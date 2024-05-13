namespace TP3_Tiquetera_Solmesky_Huberman;

class Program
{
    static void Main(string[] args)
    {
        int opciones; 
        do
        {
            Console.WriteLine("A que opcion desea entrar: ");
            Console.WriteLine("Opcion 1: Nueva Inscripción: ");
            Console.WriteLine("Opcion 2: Obtener Estadísticas del Evento: ");
            Console.WriteLine("Opcion 3: Buscar Cliente: ");
            Console.WriteLine("Opcion 4: Cambiar entrada de un Cliente: ");
            Console.WriteLine("Opcion 5: Salir");
            opciones = int.Parse(Console.ReadLine());
            switch (opciones)
            {
                case 1:
                opcion1();
                break;
                case 2:
                opcion2();
                break;
                case 3:
                opcion3();
                break;
                case 4:
                opcion4();
                break;
            }
        }while (opciones != 5);
    }
    static void opcion1()
    {
        int DNI = Funciones.IngresarInt("Ingrese su dni: ");
        string Apellido = Funciones.IngresarString("Ingrese su apellido: ");
        string Nombre = Funciones.IngresarString("Ingrese su nombre: ");
        DateTime FechaInscripcion = Funciones.IngresarFecha("Ingrese su fecha de inscripcion:");
        int TipoEntrada = Funciones.ValidarTipoDeEntrada("Ingrese el tipo de entrada: ");
        int Cantidad = Funciones.IngresarInt("Ingrese la cantidad de entradas: ");
        Cliente nuevoCliente = new Cliente (DNI, Apellido , Nombre , FechaInscripcion ,TipoEntrada,Cantidad);
        Tiquetera.AgregarCliente(nuevoCliente);
    }
    static void opcion2()
    {
        List<double> lista = new List<double>();
        lista = Tiquetera.EstadisticasTicketera();
        if(lista.Count>1)
        {
            Console.WriteLine("el porcentaje de las entradas de tipo 1 es de: " + lista[5] + "%" + " y la recaudaciuon de plata de este tipo es de: " + lista[0]);
            Console.WriteLine("el porcentaje de las entradas de tipo 2 es de: " + lista[6] + "%" + " y la recaudaciuon de plata de este tipo es de: " + lista[1]);
            Console.WriteLine("el porcentaje de las entradas de tipo 3 es de: " + lista[7] + "%" + " y la recaudaciuon de plata de este tipo es de: " + lista[2]);
            Console.WriteLine("el porcentaje de las entradas de tipo 4 es de: " + lista[8] + "%" + " y la recaudaciuon de plata de este tipo es de: " + lista[3]);
            Console.WriteLine("la recaudacion total es: " + lista[4]);
        }
        else{
            Console.WriteLine("Aún no se anotó nadie");
        }
    }
    static void opcion3()
    {
        int idEntrada;
        Console.WriteLine("Ingrese el id de entrada que quiera buscar:  ");
        idEntrada= int.Parse(Console.ReadLine());
        Cliente ClienteBuscado = Tiquetera.BuscarCliente(idEntrada);
        if (ClienteBuscado == null)
        {
            Console.WriteLine("No esta");
        }
        else{
            Console.WriteLine("El dni es: " + ClienteBuscado.DNI + "\n el apellido es: " + ClienteBuscado.Apellido + "\n el nombre es: " + ClienteBuscado.Nombre + "\n la fecha de nscripcion es: " + ClienteBuscado.FechaInscripcion + "\n el tipo de entrada es: " + ClienteBuscado.TipoEntrada + "\n el total abonado es: " + (ClienteBuscado.Cantidad * ClienteBuscado.TipoEntrada));
        }
    }
    static void opcion4()
    {
        const int OPCION1 =45000, OPCION2 =60000,OPCION3 =30000,OPCION4 =100000;
        int idEnt, cambiarEntrada, precioEntrada,precioCambio;
        Console.WriteLine("Ingrese el id de entrada para cambiar su tipo de entrada: ");
        idEnt = int.Parse(Console.ReadLine());
        Cliente ClienteBuscado = Tiquetera.BuscarCliente(idEnt);
        if (ClienteBuscado == null)
        {
            Console.WriteLine("No esta");
        }
        else
        {
            precioEntrada = ClienteBuscado.TipoEntrada * ClienteBuscado.Cantidad;
            cambiarEntrada = Funciones.ValidarTipoDeEntrada("Ingrese a que tipo de entrada desea cambiar: ");
            int Cantidad = Funciones.IngresarInt("Ingrese la cantidad de entradas: ");
            precioCambio = Funciones.TipoEntrada(OPCION1,OPCION2,OPCION3,OPCION4, cambiarEntrada);
            Tiquetera.CambiarEntrada(idEnt, cambiarEntrada, Cantidad, precioEntrada, precioCambio);
        }  
    }
}
