# BelloSoft_Test

Este projeto � uma Web API desenvolvida em .NET 8 que integra com a API p�blica da CoinGecko para fornecer dados sobre criptomoedas. O objetivo � demonstrar boas pr�ticas de desenvolvimento, integra��o com APIs externas e uso de tecnologias modernas.

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Swagger/OpenAPI
- Docker

## Funcionalidades

- Consulta de informa��es sobre criptomoedas usando a CoinGecko API.
- Endpoints RESTful para acesso aos dados.
- Documenta��o autom�tica dos endpoints via Swagger.
- Persist�ncia de dados com SQL Server (configur�vel via string de conex�o).

## Como Executar

### Pr�-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/) (opcional)
- SQL Server (local ou remoto)

### Configura��o

1. Clone o reposit�rio:
```sh
git clone https://github.com/ViniciuSaeSouza/BelloSoft_Test.git
```

2. Configure a string de conex�o do banco de dados no ambiente de uma das formas abaixo:

**Op��o 1: Vari�vel de ambiente em application_properties.json**
```
ConnectionString__SQLServer=Server=...;Database=...;User Id=...;Password=...
```

**Op��o 2: Arquivo .env**
Crie um arquivo chamado `.env` na pasta API do projeto e adicione ao .env:
```
ConnectionString__SQLServer=Server=...;Database=...;User Id=...;Password=...
```

3. Restaure os pacotes e execute as migra��es (se necess�rio).

```sh 
dotnet restore
```

#### Migrations (Entity Framework Core)

Para criar uma nova migration pelo Package Manager Console do Visual Studio:
```powershell
Add-Migration NomeDaMigration -Project Infrastructure -StartupProject CoinGecko/API
```

Para aplicar as migrations e atualizar o banco de dados:
```powershell
Update-Database NomdeDaMigration
```

Certifique-se de que o pacote `Microsoft.EntityFrameworkCore.Tools` est� instalado e que o projeto correto est� selecionado no Visual Studio.

### Executando Localmente

```sh
dotnet run --project CoinGecko/API/API.csproj
```

Acesse a documenta��o Swagger em: `https://localhost:8080/swagger`

### Executando com Docker

```sh
docker build -t bellosoft_test_api -f CoinGecko/API/Dockerfile .
docker run -p 8080:8080 bellosoft_test_api
```

## Documenta��o da API

A API CoinGecko utilizada est� documentada em:  
[https://docs.coingecko.com/v3.0.1/reference/introduction](https://docs.coingecko.com/v3.0.1/reference/introduction)

A documenta��o dos endpoints da sua API estar� dispon�vel via Swagger ap�s iniciar o projeto.

## Estrutura do Projeto

- `CoinGecko/API`: Projeto principal da Web API
- `Infrastructure`: Camada de persist�ncia e reposit�rios

## Contribui��o

Pull requests s�o bem-vindos! Para grandes mudan�as, abra uma issue primeiro para discutir o que voc� gostaria de modificar.

## Licen�a

Este projeto est� sob a licen�a MIT.
