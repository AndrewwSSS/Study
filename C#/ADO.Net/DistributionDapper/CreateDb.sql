create database Distribution;
go;

use Distribution;
go;


create table Section
(
	id int identity(1, 1) primary key not null,
	Name nvarchar(100) not null,

	 constraint UniqeName unique(Name) 
)


create table Products
(
	id int  identity(1, 1) primary key not null,
	Name nvarchar(150) not null,
	Price decimal not null,
	SectionId int foreign key references [dbo].Section(id),

	constraint UniqeNameProduct unique(Name) 
)


create table promotionalProducts
(
	id int  identity(1, 1) primary key not null,
	ProductId int foreign key references [dbo].Products(id) not null,
	NewPrice bigint not null,
	DateStart date not null,
	DateEnd date not null, 
	Country nvarchar(100) not null,

	Check(DateStart < DateEnd)
)


create table Customers
(
	id int  identity(1, 1) primary key not null,
	FirstName nvarchar(100) not null,
	SecondName nvarchar(100) not null,
	Patronymic nvarchar(100) not null,
	Sex bit not null, -- 0 - female, 1 - male
	DateOfbirth date not null, 
	CountryOfResidence nvarchar(100) not null, 
	Email nvarchar(100) not null,

	Check(FirstName <> ''),
	Check(SecondName <> ''),
	Check(Patronymic <> '')

)


create table Interests
(
	id int  identity(1, 1) primary key not null,
	CustomerId int foreign key references [dbo].Customers(id) not null,
	SectionId int foreign key references [dbo].Section(id) not null

)





insert into Section values
('Techniques'),
('Stationeries'),
('Fruits'),
('Vegetables'),
('Cars'),
('Fuel')

insert into Products values
('NoteBook STROG', 99999, 1),
('Iphone 13 pro MAx', 1000, 1),
('Ipad 2021', 600, 1), 

('Paper', 1, 2),
('scissors', 5, 2), 
('glue', 7, 2), 

('Bananas', 10, 3), 
('Apples', 5, 3), 
('Mandarins', 9, 3),

('Potatoes', 3, 4),
('Ñarrot', 4, 4),
('Sugar beet', 6, 4), 

('Audi Rs 7', 35234533, 5),
('Reno Logan', 5000, 5), 
('BMW M5', 40000, 5), 

('Diesel', 0.6, 6),
('Gasoline', 1, 6),
('Gas', 0.7, 6)	

insert into Customers values
('Vova', 'Aboba', 'Pat1', 1, '1990-04-15', 'Ukraine', 'VovaAboba@gmail.com'),
('Dmitry', 'Osipov', 'Pat2', 1, '2006-05-09', 'Ukraine', 'Dmitro@gmail.com'),
('Nastya', 'Shapovalova', 'Pat3', 0, '2000-01-29', 'Ukraine', 'Shapovalova2000@gmail.com'),
('Veronika', 'Paliy', 'Pat4', 0, '2001-02-01', 'Ukraine', 'Veronika020120021@gmail.com'),
('Alex-Teylor', 'Danyko', 'Pat5', 1 , '2000-07-04', 'Russia', 'Alex0212@gmail.com'),
('Ivan', 'Dovgolutskiy', 'Pat6', 1, '1970-05-14', 'Russia', 'IvanDov@gmail.com'),
('Tatyana', 'Cramarenko', 'Pat7', 0, '1990-10-02', 'Russia', 'Cramarenko@gmail.com'),
('Marina', 'Sibileva', 'Pat8', 0, '2006-02-09', 'Russia', 'Sibileva@gmail.com')

insert into Interests values
(1, 1),
(1, 5),

(2, 1), 
(2, 2),

(3, 2),
(3, 3), 

(4, 1), 
(4, 3),

(5, 1), 
(5, 6),

(6, 1),
(6, 2),

(7, 2), 
(7, 3),

(8, 2),
(8, 4)


insert into promotionalProducts values 
(1, 999, getdate(), getdate()+10, 'Ukraine'),
(2, 700, getdate()-10, getdate()-1, 'Ukraine'),
(1, 9995, getdate(), getdate()+10, 'Russia'),
(3, 500, getdate()-5, getdate()-1, 'Russia'),

(4, 0.5, getdate(), getdate()+10, 'Ukraine'),
(5, 3, getdate(), getdate()+5, 'Ukraine'),
(6, 3, getdate()-7, getdate()-3, 'Ukraine'),
(4, 0.7,  getdate(), getdate()+4, 'Russia'),
(6, 3.5,  getdate()-4, getdate()+5, 'Russia'),

(7, 5,  getdate()-7, getdate()+7, 'Ukraine'),
(8, 3,  getdate()-2, getdate()-1, 'Ukraine'),
(9, 8,  getdate()-7, getdate()+5, 'Russia'),

(10, 1.5,  getdate()-7, getdate()+7, 'Ukraine'),
(11, 3,  getdate()-2, getdate()-1, 'Ukraine'),
(9, 5,  getdate()-7, getdate()+5, 'Russia'),

(13, 300000, getdate(), getdate()+10, 'Ukraine'),
(14, 4500, getdate(), getdate()+5, 'Ukraine'),
(14, 4600, getdate()-7, getdate()+20, 'Russia'),
(15, 35000,  getdate(), getdate()+4, 'Russia'),

(16, 0.5, getdate(), getdate()+10, 'Ukraine'),
(17, 0.5, getdate(), getdate()+5, 'Ukraine'),
(17, 0.5, getdate()-7, getdate()+20, 'Russia'),
(18, 0.5,  getdate(), getdate()+4, 'Russia')





