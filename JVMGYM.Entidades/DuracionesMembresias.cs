namespace JVMGYM.Entidades
{
    public class DuracionesMembresias
    {
        private int _duracionMembresia;
        private string _nombre = null!;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("El nombre de la membresia no puede ser nulo ni tener espacios en blanco");
                }
                _nombre = value;
            }
        }

        public int DuracionMembresia
        {
            get { return _duracionMembresia; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser igual o menor a cero");
                }
                _duracionMembresia = value;
            }
        }

    }
}
