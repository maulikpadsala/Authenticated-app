using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace PolicyBazar.Models
{
   public class ClsAgentMaster
   {
       public string AgentNo { get; set; }
       public string AgentName { get; set; }
   }

   public class ClsResAgentMaster
   {
       public ClsAgentMaster[] GetAgentDetails { get; set; }
       public string ErrorCode { get; set; }
       public string ErrorDescription { get; set; }
   }
   
   public class ClsSchemeMaster
   {
       public string SchemeNo { get; set; }
       public string SchemeName { get; set; }
   }

   public class ClsResSchemeMaster
   {
       public ClsSchemeMaster[] GetSchemeDetails { get; set; }
       public string ErrorCode { get; set; }
       public string ErrorDescription { get; set; }
   }

   public class ClsPolicyDetails
   {
       public Int16 PolicyNo { get; set; }
       public DateTime Date { get; set; }
       public int SchemeNo { get; set; }
       public int AgentNo { get; set; }
       public int CustomerName { get; set; }
       public decimal Commission { get; set; }
   }

   public class ClsResGetAllMaster
   {
       public ClsPolicyDetails[] GetMasterDetails { get; set; }
       public int ErrorCode { get; set; }
       public string ErrorDescription { get; set; }
   }

   public class ClsReqPolicyDetails
    {
        public string PolicyNo { get; set; }
        public string Date { get; set; }
        public int SchemeNo { get; set; }
        public int AgentNo { get; set; }
        public string CustomerName { get; set; }
        public decimal Commission { get; set; }
        public decimal PolicyAmount { get; set; }
   }

    public class Response
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

    public class ClsAgentpolicyDetails
    {
        public string  Agent { get; set; }
        public string Scheme { get; set; }
        public string Policy { get; set; }
    }

    public class ClsResGetAllAgentpolicy
    {
        public ClsAgentpolicyDetails[] GetAgentPolicyDetail { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }

   public class ClsAgentCommission
   {
       public string Agent { get; set; }
       public decimal Commission { get; set; }
   }

   public class ClsResGetAllAgentCommission
   {
       public ClsAgentCommission[] Getagentcommission { get; set; }
       public string ErrorCode { get; set; }
       public string ErrorDescription { get; set; }
   }

   public class ClsReqLogin
   {
       public string UserName { get; set; }
       public string Password { get; set; }    
   }

   public class ClsResLogin
   {
       public int UserId { get; set; }
       public string UserName { get; set; }
       public string ErrorCode { get; set; }
       public string ErrorDescription { get; set; }
   }

   public class ClsReqRegister
   {
       public int UserId { get; set; }
       public string Password { get; set; }
       public string UserName { get; set; }
       public string ConfirmPassword { get; set; }
   }

   public class ClsResGetMaster
   {
       public ClsReqRegister[] GetRegisterDetails { get; set; }
       public int ErrorCode { get; set; }
       public string ErrorDescription { get; set; }
   }

}