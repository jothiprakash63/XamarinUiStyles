using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KantimeEvv.Pages
{ 
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

       List<ChartEntry> entries = new List<ChartEntry>
{
    new ChartEntry(212)
        {
            Label = "UWP",
        ValueLabel = "112",
        Color = SKColor.Parse("#2c3e50")
    },
    new ChartEntry(248)
        {
            Label = "Android",
        ValueLabel = "648",
        Color = SKColor.Parse("#77d065")
    },
    new ChartEntry(128)
        {
            Label = "iOS",
        ValueLabel = "428",
        Color = SKColor.Parse("#b455b6")
    },
    new ChartEntry(514)
        {
            Label = "Forms",
        ValueLabel = "214",
        Color = SKColor.Parse("#3498db")
    }
    };

    protected override void OnAppearing()
        {
            base.OnAppearing();
            this.barchart.Chart = new BarChart() { Entries = entries };
            this.linechart.Chart = new LineChart() { Entries = entries };
        }
    }
}