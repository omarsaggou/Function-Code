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
        
        ///method to print reoprt after adding parameters
        /// Print with one object
        public void PrintReport(Object obj){
            try{
                if (obj is ClassName)
                {
                    var o = (ClassName)obj;
                    var r = new ClassNameReport();
                    ParameterFieldDefinitions pfds = null;
                    ParameterValues pvs = null;
                    ////
                    Parameterprint(r, o.ClassNameNumber, "ClassNameNumber", pfds, pvs);
                    Parameterprint(r, o.ClassNameId, "ClassNameId", pfds, pvs);
                    string dt1 = o.poDate.ToString("yyyy/MM/dd");
                    Parameterprint(r, dt1, "poDate", pfds, pvs);
                    r.ReadRecords();
                    r.PrintToPrinter(2, true, 0, 0);
                }
            catch(Exception exp){
                MessageBox.Show("l'erreur est " + exp.Message + " " + exp.InnerException);
                }
            }
        }



        public void PrintReport(Object obj1,Object obj2,Object obj3,Object obj4){
            try{
                if ( (obj1 is CLass1) && ( obj2is is Class2)&&(obj3 is Class3)&&(obj4 is Class4)){
                    var obj_1 = (CLass1)obj1;
                    var obj_2=(Class2)obj2;
                    var obj_3=(Class3)obj3;
                    var obj_4=(Class4)obj4;
                    var r = new PurchaseOrderReport();
                    ParameterFieldDefinitions pfds = null;
                    ParameterValues pvs = null;
                    //// CLass1
                    Parameterprint(r, obj_1.Attribute, "Attribute", pfds, pvs);
                    string dt1 = obj_1.date.ToString("yyyy/MM/dd");
                    Parameterprint(r, dt1, "date", pfds, pvs);
                    ///Class3
                    Parameterprint(r,obj_3.billingContactPerson,"billingContactPerson",pfds,pvs);
                    ///Class2
                    Parameterprint(r,obj_2.Class2Name,"Class2Name",pds,pvs);
                    ///Class4
                    Parameterprint(r,obj_4.CurrencyName,"CurrencyName"pfds,vs);
                    r.PrintToPrinter(2, true, 0, 0);
                }
            catch(Exception exp){
                MessageBox.Show("l'erreur est " + exp.Message + " " + exp.InnerException);
                }
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
