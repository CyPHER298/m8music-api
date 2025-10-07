# 🎶 M&Music — README

Aplicativo que conecta **músicos/bandas**, **estabelecimentos** e **clientes** em eventos com repertório, pedidos de música, avaliações e relatórios.  

- **Backend**: ASP.NET Core (C#) com **Clean Architecture**  
- **Frontend**: React Native  

---

## 1) Definição do Projeto

### Objetivo do Projeto
Facilitar a contratação de música ao vivo e a interação durante o evento:  
- O estabelecimento cria o evento e contrata o músico.  
- O músico publica o repertório.  
- Os clientes visualizam, fazem pedidos (se permitido) e avaliam.  
- O sistema gera relatórios para o estabelecimento e histórico de avaliações para o músico.  

### Escopo
- Cadastro e autenticação (Cliente, Músico, Estabelecimento).  
- Criação/gerenciamento de **Eventos** (data, hora início/fim).  
- **Tokens de acesso** (antecipado para músico/estabelecimento; QR Code/token para clientes).  
- **Repertório** do evento (músico define músicas; cliente visualiza).  
- **Pedidos de música** (se permitido pelo músico).  
- **Contratos** entre estabelecimento e músico.  
- **Avaliações** (clientes → evento; estabelecimento → músico).  
- **Relatórios** do evento para o estabelecimento.  
- **Freelances**: feed de oportunidades entre músicos e estabelecimentos.  

### Requisitos Funcionais
- Autenticação por perfis (JWT).  
- Criação e gerenciamento de eventos.  
- Geração de tokens/QR Codes.  
- Janela de acesso do cliente: apenas a partir de **T–20 min** do evento.  
- Publicação de repertório pelo músico.  
- Alternar se aceita pedidos de música.  
- Criar e gerenciar pedidos de música.  
- Avaliações pós-evento.  
- Relatórios automáticos.  
- Feed de oportunidades (freelances).  

### Requisitos Não Funcionais
- Backend em **C# .NET Core 8** + **OracleSQL**.  
- Clean Architecture.  
- Testes unitários e de integração.  
- Segurança: JWT + refresh tokens + roles/claims.  
- Escalabilidade: filas para notificações/relatórios.  
- Front em **React Native** (Expo) + **TypeScript**.  

---

## 2) Desenho da Arquitetura (Clean Architecture)

### Camadas
- **Apresentação (API)** → Controllers/DTOs/Validação  
- **Aplicação** → Casos de uso (Services/Handlers)  
- **Domínio** → Entidades, Value Objects, Regras  
- **Infraestrutura** → EF Core, Repositórios, Notificações, APIs externas  

### Entidades principais
- **User** (Cliente)
- **Músico** (Músico)
- **Estabelecimento** (Estabelecimento)
- **Evento** (com tokens, horário início/fim, aceitação de pedidos)
- **Música** (Músicas guardadas em banco de dados)
- **Repertório** (músicas do evento)  
- **Pedidos de Música** (status: pendente, aceito, negado, tocado)  
- **Avaliações** (evento/músico)  
- **Contrato** (condições do evento entre músico e estabelecimento)  

---

## 3) Estrutura de Pastas

```
/backend
  /src
    /Presentation
    /Application
    /Domain
    /Infrastructure
  /tests
    Unit/
    Integration/

/mobile
  /src
    app/
    screens/
    components/
    store/
    services/api/
    utils/
```

---

## 4) Endpoints principais

### Autenticação
- `POST /api/v1/auth/register`  
- `POST /api/v1/auth/login`  

### Eventos
- `POST /api/v1/eventos` (estabelecimento)  
- `GET /api/v1/eventos/{id}`  
- `PATCH /api/v1/eventos/{id}`  
- `POST /api/v1/eventos/{id}/contrato`  

### Repertório
- `POST /api/v1/eventos/{id}/repertorio` (músico)  
- `GET /api/v1/eventos/{id}/repertorio` (cliente, T–20)  

### Pedidos de Música
- `POST /api/v1/eventos/{id}/pedidos` (cliente)  
- `PATCH /api/v1/pedidos/{id}` (músico atualiza status)  

### Avaliações
- `POST /api/v1/eventos/{id}/avaliacoes-evento` (cliente)  
- `POST /api/v1/eventos/{id}/avaliacoes-musico` (estabelecimento)  

### Relatórios
- `GET /api/v1/eventos/{id}/relatorio` (estabelecimento)  

---

## 5) Fluxo do Sistema

1. **Criação do evento** (estabelecimento convida músico e define contrato).  
2. **Pré-evento**: músico cadastra repertório e decide se aceita pedidos.  
3. **T–20 minutos**: clientes acessam com token/QR e veem repertório.  
4. **Durante o evento**: pedidos de música, execução e atualizações em tempo real.  
5. **Pós-evento**: avaliações, relatórios e feedbacks ficam disponíveis.  

---

## 6) Frontend (React Native)

### Telas – Cliente
- Login  
- Evento (contagem regressiva, repertório)  
- Criar pedidos  
- Avaliar evento  

### Telas – Músico
- Dashboard de eventos  
- Editor de repertório  
- Gerenciar pedidos  
- Ver avaliações  
- Freelances  

### Telas – Estabelecimento
- Criar evento  
- Gerenciar contrato  
- Relatórios pós-evento  
- Freelances  

---

## 7) Como Rodar

### Backend
```bash
# .NET 8 + OracleSQL
dotnet ef database update
dotnet run --project src/Presentation
# Swagger: http://localhost:5100/swagger
```

### Mobile
```bash
cd mobile
npm install
npx expo start
```

---

## 8) Backlog Inicial

- [ ] Autenticação + Perfis  
- [ ] CRUD Evento + Tokens + QR  
- [ ] Repertório do Evento  
- [ ] Pedidos de Música  
- [ ] Avaliações  
- [ ] Relatórios  
- [ ] Freelances MVP  
- [ ] Notificações Push  

---

## 9) Tecnologias

- **Backend**: .NET 8, ASP.NET Core, EF Core, OracleSQL  
- **Frontend**: React Native, Expo, TypeScript, React Navigation
- **Infra**: Swagger (API docs)  

---

## 📌 Missão
O **M&Music** tem como missão **integrar músicos e ouvintes** através da tecnologia, aproximando artistas, estabelecimentos e clientes em uma experiência musical interativa e organizada.
