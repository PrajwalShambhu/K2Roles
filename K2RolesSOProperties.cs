using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using SourceCode.Hosting.Client.BaseAPI;
//using SourceCode.SmartObjects.Client;
using System.Data;


namespace K2ME.Field.Roles
{
    public class K2RolesSOProperties
    {
        #region private data members
        
        private string _K2ServerName;
        private int _PortNo;
        SourceCode.SmartObjects.Client.SmartObjectClientServer cServer;
        
        #endregion 

        #region contructor(s)
        
        internal K2RolesSOProperties()
        {
        }

        internal K2RolesSOProperties(string K2serverName, int portNo)
        {
            _K2ServerName = K2serverName;
            _PortNo = portNo;
        }
        
        #endregion

        internal ServiceObject DescribeServiceObjects()
        {
            ServiceObject so = new ServiceObject("K2FieldRoles");
            so.Type = "K2FieldRoles";
            so.Active = true;
            so.MetaData.DisplayName = "K2Field Roles";
            so.MetaData.Description = "It gets you user information belongs to role with email address";
            so.Methods = DescribeMethods();
            so.Properties = DescribeProperties();
            return so;
        }

        private SourceCode.SmartObjects.Services.ServiceSDK.Objects.Properties DescribeProperties()
        {

            Properties properties = new Properties();

            properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("RoleName", "RoleName")));
            properties.Add(new Property("Name", "System.String", SoType.Text, new MetaData("Username", "Username")));
            properties.Add(new Property("UserIndex", "System.Int32", SoType.Number, new MetaData("UserIndex", "UserIndex")));
            properties.Add(new Property("EmailAddress", "System.String", SoType.Text, new MetaData("EmailAddress", "EmailAddress")));
            properties.Add(new Property("IsinRole", "System.Boolean", SoType.YesNo, new MetaData("IsinRole", "IsinRole")));

            return properties;
        }

        private SourceCode.SmartObjects.Services.ServiceSDK.Objects.Methods DescribeMethods()
        {
            SourceCode.SmartObjects.Services.ServiceSDK.Objects.Methods methods = new Methods();

            //methods.Add(new Method("GetRoleUsersEmailAddress", MethodType.List, new MetaData("GetRoleUsersEmailAddress", "Returns Role Users Email Address."), GetRequiredProperties("GetRoleUserEmailAddress"), GetMethodParameters(), GetInputProperties("GetRoleUserEmailAddress"), GetReturnProperties("GetRoleUserEmailAddress")));

            methods.Add(new Method("IsInRole", MethodType.List, new MetaData("IsInRole", "Return User presence in the K2 Role."), GetRequiredProperties("IsInRole"), GetMethodParameters(), GetInputProperties("IsInRole"), GetReturnProperties("IsInRole")));

            methods.Add(new Method("GetRoleUsersEmailsonIndex", MethodType.List, new MetaData("GetRoleUsersEmailsonIndex", "Returns Role Users Email Address."), GetRequiredProperties("GetRoleUsersEmailsonIndex"), GetMethodParameters(), GetInputProperties("GetRoleUsersEmailsonIndex"), GetReturnProperties("GetRoleUsersEmailsonIndex")));

            methods.Add(new Method("GetRoleUsersEmails", MethodType.List, new MetaData("GetRoleUsersEmails", "Returns Role Users Email Address."), GetRequiredProperties("GetRoleUsersEmails"), GetMethodParameters(), GetInputProperties("GetRoleUsersEmails"), GetReturnProperties("GetRoleUsersEmails")));

            return methods;
        }

        private InputProperties GetInputProperties(string Method)
        {
            InputProperties properties = new InputProperties();
            switch (Method)
            {
                case "IsInRole":
                    #region properties
                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));
                    properties.Add(new Property("IsinRole", "System.Boolean", SoType.YesNo, new MetaData("IsinRole", "IsinRole")));
                    properties.Add(new Property("Name", "System.String", SoType.Text, new MetaData("Username", "Username")));

                    break;
                case "GetRoleUsersEmailAddress":

                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));

                    break;
                case "GetRoleUsersEmailsonIndex":
                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));
                    properties.Add(new Property("UserIndex", "System.Int32", SoType.Number, new MetaData("UserIndex", "UserIndex")));
                    break;

                case "GetRoleUsersEmails":
                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));
                    //properties.Add(new Property("UserIndex", "System.Int32", SoType.Number, new MetaData("UserIndex", "UserIndex")));
                    break;

                    #endregion
            }
            return properties;
        }

        private Validation GetRequiredProperties(string method)
        {
            RequiredProperties properties = new RequiredProperties();
            Validation validation = null;
            validation = new Validation();
            switch (method)
            {
                case "IsInRole":
                    #region properties
                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));
                    properties.Add(new Property("Username", "System.String", SoType.Text, new MetaData("Username", "Username")));

                    break;
                case "GetRoleUsersEmailAddress":
                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));
                    break;
                case "GetRoleUsersEmailsonIndex":
                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));
                    properties.Add(new Property("UserIndex", "System.Int32", SoType.Number, new MetaData("UserIndex", "UserIndex")));
                    break;

                case "GetRoleUsersEmails":
                    properties.Add(new Property("Role_Name", "System.String", SoType.Text, new MetaData("Role_Name", "Role_Name")));
                    //properties.Add(new Property("UserIndex", "System.Int32", SoType.Number, new MetaData("UserIndex", "UserIndex")));
                    break;

                    #endregion
            }
            validation.RequiredProperties = properties;
            return validation;
        }

        private MethodParameters GetMethodParameters()
        {
            MethodParameters parameters = new MethodParameters();
            
            return parameters;
        }

        private ReturnProperties GetReturnProperties(string method)
        {
            ReturnProperties properties = new ReturnProperties();
            switch (method)
            {
                case "IsInRole":
                    properties.Add(new Property("IsinRole", "System.Boolean", SoType.YesNo, new MetaData("IsinRole", "IsinRole")));
                    break;

                case "GetRoleUsersEmailAddress":
                    properties.Add(new Property("EmailAddress", "System.String", SoType.Text, new MetaData("EmailAddress", "EmailAddress")));
                    break;

                case "GetRoleUsersEmailsonIndex":
                    properties.Add(new Property("EmailAddress", "System.String", SoType.Text, new MetaData("EmailAddress", "EmailAddress")));
                    break;

                case "GetRoleUsersEmails":
                    properties.Add(new Property("EmailAddress", "System.String", SoType.Text, new MetaData("EmailAddress", "EmailAddress")));
                    //properties.Add(new Property("UserIndex", "System.Int32", SoType.Number, new MetaData("UserIndex", "UserIndex")));
                    break;
            }
            return properties;
        }

        public DataTable CallSmartObjectListMethod( Dictionary<string, object> parameters, Dictionary<string, object> properties)
        {
            string methodName = "Get_Role_Users";
            string objectName = "UMUser";
            Check_SmartObjectClientServer();
            DataTable dt = null;
            List<Dictionary<string, object>> returnCollection = new List<Dictionary<string, object>>();
            if (!cServer.Connection.IsConnected) return new DataTable();

            SourceCode.SmartObjects.Client.SmartObject smartObject = cServer.GetSmartObject(objectName);
            smartObject.MethodToExecute = methodName;

            //Set Parameter
            foreach (SourceCode.SmartObjects.Client.SmartParameter para in smartObject.ListMethods[methodName].Parameters)
            {
                if (properties.ContainsKey(para.Name)) SetPropertyValue(para, properties[para.Name]);
            }

            //Set propery
            foreach (SourceCode.SmartObjects.Client.SmartProperty prop in smartObject.ListMethods[methodName].InputProperties)
            {
                //See if this key exists in the data properteries
                if (properties.ContainsKey(prop.Name)) SetPropertyValue(prop, properties[prop.Name]);
            }
            dt = cServer.ExecuteListDataTable(smartObject);
            cServer.Connection.Close();
            smartObject = null;
            return dt;
        }

        private void SetPropertyValue(SourceCode.SmartObjects.Client.SmartProperty smartProperty, object value)
        {
            if (value == null)
            {
                smartProperty.ValueBehaviour = SourceCode.SmartObjects.Client.ValueBehaviour.Unchanged;
                smartProperty.Value = null;
            }
            else if (value == DBNull.Value)
            {
                smartProperty.ValueBehaviour = SourceCode.SmartObjects.Client.ValueBehaviour.Clear;
                smartProperty.Value = null;
            }
            else if (value.ToString() == string.Empty)
            {
                smartProperty.ValueBehaviour = SourceCode.SmartObjects.Client.ValueBehaviour.Empty;
                smartProperty.Value = string.Empty;
            }
            else
            {
                smartProperty.ValueBehaviour = SourceCode.SmartObjects.Client.ValueBehaviour.None;
                smartProperty.Value = value.ToString();
            }
        }
        
        private void Check_SmartObjectClientServer()
        {
            string connStr = string.Format("Integrated=True;IsPrimaryLogin=True;Authenticate=True;EncryptedPassword=False;Host={0};Port={1}", _K2ServerName, _PortNo);
            try
            {
                if (cServer == null)
                {
                    cServer = new SourceCode.SmartObjects.Client.SmartObjectClientServer();
                    cServer.CreateConnection();
                    cServer.Connection.Open(connStr);
                }
            }
            catch
            {
                throw new Exception("Couldn't create connection to server");
            }
        }

        public DataTable IsinRole(Dictionary<string, object> properties, Dictionary<string, object> parameters)
        {
            DataTable ret = new DataTable();
            DataRow dr1;
            bool set = false;
            DataTable results = CallSmartObjectListMethod(parameters, properties);
            foreach(DataRow dr in results.Rows)
            {
                if (dr["Name"].ToString().ToLower().Equals(properties["Name"].ToString().ToLower()))
                    set = true;
            }
            dr1 = ret.NewRow();
            ret.Columns.Add("IsinRole");
            dr1["IsinRole"] = set;
            ret.Rows.Add(dr1);
            return ret ;
        }

        public DataTable RoleUsersEmails(Dictionary<string, object> properties, Dictionary<string, object> parameters)
        {
            DataTable ret = new DataTable();
            DataRow dr1;
            Check_SmartObjectClientServer();
            string RoleEmailAddress = string.Empty;

            DataTable results = CallSmartObjectListMethod(parameters, properties);
            foreach (DataRow dr in results.Rows)
            {
               RoleEmailAddress = RoleEmailAddress + dr["Email"].ToString() + ";";
            }
            dr1 = ret.NewRow();
            ret.Columns.Add("EmailAddress");
            dr1["EmailAddress"] = RoleEmailAddress;
            ret.Rows.Add(dr1);
            return ret;
        }

        public DataTable RoleUsersEmailswithIndex(Dictionary<string, object> properties, Dictionary<string, object> parameters)
        {
            DataTable ret = new DataTable();
            DataRow dr1;
            Check_SmartObjectClientServer();
            string RoleEmailAddress = string.Empty;
            
            int UserIndex = Convert.ToInt16(properties["UserIndex"]);
            DataTable results = CallSmartObjectListMethod(parameters, properties);
            int rowsCount = results.Rows.Count;
            for (int i = 0; i < rowsCount; i++ )
            {
                if(i != UserIndex)
                { RoleEmailAddress = results.Rows[i]["Email"].ToString() + ";"; }
            }
            dr1 = ret.NewRow();
            ret.Columns.Add("EmailAddress");
            dr1["EmailAddress"] = RoleEmailAddress;
            ret.Rows.Add(dr1);
            return ret;
        }

        public DataTable RoleUsersEmailsExceptIndex(Dictionary<string, object> properties, Dictionary<string, object> parameters)
        {
            DataTable ret = new DataTable();
            DataRow dr1;
            Check_SmartObjectClientServer();
            string RoleEmailAddress = string.Empty;

            int UserIndex = Convert.ToInt16(properties["UserIndex"]);
            DataTable results = CallSmartObjectListMethod(parameters, properties);
            int rowsCount = results.Rows.Count;
            for (int i = 0; i < rowsCount; i++)
            {
                if (i != UserIndex)
                { RoleEmailAddress = results.Rows[i]["Email"].ToString() + ";"; }
            }
            dr1 = ret.NewRow();
            ret.Columns.Add("EmailAddress");
            dr1["EmailAddress"] = RoleEmailAddress;
            ret.Rows.Add(dr1);
            return ret;
        }
    }
}
