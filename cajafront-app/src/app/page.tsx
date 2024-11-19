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

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    // Hardcoded users
    const users = [
      { email: 'admin@familiarbox.com', password: 'admin123', role: 'admin' },
      { email: 'user@familiarbox.com', password: 'user123', role: 'user' },
    ];

    const user = users.find(u => u.email === email && u.password === password);

    if (user) {
      localStorage.setItem('authToken', JSON.stringify({ role: user.role }));
      router.push(`/${user.role}/dashboard`);
    } else {
      setError('Correo electrónico o contraseña inválidos');
    }
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
            <Label htmlFor="email">Correo electrónico</Label>
            <Input
              type="email"
              id="email"
              placeholder="correo@ejemplo.com"
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