namespace MasterChef.Web.Controls
{
    using System;
    using System.Web.UI.WebControls;

    public class LikeEventArgs : EventArgs
    {
        public LikeEventArgs(bool likeValue)
        {
            this.LikeValue = likeValue;
        }
        
        public bool LikeValue { get; set; }
    }

    public partial class Likes : System.Web.UI.UserControl
    {
        public int Value { get; set; }

        public int DataID { get; set; }

        public bool UserVote { get; set; }

        public delegate void LikeEventHandler(object sender, LikeEventArgs e);

        public event LikeEventHandler Like;

        public bool mustUpdate;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if(!mustUpdate)
            {
                return;
            }

            this.LabelValue.Text = this.Value.ToString();

            if (this.UserVote)
            {
                this.ButtonLike.Visible = false;
                this.ButtonDislike.Visible = true;
            }
            else
            {
                this.ButtonLike.Visible = true;
                this.ButtonDislike.Visible = false;
            }
        }

        protected void ButtonLike_Command(object sender, CommandEventArgs e)
        {
            bool likeValue = e.CommandName == "Like" ? true : false;
            this.Like(this, new LikeEventArgs(likeValue));
        }
    }
}