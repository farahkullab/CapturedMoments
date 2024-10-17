using System.ComponentModel.DataAnnotations;

namespace CapturedMoments.Models.ViewModels
{
    public class DeleteRoleViewModel
    {
        public string RoleId { get; internal set; }
        [Required]
        public string RoleName { get; internal set; }
    }
}
