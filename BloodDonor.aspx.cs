


using BloodBankManagement.BusinessLayer;
using BloodBankManagement.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBankManagement
    {
    public partial class BloodDonor : Page
        {
        private readonly BloodDonorBLL bloodDonorBLL;

        public BloodDonor()
            {
            bloodDonorBLL = new BloodDonorBLL();
            }

        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                LoadBloodDonors();
                }
            }

        private void LoadBloodDonors()
            {
            List<BloodBankManagement.Entities.BloodDonor> donors = bloodDonorBLL.GetAllBloodDonors();
            gvBloodDonors.DataSource = donors;
            gvBloodDonors.DataBind();
            }

        protected void btnAddNew_Click(object sender, EventArgs e)
            {
            mvBloodDonor.SetActiveView(ViewAdd);
            }

        protected void btnAdd_Click(object sender, EventArgs e)
            {
            try
                {
                BloodBankManagement.Entities.BloodDonor donor = new BloodBankManagement.Entities.BloodDonor
                    {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    ContactNumber = txtContactNumber.Text.Trim(),
                    BloodGroup = txtBloodGroup.Text.Trim()
                    };
                bloodDonorBLL.AddBloodDonor(donor);

                txtFirstName.Text = String.Empty;
                txtLastName.Text = String.Empty;
                txtAddress.Text = String.Empty;
                txtCity.Text = String.Empty;
                txtContactNumber.Text = String.Empty;
                txtBloodGroup.Text = String.Empty;
                LoadBloodDonors();
                mvBloodDonor.SetActiveView(ViewList);
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void btnCancelAdd_Click(object sender, EventArgs e)
            {
            mvBloodDonor.SetActiveView(ViewList);
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtContactNumber.Text = String.Empty;
            txtBloodGroup.Text = String.Empty;
        }

        protected void gvBloodDonors_RowEditing(object sender, GridViewEditEventArgs e)
            {
            gvBloodDonors.EditIndex = e.NewEditIndex;
            LoadBloodDonors();
            }

        protected void gvBloodDonors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
            gvBloodDonors.EditIndex = -1;
            LoadBloodDonors();
            }

        protected void gvBloodDonors_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
            try
                {
                GridViewRow row = gvBloodDonors.Rows[e.RowIndex];
                int donorId = Convert.ToInt32(gvBloodDonors.DataKeys[e.RowIndex].Value);
                string firstName = ((TextBox)row.FindControl("txtEditFirstName")).Text.Trim();
                string lastName = ((TextBox)row.FindControl("txtEditLastName")).Text.Trim();
                string address = ((TextBox)row.FindControl("txtEditAddress")).Text.Trim();
                string city = ((TextBox)row.FindControl("txtEditCity")).Text.Trim();
                string contactNumber = ((TextBox)row.FindControl("txtEditContactNumber")).Text.Trim();
                string bloodGroup = ((TextBox)row.FindControl("txtEditBloodGroup")).Text.Trim();

                BloodBankManagement.Entities.BloodDonor donor = new BloodBankManagement.Entities.BloodDonor
                    {
                    BloodDonorId = donorId,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city,
                    ContactNumber = contactNumber,
                    BloodGroup = bloodGroup
                    };

                bloodDonorBLL.UpdateBloodDonor(donor);
                gvBloodDonors.EditIndex = -1;
                LoadBloodDonors();
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void gvBloodDonors_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            try
                {
                int donorId = Convert.ToInt32(gvBloodDonors.DataKeys[e.RowIndex].Value);
                bloodDonorBLL.DeleteBloodDonor(donorId);
                LoadBloodDonors();
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void btnSearch_Click(object sender, EventArgs e)
            {
            try
                {
                string searchBy = ddlSearchBy.SelectedValue;
                string searchText = txtSearch.Text.Trim();

                List<BloodBankManagement.Entities.BloodDonor> donors = bloodDonorBLL.SearchBloodDonors(searchBy, searchText);
                gvBloodDonors.DataSource = donors;
                gvBloodDonors.DataBind();
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void btnUpdate_Click(object sender, EventArgs e)
            {
            try
                {
                int donorId = (int)ViewState["DonorID"];
                BloodBankManagement.Entities.BloodDonor donor = new BloodBankManagement.Entities.BloodDonor
                    {
                    BloodDonorId = donorId,
                    FirstName = txtUpdateFirstName.Text.Trim(),
                    LastName = txtUpdateLastName.Text.Trim(),
                    Address = txtUpdateAddress.Text.Trim(),
                    City = txtUpdateCity.Text.Trim(),
                    ContactNumber = txtUpdateContactNumber.Text.Trim(),
                    BloodGroup = txtUpdateBloodGroup.Text.Trim()
                    };
                bloodDonorBLL.UpdateBloodDonor(donor);
                LoadBloodDonors();
                mvBloodDonor.SetActiveView(ViewList);
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void btnCancelUpdate_Click(object sender, EventArgs e)
            {
            mvBloodDonor.SetActiveView(ViewList);
            }

        protected void gvBloodDonors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }