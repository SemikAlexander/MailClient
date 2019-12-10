# MailClient

Почтовая программа (клиент электронной почты, почтовый клиент, мейл-клиент, мейлер) — программное обеспечение, устанавливаемое на компьютере пользователя и предназначенное для получения, написания, отправки и хранения сообщений электронной почты одного или нескольких пользователей (в случае, например, нескольких учётных записей на одном компьютере) или нескольких учётных записей одного пользователя.

Данный почтовый клиент написан с использованием библиотеки [MailKit](https://github.com/jstedfast/MailKit) и в данном клиенте очень много внимания уделяет защищённости данных.

Логин и пароль пользователя хранятся в базе [SQLite](https://www.sqlite.org/index.html) в зашифрованном виде с помощью семейства алгоритмов [SHA2](https://ru.wikipedia.org/wiki/SHA-2)

# СИНХРОНИЗАЦИЯ

В программе 5 основных папок:
- Входящие
- Отправленные
- Удалённые
- Спам
- Черновик

Синхронизация происходит в фоновом потоке.
После авторизации пользователя в системе проверяется количество сообщений в БД и на почтовом сервере. 
При неравном количестве сообщений данные в базе данных удаляются и заполняются заново.

Данные, полученные с помощью [IMAP](https://ru.wikipedia.org/wiki/IMAP) шифруются алгоритмом [Rijndael](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rijndael?view=netframework-4.8) в БД заносятся под следующими обозначениями:
- Входящие (INB) (также при считывании сообщений из папки "Входящие" проверяется прочитано сообщение, чтобы форматированно вывести список сообщений, а также ID сообщения)
- Отправленные (SNT)
- Удалённые (DEL)
- Спам (JNK)
- Черновик (DFT)
  
# ОТПРАВКА СООБЩЕНИЙ
  Отправка сообщения происходит по следующему алгоритму:
1. Зашифровать текст алгоритмом Rijndael (размер блока 128 бит).
2. Получить вектор и ключ, использующийся для шифрования в симметричном алгоритме.
3. Зашифровать ключ ассиметричным алгоритмом RSA (2048 бит) используя публичный ключ получателя. (Если такового нет программа предложит ввести ключ, чтобы запомнить его)
4. Зашифровать текст с помощью алгоритма SHA2 для электронноцифровой подписи.
5. Сформировать конечную строку.
6. Отправить сообщение через SMTP.
7. Занести изменения в базу данных.
  
# RSA
RSA (аббревиатура от фамилий создателей: Rivest, Shamir и Adleman) – один из самых популярных алгоритмов шифрования. Сначала несколько определений:
mod – операция взятия остатка от деления.
Взаимно простыми называются такие числа, которые не имеют между собой ни одного общего делителя, кроме единицы.

ШАГИ АЛГОРИТМА RSA

Последовательность шагов алгоритма RSA:
- выбрать два больших простых числа p и q;
- вычислить: n = p * q, m = (p – 1) * (q – 1);
- выбрать случайное число d, взаимно простое с m;
- определить такое число e, для которого является истинным выражение: (e ⋅ d) mod (m) = 1;
- числа e и n – это открытый ключ, а числа d и n – это закрытый ключ;
На практике это означает следующее: открытым ключом зашифровывают сообщение, а закрытым – расшифровывают. Пара чисел закрытого ключа держится в секрете.
- разбить шифруемый текст на блоки, каждый из которых может быть представлен в виде числа M(i);

Обычно блок берут равным одному символу и представляют этот символ в виду числа – его номера в алфавите или кода в таблице символов (например ASCII или Unicode).
- шифрование алгоритмом RSA производится по формуле: C(i) = (M(i)e) mod n;
- расшифровка сообщения производится с помощью формулы: M(i) = (C(i)d) mod n.
