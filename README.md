# CodeB .NET Technical Assessment

## Overview
This repository contains the backend API implementation for the CodeB .NET Technical Assessment. The application handles two primary user flows as per the provided wireframes:
1. **Registration - New Customer:** Complete onboarding flow including mock OTP verification.
2. **Migrate Existing User:** Flow to migrate an existing legacy user to the new system.

[cite_start]As per the assignment instructions, this project does not implement authentication [cite: 3] [cite_start]and relies on a mock function for OTP generation and validation without any 3rd-party integrations[cite: 6].

## Architectural Design & Patterns
[cite_start]The application is built with a strong focus on Code Quality, Reusability, and standard coding practices. 
* **Clean Architecture:** The solution is logically separated into Core (Entities, DTOs, Interfaces), Infrastructure (Data Access, EF Core), Services (Business Logic), and API (Controllers, Middleware) layers.
* **SOLID Principles:** Interfaces are used heavily to ensure loosely coupled code, adhering to the Dependency Inversion and Single Responsibility principles.
* **Dependency Injection (DI):** All repositories and services (`IUserRepository`, `IOtpService`, `IUserService`) are registered via the built-in ASP.NET Core DI container.
* **Global Exception Handling:** A custom middleware (`ExceptionMiddleware`) is implemented to catch and format exceptions globally, ensuring clean controller logic and standard API error responses.

## Technologies Used
* **Framework:** .NET 8.0 (Web API)
* **Database:** Microsoft SQL Server
* [cite_start]**ORM:** Entity Framework Core (Code-First Migrations) [cite: 4]
* **API Documentation:** Swagger / OpenAPI

## Features Implemented
* [cite_start]Complete flow coverage for both New User Registration and Existing User Migration[cite: 5].
* [cite_start]Entity Framework Core integration for seamless DB handling[cite: 4].
* [cite_start]Custom Mock OTP Service that generates, stores, and validates OTPs with expiration logic[cite: 6].
* Global Exception Handling for robust API responses.

## Getting Started

### Prerequisites
* Visual Studio 2022 (or later) / VS Code
* .NET 8.0 SDK
* Microsoft SQL Server (LocalDB or SQLEXPRESS)

### Database Setup (Entity Framework Migrations)
1. Clone the repository to your local machine.
2. Open `appsettings.json` and verify the `DefaultConnection` string matches your local SQL Server instance.
3. Open the **Package Manager Console** in Visual Studio.
4. Run the following command to apply the migrations and create the database:
   ```powershell
   Update-Database


Running the Application
Set the API project as the Startup Project.

Press F5 or click Run.

The application will launch, and your default browser will automatically open the Swagger UI (https://localhost:<port>/swagger).

API Documentation (Swagger)
All necessary APIs are exposed and can be tested directly via the Swagger UI:

POST /api/Otp/send: Generates a mock OTP and saves it to the database.

POST /api/Otp/verify: Validates the generated OTP against the database and checks for expiration.

POST /api/User/register: Registers a new user (requires prior OTP verification in a real-world frontend flow).

POST /api/User/migrate: Migrates an existing legacy user.
