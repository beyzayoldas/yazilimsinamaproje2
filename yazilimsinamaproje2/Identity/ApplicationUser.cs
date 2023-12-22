﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yazilimsinamaproje2.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }  
    }
}