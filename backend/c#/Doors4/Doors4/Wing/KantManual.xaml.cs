using Doors4.clsGenral;
using SharaLogic;
using SharaLogic.Calculations;
using System;
using System.Collections.Generic;
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

namespace Doors4.Wing
{
    /// <summary>
    /// Interaction logic for KantManual.xaml
    /// </summary>
    public partial class KantManual : Window
    {

        enum MODEKANT { New=1,Update=2}
        MODEKANT _mode = MODEKANT.New;

        clsWings _Wing;

        clsKantWingManual _KWM;

        string TypeFullName;

        int ID;
        public KantManual(int WingID,string PathImg)
        {
            InitializeComponent();

            _Wing = clsWings.Find(WingID);
            if(_Wing == null)
            {
                MessageBox.Show("Error");
                return;
            }
    
            imgKant.Source = imagePath(PathImg);

            TypeFullName = System.IO.Path.GetFileNameWithoutExtension(PathImg);

            _KWM= clsKantWingManual.FindByWingID(WingID);

            if (_KWM == null)
            {
                 _mode = MODEKANT.New;
                UPDATEUI();
            }
            else
            {
                _mode = MODEKANT.Update;
                UPDATEUI();
            }

            if (TypeFullName == "WingKantHiddenDouble1" || TypeFullName == "WingKantHiddenDouble2" )
            {
                img3dF0.Visibility = Visibility.Visible;
            }
            else
            {
                img3dF0.Visibility = Visibility.Hidden;

            }

            if(_Wing.DDAK == "K")
            {
                txtKantA.IsEnabled = false;
                txtKantB.IsEnabled = false;

            }
            else
            {
                txtKantA.IsEnabled = true;
                txtKantB.IsEnabled = true;
            }
        }
       async void  _ADD()
        {
            _KWM = new clsKantWingManual();
            _KWM.WingID = _Wing.ID;
            if (await _KWM.SaveAsync())
            {
                _mode = MODEKANT.Update;
                ID = _KWM.ID;
                UPDATEUI();
            }


        }
        void _UPDATE()
        {

            if(_KWM != null)
            {
                ID = _KWM.ID;

                FILLDATA();
            }

        }
        void FILLDATA()
        {
            txtKantA.Text = _KWM.KantA.ToString();
            txtKantB.Text = _KWM.KantB.ToString();
            txtKantC.Text = _KWM.KantC.ToString();
            txtKantD.Text = _KWM.KantD.ToString();
            txtKantE.Text = _KWM.KantE.ToString();
            txtKantF.Text = _KWM.KantF.ToString();
 
        }
        void UPDATEUI()
        {
            switch (_mode)
            {
                case MODEKANT.New:
                    _ADD();
                    break;
                case MODEKANT.Update:
                    _UPDATE();
                    break;
            }
        }

        BitmapImage imagePath(string uri)
        {
            if (uri != "")
            {
                try
                {
                    return new BitmapImage(new Uri(uri));
                }
                catch
                {
                    return new BitmapImage(new Uri(clsImageLibrary.Empty));
                }
            }
            else
            {
                return new BitmapImage(new Uri(clsImageLibrary.Empty));
            }
        }


    

        private async void btnclose_Click(object sender, RoutedEventArgs e)
        {
            clsKantWingManual temp = clsKantWingManual.FindByWingID(_Wing.DDWingID);
            if(temp != null)
            {
                temp.KantA = _KWM.KantA;
                temp.KantB = _KWM.KantB;
              await  temp.SaveAsync();
            }
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setBoxLocation();
        }

        void KantBox(TextBox box,Visibility visb,int left,int top,int rigth,int Bootm)
        {
            box.Visibility = visb;
            box.Margin = new Thickness(left, top, rigth, Bootm);
        }  
     

        void setBoxLocation()
        {

            switch (TypeFullName)
            {
                case "WingKantMedicPivotNew":

                    KantBox(txtKantA, Visibility.Visible, 370, 30, 0, 0);
                 

                    KantBox(txtKantB, Visibility.Visible, 560, 200, 0, 0);
                 
                    break; 
                
                case "WingKantHidden":

                    KantBox(txtKantA, Visibility.Visible, 370, 30, 0, 0);
                 

                    KantBox(txtKantB, Visibility.Visible, 560, 200, 0, 0);
                 
                    break;    
                
                case "WingKantA":

                    KantBox(txtKantA, Visibility.Visible,370, 175, 0, 0);
                  

                    KantBox(txtKantB, Visibility.Visible, 560, 260, 0, 0);
                
                    break;  
                
                case "WingKantVisible":

                    KantBox(txtKantA, Visibility.Visible, 370, 30, 0, 0);
                

                    KantBox(txtKantB, Visibility.Visible, 550, 200, 0, 0);
         

                    KantBox(txtKantC, Visibility.Visible, 560, 320, 0, 0);
    
                    break;    
                
                case "WingKantHiddenPivot":

                    KantBox(txtKantA, Visibility.Visible, 370, 30, 0, 0);
                

                    KantBox(txtKantB, Visibility.Visible, 550, 200, 0, 0);
         

                
    
                    break;  
                    
                case "WingKantVisiblePivot":

                    KantBox(txtKantA, Visibility.Visible, 370, 30, 0, 0);
             

                    KantBox(txtKantB, Visibility.Visible, 550, 180, 0, 0);
                

                    KantBox(txtKantC, Visibility.Visible, 560, 320, 0, 0);
          
                    break;  
                
                case "WingKantMedic":

                    KantBox(txtKantA, Visibility.Visible, 370, 30, 0, 0);
                

                    KantBox(txtKantB, Visibility.Visible, 550, 200, 0, 0);
                   

                    KantBox(txtKantC, Visibility.Visible, 220, 30, 0, 0);
             
                    break;  
                
                case "WingKantHiddenDouble1":

                    KantBox(txtKantA, Visibility.Visible, 375, 30, 0, 0);
                  

                    KantBox(txtKantB, Visibility.Visible, 550, 200, 0, 0);
            

                    KantBox(txtKantC, Visibility.Visible, 300, 285, 0, 0);
              
                    
                    KantBox(txtKantD, Visibility.Visible, 350, 310, 0, 0);
          
                    break;   
                
                case "WingKantHiddenDouble2":

                    KantBox(txtKantA, Visibility.Visible, 375, 30, 0, 0);
                  

                    KantBox(txtKantB, Visibility.Visible, 550, 200, 0, 0);
            

                    KantBox(txtKantC, Visibility.Visible, 300, 180, 0, 0);
              
                    
                    KantBox(txtKantD, Visibility.Visible, 350, 260, 0, 0);
          
                    break; 
                    
                case "WingKantVisibleDouble1":

                    KantBox(txtKantA, Visibility.Visible,354,34,0,0);                  
                    KantBox(txtKantB, Visibility.Visible,523,134,0,0);          
                    KantBox(txtKantC, Visibility.Visible,550,245,0,0);          
                    KantBox(txtKantD, Visibility.Visible,470,312,0,0);
                    KantBox(txtKantE, Visibility.Visible,376,326,0,0);
                    KantBox(txtKantF, Visibility.Visible, 189, 281, 0, 0);
          
                    break;  
                
                case "WingKantVisibleDouble2":

                    KantBox(txtKantA, Visibility.Visible,354,34,0,0 );                  
                    KantBox(txtKantB, Visibility.Visible,523,134,0,0);          
                    KantBox(txtKantC, Visibility.Visible,550,245,0,0);          
                    KantBox(txtKantD, Visibility.Visible,414,312,0,0);
                    KantBox(txtKantE, Visibility.Visible,195,322,0,0);
                    KantBox(txtKantF, Visibility.Visible, 222, 188, 0, 0);
          
                    break;

            }
        }

        private async void SaveData(object sender, KeyEventArgs e)
        {
            int num = clsValidationData.TextToInt(((TextBox)sender).Text);

            switch (((TextBox)sender).Name)
            {
                case "txtKantA":
                _KWM.KantA = num ;
                    break; 
                case "txtKantB":
                _KWM.KantB = num ;
                    break;   
                case "txtKantC":
                _KWM.KantC = num ;
                    break; 
                case "txtKantD":
                _KWM.KantD = num ;
                    break; 
                case "txtKantE":
                _KWM.KantE = num ;
                    break;
                case "txtKantF":
                _KWM.KantF = num ;
                    break;

        }
          


            await _KWM.SaveAsync();

          
            
        }
    }
}
