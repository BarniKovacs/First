CREATE TABLE Students (
	Stud_Id int,
	Name varchar(50),
	Surname varchar(50),
	Gender char,
	Date_of_Birth datetime,
	Group_ID int
	PRIMARY KEY (Stud_Id)
	);
 
 CREATE TABLE Groups (
	Gr_Id int,
	Gr_name varchar(50), 
	Year_of_Study int,
	Comments varchar(100)
	PRIMARY KEY (Gr_Id)
	);

CREATE TABLE Teachers (
	Teacher_Id int,
	Name varchar(50), 
	Surname varchar(50),
	Date_of_Birth datetime, 
	degree varchar (100)
	PRIMARY KEY (Teacher_Id)
	);

CREATE TABLE Disciplines (
	Discipline_Id int,
	Disc_name varchar (50),
	Discipline_Type varchar(100)
	PRIMARY KEY (Discipline_Id)
	);

CREATE TABLE Marks (
	Student_Id int,
	Teacher_Id int, 
	Disc_Id int,
	Mark int, 
	Date_of_Exam datetime
	);

ALTER TABLE Students
	ADD Has_scholarship bit

ALTER TABLE Disciplines
	ADD CONSTRAINT UC_Disciplines_Name UNIQUE (Disc_name);

ALTER TABLE Students
	ADD CONSTRAINT CHK_GroupID CHECK (Group_ID >= 1 AND Group_ID <= 5);

ALTER TABLE Marks
	ADD CONSTRAINT P_Marks CHECK (Mark > 0);

ALTER TABLE Students 
	ADD CONSTRAINT Stud_Group
	FOREIGN KEY (Group_ID)
	REFERENCES Groups (Gr_Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE ;

ALTER TABLE Marks
	ADD CONSTRAINT Marks_Stud
	FOREIGN KEY (Student_Id)
	REFERENCES Students (Stud_Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE ;

ALTER TABLE Marks
	ADD CONSTRAINT Mark_Teachers
	FOREIGN KEY (Teacher_Id)
	REFERENCES Teachers (Teacher_Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE ;

ALTER TABLE Marks
	ADD CONSTRAINT Mark_Disciplines
	FOREIGN KEY (Disc_Id)
	REFERENCES Disciplines (Discipline_Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE ;

ALTER TABLE Marks 
	ADD CONSTRAINT fk_Teacher_Id 
	FOREIGN KEY (Teacher_Id) 
	REFERENCES Teachers(Teacher_Id) 
	ON UPDATE RESTRICT 
	ON DELETE RESTRICT;
	
SELECT Name, Surname FROM Students	
	WHERE Group_ID = 3;

SELECT Name, Surname, Date_of_Birth, Group_ID FROM Students
	WHERE Name LIKE 'A%'

SELECT Students.Name, Students.Surname, Students.Group_ID FROM Students
	JOIN Marks ON Students.Stud_Id = Marks.Student_Id
	JOIN Teachers ON Teachers.Teacher_Id = Marks.Teacher_Id
	WHERE Teachers.name = 'Adrian';

SELECT Students.Name, Students.Surname, Students.Group_ID FROM Students
	WHERE Students.Group_ID = 3 AND Students.Stud_Id IN (
	SELECT Marks.Student_Id FROM Marks 
	INNER JOIN Disciplines ON Marks.Disc_Id = Disciplines.Discipline_Id
	INNER JOIN Students ON Students.Stud_Id = Marks.Student_Id AND Students.Name = 'Barbara'
	WHERE Disciplines.Disc_name = 'Computer Science' AND Marks.Mark > (
	SELECT Marks.Mark FROM Marks
	WHERE Marks.Student_Id = Students.Stud_Id AND Marks.Disc_Id = Disciplines.Discipline_Id
	)
)

SELECT TOP 3 Students.Name, Students.Surname, Students.Group_ID 
	FROM Students
	INNER JOIN Marks ON Students.Stud_Id = Marks.Student_Id
	WHERE Marks.Disc_Id > 0
	ORDER BY Marks.Mark DESC;

SELECT Students.Name, Students.Surname, AVG(Marks.Mark) AS avg_mark FROM Students
	INNER JOIN Marks ON Students.Stud_Id = Marks.Student_Id
	INNER JOIN Groups ON Students.Group_ID = Groups.Gr_Id
	WHERE Groups.Gr_name = 'vestibulum'
	GROUP BY Students.Name, Students.Surname;

SELECT Groups.Gr_name, Groups.Comments, COUNT(*) AS Num_Stud
	FROM Students
	INNER JOIN Groups ON Students.Group_ID = Groups.Gr_Id
	GROUP BY Groups.Gr_name, Groups.Comments ;