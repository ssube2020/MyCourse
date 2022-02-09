using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyCourse.Helpers
{
    public static class Helper
    {

        public static string doctor { get; set; }
        public static string patient { get; set; }
        public static string admin { get; set; }

         
        static Helper()
        {
            doctor = "doctor";
            patient = "patient";
            admin = "admin";
        }
    

        public static List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem> {
                
                new SelectListItem { Value = Helper.doctor, Text = Helper.doctor },
                new SelectListItem { Value = Helper.patient, Text = Helper.patient },
                new SelectListItem { Value = Helper.admin, Text = Helper.admin }
            };
        }

    }
}
