using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AdministradorLibros
{
    private const string BooksFile = "books.txt";

    public void DisplayBooks()
    {
        Console.Clear();
        Console.WriteLine("=== LISTADO DE LIBROS ===");

        if (File.Exists(BooksFile))
        {
            string[] bookLines = File.ReadAllLines(BooksFile);

            if (bookLines.Length == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("ID | Título | Autor | Precio | Stock | Año");
            Console.WriteLine("----------------------------------------");

            foreach (string line in bookLines)
            {
                string[] bookData = line.Split(',');
                if (bookData.Length >= 6)
                {
                    Console.WriteLine($"{bookData[0]} | {bookData[1]} | {bookData[2]} | ${bookData[3]} | {bookData[4]} | {bookData[5]}");
                }
            }
        }
        else
        {
            Console.WriteLine("No hay libros registrados.");
        }
    }

    public void AddBook()
    {
        Console.Clear();
        Console.WriteLine("=== AGREGAR LIBRO ===");

        // Generar ID nueva
        int newId = GetNextId();

        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Autor: ");
        string autor = Console.ReadLine();

        Console.Write("Precio: ");
        if (!int.TryParse(Console.ReadLine(), out int precio))
        {
            Console.WriteLine("Precio inválido. Se establecerá como 0.");
            precio = 0;
        }

        Console.Write("Stock: ");
        if (!int.TryParse(Console.ReadLine(), out int stock))
        {
            Console.WriteLine("Stock inválido. Se establecerá como 0.");
            stock = 0;
        }

        Console.Write("Año: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Año inválido. Se establecerá como 0.");
            year = 0;
        }

        // Crear nuevo libro
        Libro newBook = new Libro(newId, titulo, autor, precio, stock);
        newBook.Year1 = year;

        // Guardar libro en archivo
        using (StreamWriter writer = File.AppendText(BooksFile))
        {
            writer.WriteLine(newBook.ToFileString());
        }

        Console.WriteLine("\nLibro agregado exitosamente.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    public void EditBook()
    {
        Console.Clear();
        Console.WriteLine("=== EDITAR LIBRO ===");

        Console.Write("Ingrese el ID del libro a editar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        if (!File.Exists(BooksFile))
        {
            Console.WriteLine("No hay libros registrados.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        string[] bookLines = File.ReadAllLines(BooksFile);
        List<string> updatedBooks = new List<string>();
        bool bookFound = false;

        foreach (string line in bookLines)
        {
            string[] bookData = line.Split(',');

            if (bookData.Length >= 6 && int.Parse(bookData[0]) == id)
            {
                bookFound = true;
                Libro currentBook = new Libro(
                    int.Parse(bookData[0]),
                    bookData[1],
                    bookData[2],
                    int.Parse(bookData[3]),
                    int.Parse(bookData[4])
                );
                currentBook.Year1 = int.Parse(bookData[5]);

                Console.WriteLine("\nInformación actual del libro:");
                Console.WriteLine(currentBook.ObtenerDetalles());

                Console.WriteLine("\nIngrese la nueva información (deje en blanco para mantener el valor actual):");

                Console.Write($"Título [{currentBook.getTitulo()}]: ");
                string newTitle = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTitle))
                {
                    currentBook.Titulo1 = newTitle;
                }

                Console.Write($"Autor [{currentBook.getAutor()}]: ");
                string newAuthor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newAuthor))
                {
                    currentBook.Autor1 = newAuthor;
                }

                Console.Write($"Precio [{currentBook.getPrecio()}]: ");
                string newPriceStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newPriceStr) && int.TryParse(newPriceStr, out int newPrice))
                {
                    currentBook.Precio = newPrice;
                }

                Console.Write($"Stock [{currentBook.getStock()}]: ");
                string newStockStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newStockStr) && int.TryParse(newStockStr, out int newStock))
                {
                    currentBook.setStock(newStock);
                }

                Console.Write($"Año [{currentBook.Year1}]: ");
                string newYearStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newYearStr) && int.TryParse(newYearStr, out int newYear))
                {
                    currentBook.Year1 = newYear;
                }

                updatedBooks.Add(currentBook.ToFileString());
                Console.WriteLine("\nLibro actualizado exitosamente.");
            }
            else
            {
                updatedBooks.Add(line);
            }
        }

        if (!bookFound)
        {
            Console.WriteLine("No se encontró un libro con el ID especificado.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        File.WriteAllLines(BooksFile, updatedBooks);

        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    public void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("=== ELIMINAR LIBRO ===");

        Console.Write("Ingrese el ID del libro a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        if (!File.Exists(BooksFile))
        {
            Console.WriteLine("No hay libros registrados.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        string[] bookLines = File.ReadAllLines(BooksFile);
        List<string> remainingBooks = new List<string>();
        bool bookFound = false;

        foreach (string line in bookLines)
        {
            string[] bookData = line.Split(',');

            if (bookData.Length >= 6 && int.Parse(bookData[0]) == id)
            {
                bookFound = true;
                Console.WriteLine($"Libro eliminado: {bookData[1]} de {bookData[2]}");
            }
            else
            {
                remainingBooks.Add(line);
            }
        }

        if (!bookFound)
        {
            Console.WriteLine("No se encontró un libro con el ID especificado.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        File.WriteAllLines(BooksFile, remainingBooks);

        Console.WriteLine("Libro eliminado exitosamente.");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private int GetNextId()
    {
        if (!File.Exists(BooksFile))
        {
            return 1;
        }

        string[] bookLines = File.ReadAllLines(BooksFile);

        if (bookLines.Length == 0)
        {
            return 1;
        }

        int maxId = 0;

        foreach (string line in bookLines)
        {
            string[] bookData = line.Split(',');

            if (bookData.Length >= 1 && int.TryParse(bookData[0], out int id))
            {
                if (id > maxId)
                {
                    maxId = id;
                }
            }
        }

        return maxId + 1;
    }
}

