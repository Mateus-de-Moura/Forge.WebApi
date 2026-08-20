# Forge Web API Template

Template para criar Web APIs em .NET com uma estrutura baseada em Clean Architecture.

O projeto inclui Minimal APIs, MediatR, Entity Framework Core, FluentValidation, autenticação e testes com xUnit.

## Instalação

Instale o template pelo NuGet.org:

```powershell
dotnet new install MateusDeMoura.Forge.WebApi.Templates
```

## Como usar

Crie uma nova solução informando o nome do projeto:

```powershell
dotnet new forge-api --name MinhaEmpresa.Pedidos
```

Se quiser definir o diretório de saída:

```powershell
dotnet new forge-api --name MinhaEmpresa.Pedidos --output MinhaEmpresa.Pedidos
```

Entre no diretório criado, restaure as dependências e compile:

```powershell
cd MinhaEmpresa.Pedidos
dotnet restore
dotnet build
```

Configure a conexão `DefaultConnection` em `src/MinhaEmpresa.Pedidos.Api/appsettings.json` e execute a API:

```powershell
dotnet run --project src/MinhaEmpresa.Pedidos.Api
```
