using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Ejercicio2_CalculosMatematicos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            botonCalcular.IsEnabled = false;
        }
        
        private void BotonCalcular_Click(object sender, RoutedEventArgs e)
        {
            int resultado;
            try
            {
                if (operadorTextBox.Text == "-")
                    resultado = int.Parse(operador1TextBox.Text) - int.Parse(operador2TextBox.Text);
                else if (operadorTextBox.Text == "+")
                    resultado = int.Parse(operador1TextBox.Text) + int.Parse(operador2TextBox.Text);
                else if (operadorTextBox.Text == "*")
                    resultado = int.Parse(operador1TextBox.Text) * int.Parse(operador2TextBox.Text);
                else
                    resultado = int.Parse(operador1TextBox.Text) / int.Parse(operador2TextBox.Text);

                resultadoTextBox.Text = resultado.ToString();
            }
            catch (FormatException) {

                MessageBox.Show("Se ha producido un error. Revise los operandos.");
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message);
            }
        }

        private void BotonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            operador1TextBox.Text = "";
            operador2TextBox.Text = "";
            operadorTextBox.Text = "";
            resultadoTextBox.Text = "";
        }

        private void OperadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string operadorIntroducido = operadorTextBox.Text;
            Regex patron = new Regex(@"[-+*/]");
            Match coincidencia = patron.Match(operadorIntroducido);
            if (coincidencia.Success)
                botonCalcular.IsEnabled = true;
            else
                botonCalcular.IsEnabled = false;
        }
    }
}
