namespace JVMGYM.Entidades
{
    public class ClientesMembresia
    {
        private int _idClienteMembresia;
        private int _idCliente;
        private int _idMembresia;
        private Membresias _membresias = null!;
        private Clientes _clientes = null!;
        private DateOnly _inicio;
        private DateOnly _fin;
        private bool _activo;

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }


        public DateOnly Fin
        {
            get { return _fin; }
            set { _fin = value; }
        }

        public DateOnly Inicio
        {
            get { return _inicio; }
            set { _inicio = value; }
        }


        public Membresias Membresias
        {
            get { return _membresias; }
            set {
                if (value is null)
                {
                    throw new ArgumentNullException("La membresia no puede ser nula");
                }
                _membresias = value; }
        }

        public int IdMembresia
        {
            get { return _idMembresia; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser igual o menor a cero");
                }
                _idMembresia = value; }
        }

        public Clientes Cliente
        {
            get { return _clientes = null!; }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("El estudiante no puede ser nulo");
                }
                _clientes = value;
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

        public int IdClienteMembresia
        {
            get { return _idClienteMembresia; }
            set { _idClienteMembresia = value; }
        }

    }
}
