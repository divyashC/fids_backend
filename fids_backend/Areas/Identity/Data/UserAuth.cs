using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace fids_backend.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UserAuth class
public class UserAuth : IdentityUser
{
    public string Agency { get; set; }
    public string Short { get; set; }
}

