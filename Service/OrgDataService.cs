using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using my_orange_easyxls.Data;
using my_orange_easyxls.DTO;
using my_orange_easyxls.Models;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using my_orange_easyxls.Service;

namespace my_orange_easyxls.Service
{
    public class OrgDataService
    {


        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<OrgDataService> _logger;
        
        public OrgDataService(MyOrangePMPProjectContext context, ILogger<OrgDataService> logger
            )
        {

            _context = context;
            _logger = logger;
            
        }

       public bool Save2(List<Org_dataDTO> lstData )
        {

            if (lstData!=null && lstData.Count > 0)
            {

                List<Org_data> lstModels = new List<Org_data>();
                int i = 0;
                //002 再保存
                foreach(var p in lstData)
                {
                    var data = new Org_data();
                    _context.Entry(data).CurrentValues.SetValues(p);
                    lstModels.Add(data);
                    if (i % 50 == 0 && i>50)
                    {
                        _context.OrgData.AddRange(lstModels);
                         _context.SaveChanges();
                        lstModels.Clear();
                    }

                    i = i++;

                }

                if (lstModels.Count > 0)
                {
                    _context.OrgData.AddRange(lstModels);
                     _context.SaveChanges();
                }

  

            }

            return true ;


        }
        public async Task<bool> Save(List<Org_dataDTO> lstData )
        {

            if (lstData!=null && lstData.Count > 0)
            {

                List<Org_data> lstModels = new List<Org_data>();
                int i = 0;
                //002 再保存
                foreach(var p in lstData)
                {
                    var data = new Org_data();
                    _context.Entry(data).CurrentValues.SetValues(p);
                    lstModels.Add(data);
                    if (i % 50 == 0 && i>50)
                    {
                        _context.OrgData.AddRange(lstModels);
                        await _context.SaveChangesAsync();
                        lstModels.Clear();
                    }

                    i = i++;

                }

                if (lstModels.Count > 0)
                {
                    _context.OrgData.AddRange(lstModels);
                    await _context.SaveChangesAsync();
                }

  

            }

            return true ;


        }
        /// <summary>
        /// 保存数据，如果id为0则新增，不为0则更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Save(Org_dataDTO p)
        {

            var data = p.Id == 0 ? new Org_data() : await _context.OrgData.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime = DateTime.Now;

            _context.Entry(data).CurrentValues.SetValues(p);

            if (p.Id == 0) { _context.OrgData.Add(data); }

            await _context.SaveChangesAsync();
            return true;
        }


  

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Org_dataDTO p)
        {

            var project = await _context.OrgData.FindAsync(p.Id);

            if (project != null)
            {
                _context.OrgData.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<bool> DeleteAll(string dataDesc,string dataName)
        {
            string strSql = "delete from org_data where ";
            if (string.IsNullOrEmpty(dataDesc) == false)
            {
                strSql += " dataDesc='" + dataDesc + "' and ";
            }
            if (string.IsNullOrEmpty(dataName) == false)
            {
                strSql += " dataname='" + dataName + "' and ";
            }
            strSql += " Id>0";
            await _context.Database.ExecuteSqlRawAsync(strSql);
            return true;
        }

        public async Task<List<Org_dataDTO>> GetList()
        {

            var query = this.GetProjectQuery();
            var p = await query.ToListAsync<Org_dataDTO>();

            return p;
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<Org_dataDTO> GetSinger(int mId)
        {

            var query = this.GetProjectQuery();
            var p = await query.Where(x => x.Id == mId).FirstOrDefaultAsync();

            return p;
        }

        private IQueryable<Org_dataDTO> GetProjectQuery()
        {

            return _context.OrgData.Select(
                     x => new Org_dataDTO
                     {
                         Id          = x.Id,              
                         Createtime  = x.Createtime,                      
                         State       = x.State,
                         Dataname  = x.Dataname,
                         Datadesc = x.Datadesc,
                         Field1 = x.Field1,
                        Field2 = x.Field2,
                        Field3 = x.Field3,
                        Field4 = x.Field4,
                        Field5 = x.Field5,
                        Field6 = x.Field6,
                        Field7 = x.Field7,
                        Field8 = x.Field8,
                        Field9 = x.Field9,
                        Field10 = x.Field10,
                        Field11 = x.Field11,
                        Field12 = x.Field12,
                        Field13 = x.Field13,
                        Field14 = x.Field14,
                        Field15 = x.Field15,
                        Field16 = x.Field16,
                        Field17 = x.Field17,
                        Field18 = x.Field18,
                        Field19 = x.Field19,
                        Field20 = x.Field20,
                        Field21 = x.Field21,
                         Field22 = x.Field22,
                         Field23 = x.Field23,
                         Field24 = x.Field24,
                         Field25 = x.Field25,
                         Field26 = x.Field26,
                         Field27 = x.Field27,
                         Field28 = x.Field28,
                         Field29 = x.Field29,
                         Field30 = x.Field30,
                         Field31 = x.Field31,
                         Field32 = x.Field32,
                         Field33 = x.Field33,
                         Field34 = x.Field34,
                         Field35 = x.Field35,
                         Field36 = x.Field36,
                         Field37 = x.Field37,
                         Field38 = x.Field38,
                         Field39 = x.Field39,
                         Field40 = x.Field40,
                         Field41 = x.Field41,
                         Field42 = x.Field42,
                         Field43 = x.Field43,
                         Field44 = x.Field44,
                         Field45 = x.Field45,
                         Field46 = x.Field46,
                         Field47 = x.Field47,
                         Field48 = x.Field48,
                         Field49 = x.Field49,
                         Field50 = x.Field50,
                         Field51 = x.Field51,
                         Field52 = x.Field52,
                         Field53 = x.Field53,
                         Field54 = x.Field54,
                         Field55 = x.Field55,
                         Field56 = x.Field56,
                         Field57 = x.Field57,
                         Field58 = x.Field58,
                         Field59 = x.Field59,
                         Field60 = x.Field60,
                         Field61 = x.Field61,
                         Field62 = x.Field62,
                         Field63 = x.Field63,
                         Field64 = x.Field64,
                         Field65 = x.Field65,
                         Field66 = x.Field66,
                         Field67 = x.Field67,
                         Field68 = x.Field68,
                         Field69 = x.Field69,
                         Field70 = x.Field70,
                         Field71 = x.Field71,
                         Field72 = x.Field72,
                         Field73 = x.Field73,
                         Field74 = x.Field74,
                         Field75 = x.Field75,
                         Field76 = x.Field76,
                         Field77 = x.Field77,
                         Field78 = x.Field78,
                         Field79 = x.Field79,
                         Field80 = x.Field80,
                         Field81 = x.Field81,
                         Field82 = x.Field82,
                         Field83 = x.Field83,
                         Field84 = x.Field84,
                         Field85 = x.Field85,
                         Field86 = x.Field86,
                         Field87 = x.Field87,
                         Field88 = x.Field88,
                         Field89 = x.Field89,
                         Field90 = x.Field90,
                         Field91 = x.Field91,
                         Field92 = x.Field92,
                         Field93 = x.Field93,
                         Field94 = x.Field94,
                         Field95 = x.Field95,
                         Field96 = x.Field96,
                         Field97 = x.Field97,
                         Field98 = x.Field98,
                         Field99 = x.Field99,
                         Field100 = x.Field100


                     }
                );


        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_dataDTO>>> GetList(SearchDTO searchDTO, int pageNumber)
        {
            IQueryable<Org_dataDTO> query = this.GetProjectQuery();

            string where = string.IsNullOrEmpty(searchDTO.SearchValue) ? "Id>0" : searchDTO.FieldName + ".contains(\"" + searchDTO.SearchValue + "\")";
            var q = query.Where(where);
            int totalCount = await q.CountAsync();
            int skip = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<Org_dataDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


        }

        private string GetContiditon(string strValue,string strMark)
        {
            string where = "";
            if (  strMark.IndexOf("contains") > -1)
            {
                where =  ".contains(\"" + strValue + "\") and ";
                this._logger.LogInformation("This is Test strValue:"+strValue+",strMark:"+strMark);
                return where ;
            }
            if (strMark.IndexOf("in") > -1)
            {
                strValue = strValue.IndexOf(",")>0?strValue.Replace(",","\",\""):strValue;
                where =  " "+ strMark+" (\"" + strValue + "\") and ";
                this._logger.LogInformation("This is Test strValue:"+strValue+",strMark:"+strMark);
                return where ;
            }

            where =  " "+strMark+"\"" + strValue + "\" and ";
            this._logger.LogInformation("This is Test strValue:"+strValue+",strMark:"+strMark);
            return where ;

        }

        private string GetWhereFromSearchDTOs(SearchDTO[] searchDTO)
        {
            string where = "";
            int i        = 1;
            foreach(var s  in searchDTO)
            {
                if (!string.IsNullOrEmpty(s.FieldName)
                    && !string.IsNullOrEmpty(s.SearchValue))
                {
                    where += s.FieldName + this.GetContiditon(s.SearchValue,s.Condition)  ;
                }

                i = i + 1;

            }

            return where;



        }

        private IQueryable<Org_dataDTO> GetJoin(IQueryable<Org_dataDTO> q, IQueryable<Org_dataDTO> q2,string leftFieldNameValue,
            string leftOutFieldNameValue)
        {
            switch (leftFieldNameValue)
            {
                case "Field2":
                    return from a in q
                           join b in q2
                           on a.Field2 equals b.Field1
                           select a;
                case "Field3":
                    return from a in q
                           join b in q2
                           on a.Field3 equals b.Field1
                           select a;
                case "Field4":
                    return from a in q
                           join b in q2
                           on a.Field4 equals b.Field1
                           select a;
                case "Field5":
                    return from a in q
                           join b in q2
                           on a.Field5 equals b.Field1
                           select a;
                case "Field6":
                    return from a in q
                           join b in q2
                           on a.Field6 equals b.Field1
                           select a;
                case "Field7":
                    return from a in q
                           join b in q2
                           on a.Field7 equals b.Field1
                           select a;
                case "Field8":
                    return from a in q
                           join b in q2
                           on a.Field8 equals b.Field1
                           select a;
                case "Field9":
                    return from a in q
                           join b in q2
                           on a.Field9 equals b.Field1
                           select a;
                case "Field10":
                    return from a in q
                           join b in q2
                           on a.Field10 equals b.Field1
                           select a;
                case "Field11":
                    return from a in q
                           join b in q2
                           on a.Field11 equals b.Field1
                           select a;
                case "Field12":
                    return from a in q
                           join b in q2
                           on a.Field12 equals b.Field1
                           select a;
                case "Field13":
                    return from a in q
                           join b in q2
                           on a.Field13 equals b.Field1
                           select a;
                case "Field14":
                    return from a in q
                           join b in q2
                           on a.Field14 equals b.Field1
                           select a;
                case "Field15":
                    return from a in q
                           join b in q2
                           on a.Field15 equals b.Field1
                           select a;
                case "Field16":
                    return from a in q
                           join b in q2
                           on a.Field16 equals b.Field1
                           select a;
                case "Field17":
                    return from a in q
                           join b in q2
                           on a.Field17 equals b.Field1
                           select a;
                case "Field18":
                    return from a in q
                           join b in q2
                           on a.Field18 equals b.Field1
                           select a;
                case "Field19":
                    return from a in q
                           join b in q2
                           on a.Field19 equals b.Field1
                           select a;
                case "Field20":
                    return from a in q
                           join b in q2
                           on a.Field20 equals b.Field1
                           select a;
                case "Field21":
                    return from a in q
                           join b in q2
                           on a.Field21 equals b.Field1
                           select a;
                case "Field22":
                    return from a in q
                           join b in q2
                           on a.Field22 equals b.Field1
                           select a;
                case "Field23":
                    return from a in q
                           join b in q2
                           on a.Field23 equals b.Field1
                           select a;
                case "Field24":
                    return from a in q
                           join b in q2
                           on a.Field24 equals b.Field1
                           select a;
                case "Field25":
                    return from a in q
                           join b in q2
                           on a.Field25 equals b.Field1
                           select a;
                case "Field26":
                    return from a in q
                           join b in q2
                           on a.Field26 equals b.Field1
                           select a;
                case "Field27":
                    return from a in q
                           join b in q2
                           on a.Field27 equals b.Field1
                           select a;
                case "Field28":
                    return from a in q
                           join b in q2
                           on a.Field28 equals b.Field1
                           select a;
                case "Field29":
                    return from a in q
                           join b in q2
                           on a.Field29 equals b.Field1
                           select a;
                case "Field30":
                    return from a in q
                           join b in q2
                           on a.Field30 equals b.Field1
                           select a;
                case "Field31":
                    return from a in q
                           join b in q2
                           on a.Field31 equals b.Field1
                           select a;
                case "Field32":
                    return from a in q
                           join b in q2
                           on a.Field32 equals b.Field1
                           select a;
                case "Field33":
                    return from a in q
                           join b in q2
                           on a.Field33 equals b.Field1
                           select a;
                case "Field34":
                    return from a in q
                           join b in q2
                           on a.Field34 equals b.Field1
                           select a;
                case "Field35":
                    return from a in q
                           join b in q2
                           on a.Field35 equals b.Field1
                           select a;
                case "Field36":
                    return from a in q
                           join b in q2
                           on a.Field36 equals b.Field1
                           select a;
                case "Field37":
                    return from a in q
                           join b in q2
                           on a.Field37 equals b.Field1
                           select a;
                case "Field38":
                    return from a in q
                           join b in q2
                           on a.Field38 equals b.Field1
                           select a;
                case "Field39":
                    return from a in q
                           join b in q2
                           on a.Field39 equals b.Field1
                           select a;
                case "Field40":
                    return from a in q
                           join b in q2
                           on a.Field40 equals b.Field1
                           select a;
                case "Field41":
                    return from a in q
                           join b in q2
                           on a.Field41 equals b.Field1
                           select a;
                case "Field42":
                    return from a in q
                           join b in q2
                           on a.Field42 equals b.Field1
                           select a;
                case "Field43":
                    return from a in q
                           join b in q2
                           on a.Field43 equals b.Field1
                           select a;
                case "Field44":
                    return from a in q
                           join b in q2
                           on a.Field44 equals b.Field1
                           select a;
                case "Field45":
                    return from a in q
                           join b in q2
                           on a.Field45 equals b.Field1
                           select a;
                case "Field46":
                    return from a in q
                           join b in q2
                           on a.Field46 equals b.Field1
                           select a;
                case "Field47":
                    return from a in q
                           join b in q2
                           on a.Field47 equals b.Field1
                           select a;
                case "Field48":
                    return from a in q
                           join b in q2
                           on a.Field48 equals b.Field1
                           select a;
                case "Field49":
                    return from a in q
                           join b in q2
                           on a.Field49 equals b.Field1
                           select a;
                case "Field50":
                    return from a in q
                           join b in q2
                           on a.Field50 equals b.Field1
                           select a;
                case "Field51":
                    return from a in q
                           join b in q2
                           on a.Field51 equals b.Field1
                           select a;
                case "Field52":
                    return from a in q
                           join b in q2
                           on a.Field52 equals b.Field1
                           select a;
                case "Field53":
                    return from a in q
                           join b in q2
                           on a.Field53 equals b.Field1
                           select a;
                case "Field54":
                    return from a in q
                           join b in q2
                           on a.Field54 equals b.Field1
                           select a;
                case "Field55":
                    return from a in q
                           join b in q2
                           on a.Field55 equals b.Field1
                           select a;
                case "Field56":
                    return from a in q
                           join b in q2
                           on a.Field56 equals b.Field1
                           select a;
                case "Field57":
                    return from a in q
                           join b in q2
                           on a.Field57 equals b.Field1
                           select a;
                case "Field58":
                    return from a in q
                           join b in q2
                           on a.Field58 equals b.Field1
                           select a;
                case "Field59":
                    return from a in q
                           join b in q2
                           on a.Field59 equals b.Field1
                           select a;
                case "Field60":
                    return from a in q
                           join b in q2
                           on a.Field60 equals b.Field1
                           select a;
                case "Field61":
                    return from a in q
                           join b in q2
                           on a.Field61 equals b.Field1
                           select a;
                case "Field62":
                    return from a in q
                           join b in q2
                           on a.Field62 equals b.Field1
                           select a;
                case "Field63":
                    return from a in q
                           join b in q2
                           on a.Field63 equals b.Field1
                           select a;
                case "Field64":
                    return from a in q
                           join b in q2
                           on a.Field64 equals b.Field1
                           select a;
                case "Field65":
                    return from a in q
                           join b in q2
                           on a.Field65 equals b.Field1
                           select a;
                case "Field66":
                    return from a in q
                           join b in q2
                           on a.Field66 equals b.Field1
                           select a;
                case "Field67":
                    return from a in q
                           join b in q2
                           on a.Field67 equals b.Field1
                           select a;
                case "Field68":
                    return from a in q
                           join b in q2
                           on a.Field68 equals b.Field1
                           select a;
                case "Field69":
                    return from a in q
                           join b in q2
                           on a.Field69 equals b.Field1
                           select a;
                case "Field70":
                    return from a in q
                           join b in q2
                           on a.Field70 equals b.Field1
                           select a;
                case "Field71":
                    return from a in q
                           join b in q2
                           on a.Field71 equals b.Field1
                           select a;
                case "Field72":
                    return from a in q
                           join b in q2
                           on a.Field72 equals b.Field1
                           select a;
                case "Field73":
                    return from a in q
                           join b in q2
                           on a.Field73 equals b.Field1
                           select a;
                case "Field74":
                    return from a in q
                           join b in q2
                           on a.Field74 equals b.Field1
                           select a;
                case "Field75":
                    return from a in q
                           join b in q2
                           on a.Field75 equals b.Field1
                           select a;
                case "Field76":
                    return from a in q
                           join b in q2
                           on a.Field76 equals b.Field1
                           select a;
                case "Field77":
                    return from a in q
                           join b in q2
                           on a.Field77 equals b.Field1
                           select a;
                case "Field78":
                    return from a in q
                           join b in q2
                           on a.Field78 equals b.Field1
                           select a;
                case "Field79":
                    return from a in q
                           join b in q2
                           on a.Field79 equals b.Field1
                           select a;
                case "Field80":
                    return from a in q
                           join b in q2
                           on a.Field80 equals b.Field1
                           select a;
                case "Field81":
                    return from a in q
                           join b in q2
                           on a.Field81 equals b.Field1
                           select a;
                case "Field82":
                    return from a in q
                           join b in q2
                           on a.Field82 equals b.Field1
                           select a;
                case "Field83":
                    return from a in q
                           join b in q2
                           on a.Field83 equals b.Field1
                           select a;
                case "Field84":
                    return from a in q
                           join b in q2
                           on a.Field84 equals b.Field1
                           select a;
                case "Field85":
                    return from a in q
                           join b in q2
                           on a.Field85 equals b.Field1
                           select a;
                case "Field86":
                    return from a in q
                           join b in q2
                           on a.Field86 equals b.Field1
                           select a;
                case "Field87":
                    return from a in q
                           join b in q2
                           on a.Field87 equals b.Field1
                           select a;
                case "Field88":
                    return from a in q
                           join b in q2
                           on a.Field88 equals b.Field1
                           select a;
                case "Field89":
                    return from a in q
                           join b in q2
                           on a.Field89 equals b.Field1
                           select a;
                case "Field90":
                    return from a in q
                           join b in q2
                           on a.Field90 equals b.Field1
                           select a;
                case "Field91":
                    return from a in q
                           join b in q2
                           on a.Field91 equals b.Field1
                           select a;
                case "Field92":
                    return from a in q
                           join b in q2
                           on a.Field92 equals b.Field1
                           select a;
                case "Field93":
                    return from a in q
                           join b in q2
                           on a.Field93 equals b.Field1
                           select a;
                case "Field94":
                    return from a in q
                           join b in q2
                           on a.Field94 equals b.Field1
                           select a;
                case "Field95":
                    return from a in q
                           join b in q2
                           on a.Field95 equals b.Field1
                           select a;
                case "Field96":
                    return from a in q
                           join b in q2
                           on a.Field96 equals b.Field1
                           select a;
                case "Field97":
                    return from a in q
                           join b in q2
                           on a.Field97 equals b.Field1
                           select a;
                case "Field98":
                    return from a in q
                           join b in q2
                           on a.Field98 equals b.Field1
                           select a;
                case "Field99":
                    return from a in q
                           join b in q2
                           on a.Field99 equals b.Field1
                           select a;
                case "Field100":
                    return from a in q
                           join b in q2
                           on a.Field100 equals b.Field1
                           select a;
                default:
                    return from a in q
                           join b in q2
                           on a.Field1 equals b.Field1
                           select a;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_dataDTO>>> GetList(String dataDesc, string dataName,
            SearchDTO[] searchDTO,
            int pageNumber,string leftDataDesc,string leftDataName,string leftFieldNameValue,string leftOutFieldNameValue)
        {

            if (string.IsNullOrEmpty(leftDataDesc)
                 || string.IsNullOrEmpty(leftFieldNameValue)
                 || string.IsNullOrEmpty(leftOutFieldNameValue))
            {

                return await GetList(dataDesc, dataName, searchDTO, pageNumber);
            }
            //001 拼凑查询条件
            IQueryable<Org_dataDTO> query  = this.GetProjectQuery();
            string where                   =  this.GetWhere(dataDesc, dataName, searchDTO);      
            var q                          = query.Where(where);

            IQueryable<Org_dataDTO> query2 = this.GetProjectQuery();
            var q2                         = query2.Where("Datadesc=\"" + leftDataDesc + "\" and " + "Dataname=\"" + leftDataName + "\" ");
            string where2                  = "Datadesc='" + leftDataDesc + "' and " + "Dataname='" + leftDataName + "'";
            var lstAll                     = this.GetJoin(q, q2, leftFieldNameValue, leftOutFieldNameValue);

            //002获取数据
            int totalCount                 = await lstAll.CountAsync();
            int skip                       = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst                        = await lstAll.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync<Org_dataDTO>();
            var pageHtml                   = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO            = new SearchResultDTO<List<Org_dataDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;

    
        }

        private string  GetWhere(string dataDesc, string dataName, SearchDTO[] searchDTO)
        {
            string where = "";
            if (string.IsNullOrEmpty(dataName) && string.IsNullOrEmpty(dataDesc))
            {
                where = " Id>0";
            }
            else
            {
                if (!string.IsNullOrEmpty(dataDesc))
                {
                    where = "Datadesc=\"" + dataDesc + "\" and ";
                }
                if (!string.IsNullOrEmpty(dataName))
                {
                    where += "Dataname=\"" + dataName + "\" and ";
                }

                where += this.GetWhereFromSearchDTOs(searchDTO);

                where += " Id>0";
            }

            return where;
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_dataDTO>>> GetList(String dataDesc,string dataName,
            SearchDTO[] searchDTO,
            int pageNumber)
        {
            IQueryable<Org_dataDTO> query = this.GetProjectQuery();
            string where                  = this.GetWhere(dataDesc, dataName, searchDTO);
            var q                         = query.Where(where);
            int totalCount                = await q.CountAsync();
            int skip                      = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst                       = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml                  = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);
            var searchResultDTO           = new SearchResultDTO<List<Org_dataDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<List<Org_dataDTO>> GetAllList(String dataDesc, string dataName,
            SearchDTO[] searchDTO)
        {
            IQueryable<Org_dataDTO> query = this.GetProjectQuery();
            string where    = this.GetWhere(dataDesc, dataName, searchDTO);
            var q           = query.Where(where);
            var lst         = await q.OrderByDescending(x => x.Id).ToListAsync();
            return lst;


        }

        /// <summary>
        /// 获取查询数据
        /// </summary>
        /// <param name="dataDesc"></param>
        /// <param name="dataName"></param>
        /// <param name="searchDTO"></param>
        /// <param name="leftDataDesc"></param>
        /// <param name="leftDataName"></param>
        /// <param name="leftFieldNameValue"></param>
        /// <param name="leftOutFieldNameValue"></param>
        /// <returns></returns>
        public async Task<List<Org_dataDTO>> GetAllList(String dataDesc, string dataName,
            SearchDTO[] searchDTO,string leftDataDesc, string leftDataName, string leftFieldNameValue, string leftOutFieldNameValue)
        {
            if (string.IsNullOrEmpty(leftDataDesc)
           || string.IsNullOrEmpty(leftFieldNameValue)
           || string.IsNullOrEmpty(leftOutFieldNameValue))
            {

                return await GetAllList(dataDesc, dataName, searchDTO);
            }

            IQueryable<Org_dataDTO> query = this.GetProjectQuery();
            string where                  = this.GetWhere(dataDesc, dataName, searchDTO);

            var q                         = query.Where(where);
            IQueryable<Org_dataDTO> query2 = this.GetProjectQuery();
            var q2                        = query2.Where("Datadesc=\"" + leftDataDesc + "\" and " + "Dataname=\"" + leftDataName + "\" ");
            string where2                 = "Datadesc='" + leftDataDesc + "' and " + "Dataname='" + leftDataName + "'";

            var lstAll = this.GetJoin(q, q2, leftFieldNameValue, leftOutFieldNameValue);
            var lst = await lstAll.OrderByDescending(x => x.Id).ToListAsync<Org_dataDTO>();

            return lst;

        }

        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_dataDTO>>> GetList(String name)
        {

            return await this.GetList(new SearchDTO() { FieldName = "name", SearchValue = name }, 1);

        }



    }
}