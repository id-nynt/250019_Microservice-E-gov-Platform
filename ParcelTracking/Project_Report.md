# Parcel Tracking Microservice - Design and Implementation Report

## Table of Contents

1. [General Idea and Preparation](#general-idea-and-preparation)
2. [Technical Stack](#technical-stack)
3. [System Architecture](#system-architecture)
4. [Step-by-Step Implementation](#step-by-step-implementation)
5. [Deployment](#deployment)
6. [Testing and Validation](#testing-and-validation)
7. [Future Enhancements](#future-enhancements)
8. [Conclusion](#conclusion)

---

## General Idea and Preparation

### Project Overview

The **Parcel Tracking Microservice** is a standalone web application designed to allow users to track and monitor parcel delivery status using a unique tracking number. The service provides both a **RESTful API** and a **web-based interface**, making it suitable for integration into a broader ServiceUniverse ecosystem or independent deployment.

When users enter a tracking number, the system retrieves corresponding parcel details such as **status**, **location**, and **estimated time of arrival (ETA)**. If an invalid tracking number is entered, the service returns an informative message indicating that the parcel cannot be found.

### Key Features

- **Parcel Tracking API** – Retrieve parcel details by tracking number
- **Database Integration** – Uses SQLite with Entity Framework Core for persistence
- **Web Interface** – Simple HTML/CSS/JS interface for user-friendly interaction
- **Error Handling** – Returns clear messages when the parcel does not exist
- **Swagger UI** – Integrated API documentation and testing
- **Containerized Deployment** – Fully Dockerized for scalable deployment

---

## Technical Stack

### Backend Technologies

- **Framework**: ASP.NET Core 9.0 Web API
- **Language**: C# 12.0
- **Architecture**: RESTful API using MVC pattern
- **Database**: SQLite (via Entity Framework Core 9.0.9)
- **API Documentation**: Swagger/OpenAPI

### Frontend Technologies

- **HTML5** – Semantic markup for structure
- **CSS3** – Modern responsive design
- **JavaScript (ES6+)** – Fetch API for asynchronous backend communication
- **No Framework** – Vanilla JavaScript for simplicity and portability

### Development Tools

- **IDE**: Visual Studio 2022 / Visual Studio Code
- **ORM**: Entity Framework Core 9.0.9
- **Package Manager**: NuGet
- **API Testing**: Swagger UI, curl

### Containerization

- **Container Runtime**: Docker
- **Orchestration**: Docker Compose
- **Base Images**:
  - `mcr.microsoft.com/dotnet/aspnet:9.0`
  - `mcr.microsoft.com/dotnet/sdk:9.0`

### Required Packages

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="9.0.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.9" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="9.0.6" />
```

---

## System Architecture

### High-Level Architecture

```
┌─────────────────┐    HTTP/HTTPS    ┌────────────────────────┐
│   Web Browser   │ ◄──────────────► │   Parcel Tracking API  │
│   (Frontend)    │                  │   (ASP.NET Core)       │
└─────────────────┘                  └────────────────────────┘
                                             │
                                             ▼
                                    ┌─────────────────┐
                                    │  SQLite DB      │
                                    │ (Parcel Data)   │
                                    └─────────────────┘
```

### Component Architecture

```
┌──────────────────────────────────────────────────────────┐
│                ASP.NET Core Web API Host                 │
├──────────────────────────────────────────────────────────┤
│ Controllers        │ Models        │ Data Context        │
│ - ParcelController │ - ParcelModel │ - ParcelDbContext   │
├──────────────────────────────────────────────────────────┤
│ Middleware Pipeline: Static Files | Routing| Swagger|CORS│
├──────────────────────────────────────────────────────────┤
│ Frontend (wwwroot): index.html | style.css | script.js   │
└──────────────────────────────────────────────────────────┘
```

### Data Flow

1. **User Input** – User enters tracking number in the web interface or API endpoint
2. **Validation** – Input validated for null or invalid format
3. **Processing** – Backend queries SQLite database via EF Core
4. **Response** – Returns JSON containing parcel details (if found) or error message
5. **Display** – Results dynamically rendered on the webpage

---

## Step-by-Step Implementation

### Step 1: Project Creation

```bash
dotnet new webapi -n ParcelTracking
cd ParcelTracking

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Swashbuckle.AspNetCore
```

### Step 2: Model Definition (`Models/Parcel.cs`)

```csharp
namespace ParcelTracking.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Eta { get; set; }
        public string History { get; set; } = string.Empty;
    }
}
```

### Step 3: Database Context (`Data/ParcelDbContext.cs`)

```csharp
using Microsoft.EntityFrameworkCore;
using ParcelTracking.Models;
using System;

namespace ParcelTracking.Data
{
    public class ParcelDbContext : DbContext
    {
        public ParcelDbContext(DbContextOptions<ParcelDbContext> options) : base(options) { }

        public DbSet<Parcel> Parcels => Set<Parcel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parcel>().HasData(
                new Parcel { Id = 1, TrackingNumber = "AP100001", Status = "Dispatched", Location = "Sydney Facility", Eta = new DateTime(2025,10,10,8,0,0,DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 2, TrackingNumber = "AP100002", Status = "In Transit", Location = "Sydney Hub", Eta = new DateTime(2025,10,11,8,0,0,DateTimeKind.Utc), History = "[]" },
                new Parcel { Id = 3, TrackingNumber = "AP100003", Status = "Processed", Location = "Sydney Hub", Eta = new DateTime(2025,10,11,12,0,0,DateTimeKind.Utc), History = "[]" }
            );
        }
    }
}
```

### Step 4: Controller (`Controllers/ParcelController.cs`)

```csharp
using Microsoft.AspNetCore.Mvc;
using ParcelTracking.Data;
using ParcelTracking.Models;

namespace ParcelTracking.Controllers
{
    [ApiController]
    [Route("api/parcels")]
    public class ParcelController : ControllerBase
    {
        private readonly ParcelDbContext _context;

        public ParcelController(ParcelDbContext context)
        {
            _context = context;
        }

        [HttpGet("{trackingNumber}")]
        public IActionResult GetParcel(string trackingNumber)
        {
            var parcel = _context.Parcels.FirstOrDefault(p => p.TrackingNumber == trackingNumber);
            if (parcel == null)
                return NotFound(new { message = "No such parcel found." });

            return Ok(parcel);
        }
    }
}
```

### Step 5: Frontend Implementation

#### HTML (`wwwroot/index.html`)

```html
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8" />
    <title>Parcel Tracking</title>
    <link rel="stylesheet" href="style.css" />
  </head>
  <body>
    <div class="container">
      <h1>Parcel Tracking System</h1>
      <input
        id="trackingNumber"
        type="text"
        placeholder="Enter tracking number"
      />
      <button id="searchBtn">Search</button>
      <div id="result"></div>
      <div id="error" class="error"></div>
    </div>
    <script src="script.js"></script>
  </body>
</html>
```

#### JavaScript (`wwwroot/script.js`)

```javascript
document.getElementById("searchBtn").addEventListener("click", async () => {
  const tracking = document.getElementById("trackingNumber").value.trim();
  const result = document.getElementById("result");
  const error = document.getElementById("error");
  result.innerHTML = "";
  error.innerHTML = "";

  if (!tracking) {
    error.textContent = "Please enter a tracking number.";
    return;
  }

  try {
    const response = await fetch(`/api/parcels/${tracking}`);
    if (!response.ok) {
      error.textContent = "No such parcel found.";
      return;
    }

    const parcel = await response.json();
    result.innerHTML = `
      <p><strong>Tracking Number:</strong> ${parcel.trackingNumber}</p>
      <p><strong>Status:</strong> ${parcel.status}</p>
      <p><strong>Location:</strong> ${parcel.location}</p>
      <p><strong>ETA:</strong> ${new Date(parcel.eta).toLocaleString()}</p>
    `;
  } catch (err) {
    error.textContent = "Network error: " + err.message;
  }
});
```

---

## Deployment

### Dockerfile

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5173

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["ParcelTracking.csproj", "./"]
RUN dotnet restore "ParcelTracking.csproj"
COPY . .
RUN dotnet build "ParcelTracking.csproj" -c Release -o /app/build
RUN dotnet publish "ParcelTracking.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ParcelTracking.dll"]
```

### Docker Compose (`docker-compose.yml`)

```yaml
services:
  parceltracking:
    container_name: "parceltracking"
    build:
      context: .
      dockerfile: ./Dockerfile
    ports:
      - "5173:5173"
    restart: always
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ASPNETCORE_URLS=http://+:5173
```

### Local and Container Deployment

```bash
# Run locally
dotnet run

# Access URLs:
# - Web UI: http://localhost:5173
# - API: http://localhost:5173/api/parcels/AP100001
# - Swagger: http://localhost:5173/swagger

# Run with Docker
docker build -t parceltracking .
docker run -p 5173:5173 parceltracking

# Or using Compose
docker-compose up -d
```

---

## Testing and Validation

### Manual Testing

| Input    | Expected Output                   |
| -------- | --------------------------------- |
| AP100001 | Parcel details shown (Dispatched) |
| AP100002 | Parcel details shown (In Transit) |
| AP100003 | Parcel details shown (Processed)  |
| AP999999 | "No such parcel found." message   |

### API Testing with curl

# Valid request

curl -X GET http://localhost:5173/api/parcels/AP100001

# Invalid request

curl -X GET http://localhost:5173/api/parcels/AP999999

```

### Automated Testing Recommendations

1. **Unit Tests** – Validate controller and database logic
2. **Integration Tests** – Ensure API and DB work together correctly
3. **Frontend Tests** – Test input validation and dynamic rendering
4. **Contract Tests** – Verify REST API schema and response integrity

---

## Future Enhancements

### Immediate Improvements

1. Add more detailed error handling and logging.
2. Implement advanced input validation and request throttling.
3. Improve frontend layout for responsive design.

### Advanced Features

1. **Multi-carrier Support** – Integrate different logistics providers.
2. **Tracking History** – Display full event timeline for each parcel.
3. **Notifications** – Email/SMS updates for parcel status.
4. **Caching** – Use Redis to cache recent tracking results.

### Enterprise Features

1. **Authentication** – Add JWT-based role management.
2. **Health Checks** – Implement service readiness endpoints.
3. **Monitoring** – Integrate Prometheus metrics and Grafana dashboards.
4. **Security** – Add HTTPS, API key authentication, and CORS policies.

---

## Conclusion

### Project Success Criteria

✅ **Functional Requirements Met:**

- RESTful API successfully retrieves parcel data.
- User-friendly web interface operational.
- Docker containerization enables microservice deployment.

✅ **Technical Requirements Satisfied:**

- Built with .NET 8.0 and modern development practices.
- Clean separation between frontend, backend, and database layers.
- Configuration-driven and maintainable structure.

✅ **Microservice Characteristics Achieved:**

- Independent service with single responsibility.
- Network-accessible and stateless API.
- Deployable through Docker for scalability.

### Key Learnings

1. Mastery of RESTful API and EF Core integration.
2. Clear separation of concerns between architecture layers.
3. Full-stack synchronization using JavaScript fetch API.
4. Docker deployment and container networking within a microservice ecosystem.

### Project Value

The Parcel Tracking Microservice provides a complete example of a modern microservice following clean architectural principles. It demonstrates how a simple domain-specific service can be built, deployed, and integrated into a scalable ServiceUniverse. The project is both practical and extendable, forming a solid foundation for future enterprise-level development.
```
