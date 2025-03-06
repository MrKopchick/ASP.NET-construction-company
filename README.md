# ASP.NET Construction Company Web Application

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A construction company management web application built with **ASP.NET Core MVC**. The application allows administrators to manage services, service categories, and user authentication, while providing a user-friendly interface for customers to explore services.

---

## Features

### Admin Features
- **Service Management**:
  - Add, edit, and delete services
  - Upload service images
  - Categorize services under service categories
- **Service Category Management**:
  - Add, edit, and delete service categories
  - Associate services with categories
- **Admin Dashboard**:
  - View all services and categories
  - Perform CRUD operations
- **Authentication**:
  - Admin role-based access control
  - Secure login and logout

### User Features
- **Service Catalog**:
  - Browse services with detailed descriptions
  - View services by category
- **Responsive Design**:
  - Mobile-friendly layout
  - Dynamic menus and components

---

## Technologies Used

### Backend
- **ASP.NET Core MVC**: Web framework for building the application
- **Entity Framework Core**: ORM for database management
- **SQL Server**: Database for persistent storage
- **Identity Framework**: User authentication and role management
- **Dependency Injection**: Built-in IoC container for service registration
- **Repository Pattern**: Abstraction layer for data access
- **Serilog**: Structured logging for better debugging

### Frontend
- **Razor Pages**: Dynamic HTML generation with C#
- **Bootstrap**: Responsive and modern UI components
- **JavaScript/jQuery**: Client-side interactivity
- **Tag Helpers**: Clean and maintainable Razor syntax

---

## Project Structure

### Key Components
- **Controllers**:
  - `ServicesController`: Handles service-related views and actions
  - `AccountController`: Manages user authentication (login/logout)
  - `AdminController`: Handles admin-specific operations (CRUD for services and categories)
- **Models**:
  - `Service`: Represents a construction service
  - `ServiceCategory`: Represents a category for services
  - `ServiceDTO`: Data transfer object for service views
- **Repositories**:
  - `EFServiceCategoriesRepository`: Implements CRUD operations for service categories
  - `EFServicesRepository`: Implements CRUD operations for services
- **Views**:
  - Razor views for services, categories, and admin dashboard
  - Partial views and view components for reusable UI elements

---
