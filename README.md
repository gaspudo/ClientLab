# ClientLab

Sistema de Gestão de clientes desenvolvido em C# com persistência em MySQL, focado em organização.

## 2. Tecnologias e Arquitetura

### C# (.NET 8/9): Utilizado para processamento de regras de negócio.

### MySQL: Modelagem de dados relacional para garantir a integridade de clientes, compras etc.


## 3. Funcionalidades Principais
### Autenticação e autorização de usuários.

### CRUD completo de vendas.

### Relatórios gerados a partir de queries complexas no MySQL.

## 4. Como Executar
### !IMPORTANT
Certifique-se de configurar a Connection String no arquivo appsettings.json ou similar antes de rodar as migrações.

Bash
# Clonar o repositório
git clone https://github.com/gaspudo/ClientLab.git

# Restaurar dependências
dotnet restore

# Executar a aplicação
dotnet run
