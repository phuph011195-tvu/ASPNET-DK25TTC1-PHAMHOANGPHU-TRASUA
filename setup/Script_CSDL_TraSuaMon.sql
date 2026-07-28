-- 1. TẠO VÀ CHỌN DATABASE
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'TraSuaMonDb')
BEGIN
    CREATE DATABASE [TraSuaMonDb];
END
GO

USE [TraSuaMonDb];
GO

-- 2. TẠO BẢNG QUẢN LÝ MIGRATION CỦA EF CORE
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

-- 3. TẠO CÁC BẢNG DỮ LIỆU
BEGIN TRANSACTION;

CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [ImageUrl] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260705134257_InitialCreate', N'10.0.9');

COMMIT;
GO

-- 4. THÊM DỮ LIỆU MẪU (SEED DATA)
SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([Id], [Name], [Description]) VALUES 
(1, N'Trà Sữa Truyền Thống', N'Các loại trà sữa hương vị đậm đà truyền thống'),
(2, N'Trà Trái Cây', N'Trà trái cây thanh mát, giải nhiệt'),
(3, N'Topping Extra', N'Các loại topping ăn kèm');
SET IDENTITY_INSERT [Categories] OFF;
GO

SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([Id], [Name], [Price], [ImageUrl], [Description], [CategoryId]) VALUES 
(1, N'Trà Sữa Trân Châu Hoàng Gia', 35000.00, N'/images/trasua-tranchau.jpg', N'Trà sữa thơm ngon kèm trân châu đen dai giòn', 1),
(2, N'Trà Sữa Matcha Đậu Đỏ', 40000.00, N'/images/trasua-matcha.jpg', N'Hương vị matcha chuẩn Nhật Bản kết hợp đậu đỏ', 1),
(3, N'Trà Đào Cam Sả', 38000.00, N'/images/tradao-camsa.jpg', N'Trà đào tươi mát kết hợp vị sả thanh nhẹ', 2),
(4, N'Trà Vải Nhài', 38000.00, N'/images/travai-nhai.jpg', N'Trà nhài thơm ngát kết hợp trái vải mọng nước', 2);
SET IDENTITY_INSERT [Products] OFF;
GO
