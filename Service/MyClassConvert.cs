using System.Collections.Specialized;
using System.Reflection;

namespace my_orange_easyxls.Service
{
    public class MyClassConvert
    {

    
        /// <summary>
        /// 把同名属性值如果不为null和空的复制到目标对象去
        /// </summary>
        /// <param name="assamblyname"></param>
        /// <param name="source"></param>
        /// <param name="sourceClassName"></param>
        /// <param name="dest"></param>
        /// <param name="destClassName"></param>
        public static void setClassPropertyValueFromSourceToDest(
            object source,object dest
            )
        {
            try
            {
         
                PropertyInfo[] aryDest      = dest.GetType().GetProperties();
                //PropertyInfo[] arySource    = source.GetType().GetProperties();
                foreach (PropertyInfo p in aryDest)
                {
                    //01 获取目标对象的属性名称
                    string fieldname   = p.Name;
                    //02 获取同属性名称在源对象的值
                    object sourceValue = source.GetType().GetProperty(fieldname).GetValue(source,null); //getClassPropertyValue(arySource, fieldname, source);
                    //02 获取同属性名称在目标对象的值
                    object destValue   = p.GetValue(dest);

                    //03如果源值不为空，目标值为空或者两个不相等，则使用源值复制给目标对象
                    if (sourceValue != null && sourceValue.ToString() != ""
                         && (destValue == null || destValue.ToString() != sourceValue.ToString())
                        )
                    {
                        p.SetValue(dest, sourceValue);
                    }



                }
            }
            catch(Exception ex)
            {

            }

        }


        public static object setClassPropertyValueFromSourceToDest(string fieldName,
            string fieldValue,object dest
            )
        {
            try
            {
         
                Type type = dest.GetType();  
                PropertyInfo propertyInfo = type.GetProperty(fieldName);  
                if (propertyInfo != null && propertyInfo.CanWrite)  
                {  
                    // 设置属性值  
                    propertyInfo.SetValue(dest, fieldValue, null);  
                }              
                return dest;
            }
            catch(Exception ex)
            {
                return dest;
            }

        }

    

  
    }
}