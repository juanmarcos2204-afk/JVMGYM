namespace JVMGYM.Entidades
{
    public class MetodosDePago
    {
        private int _idMetodoPago;
        private string _nombre = null!;

        public string Nombre
        {
            get { return _nombre = null!; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("El nombre no puede ser nulo");
                }
                _nombre = value;
            }
        }


        public int IdMetodoPago
        {
            get { return _idMetodoPago; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser igual o menor a cero");
                }
                _idMetodoPago = value;
            }
        }

    }
}
