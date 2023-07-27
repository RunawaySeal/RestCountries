# RestCountries
**ASP.NET Core Wep Application** that consumes [Rest Countries Api](https://restcountries.com/).

The project consists of:
* **ASP.NET Core Wep App**: Where the logic to display data to the user exists. Using a MVC structure.

Multiple Class libraries:
* **Domain**: Models for the Api are stored here.
* **ApplicationServices**: Houses any logic needed after a call is done to the repositories. 
* **Infrastructure**: Contains code that retrieves any data from a source(external api/db).

## Features
This project contains the ability to:
* List all countries returned from Rest Countries Api.
* Search countries by **name**.
* Get information about a certain country by **name**.
* Get information about a certain **region.**
* Get information about a certain **subregion.**

# Get Started

This project requires Visual Studio to run locally. 
* Navigate to /RestCountriesWebApp to find the solution file(.sln) to run the project. 
* Ensure RestCountriesWebApp is set as start up project.