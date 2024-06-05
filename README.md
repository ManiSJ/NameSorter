Sort names by last name and then by given name.

Tech stack - Net 7.0 Console app, xUnit, Shouldly, Jenkins

How to Run - NameSorter.exe unsorted-names-list.txt

  -- unsorted-names-list.txt is the file with unsorted names

Result - It will generate a sorted-names-list.txt file which is overwritten each time.

CI - Jenkinsfile - clean, build, test, publish, run .exe with one argument, post action
