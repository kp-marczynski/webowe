FROM php:7.1.8-apache

MAINTAINER Jakub Gruda & Krzyszfot Marczyński

#COPY ./Php /srv/app
#COPY ./shared/images/ /srv/app/public/res/images/
#COPY ./shared/scripts/ /srv/app/public/res/scripts/
#COPY ./shared/styles/ /srv/app/public/res/styles/
COPY ./docker/php/vhost.conf /etc/apache2/sites-available/000-default.conf

WORKDIR /srv/app

RUN docker-php-ext-install mysqli \
    && chown -R www-data:www-data /srv/app && a2enmod rewrite