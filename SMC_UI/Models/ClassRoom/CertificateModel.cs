using SMC_UI.Models.Student;

namespace SMC_UI.Models.ClassRoom
{
    public class CertificateModel
    {
        public StudentReadDto Student { get; set; }
        public StudentRedByClassRoomNumberDto Data { get; internal set; }
    }
}
