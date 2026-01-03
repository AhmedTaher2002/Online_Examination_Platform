using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.Models
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public bool IsDeleted { get; set; }= false;
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime UpdatedDate { get; set; }= DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
