
USE LibraryManagement;
GO

-- B?ng T�c gi?
CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(100) NOT NULL,   -- H?
    FirstName NVARCHAR(100) NOT NULL,  -- T�n
    Biography NVARCHAR(MAX) NULL,
    Note NVARCHAR(255) NULL            -- Ghi ch�
);

-- B?ng Th? lo?i
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    Note NVARCHAR(255) NULL            -- Ghi ch�
);

-- B?ng Nh� xu?t b?n
CREATE TABLE Publishers (
    PublisherID INT IDENTITY(1,1) PRIMARY KEY,
    PublisherName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone VARCHAR(10),
    Note NVARCHAR(255) NULL            -- Ghi ch�
);

-- B?ng V? tr� ?? s�ch
CREATE TABLE BookLocations (
    LocationID INT IDENTITY(1,1) PRIMARY KEY,
    ShelfCode NVARCHAR(50) NOT NULL,       
    Floor NVARCHAR(50) NULL,              
    Room NVARCHAR(100) NULL,               
    Note NVARCHAR(255) NULL               
);

-- B?ng S�ch
CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    AuthorID INT NULL,
    CategoryID INT NULL,
    PublisherID INT NULL,
    YearPublished INT NULL,
    LocationID INT NULL,
    Quantity INT NOT NULL DEFAULT 0,
    Available INT NOT NULL DEFAULT 0,
    Note NVARCHAR(255) NULL,           -- Ghi ch�
    CONSTRAINT FK_Books_Locations FOREIGN KEY (LocationID) REFERENCES BookLocations(LocationID),
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID),
    CONSTRAINT FK_Books_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_Books_Publishers FOREIGN KEY (PublisherID) REFERENCES Publishers(PublisherID)
);

-- B?ng Th�nh vi�n
CREATE TABLE Members (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(100) NOT NULL,   -- H?
    FirstName NVARCHAR(100) NOT NULL,  -- T�n
    Email VARCHAR(100) UNIQUE,
    Phone VARCHAR(20),
    Address NVARCHAR(255),
    JoinDate DATE DEFAULT GETDATE(),
    Note NVARCHAR(255) NULL            -- Ghi ch�
);

-- B?ng Phi?u m??n
CREATE TABLE Borrowing (
    BorrowID INT IDENTITY(1,1) PRIMARY KEY,
    MemberID INT NOT NULL,
    BorrowDate DATE DEFAULT GETDATE(),
    DueDate DATE NOT NULL,
    ReturnDate DATE NULL,
    Status VARCHAR(20) DEFAULT '?ang m??n',
    Note NVARCHAR(255) NULL,
    CONSTRAINT FK_Borrowing_Members FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);
-- B?ng chi ti?t phi?u m??n
CREATE TABLE BorrowingDetails (
    DetailID INT IDENTITY(1,1) PRIMARY KEY,
    BorrowID INT NOT NULL,
    BookID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    Note NVARCHAR(255) NULL,
    CONSTRAINT FK_BorrowingDetails_Borrowing FOREIGN KEY (BorrowID) REFERENCES Borrowing(BorrowID),
    CONSTRAINT FK_BorrowingDetails_Books FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- B?ng Ng??i d�ng h? th?ng

CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,      
    PasswordHash NVARCHAR(255) NOT NULL,        
    FullName NVARCHAR(100) NOT NULL,            
    Email NVARCHAR(100) UNIQUE,                
    Role NVARCHAR(50) NOT NULL DEFAULT 'Staff', 
    IsActive BIT DEFAULT 1,                     
    CreatedAt DATETIME DEFAULT GETDATE(),       
    Note NVARCHAR(255) NULL                    
);

GO
-- them du lieu

INSERT INTO BookLocations (ShelfCode, Floor, Room, Note) VALUES
('A1', 'T?ng 1', 'Ph�ng ??c 101', N'K? s�ch v?n h?c'),
('B2', 'T?ng 2', 'Ph�ng l?u tr?', N'S�ch tham kh?o'),
('C3', 'T?ng 1', 'Ph�ng ??c 102', N'S�ch thi?u nhi'),
('D4', 'T?ng 3', 'Kho s�ch', N'S�ch c?'),
('E5', 'T?ng 2', 'Ph�ng ??c 201', N'S�ch ngo?i v?n');

INSERT INTO Authors (LastName, FirstName, Biography, Note) VALUES
(N'Nguy?n', N'Nh?t �nh', N'T�c gi? n?i ti?ng v?i s�ch thi?u nhi', N'Ti?u thuy?t h?c tr�'),
(N'Tr?n', N'??ng Khoa', N'Nh� th? t? th?i ni�n thi?u', N'Ghi ch� th�m'),
(N'V?', N'Tr�c Ph??ng', N'T�c gi? chuy�n vi?t truy?n ng?n', NULL),
(N'L�', N'Minh H�', N'Vi?t s�ch v? gi�o d?c v� t�m l�', NULL),
(N'Ph?m', N'Ti?n Du?t', N'Nh� th? th?i chi?n tranh', N'T�c ph?m n?i b?t: B�i th? v? ti?u ??i xe kh�ng k�nh');

INSERT INTO Categories (CategoryName, Note) VALUES
(N'Thi?u nhi', N'S�ch d�nh cho tr? em'),
(N'V?n h?c Vi?t Nam', N'T�c ph?m trong n??c'),
(N'Khoa h?c', N'S�ch nghi�n c?u, h?c thu?t'),
(N'T�m l� - Gi�o d?c', N'S�ch ph�t tri?n b?n th�n'),
(N'Ngo?i v?n', N'S�ch ti?ng Anh, Ph�p...');

INSERT INTO Publishers (PublisherName, Address, Phone, Note) VALUES
(N'NXB Tr?', N'161B L� Ch�nh Th?ng, Q.3, TP.HCM', '02838299999', N'Chuy�n s�ch thi?u nhi'),
(N'NXB Kim ??ng', N'55 Quang Trung, H� N?i', '02438255555', N'S�ch h?c sinh'),
(N'NXB Gi�o D?c', N'81 Tr?n H?ng ??o, H� N?i', '02439430000', NULL),
(N'NXB V?n H?c', N'4 ?inh L?, H� N?i', '02439388888', N'S�ch v?n h?c'),
(N'NXB T?ng H?p', N'62 Nguy?n Th? Minh Khai, TP.HCM', '02839393939', NULL);

INSERT INTO Books (Title, AuthorID, CategoryID, PublisherID, YearPublished, Quantity, Available, Note, LocationID) VALUES
(N'M?t Bi?c', 1, 2, 1, 2008, 10, 10, NULL, 1),
(N'G�c nh? tu?i th?', 2, 1, 2, 2010, 5, 5, N'S�ch th?', 3),
(N'B� m?t c?a n�o b?', 4, 4, 3, 2015, 7, 7, NULL, 2),
(N'Chi?n tranh v� h�a b�nh', 5, 2, 4, 1990, 3, 3, N'T�c ph?m kinh ?i?n', 4),
(N'English Grammar in Use', NULL, 5, 5, 2020, 12, 12, N'S�ch h?c ti?ng Anh', 5);

INSERT INTO Members (LastName, FirstName, Email, Phone, Address, Note) VALUES
(N'Nguy?n', N'Lan', 'lan.nguyen@example.com', '0912345678', N'H� N?i', NULL),
(N'Tr?n', N'Ho�ng', 'hoang.tran@example.com', '0987654321', N'H? Ch� Minh', N'Th�nh vi�n t�ch c?c'),
(N'L�', N'Th?o', 'thao.le@example.com', '0909090909', N'?� N?ng', NULL),
(N'Ph?m', N'Qu�n', 'quan.pham@example.com', '0939393939', N'C?n Th?', NULL),
(N'V?', N'Mai', 'mai.vu@example.com', '0922222222', N'H?i Ph�ng', N'M??n nhi?u s�ch');

INSERT INTO Borrowing (MemberID, BorrowDate, DueDate, ReturnDate, Status, Note) VALUES
(1, '2025-08-20', '2025-08-27', NULL, N'?ang m??n', NULL),
(2, '2025-08-18', '2025-08-25', '2025-08-24', N'?� tr?', NULL),
(3, '2025-08-19', '2025-08-26', NULL, N'?ang m??n', N'M??n l?n ??u'),
(4, '2025-08-21', '2025-08-28', NULL, N'?ang m??n', NULL),
(5, '2025-08-22', '2025-08-29', NULL, N'?ang m??n', NULL);

INSERT INTO BorrowingDetails (BorrowID, BookID, Quantity, Note) VALUES
(1, 1, 1, NULL),
(2, 2, 1, NULL),
(3, 3, 2, N'M??n cho nh�m h?c'),
(4, 4, 1, NULL),
(5, 5, 1, N'S�ch h?c ti?ng Anh');
GO
ALTER TABLE Users
ADD SecurityQuestion1 NVARCHAR(255) NULL,
    SecurityAnswerHash1 NVARCHAR(255) NULL,
    SecurityQuestion2 NVARCHAR(255) NULL,
    SecurityAnswerHash2 NVARCHAR(255) NULL,
    SecurityQuestion3 NVARCHAR(255) NULL,
    SecurityAnswerHash3 NVARCHAR(255) NULL;
GO
-- X�a c�c c?t kh�ng c?n thi?t
ALTER TABLE Borrowing
DROP COLUMN DueDate, ReturnDate,Status;

-- Th�m c?t UserID
ALTER TABLE Borrowing
ADD UserID INT NOT NULL;

-- T?o r�ng bu?c kh�a ngo?i t?i b?ng Users
ALTER TABLE Borrowing
ADD CONSTRAINT FK_Borrowing_Users FOREIGN KEY (UserID) REFERENCES Users(UserID);

-- them du lieu cho book--
ALTER TABLE Books
ADD Price DECIMAL(18,2) NULL,   -- Gi� b�n
    BorrowPrice DECIMAL(18,2) NULL;