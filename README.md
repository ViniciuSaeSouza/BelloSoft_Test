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
- Automatic database migrations on startup

## Technologies Used

- .NET 8
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI for documentation
- Clean Architecture pattern
- Docker containerization

## Architecture

The solution follows Clean Architecture principles and is organized into the following projects:

- **Domain**: Contains entities, interfaces, and business logic
- **Application**: Contains service implementations and DTOs
- **Infrastructure**: Contains external API integration, repositories, and database context
- **API**: Contains controllers and API configuration

## API Documentation

The API is documented using Swagger/OpenAPI. When running the application, you can access the Swagger UI at the root URL.

### Available Endpoints

- `GET /api/crypto/coins`: Get a paginated list of available cryptocurrencies
- `GET /api/crypto/currencies`: Get a paginated list of supported currencies
- `GET /api/crypto/prices`: Get current price information for a specific cryptocurrency
- `GET /api/crypto/prices/history`: Get historical price statistics for a specific cryptocurrency

## Running the Application

### Using Docker

1. Pull the image from Docker Hub:
   ```bash
   docker pull saesminerais/coingecko-api
   ```

2. Run the container:
   ```bash
   docker run -d -p 8080:8080 -e "ConnectionString__SQLServer=Server=your_server;Database=CoinGecko;User Id=your_user;Password=your_password;TrustServerCertificate=True;" saesminerais/coingecko-api
   ```

   Replace the connection string values with your actual database information. The application will automatically apply any pending database migrations on startup.

3. Access the API:
   Once the container is running, you can access the API at `http://localhost:8080` and the Swagger documentation at `http://localhost:8080/swagger`.


### Prerequisites (for local development)

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or similar IDE

### Local Configuration

1. Clone this repository
2. Create a `.env` file in the root directory with the following variables:
   ```
   ConnectionString__SQLServer=your_connection_string_here
   ```
3. Restore packages: `dotnet restore`
4. Run the application: `dotnet run --project API`
   - Note: Manual migration is no longer needed as the application automatically applies migrations on startup

## Third-Party API Documentation

This project integrates with the CoinGecko API. For more information about the API, visit:
[CoinGecko API Documentation](https://docs.coingecko.com/v3.0.1/reference/introduction)

## Contributing

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Make your changes
4. Submit a pull request

---

# Integração com a API CoinGecko (pt-BR)

Uma Web API em .NET 8 que integra com a API CoinGecko para buscar e armazenar dados de criptomoedas.

## Visão Geral do Projeto

Esta aplicação fornece endpoints para recuperar informações de criptomoedas da CoinGecko e armazenar dados históricos de preços. Segue uma abordagem de arquitetura limpa com camadas separadas para domínio, aplicação, infraestrutura e API.

### Principais Funcionalidades

- Buscar dados de criptomoedas da API CoinGecko
- Armazenar dados históricos de preços de criptomoedas
- Consultar estatísticas históricas de criptomoedas
- Obter lista de criptomoedas disponíveis e moedas suportadas
- Suporte à paginação para grandes conjuntos de dados
- Migrações automáticas de banco de dados na inicialização

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI para documentação
- Padrão de Arquitetura Limpa (Clean Architecture)
- Conteinerização com Docker

## Arquitetura

A solução segue os princípios de Arquitetura Limpa e está organizada nos seguintes projetos:

- **Domain**: Contém entidades, interfaces e lógica de negócios
- **Application**: Contém implementações de serviços e DTOs
- **Infrastructure**: Contém integração com APIs externas, repositórios e contexto de banco de dados
- **API**: Contém controladores e configuração da API

## Documentação da API

A API é documentada usando Swagger/OpenAPI. Ao executar a aplicação, você pode acessar a interface do Swagger no URL raiz.

### Endpoints Disponíveis

- `GET /api/crypto/coins`: Obtém uma lista paginada de criptomoedas disponíveis
- `GET /api/crypto/currencies`: Obtém uma lista paginada de moedas suportadas
- `GET /api/crypto/prices`: Obtém informações de preço atual para uma criptomoeda específica
- `GET /api/crypto/prices/history`: Obtém estatísticas históricas de preços para uma criptomoeda específica

## Executando a Aplicação

### Usando Docker

1. Baixe a imagem do Docker Hub:
   ```bash
   docker pull saesminerais/coingecko-api
   ```

2. Execute o container:
   ```bash
   docker run -d -p 8080:8080 -e "ConnectionString__SQLServer=Server=seu_servidor;Database=CoinGecko;User Id=seu_usuario;Password=sua_senha;TrustServerCertificate=True;" saesminerais/coingecko-api
   ```

   Substitua os valores da string de conexão com as informações reais do seu banco de dados. A aplicação aplicará automaticamente quaisquer migrações pendentes de banco de dados na inicialização.

3. Acesse a API:
   Uma vez que o container esteja em execução, você pode acessar a API em `http://localhost:8080` e a documentação Swagger em `http://localhost:8080/swagger`.

### Pré-requisitos (para desenvolvimento local)

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 ou IDE similar

### Configuração Local

1. Clone este repositório
2. Crie um arquivo `.env` no diretório raiz com as seguintes variáveis:
   ```
   ConnectionString__SQLServer=sua_string_de_conexao_aqui
   ```
3. Restaure os pacotes: `dotnet restore`
4. Execute a aplicação: `dotnet run --project API`
   - Observação: Não é mais necessário aplicar migrações manualmente, pois a aplicação aplica migrações automaticamente na inicialização

## Documentação da API de Terceiros

Este projeto integra-se com a API CoinGecko. Para mais informações sobre a API, visite:
[Documentação da API CoinGecko](https://docs.coingecko.com/v3.0.1/reference/introduction)

## Contribuindo

1. Faça um fork do repositório
2. Crie um novo branch: `git checkout -b feature/nome-da-sua-feature`
3. Faça suas alterações
4. Envie um pull request
