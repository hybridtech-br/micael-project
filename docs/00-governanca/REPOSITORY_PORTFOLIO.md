# Portfólio Oficial de Repositórios MICAEL

## Governança e documentação

- `micael-project`: governança, roadmap, backlog transversal e ADRs.
- `micael-book`: documentação oficial e livros vivos.

## Fundação

- `micael-platform`: serviços comuns neutros.
- `micael-platform-sdk`: contratos públicos, eventos e SDKs.

## Produtos

- `micael-condo`
- `micael-security`
- `micael-connect`
- `micael-command-center`
- `micael-automation`
- `micael-ai`
- `micael-cloud`

## Aplicativos

- `micael-mobile-condo`
- `micael-mobile-security`

## Ferramentas e operação

- `micael-installer`
- `micael-updater`
- `micael-devops`

## Regra de fronteira

Cada repositório de produto possui domínio, persistência, autenticação, configuração, CI/CD, observabilidade e versionamento independentes. Dependências entre produtos devem ocorrer somente por artefatos públicos versionados do SDK ou por integração via MICAEL Connect.

## Ordem de criação e migração

1. `micael-book`
2. `micael-platform-sdk`
3. `micael-platform`
4. `micael-condo`
5. `micael-connect`
6. `micael-security`
7. `micael-command-center`
8. demais produtos e ferramentas

O repositório atual permanece como registro histórico e coordenação do programa.