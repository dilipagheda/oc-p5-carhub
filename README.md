# Project - Car Hub Web Application
This is the 5th Project as part of Openclassroom's .NET Backend Developer Path. It is about building a web application for a company called Car Hub. This company's main business is to buy old car, repair it and then resell. This web application allows the company to manage their car inventory and let their customer's view what cards they have got at moment.

# Project requirement
This project is developed for a car dealership called Car Hub. His owner, Eddie needs a new web application to manage his lot inventory. Below is the requirement as described by Eddie.

I’ve been doing everything with spreadsheets for so long because I don’t know anything else. I’ve never even had a website. I’m excited to see your ideas! As promised, here are the details.

I usually buy cars at auction, make repairs, then resell them at a small profit. My business model is based on the idea that I believe can make more money long term by trading in volume, so I just add $500 to my total costs for each car. I add the auction price and the cost of repairs and conditioning, plus $500, to get my selling price.

I want to be able to view all the cars in my inventory, add new cars, make changes to current listings (like adding new photos and other details), and mark cars as sold or no longer available. I don’t want anyone else to have access to this part of things. I want everyone to be able to see what I have available on my lot, but I need to be the only person with access to make changes. If you can show me something like that, I’ll be happy. I’ve heard stories about companies getting hacked through their websites. I think that’s one of the reasons why I’ve stayed away from it for so long. I don’t want my site to be vulnerable.

Since this is a prototype, I don’t care too much about what it looks like yet. I mean, I’d like to see a nice looking home page, just to give me an idea of what you can do for me. But for the rest of it, I just want to be able to see how I’d add cars, make changes, that sort of thing. You don’t need to spend time making those parts look good. Although I should say that I want to make sure that certain things are always consistent. For example, if I need to enter a date, I should always enter it the same way, like through a calendar selector or something. I don’t want it to be possible to enter dates in different ways. Same goes for things like the car year. I don’t want to accidentally type 2117 as a car year. And I’m probably never going to buy a car for my lot older than 1990. Oh, and one more thing, just make sure things are labeled. I don’t want to end up typing a car’s model in the make box.

# Business rules
This project has few business rules that are implemented at both front-end using jQuery and back-end using FluentValidations.

* If inventory status = Sold then Sale price and Sale date are mandatory. otherwise they are optional.
* If repair description and repair cost is not entered then display an alert notifying the user that "are you sure you dont want to enter repair details?". if user selects yes then allow user to proceed
* If repair cost or repair description is entered then the other field is mandatory
* If repair description is entered then repair cost should be greater than 0
* If user selected 'Add new.." from the Car Make drop down then 'New car make' field is mandaotory
* If user selected 'Add new.." from the Car Model drop down then 'New car model' field is mandaotory
* If user selected 'Add new.." from the Car Trim drop down then 'New car trim' field is mandaotory
* Year is mandatory
* Km is mandaotory and should be between 1 and 500000
* Rego number is mandatory
* Rego expiry date is mandatory
* Transmission type is mandatory
* If user selected 'Add new.." from the Color drop down then 'New car color' field is mandaotory
* If user selected 'Add new.." from the BodyType drop down then 'New body type' field is mandaotory
* No of seats is mandatory and should be between 1 and 10
* No of cylinders is mandatory and should be between 1 and 10
* If user selected 'Add new.." from the DriveType drop down then 'New drive type' field is mandaotory
* If user selected 'Add new.." from the FuelType drop down then 'New fuel type' field is mandaotory
* Description is multi line and is mandatory. should be between 1 and 1000
* Purchase price is mandatory and should be between 1 and 100000
* If user selected 'Add new.." from the PurchaseType drop down then 'New purchase type' field is mandaotory
* Lot date is required
* Sale price must be at least "purchase price + repair cost + 500"
* InventoryStatus is mandatory

# Functionality



# Techskills Used



# How to set it up locally

* You need to have Visual studio 2019 installed with .Net Core SDK

* You need to have a SQL Server installed on local machine. Then make sure to update the connection string to point to your local database in appsettings.json

```
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-CarHub-EB14AE37-856E-4701-BF44-0A20885272FA;Trusted_Connection=True;MultipleActiveResultSets=true"
  },

```

* The project is configured with seed data of 10 cars in the inventory.

* The projec is also configured with a default Admin account to manage the inventory data.
  UserName: Admin@carhub.com
  Password: P@ssword123

* Download the project from github.
  Link: https://github.com/dilipagheda/oc-p5-carhub

* Build it first in the Visual Studio.

* Then, open Package Manager Console and run this command
`Update-Database`

This command will create the local database and seed it with starter data.

* Open the solution (*.sln) file in Visual Studio 2019. and hit the run button. Once project starts running, it should display the home page. Then, you can click on Login and login with above credentials in order to see the Admin menu and manage inventory data as an admin.

# Screenshots


