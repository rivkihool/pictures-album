

# 📸 Pictures Album Project

This project is a simple web-based Single Page Application (SPA) that allows users to manage a personal photo album. It includes a **React.js** frontend and a **.NET Core Web API** backend with a **SQL Server** database.

---

## 📁 Project Structure

The solution contains 3 main projects:

PicturesAlbum
│
├── PicturesAlbum.Core
│ ├── DTOs
│ ├── Entities
│ ├── Interfaces
│ └── Services
│
├── PicturesAlbum.Infrastructure
│ ├── Data
│ │ └── PictureDbContext.cs
│ ├── Migrations
│ ├── Services
│ └── DesignTimeDbContextFactory.cs
│
└── PicturesAlbumAPI (Startup Project)
├── Controllers
├── DTOs
├── Pages
├── wwwroot
└── appsettings.json


---

## 🧩 Project Summary

- No authentication required – open to public access
- Upload and view pictures
- Backend: RESTful API using ASP.NET Core
- Frontend: React SPA using Axios to communicate with backend
- Entity Framework Core Code-First
- Layered architecture: Core, Infrastructure, and API

---

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core Web API (.NET 6+)
- **Frontend**: React.js
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Development Tools**: Visual Studio 2022, SSMS, Git, VS Code

---

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR-REPO
cd pictures-album

2. Configure the Database
In the PicturesAlbumAPI project, create or edit the appsettings.json file with your SQL Server connection string:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=PicturesDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Replace YOUR_SERVER_NAME with your actual SQL Server instance name.

3. Apply Database Migrations
1.Open Visual Studio

2.Set Default Project in Package Manager Console to PicturesAlbum.Infrastructure

3.Run:Update-Database
This will apply the migration and create the DB schema.

 ▶️Run the Backend API
1.Open the solution in Visual Studio

2.Right-click on PicturesAlbumAPI → Set as Startup Project

3.Press F5 or click Run

Backend API will start at:https://localhost:xxxx/api/Pictures

💻 Run the React Frontend
1.Open terminal

2.Navigate to the client folder
cd client
3.Install dependencies:npm install
4.Start the development server:npm start
React app will open at:http://localhost:3000


📂 API Endpoints
Method	Endpoint	Description
GET	/api/Pictures	Get all pictures
POST	/api/Pictures	Upload a new picture


📝 Notes
Uploaded images are stored in: PicturesAlbumAPI/wwwroot/images/

Data is stored in the SQL Server database

The project was built with clean code principles:

DTOs for communication

Dependency injection

Layered separation: Core, Infrastructure, API

No authentication or user management included (not required)


📌 Purpose
This project was built as a technical assignment for a job application. It demonstrates full-stack development skills, clean architecture, and the ability to deliver a working end-to-end web application.

👩‍💻 Developer
Name: Rivka Hool
Role: Full Stack Developer
Experience: 3+ years
Languages: C#, JavaScript
Contact: Upon request




