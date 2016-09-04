using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Security;
using AmeriaPaymentTest.AmeriaVposService;
using System.Configuration;
using System.Web.Script.Serialization;

namespace AmeriaPaymentTest
{
    public partial class _Default : System.Web.UI.Page
    {
        private string AmeriaClinetID
        {
            get
            {
                return ConfigurationManager.AppSettings["AmeriaClientID"].ToString();
            }
        }

        private string UserName
        {
            get
            {
                return ConfigurationManager.AppSettings["AmeriaUserName"].ToString();
            }
        }

        private string UserPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["AmeriaUserPassword"].ToString();
            }
        }

        private AmeriaClient p = new AmeriaClient();

        private PaymentClientClass AmeriaPaymentFields
        {
            get
            {
                PaymentClientClass pc = new PaymentClientClass();
                pc.ClientID = AmeriaClinetID; // Get from Web.Config
                pc.OrderID = Convert.ToInt32(txtOrderID.Text); // order ID should be unique
                pc.Password = UserPassword;// Get from Web.Config
                pc.Username = UserName;// Get from Web.Config
                pc.PaymentAmount = Convert.ToDecimal(txtAmount.Text); // In TestMode amount should be less than 10 
                pc.backURL = "http://" + Request.Url.Authority + "/back.aspx"; // specify your backURL

                return pc;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtAmount.Text = 10.ToString();
                txtOrderID.Text = 50001.ToString();
            }
        }

        protected void btnExecTransaction_Click(object sender, EventArgs e)
        {
            ResultPaymentClass pf = p.GetPaymentID(AmeriaPaymentFields);
            Response.Redirect("https://testpayments.ameriabank.am/forms/frm_paymentstype.aspx?paymentid=" + pf.PaymentID + "&clientid=7030b78e-7630-42c0-af48-3b1998f1da29&clienturl=asa&lang=en");
        }

        protected void btnConfirmTransaction_Click(object sender, EventArgs e)
        {
            RespMessage rm = p.Confirmation(AmeriaPaymentFields);
            ltMessage.Text = "RespMessage:" + rm.Respmessage + "|" + " RespCode:" + rm.Respcode;
        }

        protected void btnReverseTransaction_Click(object sender, EventArgs e)
        {
            RespMessage rm = p.ReversePayment(AmeriaPaymentFields);
            ltMessage.Text = "RespMessage:" + rm.Respmessage + "|" + " RespCode:" + rm.Respcode;
        }

        protected void btnRefundTransaction_Click(object sender, EventArgs e)
        {
            RespMessage rm = p.Refund(AmeriaPaymentFields);
            ltMessage.Text = "RespMessage:" + rm.Respmessage + "|" + " RespCode:" + rm.Respcode;
        }

        protected void btnGetPaymentFields_Click(object sender, EventArgs e)
        {
            PaymentFields pf = new PaymentFields();
            pf = p.GetPaymentFields(AmeriaPaymentFields);
            ltMessage.Text = new JavaScriptSerializer().Serialize(pf).ToString(); 
        }
    }
}
