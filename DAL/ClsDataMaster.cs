using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using PolicyBazar.Models;

namespace PolicyBazar
{
    public class ClsDataMaster
    {
        #region Declaration
        SQLHelper ObjSQLHelper = new SQLHelper();
        //ClsDataMaster ObjClsDataMaster = new ClsDataMaster();
        #endregion

        #region 1. Get Agent Details
        public ClsResGetAllAgentpolicy GetAllAgentDetails()
        {
            DataSet ds = new DataSet();
            ClsResGetAllAgentpolicy ObjClsResGetAllAgentpolicy = new ClsResGetAllAgentpolicy();
            try
            {
                int UserCode = 0;
                object[] parameter = new object[] { UserCode };
                ds = ObjSQLHelper.SP_GetDataSet(parameter, "GetAll_tblAgentdnepolicy");
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ClsAgentpolicyDetails[] ObjClsPolicyDetails1 = new ClsAgentpolicyDetails[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsAgentpolicyDetails ObjClsPolicyDetails2 = new ClsAgentpolicyDetails();
                        ObjClsPolicyDetails2.Agent = ds.Tables[0].Rows[i]["Agent"].ToString();
                        ObjClsPolicyDetails2.Scheme = ds.Tables[0].Rows[i]["Scheme"].ToString();
                        ObjClsPolicyDetails2.Policy = ds.Tables[0].Rows[i]["Policy"].ToString();
                        ObjClsPolicyDetails1[i] = ObjClsPolicyDetails2;
                    }
                    ObjClsResGetAllAgentpolicy.GetAgentPolicyDetail = ObjClsPolicyDetails1;
                    ObjClsResGetAllAgentpolicy.ErrorCode = "1";
                    ObjClsResGetAllAgentpolicy.ErrorDescription = "Success";
                }
                else
                {
                    ObjClsResGetAllAgentpolicy.ErrorCode = "2";
                    ObjClsResGetAllAgentpolicy.ErrorDescription = "Data Not Found";
                }
                return ObjClsResGetAllAgentpolicy;
            }
            catch (Exception ex)
            {
                ObjClsResGetAllAgentpolicy.ErrorCode = "-1";
                ObjClsResGetAllAgentpolicy.ErrorDescription = ex.Message;
                return ObjClsResGetAllAgentpolicy;
            }
        }

        public ClsResGetAllAgentCommission GetAllAgentCommission()
        {
            DataSet ds = new DataSet();
            ClsResGetAllAgentCommission ObjClsResGetAllAgentCommission = new ClsResGetAllAgentCommission();
            try
            {
                int UserCode = 0;
                object[] parameter = new object[] { UserCode };
                ds = ObjSQLHelper.SP_GetDataSet(parameter, "GetAll_tblAgentcommission");
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ClsAgentCommission[] ObjClsAgentCommission1 = new ClsAgentCommission[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ClsAgentCommission ObjClsAgentCommission2 = new ClsAgentCommission();
                        ObjClsAgentCommission2.Agent = ds.Tables[0].Rows[i]["Agent"].ToString();
                        ObjClsAgentCommission2.Commission = Convert.ToDecimal(ds.Tables[0].Rows[i]["Commission"].ToString());
                        ObjClsAgentCommission1[i] = ObjClsAgentCommission2;
                    }
                    ObjClsResGetAllAgentCommission.Getagentcommission = ObjClsAgentCommission1;
                    ObjClsResGetAllAgentCommission.ErrorCode = "1";
                    ObjClsResGetAllAgentCommission.ErrorDescription = "Success";
                }
                else
                {
                    ObjClsResGetAllAgentCommission.ErrorCode = "2";
                    ObjClsResGetAllAgentCommission.ErrorDescription = "Data Not Found";
                }
                return ObjClsResGetAllAgentCommission;
            }
            catch (Exception ex)
            {
                ObjClsResGetAllAgentCommission.ErrorCode = "-1";
                ObjClsResGetAllAgentCommission.ErrorDescription = ex.Message;
                return ObjClsResGetAllAgentCommission;
            }
        }
        #endregion

        #region 2. Save Agent Details
        public ClsResGetAllMaster SaveMaster(ClsReqPolicyDetails ObjClsPolicyDetails)
        {
            ClsResGetAllMaster ObjClsResGetAllMaster = new ClsResGetAllMaster();
            
            try
            {
                    object[] parameter = new object[]
                    {
				    ObjClsPolicyDetails.PolicyNo,
                    Convert.ToDateTime(ObjClsPolicyDetails.Date),
					ObjClsPolicyDetails.SchemeNo,
					ObjClsPolicyDetails.AgentNo,
                       ObjClsPolicyDetails.CustomerName,
                     ObjClsPolicyDetails.PolicyAmount,
                     ObjClsPolicyDetails.Commission
					};
                    ObjClsResGetAllMaster.ErrorCode = ObjSQLHelper.SP_ExecuteNonQuery(parameter, "OnSave_SP_tblPolicyMaster");
                if (Convert.ToInt64(ObjClsResGetAllMaster.ErrorCode) >= 1)
                {
                    ObjClsResGetAllMaster.ErrorCode = 1;
                    ObjClsResGetAllMaster.ErrorDescription = "Success";
                }
                else
                {
                    ObjClsResGetAllMaster.ErrorCode = 0;
                    ObjClsResGetAllMaster.ErrorDescription = "Not Success";
                }
                return ObjClsResGetAllMaster;
            }
            catch (Exception ex)
            {
                ObjClsResGetAllMaster.ErrorCode = -1;
                ObjClsResGetAllMaster.ErrorDescription = ex.Message;
                return ObjClsResGetAllMaster;
            }
        }
        #endregion

        #region GetComboAgent
        public ClsResAgentMaster GetAgentCombo()
        {
            DataSet ds = new DataSet();
            ClsResAgentMaster ObjClsResAgentMasterCombo = new ClsResAgentMaster();
            try
            {
                int UserCode = 1;

                object[] parameter = new object[] { UserCode };
                ds = ObjSQLHelper.SP_GetDataSet(parameter, "ComboFill_tblAgentMaster");

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ObjClsResAgentMasterCombo.GetAgentDetails = ConvertDataTable<ClsAgentMaster>(ds.Tables[0]).ToArray();
                        
                    }
                    ObjClsResAgentMasterCombo.ErrorCode = "1";
                    ObjClsResAgentMasterCombo.ErrorDescription = "Success";
                }
                else
                {
                    ObjClsResAgentMasterCombo.ErrorCode = "2";
                    ObjClsResAgentMasterCombo.ErrorDescription = "Data Not Found";
                }
                return ObjClsResAgentMasterCombo;
            }
            catch (Exception ex)
            {
                ObjClsResAgentMasterCombo.ErrorCode = "-1";
                ObjClsResAgentMasterCombo.ErrorDescription = ex.Message;
                return ObjClsResAgentMasterCombo;
            }
        }
        #endregion

        #region GetComboScheme
        public ClsResSchemeMaster GetSchemeCombo()
        {
            DataSet ds = new DataSet();
            ClsResSchemeMaster ObjClsResSchemeMasterCombo = new ClsResSchemeMaster();
            try
            {
                int UserCode = 1;

                object[] parameter = new object[] { UserCode };
                ds = ObjSQLHelper.SP_GetDataSet(parameter, "ComboFill_tblSchemeDetails");

                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ObjClsResSchemeMasterCombo.GetSchemeDetails = ConvertDataTable<ClsSchemeMaster>(ds.Tables[0]).ToArray();
                    }
                    ObjClsResSchemeMasterCombo.ErrorCode = "1";
                    ObjClsResSchemeMasterCombo.ErrorDescription = "Success";
                }
                else
                {
                    ObjClsResSchemeMasterCombo.ErrorCode = "2";
                    ObjClsResSchemeMasterCombo.ErrorDescription = "Data Not Found";
                }
                return ObjClsResSchemeMasterCombo;
            }
            catch (Exception ex)
            {
                ObjClsResSchemeMasterCombo.ErrorCode = "-1";
                ObjClsResSchemeMasterCombo.ErrorDescription = ex.Message;
                return ObjClsResSchemeMasterCombo;
            }
        }
        #endregion

        #region
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    string Colmnname = "";
                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName] == null)
                        {
                            Colmnname = "";
                        }
                        else
                        {
                            Colmnname = dr[column.ColumnName].ToString();
                        }
                        pro.SetValue(obj, Colmnname, null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
        #endregion

        #region GetComboPolicy
        #endregion

        #region 3. Register User
        public ClsResGetMaster RegisterMaster(ClsReqRegister ObjClsReqRegister)
        {
            ClsResGetMaster ObjClsResGetMaster = new ClsResGetMaster();

            try
            {
                object[] parameter = new object[]
                   {
                    ObjClsReqRegister.UserName,
					ObjClsReqRegister.Password  
					};
                ObjClsResGetMaster.ErrorCode = ObjSQLHelper.SP_ExecuteNonQuery(parameter, "OnSave_User");
                if (Convert.ToInt64(ObjClsResGetMaster.ErrorCode) >= 1)
                {
                    ObjClsResGetMaster.ErrorCode = 1;
                    ObjClsResGetMaster.ErrorDescription = "Success";
                }
                else
                {
                    ObjClsResGetMaster.ErrorCode = 0;
                    ObjClsResGetMaster.ErrorDescription = "Not Success";
                }
                return ObjClsResGetMaster;
            }
            catch (Exception ex)
            {
                ObjClsResGetMaster.ErrorCode = -1;
                ObjClsResGetMaster.ErrorDescription = ex.Message;
                return ObjClsResGetMaster;
            }
        }
        #endregion

        #region 4. Login User
        public ClsResLogin LoginMaster(ClsReqLogin ObjClsReqLogin)
        {
            DataSet ds = new DataSet();
            ClsResLogin ObjClsResLogin = new ClsResLogin();

            try
            {
                object[] parameter = new object[]
                   {
                    ObjClsReqLogin.UserName,
					ObjClsReqLogin.Password  
					};
                ds = ObjSQLHelper.SP_GetDataSet(parameter, "Login");
                 if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                 {
                     ObjClsResLogin.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"]);
                     ObjClsResLogin.ErrorCode = "1";
                     ObjClsResLogin.ErrorDescription = "Success";
                 }
                 return ObjClsResLogin;
            }
            catch (Exception ex)
            {
                ObjClsResLogin.ErrorCode = "-1";
                ObjClsResLogin.ErrorDescription = ex.Message;
                return ObjClsResLogin;
            }
        }
        #endregion
    }
}