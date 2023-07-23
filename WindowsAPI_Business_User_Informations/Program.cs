using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Principal;
///Code allow to check which username open application:
Console.WriteLine("UserName: {0}", Environment.UserName);


/////////////Below code may be used to identity if the user is admin of the pc:
    //using system.Security.Principal:
var identity = WindowsIdentity.GetCurrent();
if (identity.User != identity.Owner)
{
    Console.WriteLine("User is not an admin :)");
    Console.WriteLine(identity.User.ToString());
    Console.WriteLine(identity.Owner.ToString());
    //If run the program, the SID will be changed because of elevated admin rights.
}
else
{
    //Works only when admin is not elevated
    Console.WriteLine("User is admin ;)");
}
//UPPER CODE is not working if the user is logged with admin rights. !!



//Below can check if the application running with admin rights:
    WindowsIdentity identity_ = WindowsIdentity.GetCurrent();
    WindowsPrincipal principal = new WindowsPrincipal(identity_);
if (principal.IsInRole(WindowsBuiltInRole.Administrator))
{
    Console.WriteLine("App is run with ADMIN rights");
}
else
{
    Console.WriteLine("App IS NOT run with ADMIN rights");
}
//Upper code allow to verify the rights and grand the access to the business logic.


//Below code can read all claims (security section will be added to the repository!)
Console.WriteLine("ALL USER CLAIMS:");
var ucl = identity.UserClaims;
foreach (var claim in ucl)
{
    Console.WriteLine(claim.Value);
}