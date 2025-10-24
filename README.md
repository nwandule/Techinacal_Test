# User Authentication System – Documentation Overview

A simple system for user login and updating personal details using **C# backend, MySQL database, and Angular/TypeScript frontend**. Features secure password hashing (BCrypt) and JWT-based authentication.

---

## Features

- Login with email & password  
- Update first name & last name  
- Passwords securely hashed  
- Token-based authentication  
- Responsive Angular frontend  

---

## Quick Setup Backend

```bash
# Clone repo
git clone <repo_url>

# Navigate to backend folder
cd backend

# Restore packages
dotnet restore

# Set MySQL connection in appsettings.json

# Apply migrations
dotnet ef database update

# Run backend
dotnet run
Database
sql
Copy code
CREATE DATABASE auth_db;

CREATE TABLE users (
  id INT AUTO_INCREMENT PRIMARY KEY,
  email VARCHAR(255) NOT NULL UNIQUE,
  password VARCHAR(255) NOT NULL,
  first_name VARCHAR(100),
  last_name VARCHAR(100),
  updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
Frontend (Angular/TypeScript)
bash
Copy code
# Navigate to frontend folder
cd frontend

# Install packages
npm install

# Configure backend URL in src/environments/environment.ts
# Example:
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5153/api'
};

# Run frontend
ng serve
User Actions in Frontend
Login
Navigate to http://localhost:4200/

Enter email and password

On success, a popup shows “Login successful!”

User is redirected to Update Details page

Register
Navigate to http://localhost:4200/register

Fill in first name, last name, email, and password

Click Register

On success, a popup shows “Registration successful!”

User is redirected to Login

Update Details
After login, navigate to Update Details page

Update first name and last name

Submit to save changes

Changes are stored in backend database

API Endpoints
Method	Endpoint	Description	Authentication
POST	/auth/login	Authenticate user, return JWT	No
POST	/auth/register	Register a new user	No
PATCH	/user/update	Update first_name & last_name	Requires JWT

Security
Passwords hashed with BCrypt

JWT authentication for protected routes

Sensitive data never exposed

Project Structure
css
Copy code
backend/
├── Controllers/
├── Repository/
├── Models/
├── Data/
└── Program.cs

frontend/
├── src/
│   ├── app/
│   │   ├── components/
│   │   │   ├── login/
│   │   │   ├── register/
│   │   │   └── update-details/
│   │   ├── services/
│   │   └── app.module.ts
│   └── main.ts
└── angular.json
pgsql
Copy code
