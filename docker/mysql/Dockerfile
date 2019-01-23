FROM mysql:5.7

MAINTAINER Jakub Gruda & Krzyszfot Marczyński

# context is set to root dir
COPY ./docker/mysql/init.sql /docker-entrypoint-initdb.d
COPY ./docker/mysql/setup.sql /docker-entrypoint-initdb.d
COPY ./docker/mysql/custom.cnf /etc/mysql/conf.d/custom.cnf