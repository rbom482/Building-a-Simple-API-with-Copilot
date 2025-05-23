# User Management API

This project is a simple ASP.NET Core Web API for managing users. It provides endpoints to create, read, update, and delete user information.

## Project Structure

- **Controllers/**: Contains the API controllers that handle HTTP requests.
  - `UsersController.cs`: Manages user-related operations.
  
- **Models/**: Contains the data models used in the application.
  - `User.cs`: Defines the user properties.

- **Program.cs**: The entry point of the application, setting up the web host and configuring services.

- **Startup.cs**: Configures application services and the request pipeline.

- **UserManagementAPI.csproj**: The project file that defines dependencies and settings.

## Getting Started

### Prerequisites

- .NET SDK (version 6.0 or later)

### Installation

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```
   cd UserManagementAPI
   ```

3. Restore the dependencies:
   ```
   dotnet restore
   ```

### Running the API

To run the API, use the following command:
```
dotnet run
```

The API will be available at `http://localhost:5000`.

### API Endpoints

- `GET /api/users`: Retrieve all users.
- `GET /api/users/{id}`: Retrieve a user by ID.
- `POST /api/users`: Create a new user.
- `PUT /api/users/{id}`: Update an existing user.
- `DELETE /api/users/{id}`: Delete a user.

## Contributing

Feel free to submit issues or pull requests for improvements or bug fixes.#   B u i l d i n g - a - S i m p l e - A P I - w i t h - C o p i l o t  
 #   B u i l d i n g - a - S i m p l e - A P I - w i t h - C o p i l o t  
 