# 🧩 DubTask - Project & Task Management Web API

This is a clean and scalable **Project & Task Management Web API** built with **ASP.NET Core 9**, following the **Clean Architecture** principles. It supports user authentication, project creation, and task tracking using robust patterns like **CQRS**, **MediatR**, and **JWT-based authentication**.

---

## 🚀 Tech Stack

### ✅ Backend

- **.NET 9 (ASP.NET Core Web API)**
- **Entity Framework Core** (with SQL Server)
- **MediatR** (Command-Query Separation using CQRS)
- **AutoMapper** (for DTO to Entity mapping)
- **JWT (JSON Web Token)** authentication
- **Clean Architecture** principles:
  - **Presentation Layer (API)**
  - **Application Layer** (Commands, Queries, Handlers, DTOs)
  - **Domain Layer** (Entities & Interfaces)
  - **Infrastructure Layer** (EF Core + Data Access)
- **Unit Testing** (for project & task creation)

---

## 🧱 Architecture Overview

### 🧼 Clean Architecture Layers

```plaintext
│
├── 📁 DubTask.API            → ASP.NET Core Web API (Presentation)
├── 📁 DubTask.Application    → Business Logic, CQRS, MediatR Handlers, DTOs
├── 📁 DubTask.Domain         → Core Entities, Interfaces, Enums
├── 📁 DubTask.Infrastructure → EF Core Repositories, Database Context
│
