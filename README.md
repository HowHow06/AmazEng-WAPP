# AmazEng-WAPP

## Overview

AmazEng-WAPP is a comprehensive web application developed using ASP.NET Web Forms, designed to showcase a unique collection of 1146 idioms. This project is part of my portfolio to demonstrate my capabilities in web development, data crawling, ETL (Extract, Transform, Load) processes, and working with ASP.NET technologies.

The idioms presented in this application have been meticulously gathered through web crawling techniques, followed by an extensive ETL process to ensure the data's uniqueness and relevance. AmazEng-WAPP offers an interactive and user-friendly platform for users to explore idioms in an engaging manner.

## Features

- **Idiom Exploration:** Browse through a collection of 1146 unique idioms, each with detailed explanations and usage examples.
- **Search Functionality:** Easily search for idioms using keywords, allowing users to find specific idioms of interest.
- **ETL Process:** Learn about the behind-the-scenes ETL process that was employed to curate and refine the idiom dataset.
- **Responsive Design:** Enjoy a seamless experience across various devices thanks to the responsive web design.

## Getting Started

To run AmazEng-WAPP on your local environment, follow these steps:

### Prerequisites

- Microsoft Visual Studio with ASP.NET and web development workload installed.
- .NET Framework (version as specified in the project).
- SQL Server (if the application utilizes a database).

### Setup

1. **Clone the repository** to your local machine:

2. **Open the `AmazEng-WAPP.sln` solution file** in Visual Studio.

3. **Restore NuGet packages** to ensure that all dependencies are correctly installed. Right-click on the solution in Solution Explorer and select "Restore NuGet Packages".

4. **Set up the database** using Entity Framework migrations. Open the Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console) and run the following command to apply the migrations to your database:

   ```bash
   Update-Database
   ```

   This step assumes that you have already configured Entity Framework in your project and defined the necessary DbContext and migration files. If your database connection string needs to be specified or modified, you can usually find and adjust it in the `Web.config` file under the `<connectionStrings>` section.

5. **Start the application** by pressing F5 or clicking the "Start" button in Visual Studio. This will build the project and launch the web application in your default web browser, allowing you to interact with AmazEng-WAPP locally.

## Contributing

Contributions to AmazEng-WAPP are welcome! Whether it's reporting bugs, suggesting new features, or contributing to the code, your input is valuable. Please feel free to fork the repository and submit pull requests, or open issues to discuss potential changes.
