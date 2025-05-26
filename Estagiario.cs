namespace Sistema_Empresarial_de_Funcionários
{
    public class Estagiario : Funcionario
    {
        public Estagiario(string cargo, string nome, string id, double salarioBase) : base(cargo, nome, id, salarioBase) { }

        public override double CalcularSalario()
        {
            return SalarioBase;
        }
    }
}
