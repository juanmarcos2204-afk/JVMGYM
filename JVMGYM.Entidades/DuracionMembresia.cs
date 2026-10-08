namespace JVMGYM.Entidades
{
    public class DuracionMembresia
    {
        private int _idDuracionMembresia;
        private string _nombre;
        public ICollection<Membresia> Membresias = new List<Membresia>();
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

        public int IdDuracionMembresia
        {
            get { return _idDuracionMembresia; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser igual o menor a cero");
                }
                _idDuracionMembresia = value;
            }
        }
       

    }
}
