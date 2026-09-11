namespace JVMGYM.Entidades
{
    public class Pagos
    {
        private int _idPago;
        private int _idCliente;
        private int _idMetodoPago;
        private Clientes _clientes = null!;
        private MetodosDePago _metodosDePago = null!;
        private DateOnly _fecha;

        public DateOnly Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public MetodosDePago MetodosDePago
        {
            get { return _metodosDePago; }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("El Metodo de pago no puede ser nulo");
                }
                _metodosDePago = value;
            }
        }

        public Clientes Clientes
        {
            get { return _clientes; }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("El cliente no puede ser nulo");
                }
                _clientes = value;
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


        public int IdCliente
        {
            get { return _idCliente; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser igual o menor a cero");
                }
                _idCliente = value;
            }
        }


        public int IdPago
        {
            get { return _idPago; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser igual o menor a cero");
                }
                _idPago = value;
            }
        }

    }
}
