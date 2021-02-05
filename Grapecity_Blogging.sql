create database blogging;

create table blog_user (userid int primary key identity, username nvarchar(25), email nvarchar(50), password nvarchar(max));

create table blog_data (blogid int primary key identity, title nvarchar(100), content nvarchar(max), userid int foreign key references blog_user(userid));


-- =============================================  
-- Author:      <Author,Rishabh Gupta>  
-- Description: <Description,To get user on behalf of username and password>  
-- ============================================= 
create proc user_by_username_password
	 @username nvarchar(25),
	 @password nvarchar(max)
as begin
	select userid, username, password from blog_user
	where username=@username and password=@password
end

Insert into blog_user(username, email, password) values ('admin','admin@gmail.com','password');

-- =============================================  
-- Author:      <Author,Rishabh Gupta>  
-- Description: <Description,To add a new blog>  
-- ============================================= 
create proc add_blog
	@title nvarchar(100), 
	@content nvarchar(max), 
	@userid int 
as begin
	insert into blog_data(title, content, userid) values (@title, @content, @userid)
end

-- =============================================  
-- Author:      <Author,Rishabh Gupta>  
-- Description: <Description,To edit a blog>  
-- ============================================= 
create proc edit_blog
	@title nvarchar(100), 
	@content nvarchar(max), 
	@blogid int 
as begin
	update blog_data set title=@title, content=@content where blogid=@blogid;
	
	select * from blog_data where blogid=@blogid;
end

-- =============================================  
-- Author:      <Author,Rishabh Gupta>  
-- Description: <Description,To delete a blog>  
-- ============================================= 
create proc delete_blog
	@blogid int 
as begin
	delete blog_data where blogid=@blogid;
end


-- =============================================  
-- Author:      <Author,Rishabh Gupta>  
-- Description: <Description,To get all blogs>  
-- ============================================= 
create proc get_allBlogs
as begin
	select * from blog_data;
end



