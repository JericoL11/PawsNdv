# 🐾 Pet Administration and Wellness System | V2 - Clean Architecture (Refactored)

A comprehensive veterinary clinic management system designed to handle pet and owner records, contact details, and wellness tracking. This **V2 version** is fully refactored using **Clean Architecture** to promote modularity, testability, and long-term maintainability.

---

## 📌 Key Features

- 🧍 Owner & Contact Management  
- 🐶 Pet Registration & Wellness Tracking  
- 📦 Clean Architecture (Domain, Application, Infrastructure, Presentation)  
- 🧩 Generic and Specific Repositories with Unit of Work  
- 🔄 AutoMapper for DTO Mapping  
- ✅ FluentValidation for Input Validation  
- 🌐 ASP.NET Core Web API Backend  
- 💻 Angular 19 Frontend with Bootstrap UI  
- 🗄️ SQL Server Database  
- 🔐 CORS Configured for Frontend Integration  

---

## 🧱 Tech Stack

| Layer        | Technology                     |
|-------------|---------------------------------|
| Frontend     | Angular 19, Bootstrap           |
| Backend      | ASP.NET Core Web API (.NET 8)   |
| Database     | SQL Server                      |
| ORM          | Entity Framework Core           |
| Validation   | FluentValidation                |
| Mapping      | AutoMapper                      |

---

## 🚀 Getting Started

### 📦 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

> ⚠️ Make sure SQL Server is installed and running. Create a database or use automatic migrations to create one.

---

### 🔧 Backend Setup

```bash
# Navigate to the backend folder
cd PawsNdv

# Restore packages
dotnet restore

# Apply migrations and update the database (ensure SQL Server connection string is configured)
dotnet ef database update

# Run the API
dotnet run



### 🔧 Front-End  Setup
# Navigate to the frontend folder
cd PawsNdv.Client

# Install dependencies
npm install

# Run the Angular app
ng serve
https://docs.github.com/github/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax
