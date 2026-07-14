# Codex Handoff — Separação do Ecossistema MICAEL

## Objetivo

Transformar o repositório atual em ponto de origem da migração para produtos independentes:

- `hybridtech-br/micael-platform-sdk`
- `hybridtech-br/micael-connect`
- `hybridtech-br/micael-condo`
- `hybridtech-br/micael-security`
- `hybridtech-br/micael-installer`
- `hybridtech-br/micael-updater`
- `hybridtech-br/micael-docs`

## Princípios obrigatórios

1. Condo e Security são aplicações independentes.
2. Cada produto possui banco, autenticação, configuração, storage, migrations e ciclo de release próprios.
3. Nenhum produto acessa diretamente banco, filesystem, secrets ou serviços internos de outro produto.
4. Integração somente por contratos públicos versionados, HTTPS, eventos e pareamento seguro.
5. O Platform SDK contém