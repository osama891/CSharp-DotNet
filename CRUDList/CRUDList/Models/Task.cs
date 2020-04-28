using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDList.Models
{
    public class Task
    {
      public int Id { get; set; }

      [Required]  
      public string Title { get; set; }
        [Required]
      public string Description { get; set; }

      public Status Status { get; set; }

      public Priority Priority { get; set; }




    }
}
