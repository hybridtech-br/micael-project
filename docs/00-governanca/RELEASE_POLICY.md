# Politica de Releases do Programa MICAEL

## Objetivo

Padronizar a preparacao, validacao, publicacao e manutencao de releases dos produtos do Ecossistema MICAEL.

## Versionamento

Todos os produtos usam Semantic Versioning: MAJOR.MINOR.PATCH.

- MAJOR: mudanca incompatível de contrato ou comportamento.
- MINOR: nova funcionalidade compatível.
- PATCH: correcao compatível.

## Canais

- alpha: validacao interna.
- beta: homologacao controlada.
- rc: candidato a release.
- stable: release para producao.

## Requisitos para publicacao

Uma release exige:

- build em modo Release aprovado;
- testes automatizados aprovados;
- verificacao de formatacao e analise estatica;
- migrations validadas;
- documentacao atualizada;
- CHANGELOG atualizado;
- notas de release;
- plano de rollback;
- verificacao de seguranca e ausencia de segredos.

## Tags

Formato: vMAJOR.MINOR.PATCH.

Exemplos:

- v0.2.0
- v1.0.0-rc.1
- v1.0.1

## Compatibilidade

Contratos publicos REST, eventos e pacotes SDK devem declarar a versao suportada. Mudancas incompatíveis exigem nova versao major ou novo endpoint versionado.

## Suporte

Releases stable recebem correcoes de seguranca conforme a politica de suporte de cada produto. Releases alpha e beta nao possuem garantia de compatibilidade.
