using System.ComponentModel.DataAnnotations;

namespace AllPhi.HoGent.Blazor.Dto.Enums
{
    public enum NumberOfDoors
    {
        [Display(Name = "1 deur")]
        OneDoor = 1,

        [Display(Name = "2 deuren")]
        TwooDoors = 2,

        [Display(Name = "3 deuren")]
        ThreeDoors = 3,

        [Display(Name = "4 deuren")]
        FourDoors = 4,

        [Display(Name = "5 deuren")]
        FiveDoors = 5,
    }
}
