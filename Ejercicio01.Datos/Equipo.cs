using Ejercicio01.Entidades;
using System.Text;

namespace Ejercicio01.Datos
{
    public class Equipo
    {
        private int cantidadJugadores;
        private List<Jugador>? jugadores;
        private string nombre=null!;
        private Equipo()
        {
            jugadores= new List<Jugador>();
        }
        public Equipo(string nombreE, int cantidad):this()
        {
            nombre = nombreE;
            cantidadJugadores=cantidad>0?cantidad:3;
        }
        public int GetCantidadJugadores() => cantidadJugadores;
        public static bool operator +(Equipo e, Jugador j)
        {
            if (e is null || j is null) return false;
            if (e.jugadores?.Count==e.GetCantidadJugadores())
            {
                return false;
            }
            if (e!=j)
            {
                e.jugadores?.Add(j);
                return true;
            }
            return false;
        }
        public static bool operator ==(Equipo e, Jugador j)
        {
            if (e is null || j is null) return false;
            if (e.jugadores is null)
            {
                return false;
            }
            if (e.GetCantidadJugadores()==0)
            {
                return false;
            }
            if (e.jugadores.Contains(j))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static explicit operator string(Equipo e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Equipo:{e.nombre}");
            sb.AppendLine($"(Jugadores):");
            string jugadoresEquipo = string.Empty;
            if (e.jugadores != null && e.jugadores.Any())
            {
                jugadoresEquipo = string.Join(Environment.NewLine,
                    e.jugadores.Select(j => j.MostrarDatos()));
            }
            else
            {
                jugadoresEquipo = "Sin Jugadores";
            }
            sb.AppendLine(jugadoresEquipo);
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Equipo equipo))return false;
            if (nombre != equipo.nombre) return false;
            
            if(GetCantidadJugadores()!=equipo.GetCantidadJugadores()) return false;

            return nombre==equipo.nombre && 
                GetCantidadJugadores()==equipo.GetCantidadJugadores() &&
                jugadores.SequenceEqual(equipo.jugadores);

        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash += 23 * nombre.GetHashCode();
                if (jugadores is not null)
                {
                    foreach (var j in jugadores)
                    {
                        hash += 23 * j.GetHashCode();
                    }

                }
                return hash;
            }
        }

        public int GetCantidad() => jugadores?.Count??0;
    }
}
