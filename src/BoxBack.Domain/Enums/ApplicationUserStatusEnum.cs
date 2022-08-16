using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ApplicationUserStatusEnum
    {
        [Display(Name = "Pending")]
        PENDING = 0,

        [Display(Name = "Active")]
        ACTIVE = 1,

        [Display(Name = "Inactive")]
        INACTIVE = 2
    }
}