using lwm.Common;
using System;
using System.Web.Services;
using System.Web.UI;

namespace lwm.Web
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static DTOMapPoint InsertPoint(DTOMapPoint DTOMapPoint)
        {
            try {

                DTOMapPoint.ResultCode = 200;
                DTOMapPoint.ResultMessage = "OK!";
            } catch(Exception ex) {
                DTOMapPoint.ResultCode = 400;
                DTOMapPoint.ResultMessage = ex.ToString();
            }
            return DTOMapPoint;
        }
    }
}