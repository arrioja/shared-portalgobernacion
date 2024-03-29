SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT;
SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS;
SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION;
SET NAMES utf8;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE=NO_AUTO_VALUE_ON_ZERO */;


CREATE DATABASE /*!32312 IF NOT EXISTS*/ `portalgobernacion`;
USE `portalgobernacion`;
CREATE TABLE `contactos` (
  `ContactoID` int(11) NOT NULL auto_increment,
  `ModuloID` int(10) unsigned NOT NULL default '0',
  `Nombre` varchar(50) NOT NULL default '',
  `Cargo` varchar(100) NOT NULL default '',
  `Email` varchar(100) NOT NULL default '',
  `Contacto1` varchar(100) NOT NULL default '',
  `Contacto2` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`ContactoID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO `contactos` (`ContactoID`,`ModuloID`,`Nombre`,`Cargo`,`Email`,`Contacto1`,`Contacto2`) VALUES 
 (2,23,'Pedro Enrique Arrioja Marcano','Director de Organización y Sistemas','arrioja@cene.gov.ve','0416-7961306','0295-2422124');
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT;
SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS;
SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
