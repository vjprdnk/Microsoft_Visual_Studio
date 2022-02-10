using Microsoft.Reporting.WinForms;
using System.Data;
using ReportsApplication1.AdventureWorks2019DataSetTableAdapters;

namespace ReportsApplication1
{
    partial class Form1
    {
        

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 


            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;




            //Get Data
            ReportParameter storeId = new ReportParameter();
            ReportParameter modifiedDate = new ReportParameter();
            storeId.Name = "StoreID";
            
                
            modifiedDate.Name = "ModifiedDate";



            this.reportViewer1.ProcessingMode = ProcessingMode.Local;

            this.reportViewer1.LocalReport.ReportPath =
                     "C:/Users/prpraramlikm/source/repos/ReportsApplication1/ReportsApplication1/report1.rdlc";

            // Create the sales customer report parameter  
            System.Data.DataSet DataSet1 = new DataSet("Sales Customer Detail");

            
            string sqlSalesCustomer = "select storeID, max(ModifiedDate) ModifiedDate from AdventureWorks2019.Sales.Customer group by StoreID";

            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection("Data Source=(local); Initial Catalog=AdventureWorks2019; Integrated Security=SSPI");

            System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlSalesCustomer, connection);

            System.Data.SqlClient.SqlDataAdapter salesCustomerAdapter = new System.Data.SqlClient.SqlDataAdapter(command);

            AdventureWorks2019DataSet.CustomerDataTable dataTable = new AdventureWorks2019DataSet.CustomerDataTable();

            DataSet1.EnforceConstraints = false;

            salesCustomerAdapter.Fill(DataSet1);

            ReportDataSource dsSalesCustomer = new ReportDataSource("DataSet1", DataSet1.Tables[0]);
            
            this.reportViewer1.LocalReport.DataSources.Add(dsSalesCustomer);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { storeId, modifiedDate });

            this.reportViewer1.RefreshReport();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

       private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
       
    
         
    }
}

