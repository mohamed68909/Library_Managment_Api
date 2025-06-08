
📚 Library Management System – ASP.NET Core 8 | EF Core | Clean Architecture
A robust and secure Library Management System built with .NET 8, following 3-Tier Architecture (API, BLL, DAL). It handles user authentication, book & copy tracking, reservations, waitlists, fines, and more – all exposed via RESTful APIs.

🚀 Features
👥 User Management
Secure registration & login for both librarians and members

JWT-based authentication and BCrypt password hashing for strong security

📚 Book & Copy Management
Store complete book information

Track individual book copies using unique copy IDs

⏳ Reservations & Waiting List
Members can reserve unavailable book copies

System automatically manages waiting lists for reservations

💸 Fines Management
Automatic calculation of late return fines

Track and display outstanding balances for each user

🏗️ Architecture Overview
API Layer (Presentation):
ASP.NET Core 8 Web API, following RESTful standards

BLL (Business Logic Layer):
Contains core logic for loans, reservations, and fine rules

DAL (Data Access Layer):
Uses Entity Framework Core with Repository & Unit of Work patterns

🛠️ Technologies & Tools
Area	Technology
Framework	.NET 8, ASP.NET Core 8
ORM	Entity Framework Core
Security	JWT, BCrypt
Documentation	Swagger / OpenAPI
Architecture	3-Tier, Clean Architecture
Design Patterns	Repository, Unit of Work, DTO, DI

📘 API Documentation
All endpoints are documented using Swagger UI.
Simply run the project and visit:

bash
نسخ
تحرير
https://localhost:<port>/swagger
🔐 Security
Passwords are hashed using BCrypt

JWT tokens are used for authentication and route protection

Role-based access control for librarians vs. members

