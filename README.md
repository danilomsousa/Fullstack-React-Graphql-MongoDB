# Personnal Project 

This project was developed to a technical interview. 
The goal was to have a Full Stack application using React as Frontend and a Backend running with a GraphQL and a MongoDB.

The solution provides a simple portal that shows information from a 3rd party RestAPI working as a middleware.

## Test solution

Backend: In the root directory, you can use Docker to process the solution running: 

### `docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d`

The graphQL will be available on: [http://localhost:9006/api/graphql/] (http://localhost:9006/api/graphql/)


Frontend: In the react-app directory, run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.