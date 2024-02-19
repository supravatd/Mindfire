using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void BindDropDownList<T>(DropDownList ddl, List<T> list, string textField, string valueField)
        {
            ddl.DataSource = list;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", ""));
        }
        private void PopulateStates(DropDownList ddl, int countryId)
        {
            List<StateModel> stateList = Business.Business.GetStateList(countryId);
            BindDropDownList(ddl, stateList, "StateName", "StateId");
        }
        protected void PresentCountryState(object sender, EventArgs e)
        {
            int selectedCountryId = int.Parse(ddlPresentAddressCountry.SelectedValue);
            PopulateStates(ddlPresentAddressState, selectedCountryId);
        }
        protected void PermanentCountryState(object sender, EventArgs e)
        {
            int selectedCountryId = int.Parse(ddlPermanentAddressCountry.SelectedValue);
            PopulateStates(ddlPermanentAddressState, selectedCountryId);
        }
    }
}