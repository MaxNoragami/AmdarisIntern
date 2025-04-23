### Assignment Requirements:

1. Take a look at the Speaker class in this GitHub repo: https://github.com/mustafadagdelen/dirty-code-for-clean-code-sample/blob/master/BusinessLayer/Speaker.cs
2. Create a console appliation and refactor the Speaker class from the repo, so that it adheres to clean code, SOLID principles and generally to good coding practices
3. Also create the other classes needed for the app to compile, like the Session class. Don't concentrate on refactoring them. Use them just for the purpose of your application to work
4. In a readme.md file, answer the following questions:

#### Questions Answers:

***What code smells did you see?***

- Fragility is well noticedm as everything can break from small changes
- Unreusable parts of the code
- The entire file is opaque, hard to understand
- Rigidity is high
- Hardcoded values aka Magic Numbers

***What problems do you think the Speaker class has?***

- One `Speaker` class that does everything
- `Speaker` class with a large volume
- Abbreviations of variable names, such as `ot` or `appr`
- Methods large in volume
- Usage of boolean variables to alter the executed logic
- Overly nested if-else statements

***Which clean code principles (or general programming principles) did it violate?***

- From SOLID it has clearly violated SRP, OCP, and DIP
- The code convetions were not respected
- Commented out deprecated code was present 
- KISS also got violated

***What refactoring techniques did you use?***

- Tried to refactor everything by following the SOLID principles, especially SRP and DIP
- Separated the code into different classes/methods, via *Extract Method / Class*, such as Entities, Exceptions, etc
- Followed code convetions

##### Example Request Body:

```json
{
  "firstName": "Max",
  "lastName": "Alex",
  "email": "yolo@amdaris.com",
  "experience": 1,
  "hasBlog": true,
  "blogURL": "http://max.xn--q9jyb4c",
  "browser": {
    "name": "Firefox",
    "majorVersion": 13
  },
  "certifications": [
    "Microsoft", "Another", "Diploma"
  ],
  "employer": "Google",
  "registrationFee": 0,
  "sessions": [
    {
      "title": "Yolo",
      "description": "yolo"
    }
  ]
}
```