import Link from 'next/link'
import { Button } from "@/components/ui/button"

export default function UnauthorizedPage() {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
      <h1 className="text-4xl font-bold mb-4">Acceso no autorizado</h1>
      <p className="text-xl mb-8">Lo sentimos, no tienes permiso para acceder a esta página.</p>
      <Button asChild>
        <Link href="/">Volver a la página principal</Link>
      </Button>
    </div>
  )
}