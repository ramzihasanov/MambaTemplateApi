using Mamba.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba.Core.Entites
{
    public class User: IdentityUser
    {
        public string Fullname { get; set; }
    }
}
