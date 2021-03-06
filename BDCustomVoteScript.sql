
/****** Object:  Table [dbo].[Enterprise]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enterprise](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessName] [nvarchar](255) NULL,
	[Representative] [nvarchar](255) NULL,
	[NIF] [int] NULL,
	[Address] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogVote]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogVote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VoteId] [int] NULL,
	[UserIp] [nvarchar](255) NULL,
	[UserMac] [nvarchar](255) NULL,
	[UserVoteId] [int] NULL,
	[DateTimeVote] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeGraphic]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeGraphic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeUser]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCrendential]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCrendential](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[TypeUserId] [int] NULL,
	[NameUser] [nvarchar](255) NULL,
	[Lastname] [nvarchar](255) NULL,
	[DNI] [nvarchar](255) NULL,
	[EnterpriseId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserVote]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserVote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[TypeUserId] [int] NULL,
	[VotationId] [int] NULL,
	[NameUser] [nvarchar](255) NULL,
	[LastNameUser] [nvarchar](255) NULL,
	[DocumentNumber] [nvarchar](255) NULL,
	[EnterpriseId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votation]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Users] [int] NULL,
	[Title] [nvarchar](255) NULL,
	[Status] [int] NULL,
	[Type] [nvarchar](255) NULL,
	[Diapositive] [bit] NOT NULL,
	[NDiapositive] [int] NULL,
	[UserId] [int] NULL,
	[QuestionStart] [int] NULL,
	[EnterpriseId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votation_Graphic]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votation_Graphic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VotationId] [int] NULL,
	[GraphicId] [int] NULL,
	[ImageG] [nvarchar](255) NULL,
	[Width] [int] NULL,
	[Heigth] [int] NULL,
	[Transparent] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votation_Options]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votation_Options](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VotationId] [int] NULL,
	[Letter] [nvarchar](255) NULL,
	[ValueOption] [nvarchar](255) NULL,
	[Color] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votation_Questions]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votation_Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VotationId] [int] NULL,
	[Order] [int] NULL,
	[Question] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votation_Questions_Answer]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votation_Questions_Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NULL,
	[Answer] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Votation_URL]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votation_URL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VotationId] [int] NULL,
	[KeyVotation] [nvarchar](max) NULL,
	[URLVotation] [nvarchar](max) NULL,
	[Order] [int] NULL,
	[QuestionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 08/04/2020 4:57:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VotationId] [int] NULL,
	[MAC] [nvarchar](255) NULL,
	[UserVoteId] [int] NULL,
	[Result] [nvarchar](255) NULL,
	[QuestionId] [int] NULL,
	[FHVote] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[LogVote]  WITH CHECK ADD FOREIGN KEY([UserVoteId])
REFERENCES [dbo].[UserVote] ([Id])
GO
ALTER TABLE [dbo].[LogVote]  WITH CHECK ADD FOREIGN KEY([VoteId])
REFERENCES [dbo].[Vote] ([Id])
GO
ALTER TABLE [dbo].[UserCrendential]  WITH CHECK ADD FOREIGN KEY([EnterpriseId])
REFERENCES [dbo].[Enterprise] ([Id])
GO
ALTER TABLE [dbo].[UserCrendential]  WITH CHECK ADD FOREIGN KEY([TypeUserId])
REFERENCES [dbo].[TypeUser] ([Id])
GO
ALTER TABLE [dbo].[UserVote]  WITH CHECK ADD FOREIGN KEY([EnterpriseId])
REFERENCES [dbo].[Enterprise] ([Id])
GO
ALTER TABLE [dbo].[UserVote]  WITH CHECK ADD FOREIGN KEY([EnterpriseId])
REFERENCES [dbo].[Enterprise] ([Id])
GO
ALTER TABLE [dbo].[UserVote]  WITH CHECK ADD FOREIGN KEY([TypeUserId])
REFERENCES [dbo].[TypeUser] ([Id])
GO
ALTER TABLE [dbo].[UserVote]  WITH CHECK ADD FOREIGN KEY([VotationId])
REFERENCES [dbo].[Votation] ([Id])
GO
ALTER TABLE [dbo].[Votation]  WITH CHECK ADD FOREIGN KEY([EnterpriseId])
REFERENCES [dbo].[Enterprise] ([Id])
GO
ALTER TABLE [dbo].[Votation]  WITH CHECK ADD FOREIGN KEY([EnterpriseId])
REFERENCES [dbo].[Enterprise] ([Id])
GO
ALTER TABLE [dbo].[Votation]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserCrendential] ([Id])
GO
ALTER TABLE [dbo].[Votation_Graphic]  WITH CHECK ADD FOREIGN KEY([GraphicId])
REFERENCES [dbo].[TypeGraphic] ([Id])
GO
ALTER TABLE [dbo].[Votation_Graphic]  WITH CHECK ADD FOREIGN KEY([VotationId])
REFERENCES [dbo].[Votation] ([Id])
GO
ALTER TABLE [dbo].[Votation_Options]  WITH CHECK ADD FOREIGN KEY([VotationId])
REFERENCES [dbo].[Votation] ([Id])
GO
ALTER TABLE [dbo].[Votation_Questions]  WITH CHECK ADD FOREIGN KEY([VotationId])
REFERENCES [dbo].[Votation] ([Id])
GO
ALTER TABLE [dbo].[Votation_Questions_Answer]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Votation_Questions] ([Id])
GO
ALTER TABLE [dbo].[Votation_URL]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Votation_Questions] ([Id])
GO
ALTER TABLE [dbo].[Votation_URL]  WITH CHECK ADD FOREIGN KEY([VotationId])
REFERENCES [dbo].[Votation] ([Id])
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Votation_Questions] ([Id])
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD FOREIGN KEY([UserVoteId])
REFERENCES [dbo].[UserVote] ([Id])
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD FOREIGN KEY([VotationId])
REFERENCES [dbo].[Votation] ([Id])
GO
USE [master]
GO
ALTER DATABASE [CustomVoteDb] SET  READ_WRITE 
GO
