# CS.Identity

Microsserviço de autenticação e cadastro de doadores da plataforma **Conexão Solidária**.

## Endpoints

- `POST /api/usuarios` — cadastro público (role Doador)
- `POST /api/auth/login` — JWT
- `GET /health`, `GET /metrics`

## Seeds

| Email | Senha | Role |
|---|---|---|
| gestor@ong.com | Teste@123 | GestorONG |
| doador@ong.com | Teste@123 | Doador |

## Executar

```bash
dotnet run --project src/CS.Identity.API
```

Stack completa: ver [CS.Infra](https://github.com/GabrielNatan2001/CS.Infra).
