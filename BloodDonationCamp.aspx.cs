using System;
using System.Collections.Generic;
using BloodBankManagement.Entities;
using BloodBankManagement.BusinessLayer;
using BloodBankManagement.DataAccessLayer;
using System.Web.UI.WebControls;

namespace BloodBankManagement
    {
    public partial class BloodDonationCamp : System.Web.UI.Page
        {
        private readonly BloodDonationCampBLL bloodDonationCampBLL;
        private readonly BloodBankBLL bloodBankBLL;

        public BloodDonationCamp()
            {
            bloodDonationCampBLL = new BloodDonationCampBLL(new BloodDonationCampDAL());
            bloodBankBLL = new BloodBankBLL();
            }

        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                LoadBloodDonationCamps();
                LoadBloodBanksDropdown();
                }
            }

        private void LoadBloodBanksDropdown()
            {
            List<BloodBankManagement.Entities.BloodBank> bloodBanks = bloodBankBLL.GetAllBloodBanks();
            ddlBloodBank.DataSource = bloodBanks;
            ddlBloodBank.DataTextField = "BloodBankName";
            ddlBloodBank.DataValueField = "BloodBankID";
            ddlBloodBank.DataBind();
            ddlBloodBank.Items.Insert(0, new ListItem("Select Blood Bank", ""));
            }

        private void LoadBloodDonationCamps()
            {
            List<BloodBankManagement.Entities.BloodDonationCamp> camps = bloodDonationCampBLL.GetAllBloodDonationCamps();
            gvBloodDonationCamps.DataSource = camps;
            gvBloodDonationCamps.DataBind();
            }

        protected void btnViewAllCamps_Click(object sender, EventArgs e)
            {
            mvBloodDonationCamps.SetActiveView(viewAllCamps);
            LoadBloodDonationCamps();
            }

        protected void btnAddCamp_Click(object sender, EventArgs e)
            {
            mvBloodDonationCamps.SetActiveView(viewAddCamp);
            ClearAddCampForm();
            }

        private void ClearAddCampForm()
            {
            txtCampName.Text = string.Empty;
            txtCampAddress.Text = string.Empty;
            txtCampCity.Text = string.Empty;
            ddlBloodBank.SelectedIndex = 0;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            }

        protected void btnSaveCamp_Click(object sender, EventArgs e)
            {
            BloodBankManagement.Entities.BloodDonationCamp camp = new BloodBankManagement.Entities.BloodDonationCamp
                {
                CampName = txtCampName.Text,
                Address = txtCampAddress.Text,
                City = txtCampCity.Text,
                BloodBankID = Convert.ToInt32(ddlBloodBank.SelectedValue),
                CampStartDate = DateTime.Parse(txtStartDate.Text),
                CampEndDate = DateTime.Parse(txtEndDate.Text)
                };

            bloodDonationCampBLL.AddBloodDonationCamp(camp);
            mvBloodDonationCamps.SetActiveView(viewAllCamps);
            LoadBloodDonationCamps();
            }

        protected void btnCancel_Click(object sender, EventArgs e)
            {
            mvBloodDonationCamps.SetActiveView(viewAllCamps);
            }

        protected void gvBloodDonationCamps_RowEditing(object sender, GridViewEditEventArgs e)
            {
            gvBloodDonationCamps.EditIndex = e.NewEditIndex;
            LoadBloodDonationCamps();

            GridViewRow row = gvBloodDonationCamps.Rows[e.NewEditIndex];
            DropDownList ddlBloodBank = row.FindControl("ddlBloodBank") as DropDownList;
            if (ddlBloodBank != null)
                {
                List<BloodBankManagement.Entities.BloodBank> bloodBanks = bloodBankBLL.GetAllBloodBanks();
                ddlBloodBank.DataSource = bloodBanks;
                ddlBloodBank.DataTextField = "BloodBankName";
                ddlBloodBank.DataValueField = "BloodBankID";
                ddlBloodBank.DataBind();

                // Set the selected value
                HiddenField hfBloodBankID = row.FindControl("hfBloodBankID") as HiddenField;
                if (hfBloodBankID != null)
                    {
                    ddlBloodBank.SelectedValue = hfBloodBankID.Value;
                    }
                }
            }

        protected void gvBloodDonationCamps_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
            GridViewRow row = gvBloodDonationCamps.Rows[e.RowIndex];
            int campID = Convert.ToInt32(gvBloodDonationCamps.DataKeys[e.RowIndex].Values["BloodDonationCampID"]);

            TextBox txtCampName = row.FindControl("txtCampName") as TextBox;
            TextBox txtAddress = row.FindControl("txtAddress") as TextBox;
            TextBox txtCity = row.FindControl("txtCity") as TextBox;
            DropDownList ddlBloodBank = row.FindControl("ddlBloodBank") as DropDownList;
            TextBox txtStartDate = row.FindControl("txtStartDate") as TextBox;
            TextBox txtEndDate = row.FindControl("txtEndDate") as TextBox;

            BloodBankManagement.Entities.BloodDonationCamp camp = new BloodBankManagement.Entities.BloodDonationCamp
                {
                BloodDonationCampID = campID,
                CampName = txtCampName.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                BloodBankID = Convert.ToInt32(ddlBloodBank.SelectedValue),
                CampStartDate = DateTime.Parse(txtStartDate.Text),
                CampEndDate = DateTime.Parse(txtEndDate.Text)
                };

            bloodDonationCampBLL.UpdateBloodDonationCamp(camp);
            gvBloodDonationCamps.EditIndex = -1;
            LoadBloodDonationCamps();
            }

        protected void gvBloodDonationCamps_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
            gvBloodDonationCamps.EditIndex = -1;
            LoadBloodDonationCamps();
            }

        protected void gvBloodDonationCamps_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            int campID = Convert.ToInt32(gvBloodDonationCamps.DataKeys[e.RowIndex].Values["BloodDonationCampID"]);
            bloodDonationCampBLL.DeleteBloodDonationCamp(campID);
            LoadBloodDonationCamps();
            }
        }
    }
