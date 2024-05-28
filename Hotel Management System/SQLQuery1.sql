SELECT * FROM clients

SELECT * FROM users

SELECT COUNT(id) FROM users WHERE role = 'STAFF'

SELECT COUNT(id) FROM rooms WHERE status = 'AVAILABLE' OR status = 'ACTIVE'

SELECT SUM(price) FROM clients