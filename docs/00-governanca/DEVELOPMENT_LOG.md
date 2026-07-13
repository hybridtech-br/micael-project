# Diário de Desenvolvimento — Projeto MICAEL

## 2026-07-13 — Sprint 01 / Fundação v0.2

### Objetivo

Substituir a base experimental por uma fundação ASP.NET Core 8 e PostgreSQL pronta para evolução incremental.

### Entregas

- Solution com separação Api, Application, Domain e Infrastructure.
- Entidade `Tenant` com identificador, nome, slug único, estado e data de criação.
- EF Core 8 com Npgsql, `MicaelDbContext` e migration `InitialCreate`.
- API mínima com health check, informações do sistema, Swagger e Problem Details.
- logging JSON estruturado no console.
- testes xUnit unitários e de integração.
- Dockerfile multi-stage e Compose com PostgreSQL 16.
- documentação de build, testes, migrations e execução no PowerShell.

### Decisões de arquitetura

- O domínio permanece independente de infraestrutura e host HTTP.
- Migrations ficam no projeto Infrastructure e podem ser aplicadas na inicialização por configuração.
- O health check inicial mede a disponibilidade do processo; a prontidão do PostgreSQL é controlada pelo Compose antes de iniciar a API.
- Configurações sensíveis são substituíveis por variáveis de ambiente e não há segredos de produção no repositório.

### Validação

- `dotnet restore backend/Micael.sln`.
- `dotnet build backend/Micael.sln --configuration Release`.
- `dotnet test backend/Micael.sln --configuration Release`.
- `docker compose config`.
- endpoints `/health` e `/api/v1/system/info`.

### Limitação do ambiente de execução

- A execução integral do Compose exige Docker Desktop com WSL 2 ou outro daemon de containers Linux ativo no Windows.

## 2026-07-13 — Versão 0.1

### Objetivo

Criar a fundação documental e uma primeira versão executável de demonstração do MICAEL.

### Entregas

- Roadmap inicial.
- SRS inicial.
- Arquitetura inicial.
- MVP em Node.js sem dependências externas.
- Dashboard com totais.
- Cadastro de moradores.
- Cadastro de visitantes.
- Cadastro de veículos.
- Registro de botão de pânico.
- Persistência em arquivo JSON.
- Dockerfile e instruções para Windows.

### Decisões de arquitetura

- O MVP Node.js é uma prova de conceito e não será a arquitetura final.
- A plataforma definitiva será organizada em MICAEL Platform, MICAEL Condo e MICAEL Security.
- A evolução deverá preservar separação por módulos, segurança por padrão e suporte multi-tenant.

### Limitações conhecidas

- Sem autenticação segura.
- Sem RBAC.
- Sem PostgreSQL.
- Sem isolamento por condomínio.
- Sem reconhecimento facial e leitura de placas.
- Sem integração com câmeras e controladoras.

## Planejamento da versão 0.2

### Objetivo

Construir a fundação técnica definitiva do MICAEL.

### Escopo planejado

- ASP.NET Core.
- PostgreSQL.
- Entity Framework Core.
- Autenticação JWT.
- RBAC.
- Multi-tenant.
- Auditoria.
- Cadastro de condomínios, blocos, unidades, moradores, visitantes e veículos.
- API OpenAPI/Swagger.
- Docker Compose.
- Frontend React com TypeScript.

### Critério de conclusão

A versão 0.2 será considerada concluída quando um administrador conseguir autenticar-se, criar um condomínio, cadastrar unidades, moradores, visitantes e veículos, com dados persistidos no PostgreSQL e isolamento básico por tenant.
