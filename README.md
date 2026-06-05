# Customer Management API

## Project Overview

This is a Customer Management CRUD API built using ASP.NET Core Web API, SQL Server, ADO.NET, Stored Procedures, and Clean Architecture.

The API allows users to:

- Create customers
- View all customers
- View a customer by ID
- Update customer details
- Delete customers

---

## Project Layers

### 1. Domain Layer

The Domain layer contains the core business models.

This layer does not contain database code or API code.

**Examples:**
- Customer
- CustomerType

---

### 2. Application Layer

The Application layer contains:

- DTOs
- Interfaces
- Services

This layer handles business logic and converts data between DTOs and entities.

---

### 3. Infrastructure Layer

The Infrastructure layer handles database operations.

It contains:

- CustomerRepository
- SqlConnectionFactory

This layer uses ADO.NET and Stored Procedures to communicate with SQL Server.

---

### 4. API Layer

The API layer exposes REST endpoints through controllers.

**Examples:**

```http
GET    /api/customers
POST   /api/customers
PUT    /api/customers/{id}
DELETE /api/customers/{id}
```

Swagger is used to test the API.

---

## Technologies Used

- ASP.NET Core Web API
- SQL Server
- ADO.NET
- Stored Procedures
- Swagger / OpenAPI
- Clean Architecture

---

