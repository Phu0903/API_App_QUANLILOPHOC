



select * from dbo.tblStudent

Insert into dbo.tblStudent VALUES('NGUYỄN DUY PHU','0989660777','160 Phan Dinh Phung','CL_001','09/03/2000','10/02/2020')
Insert into dbo.tblStudent VALUES('NGUYỄN ANH KHANG','0989660777','160 Phan Dinh Phung','CL_001','09/03/2000','10/02/2020')
------------------Lấy danh sách học sinh-----------------------------
 Alter PROC spStudent1
 AS 
 BEGIN 
 SELECT * FROM tblStudent
 END
 EXEC spStudent1
 ------------------Thêm Học Sinh-----------------------
ALTER PROCEDURE dbAddStudent(@Id int = 0 , @Name NVARCHAR(50),@PhoneNumber NVARCHAR(50), @Address NVARCHAR(50),
                              @ID_Class nchar(10), @Birthday NVARCHAR(50),@RegisterDay NVARCHAR(50),@Gender NVARCHAR(50))
 AS 
 BEGIN
 IF(@Id = 0)
 BEGIN
 INSERT INTO tblStudent VALUES(@Name,@PhoneNumber, @Address, @ID_Class,@Birthday,@RegisterDay,@Gender)
 END 
 ELSE 
 BEGIN 
 UPDATE tblStudent SET 
        Name = @Name , 
	    Address = @Address , 
		PhoneNumber =@PhoneNumber ,
		ID_Class=@ID_Class,
		Birthday = @Birthday,
		RegisterDay=@RegisterDay,
		Gender=@Gender
Where Id = @Id
END
END
---------------Lấy danh sách Class------------------------
 CREATE PROCEDURE spCLASS
 AS 
 BEGIN 
 SELECT * FROM Class
 END
 EXEC spClass
---------------Lấy danh sách học sinh theo Mã Lớp-----------------------
CREATE PROCEDURE dbStudentClass(@ID_Class nchar(10))
AS
BEGIN 
SELECT * FROM dbo.tblStudent
WHERE dbo.tblStudent.ID_Class = @ID_Class
END


-------------------------------------
SELECT GETDATE();
SELECT * FROM THONGBAO
insert into THONGBAO values('Tieude1','thong bao test',getdate());

 CREATE PROCEDURE spThongbao
 AS 
 BEGIN 
 SELECT * FROM Thongbao
 END

CREATE PROCEDURE dbAddDateTime(@Id int = 0 , @Tieude nvarchar(4000), @Noidung nvarchar(4000) )
 AS 
 BEGIN
 IF(@Id = 0)
 BEGIN
 INSERT INTO Thongbao VALUES(@Tieude , @Noidung,GETDATE())
 END 
 ELSE 
 BEGIN 
 UPDATE Thongbao SET 
       Tieude = @Tieude, 
	   Noidung = @Noidung,
	   getDate = GETDATE()
Where ID_Thongbao = @Id
END
END
----------------------------------------
ALTER TABLE Thongbao
ALTER COLUMN Tieude NVARCHAR(4000)
ALTER TABLE Thongbao
AlTER COLUMN Noidung NVARCHAR(4000)
---------Xóa học sinh--------------
CREATE Procedure dbDeleteStudent (@StudentId int)
 as 
 begin 
    delete from tblStudent  where Id = @StudentId
END
-----------------Thông báo-----------------------------


------------------------------------------------------
Insert into dbo.tblUser values(2,'Nguyen Duy Phu','09/03/2000','0852578535','123456789','phu0903')
Insert into dbo.tblUser values(3,'Nguyen Duy Phu','09/03/2000','0852578535','123456789','phu09031000')
 select * from dbo.tblUser
Alter PROC spUser
 AS 
 BEGIN 
 SELECT ID_User,Name_User,BirthDay_User,NumberPhone_User,userName,Password FROM tblUser
 END
 ------------------
 Create PROC spLogin
 AS 
 BEGIN 
 SELECT userName,Password FROM tblUser
 END
 ------------------------------







 