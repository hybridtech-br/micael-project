# MICAEL MVP v0.1

Primeira versão executável para demonstração do MICAEL Condo e da central de alertas.

## Recursos

- dashboard com totais;
- cadastro de moradores;
- cadastro de visitantes;
- cadastro de veículos;
- registro do botão de pânico;
- API HTTP;
- persistência em `data/micael.json`;
- painel web responsivo;
- execução local ou via Docker.

## Executar localmente

```bash
cd apps/mvp-node
npm start
```

Acesse `http://localhost:3000`.

## Docker

```bash
docker build -t micael-mvp apps/mvp-node
docker run --rm -p 3000:3000 -v micael-data:/app/data micael-mvp
```

## Endpoints

- `GET /api/health`
- `GET /api/dashboard`
- `GET|POST /api/residents`
- `GET|POST /api/visitors`
- `GET|POST /api/vehicles`
- `GET|POST /api/panicEvents`

> Esta versão é um protótipo funcional. Ainda não inclui autenticação forte, banco PostgreSQL, reconhecimento facial, leitura de placas ou integrações com hardware.
