using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasksample.Models
{
    public class CustomerType
    {
             [Key]
             public int CustomerTypeId { get; set; }
       
             public string CustomerTypeDescription { get; set; } = string.Empty;
        
             public DateTime? CreatedOn { get; set; }
       
             public int? CreatedBy { get; set; }
        
             public DateTime? UpdatedOn { get; set; }
        
             public int? UpdatedBy { get; set; }
      
             public bool IsDeleted { get; set; }

        
    }
}
