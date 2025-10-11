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


