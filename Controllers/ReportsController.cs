using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolicyBazar.Models;

namespace PolicyBazar.Controllers
{
    public class ReportsController : Controller
    {
        #region Declaration
        #endregion

        #region Reports
        [HttpGet]
        public ActionResult Reports()
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    ViewBag.Message = "Your contact page.";
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Authentication");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Authentication");
            }
        }

        [HttpPost]
        public JsonResult GetPolicybyAgent()
        {
            ClsResGetAllAgentpolicy ObjClsResGetAllAgentpolicy = new ClsResGetAllAgentpolicy();
            try
            {
                ClsDataMaster clsDAL = new ClsDataMaster();
                ObjClsResGetAllAgentpolicy = clsDAL.GetAllAgentDetails();
                if (ObjClsResGetAllAgentpolicy.ErrorCode == "1")
                {
                    ViewBag.Message = "Data Checked.!!";
                }
            }
            catch (Exception ex)
            {
                ObjClsResGetAllAgentpolicy.ErrorCode = "-1";
                ObjClsResGetAllAgentpolicy.ErrorDescription = ex.Message;
            }
            return Json(ObjClsResGetAllAgentpolicy, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetAgentCommission()
        {
            ClsResGetAllAgentCommission ObjClsResGetAllAgentCommission = new ClsResGetAllAgentCommission();
            try
            {
                ClsDataMaster clsDAL = new ClsDataMaster();
                ObjClsResGetAllAgentCommission = clsDAL.GetAllAgentCommission();
                if (ObjClsResGetAllAgentCommission.ErrorCode == "1")
                {
                    ViewBag.Message = "Data Checked.!!";
                }
            }
            catch (Exception ex)
            {
                ObjClsResGetAllAgentCommission.ErrorCode = "-1";
                ObjClsResGetAllAgentCommission.ErrorDescription = ex.Message;
            }
            return Json(ObjClsResGetAllAgentCommission, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
