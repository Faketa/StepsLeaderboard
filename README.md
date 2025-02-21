# 🏆 StepsLeaderboard API

StepsLeaderboard is a **.NET 8 Web API** designed to track step counts for teams and individual users.  
It follows **Clean Architecture**, **CQRS (MediatR)**, and **Dependency Injection** to ensure **scalability and maintainability**.

---

## **📌 Features**
✔ Create, update, and delete **Counters (step trackers)**.  
✔ Assign a **Counter** to a **single team** (prevents multi-team assignment).  
✔ List **all teams** and **counters assigned to them**.  
✔ Track **total steps per team**.  
✔ Prevent reassigning **existing counters** to different teams.  
✔ Uses **Swagger UI** for API documentation.  
✔ **Unit tests** with NUnit & Moq.

---

## **📌 Tech Stack & Dependencies**
| **Technology** | **Usage** |
|--------------|---------|
| **ASP.NET Core 8** | Web API Framework |
| **MediatR** | CQRS pattern implementation |
| **FluentValidation** | Request validation |
| **Serilog** | Logging |
| **Moq** | Unit testing (mocking) |
| **NUnit** | Unit test framework |
| **Swashbuckle (Swagger)** | API documentation |

---

## **📌 Project Deployment**
The project has been published on **Microsoft Azure** and can be accessed via the following links:

- 🌍 **Swagger Documentation (Azure Hosted API):**  
  [https://webappsandbox-a0brbucefug3f3fj.canadacentral-01.azurewebsites.net/swagger/index.html](https://webappsandbox-a0brbucefug3f3fj.canadacentral-01.azurewebsites.net/swagger/index.html)

- 🚀 **API Gateway URL (Tier Consumption):**  
  [https://stepsleaderboardapiapi.azure-api.net](https://stepsleaderboardapiapi.azure-api.net)

---

## **📌 Project Structure**
```
StepsLeaderboard/
│── 📁 StepsLeaderboard.API/          # ASP.NET Web API (Controllers, Middlewares)
│── 📁 StepsLeaderboard.Application/  # Business logic (CQRS, Validators, DTOs)
│── 📁 StepsLeaderboard.Domain/       # Entities & Core Domain logic
│── 📁 StepsLeaderboard.Infrastructure/ # Data persistence (Repositories)
│── 📁 StepsLeaderboard.Tests/        # NUnit test project
```

✔ **Follows Clean Architecture**: API layer **depends on Application**, but **Application does NOT depend on API**.  
✔ **CQRS**: Separates **Commands (write operations)** and **Queries (read operations)** via **MediatR**.  
✔ **Infrastructure Layer**: Contains **repositories** for data storage.  
✔ **Testing Layer**: Uses **Moq for mocking** and **NUnit for testing**.

---

## **📌 How to Run the Project**
### **1️⃣ Install .NET 8**
Ensure **.NET 8 SDK** is installed:
```sh
dotnet --version
```
If not installed, download it from:  
🔗 [Download .NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

---

### **2️⃣ Clone the Repository**
```sh
git clone https://github.com/your-repo/StepsLeaderboard.git
cd StepsLeaderboard
```

---

### **3️⃣ Restore Dependencies**
```sh
dotnet restore
```

---

### **4️⃣ Run the Application**
```sh
dotnet run --project StepsLeaderboard.API
```

The API should now be running on:  
**http://localhost:5000**

---

## **📌 Using Swagger UI**
📌 **Swagger UI** is available at:  
🔗 [http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)

Swagger allows **testing API endpoints interactively**.

✔ **Lists all available API routes**  
✔ **Allows sending test requests**  
✔ **Shows request/response models**  

---

## **📌 Running Unit Tests**
Unit tests are written in **NUnit** and **Moq**.

📌 **Run tests:**
```sh
dotnet test
```
📌 **Expected Output:**
```
Passed! - 10 tests run
```

---

## **📌 Contributions**
✔ Fork the repo  
✔ Create a new branch  
✔ Open a Pull Request  