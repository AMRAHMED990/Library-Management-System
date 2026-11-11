/*
    Library Management System — database setup
    ------------------------------------------
    Creates LibraryDB with all tables, constraints and demo data.
    Run it in SQL Server Management Studio (open the file, press Execute), or from a terminal:
        sqlcmd -S .\SQLEXPRESS -E -i Database\schema.sql

    WARNING: re-running this script deletes LibraryDB and starts fresh.

    Default sign-in:  admin / admin123
*/

USE master;
GO

IF DB_ID(N'LibraryDB') IS NOT NULL
BEGIN
    ALTER DATABASE LibraryDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE LibraryDB;
END
GO

CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

/* ---------- Tables ---------- */

CREATE TABLE logintab (
    UserID        INT IDENTITY(1,1) PRIMARY KEY,
    Username      NVARCHAR(50)  NOT NULL CONSTRAINT UQ_logintab_Username UNIQUE,
    Password_Hash CHAR(64)      NOT NULL,   -- SHA-256 of the password (never store the password itself)
    Full_Name     NVARCHAR(100) NOT NULL,
    Role          NVARCHAR(20)  NOT NULL CONSTRAINT DF_logintab_Role DEFAULT (N'Admin')
);

CREATE TABLE librarians (
    LibrarianID  INT IDENTITY(1,1) PRIMARY KEY,
    Name         NVARCHAR(100) NOT NULL,
    Email        NVARCHAR(150) NOT NULL CONSTRAINT UQ_librarians_Email UNIQUE,
    Phone_Number VARCHAR(11)   NOT NULL
);

CREATE TABLE students (
    StudentID    INT IDENTITY(1,1) PRIMARY KEY,
    Student_Name NVARCHAR(100) NOT NULL,
    Gender       NVARCHAR(10)  NOT NULL CONSTRAINT CK_students_Gender CHECK (Gender IN (N'Male', N'Female')),
    Email        NVARCHAR(150) NOT NULL CONSTRAINT UQ_students_Email UNIQUE,
    Phone_Number VARCHAR(11)   NOT NULL,
    Address      NVARCHAR(200) NOT NULL
);

CREATE TABLE books (
    BookID    INT IDENTITY(1,1) PRIMARY KEY,
    ISBN      VARCHAR(13)   NULL,
    Book_Name NVARCHAR(200) NOT NULL,
    Author    NVARCHAR(150) NOT NULL,
    Publisher NVARCHAR(150) NOT NULL,
    Category  NVARCHAR(50)  NOT NULL CONSTRAINT DF_books_Category DEFAULT (N'Other'),
    Copies    INT           NOT NULL CONSTRAINT DF_books_Copies DEFAULT (1)
                                     CONSTRAINT CK_books_Copies CHECK (Copies >= 0)
);

CREATE TABLE issue (
    IssueID     INT IDENTITY(1,1) PRIMARY KEY,
    StudentID   INT  NOT NULL CONSTRAINT FK_issue_students REFERENCES students (StudentID),
    BookID      INT  NOT NULL CONSTRAINT FK_issue_books    REFERENCES books (BookID),
    Issue_Date  DATE NOT NULL,
    Due_Date    DATE NOT NULL,
    Return_Date DATE NULL,      -- NULL = still on loan
    CONSTRAINT CK_issue_Dates CHECK (Due_Date >= Issue_Date AND (Return_Date IS NULL OR Return_Date >= Issue_Date))
);

CREATE TABLE fine (
    FineID       INT IDENTITY(1,1) PRIMARY KEY,
    IssueID      INT           NOT NULL CONSTRAINT FK_fine_issue REFERENCES issue (IssueID),
    Amount       DECIMAL(10,2) NOT NULL CONSTRAINT CK_fine_Amount CHECK (Amount > 0),
    Paid         BIT           NOT NULL CONSTRAINT DF_fine_Paid DEFAULT (0),
    Fine_Date    DATE          NOT NULL,
    Paid_Date    DATE          NULL
);
GO

/* ---------- Demo data ---------- */

-- Default accounts:
-- admin / admin123 (Full Administrator)
-- subadmin / subadmin123 (Sub-administrator with restricted privileges)
INSERT INTO logintab (Username, Password_Hash, Full_Name, Role) VALUES
(N'admin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', N'admin123'), 2), N'Library Admin', N'Admin'),
(N'subadmin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', N'subadmin123'), 2), N'Library Subadmin', N'Subadmin');

INSERT INTO librarians (Name, Email, Phone_Number) VALUES
(N'Amr Ahmed',      N'amr.ahmed@library.edu',      '01012345678'),
(N'Nour El-Din',    N'nour.eldin@library.edu',     '01123456789'),
(N'Salma Fathy',    N'salma.fathy@library.edu',    '01234567890');

INSERT INTO students (Student_Name, Gender, Email, Phone_Number, Address) VALUES
(N'Mariam Hassan',   N'Female', N'mariam.hassan@student.edu',  '01001234567', N'Nasr City, Cairo'),
(N'Youssef Adel',    N'Male',   N'youssef.adel@student.edu',   '01112345670', N'Dokki, Giza'),
(N'Habiba Mostafa',  N'Female', N'habiba.mostafa@student.edu', '01223456701', N'Heliopolis, Cairo'),
(N'Omar Khaled',     N'Male',   N'omar.khaled@student.edu',    '01534567012', N'Maadi, Cairo'),
(N'Farida Samir',    N'Female', N'farida.samir@student.edu',   '01045678123', N'Sheikh Zayed, Giza'),
(N'Karim Tarek',     N'Male',   N'karim.tarek@student.edu',    '01156789234', N'Mohandessin, Giza'),
(N'Laila Ibrahim',   N'Female', N'laila.ibrahim@student.edu',  '01267890345', N'Zamalek, Cairo'),
(N'Ahmed Walid',     N'Male',   N'ahmed.walid@student.edu',    '01578901456', N'New Cairo, Cairo'),
(N'Nada Ashraf',     N'Female', N'nada.ashraf@student.edu',    '01089012567', N'6th of October, Giza'),
(N'Mohamed Sherif',  N'Male',   N'mohamed.sherif@student.edu', '01190123678', N'Shubra, Cairo');

INSERT INTO books (ISBN, Book_Name, Author, Publisher, Category, Copies) VALUES
('9780132350884', N'Clean Code',                                N'Robert C. Martin',           N'Prentice Hall',    N'Computer Science', 3),
('9780201616224', N'The Pragmatic Programmer',                  N'Andrew Hunt, David Thomas',  N'Addison-Wesley',   N'Computer Science', 2),
('9780262033848', N'Introduction to Algorithms',                N'Thomas H. Cormen',           N'MIT Press',        N'Computer Science', 4),
('9780201633610', N'Design Patterns',                           N'Erich Gamma',                N'Addison-Wesley',   N'Computer Science', 2),
('9780073523323', N'Database System Concepts',                  N'Abraham Silberschatz',       N'McGraw-Hill',      N'Computer Science', 3),
('9780133594140', N'Computer Networking: A Top-Down Approach',  N'James F. Kurose',            N'Pearson',          N'Computer Science', 2),
('9781285741550', N'Calculus: Early Transcendentals',           N'James Stewart',              N'Cengage',          N'Mathematics',      3),
('9780321982384', N'Linear Algebra and Its Applications',       N'David C. Lay',               N'Pearson',          N'Mathematics',      2),
('9781133947271', N'Physics for Scientists and Engineers',      N'Raymond A. Serway',          N'Cengage',          N'Science',          2),
('9780307887894', N'The Lean Startup',                          N'Eric Ries',                  N'Crown Business',   N'Business',         2),
('9780374533557', N'Thinking, Fast and Slow',                   N'Daniel Kahneman',            N'Farrar, Straus and Giroux', N'Science', 2),
('9780735211292', N'Atomic Habits',                             N'James Clear',                N'Avery',            N'Other',            3),
(NULL,            N'Palace Walk',                               N'Naguib Mahfouz',             N'Anchor',           N'Literature',       2),
('9780062316097', N'Sapiens: A Brief History of Humankind',     N'Yuval Noah Harari',          N'Harper',           N'History',          2),
('9781118063330', N'Operating System Concepts',                 N'Abraham Silberschatz',       N'Wiley',            N'Computer Science', 2);
GO

-- Loans spread over the last six months (relative to today) so the dashboard chart has data.
DECLARE @today DATE = CAST(GETDATE() AS DATE);
DECLARE @loanDays INT = 14;
DECLARE @finePerDay DECIMAL(10,2) = 5.00;

DECLARE @loans TABLE (Seq INT, StudentID INT, BookID INT, DaysAgo INT, ReturnedAfter INT NULL);
INSERT INTO @loans VALUES
( 1,  1,  1, 170, 10), ( 2,  2,  3, 160, 12), ( 3,  3,  5, 150, 20), ( 4,  4,  2, 140,  9),
( 5,  5,  7, 128, 14), ( 6,  6,  4, 120, 11), ( 7,  1,  8, 110, 18), ( 8,  7,  6, 100,  7),
( 9,  8,  9,  95, 13), (10,  2, 10,  90, 25), (11,  9, 11,  80, 12), (12, 10,  1,  75,  9),
(13,  3, 12,  70, 14), (14,  4, 13,  62, 16), (15,  5,  3,  55, 10), (16,  6, 14,  50, 13),
(17,  7,  2,  45, 12), (18,  8,  5,  40,  8), (19,  9, 15,  35, 30), (20, 10,  7,  30, 10),
-- still out (the first three are overdue)
(21,  1,  4,  26, NULL), (22,  2,  6,  22, NULL), (23,  3,  9,  18, NULL), (24,  4,  1,  12, NULL),
(25,  5,  8,   9, NULL), (26,  6, 11,   6, NULL), (27,  7,  3,   4, NULL), (28,  8, 12,   2, NULL),
(29,  9,  2,   1, NULL), (30, 10, 13,   0, NULL);

INSERT INTO issue (StudentID, BookID, Issue_Date, Due_Date, Return_Date)
SELECT StudentID,
       BookID,
       DATEADD(DAY, -DaysAgo, @today),
       DATEADD(DAY, @loanDays - DaysAgo, @today),
       CASE WHEN ReturnedAfter IS NULL THEN NULL ELSE DATEADD(DAY, ReturnedAfter - DaysAgo, @today) END
FROM @loans
ORDER BY Seq;

-- Fines for the loans that came back late (two of them already paid).
INSERT INTO fine (IssueID, Amount, Paid, Fine_Date, Paid_Date)
SELECT i.IssueID,
       DATEDIFF(DAY, i.Due_Date, i.Return_Date) * @finePerDay,
       p.Paid,
       i.Return_Date,
       CASE WHEN p.Paid = 1 THEN DATEADD(DAY, 3, i.Return_Date) END
FROM issue i
JOIN (VALUES (3, 0), (7, 1), (10, 1), (14, 0), (19, 0)) AS p (IssueID, Paid) ON p.IssueID = i.IssueID
WHERE i.Return_Date > i.Due_Date;
GO

PRINT 'LibraryDB is ready. Sign in with admin / admin123.';
