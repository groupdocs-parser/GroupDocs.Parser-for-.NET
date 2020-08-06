---
id: evaluation-limitations-and-licensing
url: parser/net/evaluation-limitations-and-licensing
title: Evaluation Limitations and Licensing
weight: 5
description: ""
keywords: 
productName: GroupDocs.Parser for .NET
hideChildren: False
---
  
  

{{< alert style="info" >}}You can use GroupDocs.Parser without the license. The usage and functionalities are pretty much same as the licensed one but you will face few limitations while using the non-licensed API.{{< /alert >}}

## Evaluation Limitations

  
You can easily download GroupDocs.Parser for evaluation. The evaluation download is the same as the purchased download. The evaluation version simply becomes licensed when you add a few lines of code to apply the license. You will face following limitations while using the API without the license:    
  

| API | Limit |
| --- | --- |
|   | Only 100 files per session |
|   | Only 5 pages (slides, sheets) of a document |
| **Text extraction** | Only 20 lines per file<br/>Only the first 1600 symbols <br/>Only the first 5 pages (slides, sheets)<br/>\+ Evaluation marks |
| **Formatted text and text structure extraction** | Only 20 rows for **spreadsheets**<br/>Only the first 1600 symbols<br/>Only the first 5 pages (slides, sheets)<br/>\+ Evaluation marks |
| **Metadata extraction** | Only 5 properties per file |

## Licensing

The license file contains details such as the product name, number of developers it is licensed to, subscription expiry date and so on. It contains the digital signature, so don't modify the file. Even inadvertent addition of an extra line break into the file will invalidate it. You need to set a license before utilizing GroupDocs.Parser API if you want to avoid its evaluation limitations.  
The license can be loaded from a file or stream object. The easiest way to set a license is to put the license file in the same folder as the GroupDocs.Parser.dll file and specify the file name, without a path, as shown in the examples below.

#### Setting License from File

The code below will explain how to set product license.  
  

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET
// Setup license.
License license = new License();
license.SetLicense(licensePath);
```

#### Setting License from Stream

The following example shows how to load a license from a stream.  
  

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET
using (FileStream fileStream = File.OpenRead("GroupDocs.Parser.lic"))
{
    License license = new License();
    license.SetLicense(fileStream);
}
```
{{< alert style="info" >}}
Calling [License.SetLicense(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.license/setlicense/methods/1) multiple times is not harmful but simply wastes processor time. If you are developing a Windows Forms or console application, call [License.SetLicense(String)](https://apireference.groupdocs.com/net/parser/groupdocs.parser.license/setlicense/methods/1) in your startup code, before using GroupDocs.Parser classes.
{{< /alert >}}
#### Setting Metered License
{{< alert style="info" >}}
You can also set Metered license as an alternative to license file. It is a new licensing mechanism that will be used along with existing licensing method. It is useful for the customers who want to be billed based on the usage of the API features. For more details, please refer to Metered Licensing FAQ section.
{{< /alert >}}
  
Here are the simple steps to use the [Metered](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered) class.
*       Create an instance of [Metered](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered) class.
*       Pass public & private keys to [SetMeteredKey](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered/methods/setmeteredkey) method.
*       Do processing (perform task).
*       call method [GetConsumptionQuantity](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered/methods/getconsumptionquantity) of the [Metered](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered) class.
*       It will return the amount/quantity of API requests that you have consumed so far.
*       call method [GetConsumptionCredit](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered/methods/getconsumptioncredit) of the [Metered](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered) class.
*       It will return the credit that you have consumed so far.

  
Following is the sample code demonstrating how to use [Metered](https://apireference.groupdocs.com/net/parser/groupdocs.parser/metered) class.

```csharp
// For complete examples and data files, please go to https://github.com/groupdocs-parser/GroupDocs.Parser-for-.NET
string publicKey = ""; // Your public license key
string privateKey = ""; // Your private license key

Metered metered = new Metered();
metered.SetMeteredKey(publicKey, privateKey);

// Get amount (MB) consumed
decimal amountConsumed = GroupDocs.Parser.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount (MB) consumed: " + amountConsumed);

// Get count of credits consumed
decimal creditsConsumed = GroupDocs.Parser.Metered.GetConsumptionCredit();
Console.WriteLine("Credits consumed: " + creditsConsumed);
```
