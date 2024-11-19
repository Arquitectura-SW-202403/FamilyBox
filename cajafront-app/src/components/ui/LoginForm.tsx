'use client'

import { useState } from 'react'
import { useRouter } from 'next/navigation'

export default function LoginForm() {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const router = useRouter()

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    // Aquí deberías implementar la lógica de autenticación
    // Por ejemplo, una llamada a una API de autenticación
    const response = await fetch(`${process.env.securityUrl}/api/login`, {
      method: 'POST',
      headers: { 
        'Content-Type': 'application/json',
        "Authorization": `Basic ${btoa(`${email}:${password}`)}`
      },
    })

    if (response.ok) {
      const data = await response.json()
      console.log(data)
      // Guardar el token de autenticación en localStorage o en una cookie segura
      localStorage.setItem('authToken', data.result)
      // Redirigir al usuario según su rol
      if (data.role === 'admin') {
        router.push('/admin/dashboard')
      } else if (data.role === 'user') {
        router.push('/user/dashboard')
      } else {
        router.push('/guest/dashboard')
      }
    } else {
      // Manejar errores de autenticación
      console.error('Error de autenticación')
    }
  }

  return (
    <form onSubmit={handleSubmit} className="mt-8 space-y-6">
      <input type="hidden" name="remember" value="true" />
      <div className="rounded-md shadow-sm -space-y-px">
        <div>
          <label htmlFor="email-address" className="sr-only">
            Correo electrónico
          </label>
          <input
            id="email-address"
            name="email"
            type="email"
            autoComplete="email"
            required
            className="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
            placeholder="Correo electrónico"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>
        <div>
          <label htmlFor="password" className="sr-only">
            Contraseña
          </label>
          <input
            id="password"
            name="password"
            type="password"
            autoComplete="current-password"
            required
            className="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 focus:z-10 sm:text-sm"
            placeholder="Contraseña"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
      </div>

      <div>
        <button
          type="submit"
          className="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
        >
          Iniciar sesión
        </button>
      </div>
    </form>
  )
}