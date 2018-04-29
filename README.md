# How to build an online collaborative text editor using .NET and Pusher

This is a demo application showing how to build a realtime collaborative text editor using ASP.NET Core MVC and Pusher. You can read the tutorial on how it was built [here](https://pusher.com)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

This tutorial uses the following:

* JavaScript (jQuery) 
* ASP.NET Core MVC
* Visual Studio Code 
* .NET Core SDK (Download and install it [here](https://www.microsoft.com/net/download/core))
* Visual Studio Code C# extension (You can install it [here](https://code.visualstudio.com/))
* A Pusher account. You can get it [here](https://pusher.com/) if you don't have one already

### Setup

First of all, clone the repository to your local machine:
```sh
 $ git clone https://github.com/dongido001/CollaText.git
```

Next, cd into the project and open it with Visual Studio Code editor:

```sh
 $ cd CollaText
 $ code .
```

Next, from your Visual Studio Code, click on `Startup.cs` file.

Then,

- Select **Yes** to the Warn message "Required assets to build and debug are missing from 'CollaText'. Add them?"
- Select **Restore** to the Info message "There are unresolved dependencies".

Build and run the project by pressing Debug (F5).

Finally, Visit http://localhost:5000/Pen to see the project in action.

## Built With

* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/) - A cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.
* [Pusher](https://pusher.com/) - APIs to enable devs building realtime features

## Acknowledgments

ASP.NET Core team for their amazing guide on how to use the framework.