﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MVC_WebApi.ViewModels
{
    public class AspNetUserView
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }

        public virtual ICollection<AspNetUserClaimView> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLoginView> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetRoleView> AspNetRoles { get; set; }
        public virtual ICollection<PollView> Polls { get; set; }
    }
}