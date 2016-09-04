using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AmeriaPaymentTest.AmeriaVposService;

namespace AmeriaPaymentTest
{
    public partial class back : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["orderid"] != null && Request.Params["respcode"] != null && Request.Params["paymentid"] != null)
            {
                AmeriaClient am = new AmeriaClient();
                //http://localhost:31916 https://testpayments.ameriabank.am
                //https://newtestpayments.ameriabank.am
                ltResult.Text = @"<iframe id=" + "\"idIframe\" src=\"https://testpayments.ameriabank.am/forms/frm_checkprint.aspx?lang=am&paymentid=" + Request.Params["paymentid"].ToString() + "\" width=\"560px\" height=\"820px\" frameborder=\"0\"></iframe>";
            }
        }
    }
}