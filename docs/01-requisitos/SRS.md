# Especificação de Requisitos de Software — MICAEL

**Identificador:** MICAEL-SRS  
**Versão:** 0.1  
**Status:** Em elaboração

## 1. Introdução

### 1.1 Objetivo

Definir os requisitos funcionais e não funcionais da plataforma MICAEL, composta por MICAEL Core, MICAEL Condo e MICAEL Security.

### 1.2 Escopo

A plataforma deverá administrar condomínios, moradores, visitantes, prestadores, veículos, vagas, mensagens e ocorrências, além de gerenciar câmeras, reconhecimento facial, leitura de placas e dispositivos de controle de acesso.

### 1.3 Perfis iniciais

- Administrador.
- Síndico.
- Operador.
- Supervisor de Segurança.
- Condômino.
- Visitante.
- Prestador de serviço.

## 2. Requisitos do MICAEL Core

- RF-CORE-001: suportar múltiplos condomínios com isolamento lógico de dados.
- RF-CORE-002: autenticar usuários por credenciais seguras.
- RF-CORE-003: oferecer autenticação multifator configurável.
- RF-CORE-004: controlar permissões por papéis e escopos.
- RF-CORE-005: registrar auditoria de ações críticas.
- RF-CORE-006: disponibilizar notificações em tempo real.
- RF-CORE-007: armazenar arquivos e metadados com controle de acesso.
- RF-CORE-008: permitir integração entre módulos por APIs e eventos.

## 3. Requisitos do MICAEL Condo

- RF-CONDO-001: cadastrar condomínios, blocos, apartamentos e casas.
- RF-CONDO-002: cadastrar moradores, dependentes e responsáveis por unidade.
- RF-CONDO-003: cadastrar veículos e vinculá-los a pessoas e unidades.
- RF-CONDO-004: cadastrar visitantes com foto, documento, período autorizado e unidade de destino.
- RF-CONDO-005: cadastrar veículos de visitantes e respectivas placas.
- RF-CONDO-006: controlar vagas de moradores e visitantes.
- RF-CONDO-007: permitir mensagens e arquivos entre administração, operação e condôminos.
- RF-CONDO-008: permitir resposta do condômino às mensagens recebidas.
- RF-CONDO-009: gerar relatórios administrativos e operacionais.
- RF-CONDO-010: disponibilizar botão de pânico no aplicativo.
- RF-CONDO-011: exibir à central o bloco e a unidade que acionaram o pânico.

## 4. Requisitos do MICAEL Security

- RF-SEC-001: cadastrar e gerenciar câmeras IP, DVRs e NVRs homologados.
- RF-SEC-002: visualizar streams ao vivo conforme permissão.
- RF-SEC-003: detectar pessoas, animais e veículos.
- RF-SEC-004: reconhecer faces cadastradas conforme regras de acesso.
- RF-SEC-005: identificar placas de veículos.
- RF-SEC-006: registrar automaticamente entrada e saída por face ou placa.
- RF-SEC-007: acionar portas, portões, cancelas e catracas autorizadas.
- RF-SEC-008: controlar regras por pessoa, veículo, local, data, dia e horário.
- RF-SEC-009: gerar alertas de acessos negados, pessoas bloqueadas e placas bloqueadas.
- RF-SEC-010: manter evidências de eventos, incluindo data, hora, câmera e resultado.

## 5. Requisitos não funcionais iniciais

- RNF-001: comunicação externa protegida por TLS.
- RNF-002: dados sensíveis protegidos em repouso.
- RNF-003: logs de auditoria não poderão ser alterados por usuários comuns.
- RNF-004: o sistema deverá suportar implantação SaaS e On-Premises.
- RNF-005: as APIs deverão possuir documentação OpenAPI.
- RNF-006: operações críticas deverão possuir rastreabilidade ponta a ponta.
- RNF-007: o tratamento de dados pessoais e biométricos deverá considerar a LGPD.
- RNF-008: falhas de IA não deverão liberar acesso sem uma regra explícita de contingência.

## 6. Próximas revisões

- Detalhar critérios de aceitação.
- Adicionar regras de negócio.
- Criar matriz de permissões.
- Formalizar casos de uso.
- Definir requisitos de privacidade e retenção.
- Especificar integrações com hardware.
