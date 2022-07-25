create database Rodoviaria

USE Rodoviaria

GO

SET ANSI_NULLS ON

GO


IF(NOT EXISTS (SELECT 1 FROM SYS.TABLES T WHERE T.name = 'Motorista' ))

	BEGIN

		CREATE TABLE Motorista(
			idMotorista int PRIMARY KEY IDENTITY(1,1) NOT NULL,
			cnh int NOT NULL,
			nome nvarchar(max) NOT NULL,
			email nvarchar(max),
			ativo bit not null,
			dtNascimento Date
		)		

		PRINT 'Tabela Motorista criada!'

	END

ELSE

	BEGIN

		PRINT 'Tabela Motorista já existe'

	END
	

	
	
	
IF(NOT EXISTS (SELECT 1 FROM SYS.TABLES T WHERE T.name = 'Onibus' ))

	BEGIN

		CREATE TABLE Onibus(
			idOnibus int PRIMARY KEY IDENTITY(1,1) NOT NULL,
			cor nvarchar(max) NOT NULL,
			placa nvarchar(max) NOT NULL,
			modelo nvarchar(MAX) NOT NULL,
			observacao nvarchar(max),
			capacidade int NOT NULL,
		)		

		PRINT 'Tabela Onibus criada!'

	END

ELSE

	BEGIN

		PRINT 'Tabela Onibus já existe'

	END
	
	
IF(NOT EXISTS (SELECT 1 FROM SYS.TABLES T WHERE T.name = 'Linha' ))

	BEGIN

		CREATE TABLE Linha(
			idLinha int PRIMARY KEY IDENTITY(1,1) NOT NULL,
			nome NVARCHAR(MAX) NOT NULL,
			trajeto nvarchar(MAX) not null,
			idMotorista int FOREIGN KEY REFERENCES Motorista(idMotorista),
			idOnibus int FOREIGN KEY REFERENCES Onibus(idOnibus)			
		)		

		PRINT 'Tabela Linha criada!'

	END

ELSE

	BEGIN

		PRINT 'Tabela Linha já existe'

	END


INSERT INTO Motorista (nome, cnh, email, ativo, dtNascimento) VALUES ('Ezequias', 123456, 'ezequias@gmail.com', 'TRUE', '1956-08-25');INSERT INTO Motorista (nome, cnh, email, ativo, dtNascimento) VALUES ('José', 789123, 'jose@hotmail.com', 'TRUE', '1972-02-14');
INSERT INTO Motorista (nome, cnh, email, ativo, dtNascimento) VALUES ('Richard', 456789, 'richard@gmail.com', 'FALSE', '1980-01-05');
INSERT INTO Motorista (nome, cnh, email, ativo, dtNascimento) VALUES ('Pedro', 123123, 'pedro@hotmail.com', 'TRUE', '1984-08-06');

INSERT INTO Onibus (modelo, placa, capacidade, cor, observacao) VALUES ('Mercedez', 'MRC-1010', 60, 'Amarelo', 'tanque grande');
INSERT INTO Onibus (modelo, placa, capacidade, cor, observacao) VALUES ('Volkswagen', 'VOL-2020', 75, 'Verde', 'encher o pneu a cada 3 dias');
INSERT INTO Onibus (modelo, placa, capacidade, cor, observacao) VALUES ('Volvo', 'VOV-3030', 75, 'Azul', 'velocidade maxima 80km/h');

INSERT INTO Linha (nome, trajeto, idMotorista, idOnibus) VALUES ('Norte - Sul', 'Saida na Blumenau e ultima parada na tupy', 1, 1);
INSERT INTO Linha (nome, trajeto, idMotorista, idOnibus) VALUES ('Centro - Sul', 'Guanabara - Centro via Procópio Gomes', 1, 1);
INSERT INTO Linha (nome, trajeto, idMotorista, idOnibus) VALUES ('Centro - Norte', 'Sem parada', 1, 1);
INSERT INTO Linha (nome, trajeto, idMotorista, idOnibus) VALUES ('Norte - Sul', 'Saida na Blumenau e ultima parada na tupy', 1, 1);
INSERT INTO Linha (nome, trajeto, idMotorista, idOnibus) VALUES ('Norte - Pirabeiraba', 'via estrada da ilha', 1, 1);
INSERT INTO Linha (nome, trajeto, idMotorista, idOnibus) VALUES ('Norte - Sul', 'Sem parada', NULL, NULL);

	
