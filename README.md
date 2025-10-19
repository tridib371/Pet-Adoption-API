# 🐾 Pet-Adoption-API

**Pet-Adoption-API** is a C# .NET project structured as a multi-layered application using **Visual Studio**.  
It provides a backend API for managing pets, adoption requests, and users.

---

## 🗂 Solution Structure

The Visual Studio solution consists of three main projects:

1. **Pet Adoption API**  
   - This is the main API project (ASP.NET Core Web API).  
   - Contains controllers and endpoints for the API.  
   - Handles HTTP requests and responses.  

2. **BLL (Business Logic Layer)**  
   - Contains all the business logic.  
   - Handles validation, rules, and interaction between API and DAL.  

3. **DAL (Data Access Layer)**  
   - Responsible for database interactions.  
   - Contains repositories and models for data persistence.  
   - Works with Entity Framework or other ORM.

---

## ⚡ Features

- **Pet Management**
  - Add, update, delete, and retrieve pet information
  - Search pets by type, age, and location

- **Adoption Requests**
  - Customers can request to adopt pets
  - Admin can approve/reject adoption requests

- **User Management**
  - Register and login users
  - Role-based access: Admin & Customer

- **API Endpoints**
  - `/api/pets` → CRUD operations for pets  
  - `/api/adoptions` → Manage adoption requests  
  - `/api/users` → Register, login, manage users  

---

## 🛠 Technologies Used

- **C# .NET 6/7** – Backend API framework  
- **ASP.NET Core Web API** – Handles RESTful endpoints  
- **Entity Framework / ADO.NET** – Data persistence  
- **SQL Server / LocalDB** – Database  
- **Visual Studio 2022** – IDE and project management  

---

## 🏗 Setup Instructions

1. **Clone the solution**
```bash
git clone <your-repo-url>
