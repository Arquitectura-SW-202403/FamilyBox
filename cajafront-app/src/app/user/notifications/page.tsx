import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import ProtectedRoute from '@/components/ui/ProtectedRoute'

// Esta sería una interfaz para las notificaciones. En una aplicación real, 
// probablemente obtendrías estos datos de una API.
interface Notification {
  id: string;
  title: string;
  message: string;
  date: string;
}

const mockNotifications: Notification[] = [
  { id: '1', title: 'Reserva Confirmada', message: 'Tu reserva para la Sala A ha sido confirmada.', date: '2023-05-15' },
  { id: '2', title: 'Recordatorio', message: 'Tu reserva es mañana a las 10:00 AM.', date: '2023-05-16' },
  { id: '3', title: 'Nueva Política', message: 'Se han actualizado las políticas de uso de espacios.', date: '2023-05-17' },
]

export default function NotificationsPage() {
  return (
    <ProtectedRoute allowedRoles={['user']}>
      <div className="p-8">
        <h1 className="text-3xl font-bold mb-6">Mis Notificaciones</h1>
        <div className="space-y-4">
          {mockNotifications.map((notification) => (
            <Card key={notification.id}>
              <CardHeader>
                <CardTitle>{notification.title}</CardTitle>
                <CardDescription>{notification.date}</CardDescription>
              </CardHeader>
              <CardContent>
                <p>{notification.message}</p>
              </CardContent>
            </Card>
          ))}
        </div>
      </div>
    </ProtectedRoute>
  )
}