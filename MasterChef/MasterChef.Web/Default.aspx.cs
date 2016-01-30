using MasterChef.Data;
using MasterChef.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Caching;
using System.IO;

namespace MasterChef.Web
{
    public partial class _Default : Page
    {
        private IMasterChefData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("panelSiteMapPath").Visible = false;
            
        }
    }
}