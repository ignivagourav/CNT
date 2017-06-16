using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace CNT.BusinessLayer
{
    public class CNTMembershipProvider : SqlMembershipProvider
    {
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            // Update the private connection string field in the base class. 

            string Connection = Convert.ToString(ConfigurationManager.ConnectionStrings["CompareNewTyresConnection"]);
            DataSecurity.DataManagement obj = new DataSecurity.DataManagement();
            string connectionString = Connection;
            FieldInfo connectionStringField = GetType().BaseType.GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
            connectionStringField.SetValue(this, connectionString);
        }
    }
}
