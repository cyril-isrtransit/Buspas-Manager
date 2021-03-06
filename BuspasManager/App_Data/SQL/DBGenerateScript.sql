USE [master]
GO
/****** Object:  Database [SIV_Message]    Script Date: 07/19/2013 10:19:25 ******/
CREATE DATABASE [SIV_Message] ON  PRIMARY 
( NAME = N'SIV_Message', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\SIV_Message.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SIV_Message_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\SIV_Message_1.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SIV_Message] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SIV_Message].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SIV_Message] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SIV_Message] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SIV_Message] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SIV_Message] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SIV_Message] SET ARITHABORT OFF
GO
ALTER DATABASE [SIV_Message] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SIV_Message] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SIV_Message] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SIV_Message] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SIV_Message] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SIV_Message] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SIV_Message] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SIV_Message] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SIV_Message] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SIV_Message] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SIV_Message] SET  DISABLE_BROKER
GO
ALTER DATABASE [SIV_Message] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SIV_Message] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SIV_Message] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SIV_Message] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SIV_Message] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SIV_Message] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SIV_Message] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SIV_Message] SET  READ_WRITE
GO
ALTER DATABASE [SIV_Message] SET RECOVERY SIMPLE
GO
ALTER DATABASE [SIV_Message] SET  MULTI_USER
GO
ALTER DATABASE [SIV_Message] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SIV_Message] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SIV_Message', N'ON'
GO
USE [SIV_Message]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Code] [nchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AudioCircuitStopCriteria]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudioCircuitStopCriteria](
	[Criteria] [nchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AudioCircuitStopCriteria] PRIMARY KEY CLUSTERED 
(
	[Criteria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgStatusLog]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgStatusLog](
	[MsgID] [bigint] NOT NULL,
	[Code] [nchar](10) NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserName] [nvarchar](max) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supports]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supports](
	[Code] [nchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Support] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Code] [nchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SpeakersLocation]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpeakersLocation](
	[Code] [nchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SpeakersLocation] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SIV_MsgHist]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SIV_MsgHist](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MessageID] [bigint] NOT NULL,
	[SupportCode] [nchar](10) NOT NULL,
	[StRtTimeStamp] [datetime] NULL,
	[SentTimeStamp] [datetime] NOT NULL,
	[VehicleID] [nvarchar](50) NULL,
	[RouteNumber] [nvarchar](20) NULL,
	[StopID] [nvarchar](50) NULL,
	[MessageText] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SIV_MsgHist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SendingPriorities]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SendingPriorities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Rank] [tinyint] NOT NULL,
 CONSTRAINT [PK_SendingPriorities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PredefinedMessages]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PredefinedMessages](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoriedID] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_PredefinedMessages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategorieID] [int] NULL,
	[Title] [nvarchar](max) NULL,
	[StatusCode] [nchar](10) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[CreationUser] [nvarchar](max) NULL,
	[CreationDate] [datetime] NULL,
	[LastUpdateUser] [nvarchar](max) NULL,
	[LastUpdateDate] [datetime] NULL,
	[SendingPriority] [int] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgSchedules]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgSchedules](
	[MsgID] [bigint] NOT NULL,
	[DayOfWeek] [tinyint] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
 CONSTRAINT [PK_MSG_Schedules] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[DayOfWeek] ASC,
	[StartTime] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PredefinedMsgTexts]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PredefinedMsgTexts](
	[MsgID] [bigint] NOT NULL,
	[LanguageCode] [nchar](10) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PredefinedMsgTexts] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[LanguageCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgAudioCircuits]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgAudioCircuits](
	[MsgID] [bigint] NOT NULL,
	[CircuitID] [nvarchar](50) NOT NULL,
	[Direction] [nchar](10) NOT NULL,
	[Variant] [nchar](10) NOT NULL,
	[IncludeDoubleur] [bit] NOT NULL,
	[StopCriteria] [nchar](10) NOT NULL,
	[Distance] [int] NOT NULL,
	[SpeakersLocation] [nchar](10) NOT NULL,
 CONSTRAINT [PK_MsgAudioCircuits] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[CircuitID] ASC,
	[Direction] ASC,
	[Variant] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgAudio]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgAudio](
	[MsgID] [bigint] NOT NULL,
	[LanguageCode] [nchar](10) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MSG_Audio_Details] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[LanguageCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgTexts]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgTexts](
	[MsgID] [bigint] NOT NULL,
	[LanguageCode] [nchar](10) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MSG_Details] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[LanguageCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgSupports]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgSupports](
	[MsgID] [bigint] NOT NULL,
	[SupportCode] [nchar](10) NOT NULL,
	[Frequency] [smallint] NOT NULL,
 CONSTRAINT [PK_MSG_Supports] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[SupportCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgStops]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgStops](
	[MsgID] [bigint] NOT NULL,
	[SupportCode] [nchar](10) NOT NULL,
	[StopID] [nvarchar](50) NOT NULL,
	[Circuits] [nvarchar](max) NULL,
 CONSTRAINT [PK_MsgStops] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[SupportCode] ASC,
	[StopID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgCircuits]    Script Date: 07/19/2013 10:19:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgCircuits](
	[MsgID] [bigint] NOT NULL,
	[SupportCode] [nchar](10) NOT NULL,
	[CircuitID] [nvarchar](50) NOT NULL,
	[StartPoint] [nvarchar](50) NULL,
	[EndPoint] [nvarchar](50) NULL,
	[IncludeDoubleur] [bit] NOT NULL,
	[Direction] [nchar](10) NOT NULL,
	[Variant] [nchar](10) NOT NULL,
 CONSTRAINT [PK_MsgCircuits] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC,
	[SupportCode] ASC,
	[CircuitID] ASC,
	[Direction] ASC,
	[Variant] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Languages_Active]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[Languages] ADD  CONSTRAINT [DF_Languages_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  Default [DF_Messages_StatusCode]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_StatusCode]  DEFAULT (N'BLK') FOR [StatusCode]
GO
/****** Object:  Default [DF_Messages_SendingPriority]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_SendingPriority]  DEFAULT ((3)) FOR [SendingPriority]
GO
/****** Object:  Default [DF_MsgAudioCircuits_IncludeDoubleur]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudioCircuits] ADD  CONSTRAINT [DF_MsgAudioCircuits_IncludeDoubleur]  DEFAULT ((1)) FOR [IncludeDoubleur]
GO
/****** Object:  Default [DF_MsgAudioCircuits_Distance]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudioCircuits] ADD  CONSTRAINT [DF_MsgAudioCircuits_Distance]  DEFAULT ((0)) FOR [Distance]
GO
/****** Object:  Default [DF_MsgAudioCircuits_SpeakersLocation]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudioCircuits] ADD  CONSTRAINT [DF_MsgAudioCircuits_SpeakersLocation]  DEFAULT (N'Indoor') FOR [SpeakersLocation]
GO
/****** Object:  Default [DF_MsgCircuits_IncludeDoubleur]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgCircuits] ADD  CONSTRAINT [DF_MsgCircuits_IncludeDoubleur]  DEFAULT ((1)) FOR [IncludeDoubleur]
GO
/****** Object:  ForeignKey [FK_SpeakersLocation_SpeakersLocation]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[SpeakersLocation]  WITH CHECK ADD  CONSTRAINT [FK_SpeakersLocation_SpeakersLocation] FOREIGN KEY([Code])
REFERENCES [dbo].[SpeakersLocation] ([Code])
GO
ALTER TABLE [dbo].[SpeakersLocation] CHECK CONSTRAINT [FK_SpeakersLocation_SpeakersLocation]
GO
/****** Object:  ForeignKey [FK_PredefinedMessages_Categories]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[PredefinedMessages]  WITH CHECK ADD  CONSTRAINT [FK_PredefinedMessages_Categories] FOREIGN KEY([CategoriedID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[PredefinedMessages] CHECK CONSTRAINT [FK_PredefinedMessages_Categories]
GO
/****** Object:  ForeignKey [FK_Messages_Categories]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Categories] FOREIGN KEY([CategorieID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Categories]
GO
GO
SET IDENTITY_INSERT [dbo].[SendingPriorities] ON 

GO
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (1, N'Very Low', 1)
GO
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (2, N'Low', 2)
GO
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (3, N'Normal', 3)
GO
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (4, N'High', 4)
GO
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (5, N'Very High', 5)
GO
SET IDENTITY_INSERT [dbo].[SendingPriorities] OFF
GO
/****** Object:  ForeignKey [FK_Messages_SendingPriorities]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_SendingPriorities] FOREIGN KEY([SendingPriority])
REFERENCES [dbo].[SendingPriorities] ([ID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_SendingPriorities]
GO
/****** Object:  ForeignKey [FK_Messages_Status]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Status] FOREIGN KEY([StatusCode])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Status]
GO
/****** Object:  ForeignKey [FK_MSG_Schedules_Messages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgSchedules]  WITH CHECK ADD  CONSTRAINT [FK_MSG_Schedules_Messages] FOREIGN KEY([MsgID])
REFERENCES [dbo].[Messages] ([ID])
GO
ALTER TABLE [dbo].[MsgSchedules] CHECK CONSTRAINT [FK_MSG_Schedules_Messages]
GO
/****** Object:  ForeignKey [FK_PredefinedMsgTexts_Languages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[PredefinedMsgTexts]  WITH CHECK ADD  CONSTRAINT [FK_PredefinedMsgTexts_Languages] FOREIGN KEY([LanguageCode])
REFERENCES [dbo].[Languages] ([Code])
GO
ALTER TABLE [dbo].[PredefinedMsgTexts] CHECK CONSTRAINT [FK_PredefinedMsgTexts_Languages]
GO
/****** Object:  ForeignKey [FK_PredefinedMsgTexts_PredefinedMessages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[PredefinedMsgTexts]  WITH CHECK ADD  CONSTRAINT [FK_PredefinedMsgTexts_PredefinedMessages] FOREIGN KEY([MsgID])
REFERENCES [dbo].[PredefinedMessages] ([ID])
GO
ALTER TABLE [dbo].[PredefinedMsgTexts] CHECK CONSTRAINT [FK_PredefinedMsgTexts_PredefinedMessages]
GO
/****** Object:  ForeignKey [FK_Message_MsgAudioCircuits]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudioCircuits]  WITH CHECK ADD  CONSTRAINT [FK_Message_MsgAudioCircuits] FOREIGN KEY([MsgID])
REFERENCES [dbo].[Messages] ([ID])
GO
ALTER TABLE [dbo].[MsgAudioCircuits] CHECK CONSTRAINT [FK_Message_MsgAudioCircuits]
GO
/****** Object:  ForeignKey [FK_MsgAudioCircuits_AudioCircuitStopCriteria]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudioCircuits]  WITH CHECK ADD  CONSTRAINT [FK_MsgAudioCircuits_AudioCircuitStopCriteria] FOREIGN KEY([StopCriteria])
REFERENCES [dbo].[AudioCircuitStopCriteria] ([Criteria])
GO
ALTER TABLE [dbo].[MsgAudioCircuits] CHECK CONSTRAINT [FK_MsgAudioCircuits_AudioCircuitStopCriteria]
GO
/****** Object:  ForeignKey [FK_MsgAudioCircuits_MsgAudioCircuits]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudioCircuits]  WITH CHECK ADD  CONSTRAINT [FK_MsgAudioCircuits_MsgAudioCircuits] FOREIGN KEY([SpeakersLocation])
REFERENCES [dbo].[SpeakersLocation] ([Code])
GO
ALTER TABLE [dbo].[MsgAudioCircuits] CHECK CONSTRAINT [FK_MsgAudioCircuits_MsgAudioCircuits]
GO
/****** Object:  ForeignKey [FK_MSG_Audio_Languages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudio]  WITH CHECK ADD  CONSTRAINT [FK_MSG_Audio_Languages] FOREIGN KEY([LanguageCode])
REFERENCES [dbo].[Languages] ([Code])
GO
ALTER TABLE [dbo].[MsgAudio] CHECK CONSTRAINT [FK_MSG_Audio_Languages]
GO
/****** Object:  ForeignKey [FK_MSG_Audio_Messages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgAudio]  WITH CHECK ADD  CONSTRAINT [FK_MSG_Audio_Messages] FOREIGN KEY([MsgID])
REFERENCES [dbo].[Messages] ([ID])
GO
ALTER TABLE [dbo].[MsgAudio] CHECK CONSTRAINT [FK_MSG_Audio_Messages]
GO
/****** Object:  ForeignKey [FK_MSG_Text_Languages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgTexts]  WITH CHECK ADD  CONSTRAINT [FK_MSG_Text_Languages] FOREIGN KEY([LanguageCode])
REFERENCES [dbo].[Languages] ([Code])
GO
ALTER TABLE [dbo].[MsgTexts] CHECK CONSTRAINT [FK_MSG_Text_Languages]
GO
/****** Object:  ForeignKey [FK_MSG_Text_Messages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgTexts]  WITH CHECK ADD  CONSTRAINT [FK_MSG_Text_Messages] FOREIGN KEY([MsgID])
REFERENCES [dbo].[Messages] ([ID])
GO
ALTER TABLE [dbo].[MsgTexts] CHECK CONSTRAINT [FK_MSG_Text_Messages]
GO
/****** Object:  ForeignKey [FK_MSG_Supports_Messages]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgSupports]  WITH CHECK ADD  CONSTRAINT [FK_MSG_Supports_Messages] FOREIGN KEY([MsgID])
REFERENCES [dbo].[Messages] ([ID])
GO
ALTER TABLE [dbo].[MsgSupports] CHECK CONSTRAINT [FK_MSG_Supports_Messages]
GO
/****** Object:  ForeignKey [FK_MSG_Supports_Supports]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgSupports]  WITH CHECK ADD  CONSTRAINT [FK_MSG_Supports_Supports] FOREIGN KEY([SupportCode])
REFERENCES [dbo].[Supports] ([Code])
GO
ALTER TABLE [dbo].[MsgSupports] CHECK CONSTRAINT [FK_MSG_Supports_Supports]
GO
/****** Object:  ForeignKey [FK_MsgStops_MsgSupports]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgStops]  WITH CHECK ADD  CONSTRAINT [FK_MsgStops_MsgSupports] FOREIGN KEY([MsgID], [SupportCode])
REFERENCES [dbo].[MsgSupports] ([MsgID], [SupportCode])
GO
ALTER TABLE [dbo].[MsgStops] CHECK CONSTRAINT [FK_MsgStops_MsgSupports]
GO
/****** Object:  ForeignKey [FK_MsgCircuits_MsgSupports]    Script Date: 07/19/2013 10:19:26 ******/
ALTER TABLE [dbo].[MsgCircuits]  WITH CHECK ADD  CONSTRAINT [FK_MsgCircuits_MsgSupports] FOREIGN KEY([MsgID], [SupportCode])
REFERENCES [dbo].[MsgSupports] ([MsgID], [SupportCode])
GO
ALTER TABLE [dbo].[MsgCircuits] CHECK CONSTRAINT [FK_MsgCircuits_MsgSupports]
GO
