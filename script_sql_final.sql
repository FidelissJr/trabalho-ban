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
			idMotorista int FOREIGN KEY REFERENCES Motorista(cnh),
			idOnibus int FOREIGN KEY REFERENCES Onibus(idOnibus)			
		)		

		PRINT 'Tabela Linha criada!'

	END

ELSE

	BEGIN

		PRINT 'Tabela Linha já existe'

	END
	
