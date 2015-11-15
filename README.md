#Gada International

## Technologies

The Gada International web application has been built with the following technologies:

- Angular.JS v1.3.15
- Web API 2.0 (C# .Net 4.5)
- Dapper
- Entity Framework
- SQL Server 2014
- AutoMapper
- Autofac
- OWIN
- .Net Identity

## Setup

For this project to work you will also need the GadaInternational-Users project from https://github.com/Ragabon/GadaInternational-Users. 

To set up the database you will need to run the migration scripts in order from the `migrations.txt` file in the `sql` folder

## Bounded Contexts
The project is set up to use bounded contexts. Currently the following contexts exist:

- Users (Accounts)
- Discussions
- Interests
- Skills
 
Each context only knows the minimum amount of information about another context that it needs to. For example, the discussions context doesn't know everything about the interests. It needs to know the Id and Title but not the category. 
All contexts exist under the `Domain` folder.

Another important note about this is that it prevents bleed of the entities/models as can sometimes easily be done in other traditional onion architecture approaches.

## Infrastructure

The infrastructure is split into two components. Dapper is used for database reads and Entity Framework is used for the writes. This is done to ensure that the database is correctly kept up to date as is always in sync. So instead of just creating a post with a discussion_id in the database we update the discussion and add the post to it.

##  The next steps

So far we have provided a sound basis for further developments. The immediate next stages of development are to:

- Implement a `forgotten password` link
- Allow editing and deleting of posts and discussions
- Create a CMS for administrators to use so that they can edit the static content
