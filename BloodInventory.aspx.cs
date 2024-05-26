using BloodBankManagement.BusinessLayer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace BloodBankManagement
    {
    public partial class Inventory : System.Web.UI.Page
        {
        private readonly BloodInventoryBLL bloodInventoryBLL = new BloodInventoryBLL();

        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                BindBloodInventoryGrid();
                BindBloodGroupDropdown();
                BindTransferToDropdown();
                }
            }

        private void BindBloodInventoryGrid()
            {
            gvBloodInventory.DataSource = bloodInventoryBLL.GetAllBloodInventory();
            gvBloodInventory.DataBind();
            }

        private void BindBloodGroupDropdown()
            {
            ddlBloodGroup.DataSource = bloodInventoryBLL.GetUniqueBloodGroups();
            ddlBloodGroup.DataTextField = "BloodGroup";
            ddlBloodGroup.DataValueField = "BloodGroup";
            ddlBloodGroup.DataBind();
            }

        private void BindTransferToDropdown()
            {
            ddlTransferTo.DataSource = bloodInventoryBLL.GetTransferToOptions();
            ddlTransferTo.DataTextField = "Name";
            ddlTransferTo.DataValueField = "Name";
            ddlTransferTo.DataBind();
            }

        protected void ddlBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (ddlBloodGroup.SelectedValue != "")
                {
                string selectedBloodGroup = ddlBloodGroup.SelectedValue;
                DataTable totalBottlesTable = bloodInventoryBLL.GetTotalBottlesByBloodGroup(selectedBloodGroup);
                if (totalBottlesTable.Rows.Count > 0)
                    {
                    lblTotalBottles.Text = totalBottlesTable.Rows[0]["TotalBottles"].ToString();
                    }
                else
                    {
                    lblTotalBottles.Text = "0";
                    }
                }
            }

        protected void btnAddInventory_Click(object sender, EventArgs e)
            {
            mvInventory.ActiveViewIndex = 1;
            }

        protected void btnSaveInventory_Click(object sender, EventArgs e)
            {
            try
                {
                string bloodGroup = ddlBloodGroup.SelectedValue;
                int numberOfBottles = Convert.ToInt32(lblTotalBottles.Text);
                string transferTo = ddlTransferTo.SelectedValue;
                int transferNo = Convert.ToInt32(txtTransferNo.Text);

                bloodInventoryBLL.AddBloodInventory(bloodGroup, numberOfBottles, transferTo, transferNo);
                BindBloodInventoryGrid();
                mvInventory.ActiveViewIndex = 0;
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = "An error occurred: " + ex.Message;
                }
            }

        protected void btnCancel_Click(object sender, EventArgs e)
            {
            mvInventory.ActiveViewIndex = 0;
            }

        protected void gvBloodInventory_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            try
                {
                int bloodInventoryID = Convert.ToInt32(gvBloodInventory.DataKeys[e.RowIndex].Value);
                bloodInventoryBLL.DeleteBloodInventory(bloodInventoryID);
                BindBloodInventoryGrid();
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = "An error occurred while deleting the blood inventory: " + ex.Message;
                }
            }
        }
    }
