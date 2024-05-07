public static class Funciones
{
    public static string IngresarString(string m)    
    {
        string r;

        do
        {
            Console.Write(m);
            r = Console.ReadLine();
        }while (r== string.Empty);
        return r;
    }
    public static int IngresarInt(string m)
    {
        int r;
        do
        {
        Console.WriteLine(m);
        r= int.Parse(Console.ReadLine());
        }while(r<0);
        return r;
    }
    public static int ValidarTipoDeEntrada(string m)
    {
        int tipoDeEntrada;
        do
        {
            Console.WriteLine(m);
            tipoDeEntrada= int.Parse(Console.ReadLine());
        }while(tipoDeEntrada != 1 && tipoDeEntrada != 2 && tipoDeEntrada != 3 && tipoDeEntrada != 4);
        return tipoDeEntrada;
    }

    public  static int TipoEntrada(int opcion1,int opcion2,int opcion3,int opcion4, int tipoDeEntrada)
    {
       int r = 0;
        switch (tipoDeEntrada)
        {
             case 1:
                r = opcion1;
                break;
             case 2:
             r = opcion2;
                break;
             case 3:
             r = opcion3;
                break;
            case 4:
            r = opcion4;
                break;
        }
        return r;
    }

    public static DateTime IngresarFecha (string m)
    {
        DateTime r;
        Console.WriteLine(m);
        r = DateTime.Parse(Console.ReadLine());
        return r;
    }
}