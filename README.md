# Sklep muzyczny _BEZ_NAZWY_

## Wymagania
Trzeba mieć dockera poinstalowanego i docker-compose

## Jak odpalić?
Wejść w główny folder projektu i odpalić

```bash
docker-compose up -d
```

Stworzą się obrazy jak nie masz i stworzą kontenery.

Opcja `-d` uruchamia proces w tle.

Można się do strony (przynajmniej phpowej) dostać na `localhost:8080`,
a serwer mysql jest na `localhost:3308`

## Jak zatrzymać?
Żeby ubić kontenery wystarczy być w głównym folderze projektu i wykonać

```bash
docker-compose down
```

Jak się chce usunąć też obrazy (bo np. zmieniamy Dockerfile)
```bash
docker-compose down --rmi all
```

