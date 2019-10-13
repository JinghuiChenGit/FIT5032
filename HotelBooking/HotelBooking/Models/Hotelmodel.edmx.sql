
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/16/2019 17:47:16
-- Generated from EDMX file: C:\Users\Jin\source\repos\HotelBooking\HotelBooking\Models\Hotelmodel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HotelDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Hotels'
CREATE TABLE [dbo].[Hotels] (
    [Hotel_id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Number_of_room] nvarchar(max)  NOT NULL,
    [Hotel_OwnerOwner_id] int  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Order_id] int IDENTITY(1,1) NOT NULL,
    [Check_in_date] datetime  NOT NULL,
    [Check_out_date] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [CustomerCustomer_id] int  NOT NULL,
    [RoomRoom_number] real  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [Room_number] real  NOT NULL,
    [Num_of_guests] smallint  NOT NULL,
    [Available] bit  NOT NULL,
    [HotelHotel_id] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [User_id] int IDENTITY(1,1) NOT NULL,
    [Account_id] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users_Customer'
CREATE TABLE [dbo].[Users_Customer] (
    [Customer_id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Contact_detail] nvarchar(max)  NULL,
    [DateOfBirth] datetime  NOT NULL,
    [User_id] int  NOT NULL
);
GO

-- Creating table 'Users_Hotel_Owner'
CREATE TABLE [dbo].[Users_Hotel_Owner] (
    [Owner_id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Contact_detail] nvarchar(max)  NOT NULL,
    [User_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Hotel_id] in table 'Hotels'
ALTER TABLE [dbo].[Hotels]
ADD CONSTRAINT [PK_Hotels]
    PRIMARY KEY CLUSTERED ([Hotel_id] ASC);
GO

-- Creating primary key on [Order_id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Order_id] ASC);
GO

-- Creating primary key on [Room_number] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([Room_number] ASC);
GO

-- Creating primary key on [User_id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([User_id] ASC);
GO

-- Creating primary key on [User_id] in table 'Users_Customer'
ALTER TABLE [dbo].[Users_Customer]
ADD CONSTRAINT [PK_Users_Customer]
    PRIMARY KEY CLUSTERED ([User_id] ASC);
GO

-- Creating primary key on [User_id] in table 'Users_Hotel_Owner'
ALTER TABLE [dbo].[Users_Hotel_Owner]
ADD CONSTRAINT [PK_Users_Hotel_Owner]
    PRIMARY KEY CLUSTERED ([User_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerCustomer_id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerCustomer_id])
    REFERENCES [dbo].[Users_Customer]
        ([User_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Orders]
    ([CustomerCustomer_id]);
GO

-- Creating foreign key on [Hotel_OwnerOwner_id] in table 'Hotels'
ALTER TABLE [dbo].[Hotels]
ADD CONSTRAINT [FK_Hotel_OwnerHotel]
    FOREIGN KEY ([Hotel_OwnerOwner_id])
    REFERENCES [dbo].[Users_Hotel_Owner]
        ([User_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Hotel_OwnerHotel'
CREATE INDEX [IX_FK_Hotel_OwnerHotel]
ON [dbo].[Hotels]
    ([Hotel_OwnerOwner_id]);
GO

-- Creating foreign key on [HotelHotel_id] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_HotelRoom]
    FOREIGN KEY ([HotelHotel_id])
    REFERENCES [dbo].[Hotels]
        ([Hotel_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HotelRoom'
CREATE INDEX [IX_FK_HotelRoom]
ON [dbo].[Rooms]
    ([HotelHotel_id]);
GO

-- Creating foreign key on [RoomRoom_number] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_RoomOrder]
    FOREIGN KEY ([RoomRoom_number])
    REFERENCES [dbo].[Rooms]
        ([Room_number])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomOrder'
CREATE INDEX [IX_FK_RoomOrder]
ON [dbo].[Orders]
    ([RoomRoom_number]);
GO

-- Creating foreign key on [User_id] in table 'Users_Customer'
ALTER TABLE [dbo].[Users_Customer]
ADD CONSTRAINT [FK_Customer_inherits_User]
    FOREIGN KEY ([User_id])
    REFERENCES [dbo].[Users]
        ([User_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_id] in table 'Users_Hotel_Owner'
ALTER TABLE [dbo].[Users_Hotel_Owner]
ADD CONSTRAINT [FK_Hotel_Owner_inherits_User]
    FOREIGN KEY ([User_id])
    REFERENCES [dbo].[Users]
        ([User_id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------