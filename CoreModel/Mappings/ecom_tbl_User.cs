namespace CoreModel.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ecom_tbl_User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        public Guid UserId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string PasswordHashKey { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string UserRole { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public byte[] Pincode { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public bool? IsActive { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public Guid UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
