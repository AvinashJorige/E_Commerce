using System;
using System.ComponentModel.DataAnnotations;

namespace CoreModel.Mappings
{
    public class ecom_tbl_Category
    {
        [Key]
        [StringLength(10)]
        public string ct_Id { get; set; }

        [StringLength(30)]
        public string ct_Name { get; set; }

        [StringLength(30)]
        public string ct_Type { get; set; }

        [StringLength(50)]
        public string ct_Modified_By { get; set; }

        public DateTime? ct_Modified_Date { get; set; }
    }
}
