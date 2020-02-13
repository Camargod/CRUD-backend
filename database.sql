create database Users;

use Users;

create table Admins(
id int identity,
username varchar(60),
pwd varchar(80)
);

create table Users(
id int identity,
name varchar(50),
bio varchar (200),
avatar_url varchar (300)
)


insert into Admins(username,pwd) values ('Richard','123')