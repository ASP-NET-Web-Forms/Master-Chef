using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterChef.Web.Controls
{
    public partial class NewestArticles : UserControl
    {
        public ListView NewestArticlesList
        {
            get;
            set;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.NewestArticlesList = ListViewNewestArticles;
            
        }
    }
}