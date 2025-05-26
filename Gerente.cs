namespace Sistema_Empresarial_de_Funcionários
{
    public class Gerente : Funcionario
    {
        public Gerente(string cargo, string nome, string id, double salarioBase, double bonusPercentual) : base(cargo, nome, id, salarioBase, bonusPercentual) { }

        public override double CalcularSalario() // Faz o cálculo do salário acrescido do bônus
        {
            return SalarioBase + Bonus;
        }
    }
}
