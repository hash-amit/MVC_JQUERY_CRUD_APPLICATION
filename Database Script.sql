CREATE DATABASE DbSchool
use DbSchool

select * from tbl_Students
truncate table tbl_Students
create table tbl_Students
(
	SID int primary key identity,
	[NAME] varchar(60),
	EMAIL VARCHAR(60),
	PASS VARCHAR(50),
	MOBILE INT
)

Create proc sp_StudentInsert
(
	@name varchar(60),
	@email varchar(60),
	@pass varchar(50),
	@mobile int
)
AS
BEGIN
	INSERT INTO tbl_Students([NAME], EMAIL, PASS, MOBILE)
	VALUES (@name,@email,@pass,@mobile)
END;

CREATE PROC sp_StudentShow
AS
BEGIN
	SELECT * FROM tbl_Students
END;

use DbSchool

create proc sp_StudentDelete
(
	@id int
)
as
begin
	delete from tbl_Students where SID = @id
end;

create proc sp_GetOneRecord
(
	@sid int
)
as
begin
	select * from tbl_Students where SID = @sid
end;

select * from tbl_Students

create proc sp_StudentUpdate
(
	@name varchar(60),
	@email varchar(60),
	@pass varchar(60),
	@mobile bigint,
	@sid int
)
as
begin
	update tbl_Students set NAME = @name, EMAIL = @email, PASS = @pass, MOBILE = @mobile 
	where SID = @sid
end;