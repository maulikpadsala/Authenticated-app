using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PolicyBazar.Models;
using System.Web.Security;

namespace PolicyBazar.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Login()
        {
            return View();
        }

        //
        // GET: /Authentication/Details/5
        public ActionResult Logins(ClsReqLogin Obj)
        {
            ClsDataMaster clsDAL = new ClsDataMaster();
            ClsResLogin objClsResLogin = new ClsResLogin();
            objClsResLogin = clsDAL.LoginMaster(Obj);
            if (objClsResLogin.ErrorCode == "1")
            {
                Session["UserId"] = objClsResLogin.UserId;
                Session["UserName"] = objClsResLogin.UserName;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Authentication");
        }

        #region Logout
        [HttpGet]
        public ActionResult LogOut()
        {
            try
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                Response.Cookies.Clear();
                this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                this.Response.Cache.SetNoStore();
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Login", "Authentication");
        }
        #endregion
        
        //
        // GET: /Authentication/
        public ActionResult Register()
        {
            return View();
        }

        //
        // GET: /Authentication/Details/5
        string output;
        [HttpPost]
        public ActionResult Registers(ClsReqRegister ObjReqRegister)
        {
            ClsResGetMaster obj = new ClsResGetMaster();
            
            try
            {
                if (ObjReqRegister.Password != null && ObjReqRegister.UserName != null)
                {
                    ClsReqRegister ObjClsReqRegister = new ClsReqRegister();
                    ObjClsReqRegister.UserName = ObjReqRegister.UserName;
                    ObjClsReqRegister.Password = ObjReqRegister.Password;
                    if(ObjReqRegister.Password == ObjReqRegister.ConfirmPassword)
                    {
                        ClsDataMaster clsDAL = new ClsDataMaster();
                        obj = clsDAL.RegisterMaster(ObjClsReqRegister);
                        if (obj.ErrorCode == 1)
                        {
                            obj.ErrorCode = 1;
                            obj.ErrorDescription = "User Registered Successfully.";
                            output = obj.ErrorDescription;
                            //ViewBag.Error = obj.ErrorDescription;
                               
                        }
                    }
                    else
                    {
                        obj.ErrorCode = -1;
                        obj.ErrorDescription = "Registration failed! Password not match.";
                        output = obj.ErrorDescription;

                    }
                }
                else
                {
                    obj.ErrorCode = -1;
                    obj.ErrorDescription = "Registration failed!";
                    output = obj.ErrorDescription;                    
                }
            }
            catch (Exception ex)
            {
                obj.ErrorCode = -1;
                output = ex.Message;  
            }
            //TempData["employee"] = obj.ErrorDescription;
            return RedirectToAction("Login", "Authentication");
            //return Json(output, JsonRequestBehavior.AllowGet);           
        }     
    }
}
