# Diário de Desenvolvimento — Projeto MICAEL

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
