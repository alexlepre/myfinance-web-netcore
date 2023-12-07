CREATE DATABASE myfinanceweb;

use myfinanceweb;

CREATE TABLE dbo.planoconta (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	descricao varchar(100) NOT NULL,
	tipo char(1) NOT NULL
);

CREATE TABLE dbo.transacao (
	id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	planocontaid int NOT NULL FOREIGN KEY REFERENCES planoconta(id),
	descricao varchar(200) NOT NULL,
	valor float NOT NULL,
	data DATETIME NULL DEFAULT GETDATE()
);

ALTER TABLE dbo.transacao ADD formapagamentoid varchar(2); 

INSERT INTO planoconta (descricao, tipo) values ('Alimentação', 'D');
INSERT INTO planoconta (descricao, tipo) values ('Impostos', 'D');

INSERT INTO planoconta (descricao, tipo) values ('Salário', 'R');
INSERT INTO planoconta (descricao, tipo) values ('Dividendos', 'R');


select * from dbo.planoconta;
INSERT INTO transacao (descricao, valor, planocontaid) values ('Almoço', 20, 1);
select * from dbo.transacao;