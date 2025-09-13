# GitHub Profile README Generator

![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)
![.NET Version](https://img.shields.io/badge/.NET-8.0-purple.svg)
![Technology](https://img.shields.io/badge/Technology-WPF-blueviolet.svg)

A modern and intuitive desktop application built with C# and WPF to help developers create beautiful and professional GitHub profile READMEs with ease.

This project was developed as a professional portfolio piece to demonstrate best practices in modern desktop development with a clean, maintainable architecture.

![App Screenshot](https://raw.githubusercontent.com/aboutbehnam/GitHubProfileReadmeGenerator/main/app-screenshot.png)

---

## ✒️ About The Project

The idea for this tool originated from a personal need: the process of creating and updating a GitHub profile README is often repetitive and time-consuming. This application automates and simplifies the entire process by providing a user-friendly graphical interface with a real-time preview.

The primary goal of this project is to showcase a strong understanding of:
*   Clean, scalable, and maintainable architecture (MVVM)
*   Modern UI development with WPF
*   Professional coding standards and documentation

## ✨ Key Features

- **Live Preview:** Instantly see your generated README update as you type.
- **Modular Architecture:** The project is structured to be easily extensible.
- **Full Customization:** Add and edit all the essential sections of a professional README.
- **Multiple Themes:** Includes Dark, Light, and Colorful themes to match user preferences.
- **Appearance Control:** Adjust the preview's font size for better accessibility and comfort.

## 🛠️ Technology & Architecture

This project is built using the latest version of the .NET platform with a strong focus on software engineering principles.

- **C# & .NET 8:** The core language and framework.
- **WPF (Windows Presentation Foundation):** Used to build the modern and responsive user interface.
- **MVVM Design Pattern (Model-View-ViewModel):** The architectural backbone of the application. This pattern ensures a strict separation of concerns, decoupling the business logic from the UI.

### Project Structure

The project is organized into a clean, logical structure to maximize readability and maintainability:

```
GitHubProfileReadmeGenerator/
│
├── Core/
│   └── Utils/
│       └── RelayCommand.cs       # Standard ICommand implementation
│
├── Models/
│   ├── Profile.cs                # The main data model for the user's profile
│   └── SocialLink.cs             # Data model for social links and skills
│
├── Properties/
│   └── AssemblyInfo.cs           # Assembly metadata for the project
│
├── Resources/
│   └── Styles/
│       ├── Dark.xaml             # Resource dictionary for the Dark theme
│       ├── Light.xaml            # Resource dictionary for the Light theme
│       └── Colorful.xaml         # Resource dictionary for the Colorful theme
│
├── ViewModels/
│   ├── BaseViewModel.cs          # Base class implementing INotifyPropertyChanged
│   └── MainViewModel.cs          # The application's brain; handles all logic
│
├── Views/
│   └── MainWindow.xaml           # The main application window and UI definition
│
├── .gitignore                    # Specifies files for Git to ignore
├── App.xaml                      # Application entry point and global resources
├── LICENSE                       # The MIT License file
└── README.md                     # This file!
```

## ⚙️ Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

- **[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**
- **Visual Studio 2022** (with the `.NET desktop development` workload installed)

### Compilation Steps

1.  Clone the repository:
    ```sh
    git clone https://github.com/aboutbehnam/GitHubProfileReadmeGenerator.git
    ```

2.  Open the solution file (`.sln`) in Visual Studio.

3.  Build the solution by pressing `Ctrl+Shift+B`. This will automatically restore all required NuGet packages.

4.  Run the application by pressing `F5`.

## 💡 Extensibility

The MVVM architecture makes adding new features incredibly straightforward. For example:

- **To add a new input field (e.g., "My Top Projects"):**
    1.  Add a new property to the `Profile.cs` model.
    2.  Add a new input control (e.g., a `TextBox`) to `MainWindow.xaml` and bind it to the new property.
    3.  Update the `GenerateReadme` method in `MainViewModel.cs` to use the new property's value when generating the Markdown.

- **To add a new theme:**
    1.  Create a new `ResourceDictionary` file in the `/Resources/Styles/` folder.
    2.  Add a new value to the `AppTheme` enum in `App.xaml.cs`.
    3.  Add a new `RadioButton` in `MainWindow.xaml` to allow the user to select the new theme.

## 📞 Contact & Professional Inquiries

- **Email:** `Behnam.panahi.dev@gmail.com`
- **GitHub Profile:** [github.com/aboutbehnam](https://github.com/aboutbehnam)

I am currently available for freelance projects and custom software development opportunities. If you have an idea you'd like to turn into a product, feel free to reach out via email.

## 📄 License

This project is distributed under the MIT License. See the `LICENSE` file for more information.