# ![Guaraci](docs/guaraci-icon.png) Clean Architecture CQRS with Derived Data  

CQRS, using Clean Architecture, multiple databases, and Eventual Consistency

## :bookmark_tabs: Detailed information

I also keep more detailed information in my blog

- [X] [CQRS Translated to Clean Architecture](https://blog.fals.io/2018-09-19-cqrs-clean-architecture/)
    - [X] CQRS Deep dive into Commands
    - [X] CQRS Queries and Materialization
    - [X] CQRS Consensus and Consistency
    - [X] CQRS Distributed chaos, CAP Theorem


## :floppy_disk: How do I use it?

You're going to need the following tools:

* Docker
* Visual Studio 2019+ or Visual Studio Code
* .Net 6

Execute in your favorite command line from the `/src` folder

```bash
$ cd src
$ docker compose build
$ docker compose up
```

Open your browser and hit the URL to see the OpenApi

`http://localhost:5000/swagger/index.html`

If you can't run you can hit the health checks to see if a component is down.

`http://localhost:5000/healthcheck`

If you still have issues, don't run as detached and look the error on the console after executing the docker command.

## :dart: Clean Architecture

Here's the basic architecture of this microservice template:

* Respecting policy rules, with dependencies always pointing inward
* Separation of technology details from the rest of the system
* SOLID
* Single responsibility of each layer


![cqrs-clean](docs/cqrs-clean.png)

## :scissors: CQRS

Segregation between Commands and Queries, with isolated databases and different models

![](docs/cqrs_layer_diagram.png)

### :arrow_down: Command Stack

Has direct access to business rules and is responsible for only writing in the application.

Below you can find a basic interaction between components in the **Command Stack**:

![](docs/create_card_interaction.png)

### :arrow_up: Query Stack

Responsible for providing data to consumers of your application, containing a simplified and more suitable model for reading, with calculated data, aggregated values and materialized structures.

The image contains the basic interaction between components in the **Query Stack**:



![](docs/get_card_list_interaction.png)

## :books: DDD

This example contains a simplified Domain Model, with entities, aggregate roots, value objects and events, which are essential to synchronize the writing with reading database.

## :heavy_check_mark: TDD

The project contains a well-defined IoC structure that allows you unit test almost every part of this service template, besides technology dependencies.

Inside the main layer you're going to find Interfaces that are essential for the application, but with their implementations inside their own layers, what allow Mocking, Stubbing, using test doubles.

There's a simple example using Mother Object Pattern and Builder to simplify unit tests and keep it maintainable and clean.

## :bar_chart: Data Intensive Microservice

This microservice template comes with SRP and SOC in mind. Given the own nature of CQRS, you can easily scale this application tuning each stack separately.

## :page_facing_up: Derived Data

Having multiple data stores makes this system a Derived Data system, which means, you never lose data, you can always rebuild one store from another, for example, if you lose an event which syncs data between the write and read database you can always get this data back from the write database and rebuild the read store.

*Domain Model* is materialized to *Query Models* using view materializer. Keeping this as separed component in the query stack allows fully control to mapped properties and fully testable.

## :envelope: Message Broker

Given the physical isolation of data stores, **Command Stack** and **Query Stack** must communicate to synchronize data. This is done here using a Message Broker.

![](docs/sync_write_read.jpg)

Every successful handled command creates an event, which is published into a Message Broker. A synchronization background process subscribes to those events and is responsible for updating the reading database.

## :clock2: Eventual Consistency

Everything comes with some trade offs. The case of CQRS with multiple databases, to maintain high availability and scalability we create inconsistencies between databases.

More specifically, replicating data between two databases creates an eventual consistency, which in a specific moment in time, given the replication lag they are different, although is a temporary state and it eventually resolves itself.

## :clipboard: References

Here's a list of reliable information used to bring this project to life.

* <a href="https://www.amazon.com/Designing-Data-Intensive-Applications-Reliable-Maintainable/dp/1449373321/ref=sr_1_1?ie=UTF8&qid=1537824366&sr=8-1&keywords=designing+data-intensive+applications" target="_blank">Designing Data Intensive Applications</a>

* <a href="https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164" target="_blank">Clean Architecture, Robert C. Martin</a>

* <a href="https://azure.microsoft.com/en-us/campaigns/cloud-application-architecture-guide/" target="_blank">Cloud Application Architecture Guide</a>

* <a href="https://www.microsoftpressstore.com/store/microsoft-.net-architecting-applications-for-the-enterprise-9780735685352" target="_blank">Microsoft .NET - Architecting Applications for the Enterprise, 2nd Edition</a>
