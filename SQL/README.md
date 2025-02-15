# **Задание 1: Работа с базой данных (****MSSQL****)**

## **Часть 1: Создание таблиц**

Напишите скрипты для создания двух таблиц в MS SQL:

1. **Таблица Контейнеров** с полями:

- ИД (тип: уникальный идентификатор)
- Номер (тип: числовой)
- Тип (тип: текстовый)
- Длина (тип: числовой)
- Ширина (тип: числовой)
- Высота (тип: числовой)
- Вес (тип: числовой)
- Пустой/не пустой (тип: бит)
- Дата поступления (тип: дата/время)

2. **Таблица Операций** с полями:

- ИД (тип: уникальный идентификатор)
- ИД Контейнера (тип: уникальный идентификатор)
- Дата начала операции (тип: дата/время)
- Дата окончания операции (тип: дата/время)
- Тип операции (тип: текстовый)
- ФИО оператора (тип: текстовый)
- Место инспекции (тип: текстовый)

Реализуется в файле **!initial.sql**.

## **Часть 2: Запросы**

1. Напишите запрос, который выбирает все данные из таблицы Контейнеров в формате JSON, не используя встроенные функции.
2. Напишите запрос, который выбирает все данные из таблицы Операций для определенного контейнера в формате JSON, не используя встроенные функции.

Реализуется в хранимой процедуре **sp_TableToJson**, которая динамически конвертирует указанную таблицу в JSON формат.

## **Инструкция**
**Пререквизиты**: созданная база данных.
1. Запустить запрос **!initial.sql**.
2. Создать процедуру, выполнив запрос из файла **sp_TableToJson.sql**. Перед созданием процедуры требуется добавить в базу необходимые функции путем поочередного выполнения запросов из файлов **fnAddSeparator.sql** и **fnQuoteString.sql**.
3. Создать новый запрос, в нём выполнить запрос вида EXEC sp_TableToJson @tableName = имяТаблицы
