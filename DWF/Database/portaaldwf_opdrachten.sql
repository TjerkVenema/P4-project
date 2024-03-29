-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: portaaldwf
-- ------------------------------------------------------
-- Server version	8.0.23

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `opdrachten`
--

DROP TABLE IF EXISTS `opdrachten`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `opdrachten` (
  `opdracht_id` int NOT NULL AUTO_INCREMENT,
  `gebruiker_id` int NOT NULL,
  `opdracht_naam` varchar(50) NOT NULL,
  `beschrijving` varchar(1000) NOT NULL,
  `gewenste_opleiding` enum('MBO','HBO','Universiteit','Anders') NOT NULL,
  `opdracht_status` enum('bezig','beschikbaar','afgerond','moet_beoordeeld') NOT NULL,
  `type` enum('advies','product','anders') NOT NULL,
  `sector` enum('website','social_media','online_marketing','online_sales','procesverbetering','security','gegevensbewerking','anders') NOT NULL,
  `opleidingsjaar` enum('1','2','3','4') NOT NULL,
  `startdatum` date DEFAULT NULL,
  `einddatum` date DEFAULT NULL,
  PRIMARY KEY (`opdracht_id`),
  KEY `gebruiker_id` (`gebruiker_id`),
  CONSTRAINT `opdrachten_ibfk_1` FOREIGN KEY (`gebruiker_id`) REFERENCES `gebruikers` (`gebruiker_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `opdrachten`
--

LOCK TABLES `opdrachten` WRITE;
/*!40000 ALTER TABLE `opdrachten` DISABLE KEYS */;
INSERT INTO `opdrachten` VALUES (1,36,'backend junior programmeur','wij zoeken een junior back end programmeur voor ons bedrijf','HBO','beschikbaar','product','website','1','2021-06-30','2022-06-24'),(2,37,'front end junior programmeur','wij zoeken een front end junior programmeur','HBO','beschikbaar','product','website','1','2021-06-09','2021-06-25'),(3,36,'trouble shoot sessie bank app','wij zoeken een student die ons kan het helpen met het trouble shooten van onze bank app','HBO','beschikbaar','anders','procesverbetering','2','2021-07-06','2021-07-13'),(4,36,'security problemen webportaal','security problemen van ons webpoortaal proberen vast te stellem','MBO','beschikbaar','advies','website','2','2021-08-16','2021-08-19'),(5,37,'whitehat hacking ','white hacker gezocht voor het onderzoeken van onze applicatie','HBO','beschikbaar','advies','gegevensbewerking','2','2021-09-14','2021-09-18'),(6,37,'training datalek','wij zoeken een student om een simulatie voor het dichten van een datalek mee te oefenen','MBO','beschikbaar','anders','security','3','2021-06-26','2021-06-30'),(7,36,'code review','wij willen een HBO student hebben die de code van onze app na kan lopen en kan controleren op bugs','HBO','bezig','advies','security','3','2021-06-16','2021-06-22');
/*!40000 ALTER TABLE `opdrachten` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-22 10:48:56
