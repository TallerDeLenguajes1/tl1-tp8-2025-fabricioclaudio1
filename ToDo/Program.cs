public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<Tarea> tareasPendientes = new List<Tarea>();
        List<Tarea> tareasRealizadas = new List<Tarea>();

        int select = 1;

        string? descripcion;
        int duracion;
        int id = 0;

        while (select != 0)
        {
            Console.WriteLine(@"
            === MENÚ CALCULADORA ===
            1. Agregar una Tarea Pendiente.
            2. Mover Tareas Pendientes a Realizadas.
            3. Listar Tareas Pendientes y Realizadas.
            4. Buscar Tareas por ID.
            5. Buscar Tareas por palabra clave.

            6. Salir
            ========================
            ");
            select = NumeroEnteroPorTeclado();

            switch (select)
            {
                case 1:
                    {
                        Console.WriteLine("Escribe la descripcion de la tarea");
                        descripcion = Console.ReadLine();
                        Console.WriteLine("Escribe la duracion de la tarea (numero entero)");
                        duracion = NumeroEnteroPorTeclado();
                        id++;

                        tareasPendientes.Add(new Tarea(id, descripcion, duracion));

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Lista de tareas Pendientes: ");
                        Console.WriteLine("ID |");
                        foreach (var tarea in tareasPendientes)
                        {
                            Console.WriteLine($"{tarea.TareaID} | {tarea.Descripcion} | {tarea.Duracion}");
                        }
                        Console.WriteLine("Escribe el ID de la Tarea que deseas mover a Pendientes");
                        int idTareaMover = NumeroEnteroPorTeclado();

                        foreach (var tarea in tareasPendientes)
                        {
                            if (tarea.TareaID != 0 && tarea.TareaID == idTareaMover)
                            {
                                tareasPendientes.RemoveAt(tarea.TareaID);
                            }
                        }



                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }

            }

        }
    }


    public static int NumeroEnteroPorTeclado()
    {
        int numero;

        while (true)
        {
            string? numeroString = Console.ReadLine();
            bool resultado = int.TryParse(numeroString, out numero);
            if (resultado)
            {
                return numero;
            }
            else
            {

                Console.WriteLine("Lo que ingreso no es un numero, vuelve a intentarlo.");
            }
        }
    }


    //fin main
}