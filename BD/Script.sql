/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE=NO_AUTO_VALUE_ON_ZERO */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/ `Portal`;
USE `Portal`;
CREATE TABLE `articulos` (
  `ArticuloId` int(11) NOT NULL auto_increment,
  `ModuloId` int(11) NOT NULL default '0',
  `Titulo` longtext character set utf8 NOT NULL,
  `Resumen` longtext character set utf8 NOT NULL,
  `Contenido` longtext character set utf8 NOT NULL,
  `Orden` int(11) NOT NULL default '0',
  PRIMARY KEY  (`ArticuloId`),
  KEY `FK_articulos_1` (`ModuloId`),
  CONSTRAINT `FK_articulos_1` FOREIGN KEY (`ModuloId`) REFERENCES `modulos` (`ModuloID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
CREATE TABLE `enlaces` (
  `EnlaceId` int(11) NOT NULL auto_increment,
  `ModuloId` int(11) NOT NULL default '0',
  `Titulo` varchar(100) character set utf8 NOT NULL default '',
  `Url` mediumtext character set utf8 NOT NULL,
  `Descripcion` mediumtext character set utf8 NOT NULL,
  `Destino` varchar(10) character set utf8 NOT NULL default '',
  `Orden` int(11) NOT NULL default '0',
  PRIMARY KEY  (`EnlaceId`),
  KEY `FK_enlaces_1` (`ModuloId`),
  CONSTRAINT `FK_enlaces_1` FOREIGN KEY (`ModuloId`) REFERENCES `modulos` (`ModuloID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
CREATE TABLE `eventos` (
  `EventoId` int(11) NOT NULL auto_increment,
  `ModuloId` int(11) NOT NULL default '0',
  `Titulo` varchar(150) character set utf8 NOT NULL default '',
  `Descripcion` mediumtext character set utf8 NOT NULL,
  `Fecha` datetime NOT NULL default '0000-00-00 00:00:00',
  `Lugar` varchar(150) character set utf8 NOT NULL default '',
  `FechaVencimiento` datetime NOT NULL default '0000-00-00 00:00:00',
  PRIMARY KEY  (`EventoId`),
  KEY `FK_eventos_1` (`ModuloId`),
  CONSTRAINT `FK_eventos_1` FOREIGN KEY (`ModuloId`) REFERENCES `modulos` (`ModuloID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
CREATE TABLE `grupos` (
  `GrupoID` int(11) NOT NULL auto_increment,
  `Nombre` varchar(50) character set utf8 NOT NULL default '',
  PRIMARY KEY  (`GrupoID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO `grupos` (`GrupoID`,`Nombre`) VALUES (1,'Administradores'),(2,'Programadores'),(3,'Pagos'),(4,'Presupuesto'),(5,'Contabilidad'),(6,'Tesoreria'),(7,'Compras'),(8,'Bienes'),(9,'Informatica');
CREATE TABLE `htmltexto` (
  `ModuloID` int(11) NOT NULL default '0',
  `TextoHtml` longtext character set utf8 NOT NULL,
  PRIMARY KEY  (`ModuloID`),
  CONSTRAINT `FK_htmltexto_1` FOREIGN KEY (`ModuloID`) REFERENCES `modulos` (`ModuloID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO `htmltexto` (`ModuloID`,`TextoHtml`) VALUES (8,'\r\n		&lt;p&gt;Bienvenidos al portal de la Contraloría del estado Nueva Esparta. &lt;/p&gt;\r\n'),(17,'		&lt;img alt=&quot;Aico.jpg&quot; src=&quot;Datos/Imagenes/Aico.jpg&quot; border=&quot;0&quot; height=&quot;240&quot; width=&quot;320&quot;&gt;&amp;nbsp; Este es un texto html de prueba'),(20,'Agregue aqui el contenido...');
CREATE TABLE `modulos` (
  `ModuloID` int(11) NOT NULL auto_increment,
  `PagID` int(11) NOT NULL default '0',
  `ModuloDefID` int(11) NOT NULL default '0',
  `ModuloOrden` int(11) NOT NULL default '0',
  `NombrePanel` varchar(50) character set utf8 NOT NULL default '',
  `ModuloTitulo` varchar(50) character set utf8 NOT NULL default '',
  `GruposAutorizados` varchar(50) character set utf8 NOT NULL default '',
  `GruposAutorizadosEdicion` varchar(50) character set utf8 NOT NULL default '',
  `TiempoCache` int(11) NOT NULL default '0',
  PRIMARY KEY  (`ModuloID`),
  KEY `FK_modulos_1` (`PagID`),
  KEY `FK_modulos_2` (`ModuloDefID`),
  CONSTRAINT `FK_modulos_1` FOREIGN KEY (`PagID`) REFERENCES `paginas` (`PagID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_modulos_2` FOREIGN KEY (`ModuloDefID`) REFERENCES `modulosdefinicion` (`ModuloDefID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 3072 kB';
INSERT INTO `modulos` (`ModuloID`,`PagID`,`ModuloDefID`,`ModuloOrden`,`NombrePanel`,`ModuloTitulo`,`GruposAutorizados`,`GruposAutorizadosEdicion`,`TiempoCache`) VALUES (2,2,1,1,'Centro','Páginas','Todos','Administradores',0),(3,2,2,3,'Centro','Grupos de Seguridad','Todos','Administradores',0),(4,2,3,5,'Centro','Usuarios','Todos','Administradores',0),(5,2,4,1,'Derecha','Definición de Módulos','Todos','Administradores',0),(8,1,5,5,'Centro','Bienvenidos','Todos;','Administradores;',0),(14,1,14,1,'Derecha','Prueba Xml','Todos;','Administradores;',0),(15,1,15,1,'Izquierda','Imagen de Ejemplo','Todos;','Administradores;',0),(16,1,15,1,'Centro','Imagen','Todos','Administradores',0),(17,4,5,14,'Centro','Html de Pagos','Todos;','Administradores;',0),(18,4,14,10,'Izquierda','Prueba Xml','Todos','Administradores',0),(19,4,15,12,'Izquierda','Prueba Imagen','Todos','Administradores',0),(20,6,5,1,'Centro','Nuevo Modulo','Todos','Administradores',0);
CREATE TABLE `modulosconfig` (
  `ModuloID` int(11) NOT NULL default '0',
  `Configuracion` varchar(50) character set utf8 NOT NULL default '',
  `Valor` varchar(50) character set utf8 NOT NULL default '',
  PRIMARY KEY  (`ModuloID`,`Configuracion`),
  CONSTRAINT `FK_modulosconfig_1` FOREIGN KEY (`ModuloID`) REFERENCES `modulos` (`ModuloID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO `modulosconfig` (`ModuloID`,`Configuracion`,`Valor`) VALUES (14,'xmlfue','~/Datos/Xml/ventas.xml'),(14,'xslfue','~/Datos/Xml/ventas.xsl'),(15,'alto',''),(15,'ancho',''),(15,'ubicacion','~/Datos/Imagenes/ejemplo.gif'),(16,'alto',''),(16,'ancho',''),(16,'ubicacion','~/Datos/Imagenes/ejemplo.gif'),(18,'xmlfue','~/Datos/Xml/ventas.xml'),(18,'xslfue','~/Datos/Xml/ventas.xsl'),(19,'alto',''),(19,'ancho',''),(19,'ubicacion','~/Datos/Imagenes/ejemplo.gif');
CREATE TABLE `modulosdefinicion` (
  `ModuloDefID` int(11) NOT NULL auto_increment,
  `Nombre` varchar(128) character set utf8 NOT NULL default '',
  `Ubicacion` longtext character set utf8 NOT NULL,
  `Sistema` int(1) NOT NULL default '0',
  `UbicacionEdicion` longtext character set utf8 NOT NULL,
  PRIMARY KEY  (`ModuloDefID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO `modulosdefinicion` (`ModuloDefID`,`Nombre`,`Ubicacion`,`Sistema`,`UbicacionEdicion`) VALUES (1,'Páginas','/Administracion/Paginas.ascx',1,'/Administracion/EditarPaginas.ascx'),(2,'Grupos de Usuario','/Administracion/Grupos.ascx',1,'/Administracion/EditarGrupo.ascx'),(3,'Manejar Usuarios','/Administracion/Usuarios.ascx',1,'/Administracion/EditarUsuario.ascx'),(4,'Tipos de Módulo','/Administracion/DefinirModulos.ascx',1,'/Administracion/EditarDefinirModulos.ascx'),(5,'Documento Html','/Modulos/Html/Html.ascx',0,'/Modulos/Html/EditarHtml.ascx'),(14,'Documento Xml','/Modulos/Xml/Xml.ascx',0,'/Modulos/Xml/EditarXml.ascx'),(15,'Imagen','/Modulos/Imagen/Imagen.ascx',0,'/Modulos/Imagen/EditarImagen.ascx');
CREATE TABLE `paginas` (
  `PagID` int(11) NOT NULL auto_increment,
  `PagPadre` int(11) NOT NULL default '0',
  `PagOrden` int(11) NOT NULL default '0',
  `PagNombre` varchar(50) character set utf8 NOT NULL default '',
  `GruposAutorizados` varchar(50) character set utf8 NOT NULL default '',
  `Sistema` int(1) NOT NULL default '0',
  PRIMARY KEY  (`PagID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO `paginas` (`PagID`,`PagPadre`,`PagOrden`,`PagNombre`,`GruposAutorizados`,`Sistema`) VALUES (1,-1,1,'Principal','Todos;',0),(2,-1,1000,'Administración','Administradores',-1),(3,-1,5,'Teléfonos','Todos;',0),(4,-1,3,'Pagos','Todos;Administradores;Pagos;',0),(5,4,1,'Consultas','Todos;',0),(6,4,1,'Nueva Pagina3','Todos;',0),(7,5,1,'Nueva Pagina','Todos;',0),(8,5,3,'Nueva Pagina2','Todos;',0);
CREATE TABLE `preguntascomunes` (
  `PreguntaId` int(11) NOT NULL default '0',
  `ModuloId` int(11) NOT NULL default '0',
  `Pregunta` longtext character set utf8 NOT NULL,
  `Respuesta` longtext character set utf8 NOT NULL,
  PRIMARY KEY  (`PreguntaId`),
  KEY `FK_preguntascomunes_1` (`ModuloId`),
  CONSTRAINT `FK_preguntascomunes_1` FOREIGN KEY (`ModuloId`) REFERENCES `modulos` (`ModuloID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
CREATE TABLE `temas` (
  `TemaId` int(10) unsigned NOT NULL auto_increment,
  `Temas` varchar(50) NOT NULL default '',
  PRIMARY KEY  (`TemaId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
INSERT INTO `temas` (`TemaId`,`Temas`) VALUES (1,'Defecto'),(2,'Azul'),(3,'Amarillo'),(4,'BlancoNegro'),(5,'Rojo'),(6,'Verde'),(7,'Pacheco');
CREATE TABLE `usuarios` (
  `UsuarioID` int(11) NOT NULL auto_increment,
  `Usuario` varchar(50) character set utf8 NOT NULL default '',
  `Clave` varchar(20) character set utf8 default NULL,
  `Email` varchar(100) character set utf8 default NULL,
  `Nombre` varchar(50) character set utf8 default NULL,
  `Apellido` varchar(50) character set utf8 default NULL,
  `Tema` varchar(50) character set utf8 NOT NULL default 'Defecto',
  PRIMARY KEY  (`UsuarioID`),
  UNIQUE KEY `IUsuarios` (`Usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
INSERT INTO `usuarios` (`UsuarioID`,`Usuario`,`Clave`,`Email`,`Nombre`,`Apellido`,`Tema`) VALUES (1,'Admin','admin',NULL,'Administrador','','Azul'),(2,'Pedro','sala2ideas',NULL,'Pedro','Arrioja','Defecto'),(4,'Eduardo','eduardo',NULL,'Eduardo','Fuentes','Amarillo'),(5,'Francys','Francys','','Francys','Ferrer','Defecto');
CREATE TABLE `usuariosgrupos` (
  `UsuarioID` int(11) NOT NULL default '0',
  `GrupoID` int(11) NOT NULL default '0',
  PRIMARY KEY  (`UsuarioID`,`GrupoID`),
  KEY `FK_usuariosgrupos_2` (`GrupoID`),
  CONSTRAINT `FK_usuariosgrupos_1` FOREIGN KEY (`UsuarioID`) REFERENCES `usuarios` (`UsuarioID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_usuariosgrupos_2` FOREIGN KEY (`GrupoID`) REFERENCES `grupos` (`GrupoID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='InnoDB free: 4096 kB; (`UsuarioID`) REFER `Portal/usuar';
INSERT INTO `usuariosgrupos` (`UsuarioID`,`GrupoID`) VALUES (1,1),(2,1),(2,9);
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
