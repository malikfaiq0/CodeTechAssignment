# CodeB .NET Technical Assessment

## 📌 Overview
This repository contains the backend API implementation for the **CodeB .NET Technical Assessment**. The application handles two primary user flows as per the provided wireframes:

1. **Registration – New Customer:** Complete onboarding flow including mock OTP verification.
2. **Migrate Existing User:** Flow to migrate an existing legacy user to the new system.

This project does **not** implement authentication and relies on a mock function for OTP generation and validation without any third-party integrations, fulfilling all assignment constraints.

---

## 🏗 Architectural Design & Patterns
The application is built with a strong focus on **Code Quality, Reusability, and Standard Coding Practices**.

### ✔ Clean Architecture
The solution is logically separated into layers:

- **Core** → Entities, DTOs, Interfaces  
- **Infrastructure** → Data Access, Entity Framework Core  
- **Services** → Business Logic  
- **API** → Controllers, Middleware  

### ✔ SOLID Principles
- Interfaces are used extensively to ensure loosely coupled code.
- Follows **Dependency Inversion Principle (DIP)** and **Single Responsibility Principle (SRP)**.

### ✔ Dependency Injection (DI)
All repositories and services are registered using the built-in ASP.NET Core DI container:
- `IUserRepository`
- `IOtpService`
- `IUserService`

### ✔ Global Exception Handling
A custom middleware (`ExceptionMiddleware`) is implemented to:
- Catch exceptions globally
- Format standardized API error responses
- Keep controller logic clean

---

## 🛠 Technologies Used
- **Framework:** .NET 8.0 (Web API)
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core (Code-First Migrations)
- **API Documentation:** Swagger / OpenAPI

---

## 🚀 Getting Started

### 🔹 Prerequisites
- Visual Studio 2022 (or later) / VS Code
- .NET 8.0 SDK
- Microsoft SQL Server (LocalDB or SQLEXPRESS)

---

## 🗄 Database Setup

1. Clone the repository:
   ```bash
   git clone <your-repository-url>
   ```

2. Open `appsettings.json` and verify the `DefaultConnection` string:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CodeTechAssignmentDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. Open **Package Manager Console** in Visual Studio.

4. Run the following command to apply migrations and create the database:

   ```powershell
   Update-Database
   ```

---

## ▶ Running the Application

1. Set the **API project** as the Startup Project.
2. Press **F5** or click **Run**.
3. The application will launch and automatically open Swagger UI:

   ```
   https://localhost:<port>/swagger
   ```

---

## 📖 API Documentation (Swagger)

All APIs can be tested directly via Swagger UI.

### 🔐 OTP Endpoints
- **POST** `/api/Otp/send`  
  - Generates a mock 4-digit OTP  
  - Saves it to the database  
  - OTP expires in 5 minutes  

- **POST** `/api/Otp/verify`  
  - Validates OTP  
  - Checks expiration  

### 👤 User Endpoints
- **POST** `/api/User/register`  
  - Registers a new user  

- **POST** `/api/User/migrate`  
  - Migrates an existing legacy user into the new system  

---

## ✅ Assignment Constraints Covered
- No authentication implemented  
- Mock OTP service (no 3rd-party integration)  
- Clean Architecture  
- SOLID principles  
- Dependency Injection  
- Global Exception Handling  
- Swagger documentation  

---

## 👨‍💻 Author
Developed as part of the CodeB .NET Technical Assessment.
