﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace Identity.POC.Entities
{
    public class IdentityRole : IdentityRole<string>
    {
        public IdentityRole()
        {
        }

        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

    public class IdentityRole<TKey> : IdentityRole<TKey, IdentityUserRole<TKey>, IdentityRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        public IdentityRole()
        {
        }

        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

    public class IdentityRight<TKey> 
       where TKey : IEquatable<TKey>
    {
        public IdentityRight()
        {
        }
        
        public IdentityRight(string rightName) : this()
        {
            Name = rightName;
        }

        public virtual TKey Id { get; set; }
        public virtual string Name { get; set; }        
    }

    public class IdentityRole<TKey, TUserRole, TRoleClaim> : IRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
    {
        public IdentityRole()
        {
        }

        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }

        public virtual TKey Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<TRoleClaim> Roles { get; } = new List<TRoleClaim>();
        public virtual ICollection<TUserRole> Users { get; } = new List<TUserRole>();
    }
}