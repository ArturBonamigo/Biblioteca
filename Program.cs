// Artur Bonamigo
// Felipe Bueno
// Gustavo Vieira Walter

namespace Biblioteca;

internal class Program
{
    public static List<Leitor> Leitores = new List<Leitor>();
    static List<Livro> Livros = new List<Livro>();
    
    public void CadastrarLivro()
    {
        try
        {
            Console.Write("Digite o ISBN do livro: ");
            string isbn = Console.ReadLine() ?? "";

            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine() ?? "";

            Console.Write("Digite o subtítulo: ");
            string subtitulo = Console.ReadLine() ?? "";

            Console.Write("Digite o nome do escritor: ");
            string escritor = Console.ReadLine() ?? "";

            Console.Write("Digite a editora: ");
            string editora = Console.ReadLine() ?? "";

            Console.Write("Digite o gênero: ");
            string genero = Console.ReadLine() ?? "";

            Console.Write("Digite o ano de publicação: ");
            if (!int.TryParse(Console.ReadLine(), out int anoPublicacao))
                throw new ArgumentException("Ano de publicação inválido.");

            Console.Write("Digite o tipo de capa (Brochura/Dura): ");
            string tipoDaCapa = Console.ReadLine() ?? "";

            Console.Write("Digite o número de páginas: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroDePaginas))
                throw new ArgumentException("Número de páginas inválido.");

            Livro novoLivro = new Livro(isbn, titulo, subtitulo, escritor, editora, 
                                      genero, anoPublicacao, tipoDaCapa, numeroDePaginas);
            Livros.Add(novoLivro);

            Console.WriteLine("Livro cadastrado com sucesso!\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}\n");
        }
    }

    public void CadastrarLeitor()
    {
        try
        {
            Console.Write("Digite o nome do leitor: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Digite a idade do leitor: ");
            if (!byte.TryParse(Console.ReadLine(), out byte idade))
                throw new ArgumentException("Idade inválida.");

            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine() ?? "";

            Leitores.Add(new Leitor(nome, idade, cpf));
            Console.WriteLine("Leitor cadastrado com sucesso!\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}\n");
        }
    }
    
    public void ListarLeitores()
    {
        Console.WriteLine("\n------ Lista de Leitores ------");
        foreach (var leitor in Leitores)
        {
            Console.WriteLine($"{leitor.Nome}, {leitor.Idade} anos, CPF: {leitor.Cpf}");
        }
        Console.WriteLine("-------------------------------\n");
    }

    public void EditarLeitor()
    {
        try
        {
            Console.Write("Digite o CPF do leitor que você quer editar: ");
            string cpf = Console.ReadLine() ?? "";

            Leitor leitorEncontrado = Leitores.Find(leitor => leitor.Cpf == cpf);
        
            if (leitorEncontrado == null)
            {
                Console.WriteLine("Leitor não encontrado!\n");
                return;
            }

            Console.Write("Digite o novo nome: ");
            leitorEncontrado.Nome = Console.ReadLine() ?? "";

            Console.Write("Digite a nova idade: ");
            if (byte.TryParse(Console.ReadLine(), out byte novaIdade))
            {
                leitorEncontrado.Idade = novaIdade;
                Console.WriteLine("Leitor atualizado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Idade inválida!\n");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}\n");
        }
    }

    public void ExcluirLeitor()
    {
        try
        {
            Console.Write("Digite o CPF do leitor que deseja excluir: ");
            string cpf = Console.ReadLine() ?? "";

            Leitor leitorEncontrado = Leitores.Find(leitor => leitor.Cpf == cpf);

            if (leitorEncontrado == null)
            {
                Console.WriteLine("Leitor não encontrado!\n");
                return;
            }

            Leitores.Remove(leitorEncontrado);
            Console.WriteLine("Leitor excluído com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }

    public void AdicionarLivro()
    {
        try
        {
            Console.Write("Digite o CPF do leitor que quer adicionar um livro: ");
            string cpf = Console.ReadLine() ?? "";

            Leitor leitorEncontrado = Leitores.Find(leitor => leitor.Cpf == cpf);
            
            if (leitorEncontrado == null)
            {
                Console.WriteLine("Leitor não encontrado!\n");
                return;
            }

            Console.Write("Digite o ISBN do livro: ");
            string isbn = Console.ReadLine() ?? "";

            Livro livroEncontrado = Livros.Find(livro => livro.Isbn == isbn);

            if (livroEncontrado == null)
            {
                Console.WriteLine("Livro não encontrado!\n");
                return;
            }

            leitorEncontrado.AdicionarLivro(livroEncontrado);
            Console.WriteLine("Livro adicionado com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }

    public void RemoverLivro()
    {
        try
        {
            Console.Write("Digite o CPF do leitor que deseja remover um livro: ");
            string cpf = Console.ReadLine() ?? "";

            Leitor leitorEncontrado = Leitores.Find(leitor => leitor.Cpf == cpf);
            
            if (leitorEncontrado == null)
            {
                Console.WriteLine("Leitor não encontrado!\n");
                return;
            }

            if (leitorEncontrado.LivrosLeitor.Count == 0)
            {
                Console.WriteLine("Este leitor não possui livros para remover.\n");
                return;
            }

            Console.WriteLine("\nLivros disponíveis para remoção:");
            for (int i = 0; i < leitorEncontrado.LivrosLeitor.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {leitorEncontrado.LivrosLeitor[i].Titulo} (ISBN: {leitorEncontrado.LivrosLeitor[i].Isbn})");
            }

            Console.Write("Digite o número do livro que deseja remover: ");
            if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > leitorEncontrado.LivrosLeitor.Count)
            {
                Console.WriteLine("Escolha inválida!\n");
                return;
            }

            Livro livroRemovido = leitorEncontrado.LivrosLeitor[escolha - 1];
            leitorEncontrado.RemoverLivro(livroRemovido);

            Console.WriteLine($"Livro '{livroRemovido.Titulo}' removido da coleção de {leitorEncontrado.Nome} com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }

    public void DoarLivro()
    {
        try
        {
            Console.Write("Digite o CPF do leitor que deseja doar um livro: ");
            string cpfDoador = Console.ReadLine() ?? "";

            Leitor leitorDoador = Leitores.Find(leitor => leitor.Cpf == cpfDoador);
            if (leitorDoador == null)
            {
                Console.WriteLine("Leitor doador não encontrado!\n");
                return;
            }

            if (leitorDoador.LivrosLeitor.Count == 0)
            {
                Console.WriteLine("O doador não possui livros para doar.\n");
                return;
            }

            Console.WriteLine("\nLivros disponíveis para doação:");
            for (int i = 0; i < leitorDoador.LivrosLeitor.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {leitorDoador.LivrosLeitor[i].Titulo} (ISBN: {leitorDoador.LivrosLeitor[i].Isbn})");
            }

            Console.Write("Digite o número do livro que deseja doar: ");
            if (!int.TryParse(Console.ReadLine(), out int escolha) || escolha < 1 || escolha > leitorDoador.LivrosLeitor.Count)
            {
                Console.WriteLine("Escolha inválida!\n");
                return;
            }

            Livro livroDoado = leitorDoador.LivrosLeitor[escolha - 1];

            Console.Write("Digite o CPF do leitor que receberá o livro: ");
            string cpfDestinatario = Console.ReadLine() ?? "";

            var destinatario = Leitores.Find(leitor => leitor.Cpf == cpfDestinatario);
            if (destinatario == null)
            {
                Console.WriteLine("Leitor destinatário não encontrado!\n");
                return;
            }

            leitorDoador.RemoverLivro(livroDoado);
            destinatario.AdicionarLivro(livroDoado);

            Console.WriteLine($"Livro '{livroDoado.Titulo}' doado de {leitorDoador.Nome} para {destinatario.Nome} com sucesso!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }

    public void ListarLeitoresELivros()
    {
        Console.WriteLine("\n--- Leitores e seus Livros ---");
        foreach (var leitor in Leitores)
        {
            Console.WriteLine($"{leitor.Nome}, {leitor.Idade} anos, CPF: {leitor.Cpf}");
            if (leitor.LivrosLeitor.Count == 0)
            {
                Console.WriteLine("  Nenhum livro cadastrado.");
            }
            else
            {
                foreach (var livro in leitor.LivrosLeitor)
                {
                    Console.WriteLine($"  - {livro.Titulo} por {livro.Escritor} (ISBN: {livro.Isbn})");
                }
            }
        }
        Console.WriteLine("------------------------------\n");
    }

    public void ListarLeitorPorCPF()
    {
        try
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine() ?? "";

            var leitor = Leitores.Find(leitor => leitor.Cpf == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado!\n");
                return;
            }

            Console.WriteLine($"\nLeitor: {leitor.Nome}, {leitor.Idade} anos, CPF: {leitor.Cpf}");
            Console.WriteLine("Livros do leitor:");
            if (leitor.LivrosLeitor.Count == 0)
            {
                Console.WriteLine("Nenhum livro encontrado.\n");
            }
            else
            {
                foreach (var livro in leitor.LivrosLeitor)
                {
                    Console.WriteLine($" - {livro.Titulo}, {livro.Escritor} (ISBN: {livro.Isbn})");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }

    public void PesquisarLivro()
    {
        try
        {
            Console.Write("Digite o ISBN ou título do livro que deseja buscar: ");
            string termoBusca = Console.ReadLine() ?? "";

            var leitor = Leitores.Find(leitor => 
                leitor.LivrosLeitor.Exists(livro => 
                    livro.Isbn.Equals(termoBusca, StringComparison.OrdinalIgnoreCase) || 
                    livro.Titulo.Equals(termoBusca, StringComparison.OrdinalIgnoreCase)));
            
            if (leitor == null)
            {
                Console.WriteLine("Nenhum leitor possui esse livro.\n");
                return;
            }

            var livroEncontrado = leitor.LivrosLeitor.Find(livro => 
                livro.Isbn.Equals(termoBusca, StringComparison.OrdinalIgnoreCase) || 
                livro.Titulo.Equals(termoBusca, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nLivro encontrado: {livroEncontrado.Titulo}, {livroEncontrado.Escritor}");
            Console.WriteLine($"ISBN: {livroEncontrado.Isbn}");
            Console.WriteLine($"Está com: {leitor.Nome}, CPF: {leitor.Cpf}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}\n");
        }
    }

    private static void Main(string[] args)
    {
        Program programa = new Program();

        int opcao = -1;

        while (opcao != 0)
        {
            Console.WriteLine("");
            Console.WriteLine("=================== MENU ===================");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Cadastrar Leitor");
            Console.WriteLine("3 - Listar Leitores");
            Console.WriteLine("4 - Editar Leitor");
            Console.WriteLine("5 - Excluir Leitor");
            Console.WriteLine("6 - Adicionar Livro a um Leitor");
            Console.WriteLine("7 - Remover Livro de um Leitor");
            Console.WriteLine("8 - Doar um Livro");            
            Console.WriteLine("9 - Listar todos os leitores e seus livros");
            Console.WriteLine("10 - Listar um leitor específico e seus livros");
            Console.WriteLine("11 - Pesquisar um livro e mostrar o leitor");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("============================================");
            Console.Write("Escolha uma opção: ");
            
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                try
                {
                    switch (opcao)
                    {
                        case 1:
                            programa.CadastrarLivro();
                            break;
                        case 2:
                            programa.CadastrarLeitor();
                            break;
                        case 3:
                            programa.ListarLeitores();
                            break;
                        case 4:
                            programa.EditarLeitor();
                            break;
                        case 5:
                            programa.ExcluirLeitor();
                            break;
                        case 6:
                            programa.AdicionarLivro();
                            break;
                        case 7:
                            programa.RemoverLivro();
                            break;
                        case 8:
                            programa.DoarLivro();
                            break;
                        case 9:
                            programa.ListarLeitoresELivros();
                            break;
                        case 10:
                            programa.ListarLeitorPorCPF();
                            break;
                        case 11:
                            programa.PesquisarLivro();
                            break;
                        case 0:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}\n");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida! Digite um número.\n");
            }
        }
    }
}