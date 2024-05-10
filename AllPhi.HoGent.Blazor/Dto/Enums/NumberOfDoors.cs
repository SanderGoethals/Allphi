using System.ComponentModel.DataAnnotations;

namespace AllPhi.HoGent.Blazor.Dto.Enums
{
    public enum NumberOfDoors
    {
        [Display(Name = "2 deuren")]
        TwoDoors = 2,

        [Display(Name = "3 deuren")]
        ThreeDoors = 3,

        [Display(Name = "4 deuren")]
        FourDoors = 4,

        [Display(Name = "5 deuren")]
        FiveDoors = 5,
    }
}
