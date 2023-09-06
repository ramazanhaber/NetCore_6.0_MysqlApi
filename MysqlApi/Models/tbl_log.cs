using System.ComponentModel.DataAnnotations;

namespace MysqlApi.Models
{
    public class tbl_log
    {
            [Key]
            public int id { get; set; }
            public int? kul_id { get; set; }
            public string? yapilan_islem { get; set; } // aa
            public DateTime? tarih { get; set; }
    }
}
