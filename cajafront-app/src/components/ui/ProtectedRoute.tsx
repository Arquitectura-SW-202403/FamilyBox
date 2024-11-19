'use client'

import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'

export default function ProtectedRoute({ children, allowedRoles }: { children: React.ReactNode, allowedRoles: string[] }) {
  const router = useRouter()
  const [isAuthorized, setIsAuthorized] = useState(false)

  useEffect(() => {
    const checkAuth = () => {
      const authToken = localStorage.getItem('authToken')
      if (!authToken) {
        router.push('/login')
        return
      }

      try {
        const { role } = JSON.parse(authToken)
        if (allowedRoles.includes(role)) {
          setIsAuthorized(true)
        } else {
          router.push('/unauthorized')
        }
      } catch (error) {
        console.error('Error parsing auth token:', error)
        router.push('/login')
      }
    }

    checkAuth()
  }, [router, allowedRoles])

  if (!isAuthorized) {
    return null // O un componente de carga
  }

  return <>{children}</>
}