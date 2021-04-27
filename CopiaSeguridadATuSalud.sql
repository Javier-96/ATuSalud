/*
SQLyog Community v13.1.7 (64 bit)
MySQL - 8.0.23 : Database - oceanosalud
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`oceanosalud` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `oceanosalud`;

/*Table structure for table `tablaantecedentes` */

DROP TABLE IF EXISTS `tablaantecedentes`;

CREATE TABLE `tablaantecedentes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Paciente` int DEFAULT NULL,
  `Familiar` varchar(200) DEFAULT NULL,
  `Enfermedad` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Paciente` (`Id_Paciente`),
  CONSTRAINT `tablaantecedentes_ibfk_1` FOREIGN KEY (`Id_Paciente`) REFERENCES `tablapaciente` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablaantecedentes` */

insert  into `tablaantecedentes`(`Id`,`Id_Paciente`,`Familiar`,`Enfermedad`) values 
(7,1,'wer','et'),
(8,1,NULL,NULL),
(9,3,'asdgfw','FGA');

/*Table structure for table `tablacitaspaciente` */

DROP TABLE IF EXISTS `tablacitaspaciente`;

CREATE TABLE `tablacitaspaciente` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_paciente` int DEFAULT NULL,
  `Id_profesional` int DEFAULT NULL,
  `Fecha_atencion` datetime DEFAULT NULL,
  `Fecha_acabar` datetime DEFAULT NULL,
  `Observaciones` varchar(200) DEFAULT NULL,
  `Fecha_registro` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_paciente` (`Id_paciente`),
  KEY `Id_profesional` (`Id_profesional`),
  CONSTRAINT `tablacitaspaciente_ibfk_1` FOREIGN KEY (`Id_paciente`) REFERENCES `tablapaciente` (`Id`),
  CONSTRAINT `tablacitaspaciente_ibfk_2` FOREIGN KEY (`Id_profesional`) REFERENCES `tablaprofesional` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablacitaspaciente` */

insert  into `tablacitaspaciente`(`Id`,`Id_paciente`,`Id_profesional`,`Fecha_atencion`,`Fecha_acabar`,`Observaciones`,`Fecha_registro`) values 
(1,1,1,'2021-04-09 14:37:00','2021-04-02 15:36:00',NULL,'2021-04-30 13:40:00'),
(2,1,1,'2021-04-09 13:48:00','2021-04-14 13:48:00',NULL,'2021-04-03 13:48:00');

/*Table structure for table `tablacodigociap` */

DROP TABLE IF EXISTS `tablacodigociap`;

CREATE TABLE `tablacodigociap` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(200) DEFAULT NULL,
  `Color` varchar(200) DEFAULT NULL,
  `Enfermedad` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablacodigociap` */

/*Table structure for table `tabladatosfisico` */

DROP TABLE IF EXISTS `tabladatosfisico`;

CREATE TABLE `tabladatosfisico` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) DEFAULT NULL,
  `Id_paciente` int DEFAULT NULL,
  `Peso` int DEFAULT NULL,
  `Altura` int DEFAULT NULL,
  `Alergias` varchar(200) DEFAULT NULL,
  `Grupo_sanguineo` varchar(3) DEFAULT NULL,
  `Fumador` bit(1) DEFAULT NULL,
  `Drogas` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_paciente` (`Id_paciente`),
  CONSTRAINT `tabladatosfisico_ibfk_1` FOREIGN KEY (`Id_paciente`) REFERENCES `tablapaciente` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tabladatosfisico` */

insert  into `tabladatosfisico`(`Id`,`Nombre`,`Id_paciente`,`Peso`,`Altura`,`Alergias`,`Grupo_sanguineo`,`Fumador`,`Drogas`) values 
(1,'hu',1,7,7,NULL,NULL,'\0','\0');

/*Table structure for table `tablaepisodios` */

DROP TABLE IF EXISTS `tablaepisodios`;

CREATE TABLE `tablaepisodios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Paciente` int DEFAULT NULL,
  `FechaInicio` date DEFAULT NULL,
  `FechaFinal` date DEFAULT NULL,
  `Motivo` varchar(200) DEFAULT NULL,
  `Causa` varchar(200) DEFAULT NULL,
  `Medicacion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Paciente` (`Id_Paciente`),
  CONSTRAINT `tablaepisodios_ibfk_1` FOREIGN KEY (`Id_Paciente`) REFERENCES `tablapaciente` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablaepisodios` */

insert  into `tablaepisodios`(`Id`,`Id_Paciente`,`FechaInicio`,`FechaFinal`,`Motivo`,`Causa`,`Medicacion`) values 
(1,2,'2021-04-02','2021-04-29','2454','wfegreht','qfgw'),
(2,1,'2021-04-08','2021-05-07','fesrgv','qfegr','qegvrw');

/*Table structure for table `tablaespacios` */

DROP TABLE IF EXISTS `tablaespacios`;

CREATE TABLE `tablaespacios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Reserva` int DEFAULT NULL,
  `EspacioGeneral` varchar(200) DEFAULT NULL,
  `Mobiliario` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Reserva` (`Id_Reserva`),
  CONSTRAINT `tablaespacios_ibfk_1` FOREIGN KEY (`Id_Reserva`) REFERENCES `tablareservaespacios` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablaespacios` */

insert  into `tablaespacios`(`Id`,`Id_Reserva`,`EspacioGeneral`,`Mobiliario`) values 
(1,NULL,'Gimnasio','Bici'),
(2,NULL,'Gimnasio','Cinta'),
(3,NULL,'Piscina','Carril 1'),
(4,NULL,'Quirofano','Numero 1'),
(6,3,'sjsjs','sjsjsj');

/*Table structure for table `tablamedicamentos` */

DROP TABLE IF EXISTS `tablamedicamentos`;

CREATE TABLE `tablamedicamentos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre_medicamento` varchar(50) DEFAULT NULL,
  `Forma_farmaceutica` varchar(50) DEFAULT NULL,
  `Efectos_secundarios` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablamedicamentos` */

insert  into `tablamedicamentos`(`Id`,`Nombre_medicamento`,`Forma_farmaceutica`,`Efectos_secundarios`) values 
(1,'wert','r','wer');

/*Table structure for table `tablapaciente` */

DROP TABLE IF EXISTS `tablapaciente`;

CREATE TABLE `tablapaciente` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) DEFAULT NULL,
  `Apellido1` varchar(200) DEFAULT NULL,
  `Apellido2` varchar(200) DEFAULT NULL,
  `Fecha_de_nacimiento` datetime DEFAULT NULL,
  `Seguro_privado` bit(1) DEFAULT NULL,
  `DNI` varchar(200) DEFAULT NULL,
  `Direccion_postal` varchar(200) DEFAULT NULL,
  `telefono_fijo` int DEFAULT NULL,
  `telefono_movil_1` int DEFAULT NULL,
  `telefono_movil_2` int DEFAULT NULL,
  `Sexo` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablapaciente` */

insert  into `tablapaciente`(`Id`,`Nombre`,`Apellido1`,`Apellido2`,`Fecha_de_nacimiento`,`Seguro_privado`,`DNI`,`Direccion_postal`,`telefono_fijo`,`telefono_movil_1`,`telefono_movil_2`,`Sexo`) values 
(1,'juan','sadsadasd','asdasd','2021-05-02 17:35:00','',NULL,NULL,546546,456456,456546,NULL),
(2,'234324','3423423','rewrewr','2021-04-09 12:36:00','\0','ewrewr',NULL,3,5,4,NULL),
(3,'ww','w','w','2021-04-22 17:56:00','\0','33222','22',-3,4,4,'h'),
(4,'Juan ','445t','1r5t','2021-04-20 13:00:00','\0','2135267',NULL,214356,2145,152,NULL);

/*Table structure for table `tablapatologias` */

DROP TABLE IF EXISTS `tablapatologias`;

CREATE TABLE `tablapatologias` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TablaPacienteId` int DEFAULT NULL,
  `TablaCodigoCIAPId` int DEFAULT NULL,
  `Descripcion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `TablaPacienteId` (`TablaPacienteId`),
  KEY `TablaCodigoCIAPId` (`TablaCodigoCIAPId`),
  CONSTRAINT `tablapatologias_ibfk_1` FOREIGN KEY (`TablaPacienteId`) REFERENCES `tablapaciente` (`Id`),
  CONSTRAINT `tablapatologias_ibfk_2` FOREIGN KEY (`TablaCodigoCIAPId`) REFERENCES `tablacodigociap` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablapatologias` */

/*Table structure for table `tablaprofesional` */

DROP TABLE IF EXISTS `tablaprofesional`;

CREATE TABLE `tablaprofesional` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(200) DEFAULT NULL,
  `Apellido1` varchar(200) DEFAULT NULL,
  `Apellido2` varchar(200) DEFAULT NULL,
  `Especialidad` varchar(200) DEFAULT NULL,
  `num_colegiado` int DEFAULT NULL,
  `foto` longblob,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablaprofesional` */

insert  into `tablaprofesional`(`Id`,`Nombre`,`Apellido1`,`Apellido2`,`Especialidad`,`num_colegiado`,`foto`) values 
(1,'pepe','sanchez','rodriguez','cirujanno',2234,NULL),
(2,'Jaime','Plano',NULL,'cardiologo',3412,NULL);

/*Table structure for table `tablaprofesional_paciente` */

DROP TABLE IF EXISTS `tablaprofesional_paciente`;

CREATE TABLE `tablaprofesional_paciente` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Profesional` int DEFAULT NULL,
  `Id_Paciente` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Profesional` (`Id_Profesional`),
  KEY `Id_Paciente` (`Id_Paciente`),
  CONSTRAINT `tablaprofesional_paciente_ibfk_1` FOREIGN KEY (`Id_Profesional`) REFERENCES `tablaprofesional` (`Id`),
  CONSTRAINT `tablaprofesional_paciente_ibfk_2` FOREIGN KEY (`Id_Paciente`) REFERENCES `tablapaciente` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablaprofesional_paciente` */

/*Table structure for table `tablarecetas` */

DROP TABLE IF EXISTS `tablarecetas`;

CREATE TABLE `tablarecetas` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_medicamento` int DEFAULT NULL,
  `Diagnostico` varchar(50) DEFAULT NULL,
  `Medicamento_generico` varchar(50) DEFAULT NULL,
  `Cantidad` varchar(50) DEFAULT NULL,
  `Dosis` varchar(50) DEFAULT NULL,
  `Duracion` varchar(50) DEFAULT NULL,
  `Fecha` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_medicamento` (`Id_medicamento`),
  CONSTRAINT `tablarecetas_ibfk_1` FOREIGN KEY (`Id_medicamento`) REFERENCES `tablamedicamentos` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablarecetas` */

insert  into `tablarecetas`(`Id`,`Id_medicamento`,`Diagnostico`,`Medicamento_generico`,`Cantidad`,`Dosis`,`Duracion`,`Fecha`) values 
(1,NULL,'wrt','srth','94','5er','951','2021-04-30 16:12:00');

/*Table structure for table `tablareservaespacios` */

DROP TABLE IF EXISTS `tablareservaespacios`;

CREATE TABLE `tablareservaespacios` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Id_Profesional` int DEFAULT NULL,
  `Espacio` varchar(200) DEFAULT NULL,
  `FechaInicio` datetime DEFAULT NULL,
  `FechaFin` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Id_Profesional` (`Id_Profesional`),
  CONSTRAINT `tablareservaespacios_ibfk_1` FOREIGN KEY (`Id_Profesional`) REFERENCES `tablaprofesional` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tablareservaespacios` */

insert  into `tablareservaespacios`(`Id`,`Id_Profesional`,`Espacio`,`FechaInicio`,`FechaFin`) values 
(3,2,'quirofano 1','2021-04-23 13:18:00','2021-04-22 13:18:00'),
(4,1,'1','2021-05-01 13:48:00','2021-04-25 13:48:00'),
(5,2,'quirofano 1','2021-04-14 14:06:00','2021-04-14 14:06:00');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
