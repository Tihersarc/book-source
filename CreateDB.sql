CREATE TABLE [User] (
    IdUser int IDENTITY(1,1) PRIMARY KEY,
    UserName varchar(255) UNIQUE NOT NULL,
    Email varchar(255) UNIQUE NOT NULL,
    PasswordHash varbinary(MAX),
    PasswordSalt varbinary(MAX),
    BirthDate date,
    ProfileImageUrl varchar(255)
);

CREATE TABLE Follow (
    IdFollower int,
    IdFollowed int,
    PRIMARY KEY (IdFollower, IdFollowed),
    FOREIGN KEY (IdFollower) REFERENCES [User](IdUser),
    FOREIGN KEY (IdFollowed) REFERENCES [User](IdUser)
);

CREATE TABLE [Library] (
	IdLibrary int IDENTITY(1,1) PRIMARY KEY,
	ListName varchar(255) NOT NULL,
	FkIdUser int NOT NULL,
	FOREIGN KEY (FkIdUser) REFERENCES [User](IdUser)
);

CREATE TABLE Book (
	IdBook int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255) NOT NULL,
	Author varchar(255) NOT NULL,
	[Description] varchar(1024),
	ImageLink varchar(255),
	Subtitle varchar(255),
	Editorial varchar(255),
	[PageCount] varchar(255),
	Score double precision
);

CREATE TABLE Library_Book (
	FkIdLibrary int,
	FkIdBook int,
	PRIMARY KEY (FkIdLibrary, FkIdBook),
	FOREIGN KEY (FkIdLibrary) REFERENCES [Library](IdLibrary),
	FOREIGN KEY (FkIdBook) REFERENCES Book(IdBook)
);

CREATE TABLE Review (
	IdReview int IDENTITY(1,1) PRIMARY KEY,
	Comment varchar(512) NOT NULL,
	FKIdBook int NOT NULL,
	FkIdUser int NOT NULL,
	FOREIGN KEY (FKIdBook) REFERENCES Book(IdBook),
	FOREIGN KEY (FkIdUser) REFERENCES [User](IdUser),
);

CREATE TABLE Category (
	IdCategory int IDENTITY(1,1) PRIMARY KEY,
	CategoryName varchar(255) UNIQUE NOT NULL
);

CREATE TABLE Book_Category (
	FkIdCategory int NOT NULL,
	FkIdBook int NOT NULL,
	PRIMARY KEY (FkIdCategory, FkIdBook),
	FOREIGN KEY (FkIdCategory) REFERENCES Category(IdCategory),
	FOREIGN KEY (FkIdBook) REFERENCES Book(IdBook)
);


CREATE TABLE Publication (
	IdPublication int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255) NOT NULL,
	Content varchar(255) NOT NULL,
	PubImage varchar(255),
	FkIdUser int NOT NULL,
	FOREIGN KEY (FkIdUser) REFERENCES [User](IdUser)
);

CREATE TABLE PublicationLikes (
	FkIdUser int NOT NULL,
	FkIdPublication int NOT NULL,
	PRIMARY KEY (FkIdUser, FkIdPublication),
	FOREIGN KEY (FkIdUser) REFERENCES [User](IdUser),
	FOREIGN KEY (FkIdPublication) REFERENCES Publication(IdPublication)
);