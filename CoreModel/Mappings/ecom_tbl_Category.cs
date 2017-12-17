namespace CoreModel.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ecom_tbl_Category
    {
        [Key]
        public int ct_Id { get; set; }

        [StringLength(30)]
        public string ct_Name { get; set; }

        [StringLength(30)]
        public string ct_Type { get; set; }

        [StringLength(50)]
        public string ct_Modified_By { get; set; }

        public DateTime? ct_Modified_Date { get; set; }
    }
}
