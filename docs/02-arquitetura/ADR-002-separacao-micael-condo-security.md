# ADR-002 — Separação entre Micael Condo e Micael Security

## Status

Aceito.

## Decisão

Micael Condo e Micael Security serão produtos independentes, instaláveis separadamente, com bancos de dados, autenticação, APIs, versões, ciclos de implantação e observabilidade próprios.

Quando instalados na mesma rede, poderão ser conectados por uma integração opcional e segura chamada **Micael Link**.

## Produtos

### Micael Condo

Responsável por administração condominial: condomínios, blocos, unidades, moradores, visitantes, veículos, mensagens, reservas, correspondências, chamados e botão de pânico.

### Micael Security

Responsável por câmeras, gravações, IA de vídeo, reconhecimento facial, leitura de placas, controle de acesso, eventos, alertas, portas, portões e catracas.

### Micael Link

Responsável por descoberta, pareamento, autenticação máquina a máquina, sincronização, retries, reconciliação, auditoria e telemetria da integração.

## Regras obrigatórias

1. Nenhum produto acessará diretamente o banco de dados do outro.
2. Não haverá tabelas, migrations, credenciais administrativas ou arquivos internos compartilhados.
3. A comunicação ocorrerá por HTTPS, contratos versionados e eventos assíncronos.
4. Cada produto continuará operacional quando o outro estiver offline.
5. Toda mensagem terá `eventId`, `eventType`, `occurredAt`, `sourceInstallationId`, `tenantId`, `correlationId`, `schemaVersion` e `payload`.
6. Eventos serão idempotentes e armazenados em uma Outbox transacional.
7. Dados biométricos permanecerão no Micael Security. O Condo receberá apenas resultados e referências.

## Topologia local

```text
Micael Condo                     Micael Security
Condo API                        Security API
Condo PostgreSQL                 Security PostgreSQL
Condo Integration Agent  <---->  Security Integration Agent
        HTTPS + mTLS + eventos versionados
```

## Descoberta e pareamento

A primeira versão usará configuração por IP ou DNS local e código temporário de pareamento. QR Code poderá encapsular endereço, installationId, chave pública e código temporário.

A descoberta automática por mDNS/DNS-SD será opcional e nunca autorizará conexão sem confirmação administrativa.

## Segurança

- HTTPS obrigatório;
- mTLS após o pareamento;
- tokens de serviço de curta duração;
- permissões por escopo;
- rotação e revogação de certificados;
- proteção contra replay;
- rate limiting;
- allowlist de IP opcional;
- auditoria de conexão, sincronização e comandos críticos.

Escopos iniciais:

```text
condo.people.read
condo.visitors.read
condo.vehicles.read
security.access.write
security.events.read
security.panic.receive
```

## Contrato de evento inicial

```json
{
  "eventId": "uuid",
  "eventType": "VisitorAuthorized",
  "occurredAt": "2026-07-14T15:00:00Z",
  "sourceInstallationId": "uuid",
  "tenantId": "uuid",
  "correlationId": "uuid",
  "schemaVersion": 1,
  "payload": {}
}
```

## Eventos Condo → Security

- ResidentCreated
- ResidentUpdated
- ResidentDeactivated
- VisitorAuthorized
- VisitorCancelled
- VehicleCreated
- VehicleUpdated
- VehicleBlocked
- AccessPermissionChanged
- PanicTriggered

## Eventos Security → Condo

- PersonRecognized
- PersonNotRecognized
- PlateRecognized
- AccessGranted
- AccessDenied
- VisitorEntered
- VisitorExited
- VehicleEntered
- VehicleExited
- PanicAcknowledged
- CameraOffline
- DeviceOffline

## Resiliência

Cada produto manterá:

- `IntegrationOutbox` para eventos a enviar;
- `IntegrationInbox` para deduplicação;
- retries com backoff exponencial;
- dead-letter para falhas permanentes;
- rotina de reconciliação;
- status da conexão e última sincronização.

## Estrutura de repositório desejada

```text
apps/
  micael-condo/
  micael-security/
  micael-link-contracts/

deploy/
  condo/
  security/

docs/
  contracts/
```

Os contratos compartilhados serão apenas especificações versionadas, como OpenAPI, AsyncAPI e JSON Schema. Não serão compartilhadas bibliotecas de domínio nem infraestrutura interna.

## Critérios de aceitação arquiteturais

- Condo inicia e opera sem Security.
- Security inicia e opera sem Condo.
- Os dois usam bancos distintos.
- Pareamento pode ser criado e revogado.
- Eventos offline são reenviados após reconexão.
- Eventos duplicados não geram efeitos duplicados.
- Biometria não é replicada para o Condo.
- Todos os fluxos de integração são auditáveis.
