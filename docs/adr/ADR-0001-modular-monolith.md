# ADR-0001 — Monólito modular para a fundação MICAEL

- **Status:** Aceita
- **Data:** 2026-07-22
- **Escopo:** MICAEL Platform, MICAEL Security, HYBRID Monitor e MICAEL Condo

## Contexto

A família MICAEL possui domínios relacionados, porém distintos: identidade, tenants, auditoria, câmeras, vídeo, reconhecimento facial, LPR, controle de acesso, eventos, investigação, monitoramento e gestão condominial. Adotar microsserviços desde a primeira versão aumentaria custo operacional, complexidade de deploy, observabilidade distribuída, versionamento de contratos e consistência de dados antes de existir demanda real de escala.

## Decisão

A fundação será implementada como um monólito modular em ASP.NET Core, com fronteiras de módulo explícitas e dependências controladas.

Cada módulo deve conter, quando aplicável:

- Domain
- Application
- Infrastructure
- API
- Contracts
- Tests

Módulos não podem acessar diretamente entidades ou persistência internas de outro módulo. Integrações internas devem ocorrer por contratos públicos, comandos, consultas ou eventos.

## Organização inicial

### Núcleo de plataforma

- Identity
- Tenant
- Authorization
- Audit
- Notification
- Files
- Configuration

### Prioridade 1 — MICAEL Security

- Devices
- Cameras
- Video
- Events
- Recognition
- LPR
- Access Control
- Investigation
- Automation

### Família MICAEL

- HYBRID Monitor integra-se nativamente à família MICAEL para observabilidade e saúde operacional.
- MICAEL Condo será evoluído após a estabilização do Security Core.
- HYBRID Home Assistant permanece uma linha de produto independente, sem compartilhamento obrigatório de autenticação, banco, serviços, bibliotecas ou infraestrutura.

## Persistência

A primeira fase usará PostgreSQL compartilhado com separação lógica por schema. Cada módulo é responsável por suas tabelas e migrations. O compartilhamento físico do banco não autoriza acesso direto ao schema de outro módulo.

## Comunicação

- Síncrona: interfaces e contratos públicos dentro do processo.
- Assíncrona: eventos internos inicialmente; RabbitMQ quando a integração precisar cruzar processos ou nós Edge.
- Tempo real: SignalR para dashboards e operação.

## Consequências positivas

- deploy inicial simples;
- menor custo operacional;
- testes e depuração mais diretos;
- fronteiras preparadas para extração futura;
- entrega mais rápida do MICAEL Security MVP.

## Riscos

- acoplamento indevido entre módulos;
- crescimento excessivo da solução;
- consultas cruzadas entre schemas;
- transformação do monólito modular em monólito acoplado.

## Controles obrigatórios

- testes de arquitetura;
- referências de projeto explícitas;
- contratos públicos versionados;
- proibição de acesso direto ao DbContext de outro módulo;
- ADR específico antes de extrair qualquer módulo para microsserviço.

## Critérios para futura extração

Um módulo só deve virar serviço independente quando houver pelo menos um dos seguintes fatores:

- necessidade comprovada de escala isolada;
- ciclo de deploy independente frequente;
- requisito de isolamento de falhas;
- tecnologia especializada incompatível com o host principal;
- operação Edge ou processamento intensivo de IA.
