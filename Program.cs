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
        const int OPCION1 =45000, OPCION2 =60000,OPCION3 =30000,OPCION4 =100000;
        int DNI = Funciones.IngresarInt("Ingrese su dni: ");
        string Apellido = Funciones.IngresarString("Ingrese su apellido: ");
        string Nombre = Funciones.IngresarString("Ingrese su nombre: ");
        DateTime FechaInscripcion = Funciones.IngresarFecha("Ingrese su fecha de inscripcion:");
        int TipoEntrada = Funciones.ValidarTipoDeEntrada("Ingrese el tipo de entrada: ");
        int precioEntrada = Funciones.TipoEntrada(OPCION1, OPCION2, OPCION3, OPCION4, TipoEntrada);
        int Cantidad = Funciones.IngresarInt("Ingrese la cantidad de entradas: ");
        Cliente nuevoCliente = new Cliente (DNI, Apellido , Nombre , FechaInscripcion ,TipoEntrada,Cantidad);
        Tiquetera.AgregarCliente(nuevoCliente);
    }
    static void opcion2()
    {
        List<string> listaRespuesta = new List<string>();
        listaRespuesta = Tiquetera.EstadisticasTicketera();
        foreach (string str in listaRespuesta)
        {
            Console.WriteLine(str);
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
        int idEnt, cambiarEntrada;
        Console.WriteLine("Ingrese el id de entrada para cambiar su tipo de entrada: ");
        idEnt = int.Parse(Console.ReadLine());
        Cliente ClienteBuscado = Tiquetera.BuscarCliente(idEnt);
        if (ClienteBuscado == null)
        {
            Console.WriteLine("No esta");
        }
        else
        {
            Console.WriteLine("Ingrese a que tipo de entrada desea cambiar: ");
            cambiarEntrada = int.Parse(Console.ReadLine());
            int Cantidad = Funciones.IngresarInt("Ingrese la cantidad de entradas: ");
            Tiquetera.CambiarEntrada(idEnt, cambiarEntrada, Cantidad);
        }
        
    }
}
