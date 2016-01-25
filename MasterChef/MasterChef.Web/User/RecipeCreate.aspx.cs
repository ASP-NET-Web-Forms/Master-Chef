namespace MasterChef.Web.User
{
    using System;

    using Subgurim.Controles;

    public partial class RecipeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeGoogleMaps();
        }

        private void InitializeGoogleMaps()
        {
            GMap1.Add(new GMapUI());

            GMapUIOptions options = new GMapUIOptions();
            options.maptypes_hybrid = false;
            options.keyboard = false;
            options.maptypes_physical = false;
            options.zoom_scrollwheel = true;

            GMap1.Add(new GMapUI(options));

            GControl control = new GControl(GControl.preBuilt.LargeMapControl);
            GControl control2 = new GControl(GControl.preBuilt.MenuMapTypeControl, new GControlPosition(GControlPosition.position.Top_Right));

            GMap1.Add(control);
            GMap1.Add(control2);

            GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl, new GControlPosition(GControlPosition.position.Bottom_Left)));
        }

        protected string OnGoogleMapClick(object s, GAjaxServerEventArgs e)
        {
            return e.bounds.getNorthEast().ToString();
        }
    }
}