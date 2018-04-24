using System;
using System.Collections.Generic;
using System.Text;

namespace cifrado_descifrado
{
    class descifrado
    {
        private String cifrado;
        private String llave;

        public descifrado(String cifrado, String llave)
        {
            this.cifrado = cifrado;
            this.llave = llave;
        }

        public int  tamanioBloque(String texto)
        {

            int tamanioTexto = texto.Length / 3;
            int raizEntera = 0;
            double raizDecimal = 0.0;
            bool comprobador = false;

            do
            {
                raizEntera = (int)Math.Sqrt(tamanioTexto);
                raizDecimal = Math.Sqrt(tamanioTexto);

                if (raizDecimal != raizEntera)
                {
                    tamanioTexto++;

                }
                else
                {
                    comprobador = true;
                }
            } while (comprobador == false);

            return raizEntera;
        }

        public String[,] textoBloques(String texto, int tamanioBloque)
        {
            String [,] textoEnBloque = new String[tamanioBloque,tamanioBloque];
            int contador1 = 0;
            int contador2 = 2;

            for (int a = 0; a < tamanioBloque; a++)
            {
                for (int b = 0; b < tamanioBloque; b++)
                {
                    textoEnBloque[tamanioBloque, tamanioBloque] = texto.Substring(contador1, contador2);
                    contador1 = contador1 + 3;
                    contador2 = contador2 + 3;
                }
            }

            return textoEnBloque;
        }

    }
}
