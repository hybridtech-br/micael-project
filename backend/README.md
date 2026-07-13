# Backend MICAEL

Fundação ASP.NET Core 8 do MICAEL v0.2.

## Projetos

```text
backend/
├── Micael.sln
├── src/
│   ├── Micael.Api/
│   ├── Micael.Application/
│   ├── Micael.Domain/
│   └── Micael.Infrastructure/
└── tests/
    ├── Micael.UnitTests/
    └── Micael.IntegrationTests/
```

As dependências apontam para dentro: API usa Application e Infrastructure; Infrastructure usa Application e Domain; Application usa Domain. Domain não depende das demais camadas.

## Configuração

A configuração base está em `src/Micael.Api/appsettings.json`; valores de desenvolvimento ficam em `appsettings.Development.json`. Variáveis de ambiente substituem qualquer chave usando `__` como separador, por exemplo:

```powershell
$env:ConnectionStrings__MicaelDatabase = "Host=localhost;Port=5432;Database=micael;Username=micael;Password=<senha-local>"
$env:Database__ApplyMigrations = "true"
```

Não faça commit de credenciais reais. A senha `micael_dev_only` existe somente para facilitar o Compose local.

## Compilar e testar no Windows PowerShell

```powershell
dotnet restore backend/Micael.sln
dotnet build backend/Micael.sln --configuration Release
dotnet test backend/Micael.sln --configuration Release
```

## Executar a API

Com PostgreSQL disponível e a connection string configurada:

```powershell
$env:ASPNETCORE_ENVIRONMENT = "Development"
dotnet run --project backend/src/Micael.Api/Micael.Api.csproj
```

O ambiente `Development` habilita Swagger e a aplicação automática das migrations. Em outros ambientes, migrations são aplicadas somente quando `Database__ApplyMigrations=true`.

## Migrations

Instale a ferramenta na versão 8 se necessário e execute da raiz do repositório:

```powershell
dotnet tool install --global dotnet-ef --version 8.*
dotnet ef migrations add NomeDaMigration `
  --project backend/src/Micael.Infrastructure/Micael.Infrastructure.csproj `
  --startup-project backend/src/Micael.Api/Micael.Api.csproj `
  --output-dir Persistence/Migrations

dotnet ef database update `
  --project backend/src/Micael.Infrastructure/Micael.Infrastructure.csproj `
  --startup-project backend/src/Micael.Api/Micael.Api.csproj
```

A migration inicial `InitialCreate` cria a tabela `tenants` e um índice único para `slug`.

## Respostas de erro e logs

Exceções não tratadas são convertidas para RFC 7807 Problem Details com `traceId`. Os logs são emitidos no console em JSON estruturado e não devem conter segredos nem dados pessoais.
