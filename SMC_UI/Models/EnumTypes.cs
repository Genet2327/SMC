using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace SMC_UI.Models
{
    public enum GenderType
    {
        Male = 1,
        Female = 2
    }

    public enum GreadType
    {
 
        [EnumMember(Value = "Gread 1")]
        Gread1 = 1,
        [EnumMember(Value = "Gread 2")]
        Gread2 = 2,
        [EnumMember(Value = "Gread 3")]
        Gread3 = 3,
        [EnumMember(Value = "Gread 4")]
        Gread4 = 4,
        [EnumMember(Value = "Gread 5")]
        Gread5 = 5,
        [EnumMember(Value = "Gread 6")]
        Gread6 = 6,
        [EnumMember(Value = "Gread 7")]
        Gread7 = 7,
        [EnumMember(Value = "Gread 8")]
        Gread8 = 8,
        [EnumMember(Value = "Gread 9")]
        Gread9 = 9,
        [EnumMember(Value = "Gread 10")]
        Gread10 = 10,
        [EnumMember(Value = "Gread 11")]
        Gread11 = 11,
        [EnumMember(Value = "Gread 12")]
        Gread12 = 12,
        [EnumMember(Value = "KG 13")]
        KG1 = 13,
        [EnumMember(Value = "KG 14")]
        KG2 = 14,
    }
}
