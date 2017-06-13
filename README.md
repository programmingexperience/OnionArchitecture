Hi,

Here I am developing a Token based Web API 2 using c# based on Onion Architecture with generic repository,unit of work and centralized exception logging system. It helps not only to a developer but also it helps to all IT organizastion to design and develop a API based on merden architecture and reduced the entire development time and delivered a successful product to there client/customers. 


# OnionArchitecture

Why Onion Architecture - 
There are several traditional architectures, like 3-tier architecture and n-tier architecture, all having their own advantage and disadvantage. All these traditional architectures have some fundamental issues, such as - tight coupling and separation of concerns. The Model-View-Controller is the most commonly used architecture, these days. It solves the problem of separation of concern as there is a separation between UI, business logic, and data access logic. MVC solves the separation of concern issue but the tight coupling issue still remains.
 
Tight Coupling - 
 
When a class is dependent on a concrete dependency, it is said to be tightly coupled to that class. A tightly coupled object is dependent on another object; that means changing one object in a tightly coupled application, often requires changes to a number of other objects. It is not difficult when an application is small but in an enterprise level application, it is too difficult to make the changes.
 
Loose Coupling - 
 
It means two objects are independent and an object can use another object without being dependent on it. It is a design goal that seeks to reduce the inter-dependencies among components of a system with the goal of reducing the risk that changes in one component will require changes in any other component.
 
On the other hand, Onion Architecture addresses both the separation of concern and tight coupling issues. The overall philosophy of the Onion Architecture is to keep the business logic, data access logic, and model in the middle of the application and push the dependencies as far outward as possible means all coupling towards to center.
 
 
Advantages of Onion Architecture - 
1. It provides better maintainability as all the codes depend on layers or the center.
2. It provides better testability as the unit test can be created for separate layers without an effect of other modules of the application.
3. It develops a loosely coupled application as the outer layer of the application always communicates with inner layer via interfaces.
4. Domain entities are core and center part. It can have access to both database and UI layers.
5. The internal layers never depend on external layer. The code that may have changed should be part of an external layer.
Onion Architecture relies heavily on the Dependency Inversion Principle. The UI communicates to business logic through interfaces. 

It has four layers.
1. Domain Entities Layer
2. Repository Layer
3. Service Layer
4. UI (Web/Unit Test) Layer

Domain Entities Layer - 
It is the center part of the architecture. It holds all application domain objects. If an application is developed with ORM entity framework, then this layer holds POCO classes (Code First) or Edmx (Database First) with entities. These domain entities don't have any dependencies.

Repository Layer - 
The layer is provided to create an Abstraction layer between the Domain entities layer and Business Logic layer of an application. It is a data access pattern that offers more loosely coupled approach to data access. We create a generic repository, which queries the data source for the data, maps the data from the data source to a business entity and persists changes in the business entity to the data source. Unit of Work is a design pattern which maintains a list of transactions ,updates the data source with the changes and also provides solution to the concurrency problems. So if the appliation is performing multiple concurrent operations then Unit of Work is the solution.

Service Layer - 
The layer holds interfaces which are used to communicate between the UI layer and repository layer. It holds business logic for an entity so it’s called business logic layer as well.

UI Layer - 
It’s the most external layer. It could be the Web Application, Web API or Unit Test project. This layer has an implementation of the Dependency Inversion Principle so that application builds a loosely coupled application. It communicates to internal layer via interfaces
