# IToNeo
Простое приложение для учета компьютерной техники. Бекэнд приложение использует фреймворк asp.net core и слоистую архитектуру, а фронтенд приложение базируется на angular. Для запуска приложения применяются doker контейнеры. 

![](https://i.imgur.com/4QcBcEP.jpeg)

## Как запустить

Убедитесь что Вы установили и настроили Docker в своей среде. Для запуска приложения из каталога c исходным кодом введите команды:
```
docker-compose build
docker-compose up
```
>Note: Бекэнд запускается дольше фронтенда.

Приложение доступно по url: 
```
WebSPA: https://localhost:44396/
WebAPI:  https://localhost:44394/
```
>Note: Браузер и антивирусная программа посчитают сертификаты безопасности WebSPA и WebAPI не доверительными, потребуется добавить их в исключения.

Для аутентификации и авторизации используете следующие учетные данные:
```
admin@test.ru:Pass@word1
operator@test.ru:Pass@word1
user@test.ru:Pass@word1
```

## Скриншоты

![](https://i.imgur.com/z7ibLZJ.jpeg)

![](https://i.imgur.com/kj6Tl04.jpg)

![](https://imgur.com/vY1K04T.jpg)

![](https://imgur.com/tW8SSvh.jpg)

![](https://imgur.com/suRtFbA.jpg)

![](https://imgur.com/1pXXJv9.jpg)

![](https://imgur.com/53Gjfrq.jpg)
