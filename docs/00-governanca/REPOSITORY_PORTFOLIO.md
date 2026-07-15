# Portfólio Oficial de Repositórios MICAEL

## Governança corporativa

- `hybrid-standards`: padrões corporativos da HYBRID para arquitetura, engenharia, segurança, dados, APIs, IA, UX, DevSecOps e documentação.

## Governança e documentação MICAEL

- `micael-project`: governança, roadmap, backlog transversal e ADRs específicos do Programa MICAEL.
- `micael-book`: documentação oficial e livros vivos da família MICAEL.

## Fundação

- `micael-platform`: serviços comuns neutros da família MICAEL.
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

## Regras de fronteira

1. Cada repositório de produto possui domínio, persistência, autenticação, configuração, CI/CD, observabilidade e versionamento independentes.
2. Dependências entre produtos devem ocorrer somente por artefatos públicos versionados do SDK ou por integração via MICAEL Connect.
3. `hybrid-standards` não contém regras de negócio, requisitos funcionais nem documentação específica de produto.
4. `micael-book` não redefine padrões corporativos; referencia as normas publicadas em `hybrid-standards`.
5. O HYBRID Home Assistant permanece fora da família MICAEL e não compartilha bancos, autenticação, APIs de negócio, bibliotecas ou infraestrutura específica com seus produtos.

## Ordem de criação e migração

1. `hybrid-standards`
2. `micael-book`
3. `micael-platform-sdk`
4. `micael-platform`
5. `micael-condo`
6. `micael-connect`
7. `micael-security`
8. `micael-command-center`
9. demais produtos e ferramentas

O repositório atual permanece como registro histórico, governança e coordenação do Programa MICAEL. Os padrões corporativos provisórios permanecem aqui somente até a criação e publicação do `hybrid-standards`.