using MyCourse.Data;
using MyCourse.ViewModels;

namespace MyCourse.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext db;
        public AppointmentService(AppDbContext _db)
        {
            db = _db; 
        }
        public List<DoctorVM> GetDoctors()
        {
            var doctors = (from user in db.Users
                           join userrole in db.UserRoles on user.Id equals userrole.UserId
                           join role in db.Roles.Where(k=>k.Name == Helpers.Helper.doctor) on userrole.RoleId equals role.Id
                           select new DoctorVM
                           {
                                id = user.Id,
                                Name = user.Name

                           }).ToList();
            return doctors;
        }

        public List<PatientVM> GetPatients()
        {
            var patients = (from user in db.Users
                           join userrole in db.UserRoles on user.Id equals userrole.UserId
                           join role in db.Roles.Where(k => k.Name == Helpers.Helper.patient) on userrole.RoleId equals role.Id
                           select new PatientVM
                           {
                               id = user.Id,
                               Name = user.Name

                           }).ToList();
            return patients;
        }
        //public List<PatientVM> GetUsers(string usertype)
        //{
        //    var users = (from user in db.Users
        //                    join userrole in db.UserRoles on user.Id equals userrole.UserId
        //                    join role in db.Roles.Where(k => k.Name == usertype) on userrole.RoleId equals role.Id
        //                    select new PatientVM
        //                    {
        //                        id = user.Id,
        //                        Name = user.Name

        //                    }).ToList();
        //    return users;
        //}
    }
}
