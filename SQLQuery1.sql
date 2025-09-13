
USE LibraryManagement;
GO

-- B?ng Tác gi?
CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(100) NOT NULL,   -- H?
    FirstName NVARCHAR(100) NOT NULL,  -- Tên
    Biography NVARCHAR(MAX) NULL,
    Note NVARCHAR(255) NULL            -- Ghi chú
);

-- B?ng Th? lo?i
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    Note NVARCHAR(255) NULL            -- Ghi chú
);

-- B?ng Nhà xu?t b?n
CREATE TABLE Publishers (
    PublisherID INT IDENTITY(1,1) PRIMARY KEY,
    PublisherName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone VARCHAR(10),
    Note NVARCHAR(255) NULL            -- Ghi chú
);

-- B?ng V? trí ?? sách
CREATE TABLE BookLocations (
    LocationID INT IDENTITY(1,1) PRIMARY KEY,
    ShelfCode NVARCHAR(50) NOT NULL,       
    Floor NVARCHAR(50) NULL,              
    Room NVARCHAR(100) NULL,               
    Note NVARCHAR(255) NULL               
);

-- B?ng Sách
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
    Note NVARCHAR(255) NULL,           -- Ghi chú
    CONSTRAINT FK_Books_Locations FOREIGN KEY (LocationID) REFERENCES BookLocations(LocationID),
    CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID),
    CONSTRAINT FK_Books_Categories FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_Books_Publishers FOREIGN KEY (PublisherID) REFERENCES Publishers(PublisherID)
);

-- B?ng Thành viên
CREATE TABLE Members (
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(100) NOT NULL,   -- H?
    FirstName NVARCHAR(100) NOT NULL,  -- Tên
    Email VARCHAR(100) UNIQUE,
    Phone VARCHAR(20),
    Address NVARCHAR(255),
    JoinDate DATE DEFAULT GETDATE(),
    Note NVARCHAR(255) NULL            -- Ghi chú
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

-- B?ng Ng??i dùng h? th?ng

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
('A1', 'T?ng 1', 'Phòng ??c 101', N'K? sách v?n h?c'),
('B2', 'T?ng 2', 'Phòng l?u tr?', N'Sách tham kh?o'),
('C3', 'T?ng 1', 'Phòng ??c 102', N'Sách thi?u nhi'),
('D4', 'T?ng 3', 'Kho sách', N'Sách c?'),
('E5', 'T?ng 2', 'Phòng ??c 201', N'Sách ngo?i v?n');

INSERT INTO Authors (LastName, FirstName, Biography, Note) VALUES
(N'Nguy?n', N'Nh?t Ánh', N'Tác gi? n?i ti?ng v?i sách thi?u nhi', N'Ti?u thuy?t h?c trò'),
(N'Tr?n', N'??ng Khoa', N'Nhà th? t? th?i niên thi?u', N'Ghi chú thêm'),
(N'V?', N'Trúc Ph??ng', N'Tác gi? chuyên vi?t truy?n ng?n', NULL),
(N'Lê', N'Minh Hà', N'Vi?t sách v? giáo d?c và tâm lý', NULL),
(N'Ph?m', N'Ti?n Du?t', N'Nhà th? th?i chi?n tranh', N'Tác ph?m n?i b?t: Bài th? v? ti?u ??i xe không kính');

INSERT INTO Categories (CategoryName, Note) VALUES
(N'Thi?u nhi', N'Sách dành cho tr? em'),
(N'V?n h?c Vi?t Nam', N'Tác ph?m trong n??c'),
(N'Khoa h?c', N'Sách nghiên c?u, h?c thu?t'),
(N'Tâm lý - Giáo d?c', N'Sách phát tri?n b?n thân'),
(N'Ngo?i v?n', N'Sách ti?ng Anh, Pháp...');

INSERT INTO Publishers (PublisherName, Address, Phone, Note) VALUES
(N'NXB Tr?', N'161B Lý Chính Th?ng, Q.3, TP.HCM', '02838299999', N'Chuyên sách thi?u nhi'),
(N'NXB Kim ??ng', N'55 Quang Trung, Hà N?i', '02438255555', N'Sách h?c sinh'),
(N'NXB Giáo D?c', N'81 Tr?n H?ng ??o, Hà N?i', '02439430000', NULL),
(N'NXB V?n H?c', N'4 ?inh L?, Hà N?i', '02439388888', N'Sách v?n h?c'),
(N'NXB T?ng H?p', N'62 Nguy?n Th? Minh Khai, TP.HCM', '02839393939', NULL);

INSERT INTO Books (Title, AuthorID, CategoryID, PublisherID, YearPublished, Quantity, Available, Note, LocationID) VALUES
(N'M?t Bi?c', 1, 2, 1, 2008, 10, 10, NULL, 1),
(N'Góc nh? tu?i th?', 2, 1, 2, 2010, 5, 5, N'Sách th?', 3),
(N'Bí m?t c?a não b?', 4, 4, 3, 2015, 7, 7, NULL, 2),
(N'Chi?n tranh và hòa bình', 5, 2, 4, 1990, 3, 3, N'Tác ph?m kinh ?i?n', 4),
(N'English Grammar in Use', NULL, 5, 5, 2020, 12, 12, N'Sách h?c ti?ng Anh', 5);

INSERT INTO Members (LastName, FirstName, Email, Phone, Address, Note) VALUES
(N'Nguy?n', N'Lan', 'lan.nguyen@example.com', '0912345678', N'Hà N?i', NULL),
(N'Tr?n', N'Hoàng', 'hoang.tran@example.com', '0987654321', N'H? Chí Minh', N'Thành viên tích c?c'),
(N'Lê', N'Th?o', 'thao.le@example.com', '0909090909', N'?à N?ng', NULL),
(N'Ph?m', N'Quân', 'quan.pham@example.com', '0939393939', N'C?n Th?', NULL),
(N'V?', N'Mai', 'mai.vu@example.com', '0922222222', N'H?i Phòng', N'M??n nhi?u sách');

INSERT INTO Borrowing (MemberID, BorrowDate, DueDate, ReturnDate, Status, Note) VALUES
(1, '2025-08-20', '2025-08-27', NULL, N'?ang m??n', NULL),
(2, '2025-08-18', '2025-08-25', '2025-08-24', N'?ã tr?', NULL),
(3, '2025-08-19', '2025-08-26', NULL, N'?ang m??n', N'M??n l?n ??u'),
(4, '2025-08-21', '2025-08-28', NULL, N'?ang m??n', NULL),
(5, '2025-08-22', '2025-08-29', NULL, N'?ang m??n', NULL);

INSERT INTO BorrowingDetails (BorrowID, BookID, Quantity, Note) VALUES
(1, 1, 1, NULL),
(2, 2, 1, NULL),
(3, 3, 2, N'M??n cho nhóm h?c'),
(4, 4, 1, NULL),
(5, 5, 1, N'Sách h?c ti?ng Anh');
GO
ALTER TABLE Users
ADD SecurityQuestion1 NVARCHAR(255) NULL,
    SecurityAnswerHash1 NVARCHAR(255) NULL,
    SecurityQuestion2 NVARCHAR(255) NULL,
    SecurityAnswerHash2 NVARCHAR(255) NULL,
    SecurityQuestion3 NVARCHAR(255) NULL,
    SecurityAnswerHash3 NVARCHAR(255) NULL;
GO
-- Xóa các c?t không c?n thi?t
ALTER TABLE Borrowing
DROP COLUMN DueDate, ReturnDate,Status;

-- Thêm c?t UserID
ALTER TABLE Borrowing
ADD UserID INT NOT NULL;

-- T?o ràng bu?c khóa ngo?i t?i b?ng Users
ALTER TABLE Borrowing
ADD CONSTRAINT FK_Borrowing_Users FOREIGN KEY (UserID) REFERENCES Users(UserID);

-- them du lieu cho book--
ALTER TABLE Books
ADD Price DECIMAL(18,2) NULL,   -- Giá bán
    BorrowPrice DECIMAL(18,2) NULL;