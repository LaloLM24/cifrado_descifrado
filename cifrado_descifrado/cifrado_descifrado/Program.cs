using System;

namespace cifrado_descifrado
{
    class Program
    {
        static void Main(string[] args)
        {
            principal cifrar = new principal();
            cifrar.cifrar("mensaje", "llave");

            Console.ReadKey();
        }
    }
}
