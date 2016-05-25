# GoogleRecaptcha
The GoogleRecaptcha is a .NET library used to integrate the Google Captcha into the web applications based upon the asp.net platform.
![GoogleRecaptcha Class Diagram](http://i.imgur.com/MPPotOo.png "GoogleRecaptcha Class Diagram")

### Install and Requirements
In order to use this library, your application needs to meet these following criterias:
* Use for the web applications.
* Require the .NET Framework 4.0 or higher.

If okay, then you can install it directly via following ways:
* Via Nuget: ``` Install-Package GoogleRecaptcha ```
* Via Github: ``` git clone https://github.com/congdongdotnet/GoogleRecaptcha.git ```

In order to use for asp.net mvc, you need to install more a helper package. This package contains these helpers to create a html control for asp.net mvc:

``` Install-Package GoogleRecaptchaMvc ```

In order to use for asp.net web forms, you need to install more a package. This package is used to create the server control for Google Recaptcha:

``` Install-Package GoogleRecaptchaWebForms ```

### Samples
#### ASP.NET MVC
We will have a minor sample for asp.net mvc. In this sample, we have a view called __Index.cshtml__ and a controller named __HomeController__. In __index__ view, we will render the html control with the Google reCaptcha version 2 format. Also, HomeController will have 2 actions inside it. The first action is to implement the GET request. The second action is to implement the POST request used to verify the Google Recaptcha. The following is the sample code:

__Index.cshtml__:
```c#
@using GoogleRecaptchaMvc // You can put this as the global namespace in Web.config

// ...
// Create the html control for Google Recaptcha version 2.
@Html.RecaptchaV2("[YOUR_SITE_KEY]")
// ...
```

__HomeController.cs__:
```c#
public class HomeController: Controller
{
    public ActionResult Index()
    {
        //TODO: write code here
        return View();
    }
    
    [HttpPost]
    public ActionResult Index(FormCollection form)
    {
        // Init the recaptcha processor to start verifying...
        IRecaptcha<RecaptchaV2Result> recaptcha = new RecaptchaV2(
          new RecaptchaV2Data() { Secret = "[YOUR_SECRET_KEY]" });
        
        // Verify the captcha
        var result = recaptcha.Verify();
        if (result.Success) // Success!!!
        {
        	//TODO: write code here
        }
        
        return View();
    }
}
```

#### ASP.NET Web Forms
For asp.net web forms, after you have installed the library, you have two ways to use it:
* Refer to it in web.config:
```xml
...
    <system.web>
    
        <pages>
          <controls>
            <add tagPrefix="asp" assembly="GoogleRecaptchaWebForms"/>
          </controls>
        </pages>

  </system.web>
...
```
* Refer to it in each pages aspx or user controls ascx:
```xml
<%@ Register TagPrefix="asp" Namespace="GoogleRecaptchaWebForms"
    Assembly="GoogleRecaptchaWebForms" %>
```

Next you can use server control of Google Recaptcha for any page or user control with following syntax:
```xml
...
    <asp:RecaptchaV2Control ID="gRecaptcha" SiteKey="[YOUR_SITE_KEY]"
        SecretKey="[YOUR_SECRET_KEY]" runat="server"/>
...
    <script src='https://www.google.com/recaptcha/api.js'></script>
```

Please make note that the google recaptcha library must be included inside the *head* tag or the *body* tag.

Finally on the server-side, you can verify the captcha by using __Page.IsValid__ or __gRecaptcha.IsValid__. The success is __true__, otherwise is __false__

### Bugs and Issues
If any issue or bug, please push a new issue [here](https://github.com/congdongdotnet/GoogleRecaptcha/issues).

### Release Notes
* 1.2.1: Enable to set the custom values for 2 properties(Response and RemoteIp) in RecaptchaV2Data class.
* 1.1.1: Support the Google Recaptcha version 2 for asp.net web forms.
* 1.0.1: Add the meaningful comments into code and fix some following performance bugs:
    * Dispose and close the unnecessary resources when using MemoryStream.
    * Use the HtmlHelper class in the namespace System.Web.Mvc instead of System.Web.WebPages.Html.
* 1.0.0: The first version supports only for Google reCaptcha version 2 and asp.net mvc 4(or higher).

### Copyright and License
Copyright 2015 by CongDongDotNet - MIT License
