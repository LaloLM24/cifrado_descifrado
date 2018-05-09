using System;
using System.Collections.Generic;
using System.Text;

namespace cifrado_descifrado
{
    class descifrado
    {
        private String cifrado;
        private String llave;
        private int tamaBloque;
        private int[,] mensajeBloques;
        private char[,] llaveCifrado;
        private String [,] mensajeDecifrado;
        private String ordenado; 

        public descifrado(String cifrado, String llave)
        {
            this.cifrado = cifrado;
            this.llave = llave;
        }

        public void descifrar()
        {
            tamaBloque = tamanioBloque(cifrado);
            mensajeBloques = mensaajeCifradoEnBloques(cifrado, tamaBloque);
            llaveCifrado = llaveEnBloques(llave, tamaBloque);
            mensajeDecifrado = funcionDescifrar(mensajeBloques, llaveCifrado, tamaBloque);
            ordenado = ordenamiento(mensajeDecifrado);
        }

        public int tamanioBloque(String texto)
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

        public int[,] mensaajeCifradoEnBloques(String texto, int tamanioBloque)
        {
            int[,] textoEnBloque = new int[tamanioBloque, tamanioBloque];
            int contador1 = 0;
            int contador2 = 3;

            for (int a = 0; a < tamanioBloque; a++)
            {
                for (int b = 0; b < tamanioBloque; b++)
                {
                    textoEnBloque[a, b] = Int32.Parse(texto.Substring(contador1, contador2));
                    contador1 = contador1 + 3;
                    //contador2 = contador2 + 3;
                }
            }

            return textoEnBloque;
        }

        public char[,] llaveEnBloques(String llave, int tamanioBloque)
        {
            int tamaTotal = tamanioBloque * tamanioBloque;
            char [,] llaveBloque = new char[tamanioBloque,tamanioBloque];
            int contador = 0;
            bool comprobador = false;
            do
            {
                if (tamaTotal > llave.Length)
                {
                    llave = llave + '\u0000';
                }
                else
                {
                    comprobador = true;
                }
            } while (comprobador == false);

            for (int a = 0; a < tamanioBloque; a++)
            {
                for (int b = 0; b < tamanioBloque; b++)
                {
                    llaveBloque[a, b] = llave[contador];
                    contador++;
                }
            }

            return llaveBloque;
        }

        public String [, ]funcionDescifrar(int[,] mensaje, char[,] llave, int tamanioBloque)
        {
            String [,] mensajeDescifrado = new String[tamanioBloque,tamanioBloque];
            int[,] resultado = new int[tamanioBloque,tamanioBloque];
            char[,]caracteresResultado = new char[tamanioBloque,tamanioBloque];

            for (int a = 0; a < tamanioBloque; a++)
            {
                for (int b = 0; b < tamanioBloque; b++)
                {
                    resultado[a, b] = mensaje[a, b]  ^ llave[a, b];
                    caracteresResultado[a, b] = Convert.ToChar(resultado[a, b]);
                    mensajeDescifrado[a,b] = mensajeDescifrado[a,b] + caracteresResultado[a, b];
                }
            }
            return mensajeDescifrado;
        }

        public String ordenamiento(String[,] mensajeDescifrado)
        {
            int tamaBloque = this.tamaBloque;
            String ordenado = "";
            int temporal = 2;
            String[,] final = new String[tamaBloque,tamaBloque];
            for (int a = 0; a <tamaBloque; a++)
            {
                for (int b = 0; b < tamaBloque; b++)
                {
                    final[a, b] = mensajeDescifrado[a, temporal];
                    temporal--;
                    ordenado = ordenado + final[a, b];
                }
                temporal = 2;
            }
            Console.WriteLine("El Mensaje Descifrado es: " + ordenado);
            return ordenado;
        }
    }
}
