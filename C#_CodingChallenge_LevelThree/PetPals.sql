create database Pet_Pals;
use PetPals;

create table Petss (
PetID int primary key identity(1,1),
Name varchar(100) not null,
Age int check (age >=0) not null,
Breed varchar(100),
Type varchar(50) check(type in('Dog','Cat','Bird','Reptile','Other')),
AvailableForAdoption bit not null
);

create table Shelters(
ShelterID int primary key identity(1,1),
Name varchar(100) not null,
Location varchar(255) not null
);

create table Donations (
DonationID int primary key identity(1,1),
DonorName varchar(100) not null,
DonationType varchar(50) check (DonationType in('Cash','Item')),
DonationAmount decimal(10,2) check (DonationAmount > 0),
DonationItem varchar(100),
DonationDate datetime not null
);

create table AdoptionEvents (
EventID int primary key identity(1,1),
EventName varchar(100) not null,
EventDate datetime not null,
Location varchar(255) not null
);

create table Participants (
ParticipantID int primary key identity(1,1),
participantName varchar(100) not null,
ParticipantType varchar(50) check (ParticipantType in ('Shelter','Adopter')),
EventID int,
foreign key (EventID) references AdoptionEvents (EventID)
);

--inserting data
insert into Shelters (Name, Location)
values 
('Paws Home', 'Mumbai'),
('Happy Tails', 'Chennai'),
('Safe Haven', 'Bangalore'),
('Pet Paradise', 'Delhi'),
('Rescue Ranch', 'Hyderabad'),
('Pet Shelter', 'Pune'),
('Animal Aid', 'Kolkata'),
('Stray Care', 'Ahmedabad'),
('Care4Pets', 'Jaipur'),
('Pets R Us', 'Lucknow');

insert into Petss (Name, Age, Breed, Type, AvailableForAdoption)
values 
('Bruno', 2, 'Labrador', 'Dog', 1),
('Whiskers', 3, 'Persian Cat', 'Cat', 1),
('Coco', 1, 'Golden Retriever', 'Dog', 1),
('Milo', 5, 'Beagle', 'Dog', 0),
('Simba', 4, 'Indian Pariah', 'Dog', 1),
('Luna', 6, 'Siamese Cat', 'Cat', 1),
('Rocky', 2, 'German Shepherd', 'Dog', 0),
('Kiwi', 1, 'Parrot', 'Bird', 1),
('Fluffy', 5, 'Angora Rabbit', 'Other', 1),
('Rex', 7, 'Doberman', 'Dog', 1);

insert into Donations (DonorName, DonationType, DonationAmount, DonationItem, DonationDate)
values 
('Amit Sharma', 'Cash', 5000, NULL, '2023-08-12'),
('Sneha Rao', 'Item', NULL, 'Dog Food', '2023-07-22'),
('Ravi Patel', 'Cash', 3000, NULL, '2023-06-15'),
('Neha Singh', 'Cash', 4500, NULL, '2023-08-18'),
('Raj Malhotra', 'Item', NULL, 'Cat Food', '2023-09-01'),
('Vikram Joshi', 'Cash', 6000, NULL, '2023-09-05'),
('Pooja Desai', 'Cash', 2500, NULL, '2023-07-29'),
('Anjali Verma', 'Item', NULL, 'Dog Bed', '2023-05-21'),
('Kiran Rao', 'Cash', 7000, NULL, '2023-09-20'),
('Rohit Kumar', 'Item', NULL, 'Bird Cage', '2023-06-10');

insert into AdoptionEvents (EventName, EventDate, Location)
values 
('Mega Adoption Drive', '2023-10-10', 'Mumbai'),
('Pet Fair 2023', '2023-09-15', 'Chennai'),
('Adoptathon 2023', '2023-08-20', 'Bangalore'),
('Pet Carnival', '2023-07-12', 'Delhi'),
('Stray Care Fest', '2023-09-25', 'Hyderabad'),
('Rescue Expo', '2023-06-14', 'Pune'),
('Pets Fest', '2023-05-30', 'Kolkata'),
('Furry Friends Fest', '2023-08-10', 'Ahmedabad'),
('Happy Tails Day', '2023-09-02', 'Jaipur'),
('Paw Day Out', '2023-07-18', 'Lucknow');

insert into Participants (ParticipantName, ParticipantType, EventID)
values 
('Paws Home', 'Shelter', 1),
('Happy Tails', 'Shelter', 2),
('Safe Haven', 'Shelter', 3),
('Pet Paradise', 'Shelter', 4),
('Rescue Ranch', 'Shelter', 5),
('Animal Aid', 'Shelter', 6),
('Pooja Desai', 'Adopter', 1),
('Ravi Patel', 'Adopter', 2),
('Neha Singh', 'Adopter', 3),
('Anjali Verma', 'Adopter', 4);

select * FROM Petss;


SELECT name FROM sys.tables
SELECT DB_NAME() AS CurrentDatabase;
SELECT name 
FROM sys.databases;

use Pet_Pals;
SELECT DB_NAME() AS CurrentDatabase;
-- SELECT * FROM Petss;
SELECT * 
FROM information_schema.tables
WHERE table_name = 'Petss';

ALTER TABLE Petss
DROP COLUMN AvailableForAdoption;

SELECT * FROM Donations;





