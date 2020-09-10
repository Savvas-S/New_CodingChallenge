# CodingChallenge

## Setup the environment

The best approach is to [duplicate](https://help.github.com/articles/duplicating-a-repository/) this repository to your personal Github account and commit changes there in meaningful, well-described chunks. 
Please mark your new repository as **private** (duplicating the repo in GitHub instead of forking it will allow you to mark it as a private repository).

## Part 1 - Refactoring
Refactor the given code.

## Part 2 - Fleet API 
Your goal is to create a stateful microservice that manages shipping containers, as a RESTful API. 

### Requirements
1. As a user I want the ability create containers and load them to my fleet of Ships and Trucks
2. As a user I want the load of my ships to be persisted so that state is persisted between service restarts (the data store can be as simple or complex as you want)
3. As a user I want to restrict the load per ship to a max of 4 containers because ship 1 and 2 have a max capacity of 4
4. As a user I want to register an unlimitted number of ships and make load transfers between them, so that I can manage my whole fleet
5. As a user I want to specify individual capacities per ship, so that I can handle ships with diferent capacities
6. As a user I want to also manage trucks, so that I can use the program to manage load of my trucks as well
7. As a user I want the offloading from trucks to be restricted to the last load, so that it is not possible to unload unreachable goods

### Bonus
- Present the vehicles in the fleet in a Web-based UI, each with its details and current load of containers
- The presentation can be as simple or as elegant as you want

## Tips
- Containerize your work wherever possible
- Take the time to document your API using an industry-standard methodology
- Testing makes perfect

## Submitting your results

In order to allow us to inspect the results, please grant access to our reviewers on your private clone of your exercise using either of the below:

- Username: hyperioreviewer
- Email: reviewer@hyperiosoftware.com
