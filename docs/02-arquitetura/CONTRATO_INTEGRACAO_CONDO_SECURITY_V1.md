# Contrato de Integração Micael Condo ↔ Micael Security — v1

## Objetivo

Definir o contrato inicial para integração segura entre duas aplicações independentes instaladas na mesma rede local.

## Princípios

- bancos de dados separados;
- autenticação separada;
- nenhum acesso direto ao banco do outro produto;
- comunicação somente por HTTPS;
- pareamento explícito por administrador;
- funcionamento offline com fila local;
- contratos versionados;
- idempotência e auditoria em todos os eventos.

## Identidade da instalação

Cada instalação deve possuir:

- `installationId` (UUID);
- `product` (`micael-condo` ou `micael-security`);
- `version`;
- `displayName`;
- `baseUrl`;
- certificado público;
- status de pareamento.

## Pareamento

1. Security gera código temporário e QR Code.
2. Condo informa o código ou lê o QR Code.
3. Os sistemas validam endereço, produto, versão mínima e certificado.
4. É criado um vínculo de confiança máquina a máquina.
5. O pareamento recebe escopos mínimos necessários.
6. Toda ação é auditada.

## Escopos iniciais

### Condo concedidos ao Security

- `condo.people.read`
- `condo.visitors.read`
- `condo.vehicles.read`
- `condo.units.read`

### Security concedidos ao Condo

- `security.access-events.read`
- `security.alerts.read`
- `security.panic.write`
- `security.connection-status.read`

## Cabeçalhos obrigatórios

- `Authorization: Bearer <token>`
- `X-Micael-Installation-Id`
- `X-Micael-Event-Id`
- `X-Micael-Correlation-Id`
- `X-Micael-Contract-Version: 1`

## Envelope de evento

```json
{
  "eventId": "uuid",
  "eventType": "VisitorAuthorized",
  "contractVersion": 1,
  "occurredAt": "2026-07-14T15:00:00Z",
  "sourceInstallationId": "uuid",
  "tenantIntegrationId": "uuid",
  "correlationId": "uuid",
  "payload": {}
}
```

## Eventos Condo → Security

- `ResidentCreated`
- `ResidentUpdated`
- `ResidentDeactivated`
- `VisitorAuthorized`
- `VisitorUpdated`
- `VisitorCancelled`
- `VehicleCreated`
- `VehicleUpdated`
- `VehicleBlocked`
- `AccessPermissionChanged`
- `PanicTriggered`

## Eventos Security → Condo

- `PersonRecognized`
- `PersonNotRecognized`
- `PlateRecognized`
- `AccessGranted`
- `AccessDenied`
- `VisitorEntered`
- `VisitorExited`
- `VehicleEntered`
- `VehicleExited`
- `PanicAcknowledged`
- `CameraOffline`
- `DeviceOffline`

## Endpoints mínimos

### Comuns

- `GET /api/integration/v1/health`
- `GET /api/integration/v1/info`
- `POST /api/integration/v1/pairing/request`
- `POST /api/integration/v1/pairing/confirm`
- `POST /api/integration/v1/pairing/revoke`
- `POST /api/integration/v1/events`
- `GET /api/integration/v1/events/pending`
- `POST /api/integration/v1/reconciliation/start`

## Regras de entrega

- `eventId` único;
- consumidor idempotente;
- reenvio com backoff exponencial;
- fila de mensagens não enviadas;
- confirmação explícita de processamento;
- dead-letter queue local após o limite de tentativas;
- reconciliação periódica por identificador de integração.

## Segurança

- TLS obrigatório;
- mTLS recomendado após o primeiro pareamento;
- token máquina a máquina com curta duração;
- rotação de credenciais;
- allowlist de IP opcional;
- revogação imediata;
- proteção contra replay;
- registro de auditoria;
- sem vetores biométricos no Condo.

## LGPD

O Security é o responsável técnico pelos dados biométricos e eventos de reconhecimento. O Condo deve receber apenas dados necessários à finalidade administrativa e resultados de acesso, salvo autorização explícita e política definida.

## Compatibilidade

Mudanças incompatíveis exigem nova versão do contrato. As versões devem coexistir durante janela de migração definida.