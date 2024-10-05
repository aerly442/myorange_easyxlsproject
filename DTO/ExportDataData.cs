namespace my_orange_easyxls.DTO
{
    public class ExportDataDTO
    {
        //工作簿名称
        public string SheetName { get; set; }
        /// <summary>
        /// 表头
        /// </summary>
        public List<string> lstHeader { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<Org_dataDTO> lstData { get; set; }
    }
}
