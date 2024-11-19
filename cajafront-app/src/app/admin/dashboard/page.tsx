'use client'

import { useEffect } from 'react'
import { useRouter } from 'next/navigation'
import Link from 'next/link'
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import LogoutButton from '@/components/ui/LogoutButton'

export default function AdminDashboard() {
  const router = useRouter()

  useEffect(() => {
    const authToken = localStorage.getItem('authToken')
    if (!authToken) {
      router.push('/')
      return
    }

    try {
      const { role } = JSON.parse(authToken)
      if (role !== 'admin') {
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
        <h1 className="text-3xl font-bold">Panel de Administración</h1>
        <LogoutButton />
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        <Card>
          <CardHeader>
            <CardTitle>Reservas</CardTitle>
            <CardDescription>Gestionar reservas de espacios</CardDescription>
          </CardHeader>
          <CardContent>
            <Button asChild className="w-full">
              <Link href="/admin/reservations">Ver Reservas</Link>
            </Button>
          </CardContent>
        </Card>
        <Card>
          <CardHeader>
            <CardTitle>Espacios</CardTitle>
            <CardDescription>Administrar espacios disponibles</CardDescription>
          </CardHeader>
          <CardContent>
            <Button asChild className="w-full">
              <Link href="/admin/spaces">Gestionar Espacios</Link>
            </Button>
          </CardContent>
        </Card>
        <Card>
          <CardHeader>
            <CardTitle>Notificaciones</CardTitle>
            <CardDescription>Enviar notificaciones a usuarios</CardDescription>
          </CardHeader>
          <CardContent>
            <Button asChild className="w-full">
              <Link href="/admin/notifications">Gestionar Notificaciones</Link>
            </Button>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}