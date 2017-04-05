using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model.Common
{
    public interface IAspNetUserDomain
    {
        string Id { get; set; }
        string Email { get; set; }
        bool EmailConfirmed { get; set; }
        string PasswordHash { get; set; }
        string SecurityStamp { get; set; }
        string PhoneNumber { get; set; }
        bool PhoneNumberConfirmed { get; set; }
        bool TwoFactorEnabled { get; set; }
        Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        bool LockoutEnabled { get; set; }
        int AccessFailedCount { get; set; }
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string Address { get; set; }
        string Place { get; set; }

        ICollection<IAspNetUserClaimDomain> AspNetUserClaims { get; set; }
        ICollection<IAspNetUserLoginDomain> AspNetUserLogins { get; set; }
        ICollection<IAspNetRoleDomain> AspNetRoles { get; set; }
        ICollection<IPollDomain> Polls { get; set; }
    }
}
