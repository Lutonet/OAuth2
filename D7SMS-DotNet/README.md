# Getting started

D7 SMS allows you to reach your customers via SMS over D7's own connectivity to global mobile networks. D7 provides reliable and cost-effective SMS services to businesses across all industries and aims to connect all countries and territories via direct connections.

## How to Build

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore
is enabled, these dependencies will be installed automatically. Therefore,
you will need internet access for build.

"This library requires Visual Studio 2017 for compilation."
1. Open the solution (D7SMS.sln) file.
2. Invoke the build process using `Ctrl+Shift+B` shortcut key or using the `Build` menu as shown below.

![Building SDK using Visual Studio](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/cs_1.svg)

## How to Use

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8,
Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the [MSDN Portable Class Libraries documentation](http://msdn.microsoft.com/en-us/library/vstudio/gg597391%28v=vs.100%29.aspx).

The following section explains how to use the D7SMS library in a new console project.

### 1. Starting a new project

For starting a new project, right click on the current solution from the *solution explorer* and choose  ``` Add -> New Project ```.

![Add a new project in the existing solution using Visual Studio](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/cs_2.svg)

Next, choose "Console Application", provide a ``` TestConsoleProject ``` as the project name and click ``` OK ```.

![Create a new console project using Visual Studio](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/cs_3.svg)

### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the ``` TestConsoleProject ``` as the start-up project. To do this, right-click on the  ``` TestConsoleProject ``` and choose  ``` Set as StartUp Project ``` form the context menu.

![Set the new cosole project as the start up project](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/cs_4.svg)

### 3. Add reference of the library project

In order to use the D7SMS library in the new project, first we must add a projet reference to the ``` TestConsoleProject ```. First, right click on the ``` References ``` node in the *solution explorer* and click ``` Add Reference... ```.

![Open references of the TestConsoleProject](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/cs_5.svg)

Next, a window will be displayed where we must set the ``` checkbox ``` on ``` D7SMS.Tests ``` and click ``` OK ```. By doing this, we have added a reference of the ```D7SMS.Tests``` project into the new ``` TestConsoleProject ```.

![Add a reference to the TestConsoleProject](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/cs_6.svg)

### 4. Write sample code

Once the ``` TestConsoleProject ``` is created, a file named ``` Program.cs ``` will be visible in the *solution explorer* with an empty ``` Main ``` method. This is the entry point for the execution of the entire solution.
Here, you can add code to initialize the client library and acquire the instance of a *Controller* class. Sample code to initialize the client library and using controller methods is given in the subsequent sections.

![Add a reference to the TestConsoleProject](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/cs_7.svg)

## How to Test

The generated SDK also contain one or more Tests, which are contained in the Tests project.
In order to invoke these test cases, you will need *NUnit 3.0 Test Adapter Extension for Visual Studio*.
Once the SDK is complied, the test cases should appear in the Test Explorer window.
Here, you can click *Run All* to execute these test cases.

## Initialization

### Authentication
In order to setup authentication and initialization of the API client, you need the following information.

| Parameter | Description |
|-----------|-------------|
| aPIUsername | API Key |
| aPIPassword | API Token |



API client can be initialized as following.

```csharp
// Configuration parameters and credentials
string aPIUsername = "aPIUsername"; // API Key
string aPIPassword = "aPIPassword"; // API Token

D7SMSClient client = new D7SMSClient(aPIUsername, aPIPassword);
```



# Class Reference

## <a name="list_of_controllers"></a>List of Controllers

* [APIController](#api_controller)

## <a name="api_controller"></a>![Class: ](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/class.png "D7SMS.Tests.Controllers.APIController") APIController

### Get singleton instance

The singleton instance of the ``` APIController ``` class can be accessed from the API Client.

```csharp
APIController client = client.Client;
```

### <a name="get_balance"></a>![Method: ](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/method.png "D7SMS.Tests.Controllers.APIController.GetBalance") GetBalance

> Check account balance


```csharp
Task GetBalance()
```

#### Example Usage

```csharp

await client.GetBalance();

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 500 | Internal Server Error |


### <a name="create_send_sms"></a>![Method: ](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/method.png "D7SMS.Tests.Controllers.APIController.CreateSendSMS") CreateSendSMS

> Send SMS  to recipients using D7 SMS Gateway


```csharp
Task CreateSendSMS(Standard.Models.CreateSendSMSInput input)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | Message Body |
| contentType |  ``` Required ```  | TODO: Add a parameter description |
| accept |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
CreateSendSMSInput collect = new CreateSendSMSInput();

var body = new Standard.Models.SendSMSRequest();
collect.Body = body;

string contentType = "Content-Type";
collect.ContentType = contentType;

string accept = "Accept";
collect.Accept = accept;


await client.CreateSendSMS(collect);

```

#### Errors

| Error Code | Error Description |
|------------|-------------------|
| 500 | Internal Server Error |


### <a name="create_bulk_sms"></a>![Method: ](https://github.com/d7networks/D7SMS-SDKs/blob/master/D7SMS-DotNet/images/method.png "D7SMS.Tests.Controllers.APIController.CreateBulkSMS") CreateBulkSMS

> Send Bulk SMS  to multiple recipients using D7 SMS Gateway


```csharp
Task CreateBulkSMS(Standard.Models.BulkSMSRequest body, string contentType, string accept)
```

#### Parameters

| Parameter | Tags | Description |
|-----------|------|-------------|
| body |  ``` Required ```  | Message Body |
| contentType |  ``` Required ```  | TODO: Add a parameter description |
| accept |  ``` Required ```  | TODO: Add a parameter description |


#### Example Usage

```csharp
string bodyValue = "{  \"messages\": [    {      \"to\": [        \"971562316353\",        \"971562316354\",        \"971562316355\"      ],      \"content\": \"Same content goes to three numbers\",      \"from\": \"SignSMS\"    }  ]}";
var body = Newtonsoft.Json.JsonConvert.DeserializeObject<Standard.Models.BulkSMSRequest>(bodyValue);
string contentType = "application/json";
string accept = "application/json";

await client.CreateBulkSMS(body, contentType, accept);

```


[Back to List of Controllers](#list_of_controllers)



