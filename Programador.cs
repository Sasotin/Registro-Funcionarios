namespace Sistema_de_Funcionários
{
    internal class Programador : Funcionario
    {
        public Programador(string cargo, string nome, string id, double salarioBase, double bonusPercentual) : base(cargo, nome, id, salarioBase, bonusPercentual) { }

        public override double CalcularSalario() // Faz o cálculo do salário acrescido do bônus
        {
            return SalarioBase + Bonus;
        }
    }
}
