'use client'

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/label";

export default function Register() {
  const [nombre, setNombre] = useState('');
  const [apellido, setApellido] = useState('');
  const [cedula, setCedula] = useState('');
  const [telefono, setTelefono] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    // Verificar que las contraseñas coinciden
    if (password !== confirmPassword) {
      setError('Las contraseñas no coinciden');
      return;
    }

    // Aquí puedes realizar la lógica para registrar al usuario, por ejemplo, hacer una petición POST

    /**
     * 
     * 
     * {
          "usuarioId": "10342811291",
          "tipoDocumento": "CC",
          "nombre": "Sdebastrian",
          "apellido": "Galindo",
          "email": "email@gmaiol.com",
          "telefono": "12313213",
          "password": "firulo",
          "tipoUsuario": 1,
          "fechaRegistro": "2024-11-19T04:44:29.614Z",
          "estado": true
        }
     * 
     */

    const response = await fetch(`${process.env.securityUrl}/api/token/register`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        "usuarioId": cedula,
        "tipoDocumento": "CC",
        "nombre": nombre,
        "apellido": apellido,
        "email": email,
        "telefono": telefono,
        "password": password,
        "tipoUsuario": 1,
        "fechaRegistro": "2024-11-19T04:44:29.614Z",
        "estado": true
      }),
    });

    const data = await response.json();

    if (response.status !== 200) {
      setError('Hubo un error al registrar al usuario');
      return;
    }

    // Si el registro es exitoso, puedes redirigir al usuario
    router.push('/');
  };

  return (
    <div className="min-h-screen bg-gradient-to-b from-blue-100 to-blue-200 flex flex-col items-center justify-center p-4">
      <main className="bg-white rounded-lg shadow-xl p-8 max-w-md w-full">
        <div className="flex flex-col items-center mb-8">
          <h1 className="text-3xl font-bold text-blue-600">Registro - Familiar Box</h1>
          <p className="text-gray-600 text-center mt-2">Regístrate para acceder a tu cuenta</p>
        </div>

        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="fullName">Nombre</Label>
            <Input
              type="text"
              id="fullName"
              placeholder="Tu nombre "
              value={nombre}
              onChange={(e) => setNombre(e.target.value)}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="apellido">Apellido</Label>
            <Input
              type="text"
              id="apellido"
              placeholder="Tu apellido"
              value={apellido}
              onChange={(e) => setApellido(e.target.value)}
              required
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="idCard">Cédula</Label>
            <Input
              type="text"
              id="idCard"
              placeholder="xxxxx"
              value={cedula}
              onChange={(e) => setCedula(e.target.value)}
              required
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="email">Correo Electrónico</Label>
            <Input
              type="email"
              id="email"
              placeholder="tuemail@dominio.com"
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
          <div className="space-y-2">
            <Label htmlFor="confirmPassword">Confirmar Contraseña</Label>
            <Input
              type="password"
              id="confirmPassword"
              placeholder="••••••••"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
              required
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="phone">Telefono</Label>
            <Input
              type="text"
              id="phone"
              placeholder="Tu telefono"
              value={telefono}
              onChange={(e) => setTelefono(e.target.value)}
              required
            />
          </div>

          {error && <p className="text-red-500 text-sm">{error}</p>}
          <Button type="submit" className="w-full">
            Registrarse
          </Button>
        </form>
      </main>
    </div>
  );
}
