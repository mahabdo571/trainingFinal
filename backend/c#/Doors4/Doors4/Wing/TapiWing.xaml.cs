using Doors4;
using Doors4.Report;
using Doors4.ReportWing;
using Doors4.Wing;
using SharaLogic;
using SharaLogic.WingCalc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace Door3.Wing
{
    /// <summary>
    /// Interaction logic for TapiWing.xaml
    /// </summary>
    public partial class TapiWing : Window
    {
        enum MyMode { AddNew = 1, Update = 2 }
        MyMode _mode = MyMode.AddNew;

        clsWings _Wing;
        clsOrders _order;
        clsProjects _project;
        clsCustomers _customer;
        clsWingType _wingType;
        clsWingHinge _wingHinge;
        clsWingLock _wingLock;
        clsWingWindows _windo;
        clsWingAddon _Addon;
        clsWingAdvanced _advanced;
        clsWings TempWing;
        clsSetParameterToReportWing _setParamToReport;
        clsWings DDwing;
        int _WingID;
        int _OrderID;

        clsWings _wingTemp;

        int _doorRepeted;

        bool MakhzerShemenManoul = false;
        public TapiWing(int orderID, int WingID)
        {
            InitializeComponent();

            wpfSetting.SetLang(Doors4.Properties.Settings.Default.lang);

            _WingID = WingID;
            _OrderID = orderID;
            if (clsSettings.CheckConnection())
            {


                if (clsOrders.IsExist(orderID))
                {

                    _order = clsOrders.Find(_OrderID);
                    if (_order == null)
                    {
                        MessageBox.Show("Error");
                        return;
                    }
                    _project = clsProjects.Find(_order.ProjectID);
                    _customer = clsCustomers.Find(_project.iDcustomer);
                }
                else
                {

                    MessageBox.Show(FindResource("lang_MissingData").ToString());
                    return;
                }
            }
            else
            {

            }
            if (_WingID == -1)
            {
                _mode = MyMode.AddNew;
                _Save();

            }
            else
            {
                _mode = MyMode.Update;
                _Save();

            }

        }




        private void btnWingType_Click(object sender, RoutedEventArgs e)
        {
            WingTypeWindow wind1;

            if (_wingType == null)
            {
                wind1 = new WingTypeWindow(_WingID, -1);
            }
            else
            {
                wind1 = new WingTypeWindow(_WingID, _wingType.ID);
            }

            wind1.ShowDialog();
            MakhzerShemenManoul = false;
            UPDATEUI(); // for update wing type after change

            saveDoorTypeInWing();

            _Update();
            _inputFill();
            UPDATEUI();
            saveDoorTypeInWing();
            defultLOck();
            if (_advanced != null)
            {


                if (_wingType.TEST2 != "A")
                {
                    _Wing.FormaicaThickness = 4f;
                

                    if (_Wing.Save())
                    {
                        _Update();
                        _inputFill();
                        UPDATEUI();
                     
                        _advanced.CalcKant();
                    }
                }
                else
                {

                    _advanced.CalcKant();


                }
            }

            ucViewWinge.UPDATEUIReport(_WingID);
            fillColorDoor();

           


        }

        void saveDoorTypeInWing()
        {
            UPDATEUI();
            if (_Wing != null && _wingType != null)
            {
                _Wing.DoorType = _wingType.TEST1 + _wingType.TEST2 + _wingType.TEST3 + _wingType.TEST4;
                if (_Wing.Save())
                {
                    _Update();
                    _inputFill();
                    UPDATEUI();

                }
            }
        }
        private void btnWingHinge_Click(object sender, RoutedEventArgs e)
        {
            UPDATEUI();
            WingHingeWindow wind1;

            if (_wingHinge == null)
            {
                wind1 = new WingHingeWindow(-1, _WingID);
            }
            else
            {
                wind1 = new WingHingeWindow(_wingHinge.ID, _WingID);
            }

            wind1.ShowDialog();
            _Update();
            _inputFill();
            UPDATEUI();
            ucViewWinge.UPDATEUIReport(_WingID);
        }

        private void btnWingLock_Click(object sender, RoutedEventArgs e)
        {
            WingLockWindow wind1;
            if (_wingLock == null)
            {
                wind1 = new WingLockWindow(_WingID, -1);
            }
            else
            {
                wind1 = new WingLockWindow(_WingID, _wingLock.ID);

            }

            wind1.ShowDialog();
            _Update();
            _inputFill();
            UPDATEUI();
            ucViewWinge.UPDATEUIReport(_WingID);
        }

        private void btnWingAddons_Click(object sender, RoutedEventArgs e)
        {
            WingAddonWindow wind1;

            if (_Addon != null)
            {
                wind1 = new WingAddonWindow(_WingID, _Addon.ID);
            }
            else
            {
                wind1 = new WingAddonWindow(_WingID, -1);
            }
            wind1.ShowDialog();
            _Update();
            _inputFill();
            UPDATEUI();
            ucViewWinge.UPDATEUIReport(_WingID);
        }

        private void btnWingSubtit_Click(object sender, RoutedEventArgs e)
        {
            WingSubtitWindow wind1;
            if (_windo != null)
            {
                wind1 = new WingSubtitWindow(_WingID, _windo.ID);
            }
            else
            {
                wind1 = new WingSubtitWindow(_WingID, -1);
            }
            wind1.ShowDialog();
            _Update();
            _inputFill();
            UPDATEUI();
            ucViewWinge.UPDATEUIReport(_WingID);
        }

        private void btnWingAdvanced_Click(object sender, RoutedEventArgs e)
        {
            WingAdvancedWindow wind1;
            if (_advanced != null)
            {
                wind1 = new WingAdvancedWindow(_WingID, _advanced.ID);
            }
            else
            {
                wind1 = new WingAdvancedWindow(_WingID, -1);
            }

            wind1.ShowDialog();

            _Update();
            _inputFill();
            UPDATEUI();
            ucViewWinge.UPDATEUIReport(_WingID);
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (_Wing.Save())
            {
                _Update();
                _inputFill();
                UPDATEUI();

                ucViewWinge.UPDATEUIReport(_WingID);

                // new wpfView(_setParamToReport).ShowDialog();

            }


            // double resul = clsInjectionPoly.OutResultPoly();


            //  MessageBox.Show(resul.ToString());

        }

        bool defultADvanced()
        {
            _advanced = new clsWingAdvanced();
            _advanced.WingID = _Wing.ID;
            _advanced.ThicknessWing = 45;
            _advanced.Cylinder = true;
            _advanced.HolesCylinder = true;
            _advanced.PushSideLever = true;
            _advanced.PullSideLever = true;
            _advanced.HandleHoles = true;


            return _advanced.Save();
        }

        bool defultAddon()
        {
            _Addon = new clsWingAddon();
            _Addon.WingID = _Wing.ID;
            _Addon.PullHandleWidth = 900;
            _Addon.Offirt = "NoOffirt";
            _Addon.StainlessBand = "NoBand";

            return _Addon.Save();
        }    
        
        bool defultHinge()
        {
            _wingHinge = new clsWingHinge();
            _wingHinge.WingID = _Wing.ID;
            _wingHinge.HeightToBottomHinge = _Wing.HeightFinal;
            _wingHinge.HingeType = "4X4";
            _wingHinge.H1 =165;
            _wingHinge.H2 =952;
            _wingHinge.H3 =1740;
            _wingHinge.Amount =3;

            return _wingHinge.Save();
        }

        bool defultLOck()
        {

            if (clsWingLock.FindByWingID(_Wing.ID) == null)
            {
                _wingLock = new clsWingLock();
                _wingLock.WingID = _Wing.ID;
            }
            else
            {
                _wingLock = clsWingLock.FindByWingID(_Wing.ID);
            }


            _wingLock.LockMeasure = 1012;
            if (_wingType.TEST1 == "ALPH")
            {
                _wingLock.LockType = "Finek";
            }
            else if (_wingType.TEST1 == "ZAZA")
            {
                _wingLock.LockType = "zaza";
            }
            else
            {
                _wingLock.LockType = "shar60";
            }

            return _wingLock.Save();
        }


        void _AddNew()
        {

            _Wing = new clsWings();

            _Wing.OdrerId = _OrderID;
            _Wing.DateAdded = DateTime.Now;

            _Wing.FormaicaThickness = 4f;
            _Wing.tbAmount = 1;


            if (_Wing.Save())
            {
                _WingID = _Wing.ID;
              //  KantChangeIFChangeThickFormaick(_Wing.ID, 37);


                if (defultADvanced() && defultAddon())
                {
                    defultHinge();
                    _mode = MyMode.Update;

                    UPDATEUI();
                }


            }


        }
        void _Update()
        {
            if (clsWings.IsExist(_WingID))
            {
                _Wing = clsWings.Find(_WingID);
                _wingType = clsWingType.FindByWingID(_WingID);
                _wingHinge = clsWingHinge.FindByWingID(_WingID);
                _wingLock = clsWingLock.FindByWingID(_WingID);
                _windo = clsWingWindows.FindByWingID(_WingID);
                _Addon = clsWingAddon.FindByWingID(_WingID);
                _advanced = clsWingAdvanced.FindByWingID(_WingID);
                DDwing = clsWings.Find(_Wing.DDWingID);
                _Wing.UpdateDate = DateTime.Now;
            }
            else
            {
                MessageBox.Show(FindResource("lang_MissingData").ToString());
                return;
            }


        }

        string _getFromDBconverToEmpty(int num)
        {
            if (_Wing != null)
            {

                if (num <= 0)
                {
                    return "";
                }
                else
                {
                    return num.ToString();
                }

            }
            return "";
        }

        void _CheckingTheDirectionStatus()
        {
            if (_Wing != null)
            {
                if (_Wing.Direction == "Left")
                {
                    btnDirectionL.IsEnabled = false;
                    btnDirectionL.FontWeight = FontWeights.Bold;

                    btnDirectionR.IsEnabled = true;
                    btnDirectionR.FontWeight = FontWeights.Normal;

                }
                else if (_Wing.Direction == "Right")
                {
                    btnDirectionL.IsEnabled = true;
                    btnDirectionL.FontWeight = FontWeights.Normal;

                    btnDirectionR.IsEnabled = false;
                    btnDirectionR.FontWeight = FontWeights.Bold;
                }
                else
                {
                    btnDirectionL.IsEnabled = true;
                    btnDirectionL.FontWeight = FontWeights.Normal;

                    btnDirectionR.IsEnabled = true;
                    btnDirectionR.FontWeight = FontWeights.Normal;
                }
            }

        }

        void _CheckingTheFormaicaThicknessStatus()
        {
            if (_Wing != null)
            {
                if (_Wing.FormaicaThickness == 4f)
                {
                    btnFormicaThiknss4.IsEnabled = false;
                    btnFormicaThiknss4.FontWeight = FontWeights.Bold;

                    btnFormicaThiknss2_5.IsEnabled = true;
                    btnFormicaThiknss2_5.FontWeight = FontWeights.Normal;
                }
                else if (_Wing.FormaicaThickness == 2.5f)
                {
                    btnFormicaThiknss4.IsEnabled = true;
                    btnFormicaThiknss4.FontWeight = FontWeights.Normal;

                    btnFormicaThiknss2_5.IsEnabled = false;
                    btnFormicaThiknss2_5.FontWeight = FontWeights.Bold;

                }
                else
                {
                    btnFormicaThiknss4.IsEnabled = true;
                    btnFormicaThiknss4.FontWeight = FontWeights.Normal;

                    btnFormicaThiknss2_5.IsEnabled = true;
                    btnFormicaThiknss2_5.FontWeight = FontWeights.Normal;
                }
            }
        }

        void _checkingTheBoxStatus(bool name, CheckBox sender)
        {
            if (name)
            {
                sender.IsChecked = true;
                sender.FontWeight = FontWeights.Bold;
                if (_Wing.DoubleDoor && _Wing.DDAK=="A")
                {
                    txtWidthCut.IsEnabled = true;
                    txtHightCut.IsEnabled = true;
                    txtWidthFinal.IsEnabled = true;
                    txtHightFinal.IsEnabled = true;
                   
                }
                else if (_Wing.DoubleDoor && _Wing.DDAK == "K")
                {
                    txtWidthCut.IsEnabled = false;
                    txtHightCut.IsEnabled = false;
                    txtWidthFinal.IsEnabled = true;
                    txtHightFinal.IsEnabled = false;
                }

            }
            else
            {
                sender.IsChecked = false;
                sender.FontWeight = FontWeights.Normal;
                
            }
        }
        void _inputFill()
        {

            if (_Wing != null)
            {
               // txtColorWing.Text = _Wing.ColorDoor;
                //txtColorSide.Text = _Wing.ColorSide;
                if (int.TryParse(_Wing.ColorSide, out int res))
                {
                    if (res > 0)
                    {
                        cbColorSidelist.SelectedIndex = (res - 1);
                    }
                }  
              
                if (int.TryParse(_Wing.ColorDoor, out int resFC))
                {
                    if (resFC > 0)
                    {
                        cbColorWing.SelectedIndex = (resFC - 1);
                    }
                }

                lblCustomerName.Content = _customer.CompanyName;
                lblProjectName.Content = _project.projectName;
                txtOrderId.Text = _order.OrderNumber.ToString();
                txtAccID.Text = _Wing.AccID;
                txtLocation.Text = _Wing.Location;
                txtNotes.Text = _Wing.Notes;
                txtFactoryNotes.Text = _Wing.FactoryNotes;
                txtWidthCut.Text = _getFromDBconverToEmpty(_Wing.WidthCut);
                txtHightCut.Text = _getFromDBconverToEmpty(_Wing.HeightCut);
                txtWidthFinal.Text = _getFromDBconverToEmpty(_Wing.WidthFinal);
                txtHightFinal.Text = _getFromDBconverToEmpty(_Wing.HeightFinal);
                txtNumberWing.Text = _Wing.DoorNumber;
                tbPrintAmount.Text = _getFromDBconverToEmpty(_Wing.tbPrintAmount);
                tbStickers.Text = _getFromDBconverToEmpty(_Wing.tbStickers);
                tbAmount.Text = _getFromDBconverToEmpty(_Wing.tbAmount);
                _CheckingTheDirectionStatus();
                _CheckingTheFormaicaThicknessStatus();
                _checkingTheBoxStatus(_Wing.DoubleDoor, cbDoubleDoor);
                _checkingTheBoxStatus(_Wing.Atmer, cbAtmer);
                _checkingTheBoxStatus(_Wing.SupportHelpless, cbSupportHelpless);
                _checkingTheBoxStatus(_Wing.Side, cbSide);
                _checkingTheBoxStatus(_Wing.MakhzerShemen, cbMakhzerShemen);


                if (string.IsNullOrEmpty(txtNumberWing.Text))
                {
                    txtNumberWing.Background = Brushes.Red;
                    txtNumberWing.Foreground = Brushes.White;


                    allscren.IsEnabled = false;
                    txtNumberWing.IsEnabled = true;



                }
                else
                {
                    txtNumberWing.Background = (Brush)(new BrushConverter().ConvertFrom("#7F80DFFF"));

                    txtNumberWing.Foreground = Brushes.Black;

                    allscren.IsEnabled = true;

                }

                int.TryParse(_Wing.ColorSide, out int resuColorSide);

                if (clsColorSide.Find(resuColorSide) != null)
                {

                    cbColorSidelist.SelectedValue = resuColorSide;


                }

                //koko1
                if (_wingType != null && _wingType.TEST2 == "A")
                {
                    int.TryParse(_Wing.ColorDoor, out int resuColorFormicaA);

                    if (clsColorSide.Find(resuColorFormicaA) != null)
                    {

                        cbColorWing.SelectedValue = resuColorFormicaA;


                    }

                }
                else if (_wingType != null && _wingType.TEST2 == "F")
                {
                    int.TryParse(_Wing.ColorDoor, out int resuColorFormica);

                    if (clsFormicaColor.Find(resuColorFormica) != null)
                    {

                        cbColorWing.SelectedValue = resuColorFormica;


                    }
                }
                else
                {
                    cbColorWing.SelectedValue = -1;
                }


                    if (_wingType != null && _wingType.TEST1 == "ALPH")
                {
                    btnWingHinge.IsEnabled = false;
                    cbColorSidelist.IsEnabled = true;

                }
                else
                {
                    btnWingHinge.IsEnabled = true;

                    cbColorSidelist.IsEnabled = false;

                 

                }


                if (_Wing.DDAK == "K")
                {
                    btnWingType.IsEnabled = false;
                    btnWingAdvanced.IsEnabled = false;
                    btnWingLock.IsEnabled = false;
                    btnWingHinge.IsEnabled = false;
                    cbColorWing.IsEnabled = false;
                    cbColorSidelist.IsEnabled = false;
                    cbSide.IsEnabled = false;
                    cbAtmer.IsEnabled = false;
                    cbMakhzerShemen.IsEnabled = false;
                    tbAmount.IsEnabled = false;
                    txtAccID.IsEnabled = false;
                    txtLocation.IsEnabled = false;
                    txtNotes.IsEnabled = false;
                    txtFactoryNotes.IsEnabled = false;
                    btnFormicaThiknss2_5.IsEnabled = false;
                    btnFormicaThiknss4.IsEnabled = false;
                }
                else
                {
                    btnWingType.IsEnabled = true;
                    btnWingAdvanced.IsEnabled = true;
                    btnWingLock.IsEnabled = true;
                    btnWingHinge.IsEnabled = true;
                    cbColorWing.IsEnabled = true;
                    cbColorSidelist.IsEnabled = true;
                    cbSide.IsEnabled = true;
                    cbAtmer.IsEnabled = true;
                    cbMakhzerShemen.IsEnabled = true;
                    tbAmount.IsEnabled = true;
                    txtAccID.IsEnabled = true;
                    txtLocation.IsEnabled = true;
                    txtNotes.IsEnabled = true;
                    txtFactoryNotes.IsEnabled = true;
                    btnFormicaThiknss2_5.IsEnabled = true;
                    btnFormicaThiknss4.IsEnabled = true;
                }

                if (_wingType != null && (_wingType.TEST1 =="PVT" || _wingType.TEST1 =="ZAZA"))
                {
                    cbDoubleDoor.IsEnabled = false;
                }
                else
                {
                    cbDoubleDoor.IsEnabled = true;
                }
            }
        }

        void setDefultdata()
        {
            if (_wingType != null && _Wing != null)
            {
                if (MakhzerShemenManoul)
                {
                    return;
                }
                else
                {

                    if (_wingType.TEST1 != "ALPH")
                    {
                        cbMakhzerShemen.IsChecked = true;
                    }
                    else
                    {
                        cbMakhzerShemen.IsChecked = false;
                    }


                }

                if (_wingType.TEST2 == "A")
                {
                    _Wing.FormaicaThickness = 0.8f;
                    btnFormicaThiknss2_5.IsEnabled = false;
                    btnFormicaThiknss4.IsEnabled = false;
                }

            }
        }

        void UPDATEUI()
        {
         
            _CheckingTheDirectionStatus();
            _CheckingTheFormaicaThicknessStatus();

            setDefultdata();
            ucViewWinge.LoadUC(_WingID); //out to view
            if (_Wing != null)
            {
                if (_Wing.tbPrintAmount <= 0)
                {
                    lblAmountPrinPaeper.Content = clsSettings.CalcAmountPrintPeperWing(_WingID, (byte)_Wing.tbPrintAmount).ToString();
                }
                else
                {
                    lblAmountPrinPaeper.Content = clsSettings.CalcAmountPrintPeperWing(_WingID, (byte)_Wing.tbPrintAmount).ToString();
                }

                if (_Wing.tbStickers <= 0)
                {
                    lblAmountPrinstikrs.Content = (clsSettings.CalcAmountPrintStikrsWing(_WingID, (byte)_Wing.tbStickers) * _Wing.tbAmount).ToString();
                }
                else
                {
                    lblAmountPrinstikrs.Content = (clsSettings.CalcAmountPrintStikrsWing(_WingID, (byte)_Wing.tbStickers)).ToString();
                }
                if (_Wing.DoubleDoor)
                {
                    cbDDAK.Visibility = Visibility.Visible;

                }
                else
                {
                    cbDDAK.Visibility = Visibility.Hidden;
                }

            }




        }

        void _Save()
        {
            switch (_mode)
            {
                case MyMode.AddNew:
                    _AddNew();
                    break;
                case MyMode.Update:
                    _Update();
                    break;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (_Wing != null)
            {
                if (_Wing.ID == 9)
                {
                    new MainTapi().Show();
                    this.Close();
                }
                else
                {
                    new wpfOrderPage(_OrderID).Show();
                    this.Close();
                }
            }
            else
            {
                if (_order != null)
                {
                    new wpfOrderPage(_OrderID).Show();
                    this.Close();
                }
                else
                {
                    new MainTapi().Show();
                    this.Close();
                }

            }
        }

        int _ValidateInputs(string text)
        {

            if (int.TryParse(text, out int value))
            {
                return value;
            }
            else
            {
                return 0;
            }

        }



        private void saveToDB(object sender, KeyEventArgs e)
        {
            clsWings tempAmount = clsWings.Find(_Wing.DDWingID);
            TextBox txtSender = (TextBox)sender;
            if (_mode == MyMode.Update)
            {
                switch (txtSender.Name)
                {

                    //case "txtColorWing":
                    //    _Wing.ColorDoor = txtSender.Text;
                    //    break;
                    //case "txtColorSide":
                    //    _Wing.ColorSide = txtSender.Text;
                    //    break;
                    case "txtHightCut":
                        _Wing.HeightCut = _ValidateInputs(txtSender.Text);
                        
                        break;
                    case "txtWidthCut":
                        _Wing.WidthCut = _ValidateInputs(txtSender.Text);
                        break;
                    case "txtHightFinal":
                        _Wing.HeightFinal = _ValidateInputs(txtSender.Text);
                        break;
                    case "txtWidthFinal":
                        _Wing.WidthFinal = _ValidateInputs(txtSender.Text);
                        break;
                    case "txtNumberWing":




                        if (!clsWings.IsExistNumberDoor(_OrderID, txtSender.Text))
                        {
                            _Wing.DoorNumber = txtSender.Text;
                         
                        }



                        break;

                    case "txtAccID":
                        _Wing.AccID = txtSender.Text;
                        if (tempAmount != null)
                        {
                            tempAmount.AccID = txtSender.Text;
                            tempAmount.Save();
                        }
                        break;

                    case "txtLocation":
                        _Wing.Location = txtSender.Text;
                        if (tempAmount != null)
                        {
                            tempAmount.Location = txtSender.Text;
                            tempAmount.Save();
                        }
                        break;
                    case "txtNotes":
                        _Wing.Notes = txtSender.Text;
                        if (tempAmount != null)
                        {
                            tempAmount.Notes = txtSender.Text;
                            tempAmount.Save();
                        }
                        break;
                    case "txtFactoryNotes":
                        _Wing.FactoryNotes = txtSender.Text;
                        if (tempAmount != null)
                        {
                            tempAmount.FactoryNotes = txtSender.Text;
                            tempAmount.Save();
                        }
                        break;
                    case "tbPrintAmount":
                        _Wing.tbPrintAmount = _ValidateInputs(txtSender.Text);
                        break;
                    case "tbStickers":
                        _Wing.tbStickers = _ValidateInputs(txtSender.Text);
                        break;
                    case "tbAmount":
                     
                        if(tempAmount != null)
                        {
                            tempAmount.tbAmount = _ValidateInputs(txtSender.Text);
                            tempAmount.Save();
                        }
                        _Wing.tbAmount = _ValidateInputs(txtSender.Text);
                        break;

                }


                if (_Wing != null && _Wing.Save())
                {

                    txtNumberWing.Background = (Brush)(new BrushConverter().ConvertFrom("#7F80DFFF"));

                    txtNumberWing.Foreground = Brushes.Black;

                    allscren.IsEnabled = true;
                }

                if (_Wing != null && _Wing.Save())
                {

                    // _Update();
                    //   _inputFill();
                    //UPDATEUI();
            

                }

            }
        }

        void _btnClick(Button btnSender)
        {
            _wingTemp = clsWings.Find(_Wing.DDWingID);
            switch (btnSender.Name)
            {

                case "btnDirectionR":
                  
                    if (_Wing.DoubleDoor &&  cbDDAK.IsChecked==true && _Wing.Direction == "Right") //cbDDAK.IsChecked = K
                    {
                        _Wing.Direction = "Left";
                        DDwing.Direction = "Right";

                    }
                    else if (_Wing.DoubleDoor && cbDDAK.IsChecked == true && _Wing.Direction == "Left") //cbDDAK.IsChecked = K
                     {
                        _Wing.Direction = "Right";
                        DDwing.Direction = "Left";
               
                    }
                    else if(_Wing.DoubleDoor && cbDDAK.IsChecked == false && _Wing.Direction == "Right")//cbDDAK.IsChecked = A
                    {
                        _Wing.Direction = "Left";
                        DDwing.Direction = "Right";
                    }
                    else if (_Wing.DoubleDoor && cbDDAK.IsChecked == false && _Wing.Direction == "Left")//cbDDAK.IsChecked = A
                    {
                   

                        _Wing.Direction = "Right";
                        DDwing.Direction = "Left";
                    }
                    else
                    {
                        _Wing.Direction = btnSender.Tag.ToString();

                    }

                    break;
                case "btnDirectionL":

                    if (_Wing.DoubleDoor && cbDDAK.IsChecked == true && _Wing.Direction == "Right") //cbDDAK.IsChecked = K
                    {
                        _Wing.Direction = "Left";
                        DDwing.Direction = "Right";

                    }
                    else if (_Wing.DoubleDoor && cbDDAK.IsChecked == true && _Wing.Direction == "Left") //cbDDAK.IsChecked = K
                    {
                        _Wing.Direction = "Right";
                        DDwing.Direction = "Left";

                    }
                    else if (_Wing.DoubleDoor && cbDDAK.IsChecked == false && _Wing.Direction == "Right")//cbDDAK.IsChecked = A
                    {
                        _Wing.Direction = "Left";
                        DDwing.Direction = "Right";
                    }
                    else if (_Wing.DoubleDoor && cbDDAK.IsChecked == false && _Wing.Direction == "Left")//cbDDAK.IsChecked = A
                    {


                        _Wing.Direction = "Right";
                        DDwing.Direction = "Left";
                    }
                    else
                    {
                        _Wing.Direction = btnSender.Tag.ToString();

                    }

                    break;

                case "btnFormicaThiknss4":
                    _Wing.FormaicaThickness = 4f;
                    if (DDwing != null)
                    {
                        DDwing.FormaicaThickness = 4f;
                        KantChangeIFChangeThickFormaick(DDwing.ID, 37);

                    }
                    KantChangeIFChangeThickFormaick(_Wing.ID, 37);
                  
                    break;
                case "btnFormicaThiknss2_5":
                    _Wing.FormaicaThickness = 2.5f;
                    if (DDwing != null)
                    {
                        DDwing.FormaicaThickness = 2.5f;
                        KantChangeIFChangeThickFormaick(DDwing.ID, 40);

                    }
                    KantChangeIFChangeThickFormaick(_Wing.ID, 40);
                
                    break;


            }


          if(DDwing != null && DDwing.Save())
            {
           
                UPDATEUI();
            }

        }

        async void KantChangeIFChangeThickFormaick(int id,int val)
        {
            clsKantWingManual ckwm = clsKantWingManual.FindByWingID(id);


            if(ckwm != null)
            {

                ckwm.KantA = val;
                ckwm.KantB = val;
                await ckwm.SaveAsync();

            }
        }
        void _cbClick(CheckBox btnSender)
        {
            _wingTemp = clsWings.Find(_Wing.DDWingID);
            switch (btnSender.Name)
            {

                case "cbSupportHelpless":
                    _Wing.SupportHelpless = btnSender.IsChecked == true ? true : false;
                    break;
                case "cbMakhzerShemen":
               
                    _Wing.MakhzerShemen = btnSender.IsChecked == true ? true : false;
                    if (_wingTemp != null)
                    {
                        _wingTemp.MakhzerShemen = btnSender.IsChecked == true ? true : false;
                        _wingTemp.Save();
                    }
                    break;
                case "cbAtmer":
                    _Wing.Atmer = btnSender.IsChecked == true ? true : false;
                    if (_wingTemp != null)
                    {
                        _wingTemp.Atmer = btnSender.IsChecked == true ? true : false;
                        _wingTemp.Save();
                    }
                    break;
                case "cbSide":
                    _Wing.Side = btnSender.IsChecked == true ? true : false;
                    if (_wingTemp != null)
                    {
                        _wingTemp.Side = btnSender.IsChecked == true ? true : false;
                        _wingTemp.Save();
                    }
                    break;



            }

        }

        private void saveToDB(object sender, RoutedEventArgs e)
        {


            if (_mode == MyMode.Update)
            {


                if (sender.GetType() == typeof(Button))
                {
                    Button btnSender = (Button)sender;
                    _btnClick(btnSender);
                }
                else
                {
                    CheckBox cbSender = (CheckBox)sender;
                    _cbClick(cbSender);
                }




                if (_Wing.Save())
                {
                    UPDATEUI();
                    _Update();
                    _inputFill();
                }
            }

            // ucViewWinge.UPDATEUIReport(_WingID);
        }


        private void wpfWing_Loaded(object sender, RoutedEventArgs e)
        {
            _Update();
            _inputFill();
            UPDATEUI();
            txtNumberWing.Focus();
            popTextBoxTFwingNum.IsOpen = false;
            popTextBoxTFwingNum.PlacementTarget = (txtNumberWing);
            if (clsColorSide.getAll() != null)
            {
                cbColorSidelist.ItemsSource = clsColorSide.getAll().DefaultView;
            }


            fillColorDoor();


            // ucViewWinge.UPDATEUIReport(_WingID);

        }

        private void ucViewWinge_OnCalculationComplete_1(clsSetParameterToReportWing obj)
        {

            _setParamToReport = obj;

        }

        void fillColorDoor()
        {
            //koko2
            if (_wingType != null && _wingType.TEST2 == "A")
            {
                if (clsColorSide.getAll() != null)
                {
                    cbColorWing.ItemsSource = clsColorSide.getAll().DefaultView;
                }
            }
            else if (_wingType != null && _wingType.TEST2 == "F")
            {
                if (clsFormicaColor.getAll() != null)
                {
                    cbColorWing.ItemsSource = clsFormicaColor.getAll().DefaultView;
                }
            }
            else
            {
                cbColorWing.ItemsSource = null;
            }
        }

        private void PrintReport(object sender, RoutedEventArgs e)
        {
            if (_Wing.Save())
            {
                cbDDAK.IsChecked = false;
                _Update();
                _inputFill();
                UPDATEUI();

            }

            if (_Wing != null)
            {
                int multiStikrsAmount = 0;
                 byte stikrsAmountPrint = clsSettings.CalcAmountPrintStikrsWing(_WingID, (byte)_Wing.tbStickers);
          
               

                if(string.IsNullOrEmpty(tbStickers.Text) || (byte)_Wing.tbStickers <= 0)
                {
                    multiStikrsAmount = stikrsAmountPrint * _Wing.tbAmount;
           

                }
                else
                {
                    if (int.TryParse(tbStickers.Text, out int res))
                    {

                        multiStikrsAmount = res;
                    }
                }

                clsPrintDirect.PrintWing(_setParamToReport, clsSettings.CalcAmountPrintPeperWing(_WingID, (byte)_Wing.tbPrintAmount), multiStikrsAmount);
                if (_Wing.DoubleDoor)
                {
                    cbDDAK.IsChecked = true;
                    _Update();
                    _inputFill();
                    UPDATEUI();

                    clsPrintDirect.PrintWing(_setParamToReport, clsSettings.CalcAmountPrintPeperWing(_WingID, (byte)_Wing.tbPrintAmount), multiStikrsAmount);
                }
            }
            ucViewWinge.UPDATEUIReport(_WingID);
        }

        private void txtHightFinal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHightFinal.Text))
            {

                txtHightCut.IsEnabled = true;
            }
            else
            {
                
                if (!_Wing.DoubleDoor)
                {
                    txtHightCut.Text = "";
                    txtHightCut.IsEnabled = false;
                }
            }
        }

        private void txtHightCut_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHightCut.Text))
            {

                txtHightFinal.IsEnabled = true;
            }
            else
            {
                if (!_Wing.DoubleDoor)
                {
                    txtHightFinal.Text = "";               
                    txtHightFinal.IsEnabled = false;
                }
            }
        }

        private void txtWidthFinal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtWidthFinal.Text))
            {

                txtWidthCut.IsEnabled = true;
            }
            else
            {
                
                if (!_Wing.DoubleDoor)
                {
                    txtWidthCut.Text = "";
                    txtWidthCut.IsEnabled = false;
                }
            }
        }

        private void txtWidthCut_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtWidthCut.Text))
            {

                txtWidthFinal.IsEnabled = true;
            }
            else
            {
                
                if (!_Wing.DoubleDoor)
                {
                    txtWidthFinal.Text = "";
                    txtWidthFinal.IsEnabled = false;
                }
            }
        }

        int countcbmakzershemn = 0;
        private void cbMakhzerShemen_Click(object sender, RoutedEventArgs e)
        {

            MakhzerShemenManoul = true;



            if (countcbmakzershemn < 1)
            {
                popTextBoxTF.IsOpen = true;
                popTextBoxTF.PlacementTarget = null;
                popTextBoxTF.PlacementTarget = cbMakhzerShemen;
            }
            else
            {
                popTextBoxTF.IsOpen = false;
                popTextBoxTF.PlacementTarget = null;
                popTextBoxTF.PlacementTarget = cbMakhzerShemen;
            }


            countcbmakzershemn++;

        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            _doorRepeted = 0;
            _Update();
            _inputFill();
            UPDATEUI();
            if (_Wing != null)
            { 
           
                    _WingID = _Wing.CopyWing();
                  

            }
            _Update();
            _inputFill();
            UPDATEUI();

            txtNumberWing.Focus();


        }

        private void wpfWing_Activated(object sender, EventArgs e)

        {

        }

        private void wpfWing_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnAmount_Click(object sender, RoutedEventArgs e)
        {
            if (_Wing.Save())
            {
                cbDDAK.IsChecked = false;
                _Update();
                _inputFill();
                UPDATEUI();


            }
            if (_Wing != null)
            {


                clsPrintDirect.PrintWingNiar(_setParamToReport, clsSettings.CalcAmountPrintPeperWing(_WingID, (byte)_Wing.tbPrintAmount));
                if (_Wing.DoubleDoor)
                {
                    cbDDAK.IsChecked = true;
                    _Update();
                    _inputFill();
                    UPDATEUI();
                    clsPrintDirect.PrintWingNiar(_setParamToReport, clsSettings.CalcAmountPrintPeperWing(_WingID, (byte)_Wing.tbPrintAmount));
                }

            }



        }

        private void txtFactoryNotes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_Wing.Save())
            {
                _Update();
                _inputFill();
                UPDATEUI();
            }

        }

        private void btnPrintStikrs_Click(object sender, RoutedEventArgs e)
        {
            if (_Wing.Save())
            {
                cbDDAK.IsChecked = false;
                _Update();
                _inputFill();
                UPDATEUI();

            }

            if (_Wing != null)
            {
                int multiStikrsAmount = 0;
                byte stikrsAmountPrint = clsSettings.CalcAmountPrintStikrsWing(_WingID, (byte)_Wing.tbStickers);
                if(string.IsNullOrEmpty(tbStickers.Text) || _Wing.tbStickers <= 0)
                {
                    multiStikrsAmount = stikrsAmountPrint * _Wing.tbAmount;
                }
                else
                {
                    if (int.TryParse(tbStickers.Text, out int res))
                    {

                        multiStikrsAmount = res;
                    }

                }
                

                clsPrintDirect.PrintWingStikrs(_setParamToReport, multiStikrsAmount);
                if (_Wing.DoubleDoor)
                {
                    cbDDAK.IsChecked = true;
                    _Update();
                    _inputFill();
                    UPDATEUI();
                    clsPrintDirect.PrintWingStikrs(_setParamToReport, multiStikrsAmount);
                }

            }
            ucViewWinge.UPDATEUIReport(_WingID);
        }

        private void textboxs_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Focus();
            ((TextBox)sender).SelectAll();
        }

        private void txtNumberWing_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtNumberWing_LostFocus(object sender, RoutedEventArgs e)
        {
            popTextBoxTFwingNum.IsOpen = false;
            popTextBoxTFwingNum.PlacementTarget = (txtNumberWing);
            if (_Wing != null)
            {


                if (_Wing.Save())
                {
                    _Update();
                    _inputFill();
                    UPDATEUI();

                    popTextBoxTFwingNum.IsOpen = false;
                }
            }



        }

        private void txtNumberWing_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (!string.IsNullOrEmpty(txtNumberWing.Text))
            {
                if (clsWings.IsExistNumberDoor(_OrderID, txtNumberWing.Text))
                {


                    popTextBoxTFwingNum.IsOpen = true;
                    popTextBoxTFwingNum.PlacementTarget = (txtNumberWing);





                }
                else
                {
                    popTextBoxTFwingNum.IsOpen = false;
                    popTextBoxTFwingNum.PlacementTarget = (txtNumberWing);



                }

            }
        }

        private void cbColorSidelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbStickers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbColorSidelist_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_Wing != null)
            {


                if (clsColorSide.Find(cbColorSidelist.Text) == null)
                {
                    clsColorSide DDDD = new clsColorSide();
                    DDDD.ColorName = cbColorSidelist.Text;
                    DDDD.Save();
                    _Wing.ColorSide = DDDD.ID.ToString();
                    if (_wingTemp != null)
                    {
                        _wingTemp.ColorSide = DDDD.ID.ToString();
                        _wingTemp.Save();
                    }
                }
                else
                {
                    if (cbColorSidelist.SelectedValue != null)
                    {
                        if (_wingTemp != null)
                        {
                            _wingTemp.ColorSide = cbColorSidelist.SelectedValue.ToString();
                            _wingTemp.Save();
                        }
                        _Wing.ColorSide = cbColorSidelist.SelectedValue.ToString();
                    }
                }

                if (_Wing.Save())
                {
                    _Update();
                    _inputFill();
                    UPDATEUI();

                }
            }
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            if (_Wing != null && _Wing.Save())
            {
                _Update();
                _inputFill();
                UPDATEUI();
                TempWing = clsWings.Find(_WingID);




                if (MessageBox.Show("delete all data", "Woring Missing data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (_Wing != null)
                    {
                        _Wing.clear();
                        _Wing.Save();
                        _Update();
                        _inputFill();
                        UPDATEUI();
                        ucViewWinge.UPDATEUIReport(_WingID);
                        btnback.Visibility = Visibility.Visible;
                    }

                }
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            if (_Wing != null && _Wing.Save())
            {


                if (MessageBox.Show("back old all data", "Woring  data", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (TempWing != null && _Wing != null)
                    {
                        _Wing = TempWing;
                        _Wing.Save();
                        _Update();
                        _inputFill();
                        UPDATEUI();

                        ucViewWinge.UPDATEUIReport(_WingID);
                        popTextBoxTFwingNum.IsOpen = false;
                        btnback.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

     

        private void cbDoubleDoor_Unchecked(object sender, RoutedEventArgs e)
        {


            cbDDAK.IsChecked = false;


            if (DDwing != null && (_Wing.DDWingID == DDwing.ID))
            {

                _Wing.DoubleDoor = false;

                clsWings.Delete(DDwing.ID);

                _Wing.DDWingID = -1;
                _Wing.DDAK = "N";
                _Wing.DoorNumber = _Wing.DoorNumber.Remove(txtNumberWing.Text.Length-1);
               
                DDwing = null;

                if (_Wing.Save())
                {
                 
                    UPDATEUI();
                }

            }
            popTextBoxTFwingNum.IsOpen = false;

            btnCopy.IsEnabled = true;
      

        }


        private void cbDoubleDoor_Checked(object sender, RoutedEventArgs e)
        {
            if (_Wing != null && (_Wing.HeightCut <= 0 && _Wing.WidthCut <= 0))
            {



                MessageBox.Show("Pleass Fill WidthCut And HeightCut");
                cbDoubleDoor.IsChecked = false;
                return;


            }


            _Wing.DoubleDoor = true;


            if (DDwing == null && (_Wing.DDWingID != _Wing.ID))
            {

                DDwing = _Wing.DDCopyWing();

                _Wing.DDAK = "A";
                _Wing.DoorNumber = _Wing.DoorNumber + "A";
                _Wing.DDWingID = DDwing.ID;

                clsWingAdvanced tempad = clsWingAdvanced.FindByWingID(DDwing.ID);
                clsWingLock templock = clsWingLock.FindByWingID(DDwing.ID);

                if (templock != null && tempad != null)
                {
                    tempad.woodLockBasic = false;
                    templock.LockType = "NoLock";

                    tempad.Save();
                    templock.Save();
                }
            }
            if (_Wing.Save())
            {
                _inputFill();
                UPDATEUI();
            }
            popTextBoxTFwingNum.IsOpen = false;

            btnCopy.IsEnabled = false;
        }

        private void cbDDAK_Unchecked(object sender, RoutedEventArgs e)//A
        {
            cbDDAK.Content = "A";
            clsWings tempwing = _Wing;
            _WingID = DDwing.ID;
            _Wing = DDwing;
            DDwing = tempwing;


            _advanced.CalcKant();
            _Update();
            _inputFill();
            UPDATEUI();
            popTextBoxTFwingNum.IsOpen = false;
        }

        private void cbDDAK_Checked(object sender, RoutedEventArgs e)//K
        {
            cbDDAK.Content = "K";
            clsWings tempwing = _Wing;

          _WingID = DDwing.ID;
            _Wing = DDwing;
            DDwing = tempwing;
            clsWingAdvanced tempAdv = clsWingAdvanced.FindByWingID(_Wing.DDWingID);
            if(tempAdv != null)
            {
                tempAdv.CalcKant();
            }
      
            _Update();
            _inputFill();
            UPDATEUI();
            popTextBoxTFwingNum.IsOpen = false;
        }

        void colorsaveDoorF()
        {
            if (clsFormicaColor.Find(cbColorWing.Text) == null)
            {
                clsFormicaColor FDDDD = new clsFormicaColor();
                FDDDD.ColorName = cbColorWing.Text;
                FDDDD.Save();
                _Wing.ColorDoor = FDDDD.ID.ToString();
                if (_wingTemp != null)
                {
                    _wingTemp.ColorDoor = FDDDD.ID.ToString();
                    _wingTemp.Save();
                }
            }
            else
            {

                if (cbColorWing.SelectedValue != null)
                {
                    if (_wingTemp != null)
                    {
                        _wingTemp.ColorDoor = cbColorWing.SelectedValue.ToString();
                        _wingTemp.Save();
                    }
                    _Wing.ColorDoor = cbColorWing.SelectedValue.ToString();
                }
            }

            if (_Wing.Save())
            {
                _Update();
                _inputFill();
                UPDATEUI();

            }
        } 
        
        void colorsaveDoorA()
        {
            if (clsColorSide.Find(cbColorWing.Text) == null)
            {
                clsColorSide FDDDD = new clsColorSide();
                FDDDD.ColorName = cbColorWing.Text;
                FDDDD.Save();
                _Wing.ColorDoor = FDDDD.ID.ToString();
                if(_wingTemp != null)
                {
                    _wingTemp.ColorDoor = FDDDD.ID.ToString();
                    _wingTemp.Save();
                }

            }
            else
            {

                if (cbColorWing.SelectedValue != null)
                {
                    if (_wingTemp != null)
                    {
                        _wingTemp.ColorDoor = cbColorWing.SelectedValue.ToString();
                        _wingTemp.Save();
                    }

                    _Wing.ColorDoor = cbColorWing.SelectedValue.ToString();
                }
            }

            if (_Wing.Save())
            {
                _Update();
                _inputFill();
                UPDATEUI();

            }
        }

        private void cbColorWing_LostFocus(object sender, RoutedEventArgs e)
        {
            _wingTemp = clsWings.Find(_Wing.DDWingID);
            if (_Wing != null)
            {

                if (_wingType != null && _wingType.TEST2 == "A")
                {
                    colorsaveDoorA();
                }
                else if (_wingType != null && _wingType.TEST2 == "F")
                {
                    colorsaveDoorF();
                }
               


                 
            }
        }

        private void cbDoubleDoor_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnKantManual_Click(object sender, RoutedEventArgs e)
        {
            if (_setParamToReport != null)
            {
                KantManual kant = new KantManual(_WingID, _setParamToReport.R_imgKant);
                kant.ShowDialog();
                _Update();
                _inputFill();
                UPDATEUI();
                ucViewWinge.UPDATEUIReport(_WingID);
            }
        }

        private void cbColorWing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

