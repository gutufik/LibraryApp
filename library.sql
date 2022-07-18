CREATE DATABASE  IF NOT EXISTS `library` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `library`;
-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: library
-- ------------------------------------------------------
-- Server version	8.0.29

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
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(45) NOT NULL,
  `author` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES (1,'Мастер и Маргарита','Михаил Булгаков'),(2,'Мёртвые души','Николай Гоголь'),(3,'Двенадцать стульев','Илья Ильф, Евгений Петров'),(4,'Собачье сердце','Михаил Булгаков'),(5,'Золотой теленок','Илья Ильф, Евгений Петров'),(6,'Преступление и наказание','Федор Достоевский'),(7,'Война и мир','Лев Толстой'),(8,'Евгений Онегин','Александр Пушкин'),(9,'Отцы и дети','Иван Тургенев'),(10,'Ревизор','Николай Гоголь'),(11,'Повести Белкина','Александр Пушкин'),(12,'Братья Карамазовы','Федор Достоевский'),(13,'Палата № 6','Антон Чехов'),(14,'Село Степанчиково и его обитатели','Федор Достоевский'),(15,'Идиот','Федор Достоевский');
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book_transfer`
--

DROP TABLE IF EXISTS `book_transfer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book_transfer` (
  `id` int NOT NULL AUTO_INCREMENT,
  `reader_id` int NOT NULL,
  `book_id` int NOT NULL,
  `transfer_type_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_transfer_type` (`transfer_type_id`),
  KEY `fk_reader` (`reader_id`),
  KEY `fk_book` (`book_id`),
  CONSTRAINT `fk_book` FOREIGN KEY (`book_id`) REFERENCES `book` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_reader` FOREIGN KEY (`reader_id`) REFERENCES `reader` (`id`) ON DELETE CASCADE,
  CONSTRAINT `fk_transfer_type` FOREIGN KEY (`transfer_type_id`) REFERENCES `transfer_type` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book_transfer`
--

LOCK TABLES `book_transfer` WRITE;
/*!40000 ALTER TABLE `book_transfer` DISABLE KEYS */;
INSERT INTO `book_transfer` VALUES (1,1,2,1),(3,4,7,1),(4,15,3,1),(5,3,3,2),(6,14,11,1),(7,6,8,1),(8,11,13,2);
/*!40000 ALTER TABLE `book_transfer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reader`
--

DROP TABLE IF EXISTS `reader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reader` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reader`
--

LOCK TABLES `reader` WRITE;
/*!40000 ALTER TABLE `reader` DISABLE KEYS */;
INSERT INTO `reader` VALUES (1,'Элина','Захарова'),(2,'Андрей','Яковлев'),(3,'Дмитрий','Хомяков'),(4,'Ярослав','Иванов'),(5,'Александра','Белякова'),(6,'Тимофей','Некрасов'),(7,'Мария','Третьякова'),(8,'Николай','Лапшин'),(9,'Дмитрий','Иванов'),(10,'Валерия','Игнатьева'),(11,'Павел','Гордеев'),(12,'Анастасия','Королева'),(13,'Егор','Крючков'),(14,'Григорий','Панкратов'),(15,'Даниил','Кононов');
/*!40000 ALTER TABLE `reader` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transfer_type`
--

DROP TABLE IF EXISTS `transfer_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transfer_type` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transfer_type`
--

LOCK TABLES `transfer_type` WRITE;
/*!40000 ALTER TABLE `transfer_type` DISABLE KEYS */;
INSERT INTO `transfer_type` VALUES (1,'Взятие'),(2,'Возврат');
/*!40000 ALTER TABLE `transfer_type` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-07-13 20:17:10
