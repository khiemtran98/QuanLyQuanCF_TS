USE [QuanLyQuanCF_TS]
GO
/****** Object:  Table [dbo].[Mon]    Script Date: 09/28/2018 13:40:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mon](
	[mamon] [int] IDENTITY(1,1) NOT NULL,
	[tenmon] [nvarchar](max) NULL,
	[loaimon] [int] NULL,
	[hinh] [nvarchar](max) NULL,
	[giatien] [float] NULL,
 CONSTRAINT [PK_Mon] PRIMARY KEY CLUSTERED 
(
	[mamon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Mon] ON
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (1, N'Trà sữa trân châu', 1, N'1.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (2, N'Trà sưa hokkaido', 1, N'2.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (3, N'Trà sữa ô long', 1, N'3.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (4, N'Trà sữa vị hoa nhài', 1, N'4.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (5, N'Hồng trà sữa', 1, N'5.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (6, N'Trà sữa khoai môn', 1, N'6.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (7, N'Trà sữa chocolate', 1, N'7.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (8, N'Trà sữa hạt dẻ', 1, N'8.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (9, N'Trà sữa đường đen', 1, N'9.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (10, N'Trà sữa thạch dừa', 1, N'10.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (11, N'Trà sữa valina', 1, N'11.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (12, N'Trà sữa thạch rau câu', 1, N'12.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (13, N'Trà sữa đậu đỏ', 1, N'13.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (14, N'Phin sữa đá', 2, N'14.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (15, N'Phin đen đá', 2, N'15.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (16, N'Phin sữa nóng', 2, N'16.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (17, N'Phin đen nóng', 2, N'17.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (18, N'Latte', 2, N'18.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (19, N'Cappuccino', 2, N'19.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (20, N'Caramel macchiato', 2, N'20.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (21, N'Mocha', 2, N'21.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (22, N'Americano', 2, N'22.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (23, N'Espresso', 2, N'23.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (24, N'Caramel Phin Freeze', 3, N'24.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (25, N'Classic Phin Freeze', 3, N'25.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (26, N'Freeze trà xanh', 3, N'26.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (27, N'Freeze socola', 3, N'27.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (28, N'Cookies & cream', 3, N'28.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (29, N'Trà sen vàng', 1, N'29.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (30, N'Trà thạch đào', 1, N'30.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (31, N'Trà thanh đào', 1, N'31.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (32, N'Trà thạch vãi', 1, N'32.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (33, N'Trà xanh đậu đỏ', 1, N'33.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (34, N'Trà sữa trân châu đường đen', 1, N'34.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (35, N'Chocolate trân châu đường đen', 1, N'35.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (36, N'Đường đen trân châu sủi bọt', 1, N'36.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (37, N'Matcha trân chân đường đen', 1, N'37.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (38, N'1883 trân châu sủi bọt', 1, N'38.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (39, N'Trà trái cây main tea', 1, N'39.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (40, N'Lục trà cam nha đam', 1, N'40.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (41, N'Lục trà thạch bông cỏ', 1, N'41.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (42, N'Lục trà kim quất xí mụi', 1, N'42.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (43, N'Trà machada hạt chia', 1, N'43.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (44, N'Hồng trà vãi hạt chia', 1, N'44.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (45, N'Trà sấu táo đỏ thạch bông cỏ', 1, N'45.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (46, N'Lục trà kim quất mãng cầu', 1, N'46.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (47, N'Trà xanh vải hạt chia', 1, N'47.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (48, N'Trà chanh thanh long đỏ macchiato  ', 1, N'48.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (49, N'Trà chanh thanh long đỏ macchiato nhỏ  ', 1, N'49.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (50, N'Trà đen macchiato', 1, N'50.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (51, N'Trà xanh macchiato', 1, N'51.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (52, N'Lục trà xoài macchiato', 1, N'52.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (53, N'Trà olong nhân sâm hoa mộc macchiato ', 1, N'53.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (54, N'Trà bá tước hoa hồng', 1, N'54.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (55, N'Trà chanh dây macchiato', 1, N'55.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (56, N'Trà xanh gạo rang', 1, N'56.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (57, N'Trà đen', 1, N'57.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (58, N'Bánh mì thịt nướng', 4, N'58.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (59, N'Bánh mì gà xé nước tương', 4, N'59.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (60, N'Bánh mì chả lụa xá xíu', 4, N'60.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (61, N'Bánh mì xíu mại', 4, N'61.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (62, N'Bánh tiramisu', 4, N'62.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (63, N'Bánh chuối', 4, N'63.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (64, N'Bánh phô mai Caramel', 4, N'64.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (65, N'Bánh phô mai chanh dây', 4, N'65.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (66, N'Bánh phô mai trà xanh', 4, N'66.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (67, N'Bánh phô mai cà phê', 4, N'67.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (68, N'Bánh socola', 4, N'68.jpg', 5000)
INSERT [dbo].[Mon] ([mamon], [tenmon], [loaimon], [hinh], [giatien]) VALUES (69, N'Bánh mousse cacao', 4, N'69.jpg', 5000)
SET IDENTITY_INSERT [dbo].[Mon] OFF
/****** Object:  ForeignKey [FK_Mon_LoaiMon]    Script Date: 09/28/2018 13:40:54 ******/
ALTER TABLE [dbo].[Mon]  WITH CHECK ADD  CONSTRAINT [FK_Mon_LoaiMon] FOREIGN KEY([loaimon])
REFERENCES [dbo].[LoaiMon] ([maloaimon])
GO
ALTER TABLE [dbo].[Mon] CHECK CONSTRAINT [FK_Mon_LoaiMon]
GO
