-- database
CREATE DATABASE BtzTransports COLLATE SQL_Latin1_General_CP1_CI_AI;
GO

USE BtzTransports
GO

-- tables
CREATE TABLE Veiculo (
	Id INT IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	Placa VARCHAR(7) NOT NULL,
	Fabricante VARCHAR(50) NOT NULL,
	Ano INT NOT NULL,
	TiposDeCombustivel INT NOT NULL,
	CapacidadeDoTanque DECIMAL(5, 2) NOT NULL,
	Observacoes VARCHAR(MAX),

	CONSTRAINT PK_Veiculo PRIMARY KEY (Id),
	INDEX UX_Veiculo_Placa UNIQUE (Placa)
)
GO

CREATE TABLE Motorista (
	Id INT IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	Cpf VARCHAR(11) NOT NULL,
	Cnh VARCHAR(10) NOT NULL,
	CategoriaDaCnh INT NOT NULL,
	DataDeNascimento DATE NOT NULL,
	[Status] INT NOT NULL,

	CONSTRAINT PK_Motorista PRIMARY KEY (Id),
	INDEX UX_Veiculo_Nome UNIQUE (Cpf),
	INDEX UX_Veiculo_Cnh UNIQUE (Cnh)
)
GO

CREATE TABLE Abastecimento (
	Id INT IDENTITY,
	IdVeiculo INT NOT NULL,
	IdMotoristaResponsavel INT NOT NULL,
	[Data] DATE NOT NULL,
	TipoDeCombustivel INT NOT NULL,
	PrecoDoCombustivel DECIMAL(5, 2) NOT NULL,
	Quantidade DECIMAL(5, 2) NOT NULL,

	CONSTRAINT PK_Abastecimento PRIMARY KEY (Id),
	CONSTRAINT FK_Abastecimento_IdVeiculo FOREIGN KEY (IdVeiculo) REFERENCES Veiculo (Id),
	CONSTRAINT FK_Abastecimento_IdMotoristaResponsavel FOREIGN KEY (IdMotoristaResponsavel) REFERENCES Motorista (Id),
)
GO

CREATE TABLE Combustivel (
	Tipo INT NOT NULL,
	Preco DECIMAL(4, 2) NOT NULL,

	CONSTRAINT PK_Combustivel PRIMARY KEY (Tipo)
)
GO

CREATE TABLE Usuario (
	Id INT IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	[Login] VARCHAR(20) NOT NULL,
	Senha VARCHAR(100) NOT NULL,

	CONSTRAINT PK_Usuario PRIMARY KEY (Id),
	INDEX UX_Usuario_Login UNIQUE ([Login])
)
GO

INSERT INTO Usuario (Nome, [Login], Senha) VALUES ('Administrador', 'admin', 'WMjdjvK+cHb6wicbN2ld533k4JIh0Ah8YvT+k/g5bkE=;kE8WPJnKP5iVbUOoSFr3asSK1qdrtp8uXg==') -- 123
GO

INSERT INTO Combustivel (Tipo, Preco) VALUES (1, 4.29)
INSERT INTO Combustivel (Tipo, Preco) VALUES (2, 2.99)
INSERT INTO Combustivel (Tipo, Preco) VALUES (4, 2.09)
GO