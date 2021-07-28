# PokemonExcercise

Welcome to my [Pokemon Excercise](https://docs.google.com/document/d/13EtWfHtIXEvMf-0HmbhsgX83EUlTUEdqPPIv4InbuuI/edit) repo.

The solution is a dockerised .NET Core API. I've used the PokeApiNet nuget package to handle interactions with the PokeApi API because handwriting a client would have been painful. A swagger page is included to make testing easier. I've written unit tests around most of the branching logic.

### To run:
- Ensure docker is installed
- Point a terminal to the root of the repository
- Run command `docker build -t pokemon-api -f PokemonExcercise/Dockerfile .`
- Run command `docker run -it --rm -p 8080:80 pokemon-api`
- Point a browser to localhost:8080 and you should see a swagger page where you can play with the endpoints

### To run tests:
- Ensure .net core SDK is installed
- Point a terminal to the root of the repository
- Run command `dotnet test`

### What I'd do differently for a production API:
- Secure the endpoints as required
- Read errors thrown by PokeApi and return NotFound status when the pokemon name is not recognised
- Move the URL for the translator API to app settings with user secret support
- Log any errors to an error reporting service - *particularly unsuccessful responses from external APIs*
- Have separate controllers and services into different projects
- Tackle description formatting issues
