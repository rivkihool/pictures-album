# 📸 Personal Pictures Album Web Application

## 📝 Overview

This is a full-stack web application that allows a user to manage a personal pictures album.

* **Frontend**: React (SPA)
* **Backend**: .NET Core WebAPI
* **Database**: SQL Server (LocalDB)
* **Architecture**: Layered solution with clear separation of concerns

The system is accessed via a direct URL and **does not require login or authentication**.

---

## 🧩 Project Structure

```
PicturesAlbum/                 <-- Root
│
├── client/                    <-- React Frontend (create-react-app)
│   ├── public/
│   └── src/
│       ├── components/
│       └── App.js
│
├── server/                    <-- .NET Solution Folder
│   ├── PicturesAlbum.Core/          <-- Entities, DTOs, Interfaces
│   ├── PicturesAlbum.Infrastructure/ <-- EF DbContext, Repository
│   ├── PicturesAlbumAPI/            <-- Controllers, Startup Config
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   └── Controllers/
│   └── PicturesAlbum.sln           <-- Solution file
│
└── README.md
```

---

## 🔧 Features

1. View existing uploaded pictures by name + ID.
2. Upload a new picture with its name and file.
3. Backend handles file saving + metadata insertion to DB.
4. All pictures stored in SQL Server with name, filename, timestamp.
5. Professional layered architecture:

   * **Core**: Entities, contracts (interfaces, DTOs).
   * **Infrastructure**: Data access logic (EF Core).
   * **API**: WebAPI controllers, middleware, configuration.

---

## 🚀 Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/<your-repo>/pictures-album.git
cd pictures-album
```

### 2. Database Setup (SQL Server LocalDB)

Ensure you have LocalDB installed (comes with Visual Studio).

Update the file:

```
server/PicturesAlbumAPI/appsettings.json
```

with your connection string, for example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PicturesAlbumDB;Trusted_Connection=True;"
}
```

Apply migrations:

```bash
cd server
cd PicturesAlbumAPI
# OR set as startup project and open Package Manager Console
choose:PicturesAlbum.Infrastructure
Add-Migration InitialCreate
Update-Database
```

### 3. Run the Backend (WebAPI)

Using Visual Studio:

* Set **PicturesAlbumAPI** as Startup Project.
* Hit **F5** or run without debugging.

Or via CLI:

```bash
cd server/PicturesAlbumAPI
dotnet run
```

Default URL: `https://localhost:5001/api/pictures`

### 4. Run the Frontend (React)

```bash
cd client
npm install
npm start
```

Opens on: `http://localhost:3000`

---

## 🛠 Technologies Used

* React 18
* Axios
* ASP.NET Core 7 WebAPI
* Entity Framework Core
* SQL Server (LocalDB)
* Custom CSS (no framework)

---

## 📂 Folder Notes

* `appsettings.json`: Required for local DB config (included in repo)
* `DesignTimeDbContextFactory.cs`: Added for design-time migration support
* `wwwroot/uploads`: Where uploaded pictures are saved (create if missing)

---

## 🧪 Usage Flow

1. User opens the app in browser (`http://localhost:3000`)
2. Left panel shows uploaded pictures (ID + Name)
3. Right panel contains form to upload new picture:

   * Enter name
   * Choose image
   * Click **Upload**
4. Picture is saved to disk + DB, and list updates

---

## 📌 Notes

* No authentication required — open for demo purposes only.
* Error handling is minimal to focus on functionality.
* Code structured cleanly to reflect separation of concerns.

---

## ✅ Completion Status

This project fulfills all requirements of the assignment:

* SPA using React
* .NET WebAPI backend
* Picture upload + display
* Clear architecture and documentation

---

Thank you for reviewing! Feel free to reach out if any setup issues occur.
