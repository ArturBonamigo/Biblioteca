namespace Biblioteca;

public class Leitor
{
    private string _nome;
    private string _cpf;
    private byte _idade;
    public List<Livro> LivrosLeitor { get; private set; }

    public Leitor(string nome, byte idade, string cpf)
    {
        Nome = nome;
        Idade = idade;
        Cpf = cpf;
        LivrosLeitor = new List<Livro>();
    }

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nome não pode ser vazio ou nulo.");
            
            _nome = value.Trim();
        }
    }

    public string Cpf
    {
        get => _cpf;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("CPF não pode ser vazio ou nulo.");
            
            if (Program.Leitores.Exists(Leitor => Leitor.Cpf == value))
                throw new ArgumentException("CPF já cadastrado.");
                
            _cpf = value.Trim();
        }
    }

    public byte Idade
    {
        get => _idade;
        set
        {
            if (value < 0)
                throw new ArgumentException("Idade não pode ser negativa.");
                
            _idade = value;
        }
    }

    public void AdicionarLivro(Livro livro)
    {
        LivrosLeitor.Add(livro);
    }

    public void RemoverLivro(Livro livro)
    {
        LivrosLeitor.Remove(livro);
    }
}