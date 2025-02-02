
# Introduction
Movie booking backend service to show how this type of projects are created following OOPS and design principles.

# Project overview
- This poject is divided into has 3 libraries to make the code base modular and readable and easy to debug.
 - **Booking.Service**: This library contains all the Rest APIs. This is the service which will be deployed in case we want to go live.
 - **Booking.Common**: This library contains all the configuration shared across libraries.
 - **Booking.DataRepositories**: This library is the data layer of our service which communicates to the database, in this case it is mongo DB.

 The reason to divide it into libraries is to write the logic according to the use case or providing single responsibility to each libraries.
 This will make the code base cleaner.

## Sequence showing how the request flows
 ```mermaid
 flowchart LR
db[(database)]

subgraph Booking.Service
    Controllers --> Managers
end
    Managers --> DataRepositories
subgraph Booking.DataRepositories 
    DataRepositories
end
DataRepositories --> db
Client --> Controllers

 ```

From the above diagram it is much easier to visualize how the reqest/data flow happens.



