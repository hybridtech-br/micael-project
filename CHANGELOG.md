# Changelog

Todas as mudanças relevantes do projeto MICAEL são registradas neste arquivo. O projeto adota versionamento semântico para software e versionamento incremental para documentação.

## [0.2.0] - 2026-07-13

### Adicionado

- Solution .NET 8 com projetos Api, Application, Domain e Infrastructure.
- Projetos xUnit para testes unitários e de integração.
- Entidade multi-tenant inicial `Tenant`.
- `MicaelDbContext`, provider Npgsql e migration `InitialCreate` para PostgreSQL.
- Endpoints `GET /health` e `GET /api/v1/system/info`.
- Swagger/OpenAPI em desenvolvimento.
- tratamento global de exceções com Problem Details e logs JSON estruturados.
- Dockerfile multi-stage e Docker Compose com API e PostgreSQL.
- documentação de desenvolvimento e execução no Windows PowerShell.

### Alterado

- A fundação definitiva passa do MVP Node.js para ASP.NET Core; o MVP permanece como referência histórica.

### Segurança

- Configuração sensível pode ser substituída por variáveis de ambiente.
- Nenhum segredo real, dado pessoal ou biometria foi incluído.

## [0.1.0] - 2026-07-13

### Adicionado

- Inicialização oficial do repositório.
- Definição dos produtos MICAEL Condo, MICAEL Security e MICAEL Core.
- Estrutura inicial de documentação.
- Roadmap macro do projeto.
- Base da Especificação de Requisitos de Software (SRS).
- Diretrizes iniciais de arquitetura e governança.
