using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.Windows;
using MahApps.Metro.Controls;
using BuisenessAdvisorDesktop.Views.PrintingView;
using static BuisenessAdvisorDesktop.ViewModels.Purchase.PurchaseOrderViewModel;
using static BuisenessAdvisorDesktop.ViewModels.Sales.SalesOrderViewModel;
using static BuisenessAdvisorDesktop.ViewModels.Sales.ShipmentViewModel;
//using static BuisenessAdvisorDesktop.ViewModels.Config.BranchViewModel;
//using Branch = BuisenessAdvisorDesktop.ViewModels.Purchase.PurchaseOrderViewModel;

namespace BuisenessAdvisorDesktop.Util
{
    public class ReportViewer
    {
        public ReportViewer() { }
        public void PrintPurchaseOrder(ReportClass rep, object o) {
            //// selecting report 
            ///----1           
            if (rep is PurchaseOrderReport) {
                printPurchaseOrder((PurchaseOrder)o);
            }
            //// selecting report 
            ///----2     
            if (rep is SalesOrderReport) {
                printSalesOrder((SalesOrder)o);
            }
            
        }
        public void PrintPurchaseOrder(ReportClass rep, object o1, object o2, object o3)
        {
            //// selecting report 
            ///----3  
            if (rep is ShipmentReport){
  //           printShipment((Shipment)o1,(SalesOrder)o2,(Branch)o3);
        }
    }

        ///---PurchaseOrder
        ///
        public void printPurchaseOrder(PurchaseOrder por)
        {
            try
            {
                PurchaseOrderReport r = new PurchaseOrderReport();
                ParameterFieldDefinitions pfds;
                ParameterValues pvs;
                DateTime date = DateTime.Today;
                ////
                Parameterprint(r, por.purchaseOrderNumber, "purchaseOrderNumber");
                Parameterprint(r, por.purchaseOrderId, "purchaseOrderId");
                Parameterprint(r, por.deliveryAddress, "deliveryAddress");

                string dt1 = por.poDate.ToString("yyyy/MM/dd");
                Parameterprint(r, dt1, "poDate");

                string dt2 = por.deliveryDate.ToString("yyyy/MM/dd");
                Parameterprint(r, dt2, "deliveryDate");

                Parameterprint(r, por.Total, "Total");
                //Parameterprint(r, por.Amount, "Amount");
                Parameterprint(r, por.Discount, "Discount");
                Parameterprint(r, por.picInternal, "picInternal");
                Parameterprint(r, por.picVendor, "picVendor");
                Parameterprint(r, por.description, "description");
                Parameterprint(r, por.SubTotal, "SubTotal");

                r.ReadRecords();
                //r.SaveAs("F:\f", true);
                r.PrintToPrinter(2, true, 0, 0);//print_number
            }
            catch (Exception e1)
            {
                MessageBox.Show("l'erreur est " + e1.Message + " " + e1.InnerException);
            }
        }
        ///---SalesOrder
        ///
        public void printSalesOrder(SalesOrder por)
        {
            try
            {
                SalesOrderReport r = new SalesOrderReport();
                ParameterFieldDefinitions pfds;
                ParameterValues pvs;
                DateTime date = DateTime.Today;
                ////
                Parameterprint(r, por.salesOrderNumber, "salesOrderNumber");
                Parameterprint(r, por.salesOrderId, "salesOrderId");
                Parameterprint(r, por.deliveryAddress, "deliveryAddress");

                string dt1 = por.soDate.ToString("yyyy/MM/dd");
                Parameterprint(r, dt1, "soDate");

                string dt2 = por.deliveryDate.ToString("yyyy/MM/dd");
                Parameterprint(r, dt2, "deliveryDate");

                Parameterprint(r, por.Total, "Total");
                //Parameterprint(r, por.Amount, "Amount");
                Parameterprint(r, por.Discount, "Discount");
                Parameterprint(r, por.picInternal, "picInternal");
                Parameterprint(r, por.picCustomer, "picCustomer");
                Parameterprint(r, por.description, "description");
                Parameterprint(r, por.SubTotal, "SubTotal");

                r.ReadRecords();
                //r.SaveAs("F:\f", true);
                r.PrintToPrinter(2, true, 0, 0);//print_number
            }
            catch (Exception e1)
            {
                MessageBox.Show("l'erreur est " + e1.Message + " " + e1.InnerException);
            }
        }
        ///--Shipment
        ///
        /*public void printShipment(Shipment por,SalesOrder so,Branch br)
        {
            try
            {
                ShipmentReport r = new ShipmentReport();
                ParameterFieldDefinitions pfds;
                ParameterValues pvs;
                ////
                Parameterprint(r, por.shipmentNumber, "shipmentNumber");
                Parameterprint(r, por.salesOrderId, "salesOrderId");
                Parameterprint(r, br., "branchName");
                
                Parameterprint(r, por, "deliveryAddress");

                string dt1 = so.soDate.ToString("yyyy/MM/dd");
                Parameterprint(r, dt1, "soDate");

                string dt2 = so.deliveryDate.ToString("yyyy/MM/dd");
                Parameterprint(r, dt2, "deliveryDate");
                
                Parameterprint(r, so.picInternal, "picInternal");
                Parameterprint(r, por.Remarks, "Remarks");

                r.ReadRecords();
                //r.SaveAs("F:\f", true);
                r.PrintToPrinter(2, true, 0, 0);//print_number
            }
            catch (Exception e1)
            {
                MessageBox.Show("l'erreur est " + e1.Message + " " + e1.InnerException);
            }
        }

        */

        public void Parameterprint(ReportClass f, Object o, string parametername)
        {
            try
            {
                ParameterFieldDefinitions pfds;
                ParameterValues pvs;
                if (o != null)
                {
                    ParameterFieldDefinition pfd;
                    pvs = new ParameterValues();
                    ParameterDiscreteValue pdv = new ParameterDiscreteValue();
                    pdv.Value = o;
                    pfds = f.DataDefinition.ParameterFields;
                    pfd = pfds[parametername];
                    pvs = pfd.CurrentValues;
                    pvs.Clear();
                    pvs.Add(pdv);
                    pfd.ApplyCurrentValues(pvs);
                }
            }
            catch (Exception e1){
                MessageBox.Show("l'erreur est " + e1.Message + " " + e1.InnerException);
            }
        }
    }
}
