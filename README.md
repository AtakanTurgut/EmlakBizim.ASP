# Real estate website application (EmlakBizim) with ASP.NET MVC5

## EmlakBizim Api Addresses

If we want to start the project with [Microsoft Visual Studio](https://visualstudio.microsoft.com/), we start the project by right-clicking on the "[\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/emlakbizim/blob/master/emlakBizim/Views/Home/Index.cshtml)" file while the project is open and selecting "View in Browser ([Selected Browser](https://www.google.com.tr/))".

If we want, we can also use "\Index.cshtml" of other "[\Views](https://github.com/AtakanTurgut/emlakbizim/tree/master/emlakBizim/Views)" files to see how other pages look.

However, it's best to start the project with "[\Views\Home\Index.cshtml](https://github.com/AtakanTurgut/emlakbizim/blob/master/emlakBizim/Views/Home/Index.cshtml)" to run it properly.

The application also has an admin panel. Admin can perform operations such as adding, deleting, updating, seeing all places.

Use this user name and password for the admin page.

                UserName : atakanturgut
                Password : 123456

The project runs on "[localhost:?/](https://localhost:44330/)".

## Used Packages

- Some packages can be installed from the "[NuGet Gallery](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)" with the help of the "Tools > NuGet Package Manager > Package Manager Console".

- [EntityFramework 6.4.4](https://www.nuget.org/packages/EntityFramework/)
```
    PM>  NuGet\Install-Package EntityFramework -Version 6.4.4
```
- [Microsoft.AspNet.Identity.Core 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Core)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.Core -Version 2.2.3
```
- [Microsoft.AspNet.Identity.Owin 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.Owin/)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.Owin -Version 2.2.3
```
- [Microsoft.AspNet.Identity.EntityFramework 2.2.3](https://www.nuget.org/packages/Microsoft.AspNet.Identity.EntityFramework/)
```
    PM>  NuGet\Install-Package Microsoft.AspNet.Identity.EntityFramework -Version 2.2.3
```
- [Microsoft.Owin.Host.SystemWeb 4.2.2](https://www.nuget.org/packages/Microsoft.Owin.Host.SystemWeb)
```
    PM>  NuGet\Install-Package Microsoft.Owin.Host.SystemWeb -Version 4.2.2
```

----
## EmlakBizim Project [Images](https://github.com/AtakanTurgut/emlakbizim/tree/master/pictures)

### 1. Home Page:  https://localhost:44330/Home/Index
![](/pictures/HomePage1.PNG)
![](/pictures/HomePage2.PNG)

### 2. Register Page:  https://localhost:44330/Account/Register
![](/pictures/RegisterPage.PNG)

### 3. Login Page:  https://localhost:44330/Account/Login
![](/pictures/LoginPage.PNG)

### 4. Admin Page:  https://localhost:44330/Admin/Index
![](/pictures/AdminPage.PNG)

### 5. Advert Create Page:  https://localhost:44330/Ilan/Create
![](/pictures/AdvertCreatePage.PNG)

### 6. Profile Page:  https://localhost:44330/Account/Profil
![](/pictures/ProfilePage.PNG)

### 7. User Advert List:  https://localhost:44330/Ilan/Index
![](/pictures/AdvertListPage.PNG)

### 8. Add Picture for Advert Page:  https://localhost:44330/Ilan/Images/5
![](/pictures/AddPictureforAdvertPage.PNG)
