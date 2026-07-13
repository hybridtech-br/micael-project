# MICAEL

Plataforma para gestão condominial, segurança eletrônica e controle de acesso. A fundação técnica v0.2 usa ASP.NET Core 8, Entity Framework Core e PostgreSQL, com uma arquitetura inicial preparada para multi-tenant e auditoria futura.

## Estrutura

- `backend/`: API e camadas definitivas em .NET 8.
- `backend/src/Micael.Domain`: entidades e regras de domínio.
- `backend/src/Micael.Application`: casos de uso e contratos da aplicação.
- `backend/src/Micael.Infrastructure`: persistência PostgreSQL, EF Core e migrations.
- `backend/src/Micael.Api`: host HTTP, Swagger, health check e Problem Details.
- `backend/tests/`: testes unitários e de integração.
- `apps/mvp-node/`: prova de conceito legada, mantida apenas como referência.
- `docs/`: requisitos, arquitetura, roadmap e governança.

## Início rápido com Docker

Pré-requisitos: Docker Desktop com suporte a containers Linux e Docker Compose.

```powershell
git checkout agent/v0.2-foundation
docker compose config
docker compose up -d --build
```

Valide no PowerShell:

```powershell
Invoke-RestMethod http://localhost:8080/health
Invoke-RestMethod http://localhost:8080/api/v1/system/info
Start-Process http://localhost:8080/swagger
```

Para acompanhar e encerrar:

```powershell
docker compose logs -f micael-api
docker compose down
```

O Compose usa `micael_dev_only` apenas para desenvolvimento local. Nunca reutilize essa senha em produção; forneça segredos por variáveis de ambiente ou por um gerenciador de segredos.

## Desenvolvimento sem Docker

Instale o SDK .NET 8 e disponibilize PostgreSQL em `localhost:5432`. Na raiz do repositório, execute:

```powershell
dotnet restore backend/Micael.sln
dotnet build backend/Micael.sln --configuration Release
dotnet test backend/Micael.sln --configuration Release
$env:ASPNETCORE_ENVIRONMENT = "Development"
dotnet run --project backend/src/Micael.Api/Micael.Api.csproj
```

A connection string pode ser sobrescrita sem alterar arquivos:

```powershell
$env:ConnectionStrings__MicaelDatabase = "Host=localhost;Port=5432;Database=micael;Username=micael;Password=<senha-local>"
```

Consulte [backend/README.md](backend/README.md) para arquitetura, migrations e comandos adicionais.

## Endpoints iniciais

- `GET /health`: estado do processo da API.
- `GET /api/v1/system/info`: nome, versão e ambiente.
- `/swagger`: documentação interativa disponível em `Development`.

## Segurança e privacidade

Esta sprint não inclui dados pessoais reais, biometria, reconhecimento facial ou segredos de produção. O isolamento por tenant, autenticação e auditoria serão evoluídos em sprints posteriores.
