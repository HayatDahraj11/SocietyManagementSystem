DROP DATABASE IF EXISTS sms;
CREATE DATABASE sms;
USE sms;

-- This table stores information about all students, including those who may join or register a society.
CREATE TABLE students (
    student_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL, -- Ensure this is hashed
    join_date DATE NOT NULL
);

-- This table holds information about the societies.
CREATE TABLE societies (
    society_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    creation_date DATE NOT NULL
);

-- This table links students to societies and assigns roles within the society. It's a many-to-many relationship since a student can join multiple societies, and a society can have multiple members.
CREATE TABLE society_members (
    society_member_id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT NOT NULL,
    society_id INT NOT NULL,
    role ENUM('mentor', 'president', 'ec_member', 'member') NOT NULL,
    join_date DATE NOT NULL,
    FOREIGN KEY (student_id) REFERENCES students(student_id),
    FOREIGN KEY (society_id) REFERENCES societies(society_id)
);

-- This table stores information about events organized by the societies.
CREATE TABLE events (
    event_id INT AUTO_INCREMENT PRIMARY KEY,
    society_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    event_date DATE NOT NULL,
    location VARCHAR(255) NOT NULL,
    FOREIGN KEY (society_id) REFERENCES societies(society_id)
);

-- This table links students to events they have registered for.
CREATE TABLE event_registrations (
	registration_id INT AUTO_INCREMENT PRIMARY KEY,
	student_id INT NOT NULL,
	event_id INT NOT NULL,
	registration_date DATE NOT NULL,
	FOREIGN KEY (student_id) REFERENCES students(student_id),
	FOREIGN KEY (event_id) REFERENCES events(event_id)
);
