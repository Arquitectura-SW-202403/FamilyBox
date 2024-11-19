'use client'

import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"

interface Reservation {
  id: string;
  space: string;
  date: string;
}

export default function UserReservations() {
  const router = useRouter()
  const [reservations, setReservations] = useState<Reservation[]>([])

  useEffect(() => {
    const authToken = localStorage.getItem('authToken')
    if (!authToken) {
      router.push('/')
      return
    }

    try {
      const { role } = JSON.parse(authToken)
      if (role !== 'user') {
        router.push('/unauthorized')
      } else {
        // Fetch reservations (mock data for now)
        setReservations([
          { id: '1', space: 'Sala A', date: '2023-05-20' },
          { id: '2', space: 'Auditorio', date: '2023-05-25' },
        ])
      }
    } catch (error) {
      console.error('Error parsing auth token:', error)
      router.push('/')
    }
  }, [router])

  return (
    <div className="p-8">
      <h1 className="text-3xl font-bold mb-6">Mis Reservas</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {reservations.map((reservation) => (
          <Card key={reservation.id}>
            <CardHeader>
              <CardTitle>{reservation.space}</CardTitle>
              <CardDescription>Fecha: {reservation.date}</CardDescription>
            </CardHeader>
            <CardContent>
              <Button variant="outline" className="w-full">
                Cancelar Reserva
              </Button>
            </CardContent>
          </Card>
        ))}
      </div>
      <Button onClick={() => router.push('/user/reserve')} className="mt-6">
        Hacer Nueva Reserva
      </Button>
    </div>
  )
}