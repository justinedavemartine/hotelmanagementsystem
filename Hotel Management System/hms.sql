CREATE TABLE users
(
	id INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(MAX) NULL,
	password VARCHAR(MAX) NULL,
	role VARCHAR(MAX) NULL,
	status VARCHAR(MAX) NULL,
	date_register DATE NULL
)

SELECT * FROM users

INSERT INTO users(username, password, role, status, date_register) VALUES('ADMIN', 'ADMINPASSWORD', 'ADMIN', 'ACTIVE', '2024-05-28')
INSERT INTO users(username, password, role, status, date_register) VALUES('STAFF', 'STAFFPASSWORD', 'STAFF', 'ACTIVE', '2024-05-28')

CREATE TABLE rooms
( 
	id INT PRIMARY KEY IDENTITY(1,1),
	room_id VARCHAR(MAX) NULL,
	type VARCHAR(MAX) NULL,
	room_name VARCHAR(MAX) NULL,
	price FLOAT NULL,
	room_image VARCHAR(MAX) NULL,
	status VARCHAR(MAX) NULL,
	date_register DATE NULL,
	date_update DATE NULL,
	date_delete DATE NULL
)

SELECT * FROM rooms

SELECT room_id FROM rooms

SELECT * FROM rooms WHERE date_delete IS NULL

CREATE TABLE clients
(
	id INT PRIMARY KEY IDENTITY(1,1),
	book_id VARCHAR(MAX) NULL,
	client_name VARCHAR(MAX) NULL,
	email VARCHAR(MAX) NULL,
	contact VARCHAR(MAX) NULL,
	gender VARCHAR(MAX) NULL,
	address VARCHAR(MAX) NULL,
	price DECIMAL NULL,
	status_payment VARCHAR(MAX) NULL,
	status VARCHAR(MAX) NULL,
	date_from DATE NULL,
	date_to DATE NULL,
	date_book DATE NULL
)

ALTER TABLE clients ADD room_id VARCHAR(MAX) NULL

SELECT * FROM clients

SELECT COUNT(id) FROM users WHERE role = 'STAFF'

SELECT COUNT(id) FROM rooms WHERE status = 'AVAILABLE' OR status = 'ACTIVE'

SELECT SUM(price) FROM clients