# HYBRID Engineering Standard (HES)

**Versão:** 1.0.0-draft  
**Status:** Baseline proposta  
**Programa responsável:** Project ATLAS

## 1. Objetivo

O HYBRID Engineering Standard estabelece os princípios e requisitos mínimos de arquitetura, desenvolvimento, segurança, qualidade, documentação e operação aplicáveis aos produtos da HYBRID Tecnologia Inteligente.

O HES é corporativo. Ele não contém regras de negócio do MICAEL, do HYBRID Home Assistant, do Starlink Tracker ou de qualquer outro produto.

## 2. Escopo

O padrão abrange:

- arquitetura de software e de soluções;
- desenvolvimento e revisão de código;
- APIs e eventos;
- persistência e migrações;
- segurança e privacidade;
- inteligência artificial;
- testes e qualidade;
- CI/CD e releases;
- observabilidade e operação;
- documentação e decisões arquiteturais.

## 3. Princípios obrigatórios

### HES-EP-001 — Domínios independentes

Cada produto é dono exclusivo de suas regras, dados, autenticação, configuração, infraestrutura e ciclo de release, salvo decisão arquitetural explícita registrada em ADR.

### HES-EP-002 — Integração por contratos

Integrações entre produtos ocorrem somente por APIs, eventos, webhooks ou pacotes públicos versionados. Acesso direto ao banco, storage ou código interno de outro produto é proibido.

### HES-EP-003 — Documentação como parte da entrega

Uma funcionalidade não está concluída sem documentação, critérios de aceite, testes e atualização do changelog quando aplicável.

### HES-EP-004 — Segurança e privacidade desde o desenho

Toda mudança deve avaliar autenticação, autorização, segregação, proteção de dados, auditoria, retenção e riscos de abuso.

### HES-EP-005 — Observabilidade desde o desenho

Serviços devem produzir logs estruturados, métricas e traces adequados ao seu nível de criticidade, sem expor segredos ou dados pessoais indevidos.

### HES-EP-006 — Automação e reprodutibilidade

Builds, testes, migrações e implantações devem ser automatizáveis e reproduzíveis. Configurações específicas de ambiente não devem ser incorporadas ao código-fonte.

### HES-EP-007 — Compatibilidade controlada

APIs, eventos, schemas e pacotes públicos devem possuir versionamento e política de depreciação. Mudanças incompatíveis exigem versão principal ou estratégia de transição documentada.

### HES-EP-008 — Decisões rastreáveis

Decisões arquiteturais relevantes devem ser registradas em ADR. Propostas com impacto amplo devem começar por RFC.

### HES-EP-009 — Qualidade baseada em risco

Testes e controles devem refletir a criticidade da funcionalidade. Fluxos de autenticação, autorização, controle de acesso, biometria e auditoria exigem cobertura reforçada.

### HES-EP-010 — Simplicidade evolutiva

A solução mais simples que preserve os limites do domínio, a segurança e a capacidade de evolução deve ser preferida. Microsserviços, mensageria e infraestrutura complexa não são adotados sem necessidade comprovada.

## 4. Quality Gate mínimo

Uma entrega deve, conforme aplicável:

- compilar sem erros;
- passar por testes automatizados;
- não introduzir vulnerabilidades críticas conhecidas;
- preservar isolamento entre produtos e tenants;
- possuir revisão de código;
- atualizar documentação e contratos;
- registrar migration para mudanças persistentes;
- possuir telemetria e auditoria nos fluxos críticos;
- documentar impactos e rollback.

## 5. Governança

O Project ATLAS mantém o HES. Alterações seguem o fluxo:

```text
Proposta -> RFC -> revisão -> ADR -> atualização do HES -> adoção pelos produtos
```

Padrões corporativos não devem ser redefinidos dentro de repositórios de produto. Produtos podem complementar o HES com regras locais, desde que não o contradigam.

## 6. Relação com o ecossistema MICAEL

O MICAEL é o primeiro programa a adotar formalmente o HES. MICAEL Condo, MICAEL Security e MICAEL AI permanecem produtos independentes, comunicando-se exclusivamente por contratos públicos versionados.

O HYBRID Home Assistant não pertence à família MICAEL e não compartilha com ela bancos, autenticação, APIs de negócio, infraestrutura ou componentes específicos.

## 7. Próximos volumes

A baseline será detalhada nos seguintes padrões:

1. Architecture Standard;
2. Development Standard;
3. API and Event Standard;
4. Data Standard;
5. Security and Privacy Standard;
6. AI Governance Standard;
7. Testing and Quality Standard;
8. DevSecOps and Release Standard;
9. Observability and Operations Standard;
10. Documentation Standard.
