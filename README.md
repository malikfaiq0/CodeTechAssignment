# CodeB .NET Technical Assessment

## 📌 Project Summary

This repository contains a production-grade backend API built using **.NET 8 Web API**, implementing the required flows for the CodeB Technical Assessment.

The system supports:

1. **New Customer Registration** – Complete onboarding flow with mock OTP verification.
2. **Legacy User Migration** – Migration flow for existing users into the new platform.

The implementation emphasizes clean architecture, maintainability, scalability, and adherence to enterprise-level coding standards.

---

## 🏛 Architecture

The solution follows **Clean Architecture (Onion Architecture principles)** with clear separation of concerns:

```
CodeB.Assessment
│
├── Core
│   ├── Entities
│   ├── DTOs
│   ├── Interfaces
│
├── Infrastructure
│   ├── DbContext
│   ├── Repositories
│   ├── EF Core Configurations
│
├── Services
│   ├── Business Logic
│   ├── Domain Validations
│
└── API
    ├── Controllers
    ├── Middleware
    ├── Dependency Injection
```

### Architectural Principles Applied

- ✔ Clean Architecture
- ✔ SOLID Principles
- ✔ Repository Pattern
- ✔ Service Layer Pattern
- ✔ Dependency Injection
- ✔ Global Exception Handling
- ✔ Code-First EF Core Migrations

The design ensures that:
- Business logic is isolated from infrastructure concerns.
- Controllers remain thin.
- The system is easily testable and extensible.

---

## 🔐 OTP Design (Mock Implementation)

- 4-digit OTP generated server-side.
- Stored in database with 5-minute expiration.
- Verification validates:
  - OTP match
  - Expiration status
- No third-party integration (as per assignment constraints).

The OTP service is abstracted via `IOtpService` to allow future extensibility (e.g., SMS/Email providers).

---

## 👤 User Flows

### 1️⃣ Register New User
- Validate request DTO
- Verify OTP
- Persist user entity
- Return standardized response

### 2️⃣ Migrate Existing User
- Validate legacy user data
- Transform to new domain model
- Persist in new schema

---

## 🛠 Technology Stack

| Layer | Technology |
|-------|------------|
| Framework | .NET 8 Web API |
| ORM | Entity Framework Core |
| Database | Microsoft SQL Server |
| API Docs | Swagger / OpenAPI |
| Pattern | Clean Architecture |

---

## ⚙️ Configuration

### Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or VS Code
- SQL Server (LocalDB / SQLEXPRESS)

---

## 🗄 Database Setup

Update your `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CodeTechAssignmentDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Apply migrations:

```powershell
Update-Database
```

---

## ▶ Running the Application

1. Set API as Startup Project
2. Run the application
3. Swagger UI will be available at:

```
https://localhost:<port>/swagger
```

---

## 📖 API Endpoints

### OTP

| Method | Endpoint | Description |
|--------|----------|------------|
| POST | /api/Otp/send | Generate OTP |
| POST | /api/Otp/verify | Verify OTP |

### User

| Method | Endpoint | Description |
|--------|----------|------------|
| POST | /api/User/register | Register new user |
| POST | /api/User/migrate | Migrate legacy user |

---

## 🧠 Design Decisions

- **No Authentication Layer** → Explicitly excluded as per requirements.
- **Mock OTP Service** → Abstracted for future integration.
- **Centralized Exception Middleware** → Ensures consistent error responses.
- **Interface-Based Services** → Promotes testability.
- **Thin Controllers** → Business logic fully delegated to services.

---

## 🚀 Scalability Considerations

The current design allows easy integration of:

- JWT Authentication
- Background job processing (e.g., Hangfire)
- Caching layer (Redis)
- Distributed logging (Serilog + Seq)
- Message broker (RabbitMQ / Kafka)
- Unit & Integration Testing (xUnit / FluentAssertions)

---

## 📌 Assignment Constraints Fulfilled

- No external OTP provider
- No authentication implementation
- Clean separation of layers
- EF Core Code-First migrations
- Swagger documentation

---

## 👨‍💻 Author

Developed as part of the CodeB Technical Assessment using enterprise-level backend engineering practices.
