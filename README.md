# StarkBank Challange — .NET API + Worker

Projeto desenvolvido em .NET contendo:

* API ASP.NET Core
* Worker 
* Integração com StarkBank 
* Webhook para recebimento de eventos
* Deploy em AWS EC2 (Windows Server)
* Configuração HTTPS via IIS
* Uso de variáveis de ambiente para secrets
* Testes integrados

---

# Arquitetura

```
StarkBankTest
 ├── StarkBankTest.API
 │     └── WebhookController
 │
 ├── StarkBankTest.Worker
 │     └── InvoiceService
 │
 └── StarkBankTest.IntegrationTests
```

##  Fluxo da Aplicação

1. Worker cria invoices na StarkBank.
2. StarkBank envia webhook quando há evento.
3. API recebe o evento via endpoint `/ReceiveEvent`.
4. API cria uma transferência automaticamente.

---

#  Configuração de Ambiente

Ultilizado **Variáveis de Ambiente** e appsettings.

## Variável de ambiente

* `STARKBANK_PRIVATE_KEY`

---

##  Aprendizados
* Como funciona e como implementar um webhook
* Configurar uma instancia da AWS
* Configurar o Servidor para expor em uma rota Https
* Leitura da documentação da SarkBank


#  Checklist de Produção

* HTTPS configurado
* Security Group liberado (80/443)
* Variáveis de ambiente configuradas
* Application Pool correto
* Ambiente StarkBank configurado corretamente (sandbox/production)
* Webhook configurado no painel da StarkBank

---
