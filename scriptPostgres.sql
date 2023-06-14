-- cd C:\Program Files\PostgreSQL\14\bin
-- PSQL -U postgres -d postgres
-- \c sistlabs
-- \i C:/Users/allan/Faculdade/LPRC5-2/scriptPostgres.sql
-- /dt mydb.*
-- C:\Users\allan\Faculdade\BADC5\p2\desempenho



CREATE SCHEMA IF NOT EXISTS mydb;

DROP TABLE IF EXISTS mydb.Papel ;
CREATE TABLE IF NOT EXISTS mydb.Papel (
  nomePapel VARCHAR(25) NOT NULL,
  PRIMARY KEY (nomePapel));


DROP TABLE IF EXISTS mydb.Usuarios ;
CREATE TABLE IF NOT EXISTS mydb.Usuarios (
  idUsuarios SERIAL PRIMARY KEY,
  nome VARCHAR(45) NOT NULL,
  senha VARCHAR(45) NOT NULL,
  Papel_nomePapel VARCHAR(25) NOT NULL,
  CONSTRAINT fk_Usuarios_Papel1
    FOREIGN KEY (Papel_nomePapel)
    REFERENCES mydb.Papel (nomePapel)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


DROP TABLE IF EXISTS mydb.Chamados ;
CREATE TABLE IF NOT EXISTS mydb.Chamados (
  idChamados SERIAL PRIMARY KEY,
  titulo VARCHAR(45) NULL,
  descricao VARCHAR(120) NULL,
  localizacao VARCHAR(45) NULL,
  datac DATE,
  Usuarios_idUsuarios INT,
  CONSTRAINT fk_Chamados_Usuarios1
    FOREIGN KEY (Usuarios_idUsuarios)
    REFERENCES mydb.Usuarios (idUsuarios)
    ON DELETE SET NULL
    ON UPDATE NO ACTION);


DROP TABLE IF EXISTS mydb.Horarios ;
CREATE TABLE IF NOT EXISTS mydb.Horarios (
  listaHorarios VARCHAR(30) NOT NULL,
  PRIMARY KEY (listaHorarios));


DROP TABLE IF EXISTS mydb.Laboratorios ;
CREATE TABLE IF NOT EXISTS mydb.Laboratorios (
  idLaboratorio INT NOT NULL,
  estado BOOLEAN NOT NULL,
  tipoMaquinas VARCHAR(30) NOT NULL,
  PRIMARY KEY (idLaboratorio));


DROP TABLE IF EXISTS mydb.Reserva ;
CREATE TABLE IF NOT EXISTS mydb.Reserva (
  idReserva INT PRIMARY KEY,
  Usuarios_idUsuarios INT,
  Laboratorios_idLaboratorio INT NOT NULL,
  dataReservada DATE NULL,
  dataRetirada DATE NULL,
  dataDevolucao DATE NULL,
  Horarios_listaHorarios VARCHAR(30),
  CONSTRAINT fk_Usuarios_has_Laboratorios_Usuarios
    FOREIGN KEY (Usuarios_idUsuarios)
    REFERENCES mydb.Usuarios (idUsuarios)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Usuarios_has_Laboratorios_Laboratorios1
    FOREIGN KEY (Laboratorios_idLaboratorio)
    REFERENCES mydb.Laboratorios (idLaboratorio)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Reservas_Horarios1
    FOREIGN KEY (Horarios_listaHorarios)
    REFERENCES mydb.Horarios(listaHorarios)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


DROP TABLE IF EXISTS mydb.Soluciona;
CREATE TABLE IF NOT EXISTS mydb.Soluciona (
  Chamados_idChamados INT,
  Usuarios_idUsuarios INT,
  descricao VARCHAR(120) NULL,
  PRIMARY KEY (Chamados_idChamados),
  CONSTRAINT fk_Chamados_has_Usuarios_Chamados1
    FOREIGN KEY (Chamados_idChamados)
    REFERENCES mydb.Chamados (idChamados)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Usuarios_has_Chamados_Usuario1
    FOREIGN KEY (Usuarios_idUsuarios)
    REFERENCES mydb.Usuarios (idUsuarios)
    ON DELETE CASCADE
    ON UPDATE NO ACTION);

INSERT INTO mydb.Papel(nomePapel) VALUES('Funcionario');
INSERT INTO mydb.Papel(nomePapel) VALUES('Professor');

INSERT INTO mydb.Laboratorios(idLaboratorio, estado, tipoMaquinas) VALUES (1, TRUE, 'Dell, i5');
INSERT INTO mydb.Laboratorios(idLaboratorio, estado, tipoMaquinas) VALUES (2, TRUE, 'Lenovo, i5');
INSERT INTO mydb.Laboratorios(idLaboratorio, estado, tipoMaquinas) VALUES (3, TRUE, 'Lenovo, Ryzen 5');
INSERT INTO mydb.Laboratorios(idLaboratorio, estado, tipoMaquinas) VALUES (4, TRUE, 'Notebook Lenovo, i5');

INSERT INTO mydb.Horarios(listaHorarios) VALUES('07:30 - 08:20');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('08:20 - 09:10');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('09:10 - 10:00');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('10:20 - 11:10');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('11:10 - 12:00');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('13:00 - 13:50');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('13:50 - 14:40');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('14:40 - 15:30');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('15:50 - 16:40');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('16:40 - 17:30');
INSERT INTO mydb.Horarios(listaHorarios) VALUES('17:30 - 18:20');

INSERT INTO mydb.Usuarios(nome, senha, Papel_nomePapel) VALUES('allan', '123', 'Funcionario');
INSERT INTO mydb.Usuarios(nome, senha, Papel_nomePapel) VALUES('julio', '123', 'Professor');
UPDATE mydb.Usuarios SET nome = 'jose', senha = '123', Papel_nomePapel = 'Professor' WHERE idUsuarios = 2;

DELETE FROM mydb.Reserva;
-- idReserva = lab/dia/mes/horario
INSERT INTO mydb.Reserva(idReserva, Usuarios_idUsuarios, Laboratorios_idLaboratorio, dataReservada, Horarios_listaHorarios) VALUES (1080617,100, 1, '2023-06-08', '17:30 - 18:20');
INSERT INTO mydb.Reserva(idReserva, Usuarios_idUsuarios, Laboratorios_idLaboratorio, dataReservada, Horarios_listaHorarios) VALUES (1080616,100, 1, '2023-06-08', '16:40 - 17:30');
INSERT INTO mydb.Reserva(idReserva, Usuarios_idUsuarios, Laboratorios_idLaboratorio, dataReservada, Horarios_listaHorarios) VALUES (1070617,101, 1, '2023-07-08', '16:40 - 17:30');
INSERT INTO mydb.Reserva(idReserva, Usuarios_idUsuarios, Laboratorios_idLaboratorio, dataReservada, Horarios_listaHorarios) VALUES (3080617,100, 3, '2023-05-31', '17:30 - 18:20');

DELETE FROM mydb.Chamados;
INSERT INTO mydb.Chamados(titulo, descricao, localizacao, dataC, usuarios_idusuarios) VALUES ('Cabo de rede', 'maquina 06', 'lab 2', '2023-06-07', 101);
INSERT INTO mydb.Chamados(titulo, descricao, localizacao, dataC, usuarios_idusuarios) VALUES ('Cabo de rede', 'maquina 08', 'lab 4', '2023-06-07', 100);
INSERT INTO mydb.Chamados(titulo, descricao, localizacao, dataC, usuarios_idusuarios) VALUES ('Cabo de rede', 'maquina 08 werdftgdshkdfsa', 'lab 4', '2023-06-07', 101);

INSERT INTO mydb.Soluciona(Chamados_idChamados, Usuarios_idUsuarios, descricao) VALUES (2, 100, 'Resolvido por Allan');
UPDATE mydb.Soluciona SET descricao = 'dsadasda' WHERE Chamados_idChamados = 3;

-- SELECT * FROM mydb.Usuarios WHERE nome = 'allan' AND senha = '12345'; 

-- SELECT * FROM mydb.Reserva WHERE usuarios_idusuarios = 101;

SELECT C.titulo, C.localizacao, C.descricao, C.dataC as data_chamado, C.usuarios_idusuarios as codigo_usuario, C.idChamados as codigo_chamado, S.descricao as solucao
FROM mydb.Chamados C LEFT JOIN mydb.Soluciona S ON C.idChamados = S.Chamados_idChamados;

SELECT R.Laboratorios_idLaboratorio AS Laboratorio, R.dataReservada AS data_reservada, R.Horarios_listaHorarios AS horario_reservado, U.nome AS nome_usuário, R.idReserva AS codigo_reserva 
FROM mydb.Reserva R INNER JOIN mydb.Usuarios U ON R.usuarios_idusuarios = U.idUsuarios WHERE R.dataReservada = '2023-06-13' AND R.Laboratorios_idLaboratorio = 1 AND R.Horarios_listaHorarios >= '07:30 - 08:20';