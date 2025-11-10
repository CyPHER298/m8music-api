# M8Music API

> API para conectar **músicos/bandas**, **estabelecimentos** e **clientes** em eventos ao vivo, com **repertório**, **pedidos de música**, **avaliações** e **relatórios**, seguindo **Clean Architecture** em .NET.

---

## 1) Definição do Projeto

### Objetivo do Projeto
Esclarecer o problema que a aplicação resolve:
- Facilitar a **organização de eventos** com música ao vivo.
- Permitir que o **músico publique o repertório** do evento.
- Habilitar **interação do cliente** (visualização, votação/pedidos, avaliações).
- Gerar **relatórios** para estabelecimentos e histórico de **avaliações** para músicos.

### Escopo
Funcionalidades previstas:
- **Avaliações** (cliente → evento; estabelecimento → músico).
- **Relatórios** pós-evento (estabelecimento).

### Requisitos Funcionais
- CRUD de avaliações.
- Emissão de **relatórios** (por evento/intervalo).

### Requisitos Não Funcionais
- **.NET 8** + **ASP.NET Core**.
- **Clean Architecture**.
- **EF Core**.
- Observabilidade (**Swagger**).
- Testes **unitários** e **de integração**.
- Segurança (**CORS**).

---

## 🛠️ Instruções de Instalação e Configuração

Siga os passos abaixo para preparar e executar o projeto **M8Music API** em seu ambiente local.

### 1. Pré-requisitos

* **SDK do .NET 9.0** (ou superior).
* Um ambiente de desenvolvimento (ex: Visual Studio, VS Code).
* [cite_start]Acesso a um banco de dados **Oracle**, pois o projeto utiliza o pacote `Oracle.EntityFrameworkCore`[cite: 1].

### 2. Configuração do Banco de Dados

O projeto utiliza o Entity Framework Core e requer uma *connection string* válida para o Oracle, conforme configurado em `appsettings.json`.

1.  Abra o arquivo `appsettings.json`.
2.  Localize a seção `ConnectionStrings`.
3.  **Ajuste a *connection string* `M8MusicAPI`**:

    ```json
    "ConnectionStrings": {
      "M8MusicAPI": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521));(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=SEU_ID;Password=SUA_SENHA;"
    }
    ```
    > **Atenção:** Substitua `rm99742` e `290305` pelos seus `User Id` e `Password`.

### 3. Instalação e Execução

1.  **Clone o repositório** (ou navegue até a pasta do projeto `M8MusicAPI/`).

2.  [cite_start]**Restaure os pacotes NuGet** (as dependências estão definidas no `M8MusicAPI.csproj` [cite: 1]):
    ```bash
    dotnet restore
    ```

3.  **Execute as migrations do EF Core** (Assumindo que as classes de Migração estão prontas):
    ```bash
    dotnet ef database update
    ```
    *Obs: Este passo pode variar dependendo da organização das suas migrations.*

4.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```
    A API será iniciada no endereço configurado, geralmente `http://localhost:5264`.

### 4. Documentação e Teste (Swagger/OpenAPI)

Com a aplicação em execução:

* Acesse o navegador na URL base para visualizar a documentação interativa:
    `http://localhost:5264/`
    *(A rota de prefixo do Swagger está vazia, conforme `Program.cs`)*.
* Você poderá interagir com o *endpoint* `/api/avaliacao` e observar os *links* HATEOAS nas respostas.

---

## 2) Desenho da Arquitetura (Clean Architecture)

Separação de responsabilidades e baixo acoplamento:

- **Apresentação (Presentation / API)**  
  Controllers, DTOs/Contracts, validação de entrada, versionamento, autenticação/autorização, documentação (Swagger).

- **Aplicação (Application)**  
  Casos de uso/Services/Handlers, orquestra regra de negócio do **Domínio**.

- **Domínio (Domain)**  
  Entidades, Interfaces de repositório (abstrações).

- **Infraestrutura (Infrastructure)**  
  Implementações de repositórios (EF Core), migrations.

---

## 3) Estrutura de Pastas

```
M8MusicAPI/
├── Properties/
│
├── Controllers/
│   ├── AvaliacaoController.cs
│   ├── HelloWorldController.cs
│   ├── RelatoriosController.cs
│   └── WeatherForecastController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── DTOs/
│   ├── AvaliacaoDTO.cs
│   └── AvaliacaoUpdateDto.cs
│
├── Infrastructure/
│   └── Persistence/
│       ├── Mappings/
│       ├── Migrations/
│       ├── Models/
│       └── Repository/
│
├── Services/
│   ├── AvaliacaoService.cs
│   └── IAvaliacaoService.cs
│
├── Utils/
│   ├── SwaggerConfig.cs
│   └── SwaggerServerConfig.cs
│
├── appsettings.json
├── appsettings.Development.json
├── M8MusicAPI.http
├── Program.cs
└── WeatherForecast.cs
```

---

## 4) Avanço

- Migrations preenchidas e criada para a aplicação
- HATEOS e maturidade nível 3 para AVALIAÇÃO CONTROLLER
- Conexão com banco de dados OracleSQL
