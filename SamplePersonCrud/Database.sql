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