Technologies Used:

Application:Asp.Net Web Api
Database:Sql Server

1. Run the sql file to create the database with default user(admin and passord).
2. Open the sln file in MS Visual Studio 2019 and change the connection string in Blogging and Blogging.Repo project config files.
3. Now run the project it should be build and run successfully.
4. Some key feature it has

   Oauth Implementation for authentication purpose.
   DI pattern is implemented by Unity Container.
   Blogging basic operation end points.
   ADO.Net is used for database connectivity. Due to short of time entityframework is not used.
   CustomExceptionHandler filter is created and registered globally to handle all the exceptions.
   Code is readable and maintainable, created 3 layers architecture (Presentation, Service, Repository)