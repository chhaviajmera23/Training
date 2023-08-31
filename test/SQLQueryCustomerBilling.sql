create table CustomerTable
(
	custId int primary key identity(1,1),
	custName varchar(50),
	custPhone varchar(15)
)

create table ProductTable
(
	pId int primary key identity(1,1),
	prodName varchar(20),
	prodPrice money
)

create table BillTable
(
	billId int primary key identity(1,1),
	billAmount money
)

insert into ProductTable values('Pen', 10)
insert into ProductTable values('Notebook', 30)
insert into ProductTable values('Papaer', 40)
insert into ProductTable values('Pencil', 40)
insert into ProductTable values('Bottle',50)


alter table CustomerTable add billId int REFERENCES BillTable(billId)

insert into BillTable values(100)
insert into BillTable values(200)
insert into BillTable values(300)
insert into BillTable values(140)
insert into BillTable values(260)
insert into BillTable values(490)


select * from ProductTable
select * from CustomerTable
select * from BillTable
