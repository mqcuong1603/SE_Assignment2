# Exercise 1 - WinForms 3-Tier Architecture

## Order Management System

A Windows Forms application built using 3-tier architecture (Presentation Layer, Business Logic Layer, Data Access Layer) for managing orders, items, and agents.

## Project Structure

```
Exercise1_WinForms/
├── Exercise1_WinForms/          # Presentation Layer (WinForms UI)
│   ├── LoginForm.cs             # User authentication form
│   ├── MainForm.cs              # Main dashboard with menu
│   ├── ItemForm.cs              # Item CRUD operations
│   ├── AgentForm.cs             # Agent CRUD operations
│   ├── OrderForm.cs             # Order management (Master-Detail)
│   ├── FilterForm.cs            # Reports and filtering
│   ├── SessionManager.cs        # Session management
│   ├── Program.cs               # Application entry point
│   └── App.config               # Configuration with connection string
├── BusinessLogicLayer/          # Business Logic Layer
│   ├── UserBLL.cs               # User business logic
│   ├── ItemBLL.cs               # Item business logic
│   ├── AgentBLL.cs              # Agent business logic
│   └── OrderBLL.cs              # Order business logic
├── DataAccessLayer/             # Data Access Layer
│   ├── DatabaseConnection.cs   # Database connection management
│   ├── UserDAO.cs               # User data access
│   ├── ItemDAO.cs               # Item data access
│   ├── AgentDAO.cs              # Agent data access
│   ├── OrderDAO.cs              # Order data access
│   └── OrderDetailDAO.cs        # Order detail data access
└── Models/                      # Data Models
    ├── User.cs                  # User entity
    ├── Item.cs                  # Item entity
    ├── Agent.cs                 # Agent entity
    ├── Order.cs                 # Order entity
    └── OrderDetail.cs           # Order detail entity
```

## Database Setup

1. **Create Database**: Run the SQL scripts in the `Database` folder:
   - `01_CreateDatabase_and_Tables.sql` - Creates the database and tables
   - `02_InsertSampleData.sql` - Inserts sample data

2. **Update Connection String**: In `App.config`, update the connection string if needed:
   ```xml
   <connectionStrings>
     <add name="OrderManagementDB"
          connectionString="Server=localhost;Database=OrderManagementDB;Integrated Security=True;"
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

## Features

### 1. Login System
- User authentication with username and password
- Default credentials: `admin` / `123456`
- Session management with user roles

### 2. Item Management
- Add, Edit, Delete items
- Search items by name, category, or description
- DataGridView with full CRUD operations
- Fields: ItemName, Size, Price, Stock Quantity, Category, Description

### 3. Agent Management
- Add, Edit, Delete agents (customers)
- Search agents by name, company, email, or phone
- DataGridView with full CRUD operations
- Fields: AgentName, CompanyName, Address, Phone, Email, TaxCode

### 4. Order Management (Master-Detail)
- Create new orders with multiple items
- Select agent from ComboBox
- Add multiple items to order with quantity, price, and discount
- Calculate total amount automatically
- Order status tracking (Pending, Confirmed, Shipped, Delivered, Cancelled)
- View existing orders with details

### 5. Reports & Filtering
- **Best Selling Items**: View items sorted by total quantity sold
- **Top Customers**: View agents sorted by total spending
- **Items by Customer**: Filter items purchased by a specific agent
- **Customers by Item**: Filter agents who purchased a specific item
- **Orders by Status**: Filter orders by status
- Export reports to CSV

## Database Schema

### Tables
- **Users**: Authentication and user management
- **Item**: Product catalog
- **Agent**: Customer/sales agent information
- **Order**: Order header information
- **OrderDetail**: Order line items

### Key Features
- Foreign key constraints
- Indexes for performance
- Views for common queries
- Stored procedures for complex operations
- Triggers for automatic total calculation

## How to Run

1. **Prerequisites**:
   - Visual Studio 2019 or later
   - .NET Framework 4.8.1
   - SQL Server (LocalDB, Express, or Full)

2. **Setup**:
   - Open `Exercise1_WinForms.sln` in Visual Studio
   - Run the database scripts to create the database
   - Update the connection string in `App.config` if needed
   - Build the solution (Ctrl+Shift+B)
   - Run the application (F5)

3. **Login**:
   - Username: `admin`
   - Password: `123456`

## 3-Tier Architecture Benefits

1. **Separation of Concerns**: Each layer has a specific responsibility
2. **Maintainability**: Easy to modify without affecting other layers
3. **Testability**: Each layer can be tested independently
4. **Scalability**: Layers can be scaled independently
5. **Reusability**: Business logic and data access can be reused

## Technologies Used

- C# .NET Framework 4.8.1
- Windows Forms
- ADO.NET for database access
- SQL Server
- System.Configuration for configuration management

## Sample Users

| Username | Password | Role |
|----------|----------|------|
| admin | 123456 | Admin |
| john.doe | pass123 | Manager |
| jane.smith | pass123 | User |

## Notes

- The application uses soft delete for Items and Agents (sets IsActive = 0)
- Orders use hard delete with CASCADE on OrderDetail
- All prices are stored as DECIMAL(18,2)
- The database has sample data with 30 items, 25 agents, and 20 orders
- Connection string can be modified in App.config
- The application handles database connection errors gracefully

## Future Enhancements

- Add Crystal Reports or ReportViewer for printing orders
- Implement password hashing for security
- Add user management CRUD operations
- Implement data validation with error providers
- Add pagination for large datasets
- Implement async/await for database operations
- Add logging functionality
- Implement unit tests for BLL and DAL

## Author

Software Engineering Lab - Assignment 2
Week 2: Development
