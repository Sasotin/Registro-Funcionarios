namespace Sistema_Empresarial_de_Funcionários
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool executando = true;
            while (executando)
            {
                Servicos.Dialogos
                    ("""
                    ---Selecione uma opção---
                    -------------------------
                    1. Adicionar Funcionário.
                    2. Listar Funcionários.
                    3. Remover Funcionário.
                    4. Calcular Folha Salarial.
                    5. Sair.
                    """, ConsoleColor.DarkCyan);
                Servicos.Separacao();

                var opcoes = Console.ReadLine();

                switch (opcoes)
                {
                    case "1":
                        Servicos.Separacao();
                        Servicos.AdicionarFuncionario();
                        break;
                    case "2":
                        Servicos.Separacao();
                        Servicos.ListarFuncionarios();
                        break;
                    case "3":
                        Servicos.Separacao();
                        Servicos.RemoverFuncionario();
                        break;
                    case "4":
                        Servicos.Separacao();
                        Servicos.CalcularFolhaSalarial();
                        break;
                    case "5":
                        Servicos.Separacao();
                        executando = false;
                        break;
                    default:
                        Servicos.Dialogos("Opção inválida, tente novamente!", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}
