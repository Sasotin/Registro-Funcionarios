namespace Sistema_de_Funcionários
{
    public class Servicos
    {

        public static List<Funcionario> listaDeFuncionarios = new List<Funcionario>(); //cria a lista onde os funcionários serão armazenados

        public static void Separacao()
        {
            string separacao = "---------------------------------------";
            Console.WriteLine(separacao);
        }

        private static bool ExistemFuncionarios() //método para verificar a existencia de funcionarios na lista
        {
            if (listaDeFuncionarios.Count == 0)
            {
                Dialogos("Não existem funcionários cadastrados ainda!", ConsoleColor.Red);
                return false;
            }
            return true;
        }

        private static string GeradorId(List<Funcionario> lista) //método que verifica se já existe um id igual na lista ao gerar um novo id
        {
            Random rand = new Random();
            string idGerado;
            bool idExiste;

            do
            {
                string primeiraParte = rand.Next(1000, 9999).ToString();
                string segundaParte = rand.Next(1000, 9999).ToString();
                idGerado = $"{primeiraParte}-{segundaParte}";
                idExiste = listaDeFuncionarios.Exists(funcionario => funcionario.Id == idGerado);
            }
            while (idExiste);

            return idGerado;
        }

        public static void Dialogos(string Dialogo, ConsoleColor Cor) //método para formatação dos diálogos
        {
            Console.ForegroundColor = Cor;
            Console.WriteLine($"\n{Dialogo}");
            Console.ResetColor();
        }

        public static void AdicionarFuncionario() //método para adicionar novos funcionários à lista
        {
            string cargo = string.Empty;

            while (true)
            {
                Dialogos("""
                    Cargo do funcionário:
                    1. Estagiário.
                    2. Programador.
                    3. Gerente.
                    """, ConsoleColor.Cyan);
                Separacao();

                var escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Separacao();
                        cargo = "Estagiário";
                        break;
                    case "2":
                        Separacao();
                        cargo = "Programador";
                        break;
                    case "3":
                        Separacao();
                        cargo = "Gerente";
                        break;
                    default:
                        Dialogos("OPÇÃO INVÁLIDA! TENTE NOVAMENTE!", ConsoleColor.Red);
                        break;
                }

                if (escolha == "1" || escolha == "2" || escolha == "3")
                {
                    break;
                }
            }

            string nome;
            do
            {
                Dialogos("Nome do funcionário: ", ConsoleColor.Cyan);
                nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome))
                {
                    Dialogos("NOME NÃO PODE ESTAR VAZIO!", ConsoleColor.Red);
                }
            }
            while (string.IsNullOrEmpty(nome));

            double salarioBase;
            while (true)
            {
                Dialogos("Salario Base: R$ ", ConsoleColor.Cyan);
                string inputSalarioBase = Console.ReadLine();

                if (double.TryParse(inputSalarioBase, out salarioBase) && salarioBase > 0)
                {
                    break;
                }
                else
                {
                    Dialogos("SALÁRIO BASE DEVE SER MAIOR QUE ZERO!", ConsoleColor.Red);
                }
            }

            double bonus;
            if (cargo == "Estagiário")
            {
                bonus = 0;
            }
            else
            {
                while (true)
                {
                    Dialogos("Bonus: R$ ", ConsoleColor.Cyan);
                    bonus = Convert.ToDouble(Console.ReadLine());

                    if (bonus >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Dialogos("BONUS INVÁLIDO!", ConsoleColor.Red);
                    }
                }
            }

            string id = GeradorId(listaDeFuncionarios);
            Dialogos($"Id do funcionário: {id}", ConsoleColor.Cyan);

            try
            {
                if (cargo == "Estagiário")
                {
                    Funcionario novoFuncionario = new Estagiario(cargo, nome, id, salarioBase);
                    listaDeFuncionarios.Add(novoFuncionario);
                    Dialogos("Novo funcionário adicionado com sucesso!", ConsoleColor.Green);
                }
                else if (cargo == "Programador")
                {
                    Funcionario novoFuncionario = new Programador(cargo, nome, id, salarioBase, bonus);
                    listaDeFuncionarios.Add(novoFuncionario);
                    Dialogos("Novo funcionário adicionado com sucesso!", ConsoleColor.Green);
                }
                else if (cargo == "Gerente")
                {
                    Funcionario novoFuncionario = new Gerente(cargo, nome, id, salarioBase, bonus);
                    listaDeFuncionarios.Add(novoFuncionario);
                    Dialogos("Novo funcionário adicionado com sucesso!", ConsoleColor.Green);
                }
            }
            catch (Exception ex)
            {
                Dialogos($"ERRO AO ADICINAR FUNCIONÁRIO: {ex.Message}", ConsoleColor.Red);
            }
        }

        public static void ListarFuncionarios() //método para listar funcionários cadastrados
        {
            if (!ExistemFuncionarios())
            {
                return;
            }
            try
            {
                foreach (Funcionario f in listaDeFuncionarios)
                {
                    Dialogos($"""
                    CARGO: {f.Cargo}
                    NOME: {f.Nome}
                    ID: {f.Id}
                    SALÁRIO BASE: {f.SalarioBase:f2}
                    SALÁRIO COM BÔNUS: {f.CalcularSalario():f2}
                    """, ConsoleColor.DarkYellow);
                    Separacao();
                }
            }
            catch (Exception ex)
            {
                Dialogos($"ERRO: {ex.Message}", ConsoleColor.Red);
            }
        }

        public static void RemoverFuncionario()
        {
            if (!ExistemFuncionarios())
            {
                return;
            }
            try
            {  
                Dialogos("Digite o nome do funcionário ou seu Id: ", ConsoleColor.DarkGray);
                Separacao();
                string termoBusca = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(termoBusca))
                {
                    Dialogos("INSIRA NOME OU ID PARA BUSCAR!", ConsoleColor.Red);
                    return;
                }

                Funcionario funcionarioEncontrado = listaDeFuncionarios.Find(f => f.Nome.Equals(termoBusca, StringComparison.OrdinalIgnoreCase) || f.Id.Replace(" ", "").Replace("-", "").Equals(termoBusca.Replace(" ", "").Replace("-", ""), StringComparison.OrdinalIgnoreCase));

                if (funcionarioEncontrado != null)
                {
                    listaDeFuncionarios.Remove(funcionarioEncontrado);
                    Dialogos($"Funcionário {funcionarioEncontrado.Nome}, ID: {funcionarioEncontrado.Id} removido com sucesso", ConsoleColor.Green);
                }
                else
                {
                    Dialogos("Funcionário não encontrado!", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Dialogos($"ERRO: {ex.Message}", ConsoleColor.Red);
            }
        }

        public static void CalcularFolhaSalarial() //método para calcular a folha salarial dos funcionários
        {
            if (!ExistemFuncionarios())
            {
                return;
            }
            try
            {
                double totalSalarios = listaDeFuncionarios.Sum(f => f.CalcularSalario());
                Dialogos($"FOLHA SALARIAL TOTAL: R$ {totalSalarios:f2}", ConsoleColor.DarkMagenta);
            }
            catch (Exception ex)
            {
                Dialogos($"ERRO: {ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
