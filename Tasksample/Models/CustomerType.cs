


namespace Tasksample.Models
{
    public class CustomerType
    {
        
            public int CustomerTypeId { get; set; }
       
            public string CustomerTypeDescription { get; set; } = string.Empty;
        
            public DateTime CreatedOn { get; set; } = DateTime.Now;
        
            public int CreatedBy { get; set; }
        
            public DateTime UpdatedOn { get; set; } = DateTime.Now;
        
            public int UpdatedBy { get; set; }
      
            public bool IsDeleted { get; set; }

        
    }
}
