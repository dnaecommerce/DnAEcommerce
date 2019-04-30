# Dan & And Ecommerce: Lunar Real Estate at Bargain Prices

------------------------------

## Authors

* Daniel Logerstedt ([github.com/daniellogerstedt](https://github.com/daniellogerstedt))
* Andrew Curtis ([github.com/amjcurtis](https://github.com/amjcurtis))

---------------------------------

## We are deployed on Azure!

[dnaecommerce.azurewebsites.net](https://dnaecommerce.azurewebsites.net/)

---------------------------------
## Web Application

### Business Model and Products

Dan & And Ecommerce is a collaborative project in which we built a mock online storefront
that offers the all of the primary features and services of an ecommerce shop.
It caters especially to those in the lunar real estate market. 
Our fictitious ecomm business specializes in finding the most desirable craters
and other features of Earth's nearest celestial neighbor and offering them at
exceptionally low prices. It offers a smooth, intuitive online shopping experience
at each stage from registration and login to browsing products and checking out. 

### Web App Tools and Architecture

Our web application consists of a frontend site built with Razor views, HTML, CSS,
and Bootstrap. The backend is written in C# using ASP.NET Core, Entity Framework Core,
and the MVC framework. 

### Claims and Policies

Upon registration we capture the following claims: 

* A custom claim for the user's full name (composed of their first
and last name)
* User's email address
* Custom claim for whether or not the user is certified for space travel.

These claims are captured from the account registration page and processed in the account
controller so they can be used later to gate access to certain pages on the site and to
store the user's selected products and orders. 

We use the custom claims-based policy "SpaceTravelCertified" (a `bool`) to control access
to a Space Travelers page that allows users who meet the policy requirement to see the number
of other space travel-certified users who have shopped on the site. 

---------------------------------

## Tools Used
Microsoft Visual Studio Community 2017

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- HTML
- CSS
- Bootstrap
- SQL Server
- Azure

---------------------------------

## Recent Updates

#### v. 1.0
*Published app v1.0* - 2019-04-30

---------------------------

## Model Properties and Requirements

### Product

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Sku | string | YES |
| Name | string | YES |
| Price | decimal | YES |
| Description | string | YES |
| Image | string | YES |

### User

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| FirstName | string | YES |
| LastName | string | YES |
| SpaceTravelCertified | bool | YES |

---------------------------

## Change Log

1.0: *Published site on master branch* - 2019-04-30
