namespace CoreModel.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ecom_tbl_Sub_Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sub_ct_Id { get; set; }

        [StringLength(50)]
        public string sub_ct_Name { get; set; }

        [StringLength(50)]
        public string sub_ct_Type { get; set; }

        public string sub_ct_Description { get; set; }

        public string sub_ct_Photo { get; set; }

        public int? sub_ct_Location_Id { get; set; }

        public decimal? sub_ct_Price { get; set; }

        [StringLength(20)]
        public string sub_ct_Condition { get; set; }

        [StringLength(20)]
        public string sub_ct_Brand { get; set; }

        public string sub_ct_Feature { get; set; }

        public Guid? sub_ct_Posted_By { get; set; }

        [StringLength(15)]
        public string sub_ct_TelePhone { get; set; }

        public Guid? sub_ct_Modified_By { get; set; }

        public DateTime? sub_ct_Modified_Date { get; set; }

        [StringLength(50)]
        public string sub_ct_Title { get; set; }

        [StringLength(50)]
        public string sub_ct_Caption { get; set; }

        [StringLength(10)]
        public string sub_ct_Display_Name { get; set; }
    }
}
