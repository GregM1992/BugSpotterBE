
# BugSpotterAPI

BugSpotterAPI is a backend API designed for managing and tracking insect-related data, user interactions, and more within the BugSpotter application. Built using Entity Framework, .NET, and ASP.NET Core, this API provides comprehensive CRUD operations for resources such as posts, comments, users, suggestions, and collections.

## Table of Contents

- Overview
- Features
- Technologies
- Setup and Configuration
- Usage
  - Api Endpoints
  - Testing with Postman
- Running with Migrations


## Overview

BugSpotterAPI serves as the backend for the BugSpotter application. It connects to a frontend repository and facilitates the storage and management of information related to posts, comments, users, suggestions, and collections. The API is built to handle large volumes of data and perform various operations seamlessly.

## Features

- **CRUD Operations**: Full support for Create, Read, Update, and Delete operations on posts, comments, users, suggestions, and collections.
- **User Management**: Provides endpoints for user registration, updating user details, and retrieving user data.
- **Post and Comment Management**: Allows users to create, update, and delete posts and comments, with tagging and collection features.
- **Suggestions System**: Enables users to submit and manage suggestions for insect identifications.
- **Comprehensive Testing**: Easily test API endpoints using Postman and pgAdmin.

## Technologies

- **Framework**: ASP.NET Core
- **ORM**: Entity Framework Core
- **Database**: PostgreSQL
- **Testing Tools**: Postman, pgAdmin

## Setup and Configuration

### Prerequisites

- **.NET Core SDK**: Ensure you have .NET Core SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).
- **Visual Studio**: Install Visual Studio for development and debugging.
- **PostgreSQL**: Make sure PostgreSQL is installed and running.
- **Postman**: Download and install Postman for API testing.

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/GregM1992/BugSpotterBE.git
   cd BugSpotterAPI
   ```

2. **Setup the database**:
   - Ensure PostgreSQL is running.
   - Configure your database connection string in `appsettings.json`.

3. **Build the project**:
   ```bash
   dotnet build
   ```

### Configuration

- **Database Configuration**: Update `appsettings.json` with your PostgreSQL connection details.

## Usage

### API Endpoints

Below are some key endpoints. For a full list, see the detailed [API Endpoints Documentation](#api-endpoints-documentation).

#### Posts

- **Get All Posts**
  - `GET /posts`
  - Response:
    ```json
    [
      {
        "id": 1,
        "userId": 1,
        "collectionId": 1,
        "image": "url_to_image",
        "latitude": 45.0,
        "longitude": -93.0,
        "description": "Found this interesting beetle...",
        "favorite": true,
        "tags": [
          {
            "id": 1,
            "tagType": "beetle"
          }
        ]
      }
    ]
    ```

- **Create a Post**
  - `POST /posts`
  - Request Body:
    ```json
    {
      "userId": 1,
      "collectionId": 1,
      "image": "url_to_image",
      "latitude": 45.0,
      "longitude": -93.0,
      "description": "Found this interesting beetle...",
      "favorite": true
    }
    ```

- **Update a Post**
  - `PUT /posts/{post_id}`
  - Request Body:
    ```json
    {
      "collectionId": 1,
      "image": "url_to_image",
      "latitude": 45.0,
      "longitude": -93.0,
      "description": "Updated description...",
      "favorite": false
    }
    ```

- **Delete a Post**
  - `DELETE /posts/{post_id}`

#### Users

- **Get User by UID**
  - `GET /users/{uid}`
  - Response:
    ```json
    {
      "id": 1,
      "uid": "user123",
      "userName": "JohnDoe",
      "bio": "I love insects!",
      "city": "Nashville",
      "state": "TN",
      "emailAddress": "john@example.com"
    }
    ```

- **Register a User**
  - `POST /users/register`
  - Request Body:
    ```json
    {
      "uid": "user123",
      "userName": "JohnDoe",
      "bio": "I love insects!",
      "city": "Nashville",
      "state": "TN",
      "emailAddress": "john@example.com"
    }
    ```

- **Update a User**
  - `PUT /users/{id}`
  - Request Body:
    ```json
    {
      "userName": "JohnDoeUpdated",
      "bio": "Updated bio...",
      "city": "Nashville",
      "state": "TN",
      "emailAddress": "john_updated@example.com"
    }
    ```

- **Delete a User**
  - `DELETE /users/{id}`

#### Suggestions

- **Get Suggestions by Post ID**
  - `GET /suggestions/{post_id}`
  - Response:
    ```json
    [
      {
        "id": 1,
        "suggestionContent": "This might be a ladybug",
        "userId": 1,
        "postId": 1
      }
    ]
    ```

- **Create a Suggestion**
  - `POST /suggestions`
  - Request Body:
    ```json
    {
      "suggestionContent": "This might be a ladybug",
      "userId": 1,
      "postId": 1
    }
    ```

- **Update a Suggestion**
  - `PUT /suggestions/{suggestion_id}`
  - Request Body:
    ```json
    {
      "suggestionContent": "Updated suggestion content"
    }
    ```

- **Delete a Suggestion**
  - `DELETE /suggestions/{suggestion_id}`

### Testing with Postman

1. **Set Up Postman**:
   - Download and install [Postman](https://www.postman.com/downloads/).
   - Import the BugSpotterAPI collection into Postman using the provided JSON file.

2. **Configure Environment Variables**:
   - Set the `url` variable to the base URL of your API, typically `http://localhost:7125` for local development.
   - Set the `uid` variable to the user ID for testing.

3. **Explore the Endpoints**:
   - Use the pre-configured requests in the collection to interact with the API.

### API Endpoints Documentation

For detailed documentation on each endpoint, refer to the [API Endpoints](#api-endpoints) section above.

## Running Migrations

To apply database migrations, follow these steps:

1. **Add a new migration**:
   ```bash
   dotnet ef migrations add MigrationName
   ```

2. **Update the database**:
   ```bash
   dotnet ef database update
   ```

## Contribution

Contributions to BugSpotterAPI are currently not open. However, you can still fork the repository for personal use or modifications.

## License

This project is not licensed for distribution.

## Additional Information

- **Known Issues**: 
  - Ensure the database connection string is correctly configured in `appsettings.json`.

- **Troubleshooting Tips**:
  - Use Postman for testing API endpoints and checking responses.
  - Ensure you have applied all migrations and updated the database schema.

