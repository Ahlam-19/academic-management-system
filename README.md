 Academic Management System API

A robust "ASP.NET Core Web API" designed to manage academic operations including Students, Employees, Departments, Courses, Subjects, Semesters, and Users.

This project follows a "Clean layered architecture" and demonstrates real-world CRUD operations with proper separation of concerns using Services and Repositories.



  Features

*  User Registration (Employee & Student)
*  Student Management
*  Employee Management
*  Department Management
*  Course Management
*  Subject Management
*  Semester Management
*  User Management (Compact & Full)
*  Dependency Injection
*  SQL Injection Using ADO.NET
*  Layered Architecture (Controller → Service → Repository)
  
  



 Tech Stack

* Framework: ASP.NET Core Web API
* Language: C#
* Architecture: Clean / Layered Architecture
* Database: SQL Server
* SQL Server Data Access:ADO.NET(SQL Queries)
* API Testing: Postman 



📂 Project Structure


/Api/Controllers        → API endpoints
/Application            → Business logic & service interfaces
/Domain                 → Entities & enums
/Persistence        → Database & repositories


 📘 Courses API

| Method | Endpoint            | Description      |
| ------ | ------------------- | ---------------- |
| POST   | `/api/courses`      | Add course       |
| PUT    | `/api/courses/{id}` | Update course    |
| DELETE | `/api/courses/{id}` | Delete course    |
| GET    | `/api/courses`      | Get all courses  |
| GET    | `/api/courses/{id}` | Get course by ID |

---

 🏫 Departments API

| Method | Endpoint                      | Description             |
| ------ | ----------------------------- | ----------------------- |
| POST   | `/api/departments`            | Add department          |
| GET    | `/api/departments`            | Get all departments     |
| GET    | `/api/departments/{id}`       | Get department by ID    |
| DELETE | `/api/departments/{id}`       | Delete department       |
| PUT    | `/api/departments/{deptName}` | Update department (HOD) |

---

👨‍💼 Employees API

| Method | Endpoint              | Description        |
| ------ | --------------------- | ------------------ |
| GET    | `/api/employees`      | Get all employees  |
| GET    | `/api/employees/{id}` | Get employee by ID |

---

👨‍🎓 Students API

| Method | Endpoint             | Description       |
| ------ | -------------------- | ----------------- |
| GET    | `/api/students`      | Get all students  |
| GET    | `/api/students/{id}` | Get student by ID |

---

## 📅 Semesters API

| Method | Endpoint              | Description        |
| ------ | --------------------- | ------------------ |
| POST   | `/api/semesters`      | Add semester       |
| PUT    | `/api/semesters/{id}` | Update semester    |
| DELETE | `/api/semesters/{id}` | Delete semester    |
| GET    | `/api/semesters`      | Get all semesters  |
| GET    | `/api/semesters/{id}` | Get semester by ID |

---

 📚 Subjects API

| Method | Endpoint             | Description       |
| ------ | -------------------- | ----------------- |
| POST   | `/api/subjects`      | Add subject       |
| PUT    | `/api/subjects/{id}` | Update subject    |
| DELETE | `/api/subjects/{id}` | Delete subject    |
| GET    | `/api/subjects`      | Get all subjects  |
| GET    | `/api/subjects/{id}` | Get subject by ID |

---

 👤 Users API

 Employee User Compact

* `GET /api/users/user-employee-compact/{id}`
* `GET /api/users/user-employee-basic-list`
* `PUT /api/users/employee/{id}`

 Student User Compact

* `GET /api/users/user-student-compact/{id}`
* `GET /api/users/user-student-basic-list`
* `PUT /api/users/student/{id}`

 General Users

* `GET /api/users`
* `GET /api/users/{id}`
* `DELETE /api/users/{id}/{userRole}`



 ⚙️ Getting Started

1. Clone Repository.

2. Configure Database:
   Update connection string in:appsettings.json

3.Run DataBase Scripts:
   Given in BackupFile of Data Folder of Persistence Layer to create tables

4. Run the Application



 📄 License

This project is licensed under the MIT License.


 👨‍💻 Author:
Ahlam Mushtaq

