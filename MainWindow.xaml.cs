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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender; // μετατρέπει τον sender σε button για να μπορει να εχει προσβαση
            tb.Text += button.Content.ToString(); // παιρνει το περιεχομενο του πεδιου που πληκτρολογει ο χρηστης
        }

        private void Result_click(object sender, RoutedEventArgs e)
        {
            try
            {
                result(); // καλει την συναρτηση για να δειξει το αποτελεσμα 
            }
            catch (Exception exc)
            {
                tb.Text = "Error!"; //σε περιπτωση λαθους να μην κλεισει η εφαρμογη αλλα να βγαλει ενα μηνυμα ερρορ
            }
        }

        private void result()
        {
            int iOp = 0;// το index για την θεση που βρισκεται ο τελεστης

            // ελεγχει καθ4ε πιθανη πραξη για τον τελεστη και τον καταχωρει 
            if (tb.Text.Contains("+"))
            {
                iOp = tb.Text.IndexOf("+");
            }
            else if (tb.Text.Contains("-"))
            {
                iOp = tb.Text.IndexOf("-");
            }
            else if (tb.Text.Contains("/"))
            {
                iOp = tb.Text.IndexOf("/");
            }
            else if (tb.Text.Contains("*"))
            {
                iOp = tb.Text.IndexOf("*");
            }
            else
            {
                Console.WriteLine("Error!");
            }

            string op = tb.Text.Substring(iOp, 1); // εξαγει τον τελεστη απο τον iOp και επειδη ειναι μονο ενας τελεστης μπαινει το 1  ως αριθμος
            double num1 = Convert.ToDouble(tb.Text.Substring(0, iOp)); //κανει εξαγωγη του πρωτου αριθμου που ειναι ΠΡΙΝ απο τον τελεστη
                                                                      //και τον κανει double για να ειναι πιο ευκολο το αποτελεσμα 
            double num2 = Convert.ToDouble(tb.Text.Substring(iOp + 1, tb.Text.Length - iOp - 1));  // παιρνει τον αριθμο μετα τον τελεστη αρα τον αμεσως επομενο για αυτο και iOp + 1
                                                                                                  // και το υπολοιπο κομματι υπολογιζει το μηκος του string

            // εκτελει για καθε εναν τελεστη την αντιστοιχη πραξη με την δυνατοτητα να μπορει το αποτελεσμα να το παραμετροποιησει αργοτερα 
            // μπηκε μονο το '=' αντι για += για να εμφανιζει μονο το αποτελεσμα της πραξης και οχι και τα νουμερα και τον τελεστη
            switch (op) 
           {
                case "+" : 
                    tb.Text = (num1 + num2).ToString();
                    break;
                case "-" : 
                    tb.Text = (num1 - num2).ToString();
                    break;
                case "/":
                    tb.Text = (num1 / num2).ToString();
                    break;
                case "*":
                    tb.Text = (num1 * num2).ToString();
                    break;
                default:
                    tb.Text = "Error! Unknown operator.";
                    break;
            } 


        }
        
        //για να γινει πληρες εκκαθαριση του πεδιου 
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            tb.Text = "";
        }


        //γινεται η αναιρεση του ενος αριθμου που εγραψε ο χρηστης και ηθελε να διαγραψει
        private void BackClick(object sender, RoutedEventArgs e)
        {
            if(tb.Text.Length > 0)
            {
                // εδω αναφερει οτι παιρνει νεα τιμη απο την αρχη των αριθμων που ορισε ο χρηστης μεχρι και το τελος
                // και αφαιρει 1 νουμερο την φορα για αυτο και το  tb.Text.Length - 1
                tb.Text = tb.Text.Substring(0, tb.Text.Length - 1); 
            }
        }
        private void CloseAppClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
