# Relaxing Koala Restaurant Information System (RIS)

## Overview
The **Relaxing Koala Restaurant Information System (RIS)** is a comprehensive solution designed to streamline restaurant operations and enhance customer satisfaction. Built using the ASP.NET MVC framework, it features a modular and scalable design tailored to the needs of modern restaurant management.

Key functionalities include:
- **Menu Management**: Dynamic updates for menus and items.
- **Order Management**: Efficient processing and tracking.
- **Reservation Management**: Optimized table scheduling and utilization.
- **Payment Processing**: Transparent and secure transactions.
- **Kitchen Workflow Optimization**: Real-time order tracking and preparation.
- **Delivery Management**: Seamless tracking of delivery orders.
- **Statistics and Reporting**: Actionable insights for data-driven decisions.

---
## Features
### Core Modules
- **Menu & Menu Items**: Add, update, or delete menus and items, with real-time synchronization across platforms.
- **Orders**: Comprehensive order management, integrated with kitchen and delivery workflows.
- **Reservations**: Automated table allocation with support for multiple tables per reservation.
- **Payments**: Multiple payment modes with receipt generation.
- **Delivery**: Efficient order tracking and assignment to delivery personnel.
- **Statistics**: Reports on sales trends, popular items, and overall performance.
### User Roles
1. **Customers**: View menus, make reservations, and place orders.
2. **Staff**: Manage orders, reservations, and customer records.
3. **Managers**: Full administrative access with advanced reporting and modification rights.

---
## Technology Stack
- **Framework**: ASP.NET MVC
- **Frontend**: Razor Views with Bootstrap and custom CSS
- **Database**: SQLite (Code-First with Entity Framework)
- **Authorization**: Role-based Access Control (RBAC) using ASP.NET Identity

---
## Setup and Installation
1. **Clone the Repository**:
```bash
git clone https://github.com/rayraurray/relax-ko
cd relax-ko
```
2. **Ensure SQLite is installed.**
3. **Run the Application**:
Run from CLI...
```bash
dotnet run
```
Or navigate to the project's solution file in Visual Studio and run either normally or with Debug.

---
## Usage

### Key Use Cases

- **Managing Menus**: Add or modify menu items using the intuitive interface.
- **Order Placement**: Process orders for dine-in, takeout, or delivery.
- **Reservations**: Schedule tables efficiently with conflict-free allocation.
- **Payments**: Record and track payments seamlessly.
- **Delivery Tracking**: Monitor and update delivery statuses.
- **View Reports**: Gain insights into restaurant performance and trends.