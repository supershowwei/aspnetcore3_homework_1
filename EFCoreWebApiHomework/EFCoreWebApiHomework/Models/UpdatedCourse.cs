using System.ComponentModel.DataAnnotations;

namespace EFCoreWebApiHomework.Models
{
    public class UpdatedCourse
    {
        //[RegularExpression("[1-9][0-9]*")]
        [Range(1, 10)]
        public int Credits { get; set; }
    }
}