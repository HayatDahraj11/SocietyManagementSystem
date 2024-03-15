DROP DATABASE IF EXISTS sms;
CREATE DATABASE sms;
USE sms;

-- Users table (includes students, mentors, etc.)
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(255) NOT NULL,
    username VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    `password` VARCHAR(255) NOT NULL, -- Ensure password is hashed
    user_type ENUM('student', 'mentor') NOT NULL,
    join_date DATE NOT NULL
);

-- Societies table (includes a status for approval)
CREATE TABLE societies (
    society_id INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `description` TEXT,
    creation_date DATE NOT NULL,
    founder_id INT,
    mentor_id INT, -- Mentor who approves the society
    `status` ENUM('pending', 'approved', 'rejected') DEFAULT 'pending',
    FOREIGN KEY (founder_id) REFERENCES users(user_id),
    FOREIGN KEY (mentor_id) REFERENCES users(user_id)
);

-- Society Members table (links users to societies with roles)
CREATE TABLE society_members (
    society_member_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    society_id INT NOT NULL,
    role ENUM('president', 'ec_member', 'member') NOT NULL,
    join_date DATE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (society_id) REFERENCES societies(society_id)
);

-- Events table (information about events organized by the societies)
CREATE TABLE `events` (
    event_id INT AUTO_INCREMENT PRIMARY KEY,
    society_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    event_date DATE NOT NULL,
    location VARCHAR(255) NOT NULL,
    FOREIGN KEY (society_id) REFERENCES societies(society_id)
);

-- Event Registrations table (links users to events they've registered for)
CREATE TABLE event_registrations (
    registration_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    event_id INT NOT NULL,
    registration_date DATE NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (event_id) REFERENCES events(event_id)
);

-- Dummy Data Insertion
-- Insert dummy users (students, mentors)
INSERT INTO users (full_name, username, email, password, user_type, join_date) VALUES
('John Doe', 'jony', 'john.doe@example.com', '1234', 'student', '2023-01-01'),
('Jane Smith', 'jane', 'jane.smith@example.com', '4321', 'mentor', '2023-01-02'),
('Robert Brown', 'roby', 'robert.brown@example.com', '1234', 'student', '2023-01-03'),
('Emily Wilson', 'emily', 'emily.wilson@example.com', '4321', 'student', '2023-01-04');

-- Insert dummy societies (one pending approval, one approved)
INSERT INTO societies (name, description, creation_date, founder_id, mentor_id, status) VALUES
('Tech Society', 'A society for technology enthusiasts.', '2023-01-05', 1, 2, 'approved'),
('Art Society', 'A society for art lovers.', '2023-01-06', 3, 2, 'pending');

-- Insert society members (linking users to societies with roles)
INSERT INTO society_members (user_id, society_id, role, join_date) VALUES
(1, 1, 'president', '2023-01-07'),
(3, 1, 'member', '2023-01-08'),
(4, 1, 'ec_member', '2023-01-09');

-- Insert events organized by the societies
INSERT INTO `events` (society_id, name, description, event_date, location) VALUES
(1, 'Tech Meetup', 'An annual meetup for technology enthusiasts.', '2023-03-01', 'Auditorium'),
(1, 'Coding Workshop', 'A workshop on modern web development techniques.', '2023-04-01', 'Computer Lab');

-- Insert event registrations (linking users to events they've registered for)
INSERT INTO event_registrations (user_id, event_id, registration_date) VALUES
(1, 1, '2023-02-20'),
(3, 1, '2023-02-21'),
(4, 2, '2023-03-15');
