using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartBulmaca
{
    public partial class Form1 : Form
    {
        List<string> semboller = new List<string>()
        {
            "🍋","🍋","🍓","🍓",
            "🍇","🍇","🍈","🍈",
            "🍎","🍎","🍉","🍉",
            "🥝","🥝","🍐","🍐"

        };

        Button ilkSecilen = null;
        Button ikinciSecilen = null;

        Timer eslesmeKontrolZamani= new Timer();
        public Form1()
        {
            InitializeComponent(); //tasarım ekranında oluşturduğumuz kontrolleri forma basan kurucu metot.
            sembolleriKaristir(); 
            butonlaraSembolAta();
            eslesmeKontrolZamani.Interval = 750; //timerın ne kadar çalışacağını belirtir.
            eslesmeKontrolZamani.Tick += EslesmeKontrolZamani_Tick;
            
        }
        private void sembolleriKaristir()
        {
            Random rnd = new Random();
            semboller=semboller.OrderBy(x=>rnd.Next()).ToList(); // Her yeni turda kartların yerini değiştirir farklı bir oynanış sağlar.
        }
        private void butonlaraSembolAta()
        {
            int i = 0;

            foreach(Control kontrol in tableLayoutPanel1.Controls)
            {

                if (kontrol is Button)
                {
                    Button btn = (Button)kontrol;
                    btn.Font = new Font(FontFamily.GenericSansSerif,24,FontStyle.Bold);
                    btn.Text = "?";
                    btn.Tag = semboller[i];
                    btn.Click += KartTiklandi;
                    i++;
                }
            }
        }

        private void KartTiklandi(object sender, EventArgs e)
        {
            Button tiklanan = sender as Button;

            if (tiklanan==null || tiklanan.Text!="?")
            {
                return;
            }
            tiklanan.Text= tiklanan.Tag.ToString(); //ilk ve ikinci seçilen kart burada tutulur sonucunda simge text olarak gösterilir.

            if (ilkSecilen == null)
            {
                ilkSecilen = tiklanan;
            }
            else
            {
                ikinciSecilen = tiklanan;
                eslesmeKontrolZamani.Start();
            }
        }
        private void EslesmeKontrolZamani_Tick(object sender,EventArgs e)
        {
            eslesmeKontrolZamani.Stop();

            if(ilkSecilen.Tag.ToString()==ikinciSecilen.Tag.ToString())
            {
                ilkSecilen.Enabled= false;
                ikinciSecilen.Enabled= false;
            }
            else
            {
                ilkSecilen.Text = "?";
                ikinciSecilen.Text = "?";
            }
            ilkSecilen=null;
            ikinciSecilen=null;

            oyunBitirmeKontrolu();
        }
        private void oyunBitirmeKontrolu()
        {
            foreach(Control kontrol in tableLayoutPanel1.Controls)
            {
                if(kontrol is Button && kontrol.Enabled)
                {
                    return;
                }
            }
            MessageBox.Show("Tebrikler tüm eşleşmeler doğru! :) ");
        }
    }
}
