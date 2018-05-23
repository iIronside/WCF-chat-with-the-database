USE master
GO

CREATE DATABASE WCFChat
GO

USE WCFChat
GO


-- ������������
CREATE TABLE [dbo].[������������](
	[ID������������] [smallint] PRIMARY KEY CLUSTERED IDENTITY(1,1),
	CONSTRAINT UN_������������_������������ID_Unique UNIQUE (ID������������),
	[�����] [nvarchar](50) NOT NULL,
	CONSTRAINT UN_������������_�����_Unique UNIQUE (�����),
	[������] [nvarchar](50) NOT NULL,
	[���] [nvarchar](50) NULL,
	[�������] [nvarchar](50) NULL,
	[��������] [nvarchar](50) NULL,
	[����_�����������] [date] NOT NULL,
	[����_���������_����������] [date] NOT NULL,
	)
GO

ALTER TABLE [dbo].[������������]
ADD CONSTRAINT [DF_������������_����_�����������] DEFAULT (getdate()) FOR [����_�����������]
GO

-- ���
CREATE TABLE [dbo].[���](
	[���ID] [smallint] PRIMARY KEY CLUSTERED IDENTITY(1,1),
	CONSTRAINT UN_���_���ID_Unique UNIQUE ([���ID]),
	[���_����] [nvarchar](150) NOT NULL,
	CONSTRAINT UN_���_����_Unique UNIQUE([���_����]),
	[�����] [nvarchar](50) NOT NULL,
	[�����������]  char(10) CHECK([�����������] IN ('���������', '���������')),
	)
GO


-- ���������
CREATE TABLE [dbo].[���������](
	[���������ID] [smallint] PRIMARY KEY CLUSTERED IDENTITY(1,1),
	CONSTRAINT UN_���������_ID��������z_Unique UNIQUE ([���������ID]),
	[�����] [nvarchar](3000) NOT NULL,
	[�����] [nvarchar](50) NOT NULL,
	[����_��������] [date] NOT NULL,
	[ID������������] [smallint] NOT NULL,
	CONSTRAINT FK_���������_ID������������ FOREIGN KEY([ID������������])
	REFERENCES [������������] ([ID������������]),
	[���ID] [smallint] NOT NULL,
	CONSTRAINT FK_���������_����ID FOREIGN KEY([���ID])
	REFERENCES [���] ([���ID])
	ON UPDATE CASCADE
	ON DELETE CASCADE
	)
GO

ALTER TABLE [dbo].[���������]
ADD CONSTRAINT DF_���������_����_�������� DEFAULT (getdate()) FOR [����_��������]
GO

SELECT * FROM ������������ WHERE ����� = 'John888' AND ������ = '888';

INSERT INTO ������������ ([�����], [������], [���], [�������], [��������], [����_�����������], [����_���������_����������]) VALUES
('John888', '888', 'vcxvc', 'bfbfxcbx', 'xbvcxcvbc', '1900-01-01', '1900-01-01 00:00:00.000');

INSERT INTO ��� ([���_����], [�����], [�����������]) VALUES
('�������1','����555','���������');

INSERT INTO ��� ([���_����], [�����], [�����������]) VALUES
('�������2','����555','���������');

INSERT INTO ��� ([���_����], [�����], [�����������]) VALUES
('�������3','John888','���������');

SELECT * FROM ���;

INSERT INTO ��������� ([�����], [�����], [����_��������], [ID������������], [���ID]) VALUES
('�������� ��������� SQL','John888', '2012-01-01 00:00:00.000', '6', '2');

SELECT chat.���ID
FROM ������������ userr
 INNER JOIN ��������� msg
  ON msg.ID������������ = userr.ID������������
INNER JOIN ��� chat 
ON chat.���ID = msg.���ID
Where msg.���ID = chat.���ID
Group By chat.���ID


Select * from ��� WHERE ���ID = 1 or ���ID = 3 or ���ID = 2

SELECT ���ID from ��������� WHERE ID������������ = 6 Group By ���ID

select ID������������ from ��������� where ���ID = 2 Group By ID������������