using System.ComponentModel.DataAnnotations;

namespace HrSystem.Api.RequestModels
{
    public class MultipleUserRoleRequestVM : Model
    {
        [Required(ErrorMessage = "User is required")]
        public string UserId { get; set; }

        public long[] RoleIds { get; set; }
    }
}

