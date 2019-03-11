CREATE DATABASE [Tamagotchi2019]
GO
CREATE TABLE Tamagotchi2019.dbo.AnimalUri (
    AnimalUriId int IDENTITY(1,1) PRIMARY KEY,
    IdleUri varchar(2100) NOT NULL,
    PlayUri varchar(2100) NOT NULL,
    EatUri varchar(2100) NOT NULL,
	SleepUri varchar(2100) NOT NULL,
	AssemblyUri varchar(2100) NOT NULL,
	DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL
)
CREATE TABLE Tamagotchi2019.dbo.Player (
    PlayerId int IDENTITY(1,1) PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	PhotoUri varchar(255) NOT NULL,
    DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL
)
CREATE TABLE Tamagotchi2019.dbo.Animal (
    AnimalId int IDENTITY(1,1) PRIMARY KEY,
    [Name] varchar(255) NOT NULL,
	[Description] varchar(255),
	TimesDownloaded int,
	Ready bit NOT NULL,
	Active bit NOT NULL,
	DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL,
	PlayerId int FOREIGN KEY REFERENCES Player(PlayerId),
	AnimalUriId int FOREIGN KEY REFERENCES AnimalUri(AnimalUriId)
)
CREATE TABLE Tamagotchi2019.dbo.AnimalValues (
    AnimalValuesId int IDENTITY(1,1) PRIMARY KEY,
	ValueName varchar(255) NOT NULL,
	MaxValue decimal NOT NULL,
	MinValue decimal NOT NULL,
    DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL,
	AnimalId int FOREIGN KEY REFERENCES Animal(AnimalId)
)
CREATE TABLE Tamagotchi2019.dbo.[Session] (
    SessionId int IDENTITY(1,1) PRIMARY KEY,
	Token varchar(MAX) NOT NULL,
	Expiration datetime NOT NULL,	
    DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL,
	PlayerId int FOREIGN KEY REFERENCES Player(PlayerId)
)
CREATE TABLE Tamagotchi2019.dbo.[Login] (
    LoginId int IDENTITY(1,1) PRIMARY KEY,
	Email varchar(254) NOT NULL,
	[EncryptedPassword] varchar(MAX) NOT NULL,
    DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL,
	PlayerId int FOREIGN KEY REFERENCES Player(PlayerId)
)
CREATE TABLE Tamagotchi2019.dbo.PetGender (
	GenderId int IDENTITY(1,1) PRIMARY KEY,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),
	DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL
)
CREATE TABLE Tamagotchi2019.dbo.Pet (
    PetId int IDENTITY(1,1) PRIMARY KEY,
	Nickname varchar(255) NOT NULL,
    DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL,
	GenderId int FOREIGN KEY REFERENCES PetGender(GenderId),
	AnimalId int FOREIGN KEY REFERENCES Animal(AnimalId),
	PlayerId int FOREIGN KEY REFERENCES Player(PlayerId)
)
CREATE TABLE Tamagotchi2019.dbo.PetValues (
    PetValuesId int IDENTITY(1,1) PRIMARY KEY,
    DateCreated datetime NOT NULL,
	DateModified datetime NOT NULL,
	CurrentValue decimal NOT NULL,
	PetId int FOREIGN KEY REFERENCES Pet(PetId),
	AnimalId int FOREIGN KEY REFERENCES Animal(AnimalId)
)