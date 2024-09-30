# Health&Med Doctor Service - Hackathon Project

## Overview

This project is part of the Health&Med Hackathon, designed to manage doctor registration, authentication, and availability management. The Doctor Service is built in .NET Core and enables doctors to register, authenticate, and manage their consultation availability.

### Main Objective
To provide an API where doctors can register, authenticate, and manage their availability for consultations, ensuring smooth integration with the scheduling service.

### Key Features
- Doctor registration with required fields
- Doctor authentication using JWT
- Manage consultation availability (add/edit available slots)

## Functional Requirements
1. **Doctor Registration**
   - Doctors can sign up by providing the following required fields: Name, CPF, CRM number, Email, and Password.
   
2. **Doctor Authentication**
   - Doctors can log in using their Email and Password, with authentication managed via JWT tokens.

3. **Availability Management**
   - Doctors can manage their available consultation slots by adding or editing time slots through the API.

## Non-Functional Requirements
1. **Security**
   - All authentication is handled securely using JWT tokens.
   
2. **Data Validation**
   - Input validation ensures that all required fields (Name, CPF, CRM number, Email, Password) are correctly formatted and complete.

## Tech Stack
- **.NET Core** for backend service
- **RabbitMQ** for sending notifications
- **PostgreSQL** for database management
- **Docker** for containerization and deployment
- **Entity Framework Core** for data access
- **FluentValidation** for input validation
- **MediatR** for managing requests and command/query separation
- **JWT** for secure authentication

## Features

### 1. Doctor Registration
The API allows doctors to register by providing their basic details (Name, CPF, CRM, Email, Password). Data is securely stored in PostgreSQL.

### 2. Doctor Authentication
Doctors can log in using their Email and Password. JWT tokens are used to secure subsequent requests.

### 3. Manage Availability
Doctors can add and edit time slots for consultations. These time slots will be used by the scheduling system to determine availability.

### 4. RabbitMQ Integration
Once a doctor registers or updates their availability, notifications are sent through RabbitMQ to synchronize other services.

## Setup & Installation

### Prerequisites
- .NET 6 SDK
- Docker & Docker Compose
- RabbitMQ
- PostgreSQL

### Steps to Run

1. **Clone the repository:**
   ```bash
   git clone https://github.com/hackathon-POSTECH/Doctor.git
   ```

2. **Set up environment variables:**
   Create a `.env` file based on the provided `.env.example` file, and configure the RabbitMQ and PostgreSQL settings.

3. **Run the application using Docker Compose:**
   ```bash
   docker-compose up --build
   ```

4. **Database migration:**
   After the containers are up, run the database migrations:
   ```bash
   dotnet ef database update
   ```

5. **Access the API:**
   The API will be accessible at `http://localhost:5000`.

## CI/CD Pipeline
The service is integrated with a CI/CD pipeline to automate testing, building, and deployment using tools like GitHub Actions.

## Testing
Unit tests cover key functionalities like registration, authentication, and availability management.

Run the tests:
```bash
dotnet test
```

## Contributors
- Health&Med Hackathon Team (FIAP SOAT students)

## License
This project is licensed under the MIT License.
