#ExchangeInstantAPI
ExchangeInstantAPI is a simple WPF application built with C# and Caliburn.Micro that displays the exchange rates of USD and EURO. The application retrieves the exchange rates data via a Node.js API which runs on the local machine and returns a JSON response. The Node.js API is packaged as an executable (.exe) file using pkg and is automatically launched when the WPF application starts. The exchange rate data is updated every second and displayed in the main view using Caliburn.Micro's MVVM pattern.

#Getting Started
Prerequisites
.NET 6.0 SDK
Node.js
#Installation
Clone the repository to your local machine.
Open the solution file (ExchangeInstantAPI.sln) in Visual Studio 2022.
Build the solution.
Run the application.
Note: Executable file generates random currency values in Node.js. It is required for the application to have the final version as an executable file.
#Usage
Upon starting the application, the exchange rates for USD and EURO will be displayed in the main view. The exchange rates are updated every second and displayed in real-time.

#Known Issues
The exchange rates displayed in the application are not reflective of actual exchange rates. They are randomly generated for demonstration purposes only.
