# Codex Handoff — Sprint 01 / MICAEL v0.2

## Objetivo

Implementar a fundação definitiva do MICAEL na branch `agent/v0.2-foundation`, substituindo gradualmente o MVP Node.js por uma base ASP.NET Core + PostgreSQL pronta para evolução.

## Repositório

- Repositório: `hybridtech-br/micael-project`
- Branch de trabalho: `agent/v0.2-foundation`
- Issue principal: `#2 — Criar fundação ASP.NET Core e PostgreSQL`

## Escopo obrigatório

### Backend

Criar a solution e os projetos:

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

### Tecnologias

- .NET 8 LTS
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Npgsql
- Swagger/OpenAPI
- Health Checks
- Docker e Docker Compose
- xUnit

## Requisitos técnicos

1. A solution deve compilar sem erros.
2. A API deve iniciar em ambiente de desenvolvimento.
3. Criar endpoint `GET /health`.
4. Disponibilizar Swagger em desenvolvimento.
5. Configuração por `appsettings.json`, `appsettings.Development.json` e variáveis de ambiente.
6. Criar `MicaelDbContext` no projeto Infrastructure.
7. Criar uma entidade inicial `Tenant` com:
   - `Id` (Guid)
   - `Name`
   - `Slug`
   - `IsActive`
   - `CreatedAt`
8. Criar migration inicial.
9. Configurar PostgreSQL no Docker Compose.
10. Adicionar tratamento global de exceções e Problem Details.
11. Adicionar logging estruturado básico.
12. Não adicionar segredos reais ao repositório.

## Docker Compose

O `docker-compose.yml` deve subir:

- `micael-api`
- `micael-postgres`

Portas sugeridas:

- API: `8080`
- PostgreSQL: `5432`

Variáveis de ambiente esperadas:

```text
POSTGRES_DB=micael
POSTGRES_USER=micael
POSTGRES_PASSWORD=micael_dev_only
```

A senha acima é apenas para desenvolvimento local e deve ser documentada como não apropriada para produção.

## Endpoints iniciais

### `GET /health`

Resposta esperada:

```json
{
  "status": "Healthy"
}
```

### `GET /api/v1/system/info`

Resposta esperada:

```json
{
  "name": "MICAEL",
  "version": "0.2.0",
  "environment": "Development"
}
```

## Testes mínimos

- teste unitário para criação válida de `Tenant`;
- teste de integração para `GET /health`;
- teste de integração para `GET /api/v1/system/info`.

## Comandos de validação

Executar e corrigir até todos passarem:

```bash
dotnet restore backend/Micael.sln
dotnet build backend/Micael.sln --configuration Release
dotnet test backend/Micael.sln --configuration Release
docker compose config
docker compose up -d --build
```

Depois validar:

```bash
curl http://localhost:8080/health
curl http://localhost:8080/api/v1/system/info
```

## Documentação obrigatória

Atualizar ou criar:

- `README.md`
- `backend/README.md`
- `CHANGELOG.md`
- `docs/00-governanca/DEVELOPMENT_LOG.md`

Incluir instruções específicas para Windows PowerShell.

## Segurança e privacidade

- sem credenciais reais;
- sem dados pessoais reais;
- sem biometria nesta sprint;
- usar parâmetros e variáveis de ambiente para dados sensíveis;
- preparar a arquitetura para multi-tenant e auditoria futura.

## Critérios de aceitação finais

- [ ] Solution compila.
- [ ] Testes passam.
- [ ] Docker Compose sobe API e PostgreSQL.
- [ ] `/health` responde com sucesso.
- [ ] Swagger funciona em desenvolvimento.
- [ ] Migration inicial existe.
- [ ] Documentação para Windows foi atualizada.
- [ ] Pull Request rascunho aberto para `main`.
- [ ] PR referencia a issue `#2`.

## Orientação para o Codex

Trabalhe diretamente na branch `agent/v0.2-foundation`. Faça alterações completas e coerentes, execute os comandos de validação e corrija os erros antes de concluir. Ao final, faça commit, push e abra um Pull Request rascunho para `main` com resumo técnico, validações executadas, riscos e próximos passos.