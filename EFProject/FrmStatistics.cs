using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        EducationEfTravelDbEntities db = new EducationEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            labelLocationCount.Text = db.Location.Count().ToString();
            labelSumCapacity.Text = db.Location.Sum(x => x.Capasity).ToString();
            labelSumGuide.Text = db.Guide.Count().ToString();
            labelCapacityAvarege.Text = db.Location.Average(x => x.Capasity)?.ToString("0.00");
            labelTravePriceAvarege.Text = db.Location.Average(x => x.Price)?.ToString("0.00") + "₺";
            labelAddLastCountry.Text = db.Location.OrderByDescending(x => x.Id).Select(x => x.Country).FirstOrDefault().ToString();
            labelCapacityKapadokya.Text = db.Location.Where(x => x.City == "Kapadokya").Select(x => x.Capasity).FirstOrDefault().ToString();
            labelTurkiyeAvrCapacity.Text = db.Location.Where(x => x.Country == "Türkiye").Average(x => x.Capasity)?.ToString("0.00");
            labelRomaGuideName.Text = db.Location.Where(x => x.City == "Roma").Select(x => x.Guide.Name + " " + x.Guide.Surname).FirstOrDefault() ?? "Rehber bulunamadı";
            labelMaxCapacity.Text = db.Location.OrderByDescending(x => x.Capasity).Select(x=>x.City).FirstOrDefault().ToString();
            labelExpensivePrice.Text = db.Location.OrderByDescending(x => x.Price).Select(x=>x.City).FirstOrDefault().ToString();
            labelGetGuideName.Text = db.Location.Where(x => x.GuideId == 1).Count().ToString();
        }

     
    }
}
