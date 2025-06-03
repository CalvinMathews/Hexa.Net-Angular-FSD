CREATE DATABASE EventDB;
GO
USE EventDB;

CREATE TABLE UserInfo( EmailId VARCHAR(80) PRIMARY KEY,
UserName Varchar(50) Not Null check(len(UserName) between 1 and 50),
Role varchar(20) not null check(Role in ('Admin','Participant')),
Password varchar(20) not null check(len(Password) between 6 and 20));


create table EventDetails (
    EventId int primary key,
    EventName varchar(50) not null check(len(eventname) between 1 and 50),
    EventCategory varchar(50) not null check(len(eventcategory) between 1 and 50),
    EventDate datetime not null,
    Description varchar(100),
    Status varchar(20) check(status in ('active', 'in-active'))
);


create table SpeakersDetails (
    SpeakerId int primary key,
    SpeakerName varchar(50) not null check(len(speakername) between 1 and 50)
);


create table SessionInfo (
    sessionid int primary key,
    eventid int not null,
    sessiontitle varchar(50) not null check(len(sessiontitle) between 1 and 50),
    speakerid int not null,
    description varchar(500),
    sessionstart datetime not null,
    sessionend datetime not null,
    sessionurl varchar(255),

    foreign key (eventid) references eventdetails(eventid),
    foreign key (speakerid) references speakersdetails(speakerid)
);



create table ParticipantEventDetails (
    id int primary key,
    participantemailid varchar(80) not null,
    eventid int not null,
    sessionid int not null,
    isattended bit check(isattended in (0, 1)),

    foreign key (participantemailid) references userinfo(emailid),
    foreign key (eventid) references eventdetails(eventid),
    foreign key (sessionid) references sessioninfo(sessionid)
);

