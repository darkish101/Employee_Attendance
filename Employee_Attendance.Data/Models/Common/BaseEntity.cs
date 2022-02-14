using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Attendance.Data
{
   public abstract class BaseEntity <TKey>: IBaseEntity<TKey>
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }

        [Column(Order = 20)]
        [DefaultValue("GETDATE()")]
        public DateTime? Created_On { get; set; }

        [Column(Order = 21)]
        public DateTime? LastUpdatedDate { get; set; }
    }
}
