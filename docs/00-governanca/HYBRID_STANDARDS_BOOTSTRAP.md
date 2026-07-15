# Bootstrap do repositório `hybrid-standards`

**Status:** aprovado para execução após merge da governança inicial  
**Origem:** Project ATLAS / MICAEL Sprint 0.5

## 1. Propósito

Criar a fonte corporativa de padrões de engenharia da HYBRID Tecnologia Inteligente, separando normas reutilizáveis da documentação específica dos produtos.

## 2. Fronteiras

O repositório deve conter somente padrões corporativos, templates e decisões de alcance transversal.

Não deve conter:

- requisitos funcionais do MICAEL;
- arquitetura interna do HYBRID Home Assistant;
- regras do Starlink Tracker;
- código de produção de qualquer produto;
- segredos, dados reais ou configurações de clientes.

## 3. Estrutura inicial

```text
hybrid-standards/
├── README.md
├── GOVERNANCE.md
├── CONTRIBUTING.md
├── CHANGELOG.md
├── hea/
├── hes/
│   ├── README.md
│   ├── architecture.md
│   ├── development.md
│   ├── api-events.md
│   ├── data.md
│   ├── security-privacy.md
│   ├── ai-governance.md
│   ├── testing-quality.md
│   ├── devsecops-release.md
│   ├── observability-operations.md
│   └── documentation.md
├── adr/
│   ├── README.md
│   └── template.md
├── rfc/
│   ├── README.md
│   └── template.md
├── templates/
│   ├── feature-specification.md
│   ├── api-specification.md
│   ├── threat-model.md
│   └── operational-readiness.md
└── glossary/
    └── README.md
```

## 4. Conteúdo da primeira release

A versão `0.1.0` deve entregar:

- README e escopo corporativo;
- processo RFC -> ADR;
- HES baseline;
- templates de ADR, RFC, especificação de feature e threat model;
- política de versionamento e depreciação;
- validação automática de Markdown e links;
- CODEOWNERS e template de Pull Request;
- changelog inicial.

## 5. Migração do conteúdo transitório

Após a criação de `hybrid-standards`:

1. copiar o HES corporativo deste repositório;
2. adaptar referências específicas do MICAEL para exemplos não normativos;
3. manter no `micael-project` apenas um link e o registro histórico;
4. não duplicar o conteúdo normativo entre os dois repositórios;
5. registrar futuras alterações somente na fonte corporativa.

## 6. Critérios de aceite

- repositório independente criado sob `hybridtech-br`;
- branch padrão `main`;
- primeira release documental validada no CI;
- nenhuma regra de negócio de produto presente;
- governança e responsáveis documentados;
- MICAEL referencia o HES sem copiar sua definição integral;
- links e Markdown validados automaticamente.

## 7. Sequência recomendada

1. concluir e mesclar a PR de governança do `micael-project`;
2. criar `hybridtech-br/hybrid-standards`;
3. publicar a baseline `0.1.0`;
4. criar `hybridtech-br/micael-book` conforme a issue correspondente;
5. migrar a documentação viva do MICAEL;
6. iniciar os repositórios de produto apenas quando suas fronteiras e contratos estiverem aprovados.
