# Log Proxy API

- Uses .Net Core 3.1 Web Api, which receives log messages and forwards them to third-party API.

- Implements basic authentication. 
  
- Unit tests are implemented using XUnit and Moq.

- Solution is packed with a docker container.
  
- Steps to build and run the application,
  - [x] Create a docker container using **"docker run -it --rm -p 8080:80 khaireaniket/logproxyapi"**
  - [x] Open a web browser and navigate to **"http://localhost:8080/swagger"**
  - [x] Since basic authentication is enabled, click on Authorize button. It should look as follows,
  
    ![image](https://user-images.githubusercontent.com/60029642/107157406-fd00a700-69a9-11eb-84f8-b1d56e642605.png)
    
  - [x] Enter the Username as **test** and Password as **test**
  - [x] To get 'n' number of log messages from the API, execute GET endpoint, where 'n' can be passed as a query string (default = 3)
  - [x] To create or post log messages to the API, execute POST endpoint. Sample request model as follows,
  ```json
  {
    "logRequest": [
      {
        "title": "Event OrgCreated successfully",
        "text": "Domain event organization created with aggregate id 111"
      },
      {
        "title": "Event OrgUpdated successfully",
        "text": "Domain event organization updated with aggregate id 111"
      }
    ]
  }
  ```
