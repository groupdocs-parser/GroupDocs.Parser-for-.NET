---
id: how-to-run-examples
url: parser/net/how-to-run-examples
title: How to Run Examples
weight: 6
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
{{< alert style="warning" >}}Before running an example make sure that GroupDocs.Parser has been installed successfully.{{< /alert >}}

We offer multiple solutions on how you can run GroupDocs.Parser examples, by building your own or using our examples out-of-the-box.

Please choose one from the following list:


## Build project from scratch

*   Open Visual Studio and go to **File** -> **New** \-> **Project**;
*   Select appropriate project type - Console App, ASP.NET Web Application etc;
*   Install **GroupDocs.Parser for .NET **from Nuget or official GroupDocs website following this [guide]({{< ref "parser/net/getting-started/installation.md" >}});
*   Code your first application with **GroupDocs.Parser for .NET** like this:
    
    ```csharp
    // Create an instance of Parser class
    using (Parser parser = new Parser("c:\\documents\\sample.docx")) // NOTE: Put here actual path for your document
    {
        // Extract a text to the reader
        using (TextReader reader = parser.GetText())
        {
            // Print an extracted text (or "not supported" message)
            Console.WriteLine(reader == null ? "Text extraction isn't supported" : reader.ReadToEnd());
        }
    }
    ```
    

*   Build and Run your project;
*   Extracted text will appear on the console.

## Run examples

The complete examples package of **GroupDocs.Parser** is hosted on [GitHub](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET/). You can either download the ZIP file from [here](https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET/archive/master.zip) or clone the repository of GitHub using your favorite git client.  
In case you download the ZIP file, extract the folders on your local disk. The extracted files and folders will look like following image:

![](parser/net/images/how-to-run-examples.png)

In extracted files and folders, you can find CSharp solution file. The project is created in **Microsoft Visual Studio 2019**. The **Resources **folder contains all the sample document and image files used in the examples.  
To run the examples, open the solution file in Visual Studio and build the project. To add missing references of **GroupDocs.Parser** see [Development Environment, Installation and Configuration]({{< ref "parser/net/getting-started/installation.md" >}}). All the functions are called from **RunExamples.cs**.
Un-comment the function you want to run and comment the rest.

![](parser/net/images/how-to-run-examples_1.png)
