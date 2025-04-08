namespace Biblioteca
{
    public class Livro
    {
        private string _titulo;
        private string _subTitulo;
        private string _escritor;
        private string _editora;
        private string _genero;
        private int _anoPublicacao;
        private string _tipoDaCapa;
        private int _numeroDePaginas;
        
        public string Isbn { get; init; }

        public Livro(string isbn, string titulo, string subTitulo, string escritor, 
                    string editora, string genero, int anoPublicacao, 
                    string tipoDaCapa, int numeroDePaginas)
        {
            Isbn = isbn;
            Titulo = titulo;
            SubTitulo = subTitulo;
            Escritor = escritor;
            Editora = editora;
            Genero = genero;
            AnoPublicacao = anoPublicacao;
            TipoDaCapa = tipoDaCapa;
            NumeroDePaginas = numeroDePaginas;
        }

        public string Titulo
        {
            get => _titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Título não pode ser vazio ou nulo.");
                    
                _titulo = value.Trim();
            }
        }

        public string SubTitulo
        {
            get => _subTitulo;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O subtitulo não pode ser nulo");
                }
                _subTitulo = value.Trim();
            }
        }

        public string Escritor
        {
            get => _escritor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Escritor não pode ser vazio ou nulo.");
                    
                _escritor = value.Trim();
            }
        }

        public string Editora
        {
            get => _editora;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Editora não pode ser vazio ou nulo.");
                    
                _editora = value.Trim();
            }
        }

        public string Genero
        {
            get => _genero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Gênero não pode ser vazio ou nulo.");
                    
                _genero = value.Trim();
            }
        }

        public int AnoPublicacao
        {
            get => _anoPublicacao;
            set
            {
                int anoAtual = DateTime.Now.Year;
                if (value < 1970 || value > anoAtual)
                    throw new ArgumentException($"Ano deve estar entre 1970 e {anoAtual}.");
                    
                _anoPublicacao = value;
            }
        }

        public string TipoDaCapa
        {
            get => _tipoDaCapa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tipo da capa não pode ser vazio ou nulo.");
                    
                _tipoDaCapa = value.Trim();
            }
        }

        public int NumeroDePaginas
        {
            get => _numeroDePaginas;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Número de páginas deve ser positivo.");
                    
                _numeroDePaginas = value;
            }
        }
    }
}