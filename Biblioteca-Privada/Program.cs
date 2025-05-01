using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Biblioteca_Privada;

class Program
{
    // Credenciales de administrador
    private const string AdminUsername = "admon";
    private const string AdminPassword = "12344";

    // Atributos de Usuario actual
    private static string currentUser = null;
    private static bool isAdmin = false;

    // Instancia del administrador de libro

    static void Main(string[] args)
    {
        // Inicializar libros de muestra
        InicializarLibrosPrueba();

        bool exit = false;

        while (!exit)
        {
            if (currentUser == null)
            {
                MostrarMenuPrincipal();

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                if (isAdmin)
                {
                    MostrarMenuAdmin();
                }
                else
                {
                    MostrarMenuUsuario();
                }

                string option = Console.ReadLine();

                if (isAdmin)
                {
                    switch (option)
                    {
                        case "1":
                     
                            CRUDLibros();
                            break;
                        case "2":
                      
                            break;
                        case "3":
                          
                            break;
                        case "4":
                        
                            break;
                        case "5":
                            Logout();
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    switch (option)
                    {
                        case "1":
                      
                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                        case "2":
                            Logout();
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Intente de nuevo.");
                            break;
                    }
                }
            }

            Console.Clear();
        }

        Console.WriteLine("¡Gracias por usar el sistema de gestión de libros!");
    }

    private static void MostrarMenuPrincipal()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== SISTEMA DE GESTIÓN DE LIBROS ===");
        Console.ResetColor();
        Console.WriteLine("1. Iniciar sesión");
        Console.WriteLine("2. Registrarse");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");
    }

    private static void MostrarMenuAdmin()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"=== MENÚ ADMINISTRADOR (Usuario: {currentUser}) ===");
        Console.ResetColor();
        Console.WriteLine("1. Mostrar libros");
        Console.WriteLine("2. Agregar libro");
        Console.WriteLine("3. Editar libro");
        Console.WriteLine("4. Eliminar libro");
        Console.WriteLine("5. Cerrar sesión");
        Console.Write("Seleccione una opción: ");
    }

    private static void MostrarMenuUsuario()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"=== MENÚ USUARIO (Usuario: {currentUser}) ===");
        Console.ResetColor();
        Console.WriteLine("1. Mostrar libros");
        Console.WriteLine("2. Cerrar sesión");
        Console.Write("Seleccione una opción: ");
    }

    private static void CRUDLibros()
    {
        Console.WriteLine("\n=== OPERACIONES DE LIBROS ===");
        Console.WriteLine("1. Editar un libro");
        Console.WriteLine("2. Eliminar un libro");
        Console.WriteLine("3. Agregar un libro");
        Console.WriteLine("4. Volver al menú principal");
        Console.Write("Seleccione una opción: ");

        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
    
                break;
            case "2":

                break;
            case "3":

                break;
            case "4":
                return;
            default:
                Console.WriteLine("Opción inválida. Volviendo al menú principal...");
                break;
        }
    }

    private static void Login()
    {
        Console.Clear();
        Console.WriteLine("=== INICIAR SESIÓN ===");

        Console.Write("Usuario: ");
        string username = Console.ReadLine();

        Console.Write("Contraseña: ");
        string password = ReadPassword();

        if (username == AdminUsername && password == AdminPassword)
        {
            currentUser = username;
            isAdmin = true;
            Console.WriteLine("\n¡Bienvenido Administrador!");
        }
        else
        {
            // Verificar si el usuario si está en el txt o no
            if (File.Exists("users.txt"))
            {
                string[] users = File.ReadAllLines("users.txt");
                bool userFound = false;

                foreach (string user in users)
                {
                    string[] userData = user.Split(',');
                    if (userData.Length == 2 && userData[0] == username && userData[1] == password)
                    {
                        currentUser = username;
                        isAdmin = false;
                        userFound = true;
                        Console.WriteLine($"\n¡Bienvenido {username}!");
                        break;
                    }
                }

                if (!userFound)
                {
                    Console.WriteLine("\nUsuario o contraseña incorrectos.");
                }
            }
            else
            {
                Console.WriteLine("\nNo hay usuarios registrados.");
            }
        }

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private static void Register()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRO DE USUARIO ===");

        Console.Write("Nuevo usuario: ");
        string username = Console.ReadLine();

        // Verificar si el usuario ya existe
        if (username == AdminUsername || (File.Exists("users.txt") &&
            File.ReadAllLines("users.txt").Any(u => u.Split(',')[0] == username)))
        {
            Console.WriteLine("El nombre de usuario ya existe. Intente con otro.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.Write("Nueva contraseña: ");
        string password = ReadPassword();

        // Guardar usuario en el archivo users.txt
        using (StreamWriter writer = File.AppendText("users.txt"))
        {
            writer.WriteLine($"{username},{password}");
        }

        Console.WriteLine("\nUsuario registrado exitosamente.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private static void Logout()
    {
        currentUser = null;
        isAdmin = false;
        Console.WriteLine("Sesión cerrada exitosamente.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        return password;
    }

    private static void InicializarLibrosPrueba()
    {
        if (!File.Exists("books.txt"))
        {
            List<Libro> sampleBooks = new List<Libro>
            {
                new Libro(1, "Don Quijote de la Mancha", "Miguel de Cervantes", 1500, 10),
                new Libro(2, "Cien años de soledad", "Gabriel García Márquez", 1200, 15),
                new Libro(3, "El principito", "Antoine de Saint-Exupéry", 800, 20),
                new Libro(4, "1984", "George Orwell", 950, 8),
                new Libro(5, "Rayuela", "Julio Cortázar", 1100, 12)
            };

            // Definir años de publicación
            sampleBooks[0].Year1 = 1605;
            sampleBooks[1].Year1 = 1967;
            sampleBooks[2].Year1 = 1943;
            sampleBooks[3].Year1 = 1949;
            sampleBooks[4].Year1 = 1963;

            using (StreamWriter writer = new StreamWriter("books.txt"))
            {
                foreach (Libro book in sampleBooks)
                {
                    writer.WriteLine(book.ToFileString());
                }
            }
        }
    }
}

