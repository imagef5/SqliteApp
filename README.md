# SqliteApp
>Xamarin Forms 을 이용하여 iOS, Andriod 에서 SQLite database 와 함게 Entity Framework Core 2.0 실행하기<br/>
>[소스코드 참조] : https://github.com/HoussemDellai/EFCore-SQLite-XamarinForms <br/>


# 1. Project Setup
## 1.1 .NET Core SDK 2.0이 설치되어 있어야하며 클래스 라이브러리는 .NET Standard 2.0을 사용하도록 설정되어야함.
- [.Net Core SDK] : http://dot.net/core
- EF Core 2.0 출시로 iOS, Android 및 UWP에서 SQLite 데이터베이스를 사용하여 EF 를 실행할 수 있게 되었음.

# 2. PCL 프로젝트를 .NET Standard Library 로 변경하기 
## 2.1 pcl  *.csproj 프로젝트 파일내의 모든 내용을 삭제하고 아래와 같이 변경
```
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>netstandard2.0</TargetFramework>
        <!-- PackageTargetFallback 태그는 netstandard2.0 에서는 지원하지 않음. 2.0 이하 버전에서 기존의 PCL코드(패키지)를 참조하는 경우 추가 -->
        <!--PackageTargetFallback>$(PackageTargetFallback);portable-win+net45+wp8+win81+wpa8</PackageTargetFallback-->
    </PropertyGroup>
</Project>
```
## 2.2 각각의 프로젝트에 Nurget 패키지 관리자를 통해 Microsoft.EntityFrameworkCore.Sqlite 설치
## 2.3 iOS 의 경우 아래 코드추가 (AppDelegate.cs)
```
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //iOS일 경우 SQLite 초기화
            SQLitePCL.Batteries.Init();

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
```

>참고 : 이전 버전의 EF Core를 사용하는 경우 5.0 이하의 Mono 버전에서 실행하면 iOS에서 다음 오류가 발생하며, EF Core 2.0을 사용하려면 Mono 5.2 이상이 필요합니다. Visual Studio 15.3 이상을 사용 하기시 바랍니다.<br/>
>참고 동영상 : https://channel9.msdn.com/Shows/XamarinShow/Snack-Pack-15-Upgrading-to-XamarinForms-to-NET-Standard?ocid=player

