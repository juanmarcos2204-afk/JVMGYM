namespace JVMGYM.Entidades
{
    public class Membresia
    {
        private int _idMembresia;
        private string _tipo = null!;
        private decimal _precio;
        private int _idDuracionMembresia;

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
        public DuracionMembresia? DuracionMembresia { get; set; }
        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El precio no puede ser igual o menor a cero");
                }
                _precio = value;
            }
        }

        public string Tipo
        {
            get { return _tipo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("El tipo de membresia no puede ser nula");
                }
                _tipo = value;
            }
        }

        public int IdMembresia
        {
            get { return _idMembresia; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser igual o menor a cero");
                }
                _idMembresia = value;
            }
        }


    }
}
