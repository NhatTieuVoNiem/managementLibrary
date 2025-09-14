
USE LibraryManagement;
GO

-- Bảng Tác giả
CREATE TABLE Authors (
    AuthorID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(100) NOT NULL,   -- Họ
    FirstName NVARCHAR(100) NOT NULL,  -- Tên
    Biography NVARCHAR(MAX) NULL,
    Note NVARCHAR(255) NULL            -- Ghi chú
);

-- Bảng Thể loại
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    Note NVARCHAR(255) NULL            -- Ghi chú
);

-- Bảng Nhà xuất bản
CREATE TABLE Publishers (
    PublisherID INT IDENTITY(1,1) PRIMARY KEY,
    PublisherName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone VARCHAR(20),
    Note NVARCHAR(255) NULL            -- Ghi chú
);

-- Bảng Vị trí để sách
CREATE TABLE BookLocations (
    LocationID INT IDENTITY(1,1) PRIMARY KEY,
    ShelfCode NVARCHAR(50) NOT NULL,       
    Floor NVARCHAR(50) NULL,              
    Room NVARCHAR(100) NULL,               
    Note NVARCHAR(255) NULL               
);

-- Bảng Sách
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

-- Bảng Thành viên
CREATE TABLE Members (
    MemberID NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10),
    BirthDate DATE,
    Phone NVARCHAR(15),
    Address NVARCHAR(100),
    Position NVARCHAR(30)
);

-- Bảng Phiếu mượn
CREATE TABLE Borrowing (
    BorrowID INT IDENTITY(1,1) PRIMARY KEY,
    MemberID INT NOT NULL,
    BorrowDate DATE DEFAULT GETDATE(),
    DueDate DATE NOT NULL,
    ReturnDate DATE NULL,
    Status VARCHAR(20) DEFAULT 'Đang mượn',
    Note NVARCHAR(255) NULL,
    CONSTRAINT FK_Borrowing_Members FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);
-- Bảng chi tiết phiếu mượn
CREATE TABLE BorrowingDetails (
    DetailID INT IDENTITY(1,1) PRIMARY KEY,
    BorrowID INT NOT NULL,
    BookID INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    Note NVARCHAR(255) NULL,
    CONSTRAINT FK_BorrowingDetails_Borrowing FOREIGN KEY (BorrowID) REFERENCES Borrowing(BorrowID),
    CONSTRAINT FK_BorrowingDetails_Books FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- Bảng Người dùng hệ thống

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
CREATE TABLE Employees (
    EmployeeID NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10),
    BirthDate DATE,
    Phone NVARCHAR(15),
    Address NVARCHAR(100),
    Position NVARCHAR(30)
);
CREATE TABLE Customers (
    CustomerID NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10),
    BirthDate DATE,
    Phone NVARCHAR(15),
    Address NVARCHAR(100),
    Email NVARCHAR(50),
    RegisterDate DATE
);
CREATE TABLE Salaries (
    SalaryID INT IDENTITY PRIMARY KEY,
    EmployeeID NVARCHAR(10) FOREIGN KEY REFERENCES Employees(EmployeeID),
    Month INT,
    Year INT,
    BaseSalary DECIMAL(18,2),
    WorkDays INT,
    Allowance DECIMAL(18,2),
    Bonus DECIMAL(18,2),
    Deduction DECIMAL(18,2),
    TotalSalary AS (BaseSalary / 26.0 * WorkDays + Allowance + Bonus - Deduction) PERSISTED
);



GO
-- them du lieu

INSERT INTO BookLocations (ShelfCode, Floor, Room, Note) VALUES
('A1', N'Tầng 1', N'Phòng đọc 101', N'Kệ sách văn học'),
('B2', N'Tầng 2', N'Phòng lưu trữ', N'Sách tham khảo'),
('C3', N'Tầng 1', N'Phòng đọc 102', N'Sách thiếu nhi'),
('D4', N'Tầng 3', N'Kho sách', N'Sách cũ'),
('E5', N'Tầng 2', N'Phòng đọc 201', N'Sách ngoại văn');

INSERT INTO Authors (LastName, FirstName, Biography, Note) VALUES
(N'Nguyễn', N'Nhật Ánh', N'Tác giả nổi tiếng với sách thiếu nhi', N'Tiểu thuyết học trò'),
(N'Trần', N'Đăng Khoa', N'Nhà thơ từ thời niên thiếu', N'Ghi chú thêm'),
(N'Vũ', N'Trúc Phương', N'Tác giả chuyên viết truyện ngắn', NULL),
(N'Lê', N'Minh Hà', N'Viết sách về giáo dục và tâm lý', NULL),
(N'Phạm', N'Tiến Duật', N'Nhà thơ thời chiến tranh', N'Tác phẩm nổi bật: Bài thơ về tiểu đội xe không kính');

INSERT INTO Categories (CategoryName, Note) VALUES
(N'Thiếu nhi', N'Sách dành cho trẻ em'),
(N'Văn học Việt Nam', N'Tác phẩm trong nước'),
(N'Khoa học', N'Sách nghiên cứu, học thuật'),
(N'Tâm lý - Giáo dục', N'Sách phát triển bản thân'),
(N'Ngoại văn', N'Sách tiếng Anh, Pháp...');

INSERT INTO Publishers (PublisherName, Address, Phone, Note) VALUES
(N'NXB Trẻ', N'161B Lý Chính Thắng, Q.3, TP.HCM', '02838299999', N'Chuyên sách thiếu nhi'),
(N'NXB Kim Đồng', N'55 Quang Trung, Hà Nội', '02438255555', N'Sách học sinh'),
(N'NXB Giáo Dục', N'81 Trần Hưng Đạo, Hà Nội', '02439430000', NULL),
(N'NXB Văn Học', N'4 Đinh Lễ, Hà Nội', '02439388888', N'Sách văn học'),
(N'NXB Tổng Hợp', N'62 Nguyễn Thị Minh Khai, TP.HCM', '02839393939', NULL);

INSERT INTO Books (Title, AuthorID, CategoryID, PublisherID, YearPublished, Quantity, Available, Note, LocationID, Price, BorrowPrice) VALUES
(N'Mắt Biếc', 1, 2, 6, 2008, 10, 10, NULL, 1, 120000, 15000),
(N'Góc nhỏ tuổi thơ', 2, 1, 2, 2010, 5, 5, N'Sách thơ', 3, 80000, 10000),
(N'Bí mật của não bộ', 4, 4, 3, 2015, 7, 7, NULL, 2, 150000, 20000),
(N'Chiến tranh và hòa bình', 5, 2, 4, 1990, 3, 3, N'Tác phẩm kinh điển', 4, 200000, 25000),
(N'English Grammar in Use', NULL, 5, 5, 2020, 12, 12, N'Sách học tiếng Anh', 5, 250000, 30000);

INSERT INTO Members (LastName, FirstName, Email, Phone, Address, Note) VALUES
(N'Nguyễn', N'Lan', 'lan.nguyen@example.com', '0912345678', N'Hà Nội', NULL),
(N'Trần', N'Hoàng', 'hoang.tran@example.com', '0987654321', N'Hồ Chí Minh', N'Thành viên tích cực'),
(N'Lê', N'Thảo', 'thao.le@example.com', '0909090909', N'Đà Nẵng', NULL),
(N'Phạm', N'Quân', 'quan.pham@example.com', '0939393939', N'Cần Thơ', NULL),
(N'Vũ', N'Mai', 'mai.vu@example.com', '0922222222', N'Hải Phòng', N'Mượn nhiều sách');

INSERT INTO Borrowing (MemberID, BorrowDate, DueDate, ReturnDate, Status, Note) VALUES
(1, '2025-08-20', '2025-08-27', NULL, N'Đang mượn', NULL),
(2, '2025-08-18', '2025-08-25', '2025-08-24', N'Đã trả', NULL),
(3, '2025-08-19', '2025-08-26', NULL, N'Đang mượn', N'Mượn lần đầu'),
(4, '2025-08-21', '2025-08-28', NULL, N'Đang mượn', NULL),
(5, '2025-08-22', '2025-08-29', NULL, N'Đang mượn', NULL);

INSERT INTO BorrowingDetails (BorrowID, BookID, Quantity, Note) VALUES
(1, 6, 1, NULL),
(2, 7, 1, NULL),
(3, 8, 2, N'Mượn cho nhóm học'),
(4, 9, 1, NULL),
(5, 10, 1, N'Sách học tiếng Anh');
GO