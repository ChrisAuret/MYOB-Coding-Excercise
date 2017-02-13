
# MYOB Coding Excercise

## Running the code

You will need
- Git
- Visual Studio 2015

1. Clone the repo from [GitHub](https://github.com/ChrisAuret/MYOB-Coding-Excercise)
    ```
    git clone git@github.com:ChrisAuret/MYOB-Coding-Excercise.git
    ```
2. Open the solution in Visual Studio 2015
2. Build the solution (F6) (this will download nuget packages)
3. Paste test data into input.csv

## To Run Tests

Double-click "runtests.bat" from the file explorer

## To Run Console Application
-   Make sure to paste in test data into "input.csv"
-   Make sure solution has been built
-   Just hit F5 in Visual Studio and console app will run

## Assumptions
- File contains up to 50000 records
- Each record in the input file has been validated already
- Database is not needed as will process all recoreds in memory
- **I'm not sure about the "Pay Period" field**. Im assuming its static text in the form of:
   ```
    {1st day of Month, Month} - {Last day of Month, Month}
    ```
    **The intructions say it is a calculated field but the test data it is just static text?**
    
## Decisions
- I decided that a user interface is not important for this task. I've focused on the domain layer and unit tests and not on presentaion aspects.
