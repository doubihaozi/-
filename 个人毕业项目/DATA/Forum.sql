--create database Forum
--on
--(
--	name='Forum',
--	filename='F:\杨伟楠\个人毕业项目\个人毕业项目\DATA\Forum.mdf'	
--)
use Forum
go
create table Users
(
	[UID] int identity(1,1) primary key,        --自动编号,标识列
	Uname varchar(15)  not null,        --昵称
	Upassword varchar(10) default(88888888) not null,            --密码
	Uemail varchar(50) check(Uemail like '%@%'),            --邮件
	Usex bit not null ,            --性别
	Uclass int,                --级别（几星级）
	Uremark varchar(50),            --备注
	UregDate datetime not null,        --注册日期
	Ustate int null,            --状态(是否禁言)
	Upoint int null,            --积分（点数）
)
--添加约束、
alter table Users add constraint Uclass default (1) for Uclass 
alter table Users add constraint Upassword check(len(Upassword)>=6)  
alter table Users add constraint Upoint default (20) for Upoint
--添加数据
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('冬篱儿','fangdong','bb@sohu.com',1,'3','爱迷失在天堂',getdate(),0,600)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('Supper','master','dd@p.com',1,'6','BBS大斑竹',getdate(),0,5000)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('可卡因','HYXS007','SS@hotmail.com',1,'1','我要去公安局自首',getdate(),0,200)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('心酸果冻','888888','lyzTTT@hotmail.com',0,'2','牵匹瘦马闯天下',getdate(),0,200)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('冬篱儿','fangdong','bb@sohu.com',1,'3','爱迷失在天堂',getdate(),0,600)
insert into Users(Uname,Upassword,Uemail,Usex,Uclass,Uremark,UregDate,Ustate,Upoint)
values('Supper','master','dd@p.com',1,'6','BBS大斑竹',getdate(),0,5000)
go
create table Section
(
	SID int identity(1,1) not null primary key,    --版块编号
	Sname varchar(30) not null,            --版块名称
	SmasterID int not null,                --版主ID,外键;引用用户bbsUsers的UID
	Sprofile varchar(50),					--版面简介
	SclickCount int default(0),                --点击率
	StopicCount int default(0)                   --发帖数
)
insert into Section(Sname,SmasterID,Sprofile,SclickCount,StopicCount)
values('Java技术',3,'包含框架，开源，非技术区，J2SE',500,1)
insert into Section(Sname,SmasterID,Sprofile,SclickCount,StopicCount)
values('.Net技术',5,'包含C#,ASP,.NET Framework,Web Services',800,1)
insert into Section(Sname,SmasterID,Sprofile,SclickCount,StopicCount)
values('Linux/Unix社区',5,'包含系统维护与使用区，程序开发区别',0,0)
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
--把TSID设置为外键，引用Section表的SID主键
alter table Topic add constraint FK_Topic_SID foreign key(TSID) references Section(SID)
--把TUID设置为外键，引用Users表的UID主键
alter table Topic add constraint FK_Topic_UID foreign key(TUID) references Users(UID)
--添加数据
insert into Topic (TSID,TUID,TReplyCount,TFace,TTopic,TContetnts,TTime,TClickCount,TState,TLastReply)
values(1,3,2,1,'还是JSP中...','jsp文件中读取...',2005-08-01,200,1,2005-08-01)
insert into Topic (TSID,TUID,TReplyCount,TFace,TTopic,TContetnts,TTime,TClickCount,TState,TLastReply)
values(2,2,0,2,'部署.net...','项目包括WinSe...',getdate(),200,1,getdate())
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
values (1,1,5,2,'jsp乱码问题该怎么解决最好，因为我发现这个问题好象在好多地方都看见了',getdate(),100)
insert into Reply (RTID,RSID,RUID,RFace,RContents,RTime,RClickCount)
values (1,1,4,4,'转换jsp..',getdate(),200)
insert into Reply (RTID,RSID,RUID,RFace,RContents,RTime,RClickCount)
values (2,2,2,3,'.net很精彩，就像ppmm啊！',getdate(),200)
go
select * from Users
--				--旧表名	新表名
--exec sp_rename 'bbsReply','Reply',OBJECT

select * from Users

select * from Topic

select TTopic,Uname from Users u ,Topic t
where t.TUID=u.[UID]