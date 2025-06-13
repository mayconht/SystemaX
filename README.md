# TestSystemaX

Projeto de exemplo para demonstração de testes de integração em APIs .NET.

## Estrutura do Projeto

```
TestSystemaX/
├── src/
│   └── SampleApi/           # API de exemplo
├── tests/
│   └── ApiIntegrationTests/ # Testes de integração
├── docs/                    # Documentação adicional
└── .azure/
    └── pipelines/          # Configurações do Azure DevOps
```

## Tecnologias Utilizadas

- .NET 8.0
- ASP.NET Core Web API
- xUnit para testes
- Microsoft.AspNetCore.Mvc.Testing para testes de integração
- Verify para assertions
- Azure DevOps para CI/CD

## Pré-requisitos

- .NET 8.0 SDK
- Visual Studio 2022 ou VS Code
- Azure DevOps (para CI/CD)

## Como Executar

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/TestSystemaX.git
cd TestSystemaX
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Execute os testes:
```bash
dotnet test
```

4. Execute a API:
```bash
cd src/SampleApi
dotnet run
```

## Testes

O projeto inclui testes de integração que verificam:

- Status code das requisições
- Formato e conteúdo das respostas
- Validação de dados retornados

Para executar os testes com cobertura:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```

## Pipeline

O pipeline do Azure DevOps está configurado com as seguintes etapas:

1. Build
2. Testes Unitários
3. Testes de Integração
4. Geração de Relatório de Cobertura
5. Publicação de Artefatos

## Contribuindo

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/nova-feature`)
5. Abra um Pull Request

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes. 