//using BloodBankManagement.BusinessLayer;
//using BloodBankManagement.Entities;
//using System;
//using System.Collections.Generic;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace BloodBankManagement
//    {
//    public partial class BloodDonorDonation : Page
//        {
//        private readonly BloodDonorDonationBLL bloodDonorDonationBLL;
//        private readonly BloodDonorBLL bloodDonorBLL;

//        public BloodDonorDonation()
//            {
//            bloodDonorDonationBLL = new BloodDonorDonationBLL();
//            bloodDonorBLL = new BloodDonorBLL();
//            }

//        protected void Page_Load(object sender, EventArgs e)
//            {
//            if (!IsPostBack)
//                {
//                LoadDonors();
//                LoadDonations();
//                }
//            }

//        private void LoadDonors()
//            {
//                List<BloodBankManagement.Entities.BloodDonor> donors = bloodDonorBLL.GetAllBloodDonors();
//                ddlDonorID.DataSource = donors;
//                ddlDonorID.DataTextField = "BloodDonorID";
//                ddlDonorID.DataValueField = "BloodDonorID";
//                ddlDonorID.DataBind();
//            }

//        private void LoadDonations()
//            {
//                List<BloodBankManagement.Entities.BloodDonorDonation> donations = bloodDonorDonationBLL.GetAllBloodDonorDonations();
//                gvBloodDonorDonations.DataSource = donations;
//                gvBloodDonorDonations.DataBind();
//            }

//        protected void btnAddNew_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewAdd);
//            }

//        protected void btnAdd_Click(object sender, EventArgs e)
//            {
//            try
//                {
//                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                    {
//                    BloodDonorID = int.Parse(ddlDonorID.SelectedValue),
//                    BloodDonationDate = DateTime.Parse(txtDonationDate.Text),
//                    NumberofBottle = int.Parse(txtNumberofBottle.Text),
//                    Weight = decimal.Parse(txtWeight.Text),
//                    HBCount = decimal.Parse(txtHBCount.Text)
//                    };
//                bloodDonorDonationBLL.AddBloodDonorDonation(donation);
//                LoadDonations();
//                mvBloodDonorDonation.SetActiveView(ViewList);
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessageAdd.Text = ex.Message;
//                }
//            }

//        protected void btnCancelAdd_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewList);
//            }

//        protected void btnUpdate_Click(object sender, EventArgs e)
//            {
//            try
//                {
//                int donationID = (int)ViewState["DonationID"];
//                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                    {
//                    BloodDonationID = donationID,
//                    BloodDonorID = int.Parse(ddlUpdateDonorID.SelectedValue),
//                    BloodDonationDate = DateTime.Parse(txtUpdateDonationDate.Text),
//                    NumberofBottle = int.Parse(txtUpdateNumberofBottle.Text),
//                    Weight = decimal.Parse(txtUpdateWeight.Text),
//                    HBCount = decimal.Parse(txtUpdateHBCount.Text)
//                    };
//                bloodDonorDonationBLL.UpdateBloodDonorDonation(donation);
//                LoadDonations();
//                mvBloodDonorDonation.SetActiveView(ViewList);
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessageUpdate.Text = ex.Message;
//                }
//            }

//        protected void btnCancelUpdate_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewList);
//            }

//        protected void gvBloodDonorDonations_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
//            {
//            try
//                {
//                GridViewRow row = gvBloodDonorDonations.Rows[e.NewEditIndex];
//                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.NewEditIndex].Value);

//                BloodBankManagement.Entities.BloodDonorDonation donation = bloodDonorDonationBLL.GetAllBloodDonorDonations().Find(d => d.BloodDonationID == donationID);

//                ddlUpdateDonorID.SelectedValue = donation.BloodDonorID.ToString();
//                txtUpdateDonationDate.Text = donation.BloodDonationDate.ToString();
//                txtUpdateNumberofBottle.Text = donation.NumberofBottle.ToString();
//                txtUpdateWeight.Text = donation.Weight.ToString();
//                txtUpdateHBCount.Text = donation.HBCount.ToString();

//                ViewState["DonationID"] = donation.BloodDonationID;
//                mvBloodDonorDonation.SetActiveView(ViewUpdate);
//                }
//            catch (System.Exception ex)
//                {
//                HandleError(ex);
//                }
//            }

//        protected void gvBloodDonorDonations_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
//            {
//                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.RowIndex].Value);
//                bloodDonorDonationBLL.DeleteBloodDonorDonation(donationID);
//                LoadDonations();
//            }

//        private void HandleError(System.Exception ex)
//            {
//            lblErrorMessage.Text = ex.Message;
//            }
//        }
//    }


//using BloodBankManagement.BusinessLayer;
//using BloodBankManagement.Entities;
//using System;
//using System.Collections.Generic;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace BloodBankManagement
//    {
//    public partial class BloodDonorDonation : Page
//        {
//        private readonly BloodDonorDonationBLL bloodDonorDonationBLL;
//        private readonly BloodDonorBLL bloodDonorBLL;

//        public BloodDonorDonation()
//            {
//            bloodDonorDonationBLL = new BloodDonorDonationBLL();
//            bloodDonorBLL = new BloodDonorBLL();
//            }

//        protected void Page_Load(object sender, EventArgs e)
//            {
//            if (!IsPostBack)
//                {
//                LoadDonors();
//                LoadDonations();
//                }
//            }

//        private void LoadDonors()
//            {
//            List<BloodBankManagement.Entities.BloodDonor> donors = bloodDonorBLL.GetAllBloodDonors();
//            ddlDonorID.DataSource = donors;
//            ddlDonorID.DataTextField = "BloodDonorID";
//            ddlDonorID.DataValueField = "BloodDonorID";
//            ddlDonorID.DataBind();
//            }

//        private void LoadDonations()
//            {
//            List<BloodBankManagement.Entities.BloodDonorDonation> donations = bloodDonorDonationBLL.GetAllBloodDonorDonations();
//            gvBloodDonorDonations.DataSource = donations;
//            gvBloodDonorDonations.DataBind();
//            }

//        protected void btnAddNew_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewAdd);
//            }

//        protected void btnAdd_Click(object sender, EventArgs e)
//            {
//            try
//                {
//                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                    {
//                    BloodDonorID = int.Parse(ddlDonorID.SelectedValue),
//                    BloodDonationDate = DateTime.Parse(txtDonationDate.Text),
//                    NumberofBottle = int.Parse(txtNumberofBottle.Text),
//                    Weight = decimal.Parse(txtWeight.Text),
//                    HBCount = decimal.Parse(txtHBCount.Text)
//                    };
//                bloodDonorDonationBLL.AddBloodDonorDonation(donation);
//                LoadDonations();
//                mvBloodDonorDonation.SetActiveView(ViewList);
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessageAdd.Text = ex.Message;
//                }
//            }

//        protected void btnCancelAdd_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewList);
//            }

//        protected void btnUpdate_Click(object sender, EventArgs e)
//            {
//            try
//                {
//                int donationID = (int)ViewState["DonationID"];
//                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                    {
//                    BloodDonationID = donationID,
//                    BloodDonorID = int.Parse(ddlUpdateDonorID.SelectedValue),
//                    BloodDonationDate = DateTime.Parse(txtUpdateDonationDate.Text),
//                    NumberofBottle = int.Parse(txtUpdateNumberofBottle.Text),
//                    Weight = decimal.Parse(txtUpdateWeight.Text),
//                    HBCount = decimal.Parse(txtUpdateHBCount.Text)
//                    };
//                bloodDonorDonationBLL.UpdateBloodDonorDonation(donation);
//                LoadDonations();
//                mvBloodDonorDonation.SetActiveView(ViewList);
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessageUpdate.Text = ex.Message;
//                }
//            }

//        protected void btnCancelUpdate_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewList);
//            }

//        protected void gvBloodDonorDonations_RowEditing(object sender, GridViewEditEventArgs e)
//            {
//            try
//                {
//                GridViewRow row = gvBloodDonorDonations.Rows[e.NewEditIndex];
//                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.NewEditIndex].Value);

//                BloodBankManagement.Entities.BloodDonorDonation donation = bloodDonorDonationBLL.GetAllBloodDonorDonations().Find(d => d.BloodDonationID == donationID);

//                ddlUpdateDonorID.SelectedValue = donation.BloodDonorID.ToString();
//                txtUpdateDonationDate.Text = donation.BloodDonationDate.ToString("yyyy-MM-dd");
//                txtUpdateNumberofBottle.Text = donation.NumberofBottle.ToString();
//                txtUpdateWeight.Text = donation.Weight.ToString();
//                txtUpdateHBCount.Text = donation.HBCount.ToString();

//                ViewState["DonationID"] = donation.BloodDonationID;
//                mvBloodDonorDonation.SetActiveView(ViewUpdate);
//                }
//            catch (System.Exception ex)
//                {
//                HandleError(ex);
//                }
//            }

//        protected void gvBloodDonorDonations_RowUpdating(object sender, GridViewUpdateEventArgs e)
//            {
//            try
//                {
//                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.RowIndex].Value);
//                GridViewRow row = gvBloodDonorDonations.Rows[e.RowIndex];

//                DropDownList ddlUpdateDonorID = (DropDownList)row.FindControl("ddlUpdateDonorID");
//                TextBox txtUpdateDonationDate = (TextBox)row.FindControl("txtUpdateDonationDate");
//                TextBox txtUpdateNumberofBottle = (TextBox)row.FindControl("txtUpdateNumberofBottle");
//                TextBox txtUpdateWeight = (TextBox)row.FindControl("txtUpdateWeight");
//                TextBox txtUpdateHBCount = (TextBox)row.FindControl("txtUpdateHBCount");

//                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                    {
//                    BloodDonationID = donationID,
//                    BloodDonorID = int.Parse(ddlUpdateDonorID.SelectedValue),
//                    BloodDonationDate = DateTime.Parse(txtUpdateDonationDate.Text),
//                    NumberofBottle = int.Parse(txtUpdateNumberofBottle.Text),
//                    Weight = decimal.Parse(txtUpdateWeight.Text),
//                    HBCount = decimal.Parse(txtUpdateHBCount.Text)
//                    };

//                bloodDonorDonationBLL.UpdateBloodDonorDonation(donation);

//                gvBloodDonorDonations.EditIndex = -1;
//                LoadDonations();
//                }
//            catch (System.Exception ex)
//                {
//                HandleError(ex);
//                }
//            }

//        protected void gvBloodDonorDonations_RowDeleting(object sender, GridViewDeleteEventArgs e)
//            {
//            try
//                {
//                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.RowIndex].Value);
//                bloodDonorDonationBLL.DeleteBloodDonorDonation(donationID);
//                LoadDonations();
//                }
//            catch (SystemException ex)
//                {
//                HandleError(ex);
//                }
//            }

//        private void HandleError(System.Exception ex)
//            {
//            lblErrorMessage.Text = ex.Message;
//            }
//        }
//    }

//using BloodBankManagement.BusinessLayer;
//using BloodBankManagement.Entities;
//using System;
//using System.Collections.Generic;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace BloodBankManagement
//    {
//    public partial class BloodDonorDonation : Page
//        {
//        private readonly BloodDonorDonationBLL bloodDonorDonationBLL;
//        private readonly BloodDonorBLL bloodDonorBLL;

//        public BloodDonorDonation()
//            {
//            bloodDonorDonationBLL = new BloodDonorDonationBLL();
//            bloodDonorBLL = new BloodDonorBLL();
//            }

//        protected void Page_Load(object sender, EventArgs e)
//            {
//            if (!IsPostBack)
//                {
//                LoadDonors();
//                LoadDonations();
//                }
//            }

//        private void LoadDonors()
//            {
//            List<BloodBankManagement.Entities.BloodDonor> donors = bloodDonorBLL.GetAllBloodDonors();
//            ddlDonorID.DataSource = donors;
//            ddlDonorID.DataTextField = "BloodDonorID";
//            ddlDonorID.DataValueField = "BloodDonorID";
//            ddlDonorID.DataBind();

//            ddlUpdateDonorID.DataSource = donors;
//            ddlUpdateDonorID.DataTextField = "BloodDonorID";
//            ddlUpdateDonorID.DataValueField = "BloodDonorID";
//            ddlUpdateDonorID.DataBind();
//            }

//        private void LoadDonations()
//            {
//            List<BloodBankManagement.Entities.BloodDonorDonation> donations = bloodDonorDonationBLL.GetAllBloodDonorDonations();
//            gvBloodDonorDonations.DataSource = donations;
//            gvBloodDonorDonations.DataBind();
//            }

//        protected void btnAddNew_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewAdd);
//            }

//        protected void btnAdd_Click(object sender, EventArgs e)
//            {
//            try
//                {
//                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                    {
//                    BloodDonorID = int.Parse(ddlDonorID.SelectedValue),
//                    BloodDonationDate = DateTime.Parse(txtDonationDate.Text),
//                    NumberofBottle = int.Parse(txtNumberofBottle.Text),
//                    Weight = decimal.Parse(txtWeight.Text),
//                    HBCount = decimal.Parse(txtHBCount.Text)
//                    };
//                bloodDonorDonationBLL.AddBloodDonorDonation(donation);
//                LoadDonations();
//                mvBloodDonorDonation.SetActiveView(ViewList);
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessageAdd.Text = ex.Message;
//                }
//            }

//        protected void btnCancelAdd_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewList);
//            }

//        protected void btnUpdate_Click(object sender, EventArgs e)
//            {
//            try
//                {
//                int donationID = (int)ViewState["DonationID"];
//                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                    {
//                    BloodDonationID = donationID,
//                    BloodDonorID = int.Parse(ddlUpdateDonorID.SelectedValue),
//                    BloodDonationDate = DateTime.Parse(txtUpdateDonationDate.Text),
//                    NumberofBottle = int.Parse(txtUpdateNumberofBottle.Text),
//                    Weight = decimal.Parse(txtUpdateWeight.Text),
//                    HBCount = decimal.Parse(txtUpdateHBCount.Text)
//                    };
//                bloodDonorDonationBLL.UpdateBloodDonorDonation(donation);
//                LoadDonations();
//                mvBloodDonorDonation.SetActiveView(ViewList);
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessageUpdate.Text = ex.Message;
//                }
//            }

//        protected void btnCancelUpdate_Click(object sender, EventArgs e)
//            {
//            mvBloodDonorDonation.SetActiveView(ViewList);
//            }

//        protected void gvBloodDonorDonations_RowEditing(object sender, GridViewEditEventArgs e)
//            {
//            gvBloodDonorDonations.EditIndex = e.NewEditIndex;
//            LoadDonations();
//            }

//        protected void gvBloodDonorDonations_RowUpdating(object sender, GridViewUpdateEventArgs e)
//            {
//            try
//                {
//                GridViewRow row = gvBloodDonorDonations.Rows[e.RowIndex];
//                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.RowIndex].Value);

//                DropDownList ddlEditDonorID = (DropDownList)row.FindControl("ddlEditDonorID");
//                TextBox txtEditDonationDate = (TextBox)row.FindControl("txtEditDonationDate");
//                TextBox txtEditNumberofBottle = (TextBox)row.FindControl("txtEditNumberofBottle");
//                TextBox txtEditWeight = (TextBox)row.FindControl("txtEditWeight");
//                TextBox txtEditHBCount = (TextBox)row.FindControl("txtEditHBCount");

//                if (ddlEditDonorID != null && txtEditDonationDate != null && txtEditNumberofBottle != null && txtEditWeight != null && txtEditHBCount != null)
//                    {
//                    BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
//                        {
//                        BloodDonationID = donationID,
//                        BloodDonorID = int.Parse(ddlEditDonorID.SelectedValue),
//                        BloodDonationDate = DateTime.Parse(txtEditDonationDate.Text),
//                        NumberofBottle = int.Parse(txtEditNumberofBottle.Text),
//                        Weight = decimal.Parse(txtEditWeight.Text),
//                        HBCount = decimal.Parse(txtEditHBCount.Text)
//                        };

//                    bloodDonorDonationBLL.UpdateBloodDonorDonation(donation);
//                    gvBloodDonorDonations.EditIndex = -1;
//                    LoadDonations();
//                    }
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessage.Text = ex.Message;
//                }
//            }

//        protected void gvBloodDonorDonations_RowDeleting(object sender, GridViewDeleteEventArgs e)
//            {
//            try
//                {
//                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.RowIndex].Value);
//                bloodDonorDonationBLL.DeleteBloodDonorDonation(donationID);
//                LoadDonations();
//                }
//            catch (System.Exception ex)
//                {
//                lblErrorMessage.Text = ex.Message;
//                }
//            }

//        protected void gvBloodDonorDonations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//            {
//            gvBloodDonorDonations.EditIndex = -1;
//            LoadDonations();
//            }
//        }
//    }


using BloodBankManagement.BusinessLayer;
using BloodBankManagement.Entities;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodBankManagement
    {
    public partial class BloodDonorDonation : Page
        {
        private readonly BloodDonorDonationBLL bloodDonorDonationBLL;
        private readonly BloodDonorBLL bloodDonorBLL;

        public BloodDonorDonation()
            {
            bloodDonorDonationBLL = new BloodDonorDonationBLL();
            bloodDonorBLL = new BloodDonorBLL();
            }

        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                LoadDonors();
                LoadDonations();
                }
            }

        private void LoadDonors()
            {
            List<BloodBankManagement.Entities.BloodDonor> donors = bloodDonorBLL.GetAllBloodDonors();
            ddlDonorID.DataSource = donors;
            ddlDonorID.DataTextField = "BloodDonorID";
            ddlDonorID.DataValueField = "BloodDonorID";
            ddlDonorID.DataBind();
            }

        private void LoadDonations()
            {
            List<BloodBankManagement.Entities.BloodDonorDonation> donations = bloodDonorDonationBLL.GetAllBloodDonorDonations();
            gvBloodDonorDonations.DataSource = donations;
            gvBloodDonorDonations.DataBind();
            }

        protected void btnAddNew_Click(object sender, EventArgs e)
            {
            mvBloodDonorDonation.SetActiveView(ViewAdd);
            }

        protected void btnAdd_Click(object sender, EventArgs e)
            {
            try
                {
                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
                    {
                    BloodDonorID = int.Parse(ddlDonorID.SelectedValue),
                    BloodDonationDate = DateTime.Parse(txtDonationDate.Text),
                    NumberofBottle = int.Parse(txtNumberofBottle.Text),
                    Weight = decimal.Parse(txtWeight.Text),
                    HBCount = decimal.Parse(txtHBCount.Text)
                    };
                bloodDonorDonationBLL.AddBloodDonorDonation(donation);
                txtNumberofBottle.Text=string.Empty;
                txtWeight.Text=string.Empty;
                txtHBCount.Text=string.Empty;
                txtDonationDate.Text=string.Empty;
                ddlDonorID.Items.Clear();
                LoadDonations();
                mvBloodDonorDonation.SetActiveView(ViewList);
                }
            catch (System.Exception ex)
                {
                lblErrorMessageAdd.Text = ex.Message;
                }
            }

        protected void btnCancelAdd_Click(object sender, EventArgs e)
            {
            mvBloodDonorDonation.SetActiveView(ViewList);
            }

        protected void gvBloodDonorDonations_RowEditing(object sender, GridViewEditEventArgs e)
            {
            gvBloodDonorDonations.EditIndex = e.NewEditIndex;
            LoadDonations();
            }

        protected void gvBloodDonorDonations_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
            gvBloodDonorDonations.EditIndex = -1;
            LoadDonations();
            }

        protected void gvBloodDonorDonations_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
            try
                {
                int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.RowIndex].Value);
                GridViewRow row = gvBloodDonorDonations.Rows[e.RowIndex];

                DropDownList ddlEditDonorID = row.FindControl("ddlEditDonorID") as DropDownList;
                TextBox txtEditDonationDate = row.FindControl("txtEditDonationDate") as TextBox;
                TextBox txtEditNumberofBottle = row.FindControl("txtEditNumberofBottle") as TextBox;
                TextBox txtEditWeight = row.FindControl("txtEditWeight") as TextBox;
                TextBox txtEditHBCount = row.FindControl("txtEditHBCount") as TextBox;

                BloodBankManagement.Entities.BloodDonorDonation donation = new BloodBankManagement.Entities.BloodDonorDonation
                    {
                    BloodDonationID = donationID,
                    BloodDonorID = int.Parse(ddlEditDonorID.SelectedValue),
                    BloodDonationDate = DateTime.Parse(txtEditDonationDate.Text),
                    NumberofBottle = int.Parse(txtEditNumberofBottle.Text),
                    Weight = decimal.Parse(txtEditWeight.Text),
                    HBCount = decimal.Parse(txtEditHBCount.Text)
                    };
                bloodDonorDonationBLL.UpdateBloodDonorDonation(donation);
                gvBloodDonorDonations.EditIndex = -1;
                LoadDonations();
                }
            catch (System.Exception ex)
                {
                HandleError(ex);
                }
            }

        protected void gvBloodDonorDonations_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            int donationID = Convert.ToInt32(gvBloodDonorDonations.DataKeys[e.RowIndex].Value);
            bloodDonorDonationBLL.DeleteBloodDonorDonation(donationID);
            LoadDonations();
            }

        protected void gvBloodDonorDonations_RowDataBound(object sender, GridViewRowEventArgs e)
            {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                DropDownList ddlEditDonorID = (DropDownList)e.Row.FindControl("ddlEditDonorID");
                if (ddlEditDonorID != null)
                    {
                    List<BloodBankManagement.Entities.BloodDonor> donors = bloodDonorBLL.GetAllBloodDonors();
                    ddlEditDonorID.DataSource = donors;
                    ddlEditDonorID.DataTextField = "BloodDonorID";
                    ddlEditDonorID.DataValueField = "BloodDonorID";
                    ddlEditDonorID.DataBind();

                    BloodBankManagement.Entities.BloodDonorDonation donation = e.Row.DataItem as BloodBankManagement.Entities.BloodDonorDonation;
                    ddlEditDonorID.SelectedValue = donation.BloodDonorID.ToString();
                    }
                }
            }

        private void HandleError(System.Exception ex)
            {
            lblErrorMessage.Text = ex.Message;
            }
        }
    }