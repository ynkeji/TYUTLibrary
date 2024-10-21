using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BytesIO.TCP_Client.JsonBean
{
    public  class login_send
    {

        public long Code { get; set; }


        public LoginData Data = new LoginData();

        

        public string Msg { get; set; }
       
        
    }
    public partial class LoginData
    {
        public string DeptName { get; set; }


        public object Email { get; set; }


        public string FlagName { get; set; }

        public string Id { get; set; }

        public object Mobile { get; set; }

        public string Name { get; set; }

        public string RoleName { get; set; }
    }


}


