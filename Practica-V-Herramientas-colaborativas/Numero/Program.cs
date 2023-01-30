using System;

namespace practicaV_numero
{
    internal class Program
    {
        /* Clase numero donde se desarrollan todos los métodos para los siguientes cálculos 
           a.- Calcular si el número es primo
           b.- Calcular el factorial
           c.- Dado un número en segundos, devolver horas, minutos y segundos . Ejemplo: 3680 segundos son
               1 hora, 1 min, y 20 segundos.
           d.- Devolver los primeros 15 números de la serie de Pell
                      |        0         si n = 1
                 Pn = |        1         si n = 2
                      |  2Pn-1 + Pn-2    otro caso
           e.- Decir si un número es un número de Armstrong o no
               Es un número que es la suma de sus propios dígitos, cada uno elevado al número de dígitos del número. 
               Por ejemplo: 9 es un número de Armstrong porque: 9 = 9^1 = 9 y 
                            153 es un número de Armstrong porque: 153 = 1^3 + 5^3 + 3^3 = 1 + 125 + 27 = 153
           f.- Decir si un número tiene todos sus dígitos diferentes
        */
        public class numero
        {
            // Método que recibe un número y devuelve true si es primo o false en caso contrario.
            public Boolean APrimo(int d)
            {
                Boolean es_primo = true;
                int indice = 2;
                if (d > 1) es_primo = true;
                else es_primo = false;
                while (es_primo && indice <= Math.Sqrt(d))
                {
                    if (d % indice == 0) es_primo = false;
                    indice++;
                }
                return es_primo;
            }
            // Método que recibe un número y devuelve
            public int BFactorial(int d)
            {
                if (d == 0) return 1;
                else
                    return d * BFactorial(d - 1);
            }
            // Método que recibe un número y devuelve
            public string CHMS(int d)
            {
                string s = "";
                int contador = 0;
                while (d >= 3600)
                {
                    contador++;
                    d -= 3600;
                }
                s += " Horas: " + contador;
                contador = 0;
                while (d >= 60)
                {
                    contador++;
                    d -= 60;
                }
                s += " Minutos: " + contador;
                s += " y Segundos: " + d;
                return s;
            }
            // Método que recibe un número y devuelve
            public int[] DPell()
            {
                int[] Pell = new int[15];
                Pell[0] = 1;
                Pell[1] = 2;
                for (int i = 2; i < 15; i++) Pell[i] = 2 * Pell[i - 1] + Pell[i - 2];
                return Pell;
            }

            // Método que recibe un número y devuelve
            public Boolean EArmstrong(int d)
            {
                int cuentaDigitos = 0;
                int espontaneo = d;
                while (espontaneo != 0)
                {
                    espontaneo /= 10;
                    cuentaDigitos++;
                }
                double suma = 0.0;
                espontaneo = d;
                while (espontaneo != 0)
                {
                    suma += Math.Pow(espontaneo % 10, cuentaDigitos);
                    espontaneo /= 10;
                }
                return (d == suma);
            }


        }


        static void Main(string[] args)
        {
            // Se define la variable x
            int x = 0;
            // Se define la variable n de la clase numero
            numero n = new();
            // Se define la variable para validar la opción del menú
            string validos = "ABCDEFGHIJKabcdefghijk";
            char caracter = ' ';
            do
            {
                // Se limpia la pantalla  
                Console.Clear();
                // Se muestra el menú de opciones
                Console.WriteLine("");
                Console.WriteLine("                  MENU DE ACTIVIDADES\n");
                Console.WriteLine("");
                Console.WriteLine("   a <== Calcula si el número es primo.");
                Console.WriteLine("   b <== Calcula el factorial.");
                Console.WriteLine("   c <== Dado un número en segundos lo transforma a horas:minutos:segundos.");
                Console.WriteLine("   d <== Calcula los primeros quince números de la serie de Pell.");
                Console.WriteLine("   e <== Calcula si es un número de Armstrong.");
                Console.WriteLine("   f <== Dice si todos sus dígitos son diferentes.");
                Console.WriteLine("");
                Console.WriteLine("   g <== Salir");
                Console.WriteLine("");
                // Se lee la opción seleccionada
                do
                {
                    Console.Write("      Escriba su Opción(a, b, c, d, e, f, g) ");
                    caracter = (Console.ReadLine() + " ")[0];
                }
                // Solo se aceptan los caracteres A, a, B, b, C, c, D, d, E, e, F, f, G y g
                while (!validos.Contains(caracter.ToString()));
                Console.WriteLine("\n");
                // Se direcciona a la respectiva acción dependiendo de la letra leida
                switch (caracter)
                {
                    case 'A':
                    case 'a':
                        Console.Write("  Escribe un número: ");
                        while (!int.TryParse(Console.ReadLine(), out x))
                        {
                            Console.Write(" ==X Esto no es un número entero X==\n   Escribe un número: ");
                        }
                        if (n.APrimo(x)) Console.WriteLine("El número: " + x + " SI es primo.");
                        else Console.WriteLine("    El número: " + x + " NO es primo.");
                        Console.Write("\n     Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 'B':
                    case 'b':
                        Console.Write("  Escribe un número: ");
                        while (!int.TryParse(Console.ReadLine(), out x))
                        {
                            Console.Write(" ==X Esto no es un número entero X==\n   Escribe un número: ");
                        }
                        Console.WriteLine("     El factorial de: " + x + " es: " + n.BFactorial(x));
                        Console.Write("\n     Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 'C':
                    case 'c':
                        Console.Write("  Escribe un número: ");
                        while (!int.TryParse(Console.ReadLine(), out x))
                        {
                            Console.Write(" ==X Esto no es un número entero X==\n   Escribe un número: ");
                        }
                        Console.WriteLine("  " + x + " segundos equivalen a: " + n.CHMS(x));
                        Console.Write("\n     Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 'D':
                    case 'd':
                        Console.Write("  Serie de Pell: ");
                        for (int i = 0; i < 15; i++) Console.Write(n.DPell()[i] + " ");
                        Console.WriteLine();
                        Console.Write("\n     Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 'E':
                    case 'e':
                        Console.Write("  Escribe un número: ");
                        while (!int.TryParse(Console.ReadLine(), out x))
                        {
                            Console.Write(" ==X Esto no es un número entero X==\n   Escribe un número: ");
                        }
                        if (n.EArmstrong(x)) Console.WriteLine(" El número: " + x + " SI es un número de Armstrong");
                        else Console.WriteLine("    El número: " + x + " NO es un número de Armstrong");
                        Console.Write("\n      Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 'F':
                    case 'f':
                        Console.Write("  Escribe un número: ");
                        while (!int.TryParse(Console.ReadLine(), out x))
                        {
                            Console.Write(" ==X Esto no es un número entero X==\n   Escribe un número: ");
                        }


                        Console.Write("\n     Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;




                    default:
                        break;
                }
            }
            // Permanece dentro del ciclo a menos que se pulse la letra 'G' o 'g' de salida
            while ((caracter != 'G') && (caracter != 'g'));
        }

    }
}
