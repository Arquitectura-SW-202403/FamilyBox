-- MySQL dump 10.13  Distrib 8.0.40, for Linux (x86_64)
--
-- Host: localhost    Database: proyecto_as
-- ------------------------------------------------------
-- Server version	8.0.40-0ubuntu0.22.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Eventos`
--

DROP TABLE IF EXISTS `Eventos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Eventos` (
  `EventoId` int NOT NULL AUTO_INCREMENT,
  `SedeId` int NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Descripcion` varchar(500) DEFAULT NULL,
  `FechaInicio` datetime(6) NOT NULL,
  `FechaFin` datetime(6) NOT NULL,
  `capcidad` int NOT NULL,
  `TarifaAfiliado` decimal(18,2) NOT NULL,
  `TarifaNoAfiliado` decimal(18,2) NOT NULL,
  `Estado` tinyint(1) NOT NULL,
  PRIMARY KEY (`EventoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Instalaciones`
--

DROP TABLE IF EXISTS `Instalaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Instalaciones` (
  `InstalacionId` int NOT NULL AUTO_INCREMENT,
  `SedeId` int NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Tipo` varchar(100) NOT NULL,
  `Capacidad` int NOT NULL,
  `Descripcion` varchar(500) DEFAULT NULL,
  `Estado` tinyint(1) NOT NULL,
  `Disponibilidad` int NOT NULL,
  PRIMARY KEY (`InstalacionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Notificaciones`
--

DROP TABLE IF EXISTS `Notificaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Notificaciones` (
  `NotificacionId` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` longtext NOT NULL,
  `Tipo` int NOT NULL,
  `Titulo` varchar(255) NOT NULL,
  `Leido` tinyint(1) NOT NULL,
  `FechaEnvio` datetime(6) NOT NULL,
  PRIMARY KEY (`NotificacionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Pagos`
--

DROP TABLE IF EXISTS `Pagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Pagos` (
  `PagoId` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` longtext NOT NULL,
  `TransaccionId` int NOT NULL,
  `Tipo` longtext,
  `Monto` decimal(18,2) NOT NULL,
  `MetodoPago` int NOT NULL,
  `EstadoPago` int NOT NULL,
  `FechaPago` datetime(6) NOT NULL,
  PRIMARY KEY (`PagoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ProgramasDep`
--

DROP TABLE IF EXISTS `ProgramasDep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ProgramasDep` (
  `ProgramaId` int NOT NULL AUTO_INCREMENT,
  `SedeId` int NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Descripcion` varchar(500) DEFAULT NULL,
  `TipoActividad` varchar(100) DEFAULT NULL,
  `Cupo` int NOT NULL,
  `FechaInicio` datetime(6) NOT NULL,
  `FechaFin` datetime(6) NOT NULL,
  `TarifaAfiliado` decimal(18,2) NOT NULL,
  `TarifaNoAfiliado` decimal(18,2) NOT NULL,
  `Estado` tinyint(1) NOT NULL,
  PRIMARY KEY (`ProgramaId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Reservas`
--

DROP TABLE IF EXISTS `Reservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Reservas` (
  `ReservaId` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` longtext NOT NULL,
  `InstalacionId` int NOT NULL,
  `FechaReserva` datetime(6) NOT NULL,
  `HoraInicio` datetime(6) NOT NULL,
  `HoraFin` datetime(6) NOT NULL,
  `Tarifa` decimal(18,2) NOT NULL,
  `Estado` int NOT NULL,
  `Creacion` datetime(6) NOT NULL,
  PRIMARY KEY (`ReservaId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Sedes`
--

DROP TABLE IF EXISTS `Sedes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Sedes` (
  `SedeId` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(255) NOT NULL,
  `Direccion` varchar(500) DEFAULT NULL,
  `Telefono` varchar(50) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Horario` varchar(100) DEFAULT NULL,
  `Estado` tinyint(1) NOT NULL,
  `FechaCreacion` datetime(6) NOT NULL,
  PRIMARY KEY (`SedeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `Usuarios`
--

DROP TABLE IF EXISTS `Usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Usuarios` (
  `UsuarioId` varchar(255) NOT NULL,
  `TipoDocumento` varchar(50) DEFAULT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Apellido` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Telefono` varchar(50) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `TipoUsuario` int NOT NULL,
  `FechaRegistro` datetime(6) NOT NULL,
  `Estado` tinyint(1) NOT NULL,
  PRIMARY KEY (`UsuarioId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-19  3:28:00
