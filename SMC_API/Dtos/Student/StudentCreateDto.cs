using SMC_API.Dtos.Attendance;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_API.Dtos.Student
{
    public class StudentCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MotherName { get; set; }
        [Required]
        public string ChristeningName { get; set; }
        public int? GenderId { get; set; }
        public int Age { get; set; }
        public string OccupationType { get; set; }
        public string Telephone { get; set; }
        public string Adress { get; set; }
        public int GreadId { get; set; }
        public int ClassRoomId { get; set; }
    }
}
