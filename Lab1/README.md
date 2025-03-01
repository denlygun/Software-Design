# Warehouse Management System

## Principles Demonstrated

### 1. DRY (Don't Repeat Yourself)
The code avoids duplication by using reusable classes like `Money`, `Product`, `Warehouse`, and `Reporting`.

**Example:** [`Reporting.GenerateInvoice()`](./Lab1/Reporting.cs#L10) method is used to generate invoices, preventing duplicate invoice logic.

### 2. KISS (Keep It Simple, Stupid)
The implementation is straightforward and avoids unnecessary complexity.

**Example:** Simple constructors and clear method names improve readability and maintainability.

### 3. SOLID Principles

#### - Single Responsibility Principle (SRP)
Each class has a single responsibility:
- [`Money`](./Lab1/Money.cs) - Manages money representation.
- [`Product`](./Lab1/Product.cs) - Handles product data and price modifications.
- [`Warehouse`](./Lab1/Warehouse.cs) - Manages inventory.
- [`Reporting`](./Lab1/Reporting.cs) - Generates invoices.

#### - Open/Closed Principle (OCP)
The [`Product`](./Lab1/Product.cs) class can be extended without modifying existing code, e.g., adding different discount strategies.

#### - Liskov Substitution Principle (LSP)
If needed, subclasses of [`Product`](./Lab1/Product.cs) or [`Money`](./Lab1/Money.cs) can be introduced without breaking existing functionality.

#### - Interface Segregation Principle (ISP)
The classes are designed with clear, single-purpose methods, avoiding large, unfocused interfaces.

#### - Dependency Inversion Principle (DIP)
High-level modules like [`Warehouse`](./Lab1/Warehouse.cs) do not depend on low-level implementations but instead use abstraction (e.g., `Product` class rather than hardcoded product types).

### 4. YAGNI (You Ain't Gonna Need It)
The implementation avoids unnecessary complexity by including only required features.

**Example:** No unnecessary inheritance or unused methods.

### 5. Composition Over Inheritance
Instead of using inheritance, the [`Warehouse`](./Lab1/Warehouse.cs) class contains a list of [`Product`](./Lab1/Product.cs) instances.

### 6. Program to Interfaces, Not Implementations
The design ensures that objects communicate through well-defined interfaces (e.g., [`Money`](./Lab1/Money.cs) encapsulates currency and value representation).

### 7. Fail Fast
The constructors enforce the correct structure of objects (e.g., [`Money`](./Lab1/Money.cs) ensures both whole and cent values are stored properly).

