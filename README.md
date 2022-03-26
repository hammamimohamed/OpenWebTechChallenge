### Open.Web.Tech.Contacts.Api.Interfaces
Interface or the web api as DLL use

### Open.Web.Tech.Contacts.Api
Web Api application to manage contact in .net core.

### Application run 
- Open the Open.Web.Tech.Contacts.Api.sln in visual studio 2019
- Two roles are defined: Administrator and SimpleUser
- Have look to DbInitializer.cs file to get test users
- Run the Open.Web.Tech.Contacts.Api in IISExpress
- In swagger :
	- Use  api/Login endpoint with (user/password) to get token 
	- Click in (Authorize) button and enter the token as format following: Bearer Generated-JWT-Token