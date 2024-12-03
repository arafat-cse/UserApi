using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Model
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName {  get; set; }
        public int Age {  get; set; }
        public DateOnly Date { get; set; }
        public bool IsActive {  get; set; }
    }
}
