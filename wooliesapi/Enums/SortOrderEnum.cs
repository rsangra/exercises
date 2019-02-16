using System.Runtime.Serialization;
namespace WooliesX.Exercises.Enums
{
    public enum SortBy
    {
        [EnumMember(Value = "low")]
        Low = 1,
        [EnumMember(Value = "high")]
        High = 2,
        [EnumMember(Value = "ascending")]
        Ascending = 4,
        [EnumMember(Value = "descending")]
        Descending = 8,
        [EnumMember(Value = "recommended")]
        Recommended = 16
    }
}
