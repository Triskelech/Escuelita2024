/****** Object:  Table [dbo].[Transfer]    Script Date: 13/01/2024 07:34:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transfer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[Amount] [int] NOT NULL,
	[OriginAccountId] [int] NOT NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transfer]  WITH CHECK ADD  CONSTRAINT [FK_Transfer_Account_OriginAccountId] FOREIGN KEY([OriginAccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Transfer] CHECK CONSTRAINT [FK_Transfer_Account_OriginAccountId]
GO


