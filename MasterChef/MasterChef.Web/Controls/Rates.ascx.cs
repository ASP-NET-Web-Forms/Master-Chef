using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterChef.Web.Controls
{
    using System;
    using System.Web.UI.WebControls;

    public class RateEventArgs : EventArgs
    {
        public RateEventArgs(int rateValue)
        {
            this.RateValue = rateValue;
        }

        public int RateValue { get; set; }
    }

    public partial class Rates : System.Web.UI.UserControl
    {
        public int Value { get; set; }

        public bool UserVote { get; set; }

        public delegate void RateEventHandler(object sender, RateEventArgs e);

        public event RateEventHandler Rate;

        public bool mustUpdate;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!mustUpdate)
            {
                return;
            }

            switch (this.Value)
            {
                case 0:
                    this.StarHolder0.Visible = true;
                    this.StarHolder1.Visible = false;
                    this.StarHolder2.Visible = false;
                    this.StarHolder3.Visible = false;
                    this.StarHolder4.Visible = false;
                    this.StarHolder5.Visible = false;
                    break;
                case 1:
                    this.StarHolder0.Visible = false;
                    this.StarHolder1.Visible = true;
                    this.StarHolder2.Visible = false;
                    this.StarHolder3.Visible = false;
                    this.StarHolder4.Visible = false;
                    this.StarHolder5.Visible = false;
                    break;
                case 2:
                    this.StarHolder0.Visible = false;
                    this.StarHolder1.Visible = false;
                    this.StarHolder2.Visible = true;
                    this.StarHolder3.Visible = false;
                    this.StarHolder4.Visible = false;
                    this.StarHolder5.Visible = false;
                    break;
                case 3:
                    this.StarHolder0.Visible = false;
                    this.StarHolder1.Visible = false;
                    this.StarHolder2.Visible = false;
                    this.StarHolder3.Visible = true;
                    this.StarHolder4.Visible = false;
                    this.StarHolder5.Visible = false;
                    break;
                case 4:
                    this.StarHolder0.Visible = false;
                    this.StarHolder1.Visible = false;
                    this.StarHolder2.Visible = false;
                    this.StarHolder3.Visible = false;
                    this.StarHolder4.Visible = true;
                    this.StarHolder5.Visible = false;
                    break;
                case 5:
                    this.StarHolder0.Visible = false;
                    this.StarHolder1.Visible = false;
                    this.StarHolder2.Visible = false;
                    this.StarHolder3.Visible = false;
                    this.StarHolder4.Visible = false;
                    this.StarHolder5.Visible = true;
                    break;
                default:
                    return;
            }
            
            if (this.UserVote)
            {
                this.GiveRatingDropDown.Visible = false;
                this.ButtonPostRating.Visible = false;
                this.UserGaveRatingTextBox.Visible = true;
            }
        }

        protected void ButtonRatingAdd_Command(object sender, CommandEventArgs e)
        {
            var rateValue = int.Parse(this.GiveRatingDropDown.SelectedValue);
            if (rateValue == 0)
            {
                return;
            }

            this.Rate(this, new RateEventArgs(rateValue));
        }
    }
}