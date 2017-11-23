USE [SmartVideoBD]
GO

/****** Object:  Table [dbo].[Location]    Script Date: 23-11-17 13:42:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[film_id] [int] NULL,
	[film_name] [varchar](100) NULL,
	[datedebut] [date] NULL,
	[datefin] [date] NULL,
	[user_id] [varchar](100) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([login])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_User]
GO

