USE WayMate;
GO
-- Inserting addresses
INSERT INTO address (street, number, city, postalCode, country) VALUES
('Rue de la Rivière', '204', 'Bruxelles', '1000', 'Belgium'),
('Avenue des Chênes', '44', 'Mouscron', '7700', 'Belgium'),
('Chaussée de Liège', '1', 'Verviers', '4800', 'Belgium'),
('Rue du Marché', '765', 'Bruxelles', '1000', 'Belgium'),
('Rue de la Montagne', '123', 'Liège', '4000', 'Belgium'),
('Avenue des Roses', '67', 'Namur', '5000', 'Belgium'),
('Boulevard de la Plage', '789', 'Ostende', '8400', 'Belgium'),
('Avenue du Soleil', '22', 'Bruxelles', '1000', 'Belgium'),
('Rue des Étoiles', '555', 'Charleroi', '6000', 'Belgium'),
('Chemin du Printemps', '10', 'Bruges', '8000', 'Belgium'),
('Place du Marché', '321', 'Louvain', '3000', 'Belgium'),
('Boulevard de l Avenir', '99', 'Anvers', '2000', 'Belgium'),
('Allée des Cerisiers', '77', 'Gand', '9000', 'Belgium'),
('Rue des Fables', '3', 'Namur', '5000', 'Belgium'),
('Avenue de la Liberté', '456', 'Mons', '7000', 'Belgium'),
('Chaussée des Lilas', '888', 'Arlon', '6700', 'Belgium'),
('Rue de lEspoir', '111', 'Tournai', '7500', 'Belgium'),
('Avenue de la Renaissance', '555', 'Liège', '4000', 'Belgium'),
('Chemin des Vignes', '33', 'La Louvière', '7100', 'Belgium'),
('Rue du Cœur', '222', 'Bruxelles', '1000', 'Belgium'),
('Avenue de la Joie', '777', 'Nivelles', '1400', 'Belgium'),
('Chaussée de la Forêt', '44', 'Arlon', '6700', 'Belgium'),
('Rue du Bonheur', '999', 'Hasselt', '3500', 'Belgium'),
('Avenue des Merveilles', '123', 'Liège', '4000', 'Belgium'),
('Boulevard de la Sérénité', '555', 'Namur', '5000', 'Belgium'),
('Rue de la Paix', '777', 'Mons', '7000', 'Belgium');


GO
-- Inserting cars'Liftback'
INSERT INTO car (plateNumber, model, nbSeats, brand, carType, fuelType, color) VALUES
('FALC0N1', 'Fusion', 5, 'Ford', 'Sedan', 'Hybrid', 'red'),
('XW1NGR', 'Model X', 1, 'Tesla', 'Hatchback', 'Lpg', 'blue'),
('T13EF1GHT', 'Altima', 1, 'Nissan', 'Hatchback', 'Lpg', 'red'),
('L4NDSP33DR', 'Corolla', 2, 'Toyota', 'Micro', 'Diesel', 'blue'),
('ATAT4LK', 'Suburban', 40, 'Chevrolet', 'Universal', 'Other', 'blue'),
('SL4VESP1D3R', '3 Series', 1, 'BMW', 'Hatchback', 'Lpg', 'yellow'),
('SP33DB1K3', 'CBR1000RR', 1, 'Honda', 'Micro', 'Diesel', 'yellow'),
('ST4RDESTROYR', 'Sprinter', 1000, 'Mercedes-Benz', 'Universal', 'Other', 'yellow'),
('TWIDBL4D3', 'A8', 2, 'Audi', 'Micro', 'Diesel', 'green'),
('J4WAS4NDCRAWL3R', 'LX', 10, 'Lexus', 'Universal', 'Gasoline', 'blue'),
('S1THS3D4N', 'Focus', 2, 'Ford', 'Micro', 'Diesel', 'red'),
('R0Y4LB4RG3', 'Model S', 100, 'Tesla', 'Universal', 'Other', 'red'),
('P0DR4C3R', 'Camry', 1, 'Toyota', 'Micro', 'Gasoline', 'yellow'),
('B4NTH4', 'Equinox', 2, 'Chevrolet', 'Micro', 'Diesel', 'blue'),
('M4ND4L0R14N', 'M4', 1, 'BMW', 'Hatchback', 'Lpg', 'blue'),
('CR90CRV13R', 'S-Class', 100, 'Mercedes-Benz', 'Universal', 'Other', 'red'),
('K1RT4NKER', 'A4', 4, 'Audi', 'Micro', 'Diesel', 'yellow'),
('W00K13ROAR', 'Civic', 2, 'Honda', 'Micro', 'Diesel', 'yellow'),
('D41LYGHR0N', 'RX', 4, 'Lexus', 'Micro', 'Diesel', 'green'),
('FLY1NGL4NDSP33D', 'Land Cruiser', 2, 'Toyota', 'Micro', 'Diesel', 'red'),
('TW4RTHOG', 'Silverado', 2, 'Chevrolet', 'Micro', 'Diesel', 'blue'),
('ST4RFURY', 'Pathfinder', 1, 'Nissan', 'Hatchback', 'Lpg', 'green'),
('D4RKSLD3', 'X5', 1, 'BMW', 'Hatchback', 'Lpg', 'red'),
('CL0N3J3T', 'A6', 1, 'Audi', 'Hatchback', 'Lpg', 'blue'),
('HYPRSP4C3', 'Unknown', 0, 'Unknown', 'Liftback', 'Other', 'green'),
('N1GHTR1D3R', 'Mustang', 1, 'Ford', 'Hatchback', 'Lpg', 'red'),
('S0L0SP3C1AL', 'Model 3', 2, 'Tesla', 'Micro', 'Diesel', 'yellow'),
('4R0N4UT', 'Camry', 1, 'Toyota', 'Hatchback', 'Lpg', 'blue'),
('R1DG3B4CK', 'Equinox', 4, 'Chevrolet', 'Micro', 'Diesel', 'red'),
('T4L0NCL45P3R', 'X5', 1, 'BMW', 'Hatchback', 'Lpg', 'red'),
('FL3X1BL3F1N', 'E-Class', 1, 'Mercedes-Benz', 'Hatchback', 'Lpg', 'green'),
('ST3LTHM0D3', 'Altima', 1, 'Nissan', 'Hatchback', 'Lpg', 'blue'),
('S1L3NTR1D3R', 'Focus', 1, 'Ford', 'Hatchback', 'Lpg', 'red'),
('W00K13W4RR10R', 'Accord', 1, 'Honda', 'Micro', 'Diesel', 'red'),
('CL4NG3RF1GHT3R', 'Camaro', 1, 'Chevrolet', 'Hatchback', 'Lpg', 'blue'),
('R4P1DSTR1D3R', 'RX', 1, 'Lexus', 'Micro', 'Diesel', 'green'),
('F1R3H4WK', '3 Series', 2, 'BMW', 'Micro', 'Diesel', 'white'),
('S0L4RRAC3R', 'Model S', 1, 'Tesla', 'Micro', 'Diesel', 'white'),
('G4L4CT1CG4LL0P', 'Unknown', 1, 'Unknown', 'Micro', 'Diesel', 'red'),
('SH4D0WSL33K', 'X5', 1, 'BMW', 'Hatchback', 'Lpg', 'red'),
('V1P3R', 'S-Class', 1, 'Mercedes-Benz', 'Hatchback', 'Lpg', 'white'),
('ST4RSTR1D3R', 'Mustang', 1, 'Ford', 'Hatchback', 'Lpg', 'white'),
('M1DKN1GHT3R', 'X5', 1, 'BMW', 'Hatchback', 'Lpg', 'white'),
('SP4C3G4Z3R', 'Unknown', 2, 'Unknown', 'Micro', 'Diesel', 'red'),
('T1T4N1UM', 'Titan', 1, 'Lexus', 'Hatchback', 'Lpg', 'blue'),
('R4V3N', 'Camaro', 1, 'Chevrolet', 'Hatchback', 'Lpg', 'green'),
('TW1ST3DSTR1D3R', 'A4', 1, 'Audi', 'Hatchback', 'Lpg', 'red'),
('FURYR1D3R', 'Mustang', 1, 'Ford', 'Hatchback', 'Lpg', 'green');


GO
-- Inserting users
INSERT INTO users (userType, username, password, email, birthDate, isBanned, phoneNumber, lastName, firstName, gender, addressId, carPlate) VALUES
('Admin', 'Windu', '$2a$12$rrbtKJ1hzSpsufceTr6D1Oo/.9ADJ2.WhXgDKiN432ayPrW2oHSpC', 'windu@jeditemple.com', '1977-05-25', 0, '123-456-7890', NULL, NULL, NULL, NULL, NULL),
('Admin', 'Yoda', '$2a$12$mEJkGiq8D/e/1jkfoxIXi.g4.bUaSpfCPMNV7fpor9TYnkvFTFrT.', 'yoda@jeditemple.com', '1945-02-17', 0, '987-654-3210', NULL, NULL, NULL, NULL, NULL),
('Passenger', 'Luke', '$2a$12$W05xsnDc32fAf./PzEXQSu68Bh5ZtAwWctTVpCyXK0IF8zySYG1w6', 'luke.skywalker@jeditemple.com', '1971-09-19', 0, '555-555-5555', 'Skywalker', 'Luke', 'Male', 1, NULL),
('Passenger', 'Leia ', '$2a$12$5tcu/2Fib0b5SksGxai4DuWrwUTtNFtpRsXhJzZH/Ahg9awU2DSGC', 'leia@senate.com', '1977-05-25', 0, '555-555-5555', 'Organa', 'Leia', 'Female', 2, NULL),
('Passenger', 'Solo', '$2a$12$QcxWLZqayMMKwHO7E4BveuHYROZM9GNyeOrx8XOcQWLWZhe/dhstS', 'han@hutt.com', '1977-05-25', 0, '555-555-5555', 'Solo', 'Han', 'Male', 3, NULL),
('Driver', 'Anakin', '$2a$12$9W1iNOry8wyf42bk95n0y.rM31AoiqsEN1gRklM6deMM2y8aBSgIu', 'anakin.skywalker@jeditemple.com', '1983-05-19', 0, '333-333-3333', 'Skywalker', 'Anakin', 'Male', 4, 'FALC0N1'),
('Driver', 'Padme', '$2a$12$x7ukm1VC7cbIqlPGulW7Uei4bnJU/vd9Nec59BbYCZgQcPwcnVy26', 'padme@senate.com', '1981-05-12', 0, '333-333-3333', 'Amidala', 'Padme', 'Female', 5, 'TW1ST3DSTR1D3R'),
('Driver', 'BenKennobi', '$2a$12$GKbjZNm65uNAIT25kiLpzeZ5qjnu/WVD9JjFjHI5tkjXr3PYi/T4C', 'obiwan@jeditemple.com', '1970-08-14', 0, '333-333-3333', 'Kennobi', 'Obi-Wan', 'Male', 6, 'ST3LTHM0D3'),
('Driver', 'Chewbacca', '$2a$12$g7b40BLvlDBAWdM5FQ7KGuYc.7Kr3mnd5t1fk4iyBl0qzQ6YY98uK', 'chewbacca@milleniumfalcon.com', '1966-03-18', 0, '333-333-3333', 'Chewbacca', NULL, 'Male', 7, 'W00K13ROAR'),
('Driver', 'Lando', '$2a$12$v.fyzCW3dvJzdC8hy.401ekd/UlD7bf4iVRawAIb1U..b7CD5Silu', 'lando@driver.com', '1944-05-14', 0, '333-333-3333', 'Calrissian', 'Lando', 'Male', 8, 'S0L0SP3C1AL'),
('Passenger', 'Vader', '$2a$12$lyquARJCJZqdFB4wAn8sweCCZ2Q5RQRMPlroBEIYS6EgdNgdEemcG', 'vader@darkside.com', '1977-05-25', 0, '555-555-5555', 'Vader', 'Darth', 'Male', 9, NULL),
('driver', 'BobaFett', '$2a$12$mY//zJwTCZ9cC9nZ3vK.nO0JTvG9I6v9/SqYmAlVKbyUz60PjYhQy', 'boba@hunter.com', '1982-12-18', 0, '333-333-3333', 'Fett', 'Boba', 'Male', 10, 'SL4VESP1D3R'),
('Admin', 'Sidious', '$2a$12$OeEt5MBXtHvErRqLz7JfMu/76vs5Ly0jrfNUGmIS2hPWHVlsXGpRS', 'admin50@admin.com', '1980-01-01', 0, '555-555-5555', NULL, NULL, NULL, NULL, NULL);

GO
-- Inserting trips
INSERT INTO trip (idDriver, smoke, price, luggage, petFriendly, date, driverMessage, airConditioning, idStartingPoint, idDestination)
VALUES
(6, 0, 0.25, 1, 0, '2024-01-01 08:00:00', 'I am willing to pick you up from your home.', 1, 1, 2),
(8, 1, 0.30, 0, 1, '2024-01-02 12:30:00', 'I can drop you off wherever you want.', 0, 3, 4),
(6, 0, 0.22, 1, 1, '2024-01-03 15:45:00', 'I can drop you off wherever you want.', 1, 5, 6),
(7, 1, 0.28, 0, 1, '2024-01-04 09:15:00', 'I can drop you off wherever you want.', 0, 7, 8),
(8, 0, 0.35, 1, 0, '2024-01-05 17:30:00', 'I am willing to pick you up from your home.', 0, 9, 10),
(9, 1, 0.20, 0, 1, '2024-01-06 14:00:00', 'I do not accept animals, I am allergic.', 1, 11, 12),
(9, 0, 0.32, 1, 1, '2024-01-07 10:45:00', 'I do not accept animals, I am allergic.', 1, 13, 14),
(7, 1, 0.26, 1, 0, '2024-01-08 16:30:00', 'I am willing to pick you up from your home.', 0, 15, 16),
(8, 0, 0.28, 0, 1, '2024-01-09 11:00:00', 'I do not accept animals, I am allergic.', 1, 17, 18),
(6, 1, 0.24, 1, 1, '2024-01-10 18:45:00', 'I can drop you off wherever you want.', 0, 19, 20),
(8, 1, 0.35, 1, 1, '2024-02-19 09:15:00', 'I can drop you off wherever you want.', 1, 23, 24),
(9, 0, 0.32, 1, 1, '2024-02-22 10:45:00', 'I do not accept animals, I am allergic.', 1, 11, 15),
(7, 1, 0.26, 1, 0, '2024-02-23 16:30:00', 'I am willing to pick you up from your home.', 0, 12, 13),
(8, 0, 0.28, 0, 1, '2024-02-24 11:00:00', 'I can drop you off wherever you want.', 1, 25, 20),
(6, 1, 0.24, 1, 1, '2024-02-25 18:45:00', 'I am willing to pick you up from your home.', 1, 24, 22),
(8, 1, 0.35, 1, 1, '2024-02-26 09:15:00', 'I do not accept animals, I am allergic.', 0, 22, 24),
(9, 0, 0.32, 1, 1, '2024-02-27 10:45:00', 'I can drop you off wherever you want.', 1, 1, 16),
(7, 1, 0.26, 1, 0, '2024-02-28 16:30:00', 'I am willing to pick you up from your home.', 0, 15, 18),
(8, 0, 0.28, 0, 1, '2024-03-01 11:00:00', 'I do not accept animals, I am allergic.', 1, 9, 14),
(6, 1, 0.24, 1, 1, '2024-03-02 18:45:00', 'I can drop you off wherever you want.', 1, 8, 12),
(8, 1, 0.35, 1, 1, '2024-03-03 09:15:00', 'I am willing to pick you up from your home.', 0, 5, 14),
(9, 0, 0.32, 1, 1, '2024-03-04 10:45:00', 'I am willing to pick you up from your home.', 0, 13, 16),
(7, 1, 0.26, 1, 0, '2024-03-05 16:30:00', 'I am willing to pick you up from your home.', 0, 19, 18);
GO
-- Inserting bookings
INSERT INTO booking (date, reservedSeats, idPassenger, idTrip)
VALUES
('2023-01-01 10:00:00', 2, 3, 1),
('2023-01-02 13:45:00', 1, 4, 2),
('2023-01-03 16:30:00', 3, 5, 3),
('2023-02-16 10:15:00', 2, 11, 4),
('2023-02-18 16:30:00', 3, 12, 5),
('2023-02-19 10:45:00', 1, 13, 5);

