﻿namespace my_orange_easyxls.DTO
{
    public class SearchConditionDTO
    {
        public string? Name { get; set; }
        /// <summary>
        /// 字段值
        /// </summary>
        public string? Mark { get; set; }


        /// <summary>
        /// 返回查询的条件
        /// </summary>
        /// <returns></returns>
        public static List<SearchConditionDTO> Get()
        {
            var lst = new List<SearchConditionDTO>() {
                      new SearchConditionDTO(){Name = "等于",Mark = "="},
                      new SearchConditionDTO(){Name = "大于",Mark = ">"},
                      new SearchConditionDTO(){Name = "小于",Mark = "<"},
                      new SearchConditionDTO(){Name = "包含(in)",Mark = "in"},
                      new SearchConditionDTO(){Name = "含有(contains)",Mark = "contains"},
                      new SearchConditionDTO(){Name = "不等于",Mark = "!="},
                      //new SearchConditionDTO(){Name = "不包含",Mark = "Except"},
                      new SearchConditionDTO(){Name = "不含有",Mark = "not contains"}
                     //new SearchConditionDTO(){Name = "长度等于",Mark = "length"}
                };

            return lst;
        }

        /// <summary>
        /// 返回外联的条件
        /// </summary>
        /// <returns></returns>
        public static List<SearchConditionDTO> GetOut()
        {
            var lst = new List<SearchConditionDTO>() {
                        new SearchConditionDTO(){Name = "在范围",Mark = "include"},
                        new SearchConditionDTO(){Name = "不在范围",Mark = "not include"
                      }
                       
                };

            return lst;
        }




    }

}
