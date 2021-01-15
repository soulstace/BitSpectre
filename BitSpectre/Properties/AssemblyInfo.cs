using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("BitSpectre")]
[assembly: AssemblyDescription("Speculative execution side-channel vulnerability mitigations - Bit Editor")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
 [assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("soulstace")]
[assembly: AssemblyProduct("BitSpectre")]
[assembly: AssemblyCopyright("Copyright © 2020 - current")]
[assembly: AssemblyTrademark("™")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("102dece1-1940-4fbb-99dc-78f906b33595")]

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
[assembly: AssemblyVersion("1.0.9.10")]
[assembly: AssemblyFileVersion("1.0.9.10")]
