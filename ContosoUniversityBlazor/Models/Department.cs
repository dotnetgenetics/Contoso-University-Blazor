using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityBlazor.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        public int? InstructorID { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        /// <summary>
        /// https://stackoverflow.com/questions/21146023/converting-sql-server-rowversion-to-long-or-ulong
        /// </summary>
        [NotMapped]
        public UInt64 DisplayRowVersion
        {
            get
            {
                if (RowVersion != null)
                {
                    byte[] rr = (byte[])RowVersion.Clone();
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(rr);

                    return BitConverter.ToUInt64(rr);
                }

                return 0;
            }
        }

        [NotMapped]
        public string DisplayDate
        {
            get
            {
                return StartDate.ToString("yyyy-MM-dd");
            }
        }

        [NotMapped]
        public string DisplayBudget
        {
            get
            {
                return Budget.ToString("C");
            }
        }

        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
