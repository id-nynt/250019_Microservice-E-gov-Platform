# ServiceUniverse � Guide

## Overview

- .NET 8 API Gateway proxies HTML UIs, static assets, forms, and APIs to microservices running in Docker.
- Public routes exposed by the gateway (hosted at `http://localhost:5000`):
  - Web UIs: `/ApiGateway/Courses`, `/ApiGateway/Tax`, `/ApiGateway/Vaccination`, `/ApiGateway/Tracking`
  - APIs (absolute, for UI JavaScript): `/api/courses`, `/api/courses/all`, `/api/tax`, `/api/tax/calculate`
- The gateway also rewrites relative paths inside HTML so your CSS/JS/images work without changing microservice code.

## What each microservice must keep

- Docker/container
  - Container name must match the gateway DNS name:
    - `coursesearch`, `taxcalculation`, `vaccination`, `tracking`
  - The app must listen on container port `80` (host port can be anything except available ones - 5000, 5003, 5004).
  - All services run on the same Docker network (universe-network).
- ASP.NET Core
  - UI at root `/` with `UseDefaultFiles()` and `UseStaticFiles()`.
  - Static files referenced relatively (e.g., `script.js`, `css/site.css`, not `/css/site.css`).
  - APIs under `/api/...` (examples below).
  - Swagger at `/swagger` (optional but recommended).
- API paths expected by the gateway/UI
  - CourseSearch: `GET /api/courses`, `GET /api/courses/all` (supports `keyword`, `location`, `area`, `studyOption`).
  - TaxCalculation: `POST /api/tax/calculate` (JSON body like `{ "income": 75000 }`).

## Example docker-compose service

```yaml
services:
  coursesearch:
    container_name: "coursesearch" # MUST MATCH ABOVE
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
      - universe-network # MUST MATCH

networks:
  universe-network: # MUST MATCH
    external: true
```

## Quick test: current stage

1. Docker Desktop

- Start Docker Desktop.
- Build network: `docker network create universe-network`

2. CourseSearch service

- Open VS Code window, open folder CourseSearch
- Build and run: `docker-compose up --build`
- UI: `http://localhost:5003/`
- Swagger: `http://localhost:5003/swagger/index.html`
- API checks:
  - `GET /api/courses?keyword=IT`
  - `GET /api/courses/all`
  - Try filters: `keyword`, `location`, `area`, `studyOption`.

3. TaxCalculation service

- Open VS Code window, open folder TaxCalculation
- Build and run: `docker-compose up --build`
- UI: `http://localhost:5004/`
- Swagger: `http://localhost:5004/swagger/index.html`
- API check:
  - `POST /api/tax/calculate` with JSON `{ "income": 75000 }`.

4. API Gateway

- Open VS Code window, open folder APIGateway
- Build and run: `docker-compose up --build`
- Open gateway UI: `http://localhost:5000/`.
- Swagger: `http://localhost:5004/swagger/index.html` or click the API Docs on top right corner.
- Click on service to interact or use links:
  - Course Search: `http://localhost:5000/ApiGateway/Courses`
  - Tax Calculator: `http://localhost:5000/ApiGateway/Tax`
- Interact with the UIs:
  - Course Search should call `/api/courses` or `/api/courses/all` and return results.
  - Tax Calculator should call `/api/tax` or `/api/tax/calculate` and return totals.

## Troubleshooting

- Plain HTML without styling/JS
  - Ensure microservice HTML references assets relatively (`style.css`, `app.js`).
- �No course found� when keyword exists
  - UI sends params (e.g., `keyword`, `location`, `area`, `studyOption`). The gateway now forwards the full query string unchanged.
  - Confirm the CourseSearch API parameter names match those.
- 404 for `/api/...` from the UI
  - The gateway exposes absolute `/api/*` routes. Make sure your UI calls `/api/...` (not the service URL).
- 502/connection errors
  - Verify container names and internal ports match `_serviceUrls`.
  - Ensure services are running: `docker ps`.

## Change the gateway if needed

- Only if a microservice uses a different container name, internal port, or API path.
- Update the dictionaries in `Controllers/ApiGatewayController.cs`:
  - `_serviceUrls` (container DNS + port 80)
  - `_publicRoutes` (display segment used to rewrite HTML paths)
- If API path differs (not `/api/courses` or `/api/tax/calculate`), add/adjust the absolute routes in the controller (e.g., `/api/your-endpoint`).

---

Short version

- Keep container name = gateway DNS (e.g., `coursesearch`).
- Keep container port = 80.
- Serve UI at `/`, static files relatively.
- Expose APIs at `/api/...`.
- Gateway entry point: `http://localhost:5000`.
- Web UI via gateway: `/ApiGateway/Courses`, `/ApiGateway/Tax`.
- APIs via gateway: `/api/courses`, `/api/courses/all`, `/api/tax`, `/api/tax/calculate`.
