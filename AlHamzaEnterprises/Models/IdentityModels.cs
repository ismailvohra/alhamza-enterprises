using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AlHamzaEnterprises.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual string UserType { get; set; }
        public virtual string MobileNo { get; set; }
        public virtual string Landline { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string SalesTaxNo { get; set; }
        public virtual string NTNNo { get; set; }
        public virtual string Designation { get; set; }
        public virtual int BasicSalary { get; set; }
        public virtual System.DateTime HireDate { get; set; }
        public virtual bool CurrentEmployee { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("UserType", this.UserType));
            userIdentity.AddClaim(new Claim("MobileNo", this.MobileNo));
            userIdentity.AddClaim(new Claim("Landline", this.Landline));
            userIdentity.AddClaim(new Claim("CompanyName", this.CompanyName));
            userIdentity.AddClaim(new Claim("SalesTaxNo", this.SalesTaxNo));
            userIdentity.AddClaim(new Claim("NTNNo", this.NTNNo));
            userIdentity.AddClaim(new Claim("Designation", this.Designation));
            userIdentity.AddClaim(new Claim("BasicSalary", this.BasicSalary.ToString()));
            userIdentity.AddClaim(new Claim("HireDate", HireDate.ToString()));
            userIdentity.AddClaim(new Claim("CurrentEmployee", this.CurrentEmployee.ToString()));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}