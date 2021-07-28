# PokemonExcercise

Welcome to my [Pokemon Excercise](https://docs.google.com/document/d/13EtWfHtIXEvMf-0HmbhsgX83EUlTUEdqPPIv4InbuuI/edit) repo. The solution is a dockerised .NET Core API - there are also a few unit tests which can be run in Visual Studio.

### To run:

- Ensure docker is installed
- Point a terminal to the root of the repository
- Run command `docker build -t pokemon-api -f PokemonExcercise/Dockerfile .`
- Run command `docker run -it --rm -p 8080:80 pokemon-api`
- Point a browser to localhost:8080 and you should see a swagger page where you can play with the endpoints

### Production changes:

- Secure the endpoints as required
- Read the errors thrown by PokeApi and return NotFound status if the name is not recognised
- Move the URL for translator to app settings with user secret support
- Log any errors to a error reporting service - particularly unsuccessful responses from external APIs
- Have seperate projects for the controllers and services
- Tackle description formatting issues
