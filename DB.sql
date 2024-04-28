-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table tpcompanion.aide
CREATE TABLE IF NOT EXISTS `aide` (
  `id_aide` int NOT NULL AUTO_INCREMENT,
  `dte_demande` datetime NOT NULL,
  `description` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '0',
  `fk_id_tp` int DEFAULT NULL,
  `fk_id_eleve` int DEFAULT NULL,
  PRIMARY KEY (`id_aide`),
  KEY `fk_tp_aide` (`fk_id_tp`),
  KEY `fk_eleve_aide` (`fk_id_eleve`),
  CONSTRAINT `fk_eleve_aide` FOREIGN KEY (`fk_id_eleve`) REFERENCES `eleve` (`id_eleve`),
  CONSTRAINT `fk_tp_aide` FOREIGN KEY (`fk_id_tp`) REFERENCES `tp` (`id_tp`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table tpcompanion.eleve
CREATE TABLE IF NOT EXISTS `eleve` (
  `id_eleve` int NOT NULL AUTO_INCREMENT,
  `identifiant` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `prenom` varchar(50) DEFAULT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `fk_id_groupe` int DEFAULT NULL,
  `fk_id_promo` int NOT NULL,
  PRIMARY KEY (`id_eleve`),
  KEY `fk_id_groupe` (`fk_id_groupe`) USING BTREE,
  KEY `fk_id_promo` (`fk_id_promo`) USING BTREE,
  CONSTRAINT `fk_eleve_groupe` FOREIGN KEY (`fk_id_groupe`) REFERENCES `groupe` (`id_groupe`),
  CONSTRAINT `fk_eleve_promo` FOREIGN KEY (`fk_id_promo`) REFERENCES `promotion` (`id_promo`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table tpcompanion.eleve_tache
CREATE TABLE IF NOT EXISTS `eleve_tache` (
  `fk_id_eleve` int NOT NULL,
  `fk_id_tache` int NOT NULL,
  `etat` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`fk_id_eleve`,`fk_id_tache`),
  KEY `fk_tache_eleve` (`fk_id_tache`),
  CONSTRAINT `fk_eleve_tache` FOREIGN KEY (`fk_id_eleve`) REFERENCES `eleve` (`id_eleve`),
  CONSTRAINT `fk_tache_eleve` FOREIGN KEY (`fk_id_tache`) REFERENCES `tache` (`id_tache`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table tpcompanion.groupe
CREATE TABLE IF NOT EXISTS `groupe` (
  `id_groupe` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) DEFAULT NULL,
  `fk_id_promo` int DEFAULT NULL,
  PRIMARY KEY (`id_groupe`),
  KEY `fk_id_promo` (`fk_id_promo`),
  CONSTRAINT `fk_id_promo` FOREIGN KEY (`fk_id_promo`) REFERENCES `promotion` (`id_promo`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table tpcompanion.promotion
CREATE TABLE IF NOT EXISTS `promotion` (
  `id_promo` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`id_promo`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table tpcompanion.tache
CREATE TABLE IF NOT EXISTS `tache` (
  `id_tache` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `ordre` int DEFAULT NULL,
  `fk_id_tp` int DEFAULT NULL,
  PRIMARY KEY (`id_tache`),
  KEY `fk_id_tp` (`fk_id_tp`),
  CONSTRAINT `fk_id_tp` FOREIGN KEY (`fk_id_tp`) REFERENCES `tp` (`id_tp`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

-- Dumping structure for table tpcompanion.tp
CREATE TABLE IF NOT EXISTS `tp` (
  `id_tp` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dte_debut` datetime NOT NULL,
  `dte_fin` datetime NOT NULL,
  `is_visible` tinyint(1) NOT NULL DEFAULT '0',
  `fk_id_promo` int DEFAULT NULL,
  `fk_id_groupe` int DEFAULT NULL,
  PRIMARY KEY (`id_tp`),
  KEY `fk_tp_promo` (`fk_id_promo`) USING BTREE,
  KEY `fk_tp_groupe` (`fk_id_groupe`) USING BTREE,
  CONSTRAINT `fk_tp_groupe` FOREIGN KEY (`fk_id_groupe`) REFERENCES `groupe` (`id_groupe`),
  CONSTRAINT `fk_tp_promo` FOREIGN KEY (`fk_id_promo`) REFERENCES `promotion` (`id_promo`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Data exporting was unselected.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;

INSERT INTO `promotion` (`id_promo`, `nom`) VALUES
(1, '2021'),
(2, '2022'),
(3, '2023'),
(4, '2024'),
(5, '2025'),
(6, '2026'),
(7, '2027'),
(8, '2028'),
(9, '2029'),
(10, '2030');

INSERT INTO `groupe` (`id_groupe`, `nom`, `fk_id_promo`) VALUES
(1, 'groupe1', 1),
(2, 'groupe2', 1),
(3, 'groupe1', 2),
(4, 'groupe2', 2),
(5, 'groupe1', 3),
(6, 'groupe2', 3),
(7, 'groupe1', 4),
(8, 'groupe2', 4),
(9, 'groupe1', 5),
(10, 'groupe2', 5),
(11, 'groupe1', 6),
(12, 'groupe2', 6),
(13, 'groupe1', 7),
(14, 'groupe2', 7),
(15, 'groupe1', 8),
(16, 'groupe2', 8),
(17, 'groupe1', 9),
(18, 'groupe2', 9),
(19, 'groupe1', 10),
(20, 'groupe2', 10);

-- fill the table with some data
INSERT INTO `eleve` (`id_eleve`, `identifiant`, `password`, `prenom`, `nom`, `fk_id_groupe`, `fk_id_promo`) VALUES
(1, 'eleve1', 'password1', 'prenom1', 'nom1', 1, 1),
(2, 'eleve2', 'password2', 'prenom2', 'nom2', 2, 1),
(3, 'eleve3', 'password3', 'prenom3', 'nom3', 3, 2),
(4, 'eleve4', 'password4', 'prenom4', 'nom4', 4, 2),
(5, 'eleve5', 'password5', 'prenom5', 'nom5', 5, 3),
(6, 'eleve6', 'password6', 'prenom6', 'nom6', 6, 3),
(7, 'eleve7', 'password7', 'prenom7', 'nom7', 7, 4),
(8, 'eleve8', 'password8', 'prenom8', 'nom8', 8, 4),
(9, 'eleve9', 'password9', 'prenom9', 'nom9', 9, 5),
(10, 'eleve10', 'password10', 'prenom10', 'nom10', 10, 5),
(11, 'eleve11', 'password11', 'prenom11', 'nom11', 11, 6),
(12, 'eleve12', 'password12', 'prenom12', 'nom12', 12, 6),
(13, 'eleve13', 'password13', 'prenom13', 'nom13', 13, 7),
(14, 'eleve14', 'password14', 'prenom14', 'nom14', 14, 7),
(15, 'eleve15', 'password15', 'prenom15', 'nom15', 15, 8),
(16, 'eleve16', 'password16', 'prenom16', 'nom16', 16, 8),
(17, 'eleve17', 'password17', 'prenom17', 'nom17', 17, 9),
(18, 'eleve18', 'password18', 'prenom18', 'nom18', 18, 9),
(19, 'eleve19', 'password19', 'prenom19', 'nom19', 19, 10),
(20, 'eleve20', 'password20', 'prenom20', 'nom20', 20, 10);

INSERT INTO `tp` (`id_tp`, `nom`, `dte_debut`, `dte_fin`, `is_visible`, `fk_tp_promo`, `fk_tp_groupe`) VALUES
(1, 'tp1', '2021-01-01', '2021-01-31', 1, 1, 1),
(2, 'tp2', '2021-02-01', '2021-02-28', 1, 1, 1),
(3, 'tp3', '2021-03-01', '2021-03-31', 1, 1, 2),
(4, 'tp4', '2021-04-01', '2021-04-30', 1, 1, 2),
(5, 'tp5', '2021-05-01', '2021-05-31', 1, 2, 3),
(6, 'tp6', '2021-06-01', '2021-06-30', 1, 2, 3),
(7, 'tp7', '2021-07-01', '2021-07-31', 1, 2, 4),
(8, 'tp8', '2021-08-01', '2021-08-31', 1, 2, 4),
(9, 'tp9', '2021-09-01', '2021-09-30', 1, 3, 5),
(10, 'tp10', '2021-10-01', '2021-10-31', 1, 3, 5),
(11, 'tp11', '2021-11-01', '2021-11-30', 1, 3, 6),
(12, 'tp12', '2021-12-01', '2021-12-31', 1, 3, 6),
(13, 'tp13', '2022-01-01', '2022-01-31', 1, 4, 7),
(14, 'tp14', '2022-02-01', '2022-02-28', 1, 4, 7),
(15, 'tp15', '2022-03-01', '2022-03-31', 1, 4, 8),
(16, 'tp16', '2022-04-01', '2022-04-30', 1, 4, 8),
(17, 'tp17', '2022-05-01', '2022-05-31', 1, 5, 9),
(18, 'tp18', '2022-06-01', '2022-06-30', 1, 5, 9),
(19, 'tp19', '2022-07-01', '2022-07-31', 1, 5, 10),
(20, 'tp20', '2022-08-01', '2022-08-31', 1, 5, 10),
(21, 'tp21', '2022-09-01', '2022-09-30', 1, 6, 11),
(22, 'tp22', '2022-10-01', '2022-10-31', 1, 6, 11),
(23, 'tp23', '2022-11-01', '2022-11-30', 1, 6, 12),
(24, 'tp24', '2022-12-01', '2022-12-31', 1, 6, 12),
(25, 'tp25', '2023-01-01', '2023-01-31', 1, 7, 13),
(26, 'tp26', '2023-02-01', '2023-02-28', 1, 7, 13),
(27, 'tp27', '2023-03-01', '2023-03-31', 1, 7, 14),
(28, 'tp28', '2023-04-01', '2023-04-30', 1, 7, 14),
(29, 'tp29', '2023-05-01', '2023-05-31', 1, 8, 15),
(30, 'tp30', '2023-06-01', '2023-06-30', 1, 8, 15),
(31, 'tp31', '2023-07-01', '2023-07-31', 1, 8, 16),
(32, 'tp32', '2023-08-01', '2023-08-31', 1, 8, 16),
(33, 'tp33', '2023-09-01', '2023-09-30', 1, 9, 17),
(34, 'tp34', '2023-10-01', '2023-10-31', 1, 9, 17),
(35, 'tp35', '2023-11-01', '2023-11-30', 1, 9, 18),
(36, 'tp36', '2023-12-01', '2023-12-31', 1, 9, 18),
(37, 'tp37', '2024-01-01', '2024-01-31', 1, 10, 19),
(38, 'tp38', '2024-02-01', '2024-02-29', 1, 10, 19),
(39, 'tp39', '2024-03-01', '2024-03-31', 1, 10, 20),
(40, 'tp40', '2024-04-01', '2024-04-30', 1, 10, 20);

INSERT INTO `tache` (`id_tache`, `nom`, `description`, `ordre`, `fk_id_tp`) VALUES
(1, 'tache1', 'description1', 1, 1),
(2, 'tache2', 'description2', 2, 1),
(3, 'tache3', 'description3', 3, 2),
(4, 'tache4', 'description4', 4, 2),
(5, 'tache5', 'description5', 5, 3),
(6, 'tache6', 'description6', 6, 3),
(7, 'tache7', 'description7', 7, 4),
(8, 'tache8', 'description8', 8, 4),
(9, 'tache9', 'description9', 9, 5),
(10, 'tache10', 'description10', 10, 5),
(11, 'tache11', 'description11', 11, 6),
(12, 'tache12', 'description12', 12, 6),
(13, 'tache13', 'description13', 13, 7),
(14, 'tache14', 'description14', 14, 7),
(15, 'tache15', 'description15', 15, 8),
(16, 'tache16', 'description16', 16, 8),
(17, 'tache17', 'description17', 17, 9),
(18, 'tache18', 'description18', 18, 9),
(19, 'tache19', 'description19', 19, 10),
(20, 'tache20', 'description20', 20, 10),
(21, 'tache21', 'description21', 21, 11),
(22, 'tache22', 'description22', 22, 11),
(23, 'tache23', 'description23', 23, 12),
(24, 'tache24', 'description24', 24, 12),
(25, 'tache25', 'description25', 25, 13),
(26, 'tache26', 'description26', 26, 13),
(27, 'tache27', 'description27', 27, 14),
(28, 'tache28', 'description28', 28, 14),
(29, 'tache29', 'description29', 29, 15),
(30, 'tache30', 'description30', 30, 15),
(31, 'tache31', 'description31', 31, 16),
(32, 'tache32', 'description32', 32, 16),
(33, 'tache33', 'description33', 33, 17),
(34, 'tache34', 'description34', 34, 17),
(35, 'tache35', 'description35', 35, 18),
(36, 'tache36', 'description36', 36, 18),
(37, 'tache37', 'description37', 37, 19),
(38, 'tache38', 'description38', 38, 19),
(39, 'tache39', 'description39', 39, 20),
(40, 'tache40', 'description40', 40, 20),
(41, 'tache41', 'description41', 41, 21),
(42, 'tache42', 'description42', 42, 21),
(43, 'tache43', 'description43', 43, 22),
(44, 'tache44', 'description44', 44, 22),
(45, 'tache45', 'description45', 45, 23),
(46, 'tache46', 'description46', 46, 23),
(47, 'tache47', 'description47', 47, 24),
(48, 'tache48', 'description48', 48, 24),
(49, 'tache49', 'description49', 49, 25),
(50, 'tache50', 'description50', 50, 25),
(51, 'tache51', 'description51', 51, 26),
(52, 'tache52', 'description52', 52, 26),
(53, 'tache53', 'description53', 53, 27),
(54, 'tache54', 'description54', 54, 27),
(55, 'tache55', 'description55', 55, 28),
(56, 'tache56', 'description56', 56, 28),
(57, 'tache57', 'description57', 57, 29),
(58, 'tache58', 'description58', 58, 29),
(59, 'tache59', 'description59', 59, 30),
(60, 'tache60', 'description60', 60, 30),
(61, 'tache61', 'description61', 61, 31),
(62, 'tache62', 'description62', 62, 31),
(63, 'tache63', 'description63', 63, 32),
(64, 'tache64', 'description64', 64, 32),
(65, 'tache65', 'description65', 65, 33),
(66, 'tache66', 'description66', 66, 33),
(67, 'tache67', 'description67', 67, 34),
(68, 'tache68', 'description68', 68, 34),
(69, 'tache69', 'description69', 69, 35),
(70, 'tache70', 'description70', 70, 35),
(71, 'tache71', 'description71', 71, 36),
(72, 'tache72', 'description72', 72, 36),
(73, 'tache73', 'description73', 73, 37),
(74, 'tache74', 'description74', 74, 37),
(75, 'tache75', 'description75', 75, 38),
(76, 'tache76', 'description76', 76, 38),
(77, 'tache77', 'description77', 77, 39),
(78, 'tache78', 'description78', 78, 39),
(79, 'tache79', 'description79', 79, 40),
(80, 'tache80', 'description80', 80, 40);

INSERT INTO eleve_tache (fk_id_eleve, fk_id_tache, etat) VALUES
(1, 1, 'en cours'),
(1, 2, 'non commencé'),
(1, 3, 'en cours'),
(1, 4, 'non commencé'),
(2, 5, 'en cours'),
(2, 6, 'non commencé'),
(2, 7, 'en cours'),
(2, 8, 'non commencé'),
(3, 9, 'en cours'),
(3, 10, 'non commencé'),
(3, 11, 'en cours'),
(3, 12, 'non commencé'),
(4, 13, 'en cours'),
(4, 14, 'non commencé'),
(4, 15, 'en cours'),
(4, 16, 'non commencé'),
(5, 17, 'en cours'),
(5, 18, 'non commencé'),
(5, 19, 'en cours'),
(5, 20, 'non commencé'),
(6, 21, 'en cours'),
(6, 22, 'non commencé'),
(6, 23, 'en cours'),
(6, 24, 'non commencé'),
(7, 25, 'en cours'),
(7, 26, 'non commencé'),
(7, 27, 'en cours'),
(7, 28, 'non commencé'),
(8, 29, 'en cours'),
(8, 30, 'non commencé'),
(8, 31, 'en cours'),
(8, 32, 'non commencé'),
(9, 33, 'en cours'),
(9, 34, 'non commencé'),
(9, 35, 'en cours'),
(9, 36, 'non commencé'),
(10, 37, 'en cours'),
(10, 38, 'non commencé'),
(10, 39, 'en cours'),
(10, 40, 'non commencé'),
(11, 41, 'en cours'),
(11, 42, 'non commencé'),
(11, 43, 'en cours'),
(11, 44, 'non commencé'),
(12, 45, 'en cours'),
(12, 46, 'non commencé'),
(12, 47, 'en cours'),
(12, 48, 'non commencé'),
(13, 49, 'en cours'),
(13, 50, 'non commencé'),
(13, 51, 'en cours'),
(13, 52, 'non commencé'),
(14, 53, 'en cours'),
(14, 54, 'non commencé'),
(14, 55, 'en cours'),
(14, 56, 'non commencé'),
(15, 57, 'en cours'),
(15, 58, 'non commencé'),
(15, 59, 'en cours'),
(15, 60, 'non commencé'),
(16, 61, 'en cours'),
(16, 62, 'non commencé'),
(16, 63, 'en cours'),
(16, 64, 'non commencé'),
(17, 65, 'en cours'),
(17, 66, 'non commencé'),
(17, 67, 'en cours'),
(17, 68, 'non commencé'),
(18, 69, 'en cours'),
(18, 70, 'non commencé'),
(18, 71, 'en cours'),
(18, 72, 'non commencé'),
(19, 73, 'en cours'),
(19, 74, 'non commencé'),
(19, 75, 'en cours'),
(19, 76, 'non commencé'),
(20, 77, 'en cours'),
(20, 78, 'non commencé'),
(20, 79, 'en cours'),
(20, 80, 'non commencé');

INSERT INTO `aide` (`id_aide`, `dte_demande`, `nom`, `fk_id_eleve`, `fk_id_tp`) VALUES
(1, '2021-01-01', 'aide1', 1, 1),
(2, '2021-02-01', 'aide2', 2, 3),
(3, '2021-03-01', 'aide3', 3, 5),
(4, '2021-04-01', 'aide4', 4, 7),
(5, '2021-05-01', 'aide5', 5, 9),
(6, '2021-06-01', 'aide6', 6, 11),
(7, '2021-07-01', 'aide7', 7, 13),
(8, '2021-08-01', 'aide8', 8, 15),
(9, '2021-09-01', 'aide9', 9, 17),
(10, '2021-10-01', 'aide10', 10, 19),
(11, '2021-11-01', 'aide11', 11, 21),
(12, '2021-12-01', 'aide12', 12, 23),
(13, '2022-01-01', 'aide13', 13, 25),
(14, '2022-02-01', 'aide14', 14, 27),
(15, '2022-03-01', 'aide15', 15, 29),
(16, '2022-04-01', 'aide16', 16, 31),
(17, '2022-05-01', 'aide17', 17, 33),
(18, '2022-06-01', 'aide18', 18, 35),
(19, '2022-07-01', 'aide19', 19, 37),
(20, '2022-08-01', 'aide20', 20, 39);




