using BloodBankManagement.BusinessLayer;
using BloodBankManagement.Entities;
using BloodBankManagement.Exception;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBankManagement
    {
    public partial class BloodBank : Page
        {
        private readonly BloodBankBLL bloodBankBLL;

        public BloodBank()
            {
            bloodBankBLL = new BloodBankBLL();
            }

        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                LoadBloodBanks();
                }
            }

        private void LoadBloodBanks()
        {
            try
            {
                List<BloodBankManagement.Entities.BloodBank> banks = bloodBankBLL.GetAllBloodBanks();
                gvBloodBanks.DataSource = banks;
                gvBloodBanks.DataBind();
            }
            catch(BloodBankException ex) 
            {
                throw new BloodBankException("An error occurred while loading a blood bank.", ex);
            }

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
            {
            mvBloodBank.SetActiveView(ViewAdd);
            }

        protected void btnAdd_Click(object sender, EventArgs e)
            {
            try
                {
                BloodBankManagement.Entities.BloodBank bank = new BloodBankManagement.Entities.BloodBank
                    {
                    BloodBankName = txtBankName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    ContactNumber = txtContactNumber.Text.Trim(),
                    UserId = txtUserId.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                    };
                bloodBankBLL.AddBloodBank(bank);
                txtBankName.Text=string.Empty;
                txtAddress.Text=string.Empty;
                txtCity.Text=string.Empty;
                txtContactNumber.Text=string.Empty;
                txtUserId.Text=string.Empty;
                txtPassword.Text=string.Empty;
                LoadBloodBanks();
                mvBloodBank.SetActiveView(ViewList);
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void btnCancelAdd_Click(object sender, EventArgs e)
            {
            mvBloodBank.SetActiveView(ViewList);
            }

        protected void gvBloodBanks_RowEditing(object sender, GridViewEditEventArgs e)
            {
            gvBloodBanks.EditIndex = e.NewEditIndex;
            LoadBloodBanks();
            }

        protected void gvBloodBanks_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
            try
                {
                GridViewRow row = gvBloodBanks.Rows[e.RowIndex];
                int bankId = Convert.ToInt32(gvBloodBanks.DataKeys[e.RowIndex].Value);

                TextBox txtEditBankName = (TextBox)row.FindControl("txtEditBankName");
                TextBox txtEditAddress = (TextBox)row.FindControl("txtEditAddress");
                TextBox txtEditCity = (TextBox)row.FindControl("txtEditCity");
                TextBox txtEditContactNumber = (TextBox)row.FindControl("txtEditContactNumber");
                TextBox txtEditUserId = (TextBox)row.FindControl("txtEditUserId");
                TextBox txtEditPassword = (TextBox)row.FindControl("txtEditPassword");

                BloodBankManagement.Entities.BloodBank bank = new BloodBankManagement.Entities.BloodBank
                    {
                    BloodBankID = bankId,
                    BloodBankName = txtEditBankName.Text.Trim(),
                    Address = txtEditAddress.Text.Trim(),
                    City = txtEditCity.Text.Trim(),
                    ContactNumber = txtEditContactNumber.Text.Trim(),
                    UserId = txtEditUserId.Text.Trim(),
                    Password = txtEditPassword.Text.Trim()
                    };

                bloodBankBLL.UpdateBloodBank(bank);
                gvBloodBanks.EditIndex = -1;
                LoadBloodBanks();
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void gvBloodBanks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
            gvBloodBanks.EditIndex = -1;
            LoadBloodBanks();
            }

        protected void gvBloodBanks_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            try
                {
                int bankId = Convert.ToInt32(gvBloodBanks.DataKeys[e.RowIndex].Value);
                bloodBankBLL.DeleteBloodBank(bankId);
                LoadBloodBanks();
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }
        }
    }
