using System.Text.Json;

namespace Sistema_de_Funcionários
{
    public class RepositorioFuncionarios
    {
        private static readonly string meusDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Armazena o caminho para a pasta "Meus Documentos" do usuário
        private static readonly string caminhoRepositorio = Path.Combine(meusDocs, "RepositorioFuncionarios.json"); // Define o caminho completo do arquivo JSON

        public static List<Funcionario> Carregar()
        {
            try
            {
                if (!File.Exists(caminhoRepositorio)) // Se o arquivo não existir, retorna lista vazia (evita erro na primeira execução)
                {
                    return new List<Funcionario>();
                }

                string json = File.ReadAllText(caminhoRepositorio); // Lê e desserializa o arquivo JSON
                return JsonSerializer.Deserialize<List<Funcionario>>(json) ?? new List<Funcionario>(); // Se a desserialização retornar null, retorna lista vazia   
            }
            catch
            {
                return new List<Funcionario>(); // Em caso de qualquer erro (arquivo corrompido, permissões, etc), retorna lista vazia
            }
        }

        public static void Salvar(List<Funcionario> funcionarios) //salva a lista recebida como parametro
        {
            try
            {
                string json = JsonSerializer.Serialize(funcionarios); // Serializa a lista de funcionários para formato JSON
                File.WriteAllText(caminhoRepositorio, json); // Grava o JSON no arquivo (sobrescreve se já existir)
            }
            catch (Exception ex)
            {
                Servicos.Dialogos($"Erro ao salvar: {ex.Message}!", ConsoleColor.Magenta); // Mostra erro amigável ao usuário
            }
        }
    }
}
