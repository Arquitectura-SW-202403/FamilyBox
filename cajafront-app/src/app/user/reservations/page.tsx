'use client';

import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";

interface Reservation {
  id: string;
  space: string;
  date: string;
}

export default function UserReservations() {
  const router = useRouter();
  const [reservations, setReservations] = useState<Reservation[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const authToken = localStorage.getItem('jwt');
    if (!authToken) {
      router.push('/');
      return;
    }

    try {
      const { token, user } = JSON.parse(authToken);

      if (user.rol !== 'user') {
        router.push('/unauthorized');
        return;
      }

      // Fetch reservations from API
      const fetchReservations = async () => {
        try {
          const response = await fetch(`${process.env.apiUrl}/reservations`, {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          });

          if (!response.ok) {
            throw new Error('Failed to fetch reservations');
          }

          const data = await response.json();
          setReservations(data.reservations); // Assuming `data.reservations` is an array of reservations
        } catch (err) {
          console.error('Error fetching reservations:', err);
          setError('Error al cargar las reservas.');
        } finally {
          setLoading(false);
        }
      };

      fetchReservations();
    } catch (err) {
      console.error('Error parsing auth token:', err);
      router.push('/');
    }
  }, [router]);

  const handleCancelReservation = async (id: string) => {
    const authToken = localStorage.getItem('jwt');
    if (!authToken) return;

    const { token } = JSON.parse(authToken);

    try {
      const response = await fetch(`${process.env.apiUrl}/reservations/${id}`, {
        method: 'DELETE',
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      if (!response.ok) {
        throw new Error('Failed to cancel reservation');
      }

      // Remove the cancelled reservation from the state
      setReservations((prev) => prev.filter((reservation) => reservation.id !== id));
    } catch (err) {
      console.error('Error canceling reservation:', err);
      setError('Error al cancelar la reserva.');
    }
  };

  if (loading) {
    return <p className="p-8 text-center">Cargando reservas...</p>;
  }

  if (error) {
    return <p className="p-8 text-red-500 text-center">{error}</p>;
  }

  return (
    <div className="p-8">
      <h1 className="text-3xl font-bold mb-6">Mis Reservas</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
        {reservations.length > 0 ? (
          reservations.map((reservation) => (
            <Card key={reservation.id}>
              <CardHeader>
                <CardTitle>{reservation.space}</CardTitle>
                <CardDescription>Fecha: {reservation.date}</CardDescription>
              </CardHeader>
              <CardContent>
                <Button
                  variant="outline"
                  className="w-full"
                  onClick={() => handleCancelReservation(reservation.id)}
                >
                  Cancelar Reserva
                </Button>
              </CardContent>
            </Card>
          ))
        ) : (
          <p className="text-center col-span-full">No tienes reservas actualmente.</p>
        )}
      </div>
      <Button onClick={() => router.push('/user/reserve')} className="mt-6">
        Hacer Nueva Reserva
      </Button>
    </div>
  );
}
