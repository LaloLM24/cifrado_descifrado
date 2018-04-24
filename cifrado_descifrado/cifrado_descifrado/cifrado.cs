using System;
using System.Collections.Generic;
using System.Text;

namespace cifrado_descifrado
{
    class cifrado
    {
        private String mensaje;
        private String llave;
        private int longitudMensaje;
        private int longitudLlave;
        private int tamanioBloque ;
        private char[,] matrizMensaje;
        private char[,] matrizLlave;
        private char[,] mensajeInvertido;
        private String MensajeCifrado;

        public cifrado(String mensaje, String llave)
        {
            this.mensaje = mensaje;
            this.llave = llave;
        }

        public void cifrar()
        {
            longitudMensaje = calcularLongitud(mensaje);
            longitudLlave = calcularLongitud(llave);
            tamanioBloque = tamBloque(longitudMensaje, longitudLlave);
            matrizMensaje = matriz(mensaje, tamanioBloque);
            matrizLlave = matriz(llave, tamanioBloque);
            mensajeInvertido = invertirMensaje(matrizMensaje, tamanioBloque);
            MensajeCifrado = XOR(mensajeInvertido, matrizLlave, tamanioBloque);
        }

        public int calcularLongitud(String texto)
        {
            
            int longitud = 0;
            longitud = texto.Length;
            return longitud;
        }


        public int tamBloque(int longMensaje, int longLlave)
        {
            int tamaBloque = 0;
            double raizDecimal = 0.0;
            int raizEntera = 0;
            bool comprobacion = false;

            if (longMensaje >= longLlave)
            {
                do
                {
                    raizDecimal = Math.Sqrt(longMensaje);
                    raizEntera = (int)Math.Sqrt(longMensaje);
                    if (raizDecimal != raizEntera)
                    {
                        longMensaje++;
                    }
                    else
                    {
                        comprobacion = true;
                    }

                }
                while (comprobacion == false);
                tamaBloque = raizEntera;
                return tamaBloque;
            }

            else
            {
                do
                {
                    raizDecimal = Math.Sqrt(longLlave);
                    raizEntera = (int)Math.Sqrt(longLlave);
                    if (raizDecimal>raizEntera)
                    {
                        longLlave++;
                    }
                    else
                    {
                        comprobacion = true;
                    }

                }
                while (comprobacion == false);

                tamaBloque = raizEntera;
                return tamaBloque;
            }
        }

        public char[,] matriz(String texto, int tamaBloque)
        {
            int tamanioMatriz = tamaBloque * tamaBloque;
            int contador = 0;
            bool comprobador = false;
            char[,] matrizResultado = new char[tamaBloque,tamaBloque];

            do
            {
                if (texto.Length < tamanioMatriz)
                {
                    texto = texto + '\u0000';
                }
                else comprobador = true;

            } while (comprobador == false);

            for(int a = 0; a < tamaBloque; a++)
            {
                for(int b = 0; b < tamaBloque; b++)
                {
                    matrizResultado[a, b] = texto[contador];
                    contador++;
                }
            }

            return matrizResultado;
        }


        public char[,] invertirMensaje(char [,] matriz, int tamaBloque)
        {
            int tamBloqueTemp = tamaBloque - 1;
            int c = tamBloqueTemp;
            char[,] mensajeInvertido = new char[tamaBloque,tamaBloque];

            for (int a = 0; a < tamaBloque; a++)
            {
                for (int b = 0; b < tamaBloque; b++)
                {
                    mensajeInvertido[a, b] = matriz[a,c];
                    c--;
                }
                c = tamBloqueTemp;
            }

            return mensajeInvertido;
        }
        public String XOR(char[,] mensaje, char[,] llave, int tamanioBloque)
        {
            String mensajeCifrado = "";
            String[,] cadenaString = new string[tamanioBloque, tamanioBloque];
            int[,] cadena = new int[tamanioBloque, tamanioBloque];
            bool comprobador = false;
            
            for (int a = 0; a < tamanioBloque; a++)
            {
                for (int b = 0; b < tamanioBloque; b++)
                {
                    cadena[a, b] = mensaje[a, b] ^ llave[a, b] + llave[a,b];
                    cadenaString[a, b] = cadena[a, b].ToString();
                    do
                    {
                        if (cadenaString[a,b].Length < 3)
                        {
                            cadenaString[a, b] = '0' + cadenaString[a, b];
                        }
                        else
                        {
                            comprobador = true;
                        }

                    } while (comprobador==false);

                    mensajeCifrado = mensajeCifrado + cadenaString[a, b];
                }
            }
            Console.WriteLine("El Mensaje cifrado es:    "  + mensajeCifrado);
            return mensajeCifrado;
        }

    }
}
