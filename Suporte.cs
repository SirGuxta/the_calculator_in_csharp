namespace calculator;

static class Suporte
{

    public static bool VerificarPresencaString(string Entrada)
    {

        string[] numeros = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", "*", "/", ",", ".", " "};

        int tamanho = Entrada.Length;
        int contador = 0;

        while (contador < tamanho - 1)
        {
            foreach (string numero in numeros)
            {
                if (Entrada[contador].ToString() == numero)
                {
                    break;
                }
                else if (numero == " ")
                {
                    return false;
                }
            }

            contador++;
        } 

        return true;
    }

    public static string TratarEntrada(string entrada)
    {
        int tamanho = entrada.Length;
        string retorno = "";

        string[] tiposInvalidos = { ",", " " };

        int contador = 0;

        while (contador < tamanho)
        {
            if (entrada[contador].ToString() == ",")
            {
                retorno += ".";    
            }
            else if (entrada[contador].ToString() == " ")
            {
                retorno += "";
            }
            else
            {
                retorno += entrada[contador];
            }
            contador++;
        }

        return retorno;
    }
}
