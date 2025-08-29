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
   docker pull saesminerais/coingecko-image
   ```

2. Run the container:
   ```bash
   docker run -d -p 8080:8080 -e "ConnectionString=Server=your_server;Database=CoinGecko;User Id=your_user;Password=your_password;TrustServerCertificate=True;" saesminerais/coingecko-image
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
   ConnectionString=your_connection_string_here
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

## Roadmap

The following features and improvements are planned for future releases:

- **Authentication & Authorization**
  - Implement JWT-based authentication
  - Add role-based access control
  - Secure sensitive endpoints

- **Unit Testing**
  - Add unit tests for service layer
  - Implement integration tests for API endpoints
  - Setup CI pipeline for automated testing

- **Performance & Usability**
  - Add caching layer to reduce API calls
  - Implement rate limiting
  - Create better error handling and logging

- **New Features**
  - Cryptocurrency price alerts
  - Historical data visualization endpoints
  - Export data to various formats

Contributions in any of these areas are welcome!

---

# Integra��o com a API CoinGecko (pt-BR)

Uma Web API em .NET 8 que integra com a API CoinGecko para buscar e armazenar dados de criptomoedas.

## Vis�o Geral do Projeto

Esta aplica��o fornece endpoints para recuperar informa��es de criptomoedas da CoinGecko e armazenar dados hist�ricos de pre�os. Segue uma abordagem de arquitetura limpa com camadas separadas para dom�nio, aplica��o, infraestrutura e API.

### Principais Funcionalidades

- Buscar dados de criptomoedas da API CoinGecko
- Armazenar dados hist�ricos de pre�os de criptomoedas
- Consultar estat�sticas hist�ricas de criptomoedas
- Obter lista de criptomoedas dispon�veis e moedas suportadas
- Suporte � pagina��o para grandes conjuntos de dados
- Migra��es autom�ticas de banco de dados na inicializa��o

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI para documenta��o
- Padr�o de Arquitetura Limpa (Clean Architecture)
- Conteineriza��o com Docker

## Arquitetura

A solu��o segue os princ�pios de Arquitetura Limpa e est� organizada nos seguintes projetos:

- **Domain**: Cont�m entidades, interfaces e l�gica de neg�cios
- **Application**: Cont�m implementa��es de servi�os e DTOs
- **Infrastructure**: Cont�m integra��o com APIs externas, reposit�rios e contexto de banco de dados
- **API**: Cont�m controladores e configura��o da API

## Documenta��o da API

A API � documentada usando Swagger/OpenAPI. Ao executar a aplica��o, voc� pode acessar a interface do Swagger no URL raiz.

### Endpoints Dispon�veis

- `GET /api/crypto/coins`: Obt�m uma lista paginada de criptomoedas dispon�veis
- `GET /api/crypto/currencies`: Obt�m uma lista paginada de moedas suportadas
- `GET /api/crypto/prices`: Obt�m informa��es de pre�o atual para uma criptomoeda espec�fica
- `GET /api/crypto/prices/history`: Obt�m estat�sticas hist�ricas de pre�os para uma criptomoeda espec�fica

## Executando a Aplica��o

### Usando Docker

1. Baixe a imagem do Docker Hub:
   ```bash
   docker pull saesminerais/coingecko-image
   ```

2. Execute o container:
   ```bash
   docker run -d -p 8080:8080 -e "ConnectionString=Server=seu_servidor;Database=CoinGecko;User Id=seu_usuario;Password=sua_senha;TrustServerCertificate=True;" saesminerais/coingecko-image
   ```

   Substitua os valores da string de conex�o com as informa��es reais do seu banco de dados. A aplica��o aplicar� automaticamente quaisquer migra��es pendentes de banco de dados na inicializa��o.

3. Acesse a API:
   Uma vez que o container esteja em execu��o, voc� pode acessar a API em `http://localhost:8080` e a documenta��o Swagger em `http://localhost:8080/swagger`.

### Pr�-requisitos (para desenvolvimento local)

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 ou IDE similar

### Configura��o Local

1. Clone este reposit�rio
2. Crie um arquivo `.env` no diret�rio raiz com as seguintes vari�veis:
   ```
   ConnectionString=sua_string_de_conexao_aqui
   ```
3. Restaure os pacotes: `dotnet restore`
4. Execute a aplica��o: `dotnet run --project API`
   - Observa��o: N�o � mais necess�rio aplicar migra��es manualmente, pois a aplica��o aplica migra��es automaticamente na inicializa��o

## Documenta��o da API de Terceiros

Este projeto integra-se com a API CoinGecko. Para mais informa��es sobre a API, visite:
[Documenta��o da API CoinGecko](https://docs.coingecko.com/v3.0.1/reference/introduction)

## Contribuindo

1. Fa�a um fork do reposit�rio
2. Crie um novo branch: `git checkout -b feature/nome-da-sua-feature`
3. Fa�a suas altera��es
4. Envie um pull request

## Roadmap

As seguintes funcionalidades e melhorias est�o planejadas para vers�es futuras:

- **Autentica��o e Autoriza��o**
  - Implementar autentica��o baseada em JWT
  - Adicionar controle de acesso baseado em fun��o
  - Proteger endpoints sens�veis

- **Teste de Unidade**
  - Adicionar testes de unidade para a camada de servi�o
  - Implementar testes de integra��o para endpoints da API
  - Configurar pipeline CI para testes automatizados

- **Desempenho e Usabilidade**
  - Adicionar camada de cache para reduzir chamadas � API
  - Implementar limita��o de taxa
  - Criar melhor tratamento de erro e registro de logs

- **Novas Funcionalidades**
  - Alertas de pre�o de criptomoedas
  - Endpoints de visualiza��o de dados hist�ricos
  - Exportar dados para v�rios formatos

Contribui��es em qualquer uma dessas �reas s�o bem-vindas!
