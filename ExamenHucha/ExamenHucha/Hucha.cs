
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Hucha
{
    public string nombre;
   public List<IDinero> dinero;

    public Hucha(string nombre)
    {
        this.nombre = nombre;
        dinero = new List<IDinero>();
    }

    public void Imprime()
    {
        Console.WriteLine($"En la hucha de {nombre} hay:");
        float total = 0;
        int billeteCount = 0;
        int monedaCount = 0; 
        foreach (IDinero item in dinero)
        {
            item.Imprime();
        }
        foreach (IDinero item in dinero)
        {
            if(item is Billete)
            {
                billeteCount++;
               
            }else if(item is Moneda) {
                
                monedaCount++;
            }
        }
        foreach (IDinero item in dinero)
        {
            total += item.GetValor();
        }
        Console.WriteLine($"Total: {total} euros");
        Console.WriteLine($"Hay:{billeteCount} billetes y {monedaCount} monedas");
    }

    public void Vaciar()
    {
        dinero.Clear();
    }

    public void CambiaDueno(string nuevoNombre)
    {
        nombre = nuevoNombre;
    }

    public void MeterDinero()
    {
        Random rnd = new Random();
        int tipoDinero = rnd.Next(0, 2);
        if (tipoDinero == 0)
        {
            //moneda
            float[] valores = { 0.05f, 0.10f, 0.20f, 0.50f, 1f, 2f };
            int valorAleatorio = rnd.Next(0, 6);
            Moneda moneda = new Moneda(valores[valorAleatorio]);
            dinero.Add(moneda);
        }
        else
        {
            //billete
            int[] valores = { 5, 10, 20, 50, 100, 200, 500 };
            int valorAleatorio = rnd.Next(0, 7);
            Billete billete = new Billete(valores[valorAleatorio]);
            dinero.Add(billete);
        }
    }
}