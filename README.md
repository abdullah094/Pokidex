
# Pokedex API

A .NET custom implementation of [Pokemon API](https://pokeapi.co/) and [FunnyTranslations API](https://funtranslations.com/api/)



## Installation

Download [.NET 5.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) and install

    
## Run

Open terminal in the Pokedex.Api project and run these commands. It may ask you to insert your computer credentials.
```bash
  dotnet build
```
```bash
  dotnet run
```

You should see the Microsoft.Hosting.Lifetime is listening

Open one of the url on which the host is listening followed by '/swagger'
```bash
  https://localhost:5001/swagger
```

## Run Tests

Open terminal in the Pokedex.UnitTests project and run these commands.
```bash
  dotnet build
```
```bash
  dotnet test
```
## API Reference

#### Get the basic information of the pokemon

```http
  GET api/v1/pokemon/${pokemonName}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `pokemonName` | `string` | **Required**. Name of pokemon |

#### Get the basic information of the pokemon with it's description translated

```http
  GET api/v1/pokemon/translation/${pokemonName}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `pokemonName`      | `string` | **Required**. Name of pokemon |




## Features - changes for production 

- Add Authentication to prevent unauthorized requests
- Caching

