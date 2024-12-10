CREATE DATABASE BookSource;

USE BookSource;


-- DELETE IF EXISTS
DROP TABLE PublicationLikes;
DROP TABLE Publication;
DROP TABLE Review;
DROP TABLE Book_Category;
DROP TABLE ListOfBooks_Book;
DROP TABLE Follow;
DROP TABLE Book;
DROP TABLE ListOfBooks;
DROP TABLE Category;
DROP TABLE [User];

-- CREATE
CREATE TABLE [User] (
    IdUser int IDENTITY(1,1) PRIMARY KEY,
    UserName varchar(255) UNIQUE NOT NULL,
    Email varchar(255) UNIQUE NOT NULL,
    PasswordHash varbinary(MAX) NOT NULL,
    PasswordSalt varbinary(MAX) NOT NULL,
    BirthDate date,
    ProfileImageUrl varchar(255)
);

CREATE TABLE Follow (
    FkIdFollower int NOT NULL,
    FkIdFollowed int NOT NULL,
    PRIMARY KEY (FkIdFollower, FkIdFollowed),
    FOREIGN KEY (FkIdFollower) REFERENCES [User](IdUser),
    FOREIGN KEY (FkIdFollowed) REFERENCES [User](IdUser)
);

CREATE TABLE [ListOfBooks] (
	IdListOfBooks int IDENTITY(1,1) PRIMARY KEY,
	ListName varchar(255) NOT NULL,
	FkIdUser int NOT NULL,
	FOREIGN KEY (FkIdUser) REFERENCES [User](IdUser)
);

CREATE TABLE Book (
	IdBook int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(255) NOT NULL,
	Author varchar(255) NOT NULL,
	[Description] varchar(5000),
	ImageUrl varchar(255),
	Subtitle varchar(255),
	Editorial varchar(255),
	[PageCount] int,
	Score double precision
);

CREATE TABLE ListOfBooks_Book (
    FkIdListOfBooks int,
    FkIdBook int,
    PRIMARY KEY (FkIdListOfBooks, FkIdBook),
    FOREIGN KEY (FkIdListOfBooks) REFERENCES [ListOfBooks](IdListOfBooks)
        ON DELETE CASCADE,
    FOREIGN KEY (FkIdBook) REFERENCES Book(IdBook)
        ON DELETE CASCADE
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