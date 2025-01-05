# TESTNA APLIKACIJA

Project used for  managing requests using ASP.NET Core and the Clean Arhitecture design pattern.
The task include key functionalities for working with requests (creating, reading, updating and deleting) and the use of an InMemory database.


### Setup instructions

Before you begin, make sure that you have install docker on your local machine.  
	 For Windows and macOS please visit [Download docker Desktop](https://www.docker.com/products/docker-desktop/)


### Installation & Run: 
 
 1. Install docker desktop for Windows or macOS from the official [website](https://docs.docker.com/desktop/setup/install/windows-install/), then follow the instructions.
 
	
 2. Check if you have installed [Git](https://git-scm.com/downloads).

 3. Run application
	
	1.	Frist Clone repository.
		 
		 ```console
		git clone C:\Users\Uporabnik\source\repos\TestnaNaloga1
		cd TestnaNaloga1
		  ```
	2. Run docker compose
	
		```console
		docker compose up -d
		```		
	 
		You can also check in docker desktop if container is up. 
	
	3. Open swagger on browser.
		
	   [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html)


