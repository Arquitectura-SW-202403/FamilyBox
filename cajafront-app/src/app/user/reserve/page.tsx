'use client'

import { useState } from 'react'
import { useRouter } from 'next/navigation'
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Calendar } from "@/components/calendar"

export default function ReservePage() {
  const [date, setDate] = useState<Date | undefined>(new Date())
  const [space, setSpace] = useState<string>('')

  const router = useRouter()

  const handleReserve = () => {
    if (date && space) {
      // Aquí típicamente enviarías una solicitud a tu backend para crear la reserva
      console.log('Reserva realizada:', { date, space })
      // Por ahora, solo redirigimos a la página de reservas
      router.push('/user/reservations')
    } else {
      alert('Por favor, selecciona una fecha y un espacio.')
    }
  }

  return (
    <div className="p-8">
      <h1 className="text-3xl font-bold mb-6">Reservar Espacio</h1>
      <Card>
        <CardHeader>
          <CardTitle>Nueva Reserva</CardTitle>
          <CardDescription>Selecciona la fecha y el espacio que deseas reservar</CardDescription>
        </CardHeader>
        <CardContent>
          <div className="space-y-4">
            {/* Selección de espacio */}
            <div>
              <label htmlFor="space" className="block text-sm font-medium text-gray-700">
                Espacio
              </label>
              <Select onValueChange={setSpace} value={space}>
                <SelectTrigger>
                  {/* En lugar de "children", usamos SelectValue para mostrar el valor seleccionado */}
                  <SelectValue placeholder="Selecciona un espacio" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="sala-a">Sala A</SelectItem>
                  <SelectItem value="sala-b">Sala B</SelectItem>
                  <SelectItem value="auditorio">Auditorio</SelectItem>
                </SelectContent>
              </Select>
            </div>

            {/* Selección de fecha */}
            <div>
              <label className="block text-sm font-medium text-gray-700">
                Fecha
              </label>
              <Calendar
                mode="single"
                selected={date}
                onSelect={setDate}
                className="rounded-md border"
              />
            </div>

            {/* Botón de reserva */}
            <Button onClick={handleReserve} className="w-full mt-4">
              Realizar Reserva
            </Button>
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
