-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema info2017
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema info2017
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `info2017` DEFAULT CHARACTER SET utf8 ;
USE `info2017` ;

-- -----------------------------------------------------
-- Table `info2017`.`assistancesheet`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`assistancesheet` (
  `idAssistanceSheet` INT(11) NOT NULL,
  `idModule` INT(3) NOT NULL,
  `idStudent` INT(3) NOT NULL,
  `idTeacher` INT(3) NOT NULL,
  `date` DATETIME NULL DEFAULT NULL,
  `assisted` CHAR(1) NULL DEFAULT NULL,
  PRIMARY KEY (`idAssistanceSheet`),
  INDEX `idModule_idx` (`idModule` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`locality`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`locality` (
  `idLocality` INT(11) NOT NULL,
  `Povince` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idLocality`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`course`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`course` (
  `idCurso` INT(11) NOT NULL,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `descripcion` VARCHAR(45) NULL DEFAULT NULL,
  `inicio` VARCHAR(45) NULL DEFAULT NULL,
  `final` VARCHAR(45) NULL DEFAULT NULL,
  `direccion` VARCHAR(45) NULL DEFAULT NULL,
  `idLocalidad` VARCHAR(45) NULL DEFAULT NULL,
  `locality_idLocality` INT(11) NOT NULL,
  PRIMARY KEY (`idCurso`),
  INDEX `fk_course_locality1_idx` (`locality_idLocality` ASC),
  CONSTRAINT `fk_course_locality1`
    FOREIGN KEY (`locality_idLocality`)
    REFERENCES `info2017`.`locality` (`idLocality`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`usuarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`usuarios` (
  `idUsuario` INT(8) NOT NULL,
  `nombre` VARCHAR(50) NOT NULL,
  `apellido` VARCHAR(50) NOT NULL,
  `dni` INT(8) NOT NULL,
  `email` VARCHAR(30) NOT NULL,
  `Fecha_nacimiento` DATE NULL DEFAULT NULL,
  `direccion` VARCHAR(200) NULL DEFAULT NULL,
  `telefono` INT(15) NULL DEFAULT NULL,
  `idRol` INT(8) NOT NULL,
  `idLocalidad` INT(8) NOT NULL,
  PRIMARY KEY (`idUsuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`student` (
  `idstudent` INT NOT NULL,
  `usuarios_idUsuario` INT(8) NOT NULL,
  PRIMARY KEY (`idstudent`),
  INDEX `fk_student_usuarios1_idx` (`usuarios_idUsuario` ASC),
  CONSTRAINT `fk_student_usuarios1`
    FOREIGN KEY (`usuarios_idUsuario`)
    REFERENCES `info2017`.`usuarios` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`module-student`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`module-student` (
  `idModule-Student` INT(11) NOT NULL,
  `student_idstudent` INT NOT NULL,
  PRIMARY KEY (`idModule-Student`),
  INDEX `fk_module-student_student1_idx` (`student_idstudent` ASC),
  CONSTRAINT `fk_module-student_student1`
    FOREIGN KEY (`student_idstudent`)
    REFERENCES `info2017`.`student` (`idstudent`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`module`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`module` (
  `idmodule` INT(11) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `course_idCurso` INT(11) NOT NULL,
  `module-student_idModule-Student` INT(11) NOT NULL,
  PRIMARY KEY (`idmodule`),
  INDEX `fk_module_course1_idx` (`course_idCurso` ASC),
  INDEX `fk_module_module-student1_idx` (`module-student_idModule-Student` ASC),
  CONSTRAINT `fk_module_course1`
    FOREIGN KEY (`course_idCurso`)
    REFERENCES `info2017`.`course` (`idCurso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_module_module-student1`
    FOREIGN KEY (`module-student_idModule-Student`)
    REFERENCES `info2017`.`module-student` (`idModule-Student`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`evaluation`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`evaluation` (
  `idEvaluation` INT(11) NOT NULL,
  `module_idmodule` INT(11) NOT NULL,
  PRIMARY KEY (`idEvaluation`),
  INDEX `fk_Evaluation_module1_idx` (`module_idmodule` ASC),
  CONSTRAINT `fk_Evaluation_module1`
    FOREIGN KEY (`module_idmodule`)
    REFERENCES `info2017`.`module` (`idmodule`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`schedule`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`schedule` (
  `idschedule` INT(11) NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idschedule`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`event`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`event` (
  `idevent` INT(11) NOT NULL,
  `date` DATETIME NOT NULL,
  `description` VARCHAR(45) NOT NULL,
  `idschedule` INT(11) NOT NULL,
  `location` VARCHAR(45) NOT NULL,
  `idtype` INT(11) NOT NULL,
  `idcourse` INT(11) NOT NULL,
  PRIMARY KEY (`idevent`),
  UNIQUE INDEX `idevent_UNIQUE` (`idevent` ASC),
  INDEX `idschedule_idx` (`idschedule` ASC),
  INDEX `fk_event_1_idx` (`idcourse` ASC),
  CONSTRAINT `idschedule`
    FOREIGN KEY (`idschedule`)
    REFERENCES `info2017`.`schedule` (`idschedule`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `idcourse`
    FOREIGN KEY (`idcourse`)
    REFERENCES `info2017`.`course` (`idCurso`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`module_teacher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`module_teacher` (
  `idUser` INT(11) NOT NULL,
  `module_idmodule` INT(11) NOT NULL,
  PRIMARY KEY (`idUser`),
  INDEX `fk_module_teacher_module1_idx` (`module_idmodule` ASC),
  CONSTRAINT `fk_module_teacher_module1`
    FOREIGN KEY (`module_idmodule`)
    REFERENCES `info2017`.`module` (`idmodule`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`teacher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`teacher` (
  `idTeacher` INT(11) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `module_idmodule` INT(11) NOT NULL,
  `usuarios_idUsuario` INT(8) NOT NULL,
  `module_teacher_idUser` INT(11) NOT NULL,
  PRIMARY KEY (`idTeacher`),
  INDEX `fk_Teacher_module1_idx` (`module_idmodule` ASC),
  INDEX `fk_teacher_usuarios1_idx` (`usuarios_idUsuario` ASC),
  INDEX `fk_teacher_module_teacher1_idx` (`module_teacher_idUser` ASC),
  CONSTRAINT `fk_Teacher_module1`
    FOREIGN KEY (`module_idmodule`)
    REFERENCES `info2017`.`module` (`idmodule`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_teacher_usuarios1`
    FOREIGN KEY (`usuarios_idUsuario`)
    REFERENCES `info2017`.`usuarios` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_teacher_module_teacher1`
    FOREIGN KEY (`module_teacher_idUser`)
    REFERENCES `info2017`.`module_teacher` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`feedback`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`feedback` (
  `idfeedback` INT(11) NOT NULL,
  `Description` VARCHAR(150) NULL DEFAULT NULL,
  `Title` VARCHAR(45) NULL DEFAULT NULL,
  `IdTeacher` INT(11) NULL DEFAULT NULL,
  `IdStudent` INT(11) NULL DEFAULT NULL,
  `evaluation_idEvaluation` INT(11) NOT NULL,
  `teacher_idTeacher` INT(11) NOT NULL,
  PRIMARY KEY (`idfeedback`),
  INDEX `fk_feedback_evaluation1_idx` (`evaluation_idEvaluation` ASC),
  INDEX `fk_feedback_teacher1_idx` (`teacher_idTeacher` ASC),
  CONSTRAINT `fk_feedback_evaluation1`
    FOREIGN KEY (`evaluation_idEvaluation`)
    REFERENCES `info2017`.`evaluation` (`idEvaluation`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_feedback_teacher1`
    FOREIGN KEY (`teacher_idTeacher`)
    REFERENCES `info2017`.`teacher` (`idTeacher`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`permisos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`permisos` (
  `idPermiso` INT(8) NOT NULL,
  `nombre` VARCHAR(35) NOT NULL,
  `permiso` INT(8) NOT NULL,
  `activo` INT(8) NOT NULL,
  PRIMARY KEY (`idPermiso`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`post`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`post` (
  `idPost` INT(11) NOT NULL AUTO_INCREMENT,
  `Title` VARCHAR(45) NOT NULL,
  `Description` VARCHAR(150) NOT NULL,
  `DateTime` DATETIME NOT NULL COMMENT 'esto va a ser una clave foranea a la tabla de docente (teacher)',
  `module_idmodule` INT(11) NOT NULL,
  `teacher_idTeacher` INT(11) NOT NULL,
  PRIMARY KEY (`idPost`),
  INDEX `fk_post_module1_idx` (`module_idmodule` ASC),
  INDEX `fk_post_teacher1_idx` (`teacher_idTeacher` ASC),
  CONSTRAINT `fk_post_module1`
    FOREIGN KEY (`module_idmodule`)
    REFERENCES `info2017`.`module` (`idmodule`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_post_teacher1`
    FOREIGN KEY (`teacher_idTeacher`)
    REFERENCES `info2017`.`teacher` (`idTeacher`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`roles` (
  `idRol` INT(8) NOT NULL,
  `nombre` VARCHAR(30) NOT NULL,
  `activo` INT(8) NOT NULL,
  PRIMARY KEY (`idRol`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`roles_permisos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`roles_permisos` (
  `idRolPermiso` INT(8) NOT NULL,
  `idRol` INT(8) NOT NULL,
  `idPermiso` INT(8) NOT NULL,
  PRIMARY KEY (`idRolPermiso`),
  INDEX `idRol` (`idRol` ASC),
  INDEX `idPermiso` (`idPermiso` ASC),
  CONSTRAINT `roles_permisos_ibfk_1`
    FOREIGN KEY (`idRol`)
    REFERENCES `info2017`.`roles` (`idRol`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `roles_permisos_ibfk_2`
    FOREIGN KEY (`idPermiso`)
    REFERENCES `info2017`.`permisos` (`idPermiso`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `info2017`.`usuarios_roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `info2017`.`usuarios_roles` (
  `idUsuarioRol` INT(8) NOT NULL,
  `idUsuario` INT(8) NOT NULL,
  `idRol` INT(8) NOT NULL,
  PRIMARY KEY (`idUsuarioRol`),
  INDEX `idUsuario` (`idUsuario` ASC),
  INDEX `idRol` (`idRol` ASC),
  CONSTRAINT `usuarios_roles_ibfk_1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `info2017`.`usuarios` (`idUsuario`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `usuarios_roles_ibfk_2`
    FOREIGN KEY (`idRol`)
    REFERENCES `info2017`.`roles` (`idRol`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
