How to build the code 
o How to run the output 
  There are three projects in the solution:
  TNAChallange: Dot net core project library, a service-oriented architecture approach, contains the business logic.
  TNAChallangeConsole: A console application , the console can either run from within the visual studio or navigating to bin\Debug\netcoreapp3.1 and run the TNAChallangeConsole, the application promots the user for a document id to conduct the search.
  TNAChallangeUnitTests: A TTD approach development with six unit tests, using the Mock framework for Api data mocking in JSON format. The tests must run within visual studio test explorer 

o How to run any tests that you have written 
  From within visual studio 2019 test explorer , navigate to TNAChallangeTests, if tests are not available, go to test menu and click on test explorer click run all
o Any assumptions that you’ve made 
  The development made under Dot net core 3.1 visual studio 2019 using service oriented architecture , SOLID principle focusing on dependency injection design patterns so to achieve decoupling and freedom of testing.
o Anything else you think is relevant 
  I have highlighted that http://discovery.nationalarchives.gov.uk/API/records/v1/details/ running on port 80 only, this could propose security threats as data transferred is not encrypted , therefore sensitive data if any, is exposed.
