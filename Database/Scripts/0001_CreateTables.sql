CREATE TABLE Cars(
	Id int primary key not null identity(1,1),
	Brand nvarchar(max) not null, 
	Mileage int not null, 
	Reserved datetime null, 
);
