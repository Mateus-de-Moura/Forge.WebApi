# Forge Web API Template

Template público para criar Web APIs em .NET seguindo uma organização baseada em Clean Architecture.

## Estrutura

A solução gerada é dividida nos seguintes projetos:

- `Api`: endpoints, middlewares e configuração da aplicação;
- `Application`: casos de uso, handlers, validações e serviços;
- `Domain`: entidades e contratos do domínio;
- `Infrastructure`: acesso a dados, Entity Framework Core e repositórios;
- `Shared`: respostas e exceções compartilhadas;
- `Tests`: testes automatizados.

O projeto inclui Minimal APIs, MediatR, Entity Framework Core, FluentValidation, autenticação e testes com xUnit.

## Requisitos

- .NET SDK 9 ou superior;
- SQL Server para utilizar a configuração de banco de dados incluída.

## Instalação

Instale o template público pelo NuGet.org:

```powershell
dotnet new install MateusDeMoura.Forge.WebApi.Templates
```

Para atualizar uma instalação existente:

```powershell
dotnet new install MateusDeMoura.Forge.WebApi.Templates --force
```

## Criando um projeto

Informe o nome da nova solução com `--name`:

```powershell
dotnet new forge-api --name MinhaEmpresa.Pedidos
```

Para escolher também o diretório de saída:

```powershell
dotnet new forge-api --name MinhaEmpresa.Pedidos --output MinhaEmpresa.Pedidos
```

O nome informado substitui `Forge.WebApi` na solução, nos projetos, diretórios, namespaces e referências internas.

## Executando

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

## Testes

Execute todos os testes da solução com:

```powershell
dotnet test
```

## Remoção do template

```powershell
dotnet new uninstall MateusDeMoura.Forge.WebApi.Templates
```
