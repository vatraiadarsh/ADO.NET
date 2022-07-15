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





create table drivers(
id int not null auto_increment,
name varchar(225),
contact_no varchar(225),
added_date datetime default current_timestamp,
modified_date datetime default current_timestamp on update current_timestamp,
status tinyint default 0,
primary key (id)
);

insert into drivers(name,contact_no) values ("Good driver","042123123213");
insert into drivers(name,contact_no) values ("Bad driver","0467543247");

select * from drivers;