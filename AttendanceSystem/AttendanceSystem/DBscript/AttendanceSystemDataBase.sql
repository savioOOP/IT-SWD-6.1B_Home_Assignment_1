USE [AttendanceSystem]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 15/01/2021 15:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Course] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 15/01/2021 15:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[LessonID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[TeacherID] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAttendances]    Script Date: 15/01/2021 15:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendances](
	[AttendanceID] [int] IDENTITY(1,1) NOT NULL,
	[LessonID] [int] NOT NULL,
	[Pressence] [bit] NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_StudentAttendances] PRIMARY KEY CLUSTERED 
(
	[AttendanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 15/01/2021 15:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 15/01/2021 15:31:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 
GO
INSERT [dbo].[Groups] ([GroupID], [Name], [Course]) VALUES (1, N'Group 1', N'Name1')
GO
INSERT [dbo].[Groups] ([GroupID], [Name], [Course]) VALUES (2, N'TestGroup', N'ASD')
GO
INSERT [dbo].[Groups] ([GroupID], [Name], [Course]) VALUES (3, N'ThirdGroup', N'OOP')
GO
INSERT [dbo].[Groups] ([GroupID], [Name], [Course]) VALUES (4, N'sdsad', N'333')
GO
INSERT [dbo].[Groups] ([GroupID], [Name], [Course]) VALUES (5, N'Group4', N'NotTestedYet')
GO
INSERT [dbo].[Groups] ([GroupID], [Name], [Course]) VALUES (6, N'Group6', N'GroupName6')
GO
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessons] ON 
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (1, 1, CAST(N'2021-01-14T20:36:36.347' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (2, 2, CAST(N'2021-01-14T20:42:42.897' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (3, 2, CAST(N'2021-01-14T20:45:20.947' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (4, 2, CAST(N'2021-01-14T20:46:58.900' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (5, 2, CAST(N'2021-01-14T20:47:26.743' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (6, 2, CAST(N'2021-01-14T21:26:32.420' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (7, 1, CAST(N'2021-01-14T21:27:37.063' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (8, 1, CAST(N'2021-01-14T21:27:46.343' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (9, 1, CAST(N'2021-01-14T21:27:54.290' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (10, 1, CAST(N'2021-01-14T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (11, 3, CAST(N'2021-01-15T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (12, 3, CAST(N'2021-01-15T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[Lessons] ([LessonID], [GroupID], [DateTime], [TeacherID]) VALUES (13, 5, CAST(N'2021-01-15T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Lessons] OFF
GO
SET IDENTITY_INSERT [dbo].[StudentAttendances] ON 
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (1, 2, 1, 2)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (2, 2, 0, 4)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (3, 3, 1, 2)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (4, 5, 1, 2)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (5, 5, 1, 4)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (6, 6, 0, 2)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (7, 6, 1, 4)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (8, 7, 1, 1)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (9, 8, 0, 1)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (10, 9, 1, 1)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (11, 10, 0, 1)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (12, 11, 1, 7)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (13, 12, 0, 7)
GO
INSERT [dbo].[StudentAttendances] ([AttendanceID], [LessonID], [Pressence], [StudentID]) VALUES (14, 13, 1, 9)
GO
SET IDENTITY_INSERT [dbo].[StudentAttendances] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (1, N'CHG', N'SAV', N'savx@gmail.com', 1)
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (2, N'Savio', N'CAuchi', N'hello@gail.com', 2)
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (4, N'DoneWithoutLogic', N'fakeStudent', N'fake@gmail.com', 2)
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (7, N'Savio', N'Cauchii', N'savi@gmail.com', 3)
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (8, N'ChangedName', N'ChangedSurname', N'change@gmail.com', 2)
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (9, N'StudentForGroup', N'StudentC', N'st@gmail.com', 5)
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Surname], [Email], [GroupID]) VALUES (10, N'Student6', N'Name6', N'stude"gmail.com', 6)
GO
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 
GO
INSERT [dbo].[Teachers] ([TeacherID], [Username], [Password], [Name], [Surname], [Email]) VALUES (1, N'teacher', N'123', N'teachername', N'test', N'teacher@gmail.com')
GO
INSERT [dbo].[Teachers] ([TeacherID], [Username], [Password], [Name], [Surname], [Email]) VALUES (2, N'teacher2', N'321', N'SAvio', N'Cauchi', N'sav@gmail.com')
GO
INSERT [dbo].[Teachers] ([TeacherID], [Username], [Password], [Name], [Surname], [Email]) VALUES (3, N'OOPTeacher', N'oop', N'Savio', N'Cauchi', N'oop@gmail.com')
GO
INSERT [dbo].[Teachers] ([TeacherID], [Username], [Password], [Name], [Surname], [Email]) VALUES (4, N'DoNotTouch', N'nothing', N'DoNot', N'Touch', N'this@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Groups]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lessons_Teachers] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lessons_Teachers]
GO
ALTER TABLE [dbo].[StudentAttendances]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendances_Lessons] FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lessons] ([LessonID])
GO
ALTER TABLE [dbo].[StudentAttendances] CHECK CONSTRAINT [FK_StudentAttendances_Lessons]
GO
ALTER TABLE [dbo].[StudentAttendances]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendances_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[StudentAttendances] CHECK CONSTRAINT [FK_StudentAttendances_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO
