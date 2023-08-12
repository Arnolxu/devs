# Artado Developers

Welcome to the **Artado Developers** GitHub repository! This repository hosts the source code for the Artado Developers website, a platform that empowers developers to publish their apps, games, themes, extensions, and icons for the Artado Store and Artado Search. Whether you're a developer looking to showcase your creations or a user searching for exciting new content, Artado Developers is the place to be.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The **Artado Developers** website serves as a hub for developers who want to contribute their apps, games, themes, extensions, or icons to the Artado Store and Artado Search ecosystem. This platform provides a seamless and user-friendly experience for both developers and users to connect and share creative content.

## Features

- **App and Game Publishing:** Developers can easily publish their applications and games to the Artado Store, making them accessible to a wide user base.

- **Theme, Extension, and Icon Publishing:** Artado Developers enables creators to showcase and distribute themes, extensions, and icons for the Artado Search platform, enhancing user customization.

- **Collaborative Environment:** Developers can collaborate on projects, share ideas, and engage with the Artado community to create a thriving ecosystem.

- **User-friendly Dashboard:** The platform offers an intuitive dashboard that simplifies the publishing process and provides insights into app usage and engagement.

## Getting Started

Follow these steps to set up the Artado Developers website on your local machine.

### Prerequisites

- [ASP.NET](https://dotnet.microsoft.com/apps/aspnet)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/Artado-Project/dev.git
   cd devs
   ```

2. Restore .NET and Node.js dependencies:

   ```bash
   dotnet restore
   cd devs/ArtadoDevs
   ```

3. Configure the database connection in `web.config`:
Copy the Web.example.config to Web.config and fill in the database parameters.
   ```xml
   <connectionStrings>
	  <add name="con" connectionString="" />
	  <add name="admin" connectionString="" />
	  <add name="service" connectionString="" />
   </connectionStrings>
   ```

4. Apply migrations to create the database schema:

   ```bash
   dotnet ef database update
   ```

5. Build and run the application:

   ```bash
   dotnet run
   ```

6. Access the website through your browser at `http://localhost:44394`.

## Usage

1. Register as a developer on the Artado Developers website.
2. Log in and explore the dashboard to manage your projects.
3. Upload your apps, games, themes, extensions, or icons.
4. Engage with the community, gather feedback, and refine your creations.
5. Published content will be available on the Artado Store and Artado Search platforms.

## Contributing

Contributions to the Artado Developers website are welcome! If you want to contribute, please follow the [contribution guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [GNU Affero General Public License v3.0](LICENSE). You are free to use, modify, and distribute the code in compliance with the terms of the license.

---

We appreciate your interest in Artado Developers. Together, we can shape an engaging platform for developers and users to connect and share their creative contributions. If you have any questions or feedback, feel free to [contact us](mailto:support@artadosearch.com).
