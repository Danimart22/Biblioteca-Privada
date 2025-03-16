using System;

public class Libro
{
    private int ID;
    private string Titulo;
    private string Autor;
    private int precio;
    private int stock;
    private int Year; // Keeping Year as requested

    // Default constructor for deserialization
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
}



