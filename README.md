# opensocialapp-angular-example
A sample application to demonstrate building Single Page Applications with JWT Authentication Logic using Angular

#How to run?
Start by running the OpenSocialApp.STS project which is an ASP.NET Core 3.1 WebApp with IdentityServer4 included. The Application should run on port 5001.
Once the STS is running, continue by running the OpenSocialApp.Api which is an ASP.NET Core 3.1 WebAPI project that contains the Posts API with placeholder List to persist data for the session. The API should be running on port 5002.
Finally, run the OpenSocialApp.App project which is an Angular application which requires NodeJS and @angular/cli to be installed. Install the node modules and run the application. 
The Dockerfiles for all the individual components are placed but are yet to be integrated properly, the code will be updated once the Docker scripts are ready.
