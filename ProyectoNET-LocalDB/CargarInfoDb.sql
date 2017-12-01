SET IDENTITY_INSERT [dbo].[Modules] ON
INSERT INTO [dbo].[Modules] ([ID], [Name]) VALUES (1, N'Agiles')
INSERT INTO [dbo].[Modules] ([ID], [Name]) VALUES (2, N'Ingles')
SET IDENTITY_INSERT [dbo].[Modules] OFF


SET IDENTITY_INSERT [dbo].[Posts] ON
INSERT INTO [dbo].[Posts] ([Id], [DateTime], [Description], [ModuleID], [NameTeacher], [TeacherID], [Title]) VALUES (1, N'2017-11-30 00:00:00', N'efasczx ', 1, N'Sebastian Mansilla', 3, N'eqascx')
INSERT INTO [dbo].[Posts] ([Id], [DateTime], [Description], [ModuleID], [NameTeacher], [TeacherID], [Title]) VALUES (2, N'2017-11-30 00:00:00', N'Description Post Ingles 2', 2, N'Madia Burgos', 1, N'Titulo Post Ingles 2')
SET IDENTITY_INSERT [dbo].[Posts] OFF

SET IDENTITY_INSERT [dbo].[Teachers] ON
INSERT INTO [dbo].[Teachers] ([ID], [ModuleIDID], [Name]) VALUES (1, 2, N'Madia Burgos')
INSERT INTO [dbo].[Teachers] ([ID], [ModuleIDID], [Name]) VALUES (2, 1, N'Lucio Gabardini')
INSERT INTO [dbo].[Teachers] ([ID], [ModuleIDID], [Name]) VALUES (3, 1, N'Sebastian Mansilla')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
