Trainer API Coding Challenge
Requirements
Create two REST API endpoints as follows:

Create a new trainer
Get details for a trainer
The Trainer model should include (at the very least) the following attributes:

{
    "id" : "trainer-id-000001",
    "email" : "trainer@campgladiator.com",
    "phone" : "5125125120",
    "first_name": "Fearless",
    "last_name": "Contender"
}

Challenge Goal
The goal of this challenge is to produce a Production ready REST API. Please don't dedicate more than 3 hours to work on this project. It's ok to not complete it in full, but please add a README with instructions to run it, and what would be your next steps if you had more time available.

Application Details
.Net 5.0 API Application
Broken down into multiple projects for Reuseability and to avoid Dependency hell.
Uses Entity Framework with a InMemory SQLite DB for storage (Only while application is running, else its disposed).

Has four endpoints:
Trainer Contoller
   -Add Trainer
   -Get Trainer
   -Get Trainers
   -Modify Trainer

Console Logging for Requests / Errors
PostBody Validation
Unit Tests
Authorization Filter

Application Start
Cd into the root directory where the solution (.sln) file is at \ApiCodeChallengeRepo.

Run docker build -t apicodechallenge .

After Successful Building

Run docker run -d -p 8080:80 apicodechallenge

This will bind to localhost:8080.

Once running Import Postman Collection for endpoint useage.
