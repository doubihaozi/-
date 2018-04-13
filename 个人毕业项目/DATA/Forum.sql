--create database Forum
--on
--(
--	name='Forum',
--	filename='F:\��ΰ�\���˱�ҵ��Ŀ\���˱�ҵ��Ŀ\DATA\Forum.mdf'	
--)
use Forum
go
create table Users
(
	[UID] int identity(1,1) primary key,        --�Զ����,��ʶ��
	Uname varchar(15)  not null,        --�ǳ�
	Upassword varchar(10) default(88888888) not null,            --����
	Uemail varchar(50) check(Uemail like '%@%'),            --�ʼ�
	Usex bit not null ,            --�Ա�
	Uclass int,                --���𣨼��Ǽ���
	Uremark varchar(50),            --��ע
	UregDate datetime not null,        --ע������
	Ustate int null,            --״̬(�Ƿ����)
	Upoint int null,            --���֣�������
)
--���Լ����
alter table Users add constraint Uclass default (1) for Uclass 
alter table Users add constraint Upassword check(len(Upassword)>=6)  
alter table Users add constraint Upoint default (20) for Upoint
--�������
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('�����','fangdong','bb@sohu.com',1,'3','����ʧ������',getdate(),0,600)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('Supper','master','dd@p.com',1,'6','BBS�����',getdate(),0,5000)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('�ɿ���','HYXS007','SS@hotmail.com',1,'1','��Ҫȥ����������',getdate(),0,200)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('�������','888888','lyzTTT@hotmail.com',0,'2','ǣƥ��������',getdate(),0,200)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('�����','fangdong','bb@sohu.com',1,'3','����ʧ������',getdate(),0,600)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('Supper','master','dd@p.com',1,'6','BBS�����',getdate(),0,5000)
go
create table Section
(
	SID int identity(1,1) not null primary key,    --�����
	Sname varchar(30) not null,            --�������
	SmasterID int not null,                --����ID,���;�����û�bbsUsers��UID
	Sprofile varchar(50),					--������
	SclickCount int default(0),                --�����
	StopicCount int default(0)                   --������
)
insert into Section(Sname,SmasterID,Sprofile,SclickCount,StopicCount)
values('Java����',3,'������ܣ���Դ���Ǽ�������J2SE',500,1)
insert into Section(Sname,SmasterID,Sprofile,SclickCount,StopicCount)
values('.Net����',5,'����C#,ASP,.NET Framework,Web Services',800,1)
insert into Section(Sname,SmasterID,Sprofile,SclickCount,StopicCount)
values('Linux/Unix����',5,'����ϵͳά����ʹ���������򿪷�����',0,0)
go
create table Topic
(
	TID INT IDENTITY primary key,
	TSID INT NOT NULL foreign key(TSID) references Section(SID),
	TUID INT NOT NULL foreign key(TUID) references Users(UID),
	TReplyCount int default(0) not null,
	TFace int,
	TTopic varchar(50) not null,
	TContetnts varchar(200) not null,
	TTime datetime default(getDate()) not null,
	TClickCount int default(0) not null,
	TState int default(1) not null,
	TLastReply datetime
)
--��TSID����Ϊ���������Section���SID����
alter table Topic add constraint FK_Topic_SID foreign key(TSID) references Section(SID)
--��TUID����Ϊ���������Users���UID����
alter table Topic add constraint FK_Topic_UID foreign key(TUID) references Users(UID)
--�������
insert into Topic (TSID,TUID,TReplyCount,TFace,TTopic,TContetnts,TTime,TClickCount,TState,TLastReply)
values(1,3,2,1,'����JSP��...','jsp�ļ��ж�ȡ...',2005-08-01,200,1,2005-08-01)
insert into Topic (TSID,TUID,TReplyCount,TFace,TTopic,TContetnts,TTime,TClickCount,TState,TLastReply)
values(2,2,0,2,'����.net...','��Ŀ����WinSe...',getdate(),200,1,getdate())
go
create table Reply
(
RID int not null identity(1,1),
RTID int not null foreign key (RTID) references Topic(TID),
RSID int not null foreign key(RSID) references Section([SID]),
RUID int not null foreign key(RUID) references Users(UID),
RFace int,
RContents varchar(200) not null,
RTime datetime default(getdate()) not null,
RClickCount int default(0) not null,
)
insert into Reply (RTID,RSID,RUID,RFace,RContents,RTime,RClickCount)
values (1,1,5,2,'jsp�����������ô�����ã���Ϊ�ҷ��������������ںö�ط���������',getdate(),100)
insert into Reply (RTID,RSID,RUID,RFace,RContents,RTime,RClickCount)
values (1,1,4,4,'ת��jsp..',getdate(),200)
insert into Reply (RTID,RSID,RUID,RFace,RContents,RTime,RClickCount)
values (2,2,2,3,'.net�ܾ��ʣ�����ppmm����',getdate(),200)
go
select * from Users
--				--�ɱ���	�±���
--exec sp_rename 'bbsReply','Reply',OBJECT

select * from Users

select * from Topic

select TTopic,Uname from Users u ,Topic t
where t.TUID=u.[UID]