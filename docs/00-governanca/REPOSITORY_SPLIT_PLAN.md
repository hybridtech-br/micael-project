# Plano de Separação de Repositórios — Ecossistema MICAEL

## Objetivo

Transformar o repositório atual `hybridtech-br/micael-project` em repositórios independentes por produto, preservando histórico, documentação e capacidade de execução.

## Repositórios-alvo

1. `hybridtech-br/micael-condo`
2. `hybridtech-br/micael-security`
3. `hybridtech-br/micael-connect`
4. `hybridtech-br/micael-platform-sdk`
5. `hybridtech-br/micael-docs`

## Responsabilidades

### micael-condo

- administração condominial;
- moradores, unidades, visitantes e veículos;
- mensagens, reservas e relatórios;
- API, Web, Mobile, PostgreSQL e storage próprios;
- publicação independente.

### micael-security

- câmeras e gravações;
- reconhecimento facial e leitura de placas;
- controle de acesso;
- IA, vídeo, API, Web, Mobile, PostgreSQL e storage próprios;
- publicação independente.

### micael-connect

- descoberta na rede;
- pareamento seguro;
- autenticação máquina a máquina;
- filas, retries, reconciliação e auditoria;
- contratos versionados de eventos e comandos.

### micael-platform-sdk

- contratos de integração;
- envelopes de eventos;
- bibliotecas cliente HTTP;
- tipos compartilhados estritamente técnicos;
- sem regras de negócio de Condo ou Security.

### micael-docs

- arquitetura;
- SRS;
- ADRs;
- documentação de implantação e operação;
- contratos públicos e histórico de versões.

## Regras obrigatórias

- nenhum produto acessa banco ou storage de outro;
- autenticação, configuração e releases independentes;
- comunicação somente por HTTPS e eventos versionados;
- cada produto deve funcionar sem os demais;
- dados biométricos permanecem no Security;
- Condo recebe somente resultados e eventos necessários;
- contratos devem ser retrocompatíveis durante a janela de suporte.

## Estratégia de migração

### Etapa 1 — Congelamento arquitetural

- manter a implementação atual no repositório `micael-project`;
- concluir e revisar o PR da fundação .NET;
- registrar este plano e o contrato de integração;
- impedir novas dependências diretas entre domínios.

### Etapa 2 — Criação dos repositórios

Criar os cinco repositórios privados na organização `hybridtech-br`, com branch `main`, proteção de branch, CODEOWNERS e templates padrão.

### Etapa 3 — Extração da fundação

- mover contratos técnicos para `micael-platform-sdk`;
- criar pipelines independentes;
- publicar pacotes versionados;
- manter o repositório atual como origem temporária até concluir a transição.

### Etapa 4 — Extração do Condo

- criar solution, banco e Compose próprios;
- mover entidades e casos de uso administrativos;
- implementar endpoints de integração com Connect;
- validar execução sem Security.

### Etapa 5 — Criação do Connect

- implementar pairing code;
- registrar instalações;
- criar outbox/inbox;
- enviar e receber eventos com idempotência;
- adicionar health, status e auditoria da integração.

### Etapa 6 — Extração do Security

- criar solution, banco e Compose próprios;
- implementar módulos iniciais de dispositivos, pessoas e acessos;
- consumir autorizações do Connect;
- publicar eventos de entrada, saída e alertas.

### Etapa 7 — Desativação do monorepo transitório

- tornar `micael-project` somente leitura ou convertê-lo em repositório índice;
- atualizar links e documentação;
- arquivar branches antigas após validação.

## Critérios de conclusão

- cada produto compila, testa e publica independentemente;
- Condo e Security iniciam isoladamente;
- Connect integra duas instalações na mesma rede;
- falha de um produto não impede a operação local do outro;
- eventos offline são reenviados sem duplicidade;
- documentação e versionamento estão alinhados.