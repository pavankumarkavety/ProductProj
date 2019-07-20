# ProductsAPI



### Technical Environment

- Asp.NET Core

- Visual Studio 2017 compatible



### Solution

Solution contains Web API and Test Project



### Test Data for APIs
Get
Browser Input: /api/products/1

Browser Result: {
    "id": 1,
    "name": "Bread",
    "price": 3.0
}


Post
Browser Input: /api/products

{
	"name": "Mangoes",
	"price": "3"
}

Output: Creates new json file in assets/products folder