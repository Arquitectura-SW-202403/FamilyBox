'use client'

import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/label"

export default function EditProfile() {
  const [user, setUser] = useState<User>();
  const [nombre, setNombre] = useState<string>(' ');
  const [telefono, setTelefono] = useState<string>(' ');
  const [correo, setCorreo] = useState<string>(' ');
  const [apellido, setApellido] = useState<string>(' ');
  const [error, setError] = useState<string>(' ');
  const router = useRouter();

  useEffect(() => {
    const authToken = localStorage.getItem('jwt');
    if (!authToken) {
      router.push('/');
      return;
    }

    try {
      const { token, user: userr } = JSON.parse(authToken);
      console.log(userr)
      setUser(userr);

      setNombre((userr as User).nombre!)
      setApellido((userr as User).apellido!)
      setTelefono((userr as User).telefono!)
      setCorreo((userr as User).email!)

    } catch (error) {
      console.error('Error parsing auth token:', error);
      router.push('/');
    }
  }, []);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    const jwt = JSON.parse(
      localStorage.getItem('jwt')!
    ).token;

    user!.nombre = nombre;
    user!.apellido = apellido;
    user!.telefono = telefono;
    user!.email = correo;

    delete user!.tipoUsuario;
    delete (user! as any).rol;
    if ((user as any).id) user!.usuarioId = (user as any).id;
    delete (user as any).id;
    console.log(user)
    // Realiza la lógica para enviar los datos del formulario y actualizar el perfil
    const response = await fetch(`${process.env.securityUrl}/api/users/${user!.usuarioId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
        "Authorization": `Bearer ${jwt}`
      },
      body: JSON.stringify(user),
    });
    if (response.status !== 200) {
      setError('Hubo un problema al actualizar tu perfil');
      return;
    }

    localStorage.setItem('jwt', JSON.stringify({ token: jwt, user}));
    router.push('/user/dashboard');
  };

  return (
    <div className="p-8 ml-[30%] mr-[30%] mt-[10%]">
      <h1 className="text-3xl font-bold mb-6 text-center">Editar Perfil</h1>

      {error && <p className="text-red-500 text-sm">{error}</p>}

      <form onSubmit={handleSubmit} className="space-y-4">
        <div className="space-y-2">
          <Label htmlFor="fullName">Nombre</Label>
          <Input
            type="text"
            id="fullName"
            value={nombre}
            onChange={(e) => setNombre(e.target.value)}
            required
          />
        </div>

        <div className="space-y-2">
          <Label htmlFor="surname">Apellido</Label>
          <Input
            type="text"
            id="surname"
            value={apellido}
            onChange={(e) => setApellido(e.target.value)}
            required
          />
        </div>

        <div className="space-y-2">
          <Label htmlFor="email">Correo Electrónico</Label>
          <Input
            type="email"
            id="email"
            value={correo}
            onChange={(e) => setCorreo(e.target.value)}
            required
          />
        </div>

        <div className="space-y-2">
          <Label htmlFor="idCard">Telefono</Label>
          <Input
            type="text"
            id="idCard"
            value={telefono}
            onChange={(e) => setTelefono(e.target.value)}
            required
          />
        </div>

        <Button type="submit" className="w-full">Actualizar Perfil</Button>
      </form>
    </div>
  );
}
