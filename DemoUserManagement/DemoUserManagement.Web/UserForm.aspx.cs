using DemoUserManagement.Business;
using DemoUserManagement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                ddlPresentAddressCountry.SelectedIndexChanged += PresentCountryState;
                ddlPermanentAddressCountry.SelectedIndexChanged += PermanentCountryState;
                ShowButton(false);
                if (!string.IsNullOrEmpty(Request.QueryString["UserId"]))
                {
                    NotesUserControl.Visible = true;
                }
                else
                {
                    NotesUserControl.Visible = false;
                }
            }
            
            if (IsEditMode)
            {
                if (Session["UserDetails"] != null)
                {
                    ShowButton(true);
                    UserModel user = (UserModel)Session["UserDetails"];
                    txtFirstName.Text = user.FirstName;
                    txtLastName.Text = user.LastName;
                    txtFirstName.Text = user.FirstName;
                    txtMiddleName.Text = user.MiddleName;
                    txtLastName.Text = user.LastName;
                    txtFatherFirstName.Text = user.FatherFirstName;
                    txtFatherMiddleName.Text = user.FatherMiddleName;
                    txtFatherLastName.Text = user.FatherLastName;
                    txtMotherFirstName.Text = user.MotherFirstName;
                    txtMotherMiddleName.Text = user.MotherMiddleName;
                    txtMotherLastName.Text = user.MotherLastName;
                    txtEmail.Text = user.Email;
                    if (user.Dob.HasValue)
                    {
                        txtDateOfBirth.Text = user.Dob.Value.ToString("yyyy-MM-dd");
                    }
                    ddlBloodGroup.SelectedValue = user.BloodGroup;
                    txtMobile.Text = user.MobileNo;
                    ddlIdType.SelectedValue = user.IDType;
                    txtIdNumber.Text = user.IDNo;

                    if (user.Gender == "Male")
                        rbMale.Checked = true;
                    else if (user.Gender == "Female")
                        rbFemale.Checked = true;
                    else if (user.Gender == "Others")
                        rbOthers.Checked = true;

                    string[] hobbies = user.Hobbies.Split(',');
                    foreach (string hobby in hobbies)
                    {
                        if (hobby == "Reading")
                            chkReading.Checked = true;
                        else if (hobby == "Singing")
                            chkSinging.Checked = true;
                        else if (hobby == "Dancing")
                            chkDancing.Checked = true;
                        else if (hobby == "Traveling")
                            chkTraveling.Checked = true;
                        else if (hobby == "Gaming")
                            chkGaming.Checked = true;
                        else if (hobby == "Coding")
                            chkCoding.Checked = true;
                    }
                    if (user.PresentAddress != null)
                    {
                        txtPresentAddressHouse.Text = user.PresentAddress.DoorNo;
                        txtPresentAddressStreet.Text = user.PresentAddress.Street;
                        txtPresentAddressCity.Text = user.PresentAddress.City;
                        txtPresentAddressPincode.Text = user.PresentAddress.PostalCode;
                        string selectedCountryName = GetCountryNameById(user.PresentAddress.CountryId);
                        ddlPresentAddressCountry.SelectedValue = user.PresentAddress.CountryId.ToString();
                        PopulateStates(ddlPresentAddressState, user.PresentAddress.CountryId); 

                        string selectedStateName = GetStateNameById(user.PresentAddress.StateId, user.PresentAddress.CountryId);
                        if (!string.IsNullOrEmpty(selectedStateName))
                        {
                            if (ddlPresentAddressState.Items.FindByText(selectedStateName) != null)
                            {
                                ddlPresentAddressState.SelectedValue = user.PresentAddress.StateId.ToString();
                            }
                        }
                    }

                    if (user.PermanentAddress != null)
                    {
                        txtPermanentAddressHouseNo.Text = user.PermanentAddress.DoorNo;
                        txtPermanentAddressStreet.Text = user.PermanentAddress.Street;
                        txtPermanentAddressCity.Text = user.PermanentAddress.City;
                        txtPermanentAddressPincode.Text = user.PermanentAddress.PostalCode;
                        string selectedCountryName = GetCountryNameById(user.PermanentAddress.CountryId);
                        ddlPermanentAddressCountry.SelectedValue = user.PermanentAddress.CountryId.ToString();
                        PopulateStates(ddlPermanentAddressState, user.PermanentAddress.CountryId); 

                        string selectedStateName = GetStateNameById(user.PermanentAddress.StateId, user.PermanentAddress.CountryId); 
                        if (!string.IsNullOrEmpty(selectedStateName))
                        {
                            
                            if (ddlPermanentAddressState.Items.FindByText(selectedStateName) != null)
                            {
                                ddlPermanentAddressState.SelectedValue = user.PermanentAddress.StateId.ToString();
                            }
                        }
                    }
                    Session["UserDetails"] = null;
                }
            }
        }
        private bool IsEditMode
        {
            get
            {
                string editQueryString = Request.QueryString["UserId"];
                if (!string.IsNullOrEmpty(editQueryString))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ShowButton(bool button)
        {
            if (button)
            {
                bttnSubmit.Visible = false;
                bttnEdit.Visible = true;
            }
            else
            {
                bttnSubmit.Visible = true;
                bttnEdit.Visible = false;
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

        private Dictionary<int, string> PopulateCountries()
        {
            List<CountryModel> countryList = Business.Business.GetCountryList();
            Dictionary<int, string> countryDictionary = new Dictionary<int, string>();

            foreach (CountryModel country in countryList)
            {
                countryDictionary.Add(country.CountryId, country.CountryName);
            }

            BindDropDownList(ddlPresentAddressCountry, countryList, "CountryName", "CountryId");
            BindDropDownList(ddlPermanentAddressCountry, countryList, "CountryName", "CountryId");

            return countryDictionary;
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


        private string GetCountryNameById(int countryId)
        {
            List<CountryModel> countryList = Business.Business.GetCountryList();
            CountryModel country = countryList.FirstOrDefault(c => c.CountryId == countryId);
            return country != null ? country.CountryName : null;
        }
        public string GetStateNameById(int stateId,int countryId)
        {
            List<StateModel> states = Business.Business.GetStateList(countryId);
            StateModel state = states.FirstOrDefault(s => s.StateId == stateId);
            return state != null ? state.StateName : null;
        }
        protected void SameAsPresent_Check(object sender, EventArgs e)
        {
            if (chkSameAsPresent.Checked)
            {
                txtPermanentAddressHouseNo.Text = txtPresentAddressHouse.Text;
                txtPermanentAddressStreet.Text = txtPresentAddressStreet.Text;
                txtPermanentAddressCity.Text = txtPresentAddressCity.Text;
                txtPermanentAddressPincode.Text = txtPresentAddressPincode.Text;
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
                Dob  = ParseDateOfBirth(txtDateOfBirth.Text),
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
                Street = txtPresentAddressStreet.Text,
                City = txtPresentAddressCity.Text,
                PostalCode = txtPresentAddressPincode.Text,
                CountryId = int.Parse(ddlPresentAddressCountry.SelectedValue), 
                StateId = int.Parse(ddlPresentAddressState.SelectedValue),
            };
            AddressModel permanentAddress = new AddressModel
            {
                Type = 1,
                DoorNo = txtPermanentAddressHouseNo.Text,
                Street = txtPermanentAddressStreet.Text,
                City = txtPermanentAddressCity.Text,
                PostalCode = txtPermanentAddressPincode.Text,
                CountryId = int.Parse(ddlPermanentAddressCountry.SelectedValue),
                StateId = int.Parse(ddlPermanentAddressState.SelectedValue)
            };
            Business.Business business = new Business.Business();
            business.AddUserAddress(user, presentAddress, permanentAddress);
            Response.Redirect("UserList.aspx");
        }

        private DateTime? ParseDateOfBirth(string text)
        {
            DateTime dob;
            if (DateTime.TryParseExact(text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                return dob;
            else
                return null;
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
                Dob = ParseDateOfBirth(txtDateOfBirth.Text),
                BloodGroup = ddlBloodGroup.SelectedValue,
                MobileNo = txtMobile.Text,
                IDType = ddlIdType.SelectedValue,
                IDNo = txtIdNumber.Text,
                Gender = GetSelectedGender(),
                Hobbies = GetSelectedHobbies(),
                PresentAddress = new AddressModel
                {
                    DoorNo = txtPresentAddressHouse.Text,
                    Street = txtPresentAddressStreet.Text,
                    City = txtPresentAddressCity.Text,
                    PostalCode = txtPresentAddressPincode.Text,
                    CountryId = int.Parse(ddlPresentAddressCountry.SelectedValue),
                    StateId = int.Parse(ddlPresentAddressState.SelectedValue),
                },
                PermanentAddress = new AddressModel
                {
                    DoorNo = txtPermanentAddressHouseNo.Text,
                    Street = txtPermanentAddressStreet.Text,
                    City = txtPermanentAddressCity.Text,
                    PostalCode = txtPermanentAddressPincode.Text,
                    CountryId = int.Parse(ddlPermanentAddressCountry.SelectedValue),
                    StateId = int.Parse(ddlPermanentAddressState.SelectedValue),
                }
            };
            Business.Business.UpdateUser(userId, user);
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