using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.SmartObjects.Services.ServiceSDK;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using System.Data;

namespace K2ME.Field.Roles
{
    class K2RolesSOBroker : ServiceAssemblyBase
    {
        #region private data members

        private string _K2ServerName;
        private int _PortNo;
        SourceCode.SmartObjects.Client.SmartObjectClientServer cServer;

        #endregion 

        public override string GetConfigSection()
        {
            base.Service.ServiceConfiguration.Add("K2ServerName", true, 5555);
            base.Service.ServiceConfiguration.Add("Port", true, "DLX");
            return base.GetConfigSection();
        }
        public override string DescribeSchema()
        {
            base.Service.Name = "K2RolesSMO";
            base.Service.MetaData.DisplayName = "K2Roles as SMO";
            base.Service.MetaData.Description = "";

            K2RolesSOProperties wrkProperties = new K2RolesSOProperties();
            base.Service.ServiceObjects.Add(wrkProperties.DescribeServiceObjects());

            return base.DescribeSchema();
        }
        public override void Extend()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void Execute()
        {
            ValidateConfigSection();
            base.ServicePackage.ResultTable = null;
            DataTable result = new DataTable("Result");
            try
            {

                foreach (ServiceObject serviceObj in base.Service.ServiceObjects)
                {
                    foreach (Method method in serviceObj.Methods)
                    {
                        Dictionary<string, object> properties = new Dictionary<string, object>();
                        foreach (Property property in serviceObj.Properties)
                        {
                            if ((property.Value != null) && (!string.IsNullOrEmpty(property.Value.ToString())))
                            {
                                properties.Add(property.Name, property.Value);
                            }
                        }

                        // build the method parameters collection
                        Dictionary<string, object> parameters = new Dictionary<string, object>();
                        foreach (MethodParameter parameter in method.MethodParameters)
                        {
                            if ((parameter.Value != null) && (!string.IsNullOrEmpty(parameter.Value.ToString())))
                            {
                                parameters.Add(parameter.Name, parameter.Value);
                            }
                        }

                        if (serviceObj.Name.ToString() == "K2FieldRoles")
                        {
                            if (method.Name == "IsInRole")
                            {
                                result = IsinRole(properties, parameters);
                            }
                            if (method.Name == "GetRoleUsersEmails")
                            {
                                result = RoleUsersEmails(properties, parameters);
                            }
                            if (method.Name == "GetRoleUsersEmailsonIndex")
                            {
                                result = RoleUsersEmailswithIndex(properties, parameters);
                            }
                        }
                    }
                    base.ServicePackage.ResultTable = result;

                    base.ServicePackage.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                base.ServicePackage.IsSuccessful = false;
                base.ServicePackage.ServiceMessages.Add(new ServiceMessage(ex.Message, MessageSeverity.Error));
            }

        }

        private DataTable RoleUsersEmailswithIndex(Dictionary<string, object> properties, Dictionary<string, object> parameters)
        {
            K2RolesSOProperties _properties = new K2RolesSOProperties(_K2ServerName, _PortNo);
            DataTable result;
            result = _properties.RoleUsersEmailswithIndex(properties, parameters);
            return result;
        }

        private DataTable RoleUsersEmails(Dictionary<string, object> properties, Dictionary<string, object> parameters)
        {
           K2RolesSOProperties _properties = new K2RolesSOProperties(_K2ServerName, _PortNo);
            DataTable result;
            result = _properties.RoleUsersEmails(properties, parameters);
            return result;
        }

        private DataTable IsinRole(Dictionary<string, object> properties, Dictionary<string, object> parameters)
        {
            K2RolesSOProperties _properties = new K2RolesSOProperties(_K2ServerName, _PortNo);
            DataTable result;
            result = _properties.IsinRole(properties, parameters);
            return result;
        }

        private void ValidateConfigSection()
        {
            ServiceConfiguration config = base.Service.ServiceConfiguration;
            _PortNo = Convert.ToInt32(config["Port"]);
            _K2ServerName = config["K2ServerName"].ToString();

            if (_PortNo == 0)
            {
                base.ServicePackage.IsSuccessful = false;
                base.ServicePackage.ServiceMessages.Add(new ServiceMessage("Please provide SmartObject Port details ", MessageSeverity.Error));
            }
            if (string.IsNullOrEmpty(_K2ServerName))
            {
                base.ServicePackage.IsSuccessful = false;
                base.ServicePackage.ServiceMessages.Add(new ServiceMessage("Please provide K2 ServerName to proceed further.", MessageSeverity.Error));
            }
        }

    }
}
