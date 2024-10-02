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
    public class OrgFieldService
    {


        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<OrgFieldService> _logger;
        
        public OrgFieldService(MyOrangePMPProjectContext context, ILogger<OrgFieldService> logger
            )
        {

            _context = context;
            _logger = logger;
            
        }

        public async Task<bool> Save(List<Org_fieldDTO> lstFile)
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
        public async Task<bool> Save(Org_fieldDTO p)
        {

            var data = p.Id == 0 ? new Org_field() : await _context.OrgField.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime = DateTime.Now;

            _context.Entry(data).CurrentValues.SetValues(p);

            if (p.Id == 0) { _context.OrgField.Add(data); }

            await _context.SaveChangesAsync();
            return true;
        }


  

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Org_fieldDTO p)
        {

            var project = await _context.OrgField.FindAsync(p.Id);

            if (project != null)
            {
                _context.OrgField.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<List<Org_fieldDTO>> GetList()
        {

            var query = this.GetProjectQuery();
            var p = await query.ToListAsync<Org_fieldDTO>();

            return p;
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<Org_fieldDTO> GetSinger(int mId)
        {

            var query = this.GetProjectQuery();
            var p = await query.Where(x => x.Id == mId).FirstOrDefaultAsync();

            return p;
        }

        private IQueryable<Org_fieldDTO> GetProjectQuery()
        {

            return _context.OrgField.Select(
                     x => new Org_fieldDTO
                     {
                         Id          = x.Id,              
                         Createtime  = x.Createtime,                      
                         State       = x.State,
                         Fieldnum    = x.Fieldnum,
                         Fieldname   = x.Fieldname,
                         Org_fileid  = x.Org_fileid,
                         Dataname    = x.Dataname,
                         Datadesc    = x.Datadesc

                     }
                     );


        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_fieldDTO>>> GetList(SearchDTO searchDTO, int pageNumber)
        {
            IQueryable<Org_fieldDTO> query = this.GetProjectQuery();

            string where = string.IsNullOrEmpty(searchDTO.SearchValue) ? "Id>0" : searchDTO.FieldName + ".contains(\"" + searchDTO.SearchValue + "\")";
            var q = query.Where(where);
            int totalCount = await q.CountAsync();
            int skip = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<Org_fieldDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


        }

        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_fieldDTO>>> GetList(String name)
        {

            return await this.GetList(new SearchDTO() { FieldName = "name", SearchValue = name }, 1);

        }

        public async Task<bool> DeleteAll()
        {
            await _context.Database.ExecuteSqlRawAsync("delete from org_field");
            return true;
        }

        public async Task<List<string>> GetDatadesc()
        {
            List<string> lst = await _context.OrgField.Select(x => x.Datadesc).Distinct().ToListAsync();
            return lst;

        }
        public async Task<List<string>> GetDataname(string dataDesc)
        {
            List<string> lst = await _context.OrgField.Where(x=>x.Datadesc==dataDesc).Select(x => x.Dataname).Distinct().ToListAsync();
            return lst;

        }

        public async Task<List<string>> GetFieldname(string dataName,string dataDesc)
        {
            List<string> lst = await _context.OrgField.Where(x => x.Datadesc == dataDesc && x.Dataname == dataName).Select(x => x.Fieldname).Distinct().ToListAsync();
            return lst;

        }


    }
}
