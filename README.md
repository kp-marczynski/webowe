# Sklep muzyczny _BEZ_NAZWY_

## Wymagania
1) Docker
2) Docker-compose, ale to tylko na linuchu, my już mamy

## Jak to odpalić odpalić?
Wszystkie komendy odpalamy z poziomu głównego katalogu.

Stawiamy wszystko komendą

```bash
docker-compose up
```
Jeżeli nie masz obrazów (np. odpalasz pierwszy raz), to się stworzą (trochę to trwa).
Tworzy to kontenery zadeklarowane w `docker-compose.yml`.

Możemy to wywołać z flagą `-d`, żeby uruchomiło się wszystko w tle.

```bash
docker-compose up -d
```

Udostępniony jest serwer php, do którego można się dostać poprzez adres `http://localhost:8080`.
Udostępniony jest server dotnet, do którego można się dostać poprzez adres `http://localhost:8081`
Stworzony został też obraz mysql, który jest dostępny pod adresem `jdbc:mysql://localhost:3306`.

UWAGA! Obrazy powstałe dzięki `docker-compose` nie mogą się komunikować poprzez `localhost`, 
a muszą poprzez nazwę serwisu (sieci) w `docker-compose`, dlatego np. w php do bazy nie łączę się przez `localhost:3306`, a przez `mysql:3306`,
a do aplikacji .dotnetowej z phpa strzelam pod `http://dotnet_app:8081`.

## Jak zatrzymać tę karuzelę?
Jeżeli nie odpalaliśmy w tle (tj. bez flagi `-d`), to wystarczy zwykłe ubicie sesji terminala.
W przeciwnym wypadku należy wykonać komendę

```bash
docker-compose down
```

## Przydatne rzeczy
* Przeglądanie logów:

```bash
docker logs music_shop_mysql
```

* Wejście do środka kontenera (np. żeby wykonać sqlki)

```bash
docker exec -it music_shop_mysql bash
# root@{id}:/# mysql -u {MYSQL_USER} -p
# Enter password: {MYSQL_PASSWORD}

mysql> USE music_shop;
mysql> SELECT * FROM users;

```