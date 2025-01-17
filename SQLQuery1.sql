CREATE TABLE users (
	id INT PRIMARY KEY IDENTITY(1,1),
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	email VARCHAR(100) UNIQUE NOT NULL,
	password VARCHAR(255) NOT NULL,
);

CREATE TABLE positions (
	id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(50) NOT NULL,
	base_salary DECIMAL(10,2) NOT NULL,
	description TEXT,
	work_hours INT NOT NULL,
	vacation_days INT NOT NULL,
	has_health_plan BIT NOT NULL,
	has_transportation_voucher BIT NOT NULL,
	has_home_office BIT NOT NULL,
);

CREATE TABLE addresses (
	id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT NOT NULL,
	street VARCHAR(100) NOT NULL,
	number INT NOT NULL,
	complement VARCHAR(50),
	neighborhood VARCHAR(50) NOT NULL,
	city VARCHAR(50) NOT NULL,
	state VARCHAR(2) NOT NULL,
	zip_code VARCHAR(8) NOT NULL,
	FOREIGN KEY (user_id) REFERENCES users(id)
)
