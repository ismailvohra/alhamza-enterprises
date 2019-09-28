using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace AlHamzaEnterprises.Extension
{
    public static class IdentityExtension
    {
        public static string GetUserXName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserType(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserType");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetMobileNo(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("MobileNo");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetLandline(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Landline");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetCompanyName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("CompanyName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetSalesTaxNo(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("SalesTaxNo");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetNTNNo(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("NTNNo");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetDesignation(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Designation");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static Claim GetBasicSalary(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("BasicSalary");
            return claim;
        }

        public static Claim GetHireDate(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("HireDate");
            return claim;
        }

        public static Claim GetCurrentEmployee(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("CurrentEmployee");
            return claim;
            //return (claim != null) ? claim.Value : bool;
        }
    }
}