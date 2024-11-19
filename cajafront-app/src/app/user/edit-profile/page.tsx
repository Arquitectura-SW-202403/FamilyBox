'use client'

import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/label"

export default function EditProfile() {
  const [user, setUser] = useState<any>({});
  const [fullName, setFullName] = useState('');
  const [email, setEmail] = useState('');
  const [idCard, setIdCard] = useState('');
  const [error, setError] = useState('');
  const router = useRouter();

  useEffect(() => {
    const authToken = localStorage.getItem('jwt');
    if (!authToken) {
      router.push('/');
      return;
    }

    try {
      const { token, user } = JSON.parse(authToken);
      setUser(user);
      setFullName(user.nombre);
      setEmail(user.email);
      setIdCard(user.idCard);
    } catch (error) {
      console.error('Error parsing auth token:', error);
      router.push('/');
    }
  }, [router]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    const authToken = localStorage.getItem('jwt');


    // Realiza la lógica para enviar los datos del formulario y actualizar el perfil
    const response = await fetch(`${process.env.securityUrl}/api/users/${user.id}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        fullName,
        idCard,
        email,
      }),
    });

    const data = await response.json();

    if (response.status !== 200) {
      setError('Hubo un problema al actualizar tu perfil');
      return;
    }

    // Guardar los datos actualizados en localStorage y redirigir
    const updatedUser = { ...user, fullName, email, idCard };
    localStorage.setItem('jwt', JSON.stringify({ token: user.token, user: updatedUser }));
    router.push('/user/dashboard');
  };

  return (
    <div className="p-8">
      <h1 className="text-3xl font-bold mb-6">Editar Perfil</h1>

      {error && <p className="text-red-500 text-sm">{error}</p>}

      <form onSubmit={handleSubmit} className="space-y-4">
        <div className="space-y-2">
          <Label htmlFor="fullName">Nombre Completo</Label>
          <Input
            type="text"
            id="fullName"
            value={fullName}
            onChange={(e) => setFullName(e.target.value)}
            required
          />
        </div>

        <div className="space-y-2">
          <Label htmlFor="email">Correo Electrónico</Label>
          <Input
            type="email"
            id="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>

        <div className="space-y-2">
          <Label htmlFor="idCard">Cédula</Label>
          <Input
            type="text"
            id="idCard"
            value={idCard}
            onChange={(e) => setIdCard(e.target.value)}
            required
          />
        </div>

        <Button type="submit" className="w-full">Actualizar Perfil</Button>
      </form>
    </div>
  );
}
