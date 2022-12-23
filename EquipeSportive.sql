USE Master
Go

DROP DATABASE EquipeSportive
GO

CREATE DATABASE EquipeSportive
GO

USE EquipeSportive
GO

CREATE TABLE Joueurs (
	nom varchar(25) PRIMARY KEY,
	prenom varchar(25),
	age char(2),
	position varchar(10),
	matchs_joues char(2),
	buts char(2),
	passes_decisives char(2)
)
GO

CREATE TABLE Tournois (
	nom varchar(25) PRIMARY KEY,
	lieu varchar(25),
	date_debut varchar(25),
	date_fin varchar(25),
)
GO

CREATE TABLE Statistiques (
	statistique varchar(15) PRIMARY KEY,
	Total char(4),
)
GO

insert into Joueurs values
('Messi', 'Lionel', 35, 'Attaque', 7, 7, 3),
('Martinez', 'Emiliano', 30, 'Gardien', 7, 0, 0),
('Di Maria', 'Angel', 34, 'Attaque', 6, 1, 1),
('Otamendi', 'Nicolas', 34, 'Défense', 6, 0, 1),
('Alvarez', 'Julian', 22, 'Attaque', 5, 4, 0),
('Romero', 'Cristian', 24, 'Défense', 5, 0, 0),
('Molina', 'Nahuel', 24, 'Défense', 3, 1, 1),
('Tagliafico', 'Nicolas', 30, 'Défense', 2, 0, 0),
('De Paul', 'Rodrigo', 28, 'Milieu', 7, 0, 0),
('Fernandez', 'Enzo', 21, 'Milieu', 7, 1, 1),
('Mac Allister', 'Alexis', 23, 'Milieu', 5, 1, 1)
GO

insert into Tournois values
('Coupe du Monde', 'Qatar', '2022-11-21', '2022-12-18'),
('Copa América', 'Brésil', '2021-07-15', '2022-08-14')
GO

insert into Statistiques values
('Buts', 34),
('Tirs', 112),
('Passes', 2341),
('Arrêts', 29)
GO

Select * from Joueurs
Select * from Tournois
Select * from Statistiques