using SMC_UI.Models.ClassRoom;
using SMC_UI.Models.Result;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_UI.Models.Student
{
    public class StudentReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string ChristeningName { get; set; }
        public int GenderId { get; set; }
        public int Age { get; set; }
        public string OccupationType { get; set; }
        public string Telephone { get; set; }
        public string Adress { get; set; }
        public int GreadId { get; set; }
        public int ClassRoomId { get; set; }
        public GenderType Gender { get; set; }
        public GreadType Gread { get; set; }
        public ClassRoomReadDto ClassRoom { get; set; }
        public string FullName => string.Concat(FirstName, " ", MiddleName, " ", LastName);
        public IEnumerable<ResulReadDto> Resuls { get; set; }
    }
}
