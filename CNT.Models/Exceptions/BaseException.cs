using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CNT.Models.Exceptions
{
    public class BaseException:ApplicationException
    {
        public BaseException(string Mes):base(Mes)
        {
            LogError(base.Message);
        }

        public void LogError(string error)
        {
            try
            {
                if (error == "There is no record available") { }
                else if (error == "There are no relevant records available") { }
                else
                {
                    //string path = HttpContext.Current.Server.MapPath("~/Log/LogErrors.txt");
                    //System.IO.File.AppendAllLines(path, new List<string> { DateTime.Now.ToString() + " - " + error });
                }
            }
            catch (Exception ex) { }
        }
    }
}
