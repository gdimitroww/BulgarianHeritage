# Bulgarian Heritage Tourism Guide

A comprehensive web application for exploring Bulgaria's rich cultural heritage, featuring interactive maps, virtual tours, and user-generated content.

## Features

- 🗺️ **Interactive Heritage Map** - Explore Bulgarian heritage sites with filtering capabilities
- 🏛️ **Heritage Site Catalog** - Browse detailed information about cultural landmarks
- 👤 **User Authentication** - Register and manage your heritage journey
- 📝 **User Contributions** - Add reviews, photos, and personal experiences
- 🎯 **Personalized Itineraries** - Create custom heritage tours
- 📱 **Responsive Design** - Works seamlessly on desktop and mobile devices

## Technology Stack

- **Backend**: ASP.NET Core 8.0
- **Database**: SQL Server 2022
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Maps**: Leaflet.js
- **Authentication**: ASP.NET Core Identity
- **Containerization**: Docker & Docker Compose

## Prerequisites

- Docker Desktop installed on your machine
- Git (to clone the repository)

## Quick Start with Docker

### 1. Clone the Repository
```bash
git clone <repository-url>
cd HeritageTourism
```

### 2. Build and Run with Docker Compose

#### First Time Setup (with Database Migration)
```bash
# Run the migration service to set up the database
docker-compose --profile setup up migration

# Start the application services
docker-compose up -d
```

#### Subsequent Runs
```bash
# Start all services
docker-compose up -d

# Or run in foreground to see logs
docker-compose up
```

### 3. Access the Application

- **Web Application**: http://localhost:5000
- **SQL Server**: localhost:1433 (if you need direct database access)
  - Username: `sa`
  - Password: `BulgarianHeritage123!`

### 4. Stop the Application
```bash
docker-compose down
```

### 5. Clean Up (Remove all data)
```bash
docker-compose down -v
docker system prune -f
```

## Docker Services

The application consists of three Docker services:

1. **sqlserver**: SQL Server 2022 database with persistent storage
2. **web**: The main ASP.NET Core web application
3. **migration**: One-time service to set up the database schema

## Development

### Local Development Setup

If you prefer to run the application locally for development:

1. **Install .NET 8 SDK**
2. **Install SQL Server** (or use Docker for SQL Server only)
3. **Update Connection String** in `appsettings.json`
4. **Run Migrations**:
   ```bash
   cd BulgarianHeritage
   dotnet ef database update
   ```
5. **Run the Application**:
   ```bash
   dotnet run
   ```

### Database Migrations

To create new migrations:
```bash
cd BulgarianHeritage
dotnet ef migrations add <MigrationName>
```

To update the database:
```bash
dotnet ef database update
```

## Project Structure

```
HeritageTourism/
├── BulgarianHeritage/           # Main ASP.NET Core application
│   ├── Controllers/             # MVC Controllers
│   ├── Models/                  # Data models and ViewModels
│   ├── Views/                   # Razor views
│   ├── Data/                    # Entity Framework DbContext
│   ├── Migrations/              # Database migrations
│   ├── wwwroot/                 # Static files (CSS, JS, images)
│   └── Program.cs               # Application entry point
├── docker-compose.yml           # Docker Compose configuration
└── README.md                    # This file
```

## Configuration

### Environment Variables

The application uses the following environment variables in Docker:

- `ASPNETCORE_ENVIRONMENT`: Set to `Development` or `Production`
- `ConnectionStrings__DefaultConnection`: Database connection string
- `ASPNETCORE_URLS`: URLs the application listens on

### Database Configuration

The SQL Server container uses:
- **Database**: BulgarianHeritageDb
- **Username**: sa
- **Password**: BulgarianHeritage123!
- **Port**: 1433

## Troubleshooting

### Common Issues

1. **Port Already in Use**
   ```bash
   # Check what's using port 5000
   lsof -i :5000
   # Kill the process or change the port in docker-compose.yml
   ```

2. **Database Connection Issues**
   ```bash
   # Check if SQL Server container is running
   docker ps
   # View SQL Server logs
   docker logs bulgarian-heritage-db
   ```

3. **Migration Errors**
   ```bash
   # Run migration manually
   docker-compose --profile setup up migration
   ```

4. **Application Won't Start**
   ```bash
   # View application logs
   docker logs bulgarian-heritage-web
   ```

### Resetting the Database

To completely reset the database:
```bash
docker-compose down -v
docker-compose --profile setup up migration
docker-compose up -d
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test with Docker
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For support and questions, please open an issue in the GitHub repository. 