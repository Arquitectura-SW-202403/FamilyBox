'use client'

import { useRouter } from 'next/navigation'
import { Button } from "@/components/ui/button"

export default function LogoutButton() {
  const router = useRouter()

  const handleLogout = () => {
    // Eliminar el token de autenticación
    localStorage.removeItem('authToken')
    // Redirigir al usuario a la página de inicio
    router.push('/')
  }

  return (
    <Button variant="ghost" onClick={handleLogout}>
      Cerrar sesión
    </Button>
  )
}