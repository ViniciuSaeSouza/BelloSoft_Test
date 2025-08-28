# CoinGecko API Integration

A .NET 8 Web API that integrates with the CoinGecko API to fetch and store cryptocurrency data.

## Project Overview

This application provides endpoints for retrieving cryptocurrency information from CoinGecko and storing historical price data. It follows a clean architecture approach with separate layers for domain, application, infrastructure, and API.

### Key Features

- Fetch cryptocurrency data from CoinGecko API
- Store historical cryptocurrency price data
- Query historical cryptocurrency statistics
- Get list of available cryptocurrencies and supported currencies
- Pagination support for large data sets

## Technologies Used

- .NET 8
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI for documentation
- Clean Architecture pattern

## Architecture

The solution follows Clean Architecture principles and is organized into the following projects:

- **Domain**: Contains entities, interfaces, and business logic
- **Application**: Contains service implementations and DTOs
- **Infrastructure**: Contains external API integration, repositories, and database context
- **API**: Contains controllers and API configuration

## API Documentation

The API is documented using Swagger/OpenAPI. When running the application in development mode, you can access the Swagger UI at the root URL.

### Available Endpoints

- `GET /api/crypto/coins`: Get a paginated list of available cryptocurrencies
- `GET /api/crypto/currencies`: Get a paginated list of supported currencies
- `GET /api/crypto/prices`: Get current price information for a specific cryptocurrency
- `GET /api/crypto/prices/history`: Get historical price statistics for a specific cryptocurrency

## Setup Instructions

### Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or similar IDE

### Configuration

1. Clone this repository
2. Create a `.env` file in the root directory with the following variables:
   ```
   ConnectionString__SQLServer=your_connection_string_here
   ```

### Running the Application

1. Navigate to the project directory
2. Restore packages: `dotnet restore`
3. Apply migrations: `dotnet ef database update --project Infrastructure --startup-project API`
4. Run the application: `dotnet run --project API`

## Third-Party API Documentation

This project integrates with the CoinGecko API. For more information about the API, visit:
[CoinGecko API Documentation](https://docs.coingecko.com/v3.0.1/reference/introduction)

## Contributing

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Make your changes
4. Submit a pull request
