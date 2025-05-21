# Star Wars Characters BIH Technical Test

## About

A Nuxt/Vue application, served by a C# Api calling swapi.dev

The app lists characters from the show, including their detailed info.

Characters can be liked

Characters review can be added

This is submitted to the api, but this will fail


## Setup

### Frontend

Information on how to setup and install the frontend is in the ReadMe in the frontend folder

Requires Node >=22

### Backend

C# .Net 8 api

Runs against:
https://swapi.info/ 


### Unit Tests

In StarWarsApi.Tests

These can be run in Visual Studio

# Running

## Frontend

`cd frontend`

`npm run dev`


## Backend

`cd StarWarsApi`

run

`docker compose up`

or

`docker compose up --build`

Should run it on localhost:5000

This is what nuxt config is looking for.

If running in Visual Studio, or for some reason it is different, 
go to nuxt.config.ts

change apiUrl to correct localhost port


