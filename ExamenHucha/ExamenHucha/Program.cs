


using System.ComponentModel.DataAnnotations;

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el nombre del dueño de la hucha:");
            string nombre = Console.ReadLine();


            String path = "C:\\Users\\ftval\\Desktop\\DAW 2023\\PROGRAMACIÓN\\ExamenHucha\\";
            String filename = "Hucha.txt";
            
           
            Hucha hucha = new Hucha(nombre);

            bool salir = false;
            do
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Mostrar contenido de la hucha");
                Console.WriteLine("2. Meter dinero");
                Console.WriteLine("3. Vaciar la hucha");
                Console.WriteLine("4. Cambiar dueño");
                Console.WriteLine("5. Cargar Hucha");
                Console.WriteLine("6. Guardar Hucha");
                Console.WriteLine("7. Salir");
                Console.Write("Introduce una opción: ");

                int opcion = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        hucha.Imprime();
                        break;

                    case 2:
                        hucha.MeterDinero();
                        Console.WriteLine("\nDinero añadido a la hucha");
                        break;

                    case 3:
                        hucha.Vaciar();
                        Console.WriteLine("\nHucha vaciada");
                        break;

                    case 4:
                        Console.Write("Introduce el nuevo nombre del dueño: ");
                        nombre = Console.ReadLine();
                        hucha.CambiaDueno(nombre);
                        Console.WriteLine("\nDueño de la hucha cambiado");
                        break;
                    case 5:
                    if (File.Exists(path + filename))
                    {
                        StreamReader archivo = new StreamReader(path + filename);

                        String linea = archivo.ReadLine();
                        int contador = 1;
                        while(linea != null)
                        {
                            Console.Write(contador + "\t");
                            contador++;

                            String tipo;
                            String valor;
                            double valorInt = 0;
                            String[] tokens = linea.Split(';');
                            tipo = tokens[0];
                            valor = tokens[1];
                            
                            double.TryParse(valor, out valorInt);
                            Console.Write(tipo);
                            
                            if(valor.EndsWith(' '))
                            {
                                Console.Write(valor+"\n");
                            }
                            Console.WriteLine("\t" + valorInt);
                            linea = archivo.ReadLine();
                            if(tipo == "BILLETE")
                            {
                                hucha.dinero.Add(new Billete((int)valorInt));
                            }else
                            {
                                hucha.dinero.Add(new Moneda((float)valorInt));
                            }
                        }
                        
                        archivo.Close();

                    }
                    else
                    {
                        Console.WriteLine("El archivo " + filename + " no existe");
                    }
                    break;
                    case 6:
                    if (File.Exists(path + filename))
                    {
                        StreamWriter archivo = new StreamWriter(path + filename);
                        foreach(IDinero item in hucha.dinero)
                        {
                            if(item is Billete)
                            {
                                archivo.WriteLine($"BILLETE;{item.GetValor()}");

                            }
                            else
                            {
                                archivo.WriteLine($"MONEDA;{item.GetValor()}");

                            }
                           
                        }
                        archivo.Flush();
                        archivo.Close();

                    }
                    else
                    {
                        Console.WriteLine("El archivo " + filename + " no existe");
                    }
                    break;
                    case 7:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida");
                        break;
                }

            } while (!salir);

            Console.WriteLine("\nPrograma finalizado");
        }
    }
