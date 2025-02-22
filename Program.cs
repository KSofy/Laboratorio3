
//Laboratorio3

using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    // Variables globales
    static List<string> estudiantes = new List<string>();
    static List<double> calificaciones = new List<double>();
    static bool usuarioAutenticado = false;

    static void Main(string[] args)
    {
        // Mostrar mensaje de bienvenida
        Escribir(100, "=============================================================\n");
        Escribir(100, "====   BIENVENIDO AL SISTEMA DE GESTION DE ESTUDIANTES   ====\n");
        Escribir(100, "=============================================================");
        Console.WriteLine("\n");

        // Solicitar autenticación antes de mostrar el menú
        usuarioAutenticado = ValidacionUsuario("sofia", "s0123", "dilena", "d0321");

        if (usuarioAutenticado)
        {
            while (true)
            {
                // Mostrar el menú principal
                Console.WriteLine("ºººººººººººººººººººººººººººººººººººººº");
                Console.WriteLine("           Menu de opciones           ");
                Console.WriteLine("ºººººººººººººººººººººººººººººººººººººº");
                Console.WriteLine("\n1. Agregar estudiante");
                Console.WriteLine("2. Mostrar lista de estudiantes");
                Console.WriteLine("3. Calcular promedio de calificaciones");
                Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción ");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarEstudiante();
                        break;
                    case 2:
                        MostrarEstudiantes();
                        break;
                    case 3:
                        CalcularPromedio();
                        break;
                    case 4:
                        MostrarEstudianteConMaxCalificacion();
                        break;
                    case 5:
                        Console.WriteLine("\n");
                        Console.WriteLine("Saliendo del sistema...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Autenticación fallida. Cerrando el sistema...");
        }
    }

    //Función efecto maquina de escribir
    static void Escribir(int vel, string texto)
    {
        for (int i = 0; i < texto.Length; i++)
        {
            Console.Write(texto[i]);
            Thread.Sleep(vel);
        }
    }

    // Función para validación de usuario
    static bool ValidacionUsuario(string sofia, string s0123, string dilena, string d0321)
    {

        Console.WriteLine("---Iniciar secion---");
        Console.WriteLine("Ingrese el nombre de usuario: ");
        string nombreUsuario = Console.ReadLine();
        Console.WriteLine("Ingrese la contraseña: ");
        string contraseña = Console.ReadLine();
        if ((nombreUsuario == sofia && contraseña == s0123) || (nombreUsuario == dilena && contraseña == d0321))
        {
            Console.WriteLine("Usuario válido");
            return true;
        }
        else
        {
            Console.WriteLine("Usuario no válido");
            return false;
        }
    }

    // Función para agregar estudiante
    static void AgregarEstudiante()
    {
        Console.WriteLine("\n");
        Console.Write("1) Ingrese el nombre del estudiante: ");
        string nombre = Console.ReadLine();
        double calificacion;
        // Validar que la calificación esté en el rango adecuado
        while (true)
        {
            Console.Write("2) Ingrese la calificación del estudiante (0-10): ");
            if (double.TryParse(Console.ReadLine(), out calificacion) && calificacion >= 0 && calificacion <= 10)
            {
                break;
            }
            else
            {
                Console.WriteLine("Por favor ingrese una calificación válida entre 0 y 10.");
            }
        }

        estudiantes.Add(nombre);
        calificaciones.Add(calificacion);
        Console.WriteLine("¡Estudiante agregado correctamente!");
        Console.WriteLine("\n");
    }

    // Función para mostrar lista de estudiantes
    static void MostrarEstudiantes()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
        }
        else
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n-----Lista de estudiantes-----");
            for (int i = 0; i < estudiantes.Count; i++)
            {
                Console.WriteLine($"{estudiantes[i]} - Calificación: {calificaciones[i]}");
            }
        }
        Console.WriteLine("\n");
    }

    // Función para calcular promedio de calificaciones
    static void CalcularPromedio()
    {
        Console.WriteLine("\n");
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double suma = 0;
            foreach (double calificacion in calificaciones)
            {
                suma += calificacion;
            }
            double promedio = suma / calificaciones.Count;
            Console.WriteLine($"El promedio de calificaciones es: {promedio}");
        }
        Console.WriteLine("\n");
    }

    // Función para mostrar estudiante con la calificación más alta
    static void MostrarEstudianteConMaxCalificacion()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
        }
        else
        {
            double maxCalificacion = calificaciones[0];
            string estudianteMax = estudiantes[0];
            for (int i = 1; i < calificaciones.Count; i++)
            {
                if (calificaciones[i] > maxCalificacion)
                {
                    maxCalificacion = calificaciones[i];
                    estudianteMax = estudiantes[i];
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine($"El estudiante con la calificación más alta es {estudianteMax} con una nota de: {maxCalificacion}");
            Console.WriteLine("\n");
        }
    }
}
