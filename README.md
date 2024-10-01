# YourPet Application

YourPet is a web application for pet owners, allowing them to manage their pets' profiles. The application enables users to add, edit, and view their pets' information. It also provides user authentication through Auth0, supporting both login/password and social login options like Google.

## Authorization Workflow

### Authentication and Authorization

The application uses **OAuth 2.0** and **OpenID Connect** via [Auth0](https://auth0.com/) for user authentication. Auth0 manages all credentials (such as username/password or Google login), while the application stores only the `Auth0Id` to identify users in the backend.

### Workflow Diagram

1. **Web -> Auth0 -> Web -> API**:
   - The user initiates the authentication process in the frontend.
   - Auth0 handles the login (via username/password or Google OAuth) and returns an access token (JWT) to the frontend.
   - The frontend then uses this token to authenticate subsequent requests to the API.

2. **API -> Database**:
   - The API verifies the token received from the frontend, extracts the `Auth0Id`, and uses this identifier to manage user-specific data, such as pets.

### Diagram
+---------+             +--------+             +---------+
|  Client |  ----->     | Auth0  |             |   API   |
|  (Web)  |             |        |             |         |
+---------+             +--------+             +---------+
     |                    |                        |
     | <------ Access Token (JWT) -----------------|
     |                    |                        |
     |                    v                        |
     |             User authenticated              |
     |                    |                        |
     | ---- Authenticated requests (with JWT) ---->|
     |                                             |
     |                                             v
     |                                       Validates JWT
     |                                             |
     |                                             v
     |                                      Database Lookup
     v                                      (using Auth0Id)
User interacts                           API responds with
with Web                                user-specific data

 

## Getting Started

Follow these steps to set up and run the application locally.

### Prerequisites

1. **Node.js and npm**: Install Node.js and npm from [here](https://nodejs.org/).
2. **.NET SDK**: Install the .NET SDK from [here](https://dotnet.microsoft.com/download).
3. **Auth0 Account**: You will need an [Auth0](https://auth0.com/) account and an application configured with the following:
   - `Client ID`
   - `Domain`
   - `Audience`

### Installation

1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/yourpet.git
   cd yourpet