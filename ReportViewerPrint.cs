using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.Windows;


    public class ReportViewer
    {
        public ReportViewer() { }
        public void PrintPurchaseOrder(ReportClass rep, object o){
            /// checking kind of repport before printing
            if (rep is ReportName){
                printPurchaseOrder((ClassName)o);
            }            
        }

        ///method to print reoprt after adding parameters
        public void PrintRepot(ClassName cln){
            try{
                var r = new SalesOrderReport();
                ParameterFieldDefinitions pfds;
                ParameterValues pvs;
                ////
                Parameterprint(r, cln.AttributeName, "AttributeName",pfds,pvs);                
                r.ReadRecords();
                r.PrintToPrinter(2, true, 0, 0);
            }
            catch (Exception exp){
                MessageBox.Show("l'erreur est " + exp.Message + " " + exp.InnerException);
            }
        }

        //// method to add parameter manipuled on report
        public void Parameterprint(ReportClass f, Object o, string parameternameParameterFieldDefinitions pfds,ParameterValues pvs){
            try{
                
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
            catch (Exception exp){
                MessageBox.Show("l'erreur est " + exp.Message + " " + e1.InnerException);
            }
        }
    }
