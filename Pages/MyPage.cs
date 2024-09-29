using System.Text;

namespace my_orange_easyxls.Models
{
    public class MyPage
    {
        /// <summary>
        /// 每页记录数
        /// </summary>
        public static int PageSize = 5;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int GetSkip(int page,int pageSize)
        {
            if (page <= 1)
            {
                return 0;
            }
            else
            {
                return (page - 1) * pageSize;
            }

        }
        /// <summary>
        /// 获取分页HTML代码
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static string GetSplitPageHtml(int totalCount, int page=1, int pageSize=4)
        {
            //21 ,4
            int maxPages = 5;

            if (pageSize >= totalCount)
            {
                return "";
            }

            int totalPage = totalCount % pageSize == 0 ? totalCount / pageSize : totalCount / pageSize + 1;
            StringBuilder sb = new StringBuilder();
            //上页




            page = page < 1 ? 1 : page;
            string preClass = page<=1?"disabled":"";
            sb.AppendFormat(@"<li class=""{0}""><a  data-pageNumber={1} href = ""javascript:void(0);"" >上页</a></li>", preClass,page-1);
            
            int startIndex = page< maxPages?1:(page % maxPages*maxPages);
            string nextClass = "";
            for (int i = startIndex; i< (startIndex+maxPages); i++)
            {
             
                if (i > totalPage)
                {
                    nextClass = "disabled";
                    break;
                }
                string pageNumber = i.ToString();
                string className  = pageNumber==page.ToString()? "active":"";

                sb.AppendFormat(@"<li class=""{0}""><a data-pageNumber={2} href = ""javascript:void(0);"" >{1}</a></li>", className, pageNumber, pageNumber);
            }
            
            sb.AppendFormat(@"<li  class=""{0}""><a  data-pageNumber={1} href = ""javascript:void(0);"" >下页</a></li>", nextClass,page+1);

            return sb.ToString();


        }
    }
}
