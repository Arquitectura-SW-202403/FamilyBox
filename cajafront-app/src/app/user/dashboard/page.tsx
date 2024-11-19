'use client'

import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import Link from 'next/link'
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import LogoutButton from '@/components/ui/LogoutButton'

export default function UserDashboard() {
  const router = useRouter()
  const [user, setUser] = useState({});
  useEffect(() => {
    const authToken = localStorage.getItem('jwt')
    if (!authToken) {
      router.push('/')
      return
    }

    try {
      const { token, user } = JSON.parse(authToken)
      setUser(user);
      if (user.rol !== 'user') {
        router.push('/unauthorized')
      }
    } catch (error) {
      console.error('Error parsing auth token:', error)
      router.push('/')
    }
  }, [router])

  return (
    <div className="p-8">
      <div className="flex justify-between items-center mb-6">
        <h1 className="text-3xl font-bold">Panel de Usuario</h1>
        <LogoutButton />
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {
          user.rol == "user"
          ? (
            <Card>
          <CardHeader>
            <CardTitle>Mis Reservas</CardTitle>
            <CardDescription>Ver y gestionar tus reservas</CardDescription>
          </CardHeader>
          <CardContent>
            <Button asChild className="w-full">
              <Link href="/user/reservations">Ver Mis Reservas</Link>
            </Button>
          </CardContent>
        </Card>
          ) : ("")
        }
        <Card>
          <CardHeader>
            <CardTitle>Reservar Espacio</CardTitle>
            <CardDescription>Hacer una nueva reserva</CardDescription>
          </CardHeader>
          <CardContent>
            <Button asChild className="w-full">
              <Link href="/user/reserve">Reservar Ahora</Link>
            </Button>
          </CardContent>
        </Card>
        <Card>
          <CardHeader>
            <CardTitle>Notificaciones</CardTitle>
            <CardDescription>Ver tus notificaciones</CardDescription>
          </CardHeader>
          <CardContent>
            <Button asChild className="w-full">
              <Link href="/user/notifications">Ver Notificaciones</Link>
            </Button>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}