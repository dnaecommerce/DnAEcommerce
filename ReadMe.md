# D&A Moon Plots: Lunar Real Estate at Bargain Prices

## Developers

* Daniel Logerstedt: [github.com/daniellogerstedt](https://github.com/daniellogerstedt)
* Andrew Curtis: [github.com/amjcurtis](https://github.com/amjcurtis)

---------------------------------
## Web Application

### Business Model and Products

D&A Moon Plots is a collaborative project in which we built a mock online storefront
that offers the all of the primary features and services of an ecommerce shop.
It caters especially to those in the lunar real estate market. 
Our fictitious ecommerce business specializes in finding the most desirable craters
and other features of Earth's nearest celestial neighbor and offering them at
exceptionally low prices. It offers a smooth, intuitive online shopping experience
at each stage from registration and login to browsing products and checking out. 

### Web App Tools and Architecture

Our web application consists of a frontend site built with Razor views, HTML, and CSS. The backend is written in C# using ASP.NET Core, Entity Framework Core,
and the MVC framework. 

### Claims and Policies

Upon registration we capture the following claims: 

* User's email address
* A custom claim for the user's full name (composed of their first and last name)

These claims are captured from the account registration page and processed in the account
controller so they can be used later to gate access to certain pages on the site and to
store the user's selected products and orders. 

---------------------------------

## Tools and Technologies Used

- C#
- ASP.NET Core MVC
- ASP.NET Identity
- Entity Framework
- Razor Pages
- HTML
- CSS
- Bootstrap
- Sass/SCSS
- xUnit testing framework
- SendGrid email service
- Authorize.Net payment API
- SQL Server
- Azure

---------------------------

## Model Properties and Requirements

Our SQL Server database schemas are informed by the models below. 

Data in the Basket and BasketItem models is created
and stored once per customer and persists for the duration
of the shopping checkout process. Upon completion of checkout,
the data is transferred and stored in the Order and OrderItem models,
and the instances of the customer's Basket and BasketItem are removed.
Beyond the properties included in Basket, the Order model has an additional
property for tracking the final total price of the order.

### User

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| FirstName | string | YES |
| LastName | string | YES |
| SpaceTravelCertified | bool | YES |

### Product

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Sku | string | YES |
| Name | string | YES |
| Price | decimal | YES |
| Description | string | YES |
| Image | string | YES |

### Basket

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| UserName | string | YES |
| Subtotal | decimal | YES |
| --- | --- | --- |
| List\<BasketItem\> | BasketItems | YES | 

### BasketItem

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| BasketID | int | YES |
| ProductID | int | YES |
| Quantity | int | YES |
| --- | --- | --- |
| Basket | Basket | YES | 
| Product | Product | YES |

### Order

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| UserName | string | YES |
| FirstName | string | YES |
| LastName | string |  YES |
| Address | string | YES |
| City | string | YES |
| State | string | YES |
| PostalCode | string | YES |
| PhoneNumber | string | YES |
| Subtotal | decimal | YES |
| FinalTotal | decimal | YES |
|  TransactionNumber | string | YES |
| OrderDateTime| DateTime | YES |
| --- | --- | --- |
| List\<OrderItem\> | OrderItems | YES | 

### OrderItem

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| OrderID | int | YES |
| ProductID | int | YES |
| Quantity | int | YES |
| --- | --- | --- |
| Order | Order | YES | 
| Product | Product | YES |

---------------------------

## Change Log

0.1.0: *Published site on master branch.* (2019-04-30)

0.2.0: *Site updated with order checkout functionality, SendGrid email service integration, and styling across site.* (2019-05-08)

0.3.0: *Added integration with Authorize.Net for payment processing and Azure Blob Storage for serving product images. Built out admin and user profile pages with select CRUD operations.* (2019-05-16)

0.4.0: *UI improvements: styling, markup, image display, etc. Vulnerability report.* (2019-05-18)

1.0.0: *v1.0 release* (2019-05-20)
* Site undeployed 2019-10. Code is still deployment-ready though.
