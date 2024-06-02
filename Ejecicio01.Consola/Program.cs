using Ejercicio01.Datos;
using Ejercicio01.Entidades;
using MiDLL;
namespace Ejecicio01.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creacion de Equipos");
            string nombreEquipo = ConsoleExtensions.ReadString("Ingrese el nombre del equipo:");
            int cantidadJugadores = ConsoleExtensions.ReadInt("Ingrese la cantidad de Jugadores del equipo:");
            Equipo equipo = CrearEquipo(nombreEquipo, cantidadJugadores);
            ContratarJugadores(equipo);
            MostrarDatosDelEquipo(equipo);
            ConsoleExtensions.EsperarPresionDeTecla();
        }

        private static void MostrarDatosDelEquipo(Equipo equipo)
        {
            Console.WriteLine((string)equipo);
        }

        private static void ContratarJugadores(Equipo equipo)
        {
            do
            {
                Jugador jugador = CrearJugador();
                if (equipo+jugador)
                {
                    Console.WriteLine($"{jugador.MostrarDatos()} contratado");
                }
                else
                {
                    Console.WriteLine($"Jugador existente o no hay cupo");
                }

            } while (equipo.GetCantidad()<equipo.GetCantidadJugadores());
        }

        private static Jugador CrearJugador()
        {
            var dni = ConsoleExtensions.ReadInt("Ingrese el DNI:");
            var nombre = ConsoleExtensions.ReadString("Ingrese el nombre del jugador:");
            return new Jugador(dni, nombre);
        }

        private static Equipo CrearEquipo(string nombreEquipo, int cantidadJugadores)
        {
            return new Equipo(nombreEquipo, cantidadJugadores);
        }
    }
}
