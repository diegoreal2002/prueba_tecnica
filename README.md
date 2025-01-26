# prueba_tecnica

is an API system designed to handle banking communication, providing functionalities for managing customers, bank accounts, and transactions. The system is built using .NET Core, following clean architecture principles and implementing design patterns like CQRS, Mediator, and Repository.

## **Main Features**
- Complete CRUD operations for:
  - Customers (`Customer`)
  - Bank accounts (`BankAccount`)
  - Transactions (`Transaction`)
- Advanced banking operations:
  - **Withdrawals:** Deducting funds from the bank account balance.
  - **Deposits:** Adding funds to the bank account balance.
  - **Transfers:** Transferring funds between bank accounts with validation.
- **Data persistence:** Integration with SQL Server using Entity Framework Core.
- **Logging:** Implemented with Serilog to log API requests and responses.
- **Unit testing:** Business logic validation using XUnit and Moq.
- **Documentation:** Endpoints documented using Swagger.
- **Postman:** Collection provided for testing API functionality.

---

## **Project Structure**
The project follows a layered architecture and clean design principles, organized as follows:

- **`MyBankingApp.Domain`:** Defines the main entities (`Customer`, `BankAccount`, `Transaction`) and their relationships.
- **`MyBankingApp.Application`:** Contains business logic, implementing patterns like CQRS and Mediator.
- **`MyBankingApp.Infrastructure`:** Handles data persistence and database integration.
- **`MyBankingApp.API`:** Exposes the API through controllers and middleware configuration.
- **`MyBankingApp.Tests`:** Unit tests for business logic.

---

## **Project Requirements**
1. **CRUD Operations:**
   - Customers (`GET`, `POST`, `PUT`, `DELETE`)
   - Bank accounts (`GET`, `POST`, `PUT`, `DELETE`)
   - Transactions (`GET`, `POST`, `PUT`, `DELETE`)
2. **Banking Operations:**
   - **Withdrawals:** Validate funds and update the account balance.
   - **Deposits:** Directly increase the account balance.
   - **Transfers:** Validate funds in the source account and adjust both accounts.
3. **Data Persistence:** SQL Server using Entity Framework Core.
4. **Logging:** Use Serilog to log API requests and responses.
5. **Unit Testing:** Validate business logic using XUnit.
6. **Documentation:** Swagger for endpoints.
7. **Postman:** Collection for testing API requests.

---

## **Deliverables**
- **Database ER Model (MER):** https://github.com/diegoreal2002/prueba_tecnica/blob/dev/MER/MER.drawio.png
- **SQL Script for the database:** https://github.com/diegoreal2002/prueba_tecnica/blob/dev/script/script.sql
- **Postman Collection with test requests:** https://github.com/diegoreal2002/prueba_tecnica/blob/dev/postman_collection/MyBankingApp.postman_collection.json
- **Logs file (txt) from generated tests:** [Pending location](#)

---

## **Setup**
### **Prerequisites**
- .NET SDK 7.0 or higher.
- SQL Server.
- Postman (optional for testing).

### **Steps to Run the Project**
1. **Clone the repository:**
   ```
   git clone [Repository URL]
   cd MyBankingApp
   ```
2. **Configure the database:**
- Run the provided SQL script to create the database.
- Update the connection string in appsettings.json in the API project:
  ```json
   "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=MyBankingApp;User Id=your_user;Password=your_password;"
    }
   ```
3. **Apply migrations:**
    ```bash
     dotnet ef database update
     ```
4. **Start the server:**
    ```bash
     dotnet run --project MyBankingApp.API
     ```
