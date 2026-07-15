# MICAEL Engineering Governance

Empresa mantenedora: **HYBRID Tecnologia Inteligente**  
Site: **https://www.hybridtech.com.br**

## Papel deste repositório

`micael-project` é o repositório de governança do programa MICAEL. Ele concentra roadmap, decisões arquiteturais, catálogo de eventos, backlog transversal e coordenação entre produtos. Código de produção deve residir nos repositórios específicos de cada produto.

## Princípios obrigatórios

- Produtos independentes, com bancos, autenticação, APIs e releases próprios.
- Integração somente por contratos públicos, APIs versionadas e eventos.
- Edge First, Offline First, API First, Plugin First e Event Driven.
- Security by Design, Privacy by Design e LGPD by Design.
- Nenhum compartilhamento direto de banco, storage ou componentes internos entre Condo, Security, Connect e Command Center.

## Fluxo de trabalho

- `main`: linha estável de governança.
- `agent/*`, `feature/*`, `docs/*`: alterações propostas.
- Pull Requests obrigatórios para mudanças estruturais.
- Conventional Commits.
- Semantic Versioning por produto.

## Definition of Ready

Uma tarefa pode iniciar quando possui objetivo, critérios de aceitação, dependências, riscos e impacto arquitetural identificados.

## Definition of Done

Uma tarefa termina somente com implementação ou artefato concluído, validação, testes quando aplicáveis, documentação, changelog e Pull Request revisável.

## Autoridade

Mudanças estruturais exigem ADR. Decisões técnicas locais podem ser executadas pela MICAEL Factory desde que respeitem os ADRs aprovados.