# Introduction
Implementing a movie booking service consisting of several endpoints showing how concepts of Object Oriented Programming are used to create such projects following best design principle practices.
**NOTE:** I am not saying that OOPS is the best way to write code or create service(s), since it is one of the most widely used concept, hence discussing here.

## Project Structure
It has 3 assemblies consisting of 1 executable and 2 dlls(dynamic link libraries).
The reason to create different assembly is to make your code base `modular` and also honoring the `single responsibility principle`.
NOTE: single responsibility does not necessarily mean "one method one task". On a broader level think it as one unit should perform one type of task(s).

Listing the assemblies and how do they refer each other showing the dependency relation.
Assemblies are:
- Booking.Common.dll --> It contains all the contracts and common configurations which are used across assemblies.
- Booking.DataRepositories.dll --> It contains the data base context. It performs the data base opearations.
- Booking.Service.exe --> It is the service which contains all the API and their business logic.
  
These assemblies are further divided into multiple packages, which performs speficific tasks again honoring `SRP`. I will not mention all the packages becuase there are too much.

**Booking.Service** which is the business layer depends on **Booking.DataRepositories** which is the data layer so here we can see a dependency relation between these two.
**Booking.DataRepositories** and **Booking.Service** refers **Booking.Common** for configurations.

Next section shows how some of the concepts and design priciples are used in the project.


## Dependency Injection
It is a good practice to use DI wherever possible to make the code base clean and extendable. becuase it avoids the object creation.
I prefer to do it using interfaces via constructor by keeping only the the user facing methods inside interface and then extend it from the concrete class.
One thing to keep in mind is that whenever we doing inversion of control we need to register the interface and its concreate class as a dependency to the framework. 
different frameworks has different way to do it but they do the same thing.
Here in this project it is heavily used. Refer `BookingService -> Managers -> MovieBookingManager.cs` class, here you will see that all the dependencies of this class
are injected in the constructor and then they are being used without creating objects. For registering these dependency refer `Booking.Service -> Program.cs`. They are 
registered as singleton.

## Encapsulation
This is the most common and mostly used OOPS concept. it basically restricts(hide) the implementation from external world by providing an interface(way to access the data).
Here `Booking.DataRepositories -> DBClient.cs` class has access modifier as `internal` which means that it is only accessible by classes/methods inside its library only.
NOTE: `Booking.Service` can still persist data in the DB using the repository classes but for it `DBClient` is completely hidden.

## Single Responsibility Principle
This is also widely used int this project from assembly level till methods. I have already give an overview of how this is used in assembly level, here is an example of how it used  at class and methods. Refer `BookingService -> Managers -> MovieManager` class, this class only takes care of operations related to movies. It does care about `MovieTheatre` or `ScreeningRoom`
related use cases those are again handled by their respective manager classes. Also each methods inside this class takes care of only one use case. Similary this principle is used in all classes.

## Open/Closed Principle
"Open for extending closed for modification". This is the most confusing for developers. How i look at it is **"Don't touch the existing code"**.
Extend the code base features by using the existing code/classes. Here in this project refer `Booking.Repositories` namespace. It consists of data respositories which perform database operations on their specific tables (see again single responsibilty). `MovieRepository` is one of them. 
Just to give a prerequisite these repository classes uses `DBClient` class to create the database client. Now if we want to add a new table "Users" and want to perform database operation there. Now since **existing** repository classes are for specific tables and also `DBClient` is separate, we can add one more repository class lets say `UserRepository`  and use `DBClilent` method to establish a database connection and perform the required operation without changing the existing code.

## Modular Code Base
This is already discussed in the overview section but just to give more insights lets consider `Booking.Service` assembly it is further divided into `Controllers`, `Managers`,
`Interfaces`, `Helpers` packages. Controllers again have controllers specific to their own use cases like `MovieController` for movie use case, `MovieTheatreController` for theatre use
case etc. This is done to to have a modular code base which can be extended easily. This helps in `debiggin`, `code reviews` etc.

For now this much, i will add more insights as i keep on adding more to this project.


