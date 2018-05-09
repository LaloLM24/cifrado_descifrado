using System;
using System.Collections.Generic;
using System.Text;

namespace cifrado_descifrado
{
    class principal
    {
        public principal()
        {
        }

        public void cifrar(String mensaje, String llave)
        {
            cifrado cifrarMensaje = new cifrado(mensaje, llave); 
            cifrarMensaje.cifrar();
        }

        public void descifrar(String mensaje, String llave)
        {
            descifrado descifrarMensaje = new descifrado(mensaje, llave);
            descifrarMensaje.descifrar();

        }
    }        
}
