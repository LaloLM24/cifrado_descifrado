using System;

namespace cifrado_descifrado
{
    class Program
    {
        static void Main(string[] args)
        {
            principal cifrar = new principal();
            cifrar.cifrar("mensaje", "llave");

            principal descifrar = new principal();
            descifrar.descifrar("002009012028004115000000101", "llave");

            Console.ReadKey();
        }
    }
}
