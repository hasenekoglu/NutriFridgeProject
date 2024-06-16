
![Logo](https://github.com/hasenekoglu/NutriFridgeProject/assets/101149941/54480c73-2c64-47c0-b923-1102ac3f01cf)
# NutriFridge Project 


NutriFridge is an application designed to help users manage their kitchen inventory, receive recipe suggestions based on available ingredients, and create shopping lists. This project is aimed at individuals and families who want to promote healthy eating habits, reduce food waste, and simplify meal planning.

The application utilizes the ChatGPT API to provide recipe recommendations.


## Features

- Inventory Management: Keep track of all your kitchen items.

- Recipe Suggestions: Get recipe recommendations based on the ingredients you have.

- Shopping List: Create a shopping list from missing ingredients.

- AI-Powered Recipe Suggestions: Receive recipe suggestions using the ChatGPT API.

  
## Project Structure

The project is divided into several components:

- Backend: The backend part of the application is managed by this repo. [NutriFridge Backend](https://github.com/hasenekoglu/NutriFridgeProject)

- Frontend: The frontend part of the application is located [here](https://github.com/eyupkerem/NutriFridge-front).
## Installation 

To get started with NutriFridge, follow these steps:

##### 1. Clone the repository :
```bash 
git clone https://github.com/hasenekoglu/NutriFridge.git
cd NutriFridge

```
##### 2. Open the solution file NutriFridgeProject.sln in Visual Studio.    
##### 3. Restore the NuGet packages: 
```bash 
dotnet restore
```
##### 4. Build the solution
```bash 
dotnet build
```


## Usage

To run the application locally:

1. Ensure you have the necessary API key from OpenAI. If you don't have an API key yet, you can register for one at the OpenAI website.

2. Configure the API key in the appsettings.json file located in the WebApi project directory:
```csharp
{
   "ConnectionStrings": {
    "OpenAIKey": ""
  }
}
```
3. Start the application:
  ```bash
  dotnet run --project WebApi
   ``` 
## Technologies Used

### Server-side

 - **Platform:** .NET Core 8.0
 - **ORM:** Entity Framework Core 8.0.4
 - **Database:** SQL Server (via Microsoft.EntityFrameworkCore.SqlServer)
 - **API Documentation:** Swagger (via Swashbuckle.AspNetCore)

 ### Packages (Server-side)

- Betalgo.OpenAI.Utilities 8.0.1
- Microsoft.EntityFrameworkCore 8.0.4
- Microsoft.EntityFrameworkCore.Design 8.0.4
- Microsoft.EntityFrameworkCore.SqlServer 8.0.4
- Microsoft.EntityFrameworkCore.Tools 8.0.4
- Microsoft.Extensions.Configuration 8.0.0
- Microsoft.Extensions.Configuration.Abstractions 8.0.0
- Microsoft.Extensions.Hosting 8.0.0
- Microsoft.Extensions.Hosting.Abstractions 8.0.0
- Newtonsoft.Json 13.0.3

    
