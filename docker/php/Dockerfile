FROM php:7.1.8-apache

MAINTAINER Jakub Gruda & Krzyszfot Marczyński

COPY ./Php /srv/app
COPY ./shared /srv/app/public/shared
COPY ./docker/php/vhost.conf /etc/apache2/sites-available/000-default.conf

WORKDIR /srv/app

RUN docker-php-ext-install mysqli \
    && chown -R www-data:www-data /srv/app && a2enmod rewrite