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
        int idRealizadas = 0;

        while (select != 0)
        {
            Console.WriteLine(@"
            === MENÚ CALCULADORA ===
            1. Agregar una Tarea Pendiente.
            2. Mover Tareas Pendientes a Realizadas.
            3. Buscar Tareas Pendientes por Descripcion.
            4. Listar Tareas Pendientes y Realizadas.

            0. Salir
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
                        Console.WriteLine("ID|");
                        foreach (var tarea in tareasPendientes)
                        {
                            Console.WriteLine($"{tarea.TareaID} | {tarea.Descripcion} | {tarea.Duracion}");
                        }
                        Console.WriteLine("Escribe el ID de la Tarea que deseas mover a Realizadas");
                        int idTareaMover = NumeroEnteroPorTeclado();

                        Tarea? tareaMover = tareasPendientes.FirstOrDefault(t => t.TareaID == idTareaMover);

                        if (tareaMover != null)
                        {
                            tareasRealizadas.Add(new Tarea(idRealizadas++, tareaMover.Descripcion, tareaMover.Duracion));
                            tareasPendientes.Remove(tareaMover);
                            Console.WriteLine("La Tarea se movio con exito");
                        }
                        else
                        {
                            Console.WriteLine("No se encontro la tarea con el id especificado");
                        }


                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Escribe una descripcion de la Tarea Pendiente que deseas encontrar: ");
                        descripcion = Console.ReadLine();
                        Tarea? buscarTareaPendiente = tareasPendientes.FirstOrDefault(t => t.Descripcion == descripcion);
                        if (buscarTareaPendiente != null)
                        {
                            Console.WriteLine("La tarea encontrada: ");
                            Console.WriteLine("ID|");
                            Console.WriteLine($"{buscarTareaPendiente.TareaID} | {buscarTareaPendiente.Descripcion} | {buscarTareaPendiente.Duracion}");
                        }
                        else
                        {
                            Console.WriteLine("No se encontro la tarea con el id especificado");
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("===Lista de tareas Pendientes===");
                        Console.WriteLine("ID|");
                        foreach (var tarea in tareasPendientes)
                        {
                            Console.WriteLine($"{tarea.TareaID} | {tarea.Descripcion} | {tarea.Duracion}");
                        }

                        Console.WriteLine("===Lista de tareas Realizadas=== ");
                        Console.WriteLine("ID|");
                        foreach (var tarea in tareasRealizadas)
                        {
                            Console.WriteLine($"{tarea.TareaID} | {tarea.Descripcion} | {tarea.Duracion}");
                        }
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