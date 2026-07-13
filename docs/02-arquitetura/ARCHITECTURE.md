# Arquitetura Inicial do MICAEL

## 1. Princípios

- Modularidade.
- Separação de responsabilidades.
- Segurança por padrão.
- Multi-tenant.
- APIs versionadas.
- Eventos assíncronos para integrações desacopladas.
- Observabilidade e auditoria.
- Evolução incremental, evitando microsserviços prematuros.

## 2. Domínios principais

### MICAEL Core

- Identity e autenticação.
- Usuários, perfis e permissões.
- Tenants e configurações.
- Auditoria.
- Notificações.
- Arquivos.
- Integrações.
- Licenciamento.

### MICAEL Condo

- Condomínios e unidades.
- Moradores e dependentes.
- Visitantes e prestadores.
- Veículos e vagas.
- Comunicação.
- Reservas.
- Correspondências.
- Ocorrências e relatórios.

### MICAEL Security

- Câmeras e streams.
- Eventos de vídeo.
- Reconhecimento facial.
- Leitura de placas.
- Controle de acesso.
- Alarmes e incidentes.
- Evidências e pesquisa.

## 3. Tecnologias de referência

- Backend: ASP.NET Core e C#.
- Frontend: React e TypeScript.
- Mobile: Flutter.
- Serviços de IA: Python, PyTorch e OpenCV.
- Banco transacional: PostgreSQL.
- Cache: Redis.
- Mensageria: RabbitMQ.
- Objetos e evidências: armazenamento compatível com S3.
- Containers: Docker.
- Orquestração futura: Kubernetes quando justificado pela escala.

## 4. Estratégia de implementação

A primeira versão deverá usar um monólito modular para Core e Condo, com limites de domínio claros. Processamento de vídeo e IA será executado em serviços independentes devido às necessidades específicas de GPU, escala e isolamento.

A extração de novos serviços ocorrerá somente quando houver necessidade comprovada de escala, disponibilidade, ciclo de implantação independente ou isolamento operacional.

## 5. Comunicação

- REST/JSON para operações síncronas.
- WebSocket/SignalR para alertas e atualizações em tempo real.
- Mensageria para eventos de domínio e processamento assíncrono.
- RTSP/ONVIF e adaptadores de fabricantes para vídeo e dispositivos.

## 6. Segurança

- OpenID Connect e OAuth 2.0.
- RBAC combinado com escopos por tenant, condomínio, unidade e dispositivo.
- Criptografia em trânsito e proteção de dados sensíveis em repouso.
- Segregação de dados biométricos.
- Auditoria de acessos e comandos físicos.
- Política de retenção configurável.
- Princípio do menor privilégio.

## 7. Decisões pendentes

- Estratégia definitiva de isolamento multi-tenant.
- Provedor de identidade.
- Política de armazenamento de vídeo.
- Fabricantes prioritários para homologação.
- Estratégia de execução Edge versus Cloud.
- Requisitos de disponibilidade do piloto.
