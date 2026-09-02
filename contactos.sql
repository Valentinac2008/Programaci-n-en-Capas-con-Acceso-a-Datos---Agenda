-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-09-2026 a las 03:26:48
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agenda_db`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contactos`
--

CREATE TABLE `contactos` (
  `dni` varchar(15) NOT NULL,
  `apellido` varchar(80) NOT NULL,
  `nombres` varchar(100) NOT NULL,
  `calle` varchar(120) NOT NULL,
  `depto` varchar(20) DEFAULT NULL,
  `piso` varchar(20) DEFAULT NULL,
  `ciudad` varchar(80) NOT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(120) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `contactos`
--

INSERT INTO `contactos` (`dni`, `apellido`, `nombres`, `calle`, `depto`, `piso`, `ciudad`, `telefono`, `email`) VALUES
('45123456', 'Perez', 'Juan Carlos', 'Cuenca 1500', 'A', '2', 'Buenos Aires', '1123456789', 'juan.perez@gmail.com'),
('46234567', 'Gomez', 'Maria Elena', 'Nazca 2200', 'B', '4', 'Buenos Aires', '1198765432', 'maria.gomez@gmail.com'),
('47345678', 'Lopez', 'Sofia', 'Av. Rivadavia 5000', '', '', 'Buenos Aires', '1155554444', 'sofia.lopez@gmail.com'),
('48456789', 'Rodriguez', 'Mateo Andres', 'San Martin 980', 'C', '6', 'Buenos Aires', '1133332222', 'mateo.rodriguez@gmail.com'),
('49567890', 'Fernandez', 'Lucia', 'Camacuá 1430', 'D', '3', 'Buenos Aires', '1144447777', 'lucia.fernandez@gmail.com');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contactos`
--
ALTER TABLE `contactos`
  ADD PRIMARY KEY (`dni`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
