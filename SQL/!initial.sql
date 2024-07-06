BEGIN TRY
	BEGIN TRANSACTION;

	CREATE TABLE containers(
		id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
		number INT,
		type CHAR(64),
		length DECIMAL(2),
		width DECIMAL(2),
		weight DECIMAL(2),
		empty BIT,
		receiption_date DATETIME
	)

	CREATE TABLE operators(
		id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
		full_name CHAR(64)
	)

	CREATE TABLE operations(
		id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
		container_id UNIQUEIDENTIFIER,
		operator_id UNIQUEIDENTIFIER,
		start_date DATETIME,
		end_date DATETIME,
		type CHAR(64),
		inspection_place CHAR(255),
		FOREIGN KEY (container_id) REFERENCES containers (id),
		FOREIGN KEY (operator_id) REFERENCES operators (id)
	)

	INSERT INTO containers (number, type, length, width, weight, empty, receiption_date)
	VALUES 
	(101, 'Standard', 20.00, 8.00, 2.50, 0, '2024-06-30T10:00:00'),
	(102, 'Refrigerated', 40.00, 8.00, 4.00, 0, '2024-07-01T11:30:00'),
	(103, 'Open Top', 20.00, 8.00, 2.80, 1, '2024-07-02T09:45:00');

	INSERT INTO operators (full_name)
	VALUES 
	('John Doe'),
	('Jane Smith'),
	('Michael Johnson');

	INSERT INTO operations (container_id, operator_id, start_date, end_date, type, inspection_place)
	VALUES 
	((SELECT id FROM containers WHERE number = 101), (SELECT id FROM operators WHERE full_name = 'John Doe'), '2024-07-03T08:00:00', '2024-07-03T12:00:00', 'Loading', 'Port A'),
	((SELECT id FROM containers WHERE number = 102), (SELECT id FROM operators WHERE full_name = 'Jane Smith'), '2024-07-03T09:00:00', '2024-07-03T14:00:00', 'Unloading', 'Port B'),
	((SELECT id FROM containers WHERE number = 103), (SELECT id FROM operators WHERE full_name = 'Michael Johnson'), '2024-07-04T10:00:00', '2024-07-04T13:00:00', 'Inspection', 'Port C');

	COMMIT;
END TRY
BEGIN CATCH
	ROLLBACK;
	THROW;
END CATCH;