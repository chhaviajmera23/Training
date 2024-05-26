using BloodBankManagement.BusinessLayer;
using BloodBankManagement.Entities;
using System;
using System.Web.UI.WebControls;

namespace BloodBankManagement
    {
    public partial class Hospital : System.Web.UI.Page
        {
        private readonly HospitalBLL hospitalBLL = new HospitalBLL();

        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                BindHospitalGrid();
                }
            }

        protected void BindHospitalGrid()
            {
            gvHospitals.DataSource = hospitalBLL.GetAllHospitals();
            gvHospitals.DataBind();
            }

        protected void gvHospitals_RowEditing(object sender, GridViewEditEventArgs e)
            {
            gvHospitals.EditIndex = e.NewEditIndex;
            BindHospitalGrid();
            }

        protected void gvHospitals_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
            try
                {
                GridViewRow row = gvHospitals.Rows[e.RowIndex];
                int hospitalID = Convert.ToInt32(gvHospitals.DataKeys[e.RowIndex].Values["HospitalID"]);

                string hospitalName = ((TextBox)row.FindControl("txtEditHospitalName")).Text;
                string address = ((TextBox)row.FindControl("txtEditAddress")).Text;
                string city = ((TextBox)row.FindControl("txtEditCity")).Text;
                string contactNumber = ((TextBox)row.FindControl("txtEditContactNumber")).Text;

                BloodBankManagement.Entities.Hospital hospital = new BloodBankManagement.Entities.Hospital
                    {
                    HospitalID = hospitalID,
                    HospitalName = hospitalName,
                    Address = address,
                    City = city,
                    ContactNumber = contactNumber
                    };

                hospitalBLL.UpdateHospital(hospital);
                gvHospitals.EditIndex = -1;
                BindHospitalGrid();
                }
            catch (System.Exception ex)
                {
                lblErrorMessage.Text = ex.Message;
                }
            }

        protected void gvHospitals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
            gvHospitals.EditIndex = -1;
            BindHospitalGrid();
            }

        protected void gvHospitals_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            int hospitalID = Convert.ToInt32(gvHospitals.DataKeys[e.RowIndex].Values["HospitalID"]);
            hospitalBLL.DeleteHospital(hospitalID);
            BindHospitalGrid();
            }

        protected void btnAddHospital_Click(object sender, EventArgs e)
            {
            mvHospital.ActiveViewIndex = 1;
            }

        protected void btnSaveHospital_Click(object sender, EventArgs e)
            {
            BloodBankManagement.Entities.Hospital hospital = new BloodBankManagement.Entities.Hospital
                {
                HospitalName = txtHospitalName.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                ContactNumber = txtContactNumber.Text
                };

            hospitalBLL.AddHospital(hospital);
            BindHospitalGrid();
            mvHospital.ActiveViewIndex = 0;
            txtHospitalName.Text=string.Empty;
            txtAddress.Text=string.Empty;
            txtCity.Text=string.Empty;
            txtContactNumber.Text=string.Empty;
            }

        protected void btnCancel_Click(object sender, EventArgs e)
            {
            mvHospital.ActiveViewIndex = 0;
            }
        }
    }
