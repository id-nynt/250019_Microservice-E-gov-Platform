# ServiceUniverse - Guide

## Overview

- .NET 8 API Gateway proxies HTML UIs, static assets, forms, and APIs to four microservices running in Docker.
- Public routes exposed by the gateway (hosted at `http://localhost:5000`):
  - Web UIs: `/ApiGateway/Courses`, `/ApiGateway/Tax`, `/ApiGateway/Parcels`, `/ApiGateway/Vaccination`
  - APIs (absolute, for UI JavaScript): `/api/courses`, `/api/tax/calculate`, `/api/parcels/{trackingNumber}`, `/vaccinationRecord?user={id}`
- The gateway also rewrites relative paths inside HTML so your CSS/JS/images work without changing microservice code.

## Microservices Architecture

### 1. CourseSearch Service (Port 5003)

- **Purpose**: V-Edu (Vocational Education) course search and discovery
- **Database**: SQLite with course catalog
- **Web UI**: Course search form with filters for keyword, location, area, and study options
- **API Endpoints**:
  - `GET /api/courses` - Search courses with query parameters

### 2. TaxCalculation Service (Port 5004)

- **Purpose**: Progressive tax calculation for Australian tax system
- **Features**: Configurable tax brackets, effective rate calculation
- **Web UI**: Tax calculator form with income input
- **API Endpoints**:
  - `POST /api/tax/calculate` - Calculate tax for given income

### 3. ParcelTracking Service (Port 5173)

- **Purpose**: Australia Post parcel tracking and status monitoring
- **Database**: SQLite with parcel tracking records
- **Features**: Track parcels by tracking number, view status and ETA
- **API Endpoints**:
  - `GET /api/parcels/{trackingNumber}` - Get parcel details by tracking number

### 4. Vaccination History Service (Port 5002)

- **Purpose**: View vaccination records for a valid user
- **Tech**: Python Flask + PostgreSQL
- **Web UI**: Static HTML served from `wwwroot` (root path `/`)
- **API Endpoints**:
  - `GET /vaccinationRecord?user={userId}` - Returns vaccination records for a user
  - Root UI: `GET /` (index.html)

## Docker Configuration Requirements

### Container Specifications

- **Container names** must match the gateway DNS names:
  - `coursesearch` - CourseSearch service
  - `taxcalculation` - TaxCalculation service
  - `parceltracking-service` - ParcelTracking service
  - `vaccination` - Vaccination History service
- **Container port**: All services must listen on port `80`
- **Host ports**:
  - APIGateway: `5000:80`
  - CourseSearch: `5003:80`
  - TaxCalculation: `5004:80`
  - ParcelTracking: `5173:80`
  - Vaccination: `5002:5002` (Flask app listens on 5002)
- **Network**: All services run on `universe-network`

### ASP.NET Core Requirements

- UI at root `/` with `UseDefaultFiles()` and `UseStaticFiles()`
- Static files referenced relatively (e.g., `script.js`, `style.css`)
- APIs under `/api/...` namespace
- Swagger at `/swagger` (recommended)

### API Contracts Expected by Gateway

- **CourseSearch**:
  - `GET /api/courses` - Supports query parameters: `keyword`, `location`, `area`, `studyOption`
  - Returns array of course objects with properties: `CourseName`, `CourseCode`, `Location`, `CourseArea`, `StudyOption`
- **TaxCalculation**:
  - `POST /api/tax/calculate` - Expects JSON: `{ "income": 75000 }`
  - Returns: `{ "income": 75000, "tax": 12345.67, "effectiveRate": 0.1646 }`
- **ParcelTracking**:
  - `GET /api/parcels/{trackingNumber}` - Returns parcel details
  - Returns: `{ "id": 1, "trackingNumber": "ABC123", "status": "In Transit", "location": "Sydney", "eta": "2024-01-15T10:00:00Z", "history": "[]" }`
- **Vaccination History**:
  - `GET /vaccinationRecord?user={userId}` - Returns records for a user or error JSON
  - Success: `{ "records": [{ "type": "COVID-19", "date": "2023-11-10" }, ...] }`
  - Errors: `{ "error": "No User ID Provided" }` (400), `{ "error": "User Not Found" }` (404), `{ "error": "Records Not Found For That User" }` (404)

## Docker Compose Configuration

### API Gateway compose.yml

```yaml
services:
  apigateway:
    container_name: "apigateway"
    build:
      context: .
      dockerfile: ./Dockerfile
    ports:
      - 5000:80
    networks:
      - universe-network

networks:
  universe-network:
    external: true
```

## Quick Start Guide

### Prerequisites

- Docker Desktop running

### Setup Steps

1. **Create Docker Network**

   ```bash
   docker network create universe-network
   ```

2. **Run API Gateway and Microservices**

- Open Docker Desktop
- Open all microservices and API gateway in separate VS Code windows and run in the terminal:

  ```bash
  docker-compose up --build
  ```

- Check Docker Desktop if all services and API gateway are running

3. **Access Services**

   **Via API Gateway (Primary Access Points):**

   - **Main Portal**: http://localhost:5000

- **Course Search**: http://localhost:5000/ApiGateway/Courses
- **Tax Calculator**: http://localhost:5000/ApiGateway/Tax
- **Parcel Tracking**: http://localhost:5000/ApiGateway/Parcels
- **Vaccination History**: http://localhost:5000/ApiGateway/Vaccination

  **Direct Service Access (Development/Testing):**

- **CourseSearch**: http://localhost:5003
- **TaxCalculation**: http://localhost:5004
- **ParcelTracking**: http://localhost:5173
- **Vaccination History**: http://localhost:5002

### API Testing

1. **Via Webpage**

- Click on Swagger button in each page to direct to the coresponding Swagger API.

2. **Via Links**

- **Main Portal**: http://localhost:5000/swagger/index.html
- **Course Search**: http://localhost:5003/swagger/index.html
- **Tax Calculator**: http://localhost:5004/swagger/index.html
- **Parcel Tracking**: http://localhost:5173/swagger/index.html
- (Vaccination History uses a simple HTML page and JSON API, no Swagger by default)

### Development Commands

```bash
# Clean restart all services
docker-compose down
docker-compose up --build

# Start services
docker-compose up

# Remove network and recreate
docker network rm universe-network
docker network create universe-network
```

- Tip: refresh the webpage after each build

## Architecture Summary

**Key Components:**

- **APIGateway (Port 5000)**: Central routing hub, service aggregation, unified UI
- **CourseSearch (Port 5003)**: V-Edu course catalog with search functionality
- **TaxCalculation (Port 5004)**: Progressive tax calculation engine
- **ParcelTracking (Port 5173)**: Australia Post parcel tracking system
- **Vaccination History (Port 5002)**: Vaccination records lookup (Flask + Postgres)

**Container Communication:**

- All services communicate via `universe-network`
- Service discovery uses container names (`coursesearch`, `taxcalculation`, `parceltracking-service`, `vaccination`)
- Internal communication on port 80, external access via mapped host ports

**Access Patterns:**

- **Production**: All access via APIGateway (`http://localhost:5000/ApiGateway/...`)
- **Development**: Direct service access for testing (`http://localhost:5003`, etc.)
- **API Integration**: RESTful APIs accessible via gateway (`/api/courses`, `/api/tax/calculate`, `/api/parcels/{id}`, `/vaccinationRecord`)

---

## Architecture Decisions and Integration

This section summarizes the architectural choices for how services interact and communicate.

### Interaction Model: Synchronous vs Asynchronous

- Synchronous (request/response) via API Gateway:
  - Used for user-facing flows where immediate feedback is required (Course search, Tax calculation, Parcel lookup, Vaccination UI/API).
  - Implemented today using HTTP calls from the API Gateway to each service.
- Asynchronous (event-driven/background):
  - Recommended for long-running workflows, eventual consistency, or cross-service side effects (e.g., emit an event when a parcel status changes, or cache course indexes).
  - Can be added later with a message broker without changing public APIs.

### Communication Path: Direct vs Message Broker

- Direct HTTP via API Gateway (current):
  - All client traffic enters through the gateway; the gateway forwards to services using container DNS names.
  - Pros: Simple, predictable latency, centralized policies (auth, rate limits) possible.
  - Cons: Tight coupling for cross-service chains if overused.

### Workflow Style

- Orchestration (current, via API Gateway or a dedicated coordinator):
  - Suitable for request/response user journeys that span multiple services.
  - One place can apply retries, timeouts, and map errors to a good UX.

### Service Design Principles

- Stateless processing:
  - Each service keeps computation stateless; persistent data lives in its own database (SQLite for CourseSearch, Postgres for Vaccination, etc.).
  - Statelessness enables horizontal scaling and container restarts without session loss.
- Single responsibility and small scope:
  - Each service focuses on one capability (search courses, calculate tax, track parcels, show vaccination records).
- Resilience and reliability (apply at gateway and services):
  - Timeouts on outbound calls (e.g., 2–5s), retry with exponential backoff for transient errors, and circuit breakers to shed load.
  - Use correlation IDs for tracing across services; log request IDs and latencies.
- API contracts:
  - JSON schemas for requests/responses; version via URL or accept headers when contracts evolve.

## Quick Reference

- **Gateway entry point**: `http://localhost:5000`
- **Web UIs via gateway**: `/ApiGateway/Courses`, `/ApiGateway/Tax`, `/ApiGateway/Parcels`, `/ApiGateway/Vaccination`
- **APIs via gateway**: `/api/courses`, `/api/tax/calculate`, `/api/parcels/{trackingNumber}`, `/vaccinationRecord?user={id}`
- **Container names**: `coursesearch`, `taxcalculation`, `tracking`, `vaccination`, `apigateway`
- **Network**: `universe-network` (external, must be created first)
