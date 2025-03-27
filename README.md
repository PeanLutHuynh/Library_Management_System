# Library Management System

## Overview
The Library Management System is a C# application designed to manage books, members, borrowing, and returning processes within a library. It follows a layered architecture and utilizes object-oriented programming principles.

## Links
**GitHub Repository**: [Library Management System Repo](https://github.com/PeanLutHuynh/Library_Management_System/)

## Features
### 1. Project Foundation & System Architecture
- Object-Oriented Programming Principle
- Design patterns implementation (Singleton, Observer, Event-Delegate, Repository)
- JSON Serialization

### 2. Book Management
- Book profile management (title, author, ISBN, etc.)
- Category and genre management
- Book availability tracking

### 3. Member Management
- Member profile management (personal details, membership status)
- Borrowing history and status tracking
- Role-based access control (Signup/Login)

### 4. Borrowing & Returning Management
- Borrowing request and approval workflow
- Due date and overdue tracking
- Borrowing and returning reports

### 5. Notification System
- Notifications for due dates and overdue books
- Alerts for new arrivals and special events

## Key Developers
| Developer | Responsibilities |
|-----------|------------------|
| **Gia Lac** | Book & User Management |
| **Quynh Huong** | Borrowing & Returning Modules |
| **Duy Thai** | DateTime Tracking System, Book Search & Architecture |
| **Minh Tuan** | Main Interface, data serialize and desiralize |

## General Requirements
- WinForms UI with a simple menu
- File-based data storage using serialization
- Object-Oriented Programming (Encapsulation, Abstraction, Inheritance, Polymorphism)
- No LINQ or Lambda expressions
- Minimum of 10 object classes
- Clear task assignments with all members contributing

## How to Run
1. Clone the repository:
   ```sh
   git clone https://github.com/PeanLutHuynh/Library_Management_System.git
   ```
2. Open the project in Visual Studio.
3. Build and run the solution.

## License
This project is for educational purposes and does not require a license.
