using MyCourse.ViewModels;

namespace MyCourse.Services
{
    public interface IAppointmentService
    {
        public List<DoctorVM> GetDoctors();
        public List<PatientVM> GetPatients();
    }
}
