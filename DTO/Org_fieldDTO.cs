using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace my_orange_easyxls.DTO
{
    public class Org_fieldDTO
    {
        
        public int Id { get; set; } // SQLite中的INTEGER PRIMARY KEY AUTOINCREMENT  
        [Required(ErrorMessage = "请输入序号")]
        public int Fieldnum { get; set; } // SQLite中的TEXT NOT NULL  
        [Required(ErrorMessage = "请输入字段名")]
        public string Fieldname { get; set; } // SQLite中的TEXT NOT NULL  
        public int Org_fileid { get; set; }
        [Required(ErrorMessage = "请输入工作簿")]
        public string Dataname { get; set; }
        [Required(ErrorMessage = "请输入文件名")]
        public string Datadesc { get; set; }
        public DateTime Createtime { get; set; } // SQLite中的TIMESTAMP DEFAULT CURRENT_TIMESTAMP，在C#中通常使用DateTime  
        public int State { get; set; } // SQLite中的TEXT CHECK(state IN ('active', 'inactive', 'deleted')) NOT NULL  
         
    }
}
