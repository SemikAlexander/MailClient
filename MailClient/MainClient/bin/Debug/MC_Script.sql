﻿-- Script Date: 29.10.2019 22:49  - ErikEJ.SqlCeScripting version 3.5.2.81
CREATE TABLE [MailServers] (
  [ID] INTEGER NOT NULL
, [Name] TEXT NOT NULL
, [IMAPAdress] TEXT NOT NULL
, [IMAPPort] INTEGER NOT NULL
, [POP3Adress] TEXT NOT NULL
, [POP3Port] INTEGER NOT NULL
, [SMTPAdress] TEXT NOT NULL
, [SMTPPort] INTEGER NOT NULL
, CONSTRAINT [PK_MailServers] PRIMARY KEY ([ID])
);
