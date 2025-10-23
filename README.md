# Techinacal_Test
User Authentication System – Documentation
Overview

A simple system for user login and updating personal details using C# backend, MySQL database, and Flutter frontend.
Features secure password hashing (BCrypt) and JWT-based authentication.

Features

Login with email & password

Update first name & last name

Passwords securely hashed

Token-based authentication

Responsive Flutter frontend

Quick Setup
Backend

Clone repo: git clone <repo-link>

Navigate: cd backend

Restore packages: dotnet restore

Set MySQL connection in appsettings.json

Apply migrations: dotnet ef database update

Run backend: dotnet run

Database

Create database: CREATE DATABASE auth_db;

Create users table:

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

Frontend (Flutter)

Navigate: cd frontend

Install packages: flutter pub get

Configure backend URL in config.dart

Run app: flutter run

API Endpoints

POST /auth/login → Authenticate user, return JWT

PATCH /user/update → Update first_name & last_name (requires JWT token)

Security

Passwords hashed with BCrypt

JWT authentication for updates

Sensitive data never exposed

Project Structure
backend/
├── Controllers/
├── Repositaory/
├── Models/
├── Data/
└── Program.cs

frontend/
├── lib/
│   ├── screens/
│   ├── services/
│   └── main.dart
