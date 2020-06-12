# .NET Core Tutorial

This tutorial will walk you through the steps for creating a basic .NET Core application with Identity and unit tests. We will also cover creating a repository, scanning with SonarQube, and publishing the application to the web.

This tutorial also assumes that you are using Windows; that you have installed Visual Studio 2019 on your computer; and that you have enabled Internet Information Services (IIS). If you need help completing these prerequisites, please visit [Microsoft Docs](https://docs.microsoft.com "Microsoft Docs") for instructions.

## Part 1: Creating the Application

>Note - This is a simplified version of [Introduction to Identity on ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.1&tabs=visual-studio "Introduction to Identity on ASP.NET Core").

Open Visual Studio 2019. Select **Create a new project**:

![Create a new project](docs/cd00.png)

Select **ASP.NET Core Web Application** for your project template and click **Next**:

>NOTE - Some selections may include a short description. You should read these descriptions before continuing to the next step to build your understanding each item.

![Select a project template](docs/cd01.png)

Enter a project name, such as "COREDemo". Ensure the location is where you want the source code to be stored and ensure **Place solution and project in the same directory** is checked. Click on **Create** to continue:

![Configure your new Project](docs/cd02.png)

Ensure the correct framework (".NET Core") and version ("ASP.NET Core 3.1") appear, and select **Web Application**. DO NOT CLICK ON CREATE!

![Create a new ASP.NET Core web application](docs/cd03.png)

Under **Authentication**, click on **Change**. When the following screen appears, change the authentication method to **Individual User Accounts** and ensure **Store user accounts in-app** is selected for now. Click on **OK** to return to the main screen, and then click on **Create** to populate the project:

![Change Authentication](docs/cd04.png)

After a few minutes, the project should be scaffolded with basic Identity management support, such as login functionality, etc:

![Your Visual Studio workspace](docs/cd05.png)

Before testing the application, you must update the schema of the local data store to match the application's data model. To do this, select on **View** > **Other Windows** > **Package Manager Console** and enter the following command when the PMC prompt appears:

    PM> Update-Database

Once the update is complete, press **F5** or select **Debug** > **Start Debugging** from the menu bar to run the application (you may also click on the green arrow icon next to **IIS Express**):

![Welcome to ASP.NET Core](docs/cd06.png)

Click on **Register** to create a user:

![Register a new user](docs/cd07.png)

Support for multifactor authentication is not enabled by default, so enter "admin@coredemo.com" as the user's email address, "Password" for the password, and click **Register**. You should receive several warnings:

![Bad password error messages](docs/cd07a.png)

MS Identity does come with several default settings, such as password complexity, which may be changed later to suit your needs. For now, enter "admin@coredemo.com" as the user's email address, "P@ssW0rd" for the password, and click **Register**. You will receive a registration confirmation, as well as a link on how to enable confirmation via email (you will enable this later):

![Registar confirmation](docs/cd08.png)

Since email confirmation is not enabled, click on **Click here to confirm your account**. You are redirected to a temporary page that simulates an account confirmation:

![Confirm email](docs/cd09.png)

Click on **COREDemo** or **Home** to return to the home page. Even though you have registered, you are not logged in:

![Return to Home Page](docs/cd09a.png)

Click on **Login**, enter your credentials ("admin@coredemo.com" for the email address, "P@ssW0rd" for the password), and click **Log in**:

![Log in](docs/cd10.png)

Note that a welcome message has replaced the Register link at the top of the page.

![Home Page Welcome message](docs/cd11.png)

Stop the application by closing the browser window or clicking the red stop icon in the toolbar of the VS IDE.

## Part 2: Adding Source Control

>Note: To accomplish this step, you must have a GitHub account. For instructions on how to create an account, please visit [Signing up for a new GitHub account](https://help.github.com/en/github/getting-started-with-github/signing-up-for-a-new-github-account "Signing up for a new GitHub account").

Select **File** > **Add to Source Control** from the top menu bar (you can also right-click the solution node (i.e., **Solution 'COREDemo'**) in the **Solution Explorer** and select **Add Solution to Source Control...**):

![Add to source control](docs/cd20.png)

Visual Studio will add the necessary files to the project (i.e., .git folder, .gitattributes, and .gitignore). Next, open the **Team Explorer** window and click on the **Home** icon:

![Team Explorer](docs/cd21.png)

Click on **Branches**:

![Branches menu](docs/cd21a.png)

Click on the **New Branch** link:

![Create a new branch](docs/cd21b.png)

Create a new branch (we use our user name, so other collaborators know who made changes to the repository). Make sure **Checkout branch** is checked before clicking on **Create Branch**:

![Success](docs/cd21c.png)

Ensure that the new branch is selected (indicated by the bold font), then click on the **Home** icon to return to the main Team Explorer window:

![Team Explorer](docs/cd21d.png)

Click on **Sync**:

![Synchronization menu](docs/cd22.png)

There are several options, but we will select **Publish to GitHub** for now.

![Sign in to GitHub](docs/cd23.png)

Enter your GitHub credentials and click **Sign in**:

![Publish the repository](docs/cd24.png)

You should see a screen similar to the one below, but containing your information. Enter your own description and click **Publish**.

![Success](docs/cd25.png)

If you visit your GitHub account, you should see your new repository:

![Repository on GitHub](docs/cd26.png)

Whenever you make changes, just open the Team Explorer:

![Team Explorer](docs/cd27.png)

Select **Changes**, enter a commit message, and click on **Commit All**:

![Changes menu](docs/cd28.png)





## Part 3: Adding Unit Tests

>Note - This is a simplified version of the Microsoft Docs tutorial [Get started with unit testing](https://docs.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2019 "Get started with unit testing").

Select **File** > **Add** > **New Project** from the top menu bar (you can also right-click the solution node (i.e., **Solution 'COREDemo'**) in the **Solution Explorer** and select **Add** > **New Project**):
