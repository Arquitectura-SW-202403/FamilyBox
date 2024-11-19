'use client'

import { useState, useEffect } from 'react'
import { Button } from "@/components/ui/button"
import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card"

type Notification = {
  id: number
  message: string
  type: 'info' | 'success' | 'warning' | 'error'
  timestamp: string
}

export default function NotificationsManagement() {
  const [notifications, setNotifications] = useState<Notification[]>([])

  useEffect(() => {
    // Simular la recepción de notificaciones
    const interval = setInterval(() => {
      const newNotification: Notification = {
        id: Date.now(),
        message: `Nueva notificación ${Math.floor(Math.random() * 100)}`,
        type: ['info', 'success', 'warning', 'error'][Math.floor(Math.random() * 4)] as 'info' | 'success' | 'warning' | 'error',
        timestamp: new Date().toLocaleString()
      }
      setNotifications(prev => [newNotification, ...prev].slice(0, 5))
    }, 5000)

    return () => clearInterval(interval)
  }, [])

  const clearNotifications = () => {
    setNotifications([])
  }

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold">Notificaciones y Alertas</h1>
      <Button onClick={clearNotifications}>Limpiar Notificaciones</Button>
      <div className="space-y-4">
        {notifications.map((notification) => (
          <Card key={notification.id} className={`bg-${notification.type}`}>
            <CardHeader>
              <CardTitle>{notification.type.toUpperCase()}</CardTitle>
            </CardHeader>
            <CardContent>
              <p>{notification.message}</p>
              <p className="text-sm text-muted-foreground mt-2">{notification.timestamp}</p>
            </CardContent>
          </Card>
        ))}
      </div>
    </div>
  )
}