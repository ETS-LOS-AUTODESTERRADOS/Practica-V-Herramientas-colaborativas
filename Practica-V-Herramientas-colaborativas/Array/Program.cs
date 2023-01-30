using System;

namespace practicaV_array
{
    internal class Program
    {
        /* Clase arreglo donde se desarrollan todos los métodos para trabajar con el vector
            Calcular máximo
            Calcular mínimo
            Calcular la mediana
            Calcular la media
            Ordenar un Array de menor a mayor
            Calcular la desviación típica de un array
            Binarizar un array en base a un número n. Esta función devolverá un nuevo array, 
            cuyos elementos valdrán 0 o 1. Si el componente i del array original es menor 
            que n, el componente i del array resultado será 0, y 1 en el caso contrario.
        */
        public class arreglo
        {
            // Método que recibe un arreglo de enteros y un valor d y devuelve el arreglo con el valor
            // d insertado al final del array en última posición
            public int[] AInserta(int[] laData, int d)
            {
                Array.Resize(ref laData, laData.Length + 1);
                if (laData.Length == 1) laData[0] = d;
                else laData[laData.Length - 1] = d;
                return laData;
            }
            // Método que recibe un arreglo de enteros y devuelve el arreglo sin la última posición
            public int[] BElimina(int[] laData)
            {
                if (laData.Length >= 1) Array.Resize(ref laData, laData.Length - 1);
                return laData;
            }
            // Método que recibe un arreglo de enteros y devuelve arreglo vacío
            public int[] CBorra(int[] laData)
            {
                if (laData.Length >= 1) Array.Resize(ref laData, 0);
                return laData;
            }
            // Método que recibe un arreglo de enteros y devuelve el elemento mayor
            public int DMayor(int[] laData)
            {
                int M = laData[0];
                for (int i = 1; i < laData.Length; i++) M = (M < laData[i]) ? laData[i] : M;
                return M;
            }
            // Método que recibe un arreglo de enteros y devuelve el elemento menor
            public int EMenor(int[] laData)
            {
                int m = laData[0];
                for (int i = 1; i < laData.Length; i++) m = (m > laData[i]) ? laData[i] : m;
                return m;
            }
            // Método que recibe un arreglo de enteros y devuelve la media aritmética de dichos elementos
            public Double FMedia(int[] laData)
            {
                Double d = 0.0;
                for (int i = 0; i < laData.Length; i++) d = d + laData[i];
                return d / laData.Length;
            }
            // Método que recibe un arreglo de enteros y devuelve el mismo arreglo ordenado de menor a mayor
            private int[] ordenados(int[] datos)
            {
                int[] datosOrdenados = new int[datos.Length];
                for (int i = 0; i < datosOrdenados.Length; i++) datosOrdenados[i] = datos[i];
                int temp;
                for (int i = 0; i < datosOrdenados.Length - 1; i++)
                    for (int j = 0; j < datosOrdenados.Length - i - 1; j++)
                        if (datosOrdenados[j] > datosOrdenados[j + 1])
                        {
                            temp = datosOrdenados[j + 1];
                            datosOrdenados[j + 1] = datosOrdenados[j];
                            datosOrdenados[j] = temp;
                        }
                return datosOrdenados;
            }
            // Método que recibe un arreglo de enteros y devuelve la mediana de dichos elementos
            public Double GMediana(int[] laData)
            {
                int mitad = (laData.Length - 1) / 2;
                laData = ordenados(laData);
                return laData[mitad];
            }
            // Método que recibe un arreglo de enteros y devuelve un texto con los elementos 
            // del arreglo separados por comas
            public string HMostrar(int[] laData)
            {
                string t = "";
                int[] laDataOrdenada = ordenados(laData);
                if (laData.Length == 0) t = " Arreglo sin elementos.";
                else
                    for (int i = 0; i < laData.Length; i++) t = (i == 0) ? t + laDataOrdenada[i].ToString() : t + ", " + laDataOrdenada[i].ToString();
                return t;
            }
            // Método que recibe un arreglo de enteros y devuelve la desviación típica de dichos elementos
            public Double IDesviacion(int[] laData)
            {
                Double media = 0.0, desviacion = 0.0;
                for (int i = 0; i < laData.Length; i++) media = media + laData[i];
                media = media / laData.Length;
                for (int i = 0; i < laData.Length; i++) desviacion = desviacion + (laData[i] - media) * (laData[i] - media);
                desviacion = Math.Sqrt(desviacion / laData.Length);
                return desviacion;
            }
            // Método que recibe un arreglo de enteros Binarizar un array en base a un número n.
            // Esta función devolverá un nuevo array, cuyos elementos valdrán 0 o 1.
            // Si el componente i del array original es menor que n, el componente i
            // del array resultado será 0, y 1 en el caso contrario.
            public int[] JBinariza(int[] laData, int d)
            {
                int[] laDataBinaria = { };
                Array.Resize(ref laDataBinaria, laData.Length);
                for (int i = 0; i < laData.Length; i++) laDataBinaria[i] = (laData[i] < d) ? 0 : 1;
                return laDataBinaria;
            }
        }
        static void Main(string[] args)
        {
            // Se definen y se les dá dimensión a los vectores de lectura, proceso, ordenamiento y resultados
            int[] listaData = { };
            int n = 0;
            // Se define la variable para validar la opción del menú
            string validos = "ABCDEFGHIJKabcdefghijk";
            char caracter = ' ';
            // Se define la variable para seleccionar el vector
            arreglo vector = new arreglo();
            do
            {
                // Se limpia la pantalla  
                Console.Clear();
                // Se muestra el menú de opciones
                Console.WriteLine("");
                Console.WriteLine("                  MENU DE ACTIVIDADES\n");
                Console.WriteLine("");
                Console.WriteLine("   a <== Insertar un elemento en el array.");
                Console.WriteLine("   b <== Eliminar un elemento del array.");
                Console.WriteLine("   c <== Borrar todos los elementos del array.");
                Console.WriteLine("");
                Console.WriteLine("   d <== Mostrar el número mayor dentro del array.");
                Console.WriteLine("   e <== Mostrar el número menor dentro del array.");
                Console.WriteLine("   f <== Mostrar la media de los datos del array.");
                Console.WriteLine("   g <== Mostrar la mediana de los datos del array.");
                Console.WriteLine("   h <== Mostrar los datos del array en orden ascendente.");
                Console.WriteLine("   i <== Mostrar la desviación típica de los datos del array.");
                Console.WriteLine("   j <== Binarizar el array en base a un número n.");
                Console.WriteLine("");
                Console.WriteLine("   k <== Salir");
                Console.WriteLine("");
                // Se lee la opción seleccionada
                do
                {
                    Console.Write("      Escriba su Opción(a, b, c, d, e, f, g, h, i, j, k) ");
                    caracter = (Console.ReadLine() + " ")[0];
                }
                // Solo se aceptan los caracteres A, a, B, b, C, c, D, d, E, e, F, f, G, g, H, h, I, i, J, j, K y k
                while (!validos.Contains(caracter.ToString()));
                Console.WriteLine("\n");
                // Se direcciona a la respectiva acción dependiendo de la letra leida
                switch (caracter)
                {
                    case 'A':
                    case 'a':
                        Console.Write("  Escribe un número: ");
                        while (!int.TryParse(Console.ReadLine(), out n))
                        {
                            Console.Write(" ==X Esto no es un número entero X==\n   Escribe un número: ");
                        }
                        listaData = vector.AInserta(listaData, n);
                        break;
                    case 'B':
                    case 'b':
                        if (listaData.Length > 0) listaData = vector.BElimina(listaData);
                        else
                        {
                            Console.WriteLine("      La lista ya esta vacía.");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    case 'C':
                    case 'c':
                        if (listaData.Length > 0) listaData = vector.CBorra(listaData);
                        else
                        {
                            Console.WriteLine("      La lista ya esta vacía.");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    case 'D':
                    case 'd':
                        if (listaData.Length > 0)
                        {
                            n = vector.DMayor(listaData);
                            Console.WriteLine(" Mayor elemento: " + n);
                            Console.WriteLine("");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("      La lista esta vacía.");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    case 'E':
                    case 'e':
                        if (listaData.Length > 0)
                        {
                            n = vector.EMenor(listaData);
                            Console.WriteLine(" Menor elemento: " + n);
                            Console.WriteLine("");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("      La lista esta vacía.");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    case 'F':
                    case 'f':
                        if (listaData.Length > 0)
                        {
                            Double d = vector.FMedia(listaData);
                            Console.WriteLine(" Media aritmética: " + d);
                            Console.WriteLine("");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("      La lista esta vacía.");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    case 'G':
                    case 'g':
                        if (listaData.Length > 0)
                        {
                            Double d = vector.GMediana(listaData);
                            Console.WriteLine(" Mediana: " + d);
                            Console.WriteLine("");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("      La lista esta vacía.");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    case 'H':
                    case 'h':
                        Console.WriteLine(" Lista de elementos del vector: " + vector.HMostrar(listaData));
                        Console.Write("\n Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    case 'I':
                    case 'i':
                        if (listaData.Length > 0)
                        {
                            Double d = vector.IDesviacion(listaData);
                            Console.WriteLine(" La Desviación Típica: " + d);
                            Console.WriteLine("");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("      La lista esta vacía.");
                            Console.Write("\n Presione una tecla para continuar.");
                            Console.ReadKey();
                        }
                        break;
                    case 'J':
                    case 'j':
                        Console.Write("  Escribe el número para binarizar: ");
                        while (!int.TryParse(Console.ReadLine(), out n))
                        {
                            Console.Write(" ==X Esto no es un número entero X==\n   Escribe un número: ");
                        }
                        int[] listaDataBinarizada = vector.JBinariza(listaData, n);
                        Console.WriteLine("");
                        Console.WriteLine("  Lista binarizada de elementos del vector: " + vector.HMostrar(listaDataBinarizada));
                        Console.Write("\n Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
            // Permanece dentro del ciclo a menos que se pulse la letra 'K' o 'k' de salida
            while ((caracter != 'K') && (caracter != 'k'));
        }
    }
}
