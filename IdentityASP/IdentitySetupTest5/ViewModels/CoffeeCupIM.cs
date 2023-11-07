using System.ComponentModel.DataAnnotations;

namespace IdentitySetupTest5.ViewModels
{
    public class CoffeeCupIM
    {
        public int CoffeeCupId { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Id of Machine")]
        public int MachineNo { get; set; }
    }
}
