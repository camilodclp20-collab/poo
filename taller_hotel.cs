using System;
using System.Globalization;

namespace SistemaReservasHotel
{
    public class HabitacionHotel
    {
        //Atributos privados
        private int numero;
        private string tipo;
        private double precioPorNoche;
        private bool disponible;
        private string clienteActual;

        //  Propiedades públicas
        public int Numero
        {
            get { return numero; }
        }

        public string Tipo
        {
            get { return tipo; }
            set
            {
                if (value == "Individual" || value == "Doble" || value == "Suite")
                    tipo = value;
                else
                    throw new ArgumentException("Tipo inválido. Use: Individual, Doble o Suite.");
            }
        }

        public double PrecioPorNoche
        {
            get { return precioPorNoche; }
            set
            {
                if (value > 0)
                    precioPorNoche = value;
                else
                    throw new ArgumentException("El precio por noche debe ser mayor a 0.");
            }
        }

        public bool Disponible
        {
            get { return disponible; }
        }

        public string ClienteActual
        {
            get { return clienteActual; }
        }

        // Constructor
        public HabitacionHotel(int numero, string tipo, double precioPorNoche)
        {
            this.numero = numero;
            Tipo = tipo;                      
            PrecioPorNoche = precioPorNoche;  
            disponible = true;
            clienteActual = "";
        }

        // Métodos

        public double Reservar(string nombreCliente, int noches)
        {
            if (!disponible || noches <= 0 || string.IsNullOrWhiteSpace(nombreCliente))
                return -1;

            disponible = false;
            clienteActual = nombreCliente;
            return precioPorNoche * noches;
        }

        public bool Liberar()
        {
            if (disponible)
                return false;

            disponible = true;
            clienteActual = "";
            return true;
        }

        public string MostrarInfo()
        {
            CultureInfo cultura = new CultureInfo("es-CL");
            string info = $"Habitación {numero} | Tipo: {tipo} | Precio: ${precioPorNoche.ToString("N0", cultura)} por noche | ";
            info += disponible ? "Estado: Disponible" : $"Estado: Ocupada | Cliente: {clienteActual}";
            return info;
        }

        public void AplicarDescuento(int porcentaje)
        {
            if (porcentaje < 0)
                return;

            double nuevoPrecio = precioPorNoche - (precioPorNoche * porcentaje / 100.0);
            precioPorNoche = Math.Max(0, nuevoPrecio);
        }
    }

    class Program
    {
        static void MostrarEstado(HabitacionHotel[] habitaciones)
        {
            foreach (HabitacionHotel h in habitaciones)
                Console.WriteLine(h.MostrarInfo());
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            CultureInfo cultura = new CultureInfo("es-CL");

            HabitacionHotel h101 = new HabitacionHotel(101, "Individual", 50000);
            HabitacionHotel h202 = new HabitacionHotel(202, "Doble", 80000);
            HabitacionHotel h303 = new HabitacionHotel(303, "Suite", 150000);
            HabitacionHotel[] habitaciones = { h101, h202, h303 };

            Console.WriteLine("=== ESTADO INICIAL ===");
            MostrarEstado(habitaciones);

            // 3. Simulación de acciones
            Console.WriteLine("=== OPERACIONES ===");

            double total = h303.Reservar("Deymar Lopez", 1);
            Console.WriteLine($"Reserva 303 (Deymar Lopez, 1 noches): costo total ${total.ToString("N0", cultura)}");

            total = h202.Reservar("Luis Gómez", 2);
            Console.WriteLine($"Reserva 202 (Luis Gómez, 2 noches): costo total ${total.ToString("N0", cultura)}");

            total = h101.Reservar("Juan Gonzales", 2);
            if (total == -1)
                Console.WriteLine("Reserva 101 (Juan Gonzales): FALLÓ, la habitación está ocupada.");

            if (h202.Liberar())
                Console.WriteLine("Habitación 202 liberada correctamente.");

            h303.AplicarDescuento(10);
            Console.WriteLine($"Descuento del 10% aplicado a la 303. Nuevo precio: ${h303.PrecioPorNoche.ToString("N0", cultura)}");

            total = h202.Reservar("Carlos Ruiz", 1);
            Console.WriteLine($"Reserva 202 (Carlos Ruiz, 1 noche): costo total ${total.ToString("N0", cultura)}");
            Console.WriteLine();

                

            // Estado final
            Console.WriteLine("=== ESTADO FINAL ===");
            MostrarEstado(habitaciones);

            // Mensaje final
            int ocupadas = 0;
            foreach (HabitacionHotel h in habitaciones)
                if (!h.Disponible)
                    ocupadas++;

            Console.WriteLine($"Habitaciones ocupadas: {ocupadas} de {habitaciones.Length}");
        }
    }
}
