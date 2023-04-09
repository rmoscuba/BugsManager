# BugsManager
WebApi Project from scratch to manage bug assignments

## The system is live in: 
https://rmoscuba.bsite.net/

## About
We are working on a bug tracking project with three entities: Project, Bug, User

User:
*	Id - user identifier
*	Name - user first name
*	Surname - user surname

Bug:
*	Id - bug identifier
*	projectId - project identifier
* User - related user
*	Description - text summary of the bug (maximum 100 characters)
*	CreationDate

Project:
*	Id - project identifier
*	Name - project name
*	Description - a brief description of the project (optional)

## Backend design

We use the Repository pattern to allow to separate the data access logic and the underlying data source 
from the business logic for better maintainability, scalability, and testability of the code.
