# ADR-011 — Estratégia Multi-Repositório

- Status: Aceito
- Data: 2026-07-14
- Responsável: MICAEL Architecture Board

## Contexto

O ecossistema MICAEL contém produtos com domínios, ciclos de implantação, requisitos operacionais e perfis de segurança distintos. Um monorepositório aumentaria o acoplamento de releases, permissões e pipelines.

## Decisão

Cada produto será mantido em repositório independente. `micael-project` será o repositório de governança e `micael-book` a fonte documental oficial.

## Consequências positivas

- releases, pipelines e permissões independentes;
- fronteiras de domínio explícitas;
- menor risco de dependência acidental;
- desenvolvimento paralelo;
- possibilidade de comercialização modular.

## Restrições

- nenhum produto pode referenciar código interno de outro produto;
- compartilhamento permitido somente por pacotes públicos do `micael-platform-sdk`;
- contratos devem usar Semantic Versioning;
- integrações operacionais passam pelo MICAEL Connect;
- migrações de banco nunca são compartilhadas.

## Exceções

Qualquer exceção exige novo ADR aprovado pelo Architecture Board.