namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida el operador recibido por parametro, en caso de no cumplir con los operadores deseados se definira el operador '+'
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador validado</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '*' && operador != '/' && operador != '-')
                operador = '+';

            return operador;
        }

        /// <summary>
        /// Realiza la operacion segun el operador recibido por parametro
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de la operacion correspondiente</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado=0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado= num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }

    }
}
