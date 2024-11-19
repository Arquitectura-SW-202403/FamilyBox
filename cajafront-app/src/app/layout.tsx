import { Inter } from 'next/font/google'
import './globals.css'

const inter = Inter({ subsets: ['latin'] })

export const metadata = {
  title: 'Familiar Box',
  description: 'Sistema de gestión para cajas de compensación',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="es">
      <body className={inter.className}>
        {children}
        <footer className="absolute bottom-0 w-full py-4 text-center text-sm text-gray-600 bg-transparent">
          © 2023 Familiar Box. Todos los derechos reservados.
        </footer>
      </body>
    </html>
  )
}