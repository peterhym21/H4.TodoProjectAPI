# TODO

This Project is made to Train My skills in API, OAuth And OpenID

<br>



## Krav


- [X] En Index forside (der kan fortælle lidt om projektet - og som altid vil tillade anonym adgang)
- [X] En TodoItems side der viser alle TodoItems , der ikke er udført
- [ ] Klikker man på et TodoItems Description, åbnes emnet på en ny Page. Her er mulighed for at redigere Description, Completed og Priority. Der er lavet validering af brugerdata. 
  - [X] (Har en Edit knap med en edit side)
- [X] Desuden skal man kunne slette emnet og der skal gerne kræves en godkendelse inden emnet slettes.
- [X] På forsiden skal der være en mulighed for at oprette et nyt TodoItem. Der er lavet validering af brugerdata. Som en ekstra option kan man lave formen som en Modal form.
- [X] Når man klikker på et TodoItems Checkbox for at markere at et TodoItem er udført, fjernes emnet fra forsiden (SoftDelete). Tip: Named PageHandlers
  - [X] (kan man i hvert fald ændre i Edit page) 
- [X] Der er lavet en TodoService, som injectes med DI
- [X] Applikationenens konstanter, som f.eks. URL's og andet er angivet i en AppConstants klasse
- [X] Der laves en ReadMe til projektet, der bl.a. markerer hvilke krav der er opfyldt

<br>



## Technical Details

**FBT** : Folder By Type  
**FBF** : Folder By Feature  

|Project Name|Language|Folder Structure|
|-|-|-|
|*TodoWebAPI*|* ASP.Net Core Web API, .NET 6.0*|*FBT*|
|*TodoWebClient*|* ASP.Net Core Web, .NET 6.0*|*FBT*|

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