using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KantimeEvv.Controls.Templates
{

    public partial class VisitOverviewTemplate : Frame
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
nameof(StartColor),
  typeof(Color),     
  typeof(VisitOverviewTemplate)   
);     

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
nameof(EndColor),       
typeof(Color),    
typeof(VisitOverviewTemplate)  
);      

        public static readonly BindableProperty HeaderbackgroundProperty = BindableProperty.Create(
nameof(Headerbackground),      
typeof(Color),    
typeof(VisitOverviewTemplate) 
);

        public VisitOverviewTemplate()
        {
            InitializeComponent();
            BindingContext = this;
        }


        public Color StartColor
        {
            get => (Color)GetValue(VisitOverviewTemplate.StartColorProperty);
            set => SetValue(VisitOverviewTemplate.StartColorProperty, value);
        }

        public Color EndColor
        {
            get => (Color)GetValue(VisitOverviewTemplate.EndColorProperty);
            set => SetValue(VisitOverviewTemplate.EndColorProperty, value);
        }

        public Color Headerbackground
        {
            get => (Color)GetValue(VisitOverviewTemplate.HeaderbackgroundProperty);
            set => SetValue(VisitOverviewTemplate.HeaderbackgroundProperty, value);
        }



    }
}