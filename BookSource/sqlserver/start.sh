#!/bin/bash
/opt/mssql/bin/sqlservr &

echo "Esperando a que SQL Server inicie..."
sleep 15

echo "Ejecutando init.sql..."
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$SA_PASSWORD" -i /init.sql

wait
