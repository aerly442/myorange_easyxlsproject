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

        public async Task<bool> Save(List<Org_dataDTO> lstFile )
        {

            if (lstFile!=null && lstFile.Count > 0)
            {
              
                //002 再保存
                foreach(var f in lstFile)
                {

                    await this.Save(f);

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

        public async Task<bool> DeleteAll()
        {
            await _context.Database.ExecuteSqlRawAsync("delete from org_data");
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
            if (string.IsNullOrEmpty(strMark) || 
                strMark.IndexOf("contains") > -1)
            {
                return ".contains(\"" + strValue + "\") and ";
            }

            return " "+strMark+"\"" + strValue + "\" and ";

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
            var q = query.Where(where);
            int totalCount = await q.CountAsync();
            int skip = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<Org_dataDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


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