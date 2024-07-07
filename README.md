# Online Store
Веб-приложение интернет-магазина.\
\

Docker образ приложения: https://hub.docker.com/repository/docker/kirillfisenko/online_shop_web_app/general \
Docker образ БД: https://hub.docker.com/_/microsoft-mssql-server 
## Используемые технологии и библиотеки
- ASP.NET CORE
- шаблон Model-View-Controller (MVC)
- Razor pages
- Bootstrap
- HTML, CSS, JS
- LINQ
- MS SQL Server
- Entity Framework (EF)
- Docker
- ASP.NET Identity (система аутентификации и авторизации)
- MimeKit (работа с электронной почтой)
- Serilog (журналы для диагностики)
- Яндекс JavaScript API и HTTP Геокодер (интерактивная карта)
- Яндекс API Геосаджеста (быстрый ввод и проверка адресов)
---
> [!NOTE]
> Для тестирования функций администратора:\
*логин: proPConlineShop@gmail.com*\
*пароль: adminADMIN123$*
---
## Описание приложения 
Веб-приложение интернет-магазина состоит из двух проектов:
- "**OnlineShopWebApp**" (*ASP.NET Core Web App Model-View-Controller*)\
Веб-приложение основано на шаблоне Model-View-Controller.
Функционал администратора выделен в область (area) "Admin". Администратор может управлять товарами, заказами, ролями и пользователями.
Пользователь может войти/зарегистрироваться, сбросить пароль, редактировать свои данные, просмотреть свои заказы, добавить товар в корзину и оформить заказ, добавить товар в избранное, добавить товар в сравнение. Только зарегистрированный пользователь может совершать действия "добавления". 
Для сопоставления моделей БД и представлений подключен сервис автомаппинга.
Для логирования запросов подключена библиотека Serilog.
Все репозитории добавлены в коллекцию сервисов, внедрены зависимости (Dependency Injection).
Валидация данных осуществляется как на клиенте (использование атрибутов валидации при объявлении модели), так и на стороне сервера (ModelState.IsValid).
При попытке удаления данных (товаров, пользователей, ролей) использованы модальные окна для подтверждения операций.
Представления используют Razor pages, что позволяет писать код C# в разметке HTML. Используется CSS-фреймворк Bootstrap для упрощения работы с Frontend.
При вводе адреса реализовано автоматическое дополнение с помощью Яндекс API Геосаджеста и отображение адреса на карте с помощью Яндекс JavaScript API и HTTP Геокодер.
При регистрации нового пользователя реализовано подтверждение электронной почты, а также сброс и восстановление пароля с помощью сервиса MimeKit.
Header, footer и боковое меню выполнены в виде частичных представлений.
Отображение аватара пользователя, количества товаров в корзине, избранном и списке сравнения реализовано с помощью компонент представлений.

- "**OnlineShop.Db**" (*Class Library*)\
Все объекты приложения хранятся в БД Microsoft SQL Server. База данных состоит из двух контекстов: DatabaseContext и IdentityContext. В первом хранятся все данные, связанные с продуктами и заказами. Второй контекст реализован с помощью ASP.NET Identity - системы аутентификации и авторизации, встроенной в ASP.NET. Здесь хранятся все данные, связанные с пользователями.
Взаимодействие с БД реализовано через Entity Framework (EF).
При запуске приложения проверяется, существуют ли роли Admin и User, а также пользователь "администратор по умолчанию". При необходимости они создаются.
Если пользователь авторизовался с данными администратора, ему доступно соответствующее меню.
Работа с изображениями реализована с помощью интерфейса IFormFile.
В проекте применяются автоматические миграции.
Методы, которые обращаются к БД, выполняются асинхронно.



![image](https://github.com/KirillFisenko/OnlineStore/assets/120630673/0247556f-0811-4eb7-a797-11d56cd75eca)

![image](https://github.com/KirillFisenko/OnlineStore/assets/120630673/36d3d1e3-fad2-4279-9794-f962b6a726a8)

![image](https://github.com/KirillFisenko/OnlineStore/assets/120630673/00133d4b-ea48-494b-9f8d-457c39bb1417)

