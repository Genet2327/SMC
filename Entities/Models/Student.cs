using SMC_Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMC_Entities
{
    public class Student
    {
        public int Id { get; set; }
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
        public int? GenderId { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string OccupationType { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Adress { get; set; }
        public int GreadId { get; set; }
        public int ClassRoomId { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
}
