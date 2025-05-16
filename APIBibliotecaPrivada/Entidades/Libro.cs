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
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public double precio { get; set; }
    public int stock { get; set; }
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
}




