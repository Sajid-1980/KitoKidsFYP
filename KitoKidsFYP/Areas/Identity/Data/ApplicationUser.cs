using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KitoKidsFYP.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{


    public string ChildFullName { get; set; }
    public string NameOfParent { get; set; }
    public DateTime DOB { get; set; }
    public string Gender { get; set; }
    public string Nationality { get; set; }
    public string Religion { get; set; }
    public string ChildAddress { get; set; }
    public string Email { get; set; }
    public string PhoneNo { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string CertificateNo { get; set; }



}

