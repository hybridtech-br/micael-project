# ADR-012 — Adotar o HYBRID Engineering Standard em repositório corporativo

## Status

Accepted

## Contexto

O Programa MICAEL definiu padrões de arquitetura, segurança, APIs, dados, documentação, qualidade e operação que também são relevantes para outros produtos da HYBRID Tecnologia Inteligente.

Manter esses padrões exclusivamente dentro do `micael-project` criaria dois riscos:

1. acoplar normas corporativas ao domínio MICAEL;
2. incentivar cópias divergentes nos demais produtos.

Ao mesmo tempo, os produtos da HYBRID possuem domínios e arquiteturas independentes. Em especial, o HYBRID Home Assistant não pertence à família MICAEL e não deve compartilhar com ela autenticação, bancos, APIs de negócio, infraestrutura ou componentes específicos.

## Decisão

Será criado o repositório corporativo `hybridtech-br/hybrid-standards` como fonte oficial do HYBRID Engineering Standard (HES), templates e decisões transversais.

O `micael-project` continuará responsável por governança, roadmap e decisões próprias do Programa MICAEL. O `micael-book` será responsável pela documentação viva da família MICAEL.

Os produtos deverão referenciar o HES, sem copiar integralmente seu conteúdo normativo.

## Regras

- o HES não conterá regras de negócio de produtos;
- cada produto mantém dados, autenticação, infraestrutura, configuração e releases independentes, salvo ADR específico;
- padrões corporativos evoluem por RFC e ADR no `hybrid-standards`;
- padrões específicos do MICAEL permanecem no `micael-project` ou no `micael-book`;
- integração entre produtos ocorre somente por contratos públicos versionados;
- conteúdo transitório deste repositório será removido ou reduzido a referências após a migração.

## Alternativas consideradas

### Manter todos os padrões no `micael-project`

Rejeitada porque transforma um repositório de programa em fonte corporativa e aumenta o acoplamento entre produtos.

### Duplicar os padrões em cada produto

Rejeitada por gerar divergência, manutenção duplicada e decisões conflitantes.

### Criar imediatamente uma plataforma compartilhada de código

Rejeitada neste momento. A padronização documental não implica compartilhamento automático de código, autenticação, bancos ou infraestrutura.

## Consequências positivas

- fonte única para padrões corporativos;
- separação clara entre governança da empresa e domínio MICAEL;
- onboarding e auditoria mais simples;
- menor duplicidade documental;
- evolução independente dos produtos.

## Consequências e riscos

- mais um repositório para manter;
- necessidade de política clara de propriedade e revisão;
- risco de o HES se tornar excessivamente genérico ou burocrático;
- necessidade de links e versões explícitas entre padrões e produtos.

## Mitigações

- baseline pequena e incremental;
- padrões proporcionais ao risco;
- automação de validação documental;
- revisão periódica de regras sem uso prático;
- adoção gradual pelos produtos.

## Referências

- `docs/00-governanca/HYBRID_ENGINEERING_STANDARD.md`
- `docs/00-governanca/HYBRID_STANDARDS_BOOTSTRAP.md`
- `docs/00-governanca/REPOSITORY_PORTFOLIO.md`
- Issue #14 — criação do `micael-book`
