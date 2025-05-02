using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
namespace APIBibliotecaPrivada.Entidades;
public class Libro
{

    [Key]
    public int ID { get; set; }
    public string Titulo {  get; set; }
    public string Autor {  get; set; }
    public int precio {  get; set; }
    public int stock {  get; set; }
    public int Year {  get; set; }
	private const string BooksFile = "books.txt";
	// Constructor predeterminado
	public Libro()
    {
    }

    public Libro(int ID, string Titulo, string Autor, int precio, int stock)
    {
        this.ID = ID;
        this.Titulo = Titulo;
        this.Autor = Autor;
        this.precio = precio;
        this.stock = stock;
    }

    #region Propiedades
    public int ID1
    {
        get => ID;
        set => ID = value;
    }

    public string Titulo1
    {
        get => Titulo;
        set => Titulo = value;
    }

    public string Autor1
    {
        get => Autor;
        set => Autor = value;
    }

    public int Precio
    {
        get => precio;
        set => precio = value;
    }

    public int Stock
    {
        get => stock;
        set => stock = value;
    }

    public int Year1
    {
        get => Year;
        set => Year = value;
    }
    #endregion

    #region Métodos Básicos
    public string getTitulo()
    {
        return Titulo;
    }

    public string getAutor()
    {
        return Autor;
    }

    public int getPrecio()
    {
        return precio;
    }

    public int getStock()
    {
        return stock;
    }

    public void setStock(int nuevoStock)
    {
        stock = nuevoStock;
    }

    public string ObtenerDetalles()
    {
        return $"ID: {ID}, Título: {Titulo}, Autor: {Autor}, Precio: {precio}, Stock: {stock}, Año: {Year}";
    }

    public override string ToString()
    {
        return ObtenerDetalles();
    }

    public string ToFileString()
    {
        return $"{ID},{Titulo},{Autor},{precio},{stock},{Year}";
    }
    #endregion

    #region Métodos CRUD
    // Método para guardar un libro en el archivo
    public void Save()
    {
        using (StreamWriter writer = File.AppendText(BooksFile))
        {
            writer.WriteLine(this.ToFileString());
        }
    }

    // Método para actualizar un libro existente
    public void Update()
    {
        if (!File.Exists(BooksFile))
        {
            return;
        }

        string[] bookLines = File.ReadAllLines(BooksFile);
        List<string> updatedBooks = new List<string>();
        bool bookFound = false;

        foreach (string line in bookLines)
        {
            string[] bookData = line.Split(',');

            if (bookData.Length >= 6 && int.Parse(bookData[0]) == this.ID)
            {
                updatedBooks.Add(this.ToFileString());
                bookFound = true;
            }
            else
            {
                updatedBooks.Add(line);
            }
        }

        if (bookFound)
        {
            File.WriteAllLines(BooksFile, updatedBooks);
        }
    }

    // Método para eliminar un libro
    public bool Delete()
    {
        if (!File.Exists(BooksFile))
        {
            return false;
        }

        string[] bookLines = File.ReadAllLines(BooksFile);
        List<string> remainingBooks = new List<string>();
        bool bookFound = false;

        foreach (string line in bookLines)
        {
            string[] bookData = line.Split(',');

            if (bookData.Length >= 6 && int.Parse(bookData[0]) == this.ID)
            {
                bookFound = true;
            }
            else
            {
                remainingBooks.Add(line);
            }
        }

        if (bookFound)
        {
            File.WriteAllLines(BooksFile, remainingBooks);
        }

        return bookFound;
    }

    // Método estático para obtener todos los libros
    public static List<Libro> GetAll()
    {
        List<Libro> books = new List<Libro>();

        if (!File.Exists(BooksFile))
        {
            return books;
        }

        string[] bookLines = File.ReadAllLines(BooksFile);

        foreach (string line in bookLines)
        {
            string[] bookData = line.Split(',');
            if (bookData.Length >= 6)
            {
                Libro book = new Libro(
                    int.Parse(bookData[0]),
                    bookData[1],
                    bookData[2],
                    int.Parse(bookData[3]),
                    int.Parse(bookData[4])
                );
                book.Year1 = int.Parse(bookData[5]);
                books.Add(book);
            }
        }

        return books;
    }

    // Método estático para buscar un libro por ID
    public static Libro GetById(int id)
    {
        if (!File.Exists(BooksFile))
        {
            return null;
        }

        string[] bookLines = File.ReadAllLines(BooksFile);

        foreach (string line in bookLines)
        {
            string[] bookData = line.Split(',');
            if (bookData.Length >= 6 && int.Parse(bookData[0]) == id)
            {
                Libro book = new Libro(
                    int.Parse(bookData[0]),
                    bookData[1],
                    bookData[2],
                    int.Parse(bookData[3]),
                    int.Parse(bookData[4])
                );
                book.Year1 = int.Parse(bookData[5]);
                return book;
            }
        }

        return null;
    }

    // Método estático para obtener el siguiente ID disponible
    public static int GetNextId()
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
    #endregion
}



