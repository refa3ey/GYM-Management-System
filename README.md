<div align="center">

# 🏋️ GYM Management System

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)

A full-featured desktop application for managing gym operations built with C# Windows Forms and SQL Server.

</div>

---

## 📋 Table of Contents
- [About](#about)
- [Features](#features)
- [Technologies](#technologies)
- [Database Structure](#database-structure)
- [Getting Started](#getting-started)
- [Team](#team)

---

## 📌 About
The GYM Management System is a desktop application designed to help gym owners and staff manage their daily operations efficiently. It covers member registration, membership plan management, trainer scheduling, payment tracking, attendance monitoring, and report generation.

---

## ✨ Features

| Feature | Description |
|--------|-------------|
| 🔐 Login System | Secure login for Admins and Members |
| 👤 Member Management | Add, edit, delete and search members |
| 💳 Membership Plans | Manage Basic, Standard, Premium and VIP plans |
| 💰 Payment Tracking | Record and monitor all payment transactions |
| 📅 Attendance | Track member check-ins and check-outs |
| 🏃 Trainer Management | Manage trainer profiles and specializations |
| 📆 Workout Schedule | View and manage class timetables |
| 📊 Reports | Generate reports for members, payments and attendance |

---

## 🛠️ Technologies

- **Language:** C#
- **Framework:** .NET Framework 4.8
- **UI:** Windows Forms
- **Database:** Microsoft SQL Server
- **IDE:** Microsoft Visual Studio 2022

---

## 🗄️ Database Structure
GymDB
├── Admins
├── Members
├── MembershipPlans
├── Trainers
├── Payments
├── Attendance
└── WorkoutSchedule
---

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2022
- SQL Server / SQL Server Express
- .NET Framework 4.8

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/refa3ey/GYM-Management-System.git
```

2. **Set up the database**
   - Open SQL Server Management Studio (SSMS)
   - Create a new database named `GymDB`
   - Run the SQL script from `/Database/` folder

3. **Update connection string**
   - Open `Database/DatabaseHelper.cs`
   - Replace `YOUR_SERVER_NAME` with your SQL Server name

4. **Run the project**
   - Open `GYM-Desktop-app.sln` in Visual Studio
   - Press `F5` to run

### Default Admin Login
Username: admin
Password: admin123
---


</div>
