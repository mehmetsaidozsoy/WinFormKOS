USE [KOSDb]
GO
/****** Object:  Table [dbo].[dolaplar]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[dolaplar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](30) NULL,
 CONSTRAINT [PK_dolaplar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[emanetler]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emanetler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kitapId] [int] NULL,
	[okuyucuId] [int] NULL,
	[emanetVerilisTarihi] [date] NULL,
	[emanetGeriAlmaTarihi] [date] NULL,
	[emanetIslemTarihi] [date] NULL,
	[durum] [int] NULL CONSTRAINT [DF_emanetler_durum]  DEFAULT ((0)),
	[aktif] [int] NULL CONSTRAINT [DF_emanetler_aktif]  DEFAULT ((1)),
 CONSTRAINT [PK_emanetler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[kitaplar]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kitaplar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kayitNo] [int] NULL,
	[kitapAdi] [varchar](30) NULL,
	[yazarAdi] [varchar](30) NULL,
	[yayinevi] [varchar](30) NULL,
	[basimYili] [varchar](10) NULL,
	[sayfaSayisi] [varchar](10) NULL,
	[tur] [varchar](30) NULL,
	[aciklama] [varchar](250) NULL,
	[dolap] [varchar](30) NULL,
	[raf] [varchar](10) NULL,
	[sira] [varchar](10) NULL,
	[durum] [int] NULL CONSTRAINT [DF_kitaplar_durum]  DEFAULT ((1)),
	[aktif] [int] NULL CONSTRAINT [DF_kitaplar_aktif]  DEFAULT ((1)),
 CONSTRAINT [PK_kitaplar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kullanicilar]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kullanicilar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](20) NULL,
	[soyadi] [varchar](20) NULL,
	[kullaniciAdi] [varchar](20) NULL,
	[sifre] [varchar](20) NULL,
	[aktif] [int] NULL CONSTRAINT [DF_kullanicilar_aktif]  DEFAULT ((1)),
 CONSTRAINT [PK_kullanicilar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[okuyucular]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[okuyucular](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](30) NULL,
	[soyadi] [varchar](30) NULL,
	[cinsiyeti] [varchar](10) NULL,
	[sinifi] [varchar](10) NULL,
	[okulNo] [varchar](10) NULL,
	[cepTel] [varchar](20) NULL,
	[adres] [varchar](250) NULL,
	[aktif] [int] NULL CONSTRAINT [DF_okuyucular_aktif]  DEFAULT ((1)),
 CONSTRAINT [PK_okuyucular] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[turler]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[turler](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](30) NULL,
 CONSTRAINT [PK_turler] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[yayinevleri]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[yayinevleri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](30) NULL,
 CONSTRAINT [PK_yayinevleri] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[yazarlar]    Script Date: 27.09.2018 21:10:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[yazarlar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [varchar](30) NULL,
 CONSTRAINT [PK_yazarlar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[dolaplar] ON 

INSERT [dbo].[dolaplar] ([id], [adi]) VALUES (5, N'ROMAN - HİKAYE')
INSERT [dbo].[dolaplar] ([id], [adi]) VALUES (6, N'BİLGİSAYAR - TEKNOLOJİ')
INSERT [dbo].[dolaplar] ([id], [adi]) VALUES (7, N'TARİH')
INSERT [dbo].[dolaplar] ([id], [adi]) VALUES (8, N'DİN - FELSEFE')
SET IDENTITY_INSERT [dbo].[dolaplar] OFF
SET IDENTITY_INSERT [dbo].[emanetler] ON 

INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (1, 8, 7, CAST(N'2018-09-25' AS Date), CAST(N'2018-10-25' AS Date), CAST(N'2018-09-26' AS Date), 1, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (2, 6, 6, CAST(N'2018-09-25' AS Date), CAST(N'2018-10-25' AS Date), CAST(N'2018-09-25' AS Date), 1, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (3, 9, 8, CAST(N'2018-09-25' AS Date), CAST(N'2018-10-25' AS Date), CAST(N'2018-09-25' AS Date), 1, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (4, 6, 7, CAST(N'2018-09-25' AS Date), CAST(N'2018-08-25' AS Date), CAST(N'2018-09-25' AS Date), 1, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (5, 6, 6, CAST(N'2018-09-26' AS Date), CAST(N'2018-10-26' AS Date), NULL, 0, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (6, 8, 8, CAST(N'2018-09-26' AS Date), CAST(N'2018-10-26' AS Date), CAST(N'2018-09-26' AS Date), 1, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (7, 9, 9, CAST(N'2018-09-26' AS Date), CAST(N'2018-10-26' AS Date), NULL, 0, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (8, 11, 10, CAST(N'2018-09-26' AS Date), CAST(N'2018-10-26' AS Date), NULL, 0, 1)
INSERT [dbo].[emanetler] ([id], [kitapId], [okuyucuId], [emanetVerilisTarihi], [emanetGeriAlmaTarihi], [emanetIslemTarihi], [durum], [aktif]) VALUES (9, 13, 7, CAST(N'2018-09-26' AS Date), CAST(N'2018-10-26' AS Date), NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[emanetler] OFF
SET IDENTITY_INSERT [dbo].[kitaplar] ON 

INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (1, 1, N'Gün Olur Asra Bedel', N'Yazar 1', N'Yayinevi 2', N'2015', N'150', N'Polisiye', N'asdasdasd', N'Polisiye', N'', N'', 1, 0)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (2, 2, N'Beyaz Gemi', N'Yazar 2', N'Yayinevi 3', N'2121', N'2121', N'Tarih', N'dasda', N'Polisiye', N'', N'', 1, 0)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (3, 2, N'Deneme 2', N'Yazar 2', N'Yayinevi 2', N'2015', N'', N'Roman', N'', N'Polisiye', N'', N'', 1, 0)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (4, 3, N'Deneme 3', N'Yazar 3', N'Yayinevi 2', N'2014', N'', N'Hikaye', N'', N'Polisiye', N'', N'', 1, 0)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (5, 3, N'Deneme 4', N'Yazar 2', N'Yayinevi 2', N'2015', N'1111', N'Hikaye', N'', N'Bilgisayar - Teknoloji', N'', N'', 1, 0)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (6, 1, N'Her Yönüyle C# 6.0', N'Sefer ALGAN', N'PUSULA', N'2016', N'500', N'BİLGİSAYAR', N'', N'BİLGİSAYAR - TEKNOLOJİ', N'', N'', 0, 1)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (7, 2, N'Her Yönüyle C# 7.0', N'Sefer ALGAN', N'PUSULA', N'2017', N'400', N'BİLGİSAYAR', N'', N'BİLGİSAYAR - TEKNOLOJİ', N'', N'', 1, 1)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (8, 3, N'Android Programlama', N'Muharrem TAÇ', N'DİKEYEKSEN', N'2012', N'250', N'BİLGİSAYAR', N'', N'BİLGİSAYAR - TEKNOLOJİ', N'', N'', 1, 1)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (9, 4, N'Swift İOS SDK', N'Tevfik KIZILÖREN', N'KODLAB', N'2015', N'300', N'BİLGİSAYAR', N'', N'BİLGİSAYAR - TEKNOLOJİ', N'5', N'1', 0, 1)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (10, 5, N'Böğürtlen Kışı', N'Sarah JİO', N'', N'2015', N'', N'ROMAN', N'', N'ROMAN - HİKAYE', N'5', N'1', 1, 1)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (11, 6, N'Mart Menekşeleri', N'Sarah JİO', N'', N'', N'', N'ROMAN', N'', N'ROMAN - HİKAYE', N'', N'', 0, 1)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (12, 7, N'Osmanlı İmparatorluğu', N'Halil İNALCIK', N'', N'', N'', N'TARİH', N'', N'TARİH', N'', N'', 1, 1)
INSERT [dbo].[kitaplar] ([id], [kayitNo], [kitapAdi], [yazarAdi], [yayinevi], [basimYili], [sayfaSayisi], [tur], [aciklama], [dolap], [raf], [sira], [durum], [aktif]) VALUES (13, 8, N'Beyaz Gemi', N'Cengiz AYTMATOV', N'', N'', N'', N'ROMAN', N'', N'ROMAN - HİKAYE', N'', N'', 0, 1)
SET IDENTITY_INSERT [dbo].[kitaplar] OFF
SET IDENTITY_INSERT [dbo].[kullanicilar] ON 

INSERT [dbo].[kullanicilar] ([id], [adi], [soyadi], [kullaniciAdi], [sifre], [aktif]) VALUES (1, N'Atabay', N'SAĞIN', N'admin', N'1', 1)
SET IDENTITY_INSERT [dbo].[kullanicilar] OFF
SET IDENTITY_INSERT [dbo].[okuyucular] ON 

INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (1, N'Atabay', N'SAĞIN', N'Erkek', N'6-A', N'522', N'(111) 111-1111', N'istanbul', 0)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (2, N'Merve 2', N'CAN 2', N'Kadın', N'6-B', N'555', N'(111) 111-1111', N'İstanbul', 0)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (3, N'Kaan', N'DEMİR', N'Erkek', N'6-D', N'1200', N'(111) 111-1111', N'İstanbul', 0)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (4, N'Merve', N'CAN', N'Kadın', N'6-E', N'1255', N'(111) 111-1111', N'', 0)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (5, N'Esra', N'DENEME', N'Kadın', N'6-A', N'5454', N'(111) 111-1111', N'', 0)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (6, N'Merve', N'CAN', N'Kadın', N'6-A', N'510', N'(111) 111-1111', N'İstanbul /  Zeytinburnu', 1)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (7, N'Atabay', N'SAĞIN', N'Erkek', N'6-B', N'520', N'(111) 111-1111', N'İstanbul / Bakırköy', 1)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (8, N'Kaan', N'DEMİR', N'Erkek', N'6-C', N'530', N'(111) 111-1111', N'İstanbul / Beşiktaş', 1)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (9, N'Esra', N'YILMAZ', N'Kadın', N'6-D', N'540', N'(111) 111-1111', N'İstanbul / Bayrampaşa', 1)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (10, N'Mehmet', N'DOĞAN', N'Erkek', N'6-E', N'550', N'(111) 111-1111', N'İstanbul / Kartal', 1)
INSERT [dbo].[okuyucular] ([id], [adi], [soyadi], [cinsiyeti], [sinifi], [okulNo], [cepTel], [adres], [aktif]) VALUES (11, N'', N'', N'', N'', N'', N'(   )    -', N'', 0)
SET IDENTITY_INSERT [dbo].[okuyucular] OFF
SET IDENTITY_INSERT [dbo].[turler] ON 

INSERT [dbo].[turler] ([id], [adi]) VALUES (5, N'ROMAN')
INSERT [dbo].[turler] ([id], [adi]) VALUES (6, N'BİLGİSAYAR')
INSERT [dbo].[turler] ([id], [adi]) VALUES (7, N'TARİH')
SET IDENTITY_INSERT [dbo].[turler] OFF
SET IDENTITY_INSERT [dbo].[yayinevleri] ON 

INSERT [dbo].[yayinevleri] ([id], [adi]) VALUES (5, N'DİKEYEKSEN')
INSERT [dbo].[yayinevleri] ([id], [adi]) VALUES (6, N'KODLAB')
INSERT [dbo].[yayinevleri] ([id], [adi]) VALUES (7, N'PUSULA')
SET IDENTITY_INSERT [dbo].[yayinevleri] OFF
SET IDENTITY_INSERT [dbo].[yazarlar] ON 

INSERT [dbo].[yazarlar] ([id], [adi]) VALUES (5, N'Sarah JİO')
INSERT [dbo].[yazarlar] ([id], [adi]) VALUES (6, N'Cengiz AYTMATOV')
INSERT [dbo].[yazarlar] ([id], [adi]) VALUES (7, N'Halil İNALCIK')
INSERT [dbo].[yazarlar] ([id], [adi]) VALUES (8, N'Sefer ALGAN')
INSERT [dbo].[yazarlar] ([id], [adi]) VALUES (9, N'Muharrem TAÇ')
INSERT [dbo].[yazarlar] ([id], [adi]) VALUES (10, N'Tevfik KIZILÖREN')
SET IDENTITY_INSERT [dbo].[yazarlar] OFF
