create database PeopleDatabase;
go
use PeopleDatabase;
go

create table person
(
	personID int primary key identity(1,1),
	lastName varchar(100),
	firstName varchar(100),
	middleName varchar(100)
);
go

create PROCEDURE SelectFromPersonTable
AS Select * from person
go

create PROCEDURE InsertIntoPersonTable
	@lastName varchar(100),
	@firstName varchar(100),
	@middleName varchar(100)
AS insert into person (lastName, firstName, middleName) values (@lastName, @firstName, @middleName)
go

create procedure UpdateSetPersonTable
	@personID int,
	@lastName varchar(100),
	@firstName varchar(100),
	@middleName varchar(100)
AS update person set lastName = @lastName, firstName = @firstName, middleName = @middleName where personID = @personID
go

create PROCEDURE DeleteFromPersonTable
	@personID int
AS delete from person where personID = @personID
go

create table users
(
	usersID int primary key identity(1,1),
	username varchar(50),
	password varchar(50)
);
go

create procedure SelectFromUserTable
as select * from users
go

create procedure InsertIntoUserTable
	@username varchar(50),
	@password varchar(50)
as insert into users (username, password) values (@username, @password)
go

create procedure UpdateSetUserTable
	@usersID int,
	@username varchar(50),
	@password varchar(50)
as update users set username = @username, password = @password where usersID = @usersID
go

create procedure DeleteFromUserTable
	@usersID int
AS delete from users where usersID = @usersID
go