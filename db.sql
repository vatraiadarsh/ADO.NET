drop database ado;
create database ado;
use ado;


create table users(
id int not null auto_increment,
username varchar(225),
email varchar(225),
password varchar (225),
status tinyint default 0,
primary key (id)
);


insert into users(username,email,password) values ("Adarsh","adarsh@gmail.com","adarsh");
insert into users(username,email,password,status) values ("test","test@gmail.com","test",1);

select * from users;