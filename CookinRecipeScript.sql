USE [master]
GO
/****** Object:  Database [CookinRecipe]    Script Date: 09/06/2025 08:31:00 ******/
CREATE DATABASE [CookinRecipe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CookinRecipe', FILENAME = N'D:\CookinRecipe\DATA\CookinRecipe.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CookinRecipe_log', FILENAME = N'D:\CookinRecipe\DATA\CookinRecipe_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CookinRecipe] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CookinRecipe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CookinRecipe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CookinRecipe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CookinRecipe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CookinRecipe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CookinRecipe] SET ARITHABORT OFF 
GO
ALTER DATABASE [CookinRecipe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CookinRecipe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CookinRecipe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CookinRecipe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CookinRecipe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CookinRecipe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CookinRecipe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CookinRecipe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CookinRecipe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CookinRecipe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CookinRecipe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CookinRecipe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CookinRecipe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CookinRecipe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CookinRecipe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CookinRecipe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CookinRecipe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CookinRecipe] SET RECOVERY FULL 
GO
ALTER DATABASE [CookinRecipe] SET  MULTI_USER 
GO
ALTER DATABASE [CookinRecipe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CookinRecipe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CookinRecipe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CookinRecipe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CookinRecipe] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CookinRecipe', N'ON'
GO
USE [CookinRecipe]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[RecipeID] [bigint] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[CommentContent] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseRecipes]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseRecipes](
	[CourseID] [int] NOT NULL,
	[RecipeID] [bigint] NOT NULL,
 CONSTRAINT [PK_CourseRecipes] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](max) NOT NULL,
	[CourseImage] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dishes]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dishes](
	[DishID] [int] IDENTITY(1,1) NOT NULL,
	[DishName] [nvarchar](max) NOT NULL,
	[DishImage] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Dishes] PRIMARY KEY CLUSTERED 
(
	[DishID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DishRecipes]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DishRecipes](
	[DishID] [int] NOT NULL,
	[RecipeID] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_DishRecipes] PRIMARY KEY CLUSTERED 
(
	[DishID] ASC,
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Favourites]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favourites](
	[UserID] [bigint] NOT NULL,
	[RecipeID] [bigint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsCancel] [bit] NOT NULL,
 CONSTRAINT [PK_Favourites] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[IngredientID] [int] IDENTITY(1,1) NOT NULL,
	[IngredientName] [nvarchar](100) NOT NULL,
	[Unit] [nvarchar](20) NULL,
	[Energy] [float] NULL,
	[IsMain] [bit] NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[IngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListRecipes]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListRecipes](
	[ListID] [bigint] NOT NULL,
	[RecipeID] [bigint] NOT NULL,
 CONSTRAINT [PK_ListRecipes] PRIMARY KEY CLUSTERED 
(
	[ListID] ASC,
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lists]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lists](
	[ListID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[ListName] [nvarchar](max) NULL,
	[ListImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED 
(
	[ListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notes]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[RecipeID] [bigint] NOT NULL,
	[NoteNumber] [int] NOT NULL,
	[NoteContent] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Notes_1] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC,
	[NoteNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[RecipeID] [bigint] NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[AdminID] [bigint] NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[UserID] [bigint] NOT NULL,
	[RecipeID] [bigint] NOT NULL,
	[Point] [int] NOT NULL,
	[IsCancel] [bit] NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RecipeIngredients]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeIngredients](
	[RecipeID] [bigint] NOT NULL,
	[IngredientID] [int] NOT NULL,
	[Quantity] [float] NULL,
	[IngreNote] [nvarchar](100) NULL,
 CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC,
	[IngredientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[RecipeID] [bigint] IDENTITY(1,1) NOT NULL,
	[RecipeName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[PrepTime] [int] NOT NULL,
	[Serving] [nvarchar](20) NOT NULL,
	[Difficulty] [smallint] NOT NULL,
	[RecipeImage] [nvarchar](max) NULL,
	[RecipeVideo] [nvarchar](max) NULL,
	[Energy] [float] NULL,
	[AuthorID] [bigint] NOT NULL,
	[IsVerify] [bit] NOT NULL,
	[IsRemove] [bit] NOT NULL,
	[VerifyTime] [datetime] NULL,
	[AdminID] [bigint] NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Steps]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Steps](
	[RecipeID] [bigint] NOT NULL,
	[StepNumber] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Steps_1] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC,
	[StepNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NULL,
	[UserPoint] [int] NULL,
	[Address] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[UserImage] [nvarchar](255) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Caption] [nvarchar](max) NULL,
	[IsLocked] [bit] NOT NULL,
	[RoleNames] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Views]    Script Date: 09/06/2025 08:31:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Views](
	[RecipeID] [bigint] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[IPAddress] [nvarchar](50) NULL,
	[LastView] [datetime] NULL,
	[ViewCount] [bigint] NULL,
 CONSTRAINT [PK_Views_1] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (1, 6, 6, CAST(N'2025-04-05 00:00:00.000' AS DateTime), N'Ngol z ')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (2, 5, 6, CAST(N'2025-04-07 00:00:00.000' AS DateTime), N'Thấy cũm bthg')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (3, 6, 6, CAST(N'2025-04-17 00:00:00.000' AS DateTime), N'Hơi hơi')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (4, 2, 6, CAST(N'2025-04-17 06:30:00.000' AS DateTime), N'Thấy cứ xao xao')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (5, 6, 6, CAST(N'2025-04-17 16:25:51.463' AS DateTime), N'gà')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (25, 2, 6, CAST(N'2025-05-04 17:42:11.143' AS DateTime), N'Ngon')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (26, 3, 10, CAST(N'2025-05-24 22:15:00.050' AS DateTime), N'Ngon quá')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (32, 3, 10, CAST(N'2025-05-26 19:01:19.390' AS DateTime), N'Ngon')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (35, 3, 47, CAST(N'2025-06-05 21:42:39.240' AS DateTime), N'ngon')
INSERT [dbo].[Comments] ([CommentID], [UserID], [RecipeID], [CreatedAt], [CommentContent]) VALUES (36, 8, 33, CAST(N'2025-06-06 13:40:06.443' AS DateTime), N'Dở')
SET IDENTITY_INSERT [dbo].[Comments] OFF
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (1, 6)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (1, 10)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (1, 20)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (1, 39)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (1, 45)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (2, 38)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (2, 40)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (2, 41)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (2, 45)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (2, 49)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (2, 52)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (3, 35)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (3, 49)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (3, 50)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (4, 50)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (4, 53)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (5, 19)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (5, 37)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (5, 43)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (5, 44)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (5, 46)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (5, 47)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (5, 48)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (6, 39)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 20)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 33)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 34)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 38)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 42)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 49)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 50)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (7, 52)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (8, 36)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (8, 44)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (8, 51)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (9, 42)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (9, 43)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (9, 45)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (9, 46)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (9, 47)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (10, 38)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (10, 40)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (10, 41)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (10, 45)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (10, 47)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (12, 35)
INSERT [dbo].[CourseRecipes] ([CourseID], [RecipeID]) VALUES (12, 45)
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (1, N'Món chính', N'638841257498118387_food.png', N'Món chính trong một bữa ăn là món ăn đặc trưng, chủ yếu và thường là món ăn nặng và phức tạp nhất trong thực đơn. Món chính thường cung cấp nguồn protein chính cho bữa ăn và được xem là phần chính được mong đợi nhất sau các món khai vị. ')
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (2, N'Món phụ', N'photo-1645177628172-a94c1f96e6db.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (3, N'Món khai vị', N'photo-1676664778856-b48a7d87d831.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (4, N'Bữa tối', N'photo-1467003909585-2f8a72700288.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (5, N'Tráng miệng', N'photo-1508737804141-4c3b688e2546.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (6, N'Bữa trưa', N'photo-1594834749740-74b3f6764be4.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (7, N'Bữa sáng', N'photo-1482049016688-2d3e1b311543.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (8, N'Đồ uống', N'photo-1556679343-c7306c1976bc.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (9, N'Đồ ăn vặt', N'photo-1623852990556-2d1f29021fd2.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (10, N'Bữa ăn nửa buổi', N'photo-1623341214825-9f4f963727da.jpg', NULL)
INSERT [dbo].[Courses] ([CourseID], [CourseName], [CourseImage], [Description]) VALUES (12, N'Món ăn ngày Tết', N'banh-chung-1_710694221.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Dishes] ON 

INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (1, N'Canh', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (2, N'Salad', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (3, N'Bún, mì', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (4, N'Cháo', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (5, N'Lẩu', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (6, N'Bánh', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (7, N'Sinh tố', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (8, N'Trà, trà sữa', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (9, N'Đồ nướng', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (10, N'Đồ muối', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (11, N'Món chiên', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (12, N'Món xào', NULL, NULL)
INSERT [dbo].[Dishes] ([DishID], [DishName], [DishImage], [Description]) VALUES (13, N'Kem', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Dishes] OFF
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (2, 19, CAST(N'2025-06-01 10:30:07.940' AS DateTime), 0)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (3, 6, CAST(N'2025-05-29 15:35:37.897' AS DateTime), 0)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (3, 10, CAST(N'2025-06-01 01:03:06.780' AS DateTime), 1)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (3, 11, CAST(N'2025-06-01 01:01:40.727' AS DateTime), 1)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (3, 19, CAST(N'2025-06-01 00:13:39.667' AS DateTime), 0)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (3, 20, CAST(N'2025-06-01 00:49:31.240' AS DateTime), 0)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (3, 33, CAST(N'2025-06-06 09:08:46.333' AS DateTime), 0)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (3, 37, CAST(N'2025-06-06 08:58:56.043' AS DateTime), 0)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (6, 6, CAST(N'2025-04-09 21:44:36.293' AS DateTime), 1)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (6, 19, CAST(N'2025-06-03 17:53:29.727' AS DateTime), 1)
INSERT [dbo].[Favourites] ([UserID], [RecipeID], [CreatedAt], [IsCancel]) VALUES (8, 33, CAST(N'2025-06-06 13:39:56.633' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (1, N'Gạo nếp', N'g', 3.440000057220459, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (2, N'Gạo tẻ', N'g', 3.44, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (3, N'Gạo lứt', N'g', 3.45, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (4, N'Bánh mì', N'cái', 230, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (5, N'Bánh mì đen', N'cái', 250, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (6, N'Sandwich', N'lát', 65, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (7, N'Bánh phở', N'g', 1.43, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (8, N'Bánh quẩy', N'cái', 92, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (9, N'Bún', N'g', 1.1, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (10, N'Mì sợi', N'g', 3.49, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (11, N'Bắp nếp', N'trái', 250, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (12, N'Cốm', N'g', 2.97, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (13, N'Bột mì', N'g', 3.46, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (14, N'Miến dong', N'g', 3.32, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (15, N'Thịt bò', N'g', 1.18, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (16, N'Thịt cừu nạc', N'g', 2.19, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (17, N'Thịt dê nạc', N'g', 1.22, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (18, N'Thịt gà ta', N'g', 1.99, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (19, N'Thịt heo mỡ', N'g', 3.94, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (20, N'Thịt heo nạc', N'g', 1.39, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (21, N'Thịt vịt', N'g', 2.67, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (22, N'Chân giò heo', N'g', 2.3, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (23, N'Chả lụa', N'g', 1.36, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (24, N'Lạp xưởng', N'g', 5.85, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (25, N'Chà bông heo', N'g', 3.69, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (26, N'Thịt ếch', N'g', 0.9, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (27, N'Cá chép', N'g', 0.96, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (28, N'Cá hồi ', N'g', 1.36, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (29, N'Cá ngừ', N'g', 0.87, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (30, N'Cá thu', N'g', 1.66, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (31, N'Cua biển', N'g', 1.03, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (32, N'Cua đồng', N'g', 0.87, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (33, N'Ghẹ', N'g', 0.54, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (34, N'Mực tươi', N'g', 0.73, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (35, N'Ốc bươu', N'g', 0.84, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (36, N'Tôm biển', N'g', 0.82, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (37, N'Tôm đồng', N'g', 0.9, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (38, N'Trứng gà', N'quả', 72, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (39, N'Trứng vịt', N'quả', 130, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (40, N'Trứng cút', N'quả', 14, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (41, N'Đậu cô ve', N'g', 0.73, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (42, N'Đậu đen', N'g', 3.25, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (43, N'Đậu đũa', N'g', 0.59, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (44, N'Đậu Hà Lan', N'g', 0.72, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (45, N'Đậu nành', N'g', 4, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (46, N'Sữa đậu nành', N'g', 0.28, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (47, N'Đậu xanh', N'g', 3.28, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (48, N'Hạt điều', N'g', 5.54, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (49, N'Mè đen', N'g', 5.68, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (50, N'Mè trắng', N'g', 5.68, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (51, N'Đậu phụ', N'miếng', 61, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (52, N'Nấm hương', N'g', 2.74, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (53, N'Nấm mèo (Mộc nhĩ)', N'g', 3.04, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (54, N'Khoai lang', N'g', 1.19, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (55, N'Khoai tây', N'g', 0.93, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (56, N'Bầu', N'g', 0.14, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (58, N'Bí xanh', N'g', 0.12, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (59, N'Bí đỏ', N'g', 0.27, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (60, N'Cà chua', N'g', 0.2, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (61, N'Cà rốt', N'g', 0.39, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (62, N'Cái bắp', N'g', 0.29, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (63, N'Cải thìa', N'g', 0.17, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (64, N'Cải xanh', N'g', 0.16, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (65, N'Rau mồng tơi', N'g', 0.14, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (66, N'Rau muống', N'g', 0.25, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (67, N'Rau ngót', N'g', 0.35, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (68, N'Củ cải trắng', N'g', 0.21, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (69, N'Dưa chuột', N'g', 0.16, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (70, N'Hạt sen tươi', N'g', 1.61, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (71, N'Măng tây', N'g', 0.14, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (72, N'Mướp', N'g', 0.17, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (73, N'Khổ qua', N'g', 0.16, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (74, N'Súp lơ xanh', N'g', 0.26, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (75, N'Bưởi', N'g', 0.3, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (76, N'Cam', N'g', 0.38, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (77, N'Chanh', N'trái', 20, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (78, N'Chôm chôm', N'g', 0.72, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (79, N'Chuối tiêu', N'g', 0.97, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (80, N'Dâu tây', N'g', 0.43, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (81, N'Dưa hấu', N'g', 0.16, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (82, N'Dứa (Thơm)', N'g', 0.38, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (83, N'Đào', N'g', 0.31, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (84, N'Đu đủ chín', N'g', 0.35, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (85, N'Lê', N'g', 0.45, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (86, N'Lựu', N'g', 0.7, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (87, N'Mận', N'g', 20, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (88, N'Mít mật', N'g', 0.62, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (89, N'Nhãn', N'g', 0.48, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (90, N'Ổi', N'g', 0.38, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (91, N'Bia', N'ml', 0.45, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (92, N'Rượu nếp', N'ml', 1.7, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (93, N'Rượu vang đỏ', N'ml', 0.83, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (95, N'Coca cola', N'ml', 0.44, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (96, N'Nước cam tươi', N'ml', 0.48, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (97, N'Sữa bò', N'ml', 1.5, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (98, N'Sữa chua không đường', N'g', 0.85, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (99, N'Kẹo cà phê', N'g', 3.78, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (100, N'Kẹo dừa', N'g', 4.15, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (101, N'Kẹo sữa', N'g', 3.9, NULL)
GO
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (102, N'Bánh socola', N'g', 4.49, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (103, N'Bánh quế', N'g', 4.35, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (104, N'Bánh đậu xanh', N'g', 4.16, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (105, N'Bánh quy', N'g', 3.76, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (106, N'Mứt cam', N'g', 2.18, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (107, N'Mứt thơm', N'g', 2.08, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (108, N'Sữa chua có đường', N'g', 1.05, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (109, N'Sữa đặc', N'g', 3.41, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (110, N'Whipping Cream', N'ml', 3.35, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (111, N'Gelatin', N'g', 0.62, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (112, N'Chả cá', N'g', 0.84, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (113, N'Bơ lạt', N'gr', 7.17, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (114, N'Bơ thực vật', N'gr', 6.06, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (115, N'Đường phèn', N'gr', 3.83, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (116, N'Đường cát', N'gr', 3.87, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (117, N'Muối', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (118, N'Bột ngọt', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (119, N'Hạt nêm', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (120, N'Tiêu', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (121, N'Dầu ăn', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (122, N'Nước tương', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (123, N'Dầu hào', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (124, N'Muối tôm Tây Ninh', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (125, N'Nước mắm', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (126, N'Tương ớt', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (127, N'Hành', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (128, N'Tỏi', N'củ', NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (129, N'Bột chiên giòn', N'bịch', NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (130, N'Bột chiên xù', N'bịch', NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (131, N'Bì heo (Da heo)', N'gr', 5.44, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (132, N'Sữa tươi không đường', N'ml', NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (133, N'Sữa tươi có đường', N'ml', NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (134, N'Bột vani', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (135, N'Chanh dây', N'quả', NULL, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (136, N'Topping Cream', N'ml', NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (137, N'Màu thực phẩm', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (138, N'Sả', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (139, N'Hành tây', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (140, N'Hành lá', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (141, N'Giá đỗ', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (142, N'Rau thơm', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (143, N'Hoa chuối', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (144, N'Dầu màu điều', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (145, N'Chả cua', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (146, N'Nạm bò', NULL, NULL, NULL)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (148, N'Nguyên liệu 1', N'1', 1, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (149, N'Xương bò', N'g', 1.7799999713897705, 1)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (150, N'Mayonnaise', N'g', 0, 0)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (151, N'Pate', N'g', 0, 0)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (152, N'Rau mùi', N'', 0, 0)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (153, N'Ớt tươi', N'trái', 0, 0)
INSERT [dbo].[Ingredients] ([IngredientID], [IngredientName], [Unit], [Energy], [IsMain]) VALUES (154, N'Cà phê', N'g', 0, 0)
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (2, 6)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (2, 19)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (3, 6)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (10, 6)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (13, 10)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (13, 11)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (13, 19)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (13, 20)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (17, 11)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (19, 10)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (24, 34)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (24, 38)
INSERT [dbo].[ListRecipes] ([ListID], [RecipeID]) VALUES (25, 33)
SET IDENTITY_INSERT [dbo].[Lists] ON 

INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (1, 6, N'Bánh ngọt', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (2, 2, N'Nước ngọt', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (3, 2, N'Nước khoáng', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (10, 2, N'Gà', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (13, 3, N'Lẩu', N'4544cd78-f8d7-42db-931f-ec3a904fa9c9.jpg')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (17, 7, N'Ngọt', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (18, 3, N'Nguyên liệu', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (19, 3, N'Chè', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (23, 2, N'Loopy', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (24, 3, N'Ăn sáng', N'no-image.png')
INSERT [dbo].[Lists] ([ListID], [UserID], [ListName], [ListImage]) VALUES (25, 8, N'Phở', N'no-image.png')
SET IDENTITY_INSERT [dbo].[Lists] OFF
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (6, 1, N'Để rút ngắn thời gian chiên thì có thể luộc sơ thịt gà rồi mới tẩm ướp và bao bột, chiên giòn. Chiên ở lửa vừa để đảm bảo thịt gà bên trong chín, không bị đỏ xương.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (6, 2, N'Nếu không có bột chiên giòn thì lấy 3 muỗng canh bột mì trộn đều với 2 muỗng canh bột bắp cũng tạo lớp bao áo giòn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (10, 1, N'Món thịt đông (thịt lợn nấu đông, thịt gà nấu đông) nêm nếm hơi nhạt vì mặn sẽ khó đông. Khi ăn, rưới nước mắm truyền thống thêm ớt, hạt tiêu giúp tôn vị nhau lên.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (10, 2, N'Cho lượng bì thăn vừa đủ, khi nấu nhừ tạo gelatin keo kết dính, không cho nhiều quá làm thịt đông bị cứng. Nếu không thích ăn bì sau khi ninh nhừ vớt bỏ ra.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (10, 3, N'Khi nấu nêm muối hạt, cuối cùng mới nêm nước mắm để có vị ngọt hậu, thơm ngon hơn mà không cần nêm thêm mì chính. Không dùng muối tinh dễ có vị chát.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (11, 1, N'Trong quá trình làm lạnh, rất có thể bánh sẽ bị tách thành nhiều phần kem và sữa. Bạn chỉ cần để hỗn hợp ở nhiệt độ phòng và đánh hỗn hợp đều tay một lần nữa là được.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (11, 2, N'80 độ C là nhiệt độ thích hợp nhất để đun hỗn hợp. Khuấy đều tay để tránh làm hỗn hợp sữa bị khét.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (19, 1, N'- Khi mới bắt đầu bạn nên chọn bột mì đa dụng để làm bánh, bởi vì bột mì đa dụng có hương vị và chất lượng không thua kém gì bột làm bánh kem chuyên dụng khác.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (19, 2, N'- Khi mới bắt đầu bạn nên chọn bột mì đa dụng để làm bánh, bởi vì bột mì đa dụng có hương vị và chất lượng không thua kém gì bột làm bánh kem chuyên dụng khác.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (19, 3, N'- Khi mới bắt đầu bạn nên chọn bột mì đa dụng để làm bánh, bởi vì bột mì đa dụng có hương vị và chất lượng không thua kém gì bột làm bánh kem chuyên dụng khác.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (20, 1, N'Để chọn thịt bò ngon bạn nên quan sát màu sắc miếng thịt. Thịt tươi ngon thường có màu đỏ tươi, không phải đỏ sẫm và mỡ bò có màu vàng nhạt.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (20, 2, N'Nên chọn mua những miếng thịt nhỏ và mềm, thớ thịt mịn và khi ấn tay vào thì có độ đàn hồi tốt.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (20, 3, N'Không mua những miếng thịt thấy có những nang trắng, nhỏ và dễ rời ra thì rất có thể đó là sán. Bạn cũng hạn chế những miếng thịt nhỏ đã được cắt sẵn, vì chúng rất hay chứa sán.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (33, 1, N'Nên hầm xương ít nhất 6 tiếng để nước dùng ngọt.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (33, 2, N'Có thể thêm gừng nướng để nước dùng dậy mùi.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (34, 1, N'Có thể thay thịt heo bằng thịt bò hoặc gà tùy sở thích.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (34, 2, N'Ngâm cà rốt với dấm và đường khoảng 30 phút để có vị chua nhẹ.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (34, 3, N'Thêm ớt và hành ngò tươi để tăng vị đậm đà.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (35, 1, N'Nên chọn tôm tươi và thịt heo mềm để món gỏi cuốn ngon hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (35, 2, N'Có thể dùng tương đậu phộng thay cho nước mắm nếu thích vị béo ngậy.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (35, 3, N'Rau sống nên rửa sạch và để ráo trước khi cuốn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (36, 1, N'Dùng cà phê phin Việt Nam sẽ cho vị đậm đà và thơm ngon đặc trưng.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (36, 2, N'Có thể điều chỉnh lượng sữa đặc tùy theo khẩu vị ngọt hay đắng.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (36, 3, N'Nên dùng đá viên sạch để giữ vị cà phê chuẩn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (37, 1, N'Có thể thêm đá nếu thích ăn chè lạnh.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (37, 2, N'Điều chỉnh lượng đường theo khẩu vị.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (37, 3, N'Dùng nước cốt dừa tươi để món chè thơm ngon hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (38, 1, N'Bột bánh xèo nên pha loãng vừa phải để bánh giòn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (38, 2, N'Dùng chảo chống dính để bánh không bị dính.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (38, 3, N'Có thể thêm giá đỗ vào nhân tùy thích.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (39, 1, N'Chọn gạo tấm ngon để cơm mềm.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (39, 2, N'Nước mắm chua ngọt nên pha vừa miệng, không quá chua hay ngọt.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (39, 3, N'Tất cả thành phần nên được trình bày đẹp mắt khi dọn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (40, 1, N'Nên dùng xương bò tươi để nước dùng ngọt và trong.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (40, 2, N'Gia vị sả, mắm ruốc giúp tạo hương vị đặc trưng của bún bò Huế.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (40, 3, N'Bún nên ăn nóng để cảm nhận đúng vị.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (41, 1, N'Dùng phô mai mozzarella chất lượng để bánh ngon hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (41, 2, N'Nhiệt độ nướng cao giúp bánh giòn và phô mai chảy đều.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (41, 3, N'Không nên cho quá nhiều sốt cà chua để bánh không bị ướt.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (42, 1, N'Luộc mì vừa tới để mì không bị quá mềm hoặc quá cứng.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (42, 2, N'Sốt nên ninh đủ lâu để đậm đà hương vị.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (42, 3, N'Phô mai parmesan giúp món ăn thêm hấp dẫn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (43, 1, N'Không khuấy quá kỹ để bánh không bị dai.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (43, 2, N'Sử dụng bơ thực vật hoặc bơ lạt để bánh thơm hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (44, 1, N'Sử dụng xoài chín ngọt để smoothie ngon hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (44, 2, N'Có thể thay sữa chua bằng nước dừa hoặc sữa hạnh nhân.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (45, 1, N'Có thể thêm bột ớt nếu thích cay hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (45, 2, N'Chiên ở nhiệt độ vừa để gà chín đều bên trong.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (46, 1, N'Sử dụng cà phê espresso để hương vị đậm đà hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (46, 2, N'Để tiramisu trong tủ lạnh qua đêm ngon hơn.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (47, 1, N'Có thể thay kem lạnh bằng trái cây đông lạnh tùy thích.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (48, 1, N'Có thể thêm hạt óc chó hoặc socola chip để tăng vị.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (49, 1, N'Có thể thêm trứng luộc hoặc cà chua bi để tăng hương vị.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (50, 1, N'Có thể thêm một ít gừng để tăng hương vị.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (51, 1, N'Có thể thêm mật ong để tăng vị ngọt tự nhiên.')
INSERT [dbo].[Notes] ([RecipeID], [NoteNumber], [NoteContent]) VALUES (52, 1, N'Có thể thêm nấm và rong biển để tăng hương vị.')
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (59, 8, 37, N'Công thức đã được phê duyệt', N'Công thức Chè đậu xanh của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:23:55.320' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (60, 7, 36, N'Công thức đã được phê duyệt', N'Công thức Cà phê sữa đá của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:23:57.870' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (61, 10, 39, N'Công thức đã được phê duyệt', N'Công thức Cơm tấm sườn bì chả của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:00.250' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (62, 3, 34, N'Công thức đã được phê duyệt', N'Công thức Bánh mì thịt của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:03.670' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (63, 9, 38, N'Công thức đã được phê duyệt', N'Công thức Bánh xèo của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:06.827' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (64, 2, 33, N'Công thức đã được phê duyệt', N'Công thức Phở bò của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:10.353' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (65, 3, 52, N'Công thức đã được phê duyệt', N'Công thức Mì ramen trứng lòng đào của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:16.267' AS DateTime), 1, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (66, 9, 51, N'Công thức đã được phê duyệt', N'Công thức Trà đào cam sả của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:19.233' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (67, 9, 50, N'Công thức đã được phê duyệt', N'Công thức Súp bí đỏ của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:21.730' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (68, 7, 49, N'Công thức đã được phê duyệt', N'Công thức Salad Caesar của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:24.530' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (69, 2, 47, N'Công thức đã được phê duyệt', N'Công thức Mochi kem lạnh của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:27.417' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (70, 6, 48, N'Công thức đã được phê duyệt', N'Công thức Bánh quy bơ của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:30.460' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (71, 6, 46, N'Công thức đã được phê duyệt', N'Công thức Bánh tiramisu của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:33.540' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (72, 10, 45, N'Công thức đã được phê duyệt', N'Công thức Gà chiên KFC của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:35.950' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (73, 9, 44, N'Công thức đã được phê duyệt', N'Công thức Smoothie xoài của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:38.037' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (74, 6, 35, N'Công thức đã được phê duyệt', N'Công thức Gỏi cuốn tôm thịt của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:42.067' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (75, 5, 42, N'Công thức đã được phê duyệt', N'Công thức Spaghetti Bolognese của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:45.757' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (76, 7, 41, N'Công thức đã được phê duyệt', N'Công thức Pizza Margherita của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:48.187' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (77, 10, 40, N'Công thức đã được phê duyệt', N'Công thức Bún bò Huế của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:51.500' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (78, 3, 43, N'Công thức đã được phê duyệt', N'Công thức Bánh pancake của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:54.857' AS DateTime), 1, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (79, 5, 11, N'Công thức đã được phê duyệt', N'Công thức Panna Cotta của bạn đã được phê duyệt bởi quản trị viên Admin', N'Verified', CAST(N'2025-06-05 21:24:58.770' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (80, 8, NULL, N'Phân quyền', N'Quản trị viên Admin đã phân quyền Người kiểm duyệt cho tài khoản của bạn.', N'Permission', CAST(N'2025-06-05 21:36:37.637' AS DateTime), 1, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (81, 2, 33, N'Yêu thích công thức', N'Quyen My đã thích công thức Phở bò của bạn', N'Favourite', CAST(N'2025-06-05 21:36:58.903' AS DateTime), 0, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (82, 8, NULL, N'Phân quyền', N'Quản trị viên Admin đã phân quyền Người dùng cho tài khoản của bạn.', N'Permission', CAST(N'2025-06-05 21:37:37.627' AS DateTime), 1, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (83, 2, 47, N'Bạn có 1 thông báo mới', N'Admin đã bình luận về công thức Mochi kem lạnh của bạn', N'Comment', CAST(N'2025-06-05 21:42:39.257' AS DateTime), 1, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (84, 2, 33, N'Đánh giá công thức', N'Quyen My đã đánh giá 3 sao cho công thức Phở bò của bạn', N'Rate', CAST(N'2025-06-05 21:46:44.160' AS DateTime), 0, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (85, 8, 37, N'Yêu thích công thức', N'Admin đã thích công thức Chè đậu xanh của bạn', N'Favourite', CAST(N'2025-06-06 08:58:56.093' AS DateTime), 0, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (86, 2, 33, N'Yêu thích công thức', N'Admin đã thích công thức Phở bò của bạn', N'Favourite', CAST(N'2025-06-06 09:08:46.367' AS DateTime), 0, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (87, 6, 19, N'Phản hồi về công thức Bánh kem sinh nhật', N'Cần sửa mô tả để được duyệt', N'From Admin', CAST(N'2025-06-06 11:50:32.327' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (88, 8, 20, N'Phản hồi về công thức Cách nấu bún bò Huế chuẩn vị, đơn giản cực thơm ngon tại nhà', N'Tên dài quá', N'From Admin', CAST(N'2025-06-06 11:52:07.830' AS DateTime), 1, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (89, 2, 33, N'Yêu thích công thức', N'Quyen My đã thích công thức Phở bò của bạn', N'Favourite', CAST(N'2025-06-06 13:39:56.667' AS DateTime), 0, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (90, 2, 33, N'Đánh giá công thức', N'Quyen My đã đánh giá 4 sao cho công thức Phở bò của bạn', N'Rate', CAST(N'2025-06-06 13:39:58.723' AS DateTime), 0, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (91, 2, 33, N'Bạn có 1 thông báo mới', N'Quyen My đã bình luận về công thức Phở bò của bạn', N'Comment', CAST(N'2025-06-06 13:40:06.450' AS DateTime), 0, NULL)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (92, 8, NULL, N'Phân quyền', N'Quản trị viên Admin đã phân quyền Người kiểm duyệt cho tài khoản của bạn.', N'Permission', CAST(N'2025-06-06 13:41:47.920' AS DateTime), 0, 3)
INSERT [dbo].[Notifications] ([NotificationID], [UserID], [RecipeID], [Title], [Message], [Type], [CreatedAt], [IsRead], [AdminID]) VALUES (93, 8, 20, N'Công thức đã được phê duyệt', N'Công thức Cách nấu bún bò Huế chuẩn vị, đơn giản cực thơm ngon tại nhà của bạn đã được phê duyệt bởi quản trị viên Quyen My', N'Verified', CAST(N'2025-06-06 13:42:28.987' AS DateTime), 0, 8)
SET IDENTITY_INSERT [dbo].[Notifications] OFF
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (2, 6, 3, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (2, 19, 4, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (3, 6, 3, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (3, 10, 3, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (3, 11, 3, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (3, 19, 4, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (5, 6, 5, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (6, 6, 3, 0)
INSERT [dbo].[Ratings] ([UserID], [RecipeID], [Point], [IsCancel]) VALUES (8, 33, 4, 0)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 18, 800, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 113, 50, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 116, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 117, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 119, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 120, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 121, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 128, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (6, 129, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (10, 18, 1000, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (10, 52, 50, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (10, 53, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (10, 117, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (10, 120, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (10, 125, NULL, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (10, 131, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (11, 110, 250, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (11, 111, 10, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (11, 116, 80, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (11, 132, 250, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (11, 134, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (11, 135, 6, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (19, 13, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (19, 38, 500, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (19, 110, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (19, 121, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (19, 132, 1200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (20, 15, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (20, 22, 1000, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (20, 144, -99, N'3 muỗng canh')
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (20, 146, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (33, 7, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (33, 15, 500, N'Thịt bò tái')
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (33, 149, 1000, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (34, 4, 2, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (34, 20, 300, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (34, 61, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (34, 69, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (34, 126, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (34, 150, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (34, 153, 2, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 7, 100, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 15, 50, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 20, 20, N'Luộc chín, thái lát')
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 36, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 38, 3, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 125, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 127, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 128, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 142, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (35, 153, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (36, 109, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (36, 154, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (37, 47, 200, N'Ngâm, làm sạch vỏ')
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (37, 116, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (37, 117, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (38, 20, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (38, 37, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (38, 125, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (38, 129, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (38, 140, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (38, 141, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (39, 2, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (39, 20, 200, N'Chọn phần sườn')
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (39, 60, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (39, 69, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (39, 125, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (40, 9, 150, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (40, 15, 250, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (40, 127, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (40, 138, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (41, 13, 500, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (41, 60, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (41, 126, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (42, 10, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (42, 15, 150, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (42, 60, 50, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (43, 13, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (43, 38, 3, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (43, 97, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (43, 113, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (44, 97, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (44, 98, 150, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (45, 18, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (45, 129, 1, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (45, 130, 1, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (46, 13, 150, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (46, 80, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (46, 134, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (47, 13, 150, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (47, 116, 50, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (48, 13, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (48, 38, 3, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (48, 113, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (48, 116, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (49, 4, 2, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (49, 38, 2, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (49, 60, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (49, 142, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (49, 150, 0, NULL)
GO
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (50, 59, 300, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (50, 117, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (50, 140, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (51, 76, 20, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (51, 116, 50, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (51, 138, -99, N'3 nhánh')
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (52, 10, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (52, 20, 200, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (52, 38, 1, N'Luộc lòng đào')
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (52, 140, -99, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (53, 32, 0, NULL)
INSERT [dbo].[RecipeIngredients] ([RecipeID], [IngredientID], [Quantity], [IngreNote]) VALUES (53, 125, -99, NULL)
SET IDENTITY_INSERT [dbo].[Recipes] ON 

INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (6, N'Cánh gà chiên bơ tỏi', N'Cánh gà giòn rôm rốp, bên trong thịt ngọt mềm, dậy mùi thơm bơ tỏi. Khi ăn chấm cùng tương ớt, tương cà. Món ăn này có trong thực đơn nhiều nhà hàng là gợi ý cho thực đơn của bạn thêm phong phú.', CAST(N'2025-04-05 00:00:00.000' AS DateTime), 56, N'4-6', 0, N'gachienbotoi.jpg', N'suonchuangot.mp4', 0, 2, 0, 0, CAST(N'2025-06-03 15:21:30.083' AS DateTime), 3, NULL)
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (10, N'Thịt gà nấm hương nấu đông', N'Bát thịt đông trong veo, khi ăn cảm nhận rõ vị ngọt mát, mềm mại, thoảng hương thơm của nấm hương, chút giòn sần sật từ mộc nhĩ. ', CAST(N'2025-04-05 00:00:00.000' AS DateTime), 90, N'4-5', 0, N'ganamhuong.jpg', NULL, 1328, 3, 0, 0, CAST(N'2025-06-05 08:40:30.443' AS DateTime), 3, NULL)
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (11, N'Panna Cotta', N'Panna cotta là món tráng miệng hấp dẫn, có nguồn gốc từ nước Ý xinh đẹp. Món ăn được làm từ các loại nguyên liệu đơn giản nhưng hương vị thì vô cùng độc đáo. Khi thưởng thức, bạn sẽ cảm nhận được phần cốt bánh mềm mịn, dậy hương sữa hòa quyện cùng phần xốt trái cây chua ngọt, tạo nên một tổng thể hương vị hoàn hảo và tinh tế. ', CAST(N'2025-04-22 00:00:00.000' AS DateTime), 60, N'5-6', 0, N'pannacotta.jpg', N'', 1153.3000000000002, 5, 1, 0, CAST(N'2025-06-05 21:24:58.770' AS DateTime), 3, NULL)
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (19, N'Bánh kem sinh nhật', N'Kem thì có vị béo béo ngọt ngọt ăn cùng lớp bánh bông lan nướng thơm ngậy mùi trứng gà, mùi cacao, kết hợp với vị chua chua của dâu tây, tất cả hòa quyện tạo nên một hương vị thơm ngon không thua gì ngoài tiệm. Hãy thử bắt tay vào bếp để thực hiện đi nhé.', CAST(N'2025-04-28 18:03:49.987' AS DateTime), 30, N'4-6', 0, N'638814602298500664_finished-cake-vert-scaled.jpg', N'', 36000, 6, 0, 0, CAST(N'2025-06-05 08:21:10.460' AS DateTime), 3, NULL)
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (20, N'Cách nấu bún bò Huế chuẩn vị, đơn giản cực thơm ngon tại nhà', N'Bún bò Huế được mệnh danh là 1 trong 50 món ăn ngon nhất thế giới. Để có được một tô bún bò chuẩn vị đặc sản Huế thơm ngon cần khá nhiều nguyên liệu, tưởng chừng cầu kỳ nhưng lại rất dễ làm.', CAST(N'2025-05-25 17:33:17.517' AS DateTime), 150, N'4', 0, N'638847531233336027_IMA.jpg', N'', 2300, 8, 1, 0, CAST(N'2025-06-06 13:42:28.980' AS DateTime), 8, CAST(N'2025-06-05 20:45:23.357' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (33, N'Phở bò', N'Món ăn truyền thống Việt Nam với nước dùng đậm đà và thịt bò thái mỏng.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 45, N'2 người', 2, N'638847187905923140_IMA.jpg', N'', 2655.9999713897705, 2, 1, 0, CAST(N'2025-06-05 21:24:10.337' AS DateTime), 3, CAST(N'2025-06-05 11:18:36.780' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (34, N'Bánh mì thịt', N'Bánh mì Việt Nam giòn rụm, kẹp thịt nguội và rau sống.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 15, N'1 người', 1, N'638847529207119269_IMA.jpg', N'', 888, 3, 1, 0, CAST(N'2025-06-05 21:24:03.667' AS DateTime), 3, CAST(N'2025-06-05 20:42:00.790' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (35, N'Gỏi cuốn tôm thịt', N'Món cuốn thanh mát với tôm, thịt luộc và rau sống.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 20, N'2 người', 1, N'638847530657664216_IMA.jpg', N'', 609.8, 6, 1, 0, CAST(N'2025-06-05 21:24:42.033' AS DateTime), 3, CAST(N'2025-06-05 20:44:25.810' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (36, N'Cà phê sữa đá', N'Đặc sản Việt Nam với cà phê phin pha cùng sữa đặc.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 10, N'1', 1, N'638847532319339805_IMA.jpg', N'', 682, 7, 1, 0, CAST(N'2025-06-05 21:23:57.870' AS DateTime), 3, CAST(N'2025-06-05 20:47:38.883' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (37, N'Chè đậu xanh', N'Món tráng miệng ngọt thanh với đậu xanh và nước cốt dừa.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 30, N'3 người', 1, N'638847533435169947_IMA.jpg', N'', 656, 8, 1, 0, CAST(N'2025-06-05 21:23:55.303' AS DateTime), 3, CAST(N'2025-06-05 20:49:03.543' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (38, N'Bánh xèo', N'Món bánh Việt Nam giòn rụm, nhân tôm thịt và giá đỗ.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 40, N'2 người', 2, N'638847534508362377_IMA.jpg', N'', 458, 9, 1, 0, CAST(N'2025-06-05 21:24:06.827' AS DateTime), 3, CAST(N'2025-06-05 20:50:50.867' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (39, N'Cơm tấm sườn bì chả', N'Món cơm đặc trưng miền Nam ăn kèm sườn nướng và nước mắm.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 50, N'2 người', 2, N'638847535779824321_IMA.jpg', N'', 278, 10, 1, 0, CAST(N'2025-06-05 21:24:00.250' AS DateTime), 3, CAST(N'2025-06-05 20:52:58.010' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (40, N'Bún bò Huế', N'Món bún cay nồng với thịt bò và giò heo đặc sản Huế.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 60, N'3 người', 0, N'638847536808140268_IMA.jpg', N'', 460, 10, 1, 0, CAST(N'2025-06-05 21:24:51.500' AS DateTime), 3, CAST(N'2025-06-05 20:54:40.837' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (41, N'Pizza Margherita', N'Pizza Ý truyền thống với sốt cà chua, mozzarella và basil.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 30, N'2 người', 2, N'638847538181382866_IMA.jpg', N'', 1734, 7, 1, 0, CAST(N'2025-06-05 21:24:48.170' AS DateTime), 3, CAST(N'2025-06-05 20:56:58.160' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (42, N'Spaghetti Bolognese', N'Mì Ý với sốt thịt bò cà chua đậm đà.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 40, N'2', 2, N'638847539311442752_IMA.jpg', N'', 885, 5, 1, 0, CAST(N'2025-06-05 21:24:45.743' AS DateTime), 3, CAST(N'2025-06-05 20:58:51.163' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (43, N'Bánh pancake', N'Bánh mềm mịn dùng kèm mật ong hoặc mứt trái cây.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 20, N'2 người', 1, N'638847540204737591_IMA.jpg', N'', 1351.4, 3, 1, 0, CAST(N'2025-06-05 21:24:54.853' AS DateTime), 3, CAST(N'2025-06-05 21:00:20.477' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (44, N'Smoothie xoài', N'Đồ uống mát lạnh từ xoài chín và sữa chua.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 10, N'1', 1, N'638847541099337710_IMA.jpg', N'', 427.5, 9, 1, 0, CAST(N'2025-06-05 21:24:38.020' AS DateTime), 3, CAST(N'2025-06-05 21:01:49.957' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (45, N'Gà chiên KFC', N'Gà rán giòn tan với lớp vỏ cay hấp dẫn.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 35, N'2 ', 2, N'638847542979538057_IMA.jpg', N'', 398, 10, 1, 0, CAST(N'2025-06-05 21:24:35.933' AS DateTime), 3, CAST(N'2025-06-05 21:04:57.997' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (46, N'Bánh tiramisu', N'Món tráng miệng Ý béo ngậy với cà phê và mascarpone.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 60, N'4 người', 0, N'638847543670034326_IMA.jpg', N'', 605, 6, 1, 0, CAST(N'2025-06-05 21:24:33.540' AS DateTime), 3, CAST(N'2025-06-05 21:06:07.080' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (47, N'Mochi kem lạnh', N'Món bánh Nhật với lớp vỏ dẻo và nhân kem mát lạnh.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 25, N'3 người', 2, N'638847544668036629_IMA.jpg', N'', 712.5, 2, 1, 0, CAST(N'2025-06-05 21:24:27.400' AS DateTime), 3, CAST(N'2025-06-05 21:07:46.870' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (48, N'Bánh quy bơ', N'Bánh nướng giòn thơm từ bơ và bột mì.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 30, N'4', 1, N'638847545702787175_IMA.jpg', N'', 2419.4, 6, 1, 0, CAST(N'2025-06-05 21:24:30.443' AS DateTime), 3, CAST(N'2025-06-05 21:09:30.347' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (49, N'Salad Caesar', N'Salad rau trộn với sốt kem, thịt xông khói và phô mai Parmesan.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 20, N'2 người', 1, N'638847546588206313_IMA.jpg', N'', 608, 7, 1, 0, CAST(N'2025-06-05 21:24:24.510' AS DateTime), 3, CAST(N'2025-06-05 21:10:58.863' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (50, N'Súp bí đỏ', N'Súp sánh mịn từ bí đỏ và kem tươi.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 25, N'2', 1, N'638847547812317198_IMA.jpg', N'', 81, 9, 1, 0, CAST(N'2025-06-05 21:24:21.707' AS DateTime), 3, CAST(N'2025-06-05 21:13:01.287' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (51, N'Trà đào cam sả', N'Đồ uống giải nhiệt kết hợp đào, cam và sả.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 15, N'1', 1, N'638847548605023921_IMA.jpg', N'', 201.1, 9, 1, 0, CAST(N'2025-06-05 21:24:19.233' AS DateTime), 3, CAST(N'2025-06-05 21:14:20.580' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (52, N'Mì ramen trứng lòng đào', N'Mì Nhật với nước dùng đậm đà và trứng lòng đào.', CAST(N'2025-06-05 10:48:54.337' AS DateTime), 45, N'2', 0, N'638847549549876433_IMA.jpg', N'', 1048, 3, 1, 0, CAST(N'2025-06-05 21:24:16.257' AS DateTime), 3, CAST(N'2025-06-05 21:15:55.050' AS DateTime))
INSERT [dbo].[Recipes] ([RecipeID], [RecipeName], [Description], [CreatedAt], [PrepTime], [Serving], [Difficulty], [RecipeImage], [RecipeVideo], [Energy], [AuthorID], [IsVerify], [IsRemove], [VerifyTime], [AdminID], [UpdateTime]) VALUES (53, N'Lẩu cua', N'', CAST(N'2025-06-06 13:38:31.600' AS DateTime), 12, N'2-3', 1, N'638848139115549247_lẩu-cua.jpg', N'', 0, 8, 0, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Recipes] OFF
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (6, 1, N'Sơ chế: Cánh gà ngâm nước muối loãng, rửa sạch, thấm khô, chặt đôi và khứa nhẹ phần bên trong cho nhanh thấm gia vị và chín đều khi chiên. Tỏi bóc vỏ, giã nhuyễn, vắt lấy nước cốt để ướp cánh gà. Việc này vừa giúp gà thấm ướp nhanh và khi chiên không bị cháy phần xác tỏi. Giữ lại phần xác tỏi để chiên vàng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (6, 2, N'Tẩm ướp: Cho cánh gà thấm khô vào âu, ướp với nước cốt tỏi, 1 muỗng canh tương ớt, 2/3 muỗng cà phê muối, 1 muỗng cà phê hạt nêm, 1 muỗng cà phê hạt tiêu cùng chút rượu trắng, đảo đều trong 20 - 30 phút cho thấm vị. Nếu thích ăn ngọt thì thêm chút đường vào ướp. Sau đó, cho 1 lòng đỏ trứng vào đảo đều bao hết các mặt cánh gà. Lần lượt lấy từng cánh gà lăn qua bột chiên giòn, phủ đều các mặt. ')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (6, 3, N'Chiên gà và xóc bơ tỏi: Đun nóng dầu ăn nhiều chút, cho cánh gà vào chiên giòn vàng đều, gắp ra để giấy thấm dầu. Nếu thích giòn hơn thì chiên 2 lần lửa. Đun bơ tan chảy, cho phần xác tỏi vào phi vàng ruộm thì vớt ra, để rắc lên thành phẩm gà thêm phần hấp dẫn. Cho gà vào xóc đều phần sốt bơ tỏi, thêm hành tây thái múi cau (tùy chọn) rồi đảo qua. Tắt bếp múc ra đĩa, rắc phần tỏi phi vàng ruộm lên trên và thưởng thức nóng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (6, 4, N'Yêu cầu thành phẩm: Cánh gà bên giòn giòn rôm rốp, bên trong thịt ngọt mềm, mùi bơ tỏi dậy thơm. Khi ăn chấm cùng tương ớt, tương cà. Một món ăn thơm ngon, đổi vị ngày Tết được nhiều bạn nhỏ yêu thích. ')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (10, 1, N'Chọn và sơ chế gà: Để làm thịt gà nấu đông nên chọn gà trống thiến hoặc gà già thì khi ninh mới ngọt ngon, mềm mại. Gà sơ chế sạch, bóp hỗn hợp rượu gừng hoặc chanh, muối hạt khử mùi rồi rửa sạch, lọc thịt riêng, còn xương để ninh nước dùng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (10, 2, N'Chuẩn bị các nguyên liệu khác: Để tạo kết dính và đông nên dùng bì thăn cạo hết lông, bóp muối, rửa sạch. Có nhà dùng chân gà thay bì lợn để tạo độ kết dính (tùy chọn). Nấm hương, mộc nhĩ ngâm nở, bóp muối rồi rửa sạch, thái lát mỏng. ')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (10, 3, N'Ướp gà: Để nấu đông thuần khiết và thanh trong nên cho gà và bì vào nồi nước lạnh luộc để loại bỏ tạp chất, vớt ra rửa sạch. Phần gà cắt miếng vừa ăn rồi ướp chút muối hạt cho thấm vị. Phần bì sau khi luộc sơ, rửa sạch, lạng bỏ hết mỡ dưới da để khi nấu thanh trong, không bị nổi cợn mỡ trắng. ')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (10, 4, N'Ninh nước dùng và bì thăn: Phần xương gà đem rửa sạch, chần sơ cho vào ninh nước dùng cho ngọt ngon. Bì lợn cho vào ninh cùng, nêm chút muối hạt. Khi nước sôi trở lại, hớt bỏ bọt, mở vung và nấu ở lửa nhỏ để nước dùng được thanh trong và ngọt tự nhiên. Tránh đun lửa to hay đậy vung vì dễ khiến collagen trong da lợn, da gà phân rã vội làm đục nước, kém vị. Lửa liu riu cũng giúp chiết xuất collagen chuyển hóa từ từ thành gelatin, chất keo giúp kết dính và đông lại trong như thạch. ')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (10, 5, N'Nấu đông gà: Sau khi ninh nước dùng ngọt ngon, vớt bỏ phần xương gà. Cho thịt gà vào ninh tiếp ở lửa nhỏ liu riu, mở vung, thỉnh thoảng hớt bỏ bọt nếu có. Như vậy thịt đông sẽ trong vắt mà miếng thịt nguyên miếng, không bị nát. Khi thịt mềm nhừ, cho nấm hương, mộc nhĩ vào nấu tiếp ở lửa nhỏ cho thấm vị 6 - 8 phút giữ độ sần sật. Cuối cùng mới cho chút nước mắm ngon, mì chính (tùy chọn) là được. Tùy theo khẩu vị mỗi người, nếu không thích ăn bì có thể vớt bỏ bớt. ')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (10, 6, N'Làm đông thịt: Múc thịt gà, nấm hương, mộc nhĩ ra các bát hoặc hộp đựng thực phẩm chuyên dụng, múc nước ngập mặt, để nguội và đậy nắp cho vào ngăn mát tủ lạnh. Sau nửa ngày hoặc để qua đêm là thịt đông lại, mang ra thưởng thức. Khi ăn, úp bát thịt đông ra đĩa, rưới chút mắm truyền thống hạt tiêu ớt. ')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (10, 7, N'Yêu cầu thành phẩm: Thịt đông gà thuần khiết, trong veo như sương mai. Khi ăn cảm nhận rõ vị ngọt mát, mềm mại, thoảng hương thơm của nấm hương, chút giòn sần sật từ mộc nhĩ. Món này ăn kèm dưa muối chín tới rất ngon trong tiết trời lạnh đầu đông.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (11, 1, N'Làm cốt bánh panna cotta: 
Cốt bánh panna cotta được làm từ các nguyên liệu như: sữa tươi không đường, kem whipping cream, đường, gelatin và vani. Đầu tiên, bạn ngâm lá gelatin trong nước khoảng 5 phút cho gelatin nở mềm. Tiếp đến, bạn đun hỗn hợp gồm: gelatin, sữa tươi và đường. Khi đun, bạn lưu ý đun với lửa nhỏ đồng thời khuấy đều tay để gelatin và đường tan.

Khi gelatin và đường đã hoà tan, bạn cho thêm whipping cream vào, khuấy thật đều tay trong khoảng 2 - 3 phút rồi tắt bếp. Whipping cream sẽ giúp cốt bánh thơm và ngậy béo hơn. Sau cùng, bạn chỉ cần cho vào một ít bột vani, khuấy tan để tạo hương cho bánh là hoàn thành.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (11, 2, N'Đổ khuôn panna cotta: 
Sau khi bột vani tan đều, bạn hãy cho cốt bánh vừa làm vào khuôn hoặc những chiếc hũ nhỏ và để nguội. Tiếp đến, bạn chỉ cần cho panna cotta vào ngăn mát tủ lạnh, để từ 4 – 6 tiếng để hỗn hợp đông đặc.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (11, 3, N'Làm xốt chanh dây: 
Xốt chanh dây là một trong những thành phần quan trọng, tạo nên hương vị cho món bánh panna cotta. Chanh dây sau khi rửa sạch, bạn lọc lấy phần ruột và nước cốt, hoà cùng 200ml nước ấm rồi khuấy đều.

Tiếp theo, bạn đun nóng hỗn hợp nước chanh dây, đường và gelatin. Trong quá trình đun, bạn cần khuấy đều tay cho đường tan hết, đến khi xốt chanh dây chuyển sang dạng sệt là hoàn thành.

Ngoài xốt chanh dây, bạn có thể thay thế bằng trái cây tươi hoặc các loại xốt khác theo sở thích của mình.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (11, 4, N'Hoàn thành món ăn: 
Bước cuối cùng, bạn cho cốt bánh đã đông ra đĩa, trang trí thêm một ít xốt chanh dây lên mặt bánh là hoàn thành.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (19, 1, N'Trộn hỗn hợp với trứng: Tách ba lòng trắng trứng cho vào tô cùng 1 muỗng cà phê muối, sau đó dùng máy đánh trứng đánh tơi hỗn hợp lên, tiếp đến cho khoảng ½ muỗng cà phê cream of tartar vào, tiếp tục dùng máy đánh trứng đánh đều. Chia 60gr đường thành 2 phần: Lần đầu tiên cho 30gr đường vào hỗn hợp lòng trắng trứng, đánh khoảng 1 phút thì cho hết 30gr đường còn lại vào và đánh cho đến khi lòng trắng gần đạt bông cứng thì dừng lại. Tiếp theo, cho lần lượt một lòng đỏ trứng vào dùng máy đánh tiếp, lặp lại cho đến khi đánh đều hết cả 3 lòng đỏ trứng cùng hỗn hợp kem. Cho từ từ 20gr dầu ăn, 10gr sữa, 3ml vani vào hỗn hợp kem đánh bằng máy tiếp. Khoảng 1 phút sau cảm thấy hỗn hợp đã được hòa quyện vào nhau thì dừng lại.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (19, 2, N'Trộn hỗn hợp với trứng: Tách ba lòng trắng trứng cho vào tô cùng 1 muỗng cà phê muối, sau đó dùng máy đánh trứng đánh tơi hỗn hợp lên, tiếp đến cho khoảng ½ muỗng cà phê cream of tartar vào, tiếp tục dùng máy đánh trứng đánh đều. Chia 60gr đường thành 2 phần: Lần đầu tiên cho 30gr đường vào hỗn hợp lòng trắng trứng, đánh khoảng 1 phút thì cho hết 30gr đường còn lại vào và đánh cho đến khi lòng trắng gần đạt bông cứng thì dừng lại. Tiếp theo, cho lần lượt một lòng đỏ trứng vào dùng máy đánh tiếp, lặp lại cho đến khi đánh đều hết cả 3 lòng đỏ trứng cùng hỗn hợp kem. Cho từ từ 20gr dầu ăn, 10gr sữa, 3ml vani vào hỗn hợp kem đánh bằng máy tiếp. Khoảng 1 phút sau cảm thấy hỗn hợp đã được hòa quyện vào nhau thì dừng lại.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (20, 1, N'Sơ chế chân giò, nạm bò
Chân giò heo nếu thích nhiều thịt thì chọn chân sau, thích da và gân sần sật thì chọn chân trước, chặt thành những khoanh tròn, rửa sạch.

Luộc chân giò qua nước sôi cho hết chất bẩn sau đó rửa lại bằng nước sạch.

Nạm bò rửa sạch, luộc riêng cùng 1/2 củ gừng thái lát cho thơm. Ninh lửa nhỏ khoảng 2 tiếng, dùng đũa xiên thử miếng nạm, nếu xiên qua được là đạt yêu cầu. Đợi thịt nạm nguội thái miếng mỏng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (20, 2, N'Sơ chế các nguyên liệu khác
Huyết bò hoặc heo có thể mua sẵn hoặc mua huyết về luộc chín, thái miếng vừa ăn. (Lưu ý mua huyết ở những địa chỉ uy tín để đảm bảo an toàn thực phẩm). Nếu không ăn huyết có thể bỏ qua.

Chả cua nặn thành từng viên tròn nhỏ thả vào nồi nước luộc nạm, chả nổi lên là đã chín, bạn vớt ra để riêng. Có thể thay thế chả cua bằng chả bò, chả giò hoặc không cho chả cũng được.

Với 4 cây sả băm nhỏ, còn lại cắt khúc, đập dập. Hành tây chia 2 phần, một nữa cắt đôi, nữa còn lại thái mỏng.

Hành lá, mùi tàu, húng quế rửa sạch thái nhỏ. Các loại rau ăn kèm rửa sạch, để ráo nước.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (20, 3, N'Nấu bún bò Huế
Hòa 2 muỗng canh mắm ruốc với 100 ml nước lạnh.

Phi 4 cây sả băm cho thơm cùng 2 thìa dầu ăn, lấy bớt sả ra, cho 3 muỗng canh dầu màu điều vào. Băm nhuyễn 1 củ hành, 1 củ tỏi kèm 2 trái ớt rồi cho vào chảo phi vàng thì tắt bếp.

Chân giò heo đã sơ chế bạn cho lên bếp ninh lửa nhỏ cùng 1 củ hành tây cắt đôi và 3 cây sả đập dập cho nước dùng thơm ngọt, ra hết chất trong xương. (Lưu ý thỉnh thoảng hớt bọt nồi nước dùng để nước được trong).

Lấy phần trên của nước mắm ruốc cho vào nồi, bỏ phần cặn đi. Cho 2 muỗng canh đường, 2 muỗng canh hạt nêm, 1 muỗng canh muối vào, nêm nếm cho vừa miệng.

Thêm chén ớt sa tế đã làm ở trên vào.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (20, 4, N'Hoàn thành
Bạn trụng bún qua nước sôi, để ráo và trút ra tô.

Thêm thịt nạm, móng giò, chả cua, huyết, mùi tàu, hành lá thái nhỏ, một chút hành tây thái mỏng rồi chan nước dùng.

Bún bò Huế ăn kèm giá đỗ, hoa chuối, húng quế, ớt chưng thì tuyệt ngon bạn nhé.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (20, 5, N'Thành phẩm
Buổi sáng mát mẻ hay se lạnh làm một tô bún bò Huế thơm ngon đậm đà cùng cả nhà thì còn gì tuyệt vời bằng.

Vị ngọt thơm của nước, béo ngậy của móng giò, giòn giòn mềm ngon của thịt nạm, chả cua thơm lừng cùng một chút cay của ớt và chua chua của chanh. Chỉ nghĩ tới thôi đã cảm thấy mê man và thèm ngay một tô bún bò Huế.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (33, 1, N'Sơ chế xương bò và luộc sơ để khử mùi.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (33, 2, N'Hầm xương với các loại gia vị trong nhiều giờ.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (33, 3, N'Chần bánh phở, xếp thịt bò và chan nước dùng nóng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (34, 1, N'Nướng hoặc chiên thịt (heo, bò hoặc gà) đã ướp gia vị đến khi chín và thơm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (34, 2, N'Chuẩn bị bánh mì, cắt dọc lấy ruột nếu thích.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (34, 3, N'Phết mayonnaise hoặc pate lên bánh mì.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (34, 4, N'Xếp thịt đã nướng vào bánh mì.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (34, 5, N'Thêm dưa leo, cà rốt ngâm chua, rau mùi, hành ngò và ớt nếu thích.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (34, 6, N'Kẹp lại và thưởng thức.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (35, 1, N'Luộc tôm và thịt heo, thái lát mỏng thịt heo, bóc vỏ tôm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (35, 2, N'Ngâm bánh tráng trong nước ấm cho mềm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (35, 3, N'Trải bánh tráng ra, xếp rau sống, bún, tôm và thịt lên trên.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (35, 4, N'Cuộn chặt tay từ dưới lên trên.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (35, 5, N'Pha nước chấm (nước mắm, đường, tỏi, ớt, chanh hoặc tương đậu phộng) tùy thích.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (35, 6, N'Dùng kèm gỏi cuốn với nước chấm và thưởng thức.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (36, 1, N'Pha cà phê phin với khoảng 30-40ml nước sôi, để cà phê nhỏ giọt từ từ.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (36, 2, N'Đổ cà phê phin vào ly có sẵn đá viên.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (36, 3, N'Thêm sữa đặc có đường vừa đủ theo khẩu vị.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (36, 4, N'Khuấy đều và thưởng thức ngay khi còn lạnh.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (37, 1, N'Ngâm đậu xanh trong nước khoảng 4-5 giờ rồi rửa sạch.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (37, 2, N'Đun đậu xanh với nước, thêm chút muối và đường, nấu đến khi đậu chín mềm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (37, 3, N'Pha nước cốt dừa với đường và một ít muối, đun nóng nhưng không để sôi.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (37, 4, N'Khi đậu đã mềm, múc ra bát, thêm nước cốt dừa và thưởng thức khi nóng hoặc lạnh.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (38, 1, N'Pha bột bánh xèo với nước, thêm chút muối và nghệ, khuấy đều để bột không bị vón cục.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (38, 2, N'Rửa sạch tôm, thịt ba chỉ, thái nhỏ vừa ăn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (38, 3, N'Phi thơm hành với dầu ăn, cho thịt và tôm vào xào chín.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (38, 4, N'Đun chảo nóng, cho một lớp bột mỏng vào, rải thịt tôm lên trên, đậy nắp đun cho bánh chín giòn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (38, 5, N'Gấp bánh lại, lấy ra đĩa, ăn kèm rau sống và nước chấm pha chua ngọt.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (39, 1, N'Vo gạo tấm, nấu cơm tấm mềm, dẻo.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (39, 2, N'Marinade sườn với gia vị, nướng chín thơm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (39, 3, N'Làm bì bằng cách trộn da heo bào sợi với thính và gia vị.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (39, 4, N'Làm chả bằng cách trộn thịt heo xay, nêm nếm rồi hấp chín.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (39, 5, N'Dọn cơm, xếp sườn, bì, chả lên trên, rưới nước mắm chua ngọt.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (40, 1, N'Ninh xương bò lấy nước dùng trong và ngọt.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (40, 2, N'Chuẩn bị các gia vị như sả, ớt, mắm ruốc để tạo hương vị đặc trưng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (40, 3, N'Luộc bún tươi cho mềm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (40, 4, N'Nấu nước dùng với gia vị và thịt bò, giò heo cho chín mềm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (40, 5, N'Chan nước dùng lên bún, thêm hành lá, rau sống, và ớt tươi.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (41, 1, N'Nhào bột làm đế bánh, để nghỉ 1 tiếng cho bột nở.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (41, 2, N'Chuẩn bị sốt cà chua tươi, thêm gia vị.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (41, 3, N'Trải sốt cà chua lên đế bánh, trải phô mai mozzarella.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (41, 4, N'Nướng bánh ở nhiệt độ cao khoảng 10-12 phút.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (41, 5, N'Rắc lá húng quế tươi lên trên và phục vụ.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (42, 1, N'Luộc mì spaghetti trong nước sôi có muối đến khi mềm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (42, 2, N'Xào tỏi với dầu ô liu cho thơm, thêm thịt bò băm, sốt cà chua.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (42, 3, N'Nêm gia vị, hầm sốt cho đến khi sệt lại.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (42, 4, N'Trộn mì với sốt, rắc phô mai parmesan lên trên.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (42, 5, N'Dọn ra đĩa, trang trí thêm rau mùi tây.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (43, 1, N'Trộn bột mì, đường, bột nở, muối trong một tô lớn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (43, 2, N'Trong tô khác, đánh trứng với sữa và bơ đã đun chảy.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (43, 3, N'Đổ hỗn hợp ướt vào tô bột, khuấy đều đến khi mịn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (43, 4, N'Đun chảo chống dính, múc bột vào tạo hình bánh, chiên đến vàng hai mặt.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (43, 5, N'Phục vụ cùng mật ong hoặc siro maple.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (44, 1, N'Gọt vỏ và cắt xoài thành miếng nhỏ.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (44, 2, N'Cho xoài, sữa chua, mật ong và đá vào máy xay sinh tố.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (44, 3, N'Xay nhuyễn hỗn hợp đến khi mịn và sánh.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (44, 4, N'Rót ra ly, trang trí thêm lá bạc hà nếu thích.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (45, 1, N'Rửa sạch gà, để ráo.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (45, 2, N'Ướp gà với muối, tiêu, bột tỏi, ớt bột trong ít nhất 2 tiếng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (45, 3, N'Lăn gà qua bột mì rồi trứng đánh tan, sau đó lăn qua hỗn hợp bột chiên xù.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (45, 4, N'Chiên gà trong dầu nóng đến khi vàng giòn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (45, 5, N'Vớt ra giấy thấm dầu, thưởng thức.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (46, 1, N'Đánh lòng đỏ trứng với đường đến khi mịn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (46, 2, N'Thêm mascarpone và trộn đều.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (46, 3, N'Pha cà phê đen, nhúng bánh ladyfinger nhanh rồi xếp vào khuôn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (46, 4, N'Phủ kem mascarpone lên bánh, lặp lại lớp bánh và kem.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (46, 5, N'Rắc bột cacao lên trên và để lạnh ít nhất 4 giờ.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (47, 1, N'Trộn bột mochiko với đường và nước, khuấy đều.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (47, 2, N'Hấp bột đến khi chín, để nguội.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (47, 3, N'Chia bột thành từng phần nhỏ, bọc kem lạnh bên trong và vo tròn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (47, 4, N'Bọc mochi trong bột năng để không dính.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (48, 1, N'Đánh bơ với đường đến khi bông mịn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (48, 2, N'Thêm trứng và vani, trộn đều.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (48, 3, N'Từ từ cho bột mì vào, nhồi thành khối bột mịn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (48, 4, N'Cán bột, cắt hình và nướng ở 180 độ C trong 15-20 phút.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (49, 1, N'Rửa sạch rau xà lách, để ráo.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (49, 2, N'Nướng thịt gà, cắt lát vừa ăn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (49, 3, N'Pha nước sốt Caesar từ mayonnaise, tỏi, phô mai Parmesan và nước cốt chanh.')
GO
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (49, 4, N'Trộn rau xà lách với nước sốt, thêm thịt gà và bánh mì nướng giòn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (50, 1, N'Gọt vỏ và cắt bí đỏ thành khối nhỏ.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (50, 2, N'Xào hành tỏi thơm, cho bí đỏ vào đảo đều.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (50, 3, N'Đổ nước dùng vào, nấu đến khi bí chín mềm.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (50, 4, N'Dùng máy xay sinh tố xay nhuyễn súp, nêm muối, tiêu vừa ăn.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (50, 5, N'Thai kem tươi lên trên khi dùng.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (51, 1, N'Sắc nước trà đen hoặc trà xanh, để nguội.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (51, 2, N'Pha nước cốt cam, nước cốt sả và nước đường.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (51, 3, N'Cho đào cắt lát vào ly, thêm đá viên.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (51, 4, N'Rót trà đã nguội và hỗn hợp nước cam sả vào, khuấy đều.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (52, 1, N'Luộc mì ramen theo hướng dẫn trên bao bì, để ráo nước.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (52, 2, N'Nấu nước dùng từ xương heo hoặc gà, thêm gia vị.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (52, 3, N'Luộc trứng lòng đào, bóc vỏ.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (52, 4, N'Cho mì vào bát, thêm nước dùng, trứng, thịt và rau.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (52, 5, N'Trình bày và thưởng thức.')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (53, 1, N'Sơ chế')
INSERT [dbo].[Steps] ([RecipeID], [StepNumber], [Description]) VALUES (53, 2, N'Nấu')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (2, N'Annie Real', 1, NULL, N'', N'annieyzl@gmail.com', N'$2a$11$Omt1numt1JQpDWcPRksLj.sHOqehYaOvkwjxLNsFK2907vWSqGeg6', N'annie.jpg', CAST(N'2021-01-05 00:00:00.000' AS DateTime), N'', 0, N'user')
INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (3, N'Admin', 1, NULL, N'VN', N'admin@cr.com', N'$2a$11$VwDTa76B2dj5U3en77sxn.798JnxKjSl5BTeqk7YFmjcqP1IYS7Hi', N'638808218316301654_454721299_508749158301275_774913553837790506_n.jpg', CAST(N'2021-01-05 00:00:00.000' AS DateTime), N'Hj ae', 0, N'admin')
INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (5, N'Dương Ngọc Hoàn', 1, NULL, NULL, N'dnh@cr.com', N'$2a$11$Omt1numt1JQpDWcPRksLj.sHOqehYaOvkwjxLNsFK2907vWSqGeg6', N'user5.jpg', CAST(N'2021-01-05 00:00:00.000' AS DateTime), NULL, 0, N'admin')
INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (6, N'Hahaha', 0, NULL, N'VN', N'vtt@cr.com', N'$2a$11$Omt1numt1JQpDWcPRksLj.sHOqehYaOvkwjxLNsFK2907vWSqGeg6', N'user6.jpg', CAST(N'2021-01-05 00:00:00.000' AS DateTime), N'', 0, N'user')
INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (7, N'Annie', 0, 0, NULL, N'test@gmail.com', N'$2a$11$FdGr3opVMlvO.WPF3RlMG.wJUd5cQmc7wEPdXhyJcJqpT7pkM.Pl.', N'nophoto.jpg', CAST(N'2025-05-28 10:36:37.733' AS DateTime), NULL, 0, N'moderator')
INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (8, N'Quyen My', 1, 0, N'', N'ltmq@gmail.com', N'$2a$11$66fwOO2MOk9AUmepMxOQvu0uO9RgxEsXYr/ecrvhNZaRG8wh5QRoS', N'nophoto.jpg', CAST(N'2025-06-05 21:18:54.510' AS DateTime), N'', 0, N'moderator')
INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (9, N'Vy Ho', 0, 0, NULL, N'htz@gmail.com', N'$2a$11$UGFdUeIo.K7QIwSXhFFhU.lAupjSHLknzEwTM/BPGJHjKWc9pz04S', N'nophoto.jpg', CAST(N'2025-06-05 21:21:13.527' AS DateTime), NULL, 0, N'user')
INSERT [dbo].[Users] ([UserID], [FullName], [Gender], [UserPoint], [Address], [Email], [Password], [UserImage], [CreatedAt], [Caption], [IsLocked], [RoleNames]) VALUES (10, N'Thai Nga Le', 0, 0, NULL, N'ltn@gmail.com', N'$2a$11$4BQocScAI2yhQN6hi.BolOzZUiCDr3wmZAWGNo3WONEvtaSLZeCfq', N'nophoto.jpg', CAST(N'2025-06-05 21:21:28.917' AS DateTime), NULL, 0, N'user')
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[Views] ([RecipeID], [UserID], [IPAddress], [LastView], [ViewCount]) VALUES (6, 6, NULL, CAST(N'2025-04-10 20:42:55.177' AS DateTime), 2)
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Recipes]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[CourseRecipes]  WITH CHECK ADD  CONSTRAINT [FK_CourseRecipes_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseRecipes] CHECK CONSTRAINT [FK_CourseRecipes_Courses]
GO
ALTER TABLE [dbo].[CourseRecipes]  WITH CHECK ADD  CONSTRAINT [FK_CourseRecipes_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[CourseRecipes] CHECK CONSTRAINT [FK_CourseRecipes_Recipes]
GO
ALTER TABLE [dbo].[DishRecipes]  WITH CHECK ADD  CONSTRAINT [FK_DishRecipes_Dishes] FOREIGN KEY([DishID])
REFERENCES [dbo].[Dishes] ([DishID])
GO
ALTER TABLE [dbo].[DishRecipes] CHECK CONSTRAINT [FK_DishRecipes_Dishes]
GO
ALTER TABLE [dbo].[DishRecipes]  WITH CHECK ADD  CONSTRAINT [FK_DishRecipes_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[DishRecipes] CHECK CONSTRAINT [FK_DishRecipes_Recipes]
GO
ALTER TABLE [dbo].[Favourites]  WITH CHECK ADD  CONSTRAINT [FK_Favourites_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Favourites] CHECK CONSTRAINT [FK_Favourites_Recipes]
GO
ALTER TABLE [dbo].[Favourites]  WITH CHECK ADD  CONSTRAINT [FK_Favourites_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Favourites] CHECK CONSTRAINT [FK_Favourites_Users]
GO
ALTER TABLE [dbo].[ListRecipes]  WITH CHECK ADD  CONSTRAINT [FK_ListRecipes_Lists] FOREIGN KEY([ListID])
REFERENCES [dbo].[Lists] ([ListID])
GO
ALTER TABLE [dbo].[ListRecipes] CHECK CONSTRAINT [FK_ListRecipes_Lists]
GO
ALTER TABLE [dbo].[ListRecipes]  WITH CHECK ADD  CONSTRAINT [FK_ListRecipes_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[ListRecipes] CHECK CONSTRAINT [FK_ListRecipes_Recipes]
GO
ALTER TABLE [dbo].[Lists]  WITH CHECK ADD  CONSTRAINT [FK_Lists_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Lists] CHECK CONSTRAINT [FK_Lists_Users]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Recipes]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Recipes]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_Notifications_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_Notifications_Users]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Recipes]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Users]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Ingredients] FOREIGN KEY([IngredientID])
REFERENCES [dbo].[Ingredients] ([IngredientID])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Ingredients]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Recipes]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Users] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Users]
GO
ALTER TABLE [dbo].[Steps]  WITH CHECK ADD  CONSTRAINT [FK_Steps_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Steps] CHECK CONSTRAINT [FK_Steps_Recipes]
GO
ALTER TABLE [dbo].[Views]  WITH CHECK ADD  CONSTRAINT [FK_Views_Recipes] FOREIGN KEY([RecipeID])
REFERENCES [dbo].[Recipes] ([RecipeID])
GO
ALTER TABLE [dbo].[Views] CHECK CONSTRAINT [FK_Views_Recipes]
GO
ALTER TABLE [dbo].[Views]  WITH CHECK ADD  CONSTRAINT [FK_Views_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Views] CHECK CONSTRAINT [FK_Views_Users]
GO
USE [master]
GO
ALTER DATABASE [CookinRecipe] SET  READ_WRITE 
GO
