FROM mcr.microsoft.com/mssql/server:2022-lts

ENV SA_PASSWORD="Str0ngP@ssw0rd!"
ENV ACCEPT_EULA=Y

COPY init.sql /init.sql
COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

CMD ["/bin/bash", "/entrypoint.sh"]
