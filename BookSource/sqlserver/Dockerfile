FROM mcr.microsoft.com/mssql/server:2019-latest

ENV SA_PASSWORD=12345678aA!
ENV MSSQL_PID=Express
ENV ACCEPT_EULA=Y
USER root

# Instalar sqlcmd tools
USER root

RUN rm -f /etc/apt/sources.list.d/microsoft-prod.list /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && apt-get install -y curl apt-transport-https gnupg && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y --fix-missing msodbcsql17 mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    ln -s /opt/mssql-tools/bin/sqlcmd /usr/bin/sqlcmd && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

COPY init.sql /init.sql
COPY start.sh /start.sh

RUN chmod +x /start.sh

ENTRYPOINT ["/bin/bash", "/start.sh"]
