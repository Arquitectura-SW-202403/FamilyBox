'use client'

import { useState } from 'react'
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from "@/components/ui/dialog"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"

type Reservation = {
  id: number
  user: string
  space: string
  date: string
  status: 'Pendiente' | 'Confirmada' | 'Pagada'
}

export default function ReservationsManagement() {
  const [reservations, setReservations] = useState<Reservation[]>([
    { id: 1, user: 'Juan Pérez', space: 'Sala A', date: '2023-06-15', status: 'Pendiente' },
    { id: 2, user: 'María García', space: 'Sala B', date: '2023-06-16', status: 'Confirmada' },
  ])
  const [newReservation, setNewReservation] = useState({ user: '', space: '', date: '' })

  const addReservation = () => {
    setReservations([...reservations, { id: reservations.length + 1, ...newReservation, status: 'Pendiente' }])
    setNewReservation({ user: '', space: '', date: '' })
  }

  const updateStatus = (id: number, status: 'Pendiente' | 'Confirmada' | 'Pagada') => {
    setReservations(reservations.map(res => res.id === id ? { ...res, status } : res))
  }

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold">Gestión de Reservas y Pagos</h1>
      <Dialog>
        <DialogTrigger asChild>
          <Button>Nueva Reserva</Button>
        </DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Nueva Reserva</DialogTitle>
          </DialogHeader>
          <div className="space-y-4">
            <Input
              placeholder="Usuario"
              value={newReservation.user}
              onChange={(e) => setNewReservation({ ...newReservation, user: e.target.value })}
            />
            <Input
              placeholder="Espacio"
              value={newReservation.space}
              onChange={(e) => setNewReservation({ ...newReservation, space: e.target.value })}
            />
            <Input
              type="date"
              value={newReservation.date}
              onChange={(e) => setNewReservation({ ...newReservation, date: e.target.value })}
            />
            <Button onClick={addReservation}>Guardar</Button>
          </div>
        </DialogContent>
      </Dialog>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Usuario</TableHead>
            <TableHead>Espacio</TableHead>
            <TableHead>Fecha</TableHead>
            <TableHead>Estado</TableHead>
            <TableHead>Acciones</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {reservations.map((reservation) => (
            <TableRow key={reservation.id}>
              <TableCell>{reservation.user}</TableCell>
              <TableCell>{reservation.space}</TableCell>
              <TableCell>{reservation.date}</TableCell>
              <TableCell>{reservation.status}</TableCell>
              <TableCell>
                <Select onValueChange={(value) => updateStatus(reservation.id, value as 'Pendiente' | 'Confirmada' | 'Pagada')}>
                  <SelectTrigger className="w-[180px]">
                    <SelectValue placeholder="Cambiar estado" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="Pendiente">Pendiente</SelectItem>
                    <SelectItem value="Confirmada">Confirmada</SelectItem>
                    <SelectItem value="Pagada">Pagada</SelectItem>
                  </SelectContent>
                </Select>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  )
}