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
    public class OrgFileService
    {


        private readonly MyOrangePMPProjectContext _context;
        private readonly ILogger<OrgFileService> _logger;
        
        public OrgFileService(MyOrangePMPProjectContext context, ILogger<OrgFileService> logger
            )
        {

            _context = context;
            _logger = logger;
            
        }

        public async Task<bool> Save(List<FileDTO> lstFile)
        {

            if (lstFile!=null && lstFile.Count > 0)
            {
              
                //002 再保存
                foreach(var fileDTO in lstFile)
                {

                    await this.Save(

                              new Org_fileDTO()
                              {
                                  Id = 0,                               
                                  Filename = fileDTO.Filename,
                                  FileUrl = fileDTO.FileUrl,
                                  
                              }

                             );

                }

            }

            return true ;


        }
        /// <summary>
        /// 保存数据，如果id为0则新增，不为0则更新
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Save(Org_fileDTO p)
        {

            var data = p.Id == 0 ? new Org_file() : await _context.OrgFile.FirstOrDefaultAsync(m => m.Id == p.Id); ;
            p.Createtime = DateTime.Now;

            _context.Entry(data).CurrentValues.SetValues(p);

            if (p.Id == 0) { _context.OrgFile.Add(data); }

            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Org_fileDTO p)
        {

            var project = await _context.OrgFile.FindAsync(p.Id);

            if (project != null)
            {
                _context.OrgFile.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<List<Org_fileDTO>> GetList()
        {

            var query = this.GetProjectQuery();
            var p = await query.ToListAsync<Org_fileDTO>();

            return p;
        }

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<Org_fileDTO> GetSinger(int mId)
        {

            var query = this.GetProjectQuery();
            var p = await query.Where(x => x.Id == mId).FirstOrDefaultAsync();

            return p;
        }

        private IQueryable<Org_fileDTO> GetProjectQuery()
        {

            return _context.OrgFile.Select(
                     x => new Org_fileDTO
                     {
                         Id         = x.Id,              
                         Createtime = x.Createtime,                      
                         State      = x.State,
                         Filename   = x.Filename,
                         FileUrl    = x.FileUrl
                       

                     }
                     );


        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="searchDTO">查询对象：字段名称和值</param>
        /// <param name="pageNumber">当前页码</param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_fileDTO>>> GetList(SearchDTO searchDTO, int pageNumber)
        {
            IQueryable<Org_fileDTO> query = this.GetProjectQuery();

            string where = string.IsNullOrEmpty(searchDTO.SearchValue) ? "Id>0" : searchDTO.FieldName + ".contains(\"" + searchDTO.SearchValue + "\")";
            var q = query.Where(where);
            int totalCount = await q.CountAsync();
            int skip = MyPage.GetSkip(pageNumber, MyPage.PageSize);
            var lst = await q.OrderByDescending(x => x.Id).Skip(skip).Take(MyPage.PageSize).ToListAsync();
            var pageHtml = MyPage.GetSplitPageHtml(totalCount, pageNumber, MyPage.PageSize);

            var searchResultDTO = new SearchResultDTO<List<Org_fileDTO>>(lst, pageHtml, totalCount);

            this._logger.LogInformation("This is Test");

            return searchResultDTO;


        }

        /// <summary>
        /// 根据名称获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SearchResultDTO<List<Org_fileDTO>>> GetList(String name)
        {

            return await this.GetList(new SearchDTO() { FieldName = "name", SearchValue = name }, 1);

        }



    }
}
