using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Libro
{

    private int ID;
    private string Titulo;
    private string Autor;
    private int precio;
    private int stock;

    public Libro(int ID, string Titulo, string Autor, int precio, int stock)
    {
        this.ID = ID;
        this.Titulo = Titulo;
        this.Autor = Autor;
        this.precio = precio;
        this.stock = stock;
    }




}
