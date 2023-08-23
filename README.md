This is my first Full-Stack Project. I made this project using the designs given to me during my internship.

You can see the pages you can access from the controllers section. You just have to handle admin parts manually(They are not linked to homepage.).

To review the project, first replace YOURSERVERNAME in the appsettings.json file with your sql server.

Then type the following codes in NuGet package manager:

cd .\GenclikBelediyesi

dotnet dev-certs https --trust

dotnet ef migrations add createdb

dotnet ef database update

Finally, you can run the commands in db.txt in sql server to add a list of news and add an admin(with username: admin and password: asd).
