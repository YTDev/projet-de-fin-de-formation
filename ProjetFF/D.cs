using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ProjetFF
{
    class D
    {

        public static SqlConnection cn = new SqlConnection("data source=.; database=projetff; integrated security=sspi;MultipleActiveResultSets=true;");
        
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlDataAdapter sDA = new SqlDataAdapter();
       /* public static SqlDataAdapter daRR = new SqlDataAdapter("select * from RADIE_RESTAURATION", D.cn);
        public static SqlDataAdapter daT = new SqlDataAdapter("select * from typer", D.cn);
        public static SqlDataAdapter daR = new SqlDataAdapter("select * from RADIE", D.cn);
        public static SqlDataAdapter sDA1 = new SqlDataAdapter();*/

    }
}
