# Catálogo de Eventos MICAEL v1

## Envelope padrão

```json
{
  "eventId": "uuid",
  "eventType": "ResidentCreated",
  "eventVersion": "1.0",
  "source": "micael-condo",
  "tenantId": "uuid",
  "installationId": "uuid",
  "occurredAt": "2026-07-14T13:00:00Z",
  "correlationId": "uuid",
  "payload": {}
}
```

## Regras

- `eventId` globalmente único.
- Consumidores devem ser idempotentes.
- `eventVersion` segue Semantic Versioning.
- Dados pessoais devem ser minimizados.
- Biometria bruta não deve circular no barramento geral.
- Eventos devem ser persistidos via Transactional Outbox antes da publicação.

## Condo

- ResidentCreated
- ResidentUpdated
- ResidentDeactivated
- VisitorAuthorized
- VisitorCancelled
- VisitorEntered
- VisitorExited
- VehicleRegistered
- VehicleUpdated
- PanicTriggered

## Security

- FaceRecognized
- PlateRecognized
- AccessGranted
- AccessDenied
- DoorForced
- CameraOnline
- CameraOffline
- DeviceOnline
- DeviceOffline
- AlarmTriggered

## Connect

- ProductPaired
- ProductUnpaired
- SiteConnected
- SiteDisconnected
- SynchronizationStarted
- SynchronizationCompleted
- SynchronizationFailed

## Command Center

- IncidentCreated
- IncidentAssigned
- IncidentAcknowledged
- IncidentEscalated
- IncidentClosed
- SiteOnline
- SiteOffline

## Evolução

Mudanças incompatíveis exigem nova versão major do evento. Campos opcionais podem ser adicionados em versões minor, preservando consumidores existentes.