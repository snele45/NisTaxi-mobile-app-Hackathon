--Insert data into Fuels
INSERT INTO Fuels (Name, Price) VALUES ('Evro/OPTI dizel', 195)
INSERT INTO Fuels (Name, Price) VALUES ('BMB 95/OPTI benzin', 173)
INSERT INTO Fuels (Name, Price) VALUES ('OPTI Auto gas', 93.9)
INSERT INTO Fuels (Name, Price) VALUES ('Metan CNG', 120)
INSERT INTO Fuels (Name, Price) VALUES ('G-Drive 100', 193)
INSERT INTO Fuels (Name, Price) VALUES ('G-Drive dizel', 201)

--Insert data into FuelCombinations
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('Evro/OPTI dizel', 1, NULL, 600, 0)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('BMB 95/OPTI benzin', 2, NULL, 600, 0)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('OPTI Auto gas', 3, NULL, 600, 0)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('OPTI Auto gas + BMB 95/OPTI benzin', 3, 2, 500, 100)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('Metan CNG', 4, NULL, 800, 0)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('G-Drive 100', 5, NULL, 600, 0)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('BMB 95/OPTI benzin + G-Drive 100', 2, 5, 300, 300)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('G-Drive dizel', 6, NULL, 600, 0)
INSERT INTO FuelCombinations (Name, Fuel1Id, Fuel2Id, LimitFirstFuel, LimitLastFuel) VALUES ('Evro/OPTI dizel + G-Drive dizel', 1, 6, 300, 300)


--Insert data into Drivers

INSERT INTO Drivers (CompanyName, PhoneNumber, Email, DriverName, PostalCode, Place, TaxiCardNumber, TaxiLicence, NumberOfId, DriverStatus, SMSNotification, EmailNotification, FuelCombinationId, AmountPouredFirst, AmountPouredSecond)
VALUES ('Petar Petrovic', 0613123134, 'pera@gmail.com', 'Petar Petrovic', 31260, 'Kosjeric',111000079001399,111222, 123456789, 1, 0, 0, 4, 30, 0)

INSERT INTO Drivers (CompanyName, PhoneNumber, Email, DriverName, PostalCode, Place, TaxiCardNumber, TaxiLicence, NumberOfId, DriverStatus, SMSNotification, EmailNotification, FuelCombinationId, AmountPouredFirst, AmountPouredSecond)
VALUES ('PINK Taxi', 0623123134, 'marko@gmail.com', 'Marko Markovic', 37000, 'Krusevac',121023079001399,222333, 223456789, 0, 1, 1, 13, 100,50)

INSERT INTO Drivers (CompanyName, PhoneNumber, Email, DriverName, PostalCode, Place, TaxiCardNumber, TaxiLicence, NumberOfId, DriverStatus, SMSNotification, EmailNotification, FuelCombinationId, AmountPouredFirst, AmountPouredSecond)
VALUES ('Stefan Micovic', 0615123134, 'michigan@gmail.com', 'Stefan Micovic', 15000, 'Sabac',111053079001399,444222, 125556789, 0, 0, 0, 16, 150, 200)

--Insert data into Transactions

INSERT INTO Transactions (DriverId, FuelId, Amount, Price, DateTime, PlaceOfTransaction) VALUES (1, 3, 25, 2347.5 , '2023-10-10 01:00:10', 'B.S. Beograd')

INSERT INTO Transactions (DriverId, FuelId, Amount, Price, DateTime, PlaceOfTransaction) VALUES (3, 5, 10, 1930,  '2023-10-10 01:00:10', 'B.S. Novi Sad')

