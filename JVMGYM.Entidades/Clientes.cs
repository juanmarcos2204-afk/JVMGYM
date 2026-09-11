namespace JVMGYM.Entidades
{
    public class Clientes
    {
        private int _Idcliente;
        private string _nombre = null!;
        private string _apellido = null!;
        private string _dni = null!;
        private string _telefono = null!;
        private string? _domicilio;
        private DateOnly _fechaAlta;
        private List<ClientesMembresia>? _clientesMembresias;

        public List<ClientesMembresia>? ClientesMembresias
        {
            get { return _clientesMembresias; }
            set {_clientesMembresias = value; }
        }


        public DateOnly FechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }


        public string? Domicilio
        {
            get { return _domicilio; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("El número de telefono no puede ser nulos ni tener espacios en blanco");
                }
                _domicilio = value;
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("El número de telefono no puede ser nulos ni tener espacios en blanco");
                }
                _telefono = value;
            }
        }


        public string DNI
        {
            get { return _dni; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Los datos ingresados no deben ser nulos ni tener espacios en blanco");

                }
                _dni = value;
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Los datos ingresados no deben ser nulos ni tener espacios en blanco");
                }
                _apellido = value;
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Los datos ingresados no deben ser nulos ni tener espacios en blanco");
                }
                _nombre = value;
            }
        }


        public int IdCliente
        {
            get { return _Idcliente; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("El Id no puede ser menor a cero");
                }
                _Idcliente = value;
            }
        }

    }
}
