using System.ComponentModel.DataAnnotations;

namespace BoxBack.Domain.Enums
{
    public enum ApplicationUserStatusEnum
    {
        [Display(Name = "Pending")]
        PENDING = 1,

        [Display(Name = "Active")]
        ACTIVE = 2,

        [Display(Name = "Inactive")]
        INACTIVE = 3
    }
}