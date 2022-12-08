
# Table of Contents

1.  [.NET MAUI Demystified](#org5d5319f)
    1.  [Introduction to MAUI from a Xamarin developer perspective](#org9e4dfae)
2.  [What is .NET MAUI?](#orgd10d475)
3.  [What platforms are supported?](#orge180dac)
    1.  [Compiled to native](#orgf090c7e)
4.  [Where can I use Maui to build apps on?](#orgaa07e55)
5.  [Maui + Blazor?](#orgb4639e6)
    1.  [Using Blazor](#org781fe6d)
    2.  [Use cases](#org5a4c0cd)
6.  [Maui vs Xamarin.Forms](#org13b0366)
7.  [Graphics API](#org219fb39)
8.  [Graphics API - C#](#org4bf5ae4)
9.  [Graphics API - XAML](#org693f150)
11. [Folder structure](#org64064dd)
    1.  [Explanation](#orgf2c0d61)
12. [MVVMCross vs CommunityToolkit.Mvvm;](#orgb4bf998)
    1.  [Note](#org5d2d371)
13. [Old way - Notifying dependent properties (MVVMCross;)](#org5a267e8)
14. [New way - Notifying dependent properties (CommunityToolkit.Mvvm;)](#org8bd3415)
15. [Getting started](#orgc8d3af8)
16. [Making sense of the defaults](#org3e6dc13)
17. [AppShell](#orgd8575c0)
18. [Images & animation](#orgedbcf16)
19. [For more information](#org855862b)
    1.  [Video](#orgfe50f54)
    2.  [Reading](#orgbfd6576)



<a id="org5d5319f"></a>

# .NET MAUI Demystified


<a id="org9e4dfae"></a>

## Introduction to MAUI from a Xamarin developer perspective




<a id="orgd10d475"></a>

# What is .NET MAUI?

-   MAUI stands for &ldquo;Multi-platform Application User Interface&rdquo;;

-   Framework for C#/F# developers to write native applications for multiple platforms from a single code-base;

-   Next generation of Xamarin, inherits all Xamarin.Forms functionality and extends from there;

-   Supports &rsquo;Model View View-model&rsquo; and &rsquo;Model View Update&rsquo; architectures;

-   Supports most common desktop and mobile Operating Systems;

-   Built on-top of .NET 6 & .NET 7 (supported by either)

-   Free and Open Source software


<a id="orge180dac"></a>

# What platforms are supported?




<a id="orgf090c7e"></a>

## Compiled to native

.NET Multi-platform App UI (.NET MAUI) apps can be written for the following platforms:

-   Android 5.0 (API 21) or higher.
-   iOS 11 or higher, using the latest release of Xcode.
-   macOS 10.15 or higher, using Mac Catalyst.
-   Windows 11 and Windows 10 version 1809 or higher, using Windows UI Library (WinUI) 3.
    
    .NET MAUI Blazor apps have the following additional platform requirements:

-   Android 7.0 (API 24) or higher is required
-   iOS 14 or higher is required.
-   macOS 11 or higher, using Mac Catalyst.

Source - <https://learn.microsoft.com/en-us/dotnet/maui/supported-platforms?view=net-maui-7.0>

P.S. there is unofficial community made support for Linux GTK-based apps currently in development


<a id="orgaa07e55"></a>

# Where can I use Maui to build apps on?

Maui can be used anywhere .NET 6+ can be used, this includes but is not limited to:

-   Windows 10, 11
-   MacOS
-   Linux
-   BSD.

Maui development is supported within:

-   Visual Studio
-   Visual Studio for Mac
-   Visual Studio Code (requires extensions)
-   JetBrains Rider IDE.


<a id="orgb4639e6"></a>

# Maui + Blazor?


<a id="org781fe6d"></a>

## Using Blazor

Maui allows one to run a Blazor app as a native app without the need for Web
Assembly (WASM).  Electron and Progressive Web Apps (PWA) both require Web
Assembly in order for a Blazor app to run, with .NET Maui the code that is
running is much closer to the bare metal than otherwise, as the blazor code
targets the .NET runtime on the target platform, resulting in a more performant
application compared to running in some browser sand-boxed way (PWA, Electron)
and allows one to target both mobile and desktop applications naively.

Source - <https://www.codemag.com/Article/2111092/Blazor-Hybrid-Web-Apps-with-.NET-MAUI>


<a id="org5a4c0cd"></a>

## Use cases

The ability to create a native application with a UI written using HTML and CSS
makes it a particularly useful option if you’re already comfortable building for
the web. It means you can take all your existing knowledge, skills and
experience, and turn it toward building a native app.

At this early stage, it looks like there are three primary use cases for
adopting .NET MAUI (with Blazor).

-   As a web/Blazor developer, to take your existing Blazor app and run it
    natively on mobile and desktop
-   As a web/Blazor developer, to make a brand-new native app using your
    existing skills
-   As a desktop developer, to use Blazor for some or all of your app,
    potentially bringing in Blazor components from the community and/or any
    existing web applications to which you have access

Source - <https://www.telerik.com/blogs/blazor-dotnet-maui-what-how-when>


<a id="org13b0366"></a>

# Maui vs Xamarin.Forms

Lets go in depth about what the differences are between Xamarin and Maui, but first, a quick overview:

Differences include:

-   MAUI features a cross-platform drawing/graphic feature called &ldquo;Canvas&rdquo;;
-   MAUI doesn&rsquo;t need third party frameworks like MVVMCross, Maui.CommunityToolkit is the standard;
-   Everything Xamarin is renamed to Maui
-   Folder structure is different, all target platform code in the one project


<a id="org219fb39"></a>

# Graphics API

In Xamarin you would need to create a custom native renderer in order to make custom drawings/graphics,
in MAUI one of the tangible things that differentiate it from Xamarin is the new cross-platform &ldquo;canvas&rdquo; class that
allows you to draw custom graphics for all platforms.


<a id="org4bf5ae4"></a>

# Graphics API - C#

MyDrawing.cs

    // Maui.Graphics example
    using Microsoft.Maui.Graphics;
    
    namspace MyApp.Drawings;
    
    public partial class MyDrawing : IDrawable
    {
    
        public MyDrawing()
        {
            InitializeComponent();
        }
    
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Arc setup (both)
            canvas.StrokeSize = 45;
            canvas.BlendMode = BlendMode.Overlay;
    
            // Background Arc
            canvas.StrokeColor = Colors.Gray;
            canvas.DrawArc(45, 45, 100, 100, 230, -55, true, false);
    
            // Progress/top Arc
            canvas.StrokeColor = Colors.DarkOrange;
            canvas.DrawArc(45, 45, 100, 100, 230, 0, true, false);
        }
    }


<a id="org693f150"></a>

# Graphics API - XAML

MainPage.xaml

    <?xml version="1.0" encoding="utf-8" ?>
    <ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 xmlns:drawable="clr-namespace:sevenmaui.Views"
                 x:Class="sevenmaui.MainPage">
        <ContentPage.Resources>
            <drawable:RadialBar x:Key="drawable" />
        </ContentPage.Resources>
        <ScrollView>
            <VerticalStackLayout
                Spacing="25"
                Padding="30,0"
                VerticalOptions="Center">
                <GraphicsView
                    Drawable="{StaticResource drawable}"
                    HorizontalOptions="Center"
                    HeightRequest="195"
                    WidthRequest="195" />
            </VerticalStackLayout>
        </ScrollView>
    </ContentPage>


<a id="org520c452"></a>




# Folder structure


<a id="orgf2c0d61"></a>

## Explanation

With both Xamarin.Forms and Xamarin.Native, each target platform required
separate projects, this is not the case for .NET Maui.  All platforms can be
managed into a single project, with features like fonts, images, styling, raw
assets, splash screens and more being located within the &ldquo;Resources&rdquo; folder.

Native platform specific code is still supported, this can be specified in the &ldquo;Platforms&rdquo; folder within
a Maui project or as a conditional.


<a id="orgb4bf998"></a>

# MVVMCross vs CommunityToolkit.Mvvm;

No longer is there a need to install a third-party MVVM framework for
data-binding, property notification and extra abstraction, its built in nowadays.
CommunityToolkit.Mvvm features many of the cherished features of frameworks
like TinyMVVM, MVVMCross and more. The syntax different between frameworks of
course so lets look at how to do some basics in CommunityToolkit.Mvvm.


<a id="org5d2d371"></a>

## Note

To use CommunityToolkit.Mvvm first you&rsquo;ll have to install the package in your Maui project and add:

    using CommunityToolkit.Mvvm;

For more information please refer to - <https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/>


<a id="org5a267e8"></a>

# Old way - Notifying dependent properties (MVVMCross;)

    private string _firstName;
    
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            RaisePropertyChanged("FullName");
            RaisePropertyChanged("EmployeeReference");
            RaisePropertyChanged("BigMegaCorpEmployeeList");
        }
    }


<a id="org8bd3415"></a>

# New way - Notifying dependent properties (CommunityToolkit.Mvvm;)

    [ObservableProperty]
    [NotifyPropertyChangeFor(nameof(FullName))]
    [NotifyPropertyChangeFor(nameof(EmployeeReference))]
    [NotifyPropertyChangeFor(nameof(BigMegaCorpEmployeeList))]
    private string firstName;

For more info on how this works, go to - <https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/generators/observableproperty>


<a id="orgc8d3af8"></a>

# Getting started

To start a new Maui project you can either generate it in your preferred IDE or with the Dotnet CLI.
First you will need to install the Maui workflow, this can be done with the following command:

    dotnet workload install maui

You&rsquo;ll also need either .NET 6 or .NET 7 installed on your system.

To start a new Maui project via the Dotnet CLI:

    dotnet new maui MyProjectNameGoesHere


<a id="org3e6dc13"></a>

# Making sense of the defaults

MainPage.xaml is your home page, this can be moved anywhere so long as
you update the classes and namespaces to match the new path.  Each
ContentPage.xaml will have an underlying class connected to it, for example when
creating a new ContentPage in Visual Studio called NewPage you will instantiate
both a NewPage.xaml and a NewPage.cs file. ContentPage is the go-to
template/subclass to inherit in order to make a page in your app.


<a id="orgd8575c0"></a>

# AppShell

AppShell.xaml is your Navigation bar/Hamburger menu/ flyout menu/ect. You can
add new pages via AppShell.xaml.  To add a new page link to your nav bar, add a
new <ShellContent /> element and follow the conventions shown below:

    <?xml version="1.0" encoding="UTF-8" ?>
    <Shell
        x:Class="TestMaui.AppShell"
        xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
        xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
        xmlns:local="clr-namespace:TestMaui"
        Shell.FlyoutBehavior="Flyout">
    
        <ShellContent
            Title="Home"
            ContentTemplate="{DataTemplate local:MainPage}"
            Route="MainPage" />
    
        <ShellContent
            Title="NewPage"
            ContentTemplate="{DataTemplate local:NewPage}"
            Route="NewPage" />
    </Shell>


<a id="orgedbcf16"></a>

# Images & animation

<Image/> elements will automatically convert .svg files to .png out of the box, this
has been showcased in the default MainPage.xaml provided in a new Maui app.
Images can be animated, tranformed and or manipulated in any way that they would
be expected to be, the key is to give your image element a \`x:Name=&ldquo;NameOfImage&rdquo;\`
in order to reference your image in the code behind.


<a id="org855862b"></a>

# For more information

Some resources you may find as handy as I have include:


<a id="orgfe50f54"></a>

## Video

James Montemagno - <https://www.youtube.com/watch?v=KmLQLSKqvvI>

Daniel Hindrikes (creator of TinyMvvm framework) - <https://www.youtube.com/watch?v=80sinVHdCSQ>


<a id="orgbfd6576"></a>

## Reading

Microsoft - <https://learn.microsoft.com/en-us/dotnet/maui/?view=net-maui-7.0>

