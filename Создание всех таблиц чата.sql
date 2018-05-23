USE master
GO

CREATE DATABASE WCFChat
GO

USE WCFChat
GO


-- Пользователь
CREATE TABLE [dbo].[Пользователь](
	[IDПользователя] [smallint] PRIMARY KEY CLUSTERED IDENTITY(1,1),
	CONSTRAINT UN_Пользователь_ПользователяID_Unique UNIQUE (IDПользователя),
	[Логин] [nvarchar](50) NOT NULL,
	CONSTRAINT UN_Пользователь_Логин_Unique UNIQUE (Логин),
	[Пароль] [nvarchar](50) NOT NULL,
	[Имя] [nvarchar](50) NULL,
	[Фамилия] [nvarchar](50) NULL,
	[Отчество] [nvarchar](50) NULL,
	[Дата_регистрации] [date] NOT NULL,
	[Дата_последней_активности] [date] NOT NULL,
	)
GO

ALTER TABLE [dbo].[Пользователь]
ADD CONSTRAINT [DF_Пользователь_Дата_Регистрации] DEFAULT (getdate()) FOR [Дата_Регистрации]
GO

-- Чат
CREATE TABLE [dbo].[Чат](
	[ЧатID] [smallint] PRIMARY KEY CLUSTERED IDENTITY(1,1),
	CONSTRAINT UN_Чат_ЧатID_Unique UNIQUE ([ЧатID]),
	[Имя_чата] [nvarchar](150) NOT NULL,
	CONSTRAINT UN_Имя_чата_Unique UNIQUE([Имя_чата]),
	[Автор] [nvarchar](50) NOT NULL,
	[Доступность]  char(10) CHECK([Доступность] IN ('Публичный', 'Приватный')),
	)
GO


-- Сообщение
CREATE TABLE [dbo].[Сообщение](
	[СообщениеID] [smallint] PRIMARY KEY CLUSTERED IDENTITY(1,1),
	CONSTRAINT UN_Сообщение_IDСообщениz_Unique UNIQUE ([СообщениеID]),
	[Текст] [nvarchar](3000) NOT NULL,
	[Автор] [nvarchar](50) NOT NULL,
	[Дата_создания] [date] NOT NULL,
	[IDПользователя] [smallint] NOT NULL,
	CONSTRAINT FK_Сообщение_IDПользователя FOREIGN KEY([IDПользователя])
	REFERENCES [Пользователь] ([IDПользователя]),
	[ЧатID] [smallint] NOT NULL,
	CONSTRAINT FK_Сообщение_ЧатаID FOREIGN KEY([ЧатID])
	REFERENCES [Чат] ([ЧатID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
	)
GO

ALTER TABLE [dbo].[Сообщение]
ADD CONSTRAINT DF_Сообщение_Дата_создания DEFAULT (getdate()) FOR [Дата_создания]
GO

SELECT * FROM Пользователь WHERE Логин = 'John888' AND Пароль = '888';

INSERT INTO Пользователь ([Логин], [Пароль], [Имя], [Фамилия], [Отчество], [Дата_регистрации], [Дата_последней_активности]) VALUES
('John888', '888', 'vcxvc', 'bfbfxcbx', 'xbvcxcvbc', '1900-01-01', '1900-01-01 00:00:00.000');

INSERT INTO Чат ([Имя_чата], [Автор], [Доступность]) VALUES
('ЧатТест1','Петя555','Публичный');

INSERT INTO Чат ([Имя_чата], [Автор], [Доступность]) VALUES
('ЧатТест2','Петя555','Публичный');

INSERT INTO Чат ([Имя_чата], [Автор], [Доступность]) VALUES
('ЧатТест3','John888','Публичный');

SELECT * FROM Чат;

INSERT INTO Сообщение ([Текст], [Автор], [Дата_создания], [IDПользователя], [ЧатID]) VALUES
('Тестовое сообщение SQL','John888', '2012-01-01 00:00:00.000', '6', '2');

SELECT chat.ЧатID
FROM Пользователь userr
 INNER JOIN Сообщение msg
  ON msg.IDПользователя = userr.IDПользователя
INNER JOIN Чат chat 
ON chat.ЧатID = msg.ЧатID
Where msg.ЧатID = chat.ЧатID
Group By chat.ЧатID


Select * from Чат WHERE ЧатID = 1 or ЧатID = 3 or ЧатID = 2

SELECT ЧатID from Сообщение WHERE IDПользователя = 6 Group By ЧатID

select IDПользователя from Сообщение where ЧатID = 2 Group By IDПользователя