namespace my_orange_easyxls.DTO
{
    public class Org_fieldDTO
    {
        
            public int Id { get; set; } // SQLite中的INTEGER PRIMARY KEY AUTOINCREMENT  
            public int Fieldnum { get; set; } // SQLite中的TEXT NOT NULL  
            public string Fieldname { get; set; } // SQLite中的TEXT NOT NULL  
            public int Org_fileid { get; set; }
            public string Dataname { get; set; }
            public string Datadesc { get; set; }
            public DateTime Createtime { get; set; } // SQLite中的TIMESTAMP DEFAULT CURRENT_TIMESTAMP，在C#中通常使用DateTime  
            public int State { get; set; } // SQLite中的TEXT CHECK(state IN ('active', 'inactive', 'deleted')) NOT NULL  
         
    }
}
