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
        private readonly FileUploadService fileUploadService;
        //IWebHostEnvironment Environment
        public XlsFileService(IWebHostEnvironment hostEnvironment,FileUploadService _fileUploadService)
        {
            _hostEnvironment = hostEnvironment;
            fileUploadService = _fileUploadService;

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
                    string sheetName = worksheet.Name;  //工作簿的名称                   
                    string dataDesc = GetXlsFileName(f.Filename);
                    string dataName = sheetName;

                    for (int row=2;row<=worksheet.Dimension.End.Row;row++){

                        Org_dataDTO item = new Org_dataDTO();
                        for (int col = 1; col <= worksheet.Dimension.Columns; col++)  
                        {  

                            var cell          = worksheet.Cells[row, col]; 
                            string fieldValue = cell.Value!=null && string.IsNullOrEmpty(cell.Value.ToString()) ==false ?cell.Value?.ToString():"";
                            if (fieldValue == "") { continue; }
                            //字段值 
                            string fieldName  = "Field"+col.ToString();//字段名
                            item              = (Org_dataDTO)MyClassConvert.setClassPropertyValueFromSourceToDest(fieldName,fieldValue,item);  
                        }

                        if (String.IsNullOrEmpty(item.Field1)) { continue; }

                        item.Dataname    = sheetName;
                        item.Datadesc    = dataDesc;
                        item.State       =  0 ;
                        item.Createtime  = DateTime.Now;   
                        lstFile.Add(item);
                    }

                }  
              
            

            } 

            return lstFile; 


        }
        /// <summary>
        /// 导出所有工作簿
        /// </summary>
        /// <param name="lstExport"></param>
        public void ExportFile(List<ExportDataDTO> lstExport)
        {

            string fileName = fileUploadService.GetExportFileName();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                foreach( var item in lstExport) {

                    var sheetName = item.SheetName;
                    // 添加一个新的工作表  
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);

                    ///01 写入第一行作为表头
                    int colIndex = 1;
                        var lstHeader = item.lstHeader;
                    foreach (var head in lstHeader)
                    {
                        worksheet.Cells[1, colIndex].Value = head;
                        colIndex++;
                    }

                    //02开始写入数据
                    var lstData = item.lstData;
                    for (int i = 0; i < lstData.Count; i++)
                    {
                        int row = i + 2;
                        for (int col = 0; col < lstHeader.Count; col++)
                        {

                            var cellValue = MyClassConvert.getClassPropertyValueFromSourceToDest("Field" + (col + 1),
                                 lstData[i]);
                            worksheet.Cells[row, col + 1].Value = cellValue;
                        }

                    }


                }
                // 保存Excel文件  
                FileInfo file = new FileInfo(fileName);
                excelPackage.SaveAs(file);
            }

        }

        public void ExportFile(List<String> lstHeader,string sheetName, List<Org_dataDTO> lstData) {

            string fileName = fileUploadService.GetExportFileName();
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // 添加一个新的工作表  
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);

                ///01 写入第一行作为表头
                int colIndex = 1;
                foreach(var head in lstHeader)
                {
                    worksheet.Cells[1, colIndex].Value = head;
                    colIndex++;
                }

                //02开始写入数据

                for(int i = 0; i < lstData.Count; i++)
                {
                    int row = i + 2;
                    for(int col = 0;col<lstHeader.Count; col++)
                    {

                       var cellValue = MyClassConvert.getClassPropertyValueFromSourceToDest("Field"+(col+1),
                            lstData[i]);
                        worksheet.Cells[row, col + 1].Value = cellValue;
                    }

                }



                // 保存Excel文件  
                FileInfo file = new FileInfo(fileName);
                excelPackage.SaveAs(file);
            }
  
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
                    string dataDesc  = GetXlsFileName(f.Filename);
                    string dataName  = sheetName;
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
                            Datadesc   = dataDesc,
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