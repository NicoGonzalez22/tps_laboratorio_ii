using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }
        /// <summary>
        /// sobrecarga del constructor pero recibe por parametro un double
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero) : this()
        {
            this.numero = numero;
        }
        /// <summary>
        /// sobrecarga del constructor pero recibe por parametro un string
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero) : this()
        {
            this.numero = ValidarOperando(strNumero);
        }

        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        /// <summary>
        /// Convierte un valor Binario a decimal
        /// </summary>
        /// <param name="Binario"> valor en Binario </param>
        /// <returns>retorna el valor Decimal, en caso de que los valores del parametro sean invalido, retornará "Valor invalido" </returns>
        public string BinarioDecimal(string Binario)
        {
            double total = 0;
            int exponente = Binario.Length;
            if (Binario is not null && EsBinario(Binario))
            {
                for (int i = 0; i < Binario.Length; i++)
                {
                    if (Binario[i] == '1')
                    {
                        total = total + (1 * Math.Pow(2, exponente - 1));
                    }
                    exponente--;
                }
                return total.ToString();
            }
            return "Valor invalido";

        }

        /// <summary>
        /// Valida que el parametro recibido no sea null e intenta parsearlo, en caso de poder parsear retorna el numero caso contrario retorna 0
        /// </summary>
        /// <param name="strNumero">Numero recibido </param>
        /// <returns>Retorna el numero parseado, en caso de no poder parsearlo o que sea null el parametro retorna 0</returns>
        private double ValidarOperando(string strNumero)
        {
            if (strNumero is not null && Double.TryParse(strNumero, out this.numero))
            {
                return this.numero;
            }
            return 0;
        }
        /// <summary>
        /// Verifica que el valor recibido sea Binario
        /// </summary>
        /// <param name="Binario"> Valor Binario recibido </param>
        /// <returns>Retorta true en caso de que sea un valor Binario o false en caso de que no lo sea</returns>
        public static bool EsBinario(string Binario)
        {
            for (int i = 0; i < Binario.Length; i++)
            {
                if (Binario[i] != '1' && Binario[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Convierte el valor Decimal recibido en Binario, En caso de que no pueda ser Parseado o sea null retorna "Valor invalido"
        /// </summary>
        /// <param name="numero">Valor decimal recibido </param>
        /// <returns>Retorna el valor del numero en Binario, o "Valor invalido" en caso de recibir un parametro invalido</returns>
        public string DecimalBinario(string numero)
        {
            double binario;
            bool esNumero = Double.TryParse(numero, out binario);
            int resto;
            string retorno = string.Empty;
            if (numero is null || !esNumero)
                return "Valor invalido";

            while (binario >= 1)
            {
                resto = (int)binario % 2;
                binario = (int)binario / 2;
                retorno = resto.ToString() + retorno;
            }
            return retorno;
        }

        /// <summary>
        /// Convierte el valor Decimal recibido en Binario, en caso de recibir un valor negativo, Trabajará con su valor positivo y se quedara con 
        /// su valor absoluto
        /// </summary>
        /// <param name="numero"> Valor decimal recibido </param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {

            if (numero >= 0)
            {
                return DecimalBinario(numero.ToString());
            }
            else
            {
                numero = numero * -1;

                return DecimalBinario(numero.ToString());
            }
        }


        /// <summary>
        ///  Sobrecarca del operador '+' permite realizar la suma del atributo del objeto "Operando"
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>retorna el resultado de la suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        ///  Sobrecarca del operador '-' permite realizar la resta del atributo del objeto "Operando"
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>retorna el resultado de la resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        ///  Sobrecarca del operador '*' permite realizar la multiplicacion del atributo del objeto "Operando"
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>retorna el resultado de la multiplicacion</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        ///  Sobrecarca del operador '/' permite realizar la division del atributo del objeto "Operando"
        /// </summary>
        /// <param name="n1">Numero 1</param>
        /// <param name="n2">Numero 2</param>
        /// <returns>retorna el resultado de la division</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            return n1.numero / n2.numero;
        }




    }
}
