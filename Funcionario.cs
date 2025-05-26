namespace Sistema_Empresarial_de_Funcionários
{
    public abstract class Funcionario //classe modelo
    {
        public string Cargo { get; set; }
        public string Nome { get; set; }
        public string Id { get; set; }
        public double SalarioBase { get; set; }
        public double Bonus { get; set; }

        public Funcionario(string cargo, string nome, string id, double salarioBase, double bonusPercentual = 0) //construtor da classe modelo
        {
            Cargo = cargo;
            Nome = nome;
            Id = id;
            SalarioBase = salarioBase;
            Bonus = bonusPercentual;
        }

        public abstract double CalcularSalario();
    }
}
