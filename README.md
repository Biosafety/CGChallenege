# **Trainer API Coding Challenge**

## **Requirements**

Create two REST API endpoints as follows:

Create a new trainer
Get details for a trainer
The Trainer model should include (at the very least) the following attributes:
```
{
    "id" : "trainer-id-000001",
    "email" : "trainer@campgladiator.com",
    "phone" : "5125125120",
    "first_name": "Fearless",
    "last_name": "Contender"
}
```

## Challenge Goal

The goal of this challenge is to produce a Production ready REST API. Please don't dedicate more than 3 hours to work on this project. It's ok to not complete it in full, but please add a README with instructions to run it, and what would be your next steps if you had more time available.

## Application Details

1. .Net 5.0 API Application
2. Broken down into multiple projects for Reuseability and to avoid Dependency hell.
3. Uses Entity Framework with a InMemory SQLite DB for storage (Only while application is running).
4. Logging
5. Authorization Checking
6. Body Validation
7. Unit Testing

Four endpoints:
Trainer Contoller
- Accept Header must be included ``` Accept: application/json ```
- Authorization Header must be included ``` Authorization: anything ```
- Add Trainer api/trainers/
  - PUT
  - Postbody Validation
  - Request
```
{
    "firstName": "Bast",
    "lastName": "Son of Remmen",
    "address": "123 Main St, Anywhere USA",
    "email": "trainer@cg.com",
    "phone": "1234567890"
}
```
  - Response
```
{
    "trainerID": "51eedb43-4d39-4f52-ad49-19306759d578",
    "firstName": "Bast",
    "lastName": "Son of Remmen",
    "address": "123 Main St, Anywhere USA",
    "email": "test@cg.com",
    "phone": "1234567890"
}
```
- Get Trainer api/trainers/{GUID}
  - GET
  - Response
```
{
    "trainerID": "51eedb43-4d39-4f52-ad49-19306759d578",
    "firstName": "Bast",
    "lastName": "Son of Remmen",
    "address": "123 Main St, Anywhere USA",
    "email": "test@cg.com",
    "phone": "1234567890"
}
```
- Get Trainers api/trainers/
  - GET
  - Response
```
[
    {
        "trainerID": "51eedb43-4d39-4f52-ad49-19306759d578",
        "firstName": "Bast",
        "lastName": "Son of Remmen",
        "address": "123 Main St, Anywhere USA",
        "email": "test@cg.com",
        "phone": "1234567890"
    }
]
```
- Modify Trainer api/trainers/
  - PATCH
  - Request
```
[
    {
        "value": "Rabbit",
        "path": "/LastName",
        "op": "replace"
    },
        {
        "value": "Sally",
        "path": "/FirstName",
        "op": "replace"
    }
]
```
  - Response
```
{
    "trainerID": "51eedb43-4d39-4f52-ad49-19306759d578",
    "firstName": "Sally",
    "lastName": "Rabbit",
    "address": "123 Main St, Anywhere USA",
    "email": "test@cg.com",
    "phone": "1234567890"
}
```

Application Start
Cd into the root directory where the solution (.sln) file is at \ApiCodeChallengeRepo.

``` Run docker build -t apicodechallenge . ```

After Successful Building

``` Run docker run -d -p 8080:80 apicodechallenge ```

This will bind to localhost:8080.

Once running Import Postman Collection for endpoint useage.
[CodeChallenge.postman_collection.zip](https://github.com/Biosafety/CGChallenege/files/6987203/CodeChallenge.postman_collection.zip)


## Next Steps:
- Implement a non inmemory based DB
  - Move Context to start of app and use DI
- Properly introduce real token based Authorization
- Expand on logging
  - Request Id's
  - Logging to a service
- Expand Unit Testing to Service / Repo layer
- Depending on Scope of Data move to JSON:API ``` application/vnd.api+json ``` 
