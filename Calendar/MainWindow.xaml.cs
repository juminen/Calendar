using System;
using System.Globalization;
using System.Text;
using System.Windows;

namespace Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox_Vuosi_Alku.Text = DateTime.Now.Year.ToString();
            TextBox_Vuosi_Loppu.Text = DateTime.Now.Year.ToString();
        }

        private void Button_Tee_Rivit_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox_Tiedot.Document.Blocks.Clear();
            int startYear;
            int endYear;

            if (TextBox_Vuosi_Alku.Text.Length == 0 ||
                TextBox_Vuosi_Loppu.Text.Length == 0)
            {
                RichTextBox_Tiedot.AppendText("Syöte alku- tai loppuvuosi ei saa olla tyhjä.");
                return;
            }

            if (!int.TryParse(TextBox_Vuosi_Alku.Text, out startYear))
            {
                string msg = string.Format("Syöte '{0}' (alkuvuosi) ei ollut luku.", TextBox_Vuosi_Alku.Text);
                RichTextBox_Tiedot.AppendText(msg);
                return;
            }

            if (!int.TryParse(TextBox_Vuosi_Loppu.Text, out endYear))
            {
                string msg = string.Format("Syöte '{0}' (loppuvuosi) ei ollut luku.", TextBox_Vuosi_Loppu.Text);
                RichTextBox_Tiedot.AppendText(msg);
                return;
            }

            if (startYear > endYear)
            {
                string msg = string.Format("Alkuvuoden ({0}) pitää olla pienempi kuin loppuvuosi ({1}).",
                    TextBox_Vuosi_Alku.Text, TextBox_Vuosi_Loppu.Text);
                RichTextBox_Tiedot.AppendText(msg);
                return;
            }


            string info = CreateCalendar(startYear, endYear);
            RichTextBox_Tiedot.AppendText(info);
            Clipboard.SetText(info);
        }

        private string CreateCalendar(int startYear, int endYear)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Päivämäärä");
            sb.Append("\tViikonpäivän numero");
            sb.Append("\tViikonpäivä");
            sb.Append("\tPäivä");
            sb.Append("\tKuukausi");
            sb.Append("\tKuukausi (teksti)");
            sb.Append("\tVuosi");
            sb.Append("\tViikkonumero");
            sb.Append("\tTuntilapun viikkonumero (viikko)");
            sb.Append("\tTuntilapun viikkonumero (kuukausivaihde)");
            sb.Append("\tPäivämäärän huomautus");
            sb.Append("\tArki/viikonloppu");
            sb.Append("\tTyö-/vapaapäivä");
            sb.AppendLine("\tNormaalit työtunnit päivässä");

            for (int i = startYear; i < endYear + 1; i++)
            {
                Year y = new Year(i);
                foreach (Day d in y.GetDaysInOrder())
                {
                    sb.Append(d.Date.ToString("dd.MM.yyyy"));
                    sb.Append("\t" + d.WeekDayNumber);
                    sb.Append("\t" + d.LocalName);
                    sb.Append("\t" + d.Date.Day);
                    sb.Append("\t" + d.Date.Month);
                    sb.Append("\t" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Date.Month));
                    sb.Append("\t" + d.Date.Year);
                    sb.Append("\t" + d.Iso8601WeekOfYear);
                    sb.Append("\t" + d.Iso8601WeekOfYearWithYear);
                    sb.Append("\t" + d.Iso8601WeekOfYearWithYear + d.GetWeekNumberPart());
                    sb.Append("\t" + d.WorkingDayDescription);
                    if (d.WeekDay)
                    {
                        sb.Append("\tarki");
                    }
                    else
                    {
                        sb.Append("\tviikonloppu");
                    }
                    if (d.IsWorkingDay)
                    {
                        sb.Append("\ttyöpäivä");
                        sb.AppendLine("\t8,0");
                    }
                    else
                    {
                        sb.Append("\tvapaapäivä");
                        sb.AppendLine("\t0,0");
                    }

                }
            }
            return sb.ToString();
        }

        //private void Button_Testi_Click(object sender, RoutedEventArgs e)
        //{
        //    RichTextBox_Tiedot.Document.Blocks.Clear();
        //    Day day = new Day(new DateTime(2017, 1, 1));
        //    string info = "Iso8601WeekOfYear:" + day.Iso8601WeekOfYear.ToString();
        //    RichTextBox_Tiedot.AppendText(info);
        //}
    }
}
