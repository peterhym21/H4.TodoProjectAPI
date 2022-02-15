# TODO

This Project is made to Train My skills in API, OAuth And OpenID

<br>


## Technical Details

**FBT** : Folder By Type  
**FBF** : Folder By Feature  

|Project Name|Language|Folder Structure|
|-|-|-|
|*TodoWebAPI*|* ASP.Net API 6.0*|*FBT*|

<br>


### API Overview


| API                      | Description                      | Request body | Response body        |
| ------------------------ | -------------------------------- | ------------ | -------------------- |
| `GET /`                  | Browser test, "Hello World"      | None         | Hello World!         |
| `GET /todoitems`         | Get No-Completed all to-do items | None         | Array of to-do items |
| `GET /todoitems/all`     | Get all to-do items              | None         | Array of to-do items |
| `GET /todoitems/{id}`    | Get an item by ID                | None         | To-do item           |
| `POST /todoitems`        | Add a new item                   | To-do item   | To-do item           |
| `PUT /todoitems/{id}`    | Update an existing item          | To-do item   | None                 |
| `DELETE /todoitems/{id}` | Delete an item                   | None         | None                 |


<br>


### Technologies and prerequisites


- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [ASP.Net 6.0](https://docs.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-6.0&tabs=windows)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Razor Pages](https://www.learnrazorpages.com/)
- [Log4Net](https://logging.apache.org/log4net/)
- Basic knowledge of VSTS, GIT and LINQ


<br>


## Use of third party libraries


### Todo.WebAPI
| Name                                                 | Version |
| :--------------------------------------------------- | :------ |
| Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore | 6.0.2   |
| Microsoft.EntityFrameworkCore.InMemory               | 6.0.2   |
| Swashbuckle.AspNetCore                               | 6.2.3   |


<br>


## Responsible People  


|Name|E-mail|Role|
|-|-|-|
|Peter Hymoller|Peterhym21@gmail.com|Developer|
|Peter Hymoller|Peterhym21@gmail.com|Product Owner|