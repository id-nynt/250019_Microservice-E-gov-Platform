# CourseSearch Microservice - Design and Implementation Report

## 1. Executive Summary

The CourseSearch microservice is a RESTful web application designed to provide search functionality for educational courses. Built using modern web technologies, it serves as a standalone microservice that can be integrated into a larger ServiceUniverse ecosystem. The application provides both API endpoints and a web interface for searching courses by various criteria including keywords, location, course area, and study options.

## 2. General Idea and Preparation

### 2.1 Project Overview

The CourseSearch microservice addresses the need for a centralized course discovery system that allows users to search through various educational offerings across different disciplines and locations. The system is designed with microservice architecture principles, ensuring it can operate independently while being easily integrated with other services.

### 2.2 Technical Stack Selection

#### Backend Technologies:

- **C# and .NET 8.0**: Chosen for robust, enterprise-grade web API development
- **ASP.NET Core Web API**: Provides lightweight, high-performance REST API framework
- **Entity Framework Core 9.0.9**: Object-Relational Mapping (ORM) for database operations
- **SQLite**: Lightweight, serverless database suitable for microservice deployment

#### Frontend Technologies:

- **HTML5**: Modern markup for semantic web structure
- **CSS3**: Styling and responsive design
- **Vanilla JavaScript**: Client-side interactivity and API consumption

#### DevOps and Deployment:

- **Docker**: Containerization for consistent deployment across environments
- **Docker Compose**: Multi-container orchestration
- **Swagger/OpenAPI**: API documentation and testing interface

### 2.3 Package Dependencies

The project utilizes the following NuGet packages:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="9.0.9" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.9" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="9.0.4" />
```

## 3. System Architecture and Workflow

### 3.1 Overall Architecture

The CourseSearch microservice follows a three-tier architecture:

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Frontend      │    │   Backend       │    │   Database      │
│   (HTML/CSS/JS) │◄──►│   (ASP.NET API) │◄──►│   (SQLite)      │
└─────────────────┘    └─────────────────┘    └─────────────────┘
```

#### Frontend Layer:

- Responsive web interface for user interaction
- JavaScript handles form validation and API communication
- Dynamic rendering of search results

#### Backend Layer:

- RESTful API controllers handle HTTP requests
- Business logic for course filtering and searching
- Swagger documentation for API endpoints

#### Data Layer:

- SQLite database for data persistence
- Entity Framework Core for data access
- Migration-based schema management

### 3.2 Database Design

#### Course Entity Model:

```csharp
public class Course
{
    [Key]
    public string CourseCode { get; set; } = "";      // Primary Key
    public string CourseName { get; set; } = "";      // Course title
    public string Level { get; set; } = "";           // Education level
    public string CourseArea { get; set; } = "";      // Subject area
    public string Location { get; set; } = "";        // Physical location
    public string StudyOption { get; set; } = "";     // Study mode
    public string Duration { get; set; } = "";        // Course duration
    public decimal EstimatedFee { get; set; }         // Course fee
}
```

#### Data Categories:

- **Information Technology**: Programming, Web Development, Cloud Computing, Data Science, Cybersecurity
- **Health**: Individual Support, Nursing, Community Health, Mental Health, Public Health
- **Trades**: Carpentry, Electrical, Plumbing, Welding, Automotive
- **Hospitality**: Cookery, Hotel Management, Bakery, Café Management, Culinary Arts
- **Creative Arts**: Fashion Design, Interior Design, Photography, Fine Arts, Graphic Design
- **Business and Administration**: Business Administration, Leadership, Commerce, Project Management, MBA
- **Agriculture**: Agricultural Practices, Horticulture, Agribusiness, Agricultural Science, Sustainable Farming

### 3.3 API Design

#### Primary Endpoint:

- **GET /api/courses**: Search courses with optional query parameters
  - `keyword`: Search in course name or code
  - `location`: Filter by location
  - `area`: Filter by course area
  - `studyOption`: Filter by study mode

#### Secondary Endpoint:

- **GET /api/courses/all**: Retrieve all courses

#### Response Format:

```json
[
  {
    "courseCode": "IT101",
    "courseName": "Intro to Programming",
    "level": "Certificate IV",
    "courseArea": "Information Technology",
    "location": "Sydney",
    "studyOption": "Full time",
    "duration": "6 months",
    "estimatedFee": 2500.0
  }
]
```

## 4. Step-by-Step Implementation

### 4.1 Project Creation via ASP.NET Core API

1. **Initialize Project**:

   ```bash
   dotnet new webapi -n CourseSearch
   cd CourseSearch
   ```

2. **Add Required Packages**:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Swashbuckle.AspNetCore
   ```

### 4.2 Define Models with Key Annotations

**Course Model Implementation**:

```csharp
using System.ComponentModel.DataAnnotations;

namespace CourseSearch.Models
{
    public class Course
    {
        [Key]
        public string CourseCode { get; set; } = "";
        public string CourseName { get; set; } = "";
        public string Level { get; set; } = "";
        public string CourseArea { get; set; } = "";
        public string Location { get; set; } = "";
        public string StudyOption { get; set; } = "";
        public string Duration { get; set; } = "";
        public decimal EstimatedFee { get; set; }
    }
}
```

Key features:

- `[Key]` attribute designates CourseCode as primary key
- All properties have default values to prevent null reference issues
- Decimal type for EstimatedFee ensures proper currency handling

### 4.3 Database Implementation with SQLite

#### 4.3.1 DbContext Configuration

```csharp
public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
```

#### 4.3.2 Database Configuration for Mock Data

The `CourseConfiguration` class implements `IEntityTypeConfiguration<Course>` to seed the database with comprehensive sample data covering 7 course areas and 35 different courses.

**Data Seeding Strategy**:

- Representative courses across multiple disciplines
- Varied education levels (Certificate II through Master)
- Different locations across Australia
- Multiple study options (Full time, Part time, Self-paced)
- Realistic fee structures

#### 4.3.3 Migration Implementation

```bash
dotnet ef migrations add Add_Data
dotnet ef database update
```

The migration creates the Courses table and populates it with seed data, ensuring consistent database state across deployments.

### 4.4 Controller Implementation

#### 4.4.1 CoursesController Architecture

```csharp
[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly CourseDbContext _db;

    public CoursesController(CourseDbContext db)
    {
        _db = db;
    }
```

#### 4.4.2 Search Logic Implementation

The search endpoint implements flexible filtering:

1. **Keyword Search**: Case-insensitive matching in course name and code
2. **Location Filter**: Partial matching for location names
3. **Area Filter**: Exact matching for course areas
4. **Study Option Filter**: Exact matching for study modes
5. **Result Ordering**: Sorted by course area, then by course name

**Query Building Pattern**:

```csharp
IQueryable<Course> q = _db.Courses;

if (!string.IsNullOrWhiteSpace(keyword))
{
    var k = keyword.Trim().ToLower();
    q = q.Where(c => c.CourseName.ToLower().Contains(k) ||
                     c.CourseCode.ToLower().Contains(k));
}
```

This approach allows for efficient query composition and database-level filtering.

### 4.5 Frontend Implementation

#### 4.5.1 HTML Structure

The frontend provides a clean, accessible interface with:

- Text input for keyword search
- Location input field
- Dropdown selectors for course area and study option
- Results display area

#### 4.5.2 JavaScript Logic for API Integration

```javascript
async function doSearch() {
  const params = new URLSearchParams();
  if (keyword) params.append("keyword", keyword);
  // ... build other parameters

  const url =
    "/api/courses" + (params.toString() ? "?" + params.toString() : "");

  try {
    const res = await fetch(url);
    if (!res.ok) {
      showError("Search failed: " + res.statusText);
      return;
    }
    const list = await res.json();
    renderResults(list);
  } catch (err) {
    showError("Network error: " + err.message);
  }
}
```

**Key Features**:

- Asynchronous API calls using modern fetch API
- Dynamic URL construction with query parameters
- Comprehensive error handling
- XSS protection through HTML escaping
- Responsive table rendering for results

#### 4.5.3 Styling and User Experience

The CSS implementation provides:

- Clean, professional appearance
- Responsive design principles
- Consistent spacing and typography
- Accessible color schemes
- Hover states and visual feedback

### 4.6 Docker Configuration

#### 4.6.1 Dockerfile Implementation

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["CourseSearch.csproj", "./"]
RUN dotnet restore "CourseSearch.csproj"
COPY . .
RUN dotnet build "CourseSearch.csproj" -c $configuration -o /app/build

FROM build AS publish
RUN dotnet publish "CourseSearch.csproj" -c $configuration -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseSearch.dll"]
```

**Multi-stage Build Benefits**:

- Optimized image size by excluding build tools from final image
- Consistent build environment
- Support for different configuration builds

#### 4.6.2 Docker Compose Configuration

```yaml
services:
  coursesearch:
    container_name: "coursesearch"
    build:
      context: .
      dockerfile: ./Dockerfile
    volumes:
      - ./data:/app/data
    ports:
      - "5003:80"
    restart: always
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - DB_PATH=/app/data/courses.db
    networks:
      - universe-network
```

**Configuration Features**:

- **Port Mapping**: External port 5003 maps to internal port 80
- **Volume Mounting**: Database persistence through volume mapping
- **Network Integration**: Connected to universe-network for microservice communication
- **Environment Variables**: Configurable database path and environment settings
- **Restart Policy**: Automatic container restart on failure

## 5. Application Configuration

### 5.1 Program.cs Configuration

The main application configuration includes:

```csharp
// Database configuration with environment variable support
var dbPath = Environment.GetEnvironmentVariable("DB_PATH") ?? "data/courses.db";
var connectionString = $"Data Source={dbPath}";

builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlite(connectionString));

// Service registration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```

**Key Configuration Decisions**:

- Environment-based database path configuration
- Automatic migration application on startup
- Swagger enabled in all environments for API documentation
- Static file serving for frontend assets
- Container-aware URL binding

### 5.2 Environment Configuration

- **Development**: Full error pages, HTTPS redirection disabled in containers
- **Production**: Optimized logging, security headers
- **Container**: Dynamic port binding, external database path

## 6. Deployment Strategy

### 6.1 Local Development

```bash
dotnet run
# Application available at https://localhost:5001 or http://localhost:5000
```

### 6.2 Docker Deployment

```bash
# Build and run with Docker Compose
docker-compose up --build

# Access application at http://localhost:5003
```

### 6.3 Production Deployment Considerations

#### Database:

- Consider migrating to PostgreSQL or SQL Server for production
- Implement connection pooling
- Set up database backups and monitoring

#### Security:

- Implement authentication and authorization
- Add rate limiting to prevent abuse
- Configure HTTPS certificates
- Set up CORS policies for frontend integration

#### Scalability:

- Add Redis for caching frequently accessed data
- Implement database connection pooling
- Consider read replicas for high-traffic scenarios
- Add logging and monitoring (e.g., Application Insights, Serilog)

#### Performance:

- Add response caching for static course data
- Implement pagination for large result sets
- Add database indexing for search columns
- Consider search optimization (e.g., Elasticsearch integration)

## 7. API Documentation and Testing

### 7.1 Swagger Integration

The application includes comprehensive API documentation through Swagger/OpenAPI:

- Interactive API explorer at `/swagger`
- Complete endpoint documentation
- Request/response examples
- Parameter validation documentation

### 7.2 Testing Strategy

Recommended testing approaches:

#### Unit Tests:

- Controller action testing
- Service layer testing
- Model validation testing

#### Integration Tests:

- End-to-end API testing
- Database integration testing
- Docker container testing

#### Performance Tests:

- Load testing for concurrent users
- Database query performance testing
- Memory usage optimization

## 8. Future Enhancements and Recommendations

### 8.1 Immediate Improvements

#### Enhanced Search Functionality:

- Implement full-text search capabilities
- Add fuzzy search for typo tolerance
- Include advanced filtering options (price range, duration range)
- Add sorting options (price, duration, alphabetical)

#### User Experience:

- Add pagination for large result sets
- Implement search suggestions/autocomplete
- Add course comparison functionality
- Create detailed course view pages

### 8.2 Technical Enhancements

#### Performance Optimization:

- Implement caching strategies (Redis, in-memory caching)
- Add database indexing for search columns
- Optimize database queries with query analysis
- Implement response compression

#### Monitoring and Observability:

- Add structured logging with Serilog
- Implement health checks
- Add application performance monitoring
- Create dashboards for key metrics

#### Security:

- Implement API authentication (JWT tokens)
- Add input validation and sanitization
- Configure rate limiting
- Add security headers (CORS, CSP, HSTS)

### 8.3 Microservice Integration

#### Service Discovery:

- Integrate with service registry (Consul, Eureka)
- Implement circuit breaker patterns
- Add retry policies for external service calls

#### Event-Driven Architecture:

- Implement event publishing for course updates
- Add message queuing (RabbitMQ, Apache Kafka)
- Create event sourcing for audit trails

#### API Gateway Integration:

- Configure reverse proxy routing
- Implement centralized authentication
- Add request/response transformation

### 8.4 Data Management

#### Advanced Database Features:

- Implement soft deletes for courses
- Add audit logging for data changes
- Create data archiving strategies
- Implement multi-tenant support

#### Data Synchronization:

- Add external data source integration
- Implement scheduled data updates
- Create data validation pipelines
- Add conflict resolution strategies

## 9. Conclusion

The CourseSearch microservice successfully demonstrates modern web application development practices using the .NET ecosystem. The implementation provides a solid foundation for a production-ready course search system with the following key achievements:

### Technical Accomplishments:

- **Clean Architecture**: Well-separated concerns with clear layer boundaries
- **Modern Stack**: Utilizes current .NET 8.0 and Entity Framework Core 9.0
- **Container Ready**: Full Docker support with multi-stage builds
- **API-First Design**: RESTful endpoints with comprehensive documentation
- **Responsive Frontend**: Modern JavaScript with fetch API integration

### Business Value:

- **Comprehensive Search**: Multi-criteria search across diverse course categories
- **User-Friendly Interface**: Intuitive web interface with real-time search
- **Scalable Architecture**: Microservice design ready for enterprise integration
- **Maintainable Codebase**: Clean code practices with clear documentation

### Development Best Practices:

- **Database Migrations**: Version-controlled schema changes
- **Environment Configuration**: Flexible deployment across environments
- **Error Handling**: Comprehensive error management and user feedback
- **Security Considerations**: XSS protection and input validation

The CourseSearch microservice provides an excellent foundation for further development and demonstrates the effective application of modern web development technologies in creating maintainable, scalable, and user-focused applications.

---

**Report Generated**: September 30, 2025  
**Technology Stack**: .NET 8.0, ASP.NET Core, Entity Framework Core 9.0, SQLite, Docker  
**Project Type**: Microservice Architecture  
**Development Status**: Complete with recommendations for enhancement
