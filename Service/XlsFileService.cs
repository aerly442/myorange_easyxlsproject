using Microsoft.Extensions.Hosting;
using System;  
using System.Collections.Generic;  
using System.IO;  
using OfficeOpenXml;  
using my_orange_easyxls.DTO;

namespace my_orange_easyxls.Service
{
    public class XlsFileService
    {

        

        private readonly IWebHostEnvironment? _hostEnvironment;
        //IWebHostEnvironment Environment
        public XlsFileService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;

        }

        private string GetXlsFileName(string fileName){

           string[] aryFile = fileName.Split('.');
           if (aryFile.Length ==2){

               return aryFile[0] ;
           }

           return fileName;


        }

        public List<Org_dataDTO> GetOrgDataByFile(Org_fileDTO f,int org_fieldid,int org_fileid){

            string path     = _hostEnvironment.WebRootPath;
            string filePath = path +f.FileUrl;
            FileInfo fileInfo = new FileInfo(filePath); 


             List<Org_dataDTO> lstFile = new  List<Org_dataDTO>();
  
            // 使用 EPPlus 打开 Excel 包  
            using (ExcelPackage package = new ExcelPackage(fileInfo))  
            {
                List<string> sheetNames = new List<string>();  
                foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)  
                {  
                    for(int row=2;row<=worksheet.Dimension.End.Row;row++){

                        Org_dataDTO item = new Org_dataDTO();
                        for (int col = 1; col <= worksheet.Dimension.Columns; col++)  
                        {  

                            var cell          = worksheet.Cells[row, col]; 
                            string fieldValue = cell.Value.ToString(); //字段值 
                            string fieldName  = "Field"+col.ToString();//字段名
                            item              = (Org_dataDTO)MyClassConvert.setClassPropertyValueFromSourceToDest(fieldName,fieldValue,item);  
                        }
                        item.Org_fieldid = org_fieldid;
                        item.Org_fileid  = org_fileid ;
                        item.State       =  0 ;
                        item.Createtime  = DateTime.Now;   
                        lstFile.Add(item);
                    }

                }  
              
            

            } 

            return lstFile; 


        }

        //读取xlsx文件获取工作簿名称和列明 
        public List<Org_fieldDTO> GetOrgFieldByFile(Org_fileDTO f){
            
            string path     = _hostEnvironment.WebRootPath;
            string filePath = path +f.FileUrl;
            FileInfo fileInfo = new FileInfo(filePath); 


             List<Org_fieldDTO> lstFile = new  List<Org_fieldDTO>();
  
            // 使用 EPPlus 打开 Excel 包  
            using (ExcelPackage package = new ExcelPackage(fileInfo))  
            {
                List<string> sheetNames = new List<string>();  
                foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)  
                {  
                    string sheetName = worksheet.Name;  //工作簿的名称
                    string dataName  = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string dataDesc  = GetXlsFileName(f.Filename)+"."+sheetName; 
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)  
                    {  

                        var cell       = worksheet.Cells[1, col]; 
                        string colName = cell.Value.ToString(); //列名

                        lstFile.Add(new Org_fieldDTO(){

                            Id         = 0 ,   
                            Fieldnum   = col,
                            Fieldname  = colName,
                            Org_fileid = f.Id,
                            Dataname   = dataName,
                            Datadesc   = this.GetXlsFileName(f.Filename)+"."+sheetName,
                            Createtime = DateTime.Now,
                            State      = 0

                        });
 
                    }  

                }  
              
            

            } 

            return lstFile; 


        }

 

    }
}