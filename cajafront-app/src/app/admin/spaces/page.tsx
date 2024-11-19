'use client'

import { useState } from 'react'
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from "@/components/ui/dialog"

type Space = {
  id: number
  name: string
  capacity: number
  price: number
}

export default function SpacesManagement() {
  const [spaces, setSpaces] = useState<Space[]>([
    { id: 1, name: 'Sala A', capacity: 10, price: 100 },
    { id: 2, name: 'Sala B', capacity: 20, price: 200 },
  ])
  const [newSpace, setNewSpace] = useState({ name: '', capacity: 0, price: 0 })

  const addSpace = () => {
    setSpaces([...spaces, { id: spaces.length + 1, ...newSpace }])
    setNewSpace({ name: '', capacity: 0, price: 0 })
  }

  const deleteSpace = (id: number) => {
    setSpaces(spaces.filter(space => space.id !== id))
  }

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold">Gestión de Espacios</h1>
      <Dialog>
        <DialogTrigger asChild>
          <Button>Agregar Espacio</Button>
        </DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Agregar Nuevo Espacio</DialogTitle>
          </DialogHeader>
          <div className="space-y-4">
            <Input
              placeholder="Nombre"
              value={newSpace.name}
              onChange={(e) => setNewSpace({ ...newSpace, name: e.target.value })}
            />
            <Input
              placeholder="Capacidad"
              type="number"
              value={newSpace.capacity}
              onChange={(e) => setNewSpace({ ...newSpace, capacity: Number(e.target.value) })}
            />
            <Input
              placeholder="Precio"
              type="number"
              value={newSpace.price}
              onChange={(e) => setNewSpace({ ...newSpace, price: Number(e.target.value) })}
            />
            <Button onClick={addSpace}>Guardar</Button>
          </div>
        </DialogContent>
      </Dialog>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Nombre</TableHead>
            <TableHead>Capacidad</TableHead>
            <TableHead>Precio</TableHead>
            <TableHead>Acciones</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {spaces.map((space) => (
            <TableRow key={space.id}>
              <TableCell>{space.name}</TableCell>
              <TableCell>{space.capacity}</TableCell>
              <TableCell>${space.price}</TableCell>
              <TableCell>
                <Button variant="destructive" onClick={() => deleteSpace(space.id)}>Eliminar</Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  )
}