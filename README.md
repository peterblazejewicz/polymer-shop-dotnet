# polymer-shop-dotnet

The Polymer's Shop app that runs on Kestrel with Web API backend: https://github.com/Polymer/shop

## Development concepts used

- CORS support

The server part is configured to support API requests from client application run on other host. 

- Swagger UI support

The server part contains Swagger UI configuration and metadata. It can be viewed at standard `/swagger/ui` path.

- Dotnet Core Web API RESTful api

- Polymer app built with Polymer CLI

Many things are still in non-finished state, for example build phase for Polymer app and publish method for Kestrel needs some work on correct configuration, for example for `hosting.json`. The backend is not yet added and will be based on SQLite driver from AspNet Core (EF7).

## Author

@peterblazejewicz 