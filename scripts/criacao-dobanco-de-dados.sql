
CREATE TABLE Cooperativa (
	iCodCooperativa int identity,
	sDescricao varchar(100),
	PRIMARY KEY (iCodCooperativa)
);

CREATE TABLE TipoChavePix (
	iCodPix int ,
	sDescricao varchar(100),
	PRIMARY KEY (iCodPix)
);

CREATE TABLE Cooperado (
	iCodCooperado int identity,
	iCodCooperativa int not null,
	iContaCorrente int not null,
	sNomeCooperado varchar(100)

		PRIMARY KEY (iCodCooperado),
	CONSTRAINT FK_CooperadoCooperativa FOREIGN KEY (iCodCooperativa)
    REFERENCES Cooperado(iCodCooperado)
);

CREATE TABLE ContatosFavoritos (
	iCodFavorito int identity,
	iCodCooperado int not null,
	sNomeContatoFavorito varchar(100) not null,
	iCodPix int not null,
	sChavePix varchar(100) not null

		PRIMARY KEY (iCodFavorito),
	CONSTRAINT FK_ContatosFavoritosCooperado FOREIGN KEY (iCodCooperado)
    REFERENCES ContatosFavoritos(iCodFavorito)
);

--insert into TipoChavePix (iCodPix,sDescricao) values (0 , 'CPF')
--insert into TipoChavePix (iCodPix,sDescricao) values (1 , 'CNPJ')
--insert into TipoChavePix (iCodPix,sDescricao) values (2 , 'E-mail')
--insert into TipoChavePix (iCodPix,sDescricao) values (3 , 'Telefone')
--insert into TipoChavePix (iCodPix,sDescricao) values (4 , 'Aleatória')

--insert into Cooperativa (sDescricao) values('Cooperativa A')
--insert into Cooperativa (sDescricao) values('Cooperativa B')
--insert into Cooperativa (sDescricao) values('Cooperativa C')

--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (1, 123456 , 'João'     )
--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (1, 456789 , 'Maria'	 )
--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (1, 012348 , 'Pedro'	 )
--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (2, 129    , 'Luana'	 )
--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (2, 328    , 'Júlia'	 )
--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (3, 129    , 'Guimarães')
--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (3, 456789 , 'Fonseca'	 )
--insert into Cooperado (iCodCooperativa,iContaCorrente,sNomeCooperado) values (3, 885544 , 'Caro'	 )

select * from Cooperativa
select * from Cooperado
select * from ContatosFavoritos
select * from TipoChavePix