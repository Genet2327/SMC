using SMC_UI.Models.ClassRoom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Student
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
        [Required]
        public int? Age { get; set; }
        [Required]
        public string OccupationType { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Adress { get; set; }
        [Required]
        public int GenderId { get; set; }
        public GenderType Gender { get; set; }
        [Required]
        public int GreadId { get; set; }
        public GreadType Gread { get; set; }
        [Required]
        public int? ClassRoomId { get; set; }
        public IEnumerable<ClassRoomReadDto> ClassRooms { get; set; }
    }
}
