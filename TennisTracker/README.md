🎾 Tennis Tracker

Project Overview:
Tennis Tracker is a simple cross-platform desktop application built with Avalonia (.NET) that allows users to log their tennis matches, track performance, and take quick notes after each game.
It was designed to provide an easy way for players to record scores and opponents locally, with potential for future expansion.

Features:

Add new matches with opponent name, score, and notes

Automatically display all stored matches in a clean list view

Data persistence through local JSON storage

Cross-platform compatibility (macOS, Windows, Linux)

Lightweight and fast to open

File Structure:
TennisTracker/
├── Controllers/
│ └── MatchController.cs
├── Models/
│ └── MatchItem.cs
├── Views/
│ ├── MainWindow.axaml
│ └── MainWindow.axaml.cs
├── App.axaml
├── App.axaml.cs
├── Program.cs
└── README.md

Installation Instructions:

Clone the repository
git clone https://github.com/GenaroDagotto/todolistnuevo.git

Navigate to the project directory
cd Todolistaplicacion/TennisTracker

Build the project
dotnet build

Run the project
dotnet run

How Data is Stored:
All matches are stored locally in a JSON file located at:
/Users/<username>/Documents/TennisTracker/matches.json

Each entry includes:
{
"Opponent": "John Doe",
"Score": "6-3, 7-5",
"Notes": "Great backhand performance today."
}

Known Issues / Limitations:

The app only stores match data locally on the user’s device.

Editing or deleting matches is not yet supported.

The app does not synchronize data across devices.

On macOS, the app must be opened through the .app bundle inside the release folder; direct execution from Finder may require adjusting permissions.

Debugging Summary:

Fixed multiple build errors related to Avalonia’s read-only ItemsControl.Items property by using an ObservableCollection.

Solved missing references between XAML and code-behind elements by ensuring consistent naming.

Resolved packaging issues on macOS by manually bundling the app since Xcode couldn’t be installed.

Credits and Acknowledgements:
Created by Genaro Dagotto for Software Engineering I at Newman University (Fall 2025).
Thanks to AvaloniaUI and the .NET community for tools and documentation.

Release:
The latest macOS release (.app installer) is available on GitHub:
https://github.com/GenaroDagotto/todolistnuevo/releases