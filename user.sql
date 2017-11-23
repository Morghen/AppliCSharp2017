USE [SmartVideoBD]
GO

/****** Object:  Table [dbo].[User]    Script Date: 23-11-17 13:43:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[login] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[prenom] [varchar](100) NULL,
	[nom] [varchar](100) NULL,
	[codepostal] [int] NULL,
	[ville] [varchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

