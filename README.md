# TodoList/Posticks

Este é um projeto ASP.NET 6 que utiliza EF Core e a provider factory/DbContext está relacionada ao banco SqlServer. É um sistema simples de notas/posticks.

## Instalação
Para restaurar os pacotes necessários, utilize o comando `dotnet restore`.

O aplicativo requer um banco de dados para ser executado. Certifique-se de que você tenha um banco de dados SQL Server em execução e atualize o arquivo `appsettings.json` com a string de conexão correta. Em seguida, execute o comando `dotnet ef database update` para aplicar as migrações no banco de dados.

## Resumo do Projeto:

O Notas/Posticks Web App é um sistema simples de notas/posticks desenvolvido com ASP.NET 6 e EF Core, utilizando o banco de dados SQL Server. O sistema permite que o usuário adicione, edite e exclua notas, que são exibidas na página inicial do aplicativo.

Para instalar o aplicativo, o usuário precisa restaurar os pacotes necessários usando o comando `dotnet restore`. Em seguida, deve-se configurar um banco de dados SQL Server e atualizar o arquivo `appsettings.json` com a string de conexão correta. Por fim, deve-se aplicar as migrações no banco de dados usando o comando `dotnet ef database update`.
