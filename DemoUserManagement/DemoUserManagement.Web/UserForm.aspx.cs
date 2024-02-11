using DemoUserManagement.Business;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.Models.Model;

namespace DemoUserManagement.Web
{
    public partial class UserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                PopulateCountries();
                ShowButton(false);
            }
        }

        private void ShowButton(bool button)
        {
            if (button)
            {
                bttnSubmit.Visible = false;
                bttnEdit.Visible = true;
                bttnDelete.Visible = true;
            }
            else
            {
                bttnSubmit.Visible = true; 
                bttnEdit.Visible = false;
                bttnDelete.Visible = false;
            }
        }

        private void BindDropDownList<T>(DropDownList ddl, List<T> list, string textField, string valueField)
        {
            ddl.DataSource = list;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", ""));
        }

        private void PopulateCountries()
        {
            List<CountryModel> countryList = Business.Business.GetCountryList();

            BindDropDownList(ddlPresentAddressCountry, countryList, "CountryName", "CountryId");
            BindDropDownList(ddlPermanentAddressCountry, countryList, "CountryName", "CountryId");
        }

        private void PopulateStates(DropDownList ddl, int countryId)
        {
            List<StateModel> stateList = Business.Business.GetStateList(countryId);
            BindDropDownList(ddl, stateList, "StateName", "StateId");
        }

        protected void PresentCountryState(object sender, EventArgs e)
        {
            int selectedCountryId = Convert.ToInt32(ddlPresentAddressCountry.SelectedValue);
            PopulateStates(ddlPresentAddressState, selectedCountryId);
        }

        protected void PermanentCountryState(object sender, EventArgs e)
        {
            int selectedCountryId = Convert.ToInt32(ddlPermanentAddressCountry.SelectedValue);
            PopulateStates(ddlPermanentAddressState, selectedCountryId);
        }

        protected void SameAsPresent_Check(object sender, EventArgs e)
        {
            if (chkSameAsPresent.Checked)
            {
                txtPermanentAddressHouseNo.Text=txtPresentAddressHouse.Text;
                txtPermanentAddressStreet.Text=txtPresentAddressStreet.Text;
                txtPermanentAddressCity.Text=txtPresentAddressCity.Text;
                txtPermanentAddressPincode.Text=txtPresentAddressPincode.Text;
                ddlPermanentAddressCountry.SelectedValue = ddlPresentAddressCountry.SelectedValue;
                ddlPermanentAddressState.SelectedValue = ddlPresentAddressState.SelectedValue;
            }
            else
            {
                ddlPermanentAddressCountry.SelectedIndex = 0;
                ddlPermanentAddressState.SelectedIndex = 0;
                txtPermanentAddressHouseNo.Text = "";
                txtPermanentAddressStreet.Text = "";
                txtPermanentAddressCity.Text = "";
                txtPermanentAddressPincode.Text = "";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                FatherFirstName = txtFatherFirstName.Text,
                FatherMiddleName = txtFatherMiddleName.Text,
                FatherLastName = txtFatherLastName.Text,
                MotherFirstName = txtMotherFirstName.Text,
                MotherMiddleName = txtMotherMiddleName.Text,
                MotherLastName = txtMotherLastName.Text,
                Email = txtEmail.Text,
                Dob = txtDateOfBirth.Text,
                BloodGroup = ddlBloodGroup.SelectedValue,
                MobileNo = txtMobile.Text,
                IDType = ddlIdType.SelectedValue,
                IDNo = txtIdNumber.Text,
                Gender = GetSelectedGender(),
                Hobbies = GetSelectedHobbies()
            };
            AddressModel presentAddress = new AddressModel
            {
                Type = 0,
                DoorNo = txtPresentAddressHouse.Text,
                Street=txtPresentAddressStreet.Text,
                City=txtPresentAddressCity.Text,
                PostalCode=txtPresentAddressPincode.Text,
                Country=ddlPresentAddressCountry.SelectedValue,
                State=ddlPresentAddressState.SelectedValue,
            };
            AddressModel permanentAddress = new AddressModel
            {
                Type = 0,
                DoorNo = txtPermanentAddressHouseNo.Text,
                Street = txtPermanentAddressStreet.Text,
                City = txtPermanentAddressCity.Text,
                PostalCode = txtPresentAddressPincode.Text,
                Country = ddlPresentAddressCountry.Text,
                State = ddlPresentAddressState.SelectedValue,
            };
            Business.Business.SubmitUser(user);
            Response.Redirect("UserList.aspx");
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Request.QueryString["UserId"]);
            UserModel user = new UserModel
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                FatherFirstName = txtFatherFirstName.Text,
                FatherMiddleName = txtFatherMiddleName.Text,
                FatherLastName = txtFatherLastName.Text,
                MotherFirstName = txtMotherFirstName.Text,
                MotherMiddleName = txtMotherMiddleName.Text,
                MotherLastName = txtMotherLastName.Text,
                Email = txtEmail.Text,
                Dob = txtDateOfBirth.Text,
                BloodGroup = ddlBloodGroup.SelectedValue,
                MobileNo = txtMobile.Text,
                IDType = ddlIdType.SelectedValue,
                IDNo = txtIdNumber.Text,
                Gender = GetSelectedGender(),
                Hobbies = GetSelectedHobbies()
            };
            Business.Business.UpdateUser(userId, user);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(Request.QueryString["ID"]);
            Business.Business.DeleteUser(userId);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Deleted User Successfully');", true);
            Response.Redirect("UserList.aspx");
        }

        private string GetSelectedGender()
        {
            if (rbMale.Checked)
                return rbMale.Text;
            else if (rbFemale.Checked)
                return rbFemale.Text;
            else if (rbOthers.Checked)
                return rbOthers.Text;
            else
                return string.Empty;
        }

        private string GetSelectedHobbies()
        {
            string hobbies = "";

            if (chkReading.Checked)
                hobbies += chkReading.Text + ",";
            if (chkSinging.Checked)
                hobbies += chkSinging.Text + ",";
            if (chkDancing.Checked)
                hobbies += chkDancing.Text + ",";
            if (chkTraveling.Checked)
                hobbies += chkTraveling.Text + ",";
            if (chkGaming.Checked)
                hobbies += chkGaming.Text + ",";
            if (chkCoding.Checked)
                hobbies += chkCoding.Text + ",";
            if (!string.IsNullOrEmpty(hobbies))
                hobbies = hobbies.TrimEnd(',');

            return hobbies;
        }


    }
}