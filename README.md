# 🚜 Oficina RGF — API de Estoque de Peças

API REST desenvolvida para o sistema de gerenciamento de estoque de peças da Oficina RGF, especializada em tratores e colhedoras John Deere.

## 📋 Sobre o Projeto

Backend completo com endpoints para gerenciamento de peças e modelos de máquinas, com suporte a relacionamento entre peças e múltiplos modelos compatíveis.

## ✨ Endpoints

### Peças

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/Pecas` | Listar todas as peças |
| GET | `/api/Pecas/buscar` | Buscar peças por código parcial e/ou modelo |
| GET | `/api/Pecas/{codigo}` | Buscar peça por código exato |
| GET | `/api/Pecas/modelo/{modeloId}` | Listar peças por modelo |
| POST | `/api/Pecas` | Cadastrar nova peça |
| PUT | `/api/Pecas/{id}` | Atualizar peça |
| DELETE | `/api/Pecas/{id}` | Excluir peça |

### Modelos

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/Modelos` | Listar todos os modelos |
| POST | `/api/Modelos` | Cadastrar novo modelo |
| PUT | `/api/Modelos/{id}` | Atualizar modelo |
| DELETE | `/api/Modelos/{id}` | Excluir modelo |

## 🛠️ Tecnologias

- [.NET 8]— plataforma
- [ASP.NET Core] — framework web
- [Entity Framework Core 8] — ORM
- [PostgreSQL] — banco de dados
- [Npgsql]— driver PostgreSQL
- [Swagger] — documentação da API

## 🚀 Como Rodar

### Pré-requisitos

- .NET 8 SDK
- PostgreSQL instalado e rodando

### Instalação

```bash
# Clone o repositório
git clone https://github.com/ErickCarvalhoSena/OficinaJD-API.git

# Entre na pasta
cd OficinaJD.API

# Restaure as dependências
dotnet restore
```

### Configuração do banco de dados

Crie o arquivo `appsettings.json` baseado no `appsettings.Example.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=oficina_jd;Username=postgres;Password=SUA_SENHA"
  }
}
```

### Rodando o projeto

```bash
# Aplicar migrations
dotnet ef database update

# Rodar a API
dotnet run
```

 `http://localhost:5090/swagger` para ver a documentação.

## 📁 Estrutura do Projeto

```
OficinaJD.API/
├── Controllers/
│   ├── PecasController.cs
│   └── ModelosController.cs
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   └── PecaDTO.cs
├── Models/
│   ├── Peca.cs
│   ├── Modelo.cs
│   └── PecaModelo.cs
├── Migrations/
└── Program.cs
```

## 🔗 Repositórios Relacionados

- [Frontend — oficina-jd-web](https://github.com/ErickCarvalhoSena/API-InventarioJD-front)
