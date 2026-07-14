# MICAEL Security Command Center

## Objetivo

Adicionar ao ecossistema MICAEL Security uma central de vigilância 24x7 capaz de supervisionar múltiplas instalações independentes do MICAEL Security a partir de uma única operação central.

## Nome do serviço

**MICAEL Security Command Center**

O Command Center é um produto/serviço independente. Ele não substitui as instalações locais do MICAEL Security e não compartilha banco de dados com elas.

## Arquitetura

```text
Sites monitorados

MICAEL Security - Condomínio A
MICAEL Security - Condomínio B
MICAEL Security - Empresa C
MICAEL Security - Hospital D
            │
            │ conexão de saída HTTPS/mTLS
            ▼
MICAEL Security Command Center
            │
            ├── Central de eventos
            ├── Videowall e vídeo sob demanda
            ├── Gestão de incidentes
            ├── Escalonamento e SLA
            ├── Saúde de dispositivos
            ├── Operadores e turnos
            └── Auditoria 24x7
```

## Princípios

1. Cada MICAEL Security local continua operando de forma autônoma.
2. A indisponibilidade do Command Center não interrompe reconhecimento, gravação ou controle de acesso local.
3. Os sites iniciam conexões de saída; não é obrigatório expor portas de entrada na rede do cliente.
4. A comunicação usa HTTPS, mTLS, certificados por instalação e tokens de serviço de curta duração.
5. Não existe acesso direto ao banco, storage ou rede interna de outro site.
6. Toda ação remota é autorizada, auditada e limitada por política.

## Componentes

### Security Edge Agent

Serviço instalado junto a cada MICAEL Security local.

Responsabilidades:
- registrar a instalação no Command Center;
- enviar heartbeat e telemetria;
- publicar eventos e alarmes;
- manter fila local para períodos offline;
- receber comandos remotos autorizados;
- criar sessão de vídeo sob demanda;
- executar reconexão automática e rotação de certificados.

### Command Center API

Responsabilidades:
- autenticação de instalações e operadores;
- cadastro de sites e grupos operacionais;
- ingestão e roteamento de eventos;
- gestão de incidentes;
- autorização de comandos remotos;
- auditoria e relatórios.

### Event Hub

Responsabilidades:
- receber eventos em tempo real;
- priorizar alarmes críticos;
- eliminar duplicidades;
- controlar retries e dead-letter queue;
- distribuir eventos entre estações de operadores.

Tecnologias candidatas: NATS JetStream ou RabbitMQ.

### Video Relay

Responsabilidades:
- abrir vídeo somente quando solicitado ou por regra de incidente;
- evitar tráfego contínuo desnecessário;
- usar WebRTC para baixa latência quando possível;
- oferecer fallback HLS para compatibilidade;
- nunca expor diretamente as câmeras à Internet.

### Operator Console

Interface para vigilância 24h:
- mapa/lista de sites;
- status online/offline;
- fila priorizada de alarmes;
- videowall configurável;
- abertura automática de câmeras relacionadas;
- reconhecimento e tratamento do incidente;
- comunicação com portaria ou responsável local;
- histórico e pesquisa;
- troca de turno.

## Eventos monitorados

- câmera offline;
- NVR/DVR offline;
- perda de comunicação com controladora;
- acesso negado repetidamente;
- pessoa não reconhecida;
- placa bloqueada;
- botão de pânico;
- invasão de perímetro;
- pessoa caída;
- fumaça/incêndio;
- objeto abandonado;
- portão aberto por tempo excessivo;
- falha de armazenamento;
- falha de IA;
- site completamente offline.

## Gestão de incidentes

Estados mínimos:

```text
New -> Acknowledged -> Investigating -> Escalated -> Resolved -> Closed
```

Cada incidente deve registrar:
- site e tenant;
- severidade;
- evento originador;
- operador responsável;
- horários de criação, reconhecimento e resolução;
- câmeras e dispositivos relacionados;
- ações executadas;
- observações e anexos;
- motivo de encerramento.

## Prioridades e SLA

- P1 Crítico: pânico, invasão confirmada, incêndio, pessoa caída.
- P2 Alto: acesso forçado, câmera crítica offline, placa bloqueada.
- P3 Médio: falha parcial de equipamento, acesso negado recorrente.
- P4 Baixo: manutenção e avisos não críticos.

O sistema deve medir tempo para reconhecimento e resolução por prioridade.

## Comandos remotos

Comandos possíveis, sujeitos a política:
- solicitar snapshot;
- abrir stream ao vivo;
- iniciar gravação de evidência;
- acionar sirene;
- falar por áudio bidirecional;
- liberar ou bloquear acesso;
- reiniciar serviço local;
- marcar dispositivo para manutenção.

Comandos críticos exigem dupla confirmação ou aprovação de supervisor.

## Multi-tenant e segregação

O Command Center pode atender várias empresas e condomínios, mas os dados devem ser isolados por tenant, contrato e grupo operacional.

Perfis mínimos:
- Administrador da Central;
- Supervisor;
- Operador;
- Auditor;
- Técnico de Manutenção;
- Cliente/Visualizador.

## Alta disponibilidade 24x7

Requisitos:
- duas ou mais instâncias da API;
- broker de mensagens redundante;
- PostgreSQL com réplica e backup;
- armazenamento de evidências redundante;
- monitoramento e alertas internos;
- estações de operação redundantes;
- failover documentado;
- RPO e RTO definidos.

Meta inicial sugerida: disponibilidade de 99,95%.

## Funcionamento offline

O Edge Agent deve armazenar eventos em outbox local quando a conexão cair. Após a reconexão, envia os eventos em ordem, com idempotência e controle de duplicidade.

## Contratos principais

### Heartbeat

```json
{
  "installationId": "uuid",
  "siteId": "uuid",
  "version": "1.0",
  "status": "online",
  "occurredAt": "2026-07-14T13:00:00Z",
  "camerasOnline": 48,
  "camerasOffline": 2,
  "pendingEvents": 0
}
```

### SecurityEvent

```json
{
  "eventId": "uuid",
  "eventType": "PanicTriggered",
  "severity": "critical",
  "source": "micael-security",
  "installationId": "uuid",
  "tenantId": "uuid",
  "occurredAt": "2026-07-14T13:00:00Z",
  "payload": {}
}
```

### RemoteCommand

```json
{
  "commandId": "uuid",
  "commandType": "OpenLiveStream",
  "installationId": "uuid",
  "deviceId": "uuid",
  "requestedBy": "uuid",
  "expiresAt": "2026-07-14T13:01:00Z",
  "parameters": {}
}
```

## Roadmap de implementação

### Fase 1 — Supervisão
- cadastro e pareamento de sites;
- heartbeat;
- status online/offline;
- ingestão de eventos;
- console de alarmes;
- gestão básica de incidentes.

### Fase 2 — Vídeo e operação
- snapshots;
- vídeo ao vivo sob demanda;
- videowall;
- áudio bidirecional;
- comandos remotos com auditoria.

### Fase 3 — Operação 24x7 avançada
- escalonamento e SLA;
- turnos e passagem de serviço;
- redundância e failover;
- relatórios operacionais;
- automações e playbooks.

### Fase 4 — IA centralizada
- correlação de eventos entre sites;
- priorização inteligente;
- detecção de padrões;
- resumo automático de incidentes;
- busca em linguagem natural.

## Decisão arquitetural

O MICAEL Security Command Center será um produto independente do MICAEL Security local. A integração ocorrerá por um Edge Agent e contratos versionados. Nenhum site dependerá da central para executar funções locais críticas.
