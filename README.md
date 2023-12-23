# thunders

O projeto foi feito rodando a base de dados em Docker, onde foi criado uma base SQLServer usando as seguintes especificações

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=S3nh@d0b4nc0" `   -p 1433:1433 --name bancoteste --hostname bancoteste `   -d `   mcr.microsoft.com/mssql/server:2022-latest

Que produziu a seguinte conexão

Server= localhost
Database= TestDB
User= sa
Password= S3nh@d0b4nc0

A connection string completa está dentro do appsettings.json

A aplicação usa migrations para criar e modificar as tabelas no banco de dados, então após a criação da instância do banco de dados deverá ser atualizado as migrations na base criada.
