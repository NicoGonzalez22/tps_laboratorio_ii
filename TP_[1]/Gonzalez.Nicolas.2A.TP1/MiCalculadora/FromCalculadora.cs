using Entidades;
using System;
using System.Text;
using System.Windows.Forms;
namespace MiCalculadora
{
    public partial class FromCalculadora : Form
    {

        /// <summary>
        /// Agrega los items del ComboBox
        /// </summary>
        public FromCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add(' ');
            this.cmbOperador.Items.Add('+');
            this.cmbOperador.Items.Add('/');
            this.cmbOperador.Items.Add('*');
            EsBinarioODecimal();
        }

        /// <summary>
        /// Limpia todos los datos de la calculadora
        /// </summary>
        private void Limpiar()
        {
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = " ";
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lstOperaciones.Items.Clear();
        }


        /// <summary>
        /// Establece los botones de conversion segun los datos hasta el momento
        /// </summary>
        private void EsBinarioODecimal()
        {
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Reaaliza la operacion correspondiente segun el operador recibido por parametro
        /// </summary>
        /// <param name="numero1">numero 2</param>
        /// <param name="numero2">numero 1</param>
        /// <param name="operador">Operador recibido</param>
        /// <returns>retorna el resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            Char.TryParse(operador, out char operando);
            return Calculadora.Operar(num1, num2, operando);

        }
        /// <summary>
        /// Realiza la operacion correspondiente y valida que los operando no sean NULL y que no se pueda dividir por 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder resultado = new StringBuilder();
            int.TryParse(txtNumero2.Text, out int esCero);
            if (txtNumero1.Text == string.Empty || txtNumero2.Text == string.Empty)
            {
                lblResultado.Text = "Operacion no valida";
            }
            else
            {
                if (esCero == 0 && cmbOperador.Text == "/")
                {
                    lblResultado.Text = "No es posible dividir por 0";
                }
                else
                {
                    if (cmbOperador.SelectedIndex == -1 || cmbOperador.SelectedIndex == 0)
                        cmbOperador.Text = "+";
                    txtNumero1.Text = txtNumero1.Text.Replace('.', ',');
                    txtNumero2.Text = txtNumero2.Text.Replace('.', ',');
                    lblResultado.Text = FromCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                    resultado.AppendLine($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
                    lstOperaciones.Items.Add(resultado.ToString());
                    EsBinarioODecimal();
                }
            }


        }

        /// <summary>
        /// Limpia los datos de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FromCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Convierte el resultado obtenido Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (String.Compare("Valor invalido", lblResultado.Text.ToString()) != 0 && String.Compare("No es posible dividir por 0", lblResultado.Text.ToString()) != 0)
            {
                StringBuilder resultadoBinario = new StringBuilder();
                Operando resultado = new Operando();
                resultadoBinario.AppendLine($"{lblResultado.Text} = {resultado.BinarioDecimal(lblResultado.Text)}");
                lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text);
                lstOperaciones.Items.Add(resultadoBinario.ToString());
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }

        }

        /// <summary>
        /// Convierte el resultado obtenido Decimal a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (String.Compare("Valor invalido", lblResultado.Text.ToString()) != 0 && String.Compare("No es posible dividir por 0", lblResultado.Text.ToString()) != 0)
            {
                StringBuilder resultadoBinario = new StringBuilder();
                Operando resultado = new Operando();
                resultadoBinario.AppendLine($"{lblResultado.Text} = {resultado.DecimalBinario(lblResultado.Text)}");
                lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);
                lstOperaciones.Items.Add(resultadoBinario.ToString());
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Limpia todos los datos de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        /// <summary>
        /// Cierra la aplicacion dando un mensaje preguntando si esta seguro de salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Cierra la aplicacion dando un mensaje preguntando si esta seguro de salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FromCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}

