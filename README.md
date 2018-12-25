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
Stworzony został też obraz mysql, który jest dostępny pod adresem `jdbc:mysql://localhost:3306`.

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