# Vasis.Erp.Facil – Emissor MDF-e com Blazor e Integração Zeus

Este é um sistema ERP focado na emissão de Manifesto Eletrônico de Documentos Fiscais (MDF-e), utilizando .NET 8 com Blazor (Server + WebAssembly), Entity Framework Core com Code First e integração com a biblioteca Zeus DFe.NET.

## 🚀 Funcionalidades

- Cadastro de Empresa, Transportadora, Veículos, Condutores, Pessoas
- Emissão de MDF-e com CIOT, documentos vinculados e informações de percurso
- Assinatura digital e envio para SEFAZ (via Zeus DFe)
- Visualização e gerenciamento dos MDF-es emitidos
- Integração modular para uso com certificado A1 ou A3 (planejado)
- Testes automatizados com xUnit
- CI/CD via GitHub Actions (build, testes e deploy via FTP ou Docker)

## 🧱 Estrutura do Projeto

- Backend/Blazor Server → API REST + integração Zeus
- Frontend/Blazor WebAssembly → Interface e consumo da API
- Shared/ → DTOs e modelos compartilhados
- Integracoes/ → Encapsulamento da biblioteca Zeus DFe.NET
- Tests/ → Projeto xUnit para testes de unidade

## 🛠️ Tecnologias Utilizadas

- .NET 8 (Blazor Server + WASM)
- Entity Framework Core 8 (Code First)
- SQL Server Express 2022
- Zeus DFe.NET (MDF-e)
- xUnit (Testes)
- GitHub Actions (CI/CD)
- Docker (opcional para homologação)

## 🧪 Requisitos de Desenvolvimento

- Visual Studio 2022 ou superior
- .NET SDK 8 instalado
- SQL Server Express 2022 instalado e em execução
- Git instalado

## 🧭 Como rodar o projeto localmente

1. Clone o repositório:

```bash
git clone https://github.com/seu-repositorio/Vasis.Erp.Facil.git
```

2. Abra o arquivo Vasis.Erp.Facil.sln no Visual Studio 2022

3. Configure a string de conexão no appsettings.json do projeto Backend:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\SQLEXPRESS;Database=VasisDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

4. Execute as migrations com Entity Framework Core:

```bash
cd Backend/Vasis.Erp.Facil.Server
dotnet ef database update
```

5. Rode o projeto pressionando F5 no Visual Studio

## ✅ Instruções adicionais para o time de desenvolvimento

- Use a branch develop para commits de funcionalidades
- As migrations devem ser nomeadas no padrão Add_Entidade_Exemplo
- Cada módulo novo (entidade) deve ter:
  - DTO no projeto Shared
  - API Controller no Server
  - Página Razor no Client
  - Serviço de chamada HTTP (Client/Services)
- Testes devem ser adicionados ao projeto Vasis.Erp.Facil.Tests
- Em caso de dúvida, consulte o arquivo README ou documentação complementar

## 📂 Banco de dados

- SQL Server Express 2022 (localdb ou instância nomeada)
- Migrations via Code First com EF Core
- Opcional: script .sql com estrutura gerada será incluído em /Docs
