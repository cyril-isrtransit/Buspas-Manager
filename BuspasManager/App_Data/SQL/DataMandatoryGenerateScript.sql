USE [SIV_Message]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 07/19/2013 10:21:33 ******/
INSERT [dbo].[Status] ([Code], [Description]) VALUES (N'ARC       ', N'Archived')
INSERT [dbo].[Status] ([Code], [Description]) VALUES (N'BLK       ', N'Draft')
INSERT [dbo].[Status] ([Code], [Description]) VALUES (N'DEL       ', N'Deleted')
INSERT [dbo].[Status] ([Code], [Description]) VALUES (N'OFF       ', N'Inactive')
INSERT [dbo].[Status] ([Code], [Description]) VALUES (N'PUB       ', N'Active')
/****** Object:  Table [dbo].[SendingPriorities]    Script Date: 07/19/2013 10:21:33 ******/
SET IDENTITY_INSERT [dbo].[SendingPriorities] ON
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (1, N'Very Low', 1)
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (2, N'Low', 2)
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (3, N'Normal', 3)
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (4, N'High', 4)
INSERT [dbo].[SendingPriorities] ([ID], [Description], [Rank]) VALUES (5, N'Very High', 5)
SET IDENTITY_INSERT [dbo].[SendingPriorities] OFF
