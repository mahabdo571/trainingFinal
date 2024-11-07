using Door3;
using Door3.Wing;
using Doors4.Projects;
using Doors4.Report;
using Doors4.ReportWing;
using Newtonsoft.Json.Linq;
using SharaLogic;
using SharaLogic.Calculations;
using SharaLogic.WingCalc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Doors4
{
    /// <summary>
    /// Interaction logic for wpfOrderPage.xaml
    /// </summary>
    public partial class wpfOrderPage : Window
    {
        int IDorder;
        clsOrders _order;
        DataTable Temptb, datatableDoor,TempTbFrame,DataTableFrame;
    
        public wpfOrderPage(int idOrder)
        {
            InitializeComponent();
            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);
            this.IDorder = idOrder;
            _order = clsOrders.Find(IDorder);
            if (_order != null)
            {
                this.Title = FindResource("langOrderNo") + " " + _order.OrderNumber + " " + FindResource("langfromthe") + " " + clsProjects.Find(_order.ProjectID).projectName + " " + FindResource("projects");
          DateOrderManual.Text = _order.DateManual.ToString();
            }
                lbltitle.Content = this.Title;
            if(Doors4.Properties.Settings.Default.lang == "HE" || Doors4.Properties.Settings.Default.lang == "AR")
            {
                lbltitle.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                lbltitle.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void btnAddFrame_Click(object sender, RoutedEventArgs e)
        {

            new TapiFrame(this.IDorder, -1).ShowDialog();
   
  

        }
        string getColorName(string id)
        {
            if (int.TryParse(id, out int res))
            {
                clsFormicaColor color = clsFormicaColor.Find(res);
                if (color != null)
                {
                    return color.ColorName;
                }
            }
            return "";

        }   
        
        string getColorNameA(string id)
        {
            if (int.TryParse(id, out int res))
            {
                clsColorSide color = clsColorSide.Find(res);
                if (color != null)
                {
                    return color.ColorName;
                }
            }
            return "";

        }
        void _loadData(DataTable dtFrame,DataTable dtDoor)
        {

       



            if (dtFrame == null )
            {
                dgvFrame.ItemsSource = null;
         
            }
            else
            {
                TempTbFrame = dtFrame.DefaultView.ToTable(false, "ID", "DoorNumber", "FrameType", "Width", "Height", "FrameThickness", "WallThickness", "Date");
             
                DataTableFrame = TempTbFrame.Clone();


                foreach (DataRow row in TempTbFrame.Rows)
                {
                   
                    row.BeginEdit();
                    if (!string.IsNullOrEmpty(row["FrameType"].ToString()))
                    {
                        row["FrameType"] = FrameNameCalc.FrameNameSys(row["FrameType"].ToString()); 
                    }
                    else
                    {
                        row["FrameType"] = "No Chois";
                    }



                    row.EndEdit();


                    DataTableFrame.ImportRow(row);
                }



                dgvFrame.ItemsSource = DataTableFrame.DefaultView;


                dgvFrame.Columns[0].Visibility = Visibility.Hidden;
           
                dgvFrame.Columns[1].Header = FindResource("listFrameNumber");
                dgvFrame.Columns[1].Width = 80;
                dgvFrame.Columns[2].Header = FindResource("listFrameType");
                dgvFrame.Columns[2].Width = 250;
                dgvFrame.Columns[3].Header = FindResource("listframeWidth");
                dgvFrame.Columns[3].Width = 100;
                dgvFrame.Columns[4].Header = FindResource("listframeHeight");
                dgvFrame.Columns[4].Width = 80;
                dgvFrame.Columns[5].Header = FindResource("listFrameThickness");
                dgvFrame.Columns[5].Width = 50;
                dgvFrame.Columns[6].Header = FindResource("listWallThickness");
                dgvFrame.Columns[6].Width = 50;
                 dgvFrame.Columns[7].Header = FindResource("langUpdateDatedoor");
                dgvFrame.Columns[7].Width = 130;



            }


            if (dtDoor == null)
            {
    
                dgvDoor.ItemsSource = null;
            }
            else
            {

              //  Temptb = dtDoor.DefaultView.ToTable(false, "ID", "DoorNumber", "DoorType", "ColorDoor","HeightFinal", "WidthFinal", "UpdateDate");
                 Temptb = dtDoor.Select("DDAK <> 'K'").CopyToDataTable().DefaultView.ToTable(false, "ID", "DoorNumber", "DoorType", "ColorDoor", "HeightFinal", "WidthFinal", "UpdateDate");


                datatableDoor = Temptb.Clone();


                foreach (DataRow row in Temptb.Rows)
                {
                    clsWingType typewing = clsWingType.FindByWingID((int)row["ID"]);

                    row.BeginEdit();
                    if (typewing != null)
                    {
                        row["DoorType"] = clsCalcNameType.getName(typewing.TEST1, typewing.TEST2, typewing.TEST3, typewing.TEST4);
                    }
                    else
                    {
                        row["DoorType"] = "No Chois";
                    }
                    if (typewing != null && typewing.TEST2 == "A")
                    {
                        row["ColorDoor"] = getColorNameA(row["ColorDoor"] as string);
                    }
                    else
                    {
                        row["ColorDoor"] = getColorName(row["ColorDoor"] as string);
                    }
                  row.EndEdit();


                    datatableDoor.ImportRow(row);
                }

                datatableDoor.DefaultView.Sort = "UpdateDate DESC";

                datatableDoor = datatableDoor.DefaultView.ToTable();

                dgvDoor.ItemsSource = datatableDoor.DefaultView;


                if (dgvDoor.Items.Count > 0)
                {

                    dgvDoor.Columns[0].Visibility = Visibility.Hidden;

                    dgvDoor.Columns[1].Header = FindResource("langwingNumber");
                    dgvDoor.Columns[1].Width = 80;
                    dgvDoor.Columns[2].Header = FindResource("langTypeWinglist");
                    dgvDoor.Columns[2].Width = 250;
                    dgvDoor.Columns[3].Header = FindResource("langwingColorDoor");
                    dgvDoor.Columns[3].Width = 100;
                    dgvDoor.Columns[4].Header = FindResource("langHeightFinaldoor");
                    dgvDoor.Columns[4].Width = 80;
                    dgvDoor.Columns[5].Header = FindResource("langWidthFinaldoor");
                    dgvDoor.Columns[5].Width = 80;
                    dgvDoor.Columns[6].Header = FindResource("langUpdateDatedoor");
                    dgvDoor.Columns[6].Width = 130;




                }
            }

        }

        

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            new wpfOrders(_order.ProjectID).Show();
            this.Close();
        }

        private void wpfOrderPageScreen_Loaded(object sender, RoutedEventArgs e)
        {
            cbPrintType.Items.Add("All");
            cbPrintType.Items.Add("Print Stikrs Formaica");
            cbPrintType.Items.Add("Print Peper Formaica");
            cbPrintType.Items.Add("Print Color Side");
            cbPrintType.Items.Add("Print Tris Size");
            cbPrintType.Items.Add("Print Windos Size");
            cbPrintType.Items.Add("Sticker Packing Wing");

            cbPrintTypeFrame.Items.Add("Sticker Prisa");
            cbPrintTypeFrame.Items.Add("Sticker Packing");
            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));
        }

        private void MenuItem_Click_OpenFrame(object sender, RoutedEventArgs e)
        {
            new TapiFrame(IDorder, (int)((DataRowView)dgvFrame.SelectedItem).Row.ItemArray[0]).ShowDialog();
    
        }

        private void MenuItem_Click_EditFrame(object sender, RoutedEventArgs e)
        {
            new TapiFrame(IDorder, (int)((DataRowView)dgvFrame.SelectedItem).Row.ItemArray[0]).ShowDialog();

         
        }

        private void MenuItem_Click_DeleteFrame(object sender, RoutedEventArgs e)
        {

        }


      private void MenuItem_Click_FrameRefres(object sender, RoutedEventArgs e)
            {
            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));
        }

        private void DataGridCell_MouseDoubleClick_Frame(object sender, MouseButtonEventArgs e)
        {
            new TapiFrame(IDorder, (int)((DataRowView)dgvFrame.SelectedItem).Row.ItemArray[0]).ShowDialog();
            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));


        }

        private void DataGridCell_MouseDoubleClick_Door(object sender, MouseButtonEventArgs e)
        {
            new TapiWing(IDorder, (int)((DataRowView)dgvDoor.SelectedItem).Row.ItemArray[0]).ShowDialog();
            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));

        }

        private void MenuItem_Click_DoorRefres(object sender, RoutedEventArgs e)
        {
            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));
        }

        private void MenuItem_Click_DeleteDoor(object sender, RoutedEventArgs e)
        {

            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));

        }


        private void MenuItem_Click_EditDoor(object sender, RoutedEventArgs e)
        {
            new TapiWing(IDorder, (int)((DataRowView)dgvDoor.SelectedItem).Row.ItemArray[0]).ShowDialog();
            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));

        }


        private void MenuItem_Click_OpenDoor(object sender, RoutedEventArgs e)
        {
            new TapiWing(IDorder, (int)((DataRowView)dgvDoor.SelectedItem).Row.ItemArray[0]).ShowDialog();
            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));


        }

        private void txtSearchFrame_TextChanged(object sender, TextChangedEventArgs e)
        {

            try { 
            DataTableFrame.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{2}%' or Convert([{1}], System.String) LIKE '%{2}%'",  "FrameType", "DoorNumber" ,txtSearchFrame.Text);
        }catch(Exception ex)
            {
                clsSettings.SetEventLogMsg(ex.Message, "CLS_OrderPage_FUN_txtSearchFrame", System.Diagnostics.EventLogEntryType.Warning);
            }


            if (string.IsNullOrEmpty(txtSearchFrame.Text))
            {
                DataTableFrame.DefaultView.RowFilter = null;
            }



        }

        private void btncustomer_Click(object sender, RoutedEventArgs e)
        {
            new MainCustomers().Show();
            this.Close();
        }

        private void btnProject_Click(object sender, RoutedEventArgs e)
        {
            new MainProjects(clsProjects.Find( _order.ProjectID).iDcustomer).Show();
            this.Close();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddNewDoor_Click(object sender, RoutedEventArgs e)
        {
            new TapiWing(IDorder,-1).ShowDialog();

            _loadData(clsFrames.getFrameFromOrderID(IDorder), clsWings.getbyOrderID(IDorder));



        }

        private void DateOrderManual_LostFocus(object sender, RoutedEventArgs e)
        {
            if(_order != null)
            {
                _order.DateManual = DateOrderManual.SelectedDate.Value.Date;
                _order.Save();
            }
         
        }

        private void btnScan_Click(object sender, RoutedEventArgs e)
        {
            ScannedOrders scan = new ScannedOrders(IDorder,ScannedOrders.Mode.Order);
            scan.ShowDialog();
        }

        private void btnPrintStikrsFrameDitels_Click(object sender, RoutedEventArgs e)
        {

            if (clsFrames.getFrameFromOrderID(IDorder) != null)
            {
                switch (cbPrintTypeFrame.SelectedIndex)
                {
                    case 0:
                        clsPrisaSizesGetValueFromData printPrisaSizes = new clsPrisaSizesGetValueFromData(IDorder);

                        printPrisaSizes.Print();
                        break;
                    case 1:
                        clsPackingFrameStikrs print = new clsPackingFrameStikrs(IDorder);
                        print.Print();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Order Not Found");
            }

             

        }

        private async void btnPrintExlFileData_Click(object sender, RoutedEventArgs e)
        {
          
        progressBar.Visibility = Visibility.Visible;
            try
            {
                await Task.Delay(500);
               await Task.Run(() =>  clsFrames.BLL_ExportDoorFrameDetailsToExcelFile(IDorder));
                await Task.Delay(100);
                MessageBox.Show("The file was created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                progressBar.Visibility = Visibility.Hidden; 
            }
        }

        private void dgvFrame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnPrintStikrsDoorDitels_Click(object sender, RoutedEventArgs e)
        {
            if (clsWings.getbyOrderID(IDorder) != null)
            {
                clsListOrderWing listWing = new clsListOrderWing(clsWings.getbyOrderID(IDorder), IDorder);

                switch (cbPrintType.SelectedIndex)
                {
                    case 0:
                        listWing.Print();
                        break;
                    case 1:
                        listWing.PrintStikrsFormaica();
                        break;
                    case 2:
                        listWing.PrintPeperFormaica();
                        break;   
                    
                    case 3:
                        listWing.PrintColorSide();
                        break;  
                    case 4:
                        listWing.PrintTrisList();
                        break; 
                    case 5:
                        listWing.PrintWindoList();
                        break;  
                    
                    case 6:
                        listWing.StickerPackingWing();
                        break;  
                

                }

            }
            else
            {
                MessageBox.Show("Order Not Found");
            }

        }

        private void txtSearchDoor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchDoor.Text))
            {
                datatableDoor.DefaultView.RowFilter = null;
            }

            try
            {
                datatableDoor.DefaultView.RowFilter = string.Format("[{0}] = '{3}' or [{1}] like '%{3}%' or [{2}] like '%{3}%' ", "DoorNumber", "DoorType", "ColorDoor", txtSearchDoor.Text);
            }catch(Exception ex)
            {
                clsSettings.SetEventLogMsg(ex.Message, "CLS_OrderPage_FUN_txtsearchDoor", System.Diagnostics.EventLogEntryType.Warning);
            }
       
      
        }



    }
}

