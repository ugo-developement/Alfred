using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Alfred")]

[assembly: AssemblyDescription(
    "Alfred is an all purpose business management application\n" +
    "for use by employees, managers, district managers, and on. Designed and developed by\n" +
    "Joey Hendrich and Russell Goodloe, Alfred's aim is to present the user with custom\n" +
    "information suited for their store, employee status, and whatever is deamed important\n" +
    "in the ever lengthy journey of increased efficiencey.\n\n\n" +
    "\"Any run-of-mill engineer can design something which is elegant.\nA good engineer designs a system to be efficient.\n A great engineer designs them to be effective.\"" +
    "\n\nAkin's Laws. No. 36\nhttps://spacecraft.ssl.umd.edu/akins_laws.html")]

[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Ugo - Delivery LLC")]
[assembly: AssemblyProduct("Alfred")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//In order to begin building localizable applications, set
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
                                     //(used if a resource is not found in the page,
                                     // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
                                              //(used if a resource is not found in the page,
                                              // app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
