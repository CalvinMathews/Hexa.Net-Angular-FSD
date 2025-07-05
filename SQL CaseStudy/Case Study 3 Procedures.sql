CREATE PROCEDURE sp_Add_UserInfo
@EmailId varchar(50),
@UserName varchar(50),
@Role varchar(20),
@Password varchar(30)
AS 
BEGIN 
     INSERT INTO UserInfo VALUES(@EmailId,@UserName,@Role,@Password)
END 

sp_Add_UserInfo 'lisa.montez@outlook.com', 'LisaMontez', 'Participant', 'Secure@789'


select  from UserInfo


CREATE PROCEDURE sp_Add_EventDetails
@EventId int,
@EventName varchar(50),
@EventCategory varchar(50),
@EventDate datetime = NULL,
@Description varchar(50)= NULL,
@Status varchar(10)=NULL
AS
BEGIN
      INSERT  INTO EventDetails VALUES(@EventId,@EventName,
	  @EventCategory,@EventDate,@Description,@Status)
END

sp_Add_EventDetails 101, 'Tech Fusion 2025', 'Conference', '2025-09-15 10:30:00', 'Annual global tech summit', 'Active'



CREATE PROCEDURE sp_Add_SpeakersDetails
@SpeakerId int,
@SpeakerName varchar(50)
AS
BEGIN 
       INSERT INTO SpeakersDetails VALUES(@SpeakerId,@SpeakerName)
END

sp_Add_SpeakersDetails 207, 'Dr. Nathan Price'


CREATE PROCEDURE sp_Add_SessionInfo
@sessionId int,
@EventId int,
@SessionTitle varchar(50),
@SpeakerId int,
@Description varchar(255),
@SessionStart datetime,
@SessionEnd datetime,
@SessionUrl varchar(100)
AS
BEGIN 
      INSERT INTO SessionInfo VALUES(@sessionId,@EventId ,@SessionTitle,
	  @SpeakerId,@Description,@SessionStart ,@SessionEnd,@SessionUrl)
END


sp_Add_SessionInfo 305, 101, 'Future of AI Ethics', 207, 'Discussion on responsible AI usage', '2025-09-15 11:00:00', '2025-09-15 12:30:00', 'https://futureai2025.com/session1'



CREATE PROCEDURE sp_Delete_EventDetails
    @EventIdVal INT
AS
BEGIN
    DELETE FROM EventDetails WHERE EventId = @EventIdVal;
END;

CREATE PROCEDURE sp_Delete_SessionInfo
    @SessionIdVal INT
AS
BEGIN
    DELETE FROM SessionInfo WHERE SessionId = @SessionIdVal;
END;

CREATE PROCEDURE sp_Delete_SpeakerDetails
    @SpeakerIdVal INT
AS
BEGIN
    DELETE FROM SpeakersDetails WHERE SpeakerId = @SpeakerIdVal;
END;

CREATE PROCEDURE sp_Delete_UserInfo
    @EmailIdVal INT
AS
BEGIN
    DELETE FROM UserInfo WHERE EmailId = @EmailIdVal;
END;

---3

CREATE PROCEDURE sp_update_EventDetails
@EventId int,
@EventName varchar(50),
@EventCategory varchar(50),
@EventDate datetime = NULL,
@Description varchar(50)= NULL,
@Status varchar(10)=NULL
AS
BEGIN
    UPDATE  EventDetails SET EventName=@EventName,EventCategory=@EventCategory,EventDate=@EventDate,Description=@Description,Status=@Status 
	WHERE EventId=@EventId
END

CREATE PROCEDURE sp_update_SessionInfo
@sessionId int,
@EventId int,
@SessionTitle varchar(50),
@SpeakerId int,
@Description varchar(255),
@SessionStart datetime,
@SessionEnd datetime,
@SessionUrl varchar(100)
AS
BEGIN 
    UPDATE  SessionInfo SET EventId=@EventId,SessionTitle=@SessionTitle,SpeakerId=@SpeakerId,Description=@Description,SessionStart=@SessionStart,SessionEnd=@SessionEnd,SessionUrl=@SessionUrl

	WHERE SessionId=@sessionId
END

CREATE PROCEDURE sp_update_SpeakersDetails
@SpeakerId int,
@SpeakerName varchar(50)
AS
BEGIN 
    UPDATE  SpeakersDetails SET SpeakerName=@SpeakerName
	WHERE SpeakerId = @SpeakerId
END


CREATE PROCEDURE sp_update_UserInfo
@EmailId varchar(50),
@UserName varchar(50),
@Role varchar(20),
@Password varchar(30)
AS 
BEGIN 
    UPDATE  UserInfo SET UserName=@UserName,Role=@Role,Password=@Password
	WHERE EmailId=@EmailId
END

sp_update_UserInfo 
    @EmailId = 'lisa.montez@outlook.com', 
    @UserName = 'LisaM_Updated', 
    @Role = 'Moderator', 
    @Password = 'NewPass#321'

	---4
CREATE VIEW View_SessionDetails AS
SELECT s.SessionId, s.SessionTitle, s.Description, s.SessionStart, s.SessionEnd, s.SessionUrl, e.EventName, e.EventCategory
FROM SessionInfo s
JOIN EventDetails e ON s.EventId = e.EventId;

--5

CREATE VIEW View_SpeakerDetails AS
SELECT s.SessionId, s.SessionTitle, sp.SpeakerId, sp.SpeakerName
FROM SessionInfo s
JOIN SpeakersDetails sp ON s.SpeakerId = sp.SpeakerId;

---6
CREATE VIEW View_EventDetails AS
SELECT e.EventId, e.EventName, e.EventCategory, e.EventDate, e.Description, e.Status,
       s.SessionTitle, s.SessionStart, s.SessionEnd, sp.SpeakerName, u.UserName, u.Role
FROM EventDetails e
LEFT JOIN SessionInfo s ON e.EventId = s.EventId
LEFT JOIN SpeakersDetails sp ON s.SpeakerId = sp.SpeakerId
LEFT JOIN UserInfo u ON u.Role = 'Participant'

---7
CREATE NONCLUSTERED INDEX IX_UserInfo_Email ON UserInfo (EmailId);


CREATE NONCLUSTERED INDEX IX_EventDetails_EventId ON EventDetails (EventId);


CREATE NONCLUSTERED INDEX IX_SpeakersDetails_SpeakerId ON SpeakersDetails (SpeakerId);

CREATE NONCLUSTERED INDEX IX_SessionInfo ON SessionInfo (SessionId, EventId);