'use client'

import Image from "next/image";
import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/label"

export default function Home() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    const response = await fetch(`${process.env.securityUrl}/api/token/login`, {
      method: 'POST',
      headers: { 
        'Content-Type': 'application/json',
        "Authorization": `Basic ${btoa(`${email}:${password}`)}`
      },
    })

    const data = await response.json()

    console.log(data)

    if (response.status == 400) {
      setError('Cedula o contraseña inválidos');
      setEmail(""); setPassword("");
      return;
    }
    data.result.user.rol = data.result.user.rol === "Admin" ? "admin" : "user";
    localStorage.setItem('jwt', JSON.stringify(data.result));

    const role = data.result.user.rol === "Admin" ? "admin" : "user";
    router.push(`/${role}/dashboard`);
  };

  return (
    <div className="min-h-screen bg-gradient-to-b from-blue-100 to-blue-200 flex flex-col items-center justify-center p-4">
      <main className="bg-white rounded-lg shadow-xl p-8 max-w-md w-full">
        <div className="flex flex-col items-center mb-8">
          <Image
            src="/placeholder.svg?height=100&width=100"
            alt="Familiar Box logo"
            width={100}
            height={100}
            className="mb-4"
          />
          <h1 className="text-3xl font-bold text-blue-600">Familiar Box</h1>
          <p className="text-gray-600 text-center mt-2">Tu caja de compensación familiar</p>
        </div>

        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="email">Cedula</Label>
            <Input
              type="text"
              id="email"
              placeholder="xxxxx"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="password">Contraseña</Label>
            <Input
              type="password"
              id="password"
              placeholder="••••••••"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>
          {error && <p className="text-red-500 text-sm">{error}</p>}
          <Button type="submit" className="w-full">
            Iniciar sesión
          </Button>
        </form>
      </main>
    </div>
  );
}