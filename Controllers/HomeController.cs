using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolicyBazar.Models;

namespace PolicyBazar.Controllers
{
    public class HomeController : Controller
    {
        #region Declaration

        #endregion

        #region SaveDetails
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (Session["UserID"] != null)
                {
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
        public JsonResult AddPolicyData(ClsReqPolicyDetails ObjPolicyDetails)
        {
            ClsResGetAllMaster obj = new ClsResGetAllMaster();
            try
            {
                if (ObjPolicyDetails.AgentNo != null && ObjPolicyDetails.PolicyNo != null && ObjPolicyDetails.SchemeNo != null && ObjPolicyDetails.CustomerName != null && ObjPolicyDetails.Commission != null)
                {
                    ClsReqPolicyDetails ObjClsReqPolicyDetails = new ClsReqPolicyDetails();
                    ObjClsReqPolicyDetails.AgentNo = ObjPolicyDetails.AgentNo;
                    ObjClsReqPolicyDetails.PolicyNo = ObjPolicyDetails.PolicyNo;
                    ObjClsReqPolicyDetails.SchemeNo = ObjPolicyDetails.SchemeNo;
                    ObjClsReqPolicyDetails.Commission = Convert.ToDecimal(ObjPolicyDetails.Commission);
                    ObjClsReqPolicyDetails.CustomerName = ObjPolicyDetails.CustomerName;
                    ObjClsReqPolicyDetails.Date = ObjPolicyDetails.Date;
                    ObjClsReqPolicyDetails.PolicyAmount = Convert.ToDecimal(ObjPolicyDetails.PolicyAmount);
                    ClsDataMaster clsDAL = new ClsDataMaster();
                    obj = clsDAL.SaveMaster(ObjClsReqPolicyDetails);
                    if (obj.ErrorCode == 1)
                    {
                        obj.ErrorCode = 1;
                        obj.ErrorDescription = "Data Saved Successfully.";
                    }
                }
                else
                {
                    obj.ErrorCode = -1;
                    obj.ErrorDescription = "Record failed!";                   
                }
            }
            catch (Exception ex)
            {
                obj.ErrorCode = -1;
                obj.ErrorDescription = ex.Message;  
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAgentPolicyData()
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
            return Json(ObjClsResGetAllAgentpolicy,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ComboAgentData()
        {
            ClsResAgentMaster ObjClsResAgentMaster = new ClsResAgentMaster();
            try
            {
                ClsDataMaster clsDAL = new ClsDataMaster();
                ObjClsResAgentMaster = clsDAL.GetAgentCombo();
                if (ObjClsResAgentMaster.ErrorCode == "1")
                {
                    ViewBag.Message = "Data Checked.!!";
                }
            }
            catch (Exception ex)
            {
                ObjClsResAgentMaster.ErrorCode = "-1";
                ObjClsResAgentMaster.ErrorDescription = ex.Message;
            }
            return Json(ObjClsResAgentMaster, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ComboSchemeData()
        {
            ClsResSchemeMaster ObjClsResSchemeMaster = new ClsResSchemeMaster();
            try
            {
                ClsDataMaster clsDAL = new ClsDataMaster();
                ObjClsResSchemeMaster = clsDAL.GetSchemeCombo();
                if (ObjClsResSchemeMaster.ErrorCode == "1")
                {
                    ViewBag.Message = "Data Checked.!!";
                }
            }
            catch (Exception ex)
            {
                ObjClsResSchemeMaster.ErrorCode = "-1";
                ObjClsResSchemeMaster.ErrorDescription = ex.Message;
            }
            return Json(ObjClsResSchemeMaster, JsonRequestBehavior.AllowGet);
        }

        #endregion

        public ActionResult About()
        {
             try
            {
                if (Session["UserID"] != null)
                {
                    ViewBag.Message = "Your application description page.";
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

        public ActionResult Contact()
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
    }
}