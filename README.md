# Paylocity Deduction App - Created by Isaac Kronz
This app is used to calculate simple paycheck deductions and discounts.

It consists of a frontend written in React and running on Node
and a backend API written in C# running on the .NET framework.

The frontend acts as a client/interface to get input from the user regarding
their name and their dependents. All of the business logic is done on the backend API.

# Prerequisites

Node Package Manager

Visual Studio with C# and .NET packages installed

# Usage
First, navigate to `DeductibleApi`, and open the folder with Visual Studio.
Start the backend server by hitting the play button next to "IIS Express".
By default, this will run on `localhost:44360`

Second, navigate to the `paylocity-interview-frontend` folder in your command prompt.
Make sure to install dependencies with `npm install`.
Start up the frontend server by running `npm start` in the command prompt.
By default, this will run on `localhost:3000`

Open `localhost:3000` in your browser of choice (if npm start didn't open one for you), and enter an employer name and dependent names. The result should be calculated based off of the business logic defined by the rubric.

# Resources
Microsoft documentation for first creating a .NET Core API:
[https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio]()