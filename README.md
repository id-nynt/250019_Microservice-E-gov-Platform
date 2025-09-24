# ⚙️ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) (for local development)  
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (for containerized demo)  
- Git (to clone repo)  

**Packages (NuGet dependencies):**
- `Microsoft.EntityFrameworkCore.InMemory` → In-memory database for demo storage  
- `Swashbuckle.AspNetCore` → Swagger API docs  
- `Microsoft.AspNetCore.Mvc` → REST controllers  

---

## 🚀 Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/<your-username>/ServiceUniverse.git
cd ServiceUniverse
```

###2. Run a service individually
```bash
cd CourseSearch
dotnet run
```
CourseSearch → http://localhost:6003/swagger
TaxCalculation → http://localhost:6002/swagger
