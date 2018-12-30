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

mysql> USE muzyka4;
mysql> SELECT * FROM users;

```

## Q&A

### PHP 1.13
#### Stosowane znaczniki PHP, ich znaczenie oraz zakres ich działania.  
Mamy podstawowe: wszystko pomiędzy `<?php` i `?>` jest kodem PHP
```php
<?php echo 'PWr' ?>
```
Można też używać `<? ?>` albo `<% %>`, ale nie wszystkie serwery to obsługują + dobrą praktyką jest stosowanie tego pierwszego

```php
<?= wyrazenie ?> /* To jest skrót dla */ <? echo wyrazenie ?>"
```

Jeżeli w pliku jest tylko i wyłącznie kod php, to przyjęło się, że nie dodajemy kończącego tagu `?>`, zostaje po prostu
```php
<?php
$zmienna = 5;
// koniec pliku
```

#### Rodzaje komentarzy w skryptach PHP.  
Jest 2,5 rodzaja komentarza - `//` oraz `#` to jednolinijkowe komentarze. Może się wcześniej skończyć, 
jak skończy się blok php, ale nadal linia trwa, np.
```php
<h1>To jest <?php # echo 'prosty';?> przykład</h1>
```
Drugim rodzajem komentarza jest `/* */` - komentarze wielolinijkowe. Nie ma zagnieżdżeń, tj
```php
<?php
 /* 
    echo 'To jest test'; /* Ten komentarz będzie przyczyną problemów */
 */
?>
```

#### Rola pojedynczych i podwójnych znaków apostrofu oraz par apostrofów.
Wszystko pomiędzy pojedynczymi `'` jest traktowane jako tekst - nie można dodać zmiennych itp (ewentualnie `\'` jest parsowane)
Podwójne znaki `"` są normalnie parsowane i ewaluowane - możemy dawać zmienne i wyrażenia wewnątrz

```php
$name = 'test';
$singleQuote = 'This is example for single quote $name'; // here $name variable not evaluating 
echo $singleQuote; // Output: This is example for single quote $name
$singleQuote = "This is example for single quote $name"; // here $name variable will evaluate and replace variable value
echo $singleQuote; // Output: This is example for single quote test

Also inside single quote expression evaluate faster campare to double quotes
```

Są jeszcze ala bashowe `<<<`
```php
<?php
  // Example of heredoc
    echo $foo = <<<abc
    My name is {$fname}
    abc;

        // Example of nowdoc
        echo <<< 'abc'
        My name is "$name".
        Now, I am printing some
    abc;
```

#### Jak deklaruje się i inicjuje zmienne? Czy wielkie i małe litery w nazwie zmiennej są rozróżniane? Jakie są typy zmiennych?
Zmienne muszą się zaczynać od znaku `$` - obojętnie czy pola czy parametry funkcji.
W klasie nie można jednocześnie deklarować i inicializować zmiennej.
Małe i duże litery robią różnce! - Case sensitive
```php
<?php
$name;
$five = 5;
if (5 === $five) {
    $name = 'hehe';
} else {
    $name = ':(';
}
echo $name;
```

Typy zmiennych:
* boolean,
* integer,
* float,
* string,
* array,
* object,
* callable,
* resource,
* NULL.

Typ można ogarnąć przez `gettype`
```php
<?php
 echo(gettype(0)); // integer
```

Od wersji 7.0 PHP jesteśmy w stanie tworzyć funkcje, które przyjmują parametry określonych typów 
(od wersji 5.0 było to możliwe tylko dla klas oraz self, następnie m. in. dla tablic)
```php
<?php
class SzalonyPecet {
    
    function a (int $count){
        echo "Szalony Pecet jest super";
        for($i=0; $i<$count; $i++){
            echo "!";
        }
    }
    
    function b(SzalonyPecet $szalonyPecet){
        return TRUE;
    }
    
}
$str = "aaa";
$sp = new SzalonyPecet();
$sp->a($str);               // Fatal error
$sp->a(5);                  // OK
$sp->b(5);                  // Fatal error
$sp->b(new SzalonyPecet()); // OK
```


#### Realizacja operacji arytmetycznych.
Tak samo jak wszędzie xD
(+ występuje też porównywanie typów przez `===` - identycznie jak w js)

#### Na czym polega konwersja typów danych i rzutowanie (casting) zmiennych?
Tak jak w js.
```php
<?
$string = "1";
$num = 2;
$result = $string + $num; // $string jest konwertowane na inta
$result2 = $string . $num; // $num jest konwertowane na string (Stringi nie dodają się przez '+'!)

$result3 = (int)$string + $num; // jawne rzutowanie

```

#### Sposoby inicjowania i indeksowanie tablic (również tablice asocjacyjne).
Inicializujemy każdy rodzaj tablicy przez `$arr = [wart?]` lub `$xx = array(wart?)`.
Dodajemy przez `$a[] = x` xD
```php
<?
$arr = [1]; // lub $arr = array(1);
$arr[] = 44;
$arr[] = 66; 
$arr[123] = 321;

print_r($arr);
/* Array
   (
       [0] => 1
       [1] => 44
       [2] => 66
       [10] => 321
   )*/
```
Asocjacyjne tablice (mapy) tworzym tak
```php
<?
$arr = ["start" => "koniec"];
$arr["mama"] = "tata";
$arr["wilk"] = 444;

echo $arr["mama"]; // tata
```


#### Sposoby „przeglądania” tablic i funkcje wspomagające te działania.
Możemy wypisać wszystko przez funkcję `print_r`.
Do indeksowej możemy zwykłym forem.
```php
<?
$arr = array("a", "b", "c");
for ($i = 0; $i < count($arr); $i++)
    echo "$i: $arr[$i] <br/>";
```
ale lepiej jest foreachem (Uwaga! Kolejność inna niż wszędzie xD)
```php
<?
$arr = array("a", "b", "c");
foreach ($arr as $item)
    echo "$item <br/>";
```
BO zwykłym forem można się przejechać xD
```php
<?
$arr = [1]; // lub $arr = array(1);
$arr[] = 44;
$arr[33] = 66; 
for ($i = 0; $i < count($arr); $i++)
    echo "($i): $arr[$i] | ";
// Wypisze (0): 1 | (1): 44 | (2):  | 
```
Dla asocjacyjnej:
```php
<?
$arr = ["start" => "koniec"];
foreach ($arr as $key => $value)
    echo "$key --> $value <br/>";
```

#### Jakich kontrolek używa się do wprowadzania danych do formularza? Kiedy, które stosować?
??? Nie wiem o co chodzi. O tagi html?


#### Która kontrolka formularza wyzwala zdarzenie wysłania danych? Jak określa się metodę wysyłania danych z formularza?
??? Chyba chodzi o htmla
`<form></form>` jest do wysyłania formularza, jak jest `<button type='submit'>` To on wysyła, a funkcję przed tym możemy
dodać w formie `<form onsubmit=funkcja()>`, a jak chcemy wszystko wysłać POSTem (defaultowo jest GET), to musimy dodać method.

```html
<form method="post" action="/url/to/send" onsubmit="funkcja()">

</form>
```
 
#### Jaka jest konstrukcja tablic superglobalnych, w szczególności $_POST?
Tablica asocjacyjna ze zmiennymi przekazanymi przez wysłanie żądania POST

```php
<?php 
echo $_POST['hehe'];
?>
<form method="post" action="/url/to/send" onsubmit="funkcja()">
    <input name="hehe">
</form>

```

#### Jak realizuje się walidację danych z formularza? 
Jak się chce xD Sprawdzasz w `$_POST` regexem czy jak tam potrzebujesz, wykorzystujesz metody
`preg_match` do sprawdzania regexa

### Php 2.13

#### Opisz sekwencję wymiany wiadomości, gdy klient i serwer korzystają z ciastek. W którym miejscu wiadomości HTTP przesyłane są ciastka?
Cookie są zapisywane w przeglądarce użytkownika i są wysyłane w każdym requeście (o ile w ścieżce nie podaliśmy inaczej) jako nagłówek HTTP.
Wymiana wygląda następująco
1) Przeglądarka wysyła żądanie HTTP
2) Serwer odpowiada dodając nagłówek `Set-Cookie: $nazwa=$wartosc`
3) Przeglądarka wysyła requesty już z dodatkowyn nagłówkiem `Cookie: $nazwa=$wartosc`
4) Serwer odpowiada normalnie i wszyscy są szczęśliwi

#### Omów działanie funkcji setcookie().
`setcookie` definiuje wartość ciastka, jakie będzie wysłane jako nagłówek w odpowiedzi serwera.
UWAGA! Wywołanie musi nastąpić przed tagiem `<html>` (zanim cokolwiek wyślemy do klienta).
Funkcję ma sygnaturę `setcookie(nazwaCiastka, wartosc, czas w którym ma wygasnąć, ścieżka na której ma być wysyłane ciastko);`
Rozważmy następujący przypadek:
```php
<?php 
setcookie("nazwa", "wartosc", time() + (60 * 60 * 24), "/");
?>
<html>
<body>
<?php echo $_COOKIE['nazwa']; ?>
</body>
</html>
```
Przy pierwszym załadowaniu strony serwer oprócz htmla zwróci header mówiący o potrzebie utworzenia ciasteczka przez przeglądarkę.
UWAGA! W tym momencie w tablicy `$_COOKIE` nic jeszcze nie ma!
Dopiero w ponownym żądaniu (kiedy przeglądarka wyśle nagłówek Cookie) będzie tam wartość.
#### Zastanów się nad funkcjonalnością stron w przypadku wyłączenia zapisu ciastek w przeglądarce. Czy jest jakieś alternatywne rozwiązanie?
Ogarnięcie czy są wyłaczone cookiesy można na 2 sposoby - w jsie jest easy, albo w phpie można ustawić ciastko, 
odświeżyć i sprawdzić, czy jest ustawione.
Ale co tu zrobić?

1) Można wysyłać id sesji w urlu (tak se bezpiecznie, ale zawsze działa). Można to easy zrobić w php
```php
<?
     ini_set("session.use_cookies", 0);
     ini_set("session.use_only_cookies", 0);
     ini_set("session.use_trans_sid", 1);
```
2) Można id sesji (lub jakiś jwt token) przesyłać w każdym żądaniu po stronie jsa, ale
to trzeba konfigurować w kliencie (js) i jest trudnij to zrobić

#### Opisz zasadę działania mechanizmu sesji. Omów działanie funkcji session_start().
`session_start` tworzy albo kontynuuje wcześniej stworzoną sesja (patrzy na wartość cookie PHPSESSID albo query stringa).
Tworzy to tymczasowy plik na serwerze (w odróżnieniu od ciastka, który jest zapisany w przeglądarce), w którym są
zapisane parametry jakie sobie zdefiniujemy.