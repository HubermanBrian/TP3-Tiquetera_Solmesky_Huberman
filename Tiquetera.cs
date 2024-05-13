public static class Tiquetera
{
    private static Dictionary<int, Cliente> dicClientes = new Dictionary<int, Cliente>();

    public static int UltimoIDEntrada = 0;
    public static int DevolverUltimoId()
    {
        return UltimoIDEntrada;
    }
    public static int AgregarCliente(Cliente nuevoCliente)
    {
        UltimoIDEntrada++;
        dicClientes.Add(UltimoIDEntrada, nuevoCliente);
        return UltimoIDEntrada;
    }
    public static Cliente BuscarCliente(int idEntrada)
    {
        Cliente clienteVacio = null;
        if (dicClientes.ContainsKey(idEntrada))
        {
            clienteVacio = dicClientes[idEntrada];
        }

        return clienteVacio;
    }
    public static bool CambiarEntrada(int idEnt, int cambiarEntradaa, int cantidad, double precioEntrada, double cambioPrecio )
    {        
        bool aceptar = false;
        if(dicClientes.ContainsKey(idEnt))
        {
            if(cambioPrecio * cantidad > precioEntrada *dicClientes[idEnt].Cantidad)
            {
                dicClientes[idEnt].TipoEntrada = cambiarEntradaa;
                dicClientes[idEnt].Cantidad = cantidad; 
                Console.WriteLine($"Se cambio el tipo de entrada a {cambiarEntradaa} y se compraron {cantidad}");
                aceptar = true;
            }
            else
            {
                Console.WriteLine($"No se logró hacer el cambio");
            }
        }
        
        return aceptar;
    }
    public static List<double> EstadisticasTicketera()
    {
        List<double> lista = new List<double>();
        int CantidadDeClientesInscriptos = dicClientes.Count();
        
        Console.WriteLine("El total de personas inscriptas son: " + CantidadDeClientesInscriptos);
        if (CantidadDeClientesInscriptos > 0)
        {
            int totalEntradas = 0;
            int cant1 = 0, cant2 = 0, cant3 = 0, cant4 = 0;
            int plata1 = 0, plata2 = 0, plata3 = 0, plata4 = 0;
            foreach (Cliente a in dicClientes.Values)
            {
                totalEntradas += a.Cantidad;
                switch (a.TipoEntrada)
                {
                    case 1:
                        cant1 += a.Cantidad;
                        plata1 += a.Cantidad * 45000;
                        break;
                    case 2:
                        cant2 += a.Cantidad;
                        plata2 += a.Cantidad * 60000;
                        break;
                    case 3:
                        cant3 += a.Cantidad;
                        plata3 += a.Cantidad * 30000;
                        break;
                    case 4:
                        cant4 += a.Cantidad;
                        plata4 += a.Cantidad * 100000;
                        break;
                }
            }
            double porcentaje1 = (cant1 * 100 / totalEntradas);
            double porcentaje2 = (cant2 * 100 / totalEntradas);
            double porcentaje3 = (cant3 * 100 / totalEntradas);
            double porcentaje4 = (cant4 * 100 / totalEntradas);
            int recaudacionTotal = plata1 + plata2 + plata3 + plata4;

           lista.Add (plata1);
           lista.Add (plata2);
           lista.Add (plata3);
           lista.Add (plata4);
           lista.Add (recaudacionTotal);
           lista.Add (porcentaje1 = (cant1*100/CantidadDeClientesInscriptos));
           lista.Add (porcentaje2 = (cant2*100/CantidadDeClientesInscriptos));
           lista.Add (porcentaje3 = (cant3*100/CantidadDeClientesInscriptos));
           lista.Add (porcentaje4 = (cant4*100/CantidadDeClientesInscriptos));
        }
        return lista;
    }
         
      
}