using System;
using System.Collections.Generic;
using System.IO;
using Biblioteca_Privada;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca_Privada.Controllers
{
    [ApiController]
    [Route("Libros")]

    public class LibrosController : ControllerBase
    {
        public void DisplayBooks()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE LIBROS ===");

            List<Libro> books = Libro.GetAll();

            if (books.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            Console.WriteLine("ID | Título | Autor | Precio | Stock | Año");
            Console.WriteLine("----------------------------------------");

            foreach (Libro book in books)
            {
                Console.WriteLine($"{book.ID1} | {book.getTitulo()} | {book.getAutor()} | ${book.getPrecio()} | {book.getStock()} | {book.Year1}");
            }
        }

        public void AddBook()
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR LIBRO ===");

            // Generar ID nueva
            int newId = Libro.GetNextId();

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

            // Guardar libro
            newBook.Save();

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

            // Buscar el libro por ID
            Libro currentBook = Libro.GetById(id);

            if (currentBook == null)
            {
                Console.WriteLine("No se encontró un libro con el ID especificado.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

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

            // Actualizar el libro
            currentBook.Update();

            Console.WriteLine("\nLibro actualizado exitosamente.");
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

            // Buscar el libro por ID
            Libro bookToDelete = Libro.GetById(id);

            if (bookToDelete == null)
            {
                Console.WriteLine("No se encontró un libro con el ID especificado.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Libro a eliminar: {bookToDelete.getTitulo()} de {bookToDelete.getAutor()}");
            Console.Write("¿Está seguro de eliminar este libro? (S/N): ");
            string confirmation = Console.ReadLine().ToUpper();

            if (confirmation == "S")
            {
                // Eliminar el libro
                bool deleted = bookToDelete.Delete();

                if (deleted)
                {
                    Console.WriteLine("Libro eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo eliminar el libro.");
                }
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}

