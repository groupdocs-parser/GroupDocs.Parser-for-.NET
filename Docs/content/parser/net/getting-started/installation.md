---
id: installation
url: parser/net/installation
title: Installation
weight: 4
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
## Install from Nuget

NuGet is the easiest way to download and install GroupDocs.Parser for .NET. There are ways to install it in your project.

#### Install via Package Manager GUI

Follow these steps to reference GroupDocs.Parser using Package Manager GUI:

*   Open your solution/project in Visual Studio.
*   Click Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution.  
    You can also access the same option through the Solution Explorer. Right-click the solution or project and select Manage NuGet Packages from the context menu
*   Select Browse tab and type "GroupDocs.Parser" in the search text box.
*   Click the Install button to install the latest version of the API into your project as shown in the following screenshot.

![](parser/net/images/installation.png)

#### Using Package Manager Console

You can follow the steps below to reference GroupDocs.Parser for .NET using the Package Manager Console:

*   Open your solution/project in Visual Studio.
*   Select Tools -> NuGet Package Manager -> Package Manager Console from the menu to open package manager console.
*   Type the command "Install-Package GroupDocs.Parser" and press enter to install the latest release into your application.
*   After successful installation, GroupDocs.Parser will be referenced in your application.

![](parser/net/images/installation_1.png)

![](parser/net/images/installation_2.png)

## Install from official GroupDocs website

You can follow the steps below to reference GroupDocs.Parser for .NET downloaded from official website Downloads section:

*   Unpack zip archive or follow MSI install wizard instructions.
*   In the Solution Explorer, expand the project node you want to add a reference to.
*   Right-click the References node for the project and select Add Reference from the menu.
*   In the Add Reference dialog box, select the .NET tab (it's usually selected by default).
*   If you have used MSI installer to install GroupDocs.Parser, you will see GroupDocs.Parser in the top pane. Select it and then click the Select button.
*   If you have downloaded and unpacked the DLL only, click the Browse button and locate the GroupDocs.Parser.dll file.
*   You have referenced GroupDocs.Parser and it should appear in the SelectedComponents pane of the dialog box.
*   Click OK.

GroupDocs.Parser reference appears under the References node of the project.

Note that .NET Standard 2.0 version has external references:

| Package | Version |
| --- | --- |
| System.Drawing.Common                  | 4.7.0  |
| System.Text.Encoding.CodePages         | 4.7.0  |
| System.Reflection.Emit                 | 4.7.0  |
| System.Reflection.Emit.ILGeneration    | 4.7.0  |
| System.Diagnostics.PerformanceCounter  | 4.5.0  |
| System.Security.Cryptography.Pkcs      | 4.7.0  |
| System.Security.Permissions            | 4.5.0  |
| Microsoft.Win32.Registry               | 4.7.0  |
| Microsoft.Extensions.DependencyModel   | 2.0.4  |
| SkiaSharp                              | 2.80.1 |

## Linux environment

For correct working of GroupDocs.Parser.Net on Linux the following packages need to be installed:

* libgdiplus package
* libc6-dev package
* package with Microsoft compatible fonts: ttf-mscorefonts-installer. (e.g. sudo apt-get install ttf-mscorefonts-installer)

Also GroupDocs.Parser.Net in Linux environment has external reference:

| Package | Version |
| --- | --- |
| SkiaSharp.NativeAssets.Linux.NoDependencies | 2.80.2 |