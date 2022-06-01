using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;

namespace KantimeEvv.Controls.CustomDialogs
{
  
    public partial class AllowBiometricDialog : Popup
    {
        public AllowBiometricDialog()
        {
            InitializeComponent();

            this.BackgroundColor = Color.Transparent;
         
        }

        private void Skip_Clicked(object sender, EventArgs e)
        {
            Dismiss(false);
        }

        private void Permisson_Clicked(object sender, EventArgs e)
        {
            Dismiss(true);
        }
    }
}