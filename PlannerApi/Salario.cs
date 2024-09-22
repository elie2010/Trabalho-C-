    public class Salario {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal SalBruto { get; set; }
        public decimal SalarioLiq { get; private set; }
        public decimal SalarioAnteriores { get; set; }
        public decimal Fgst { get; private set; }
        public decimal Horastrab { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Inss { get; private set; }
        public decimal Ir { get; private set; }

        public void CalcularSalario()
        {
            SalBruto = Horastrab * ValorHora;
            CalcularInss();
            CalcularIr();
            calcularFgts();
            SalarioLiq = SalBruto - Inss - Ir;
        }

        private void CalcularIr()
        {
            if (SalBruto <= 1372.81m)
            {
                Ir = 0;
            }
            else if (SalBruto <= 2743.25m)
            {
                Ir = SalBruto * 0.15m;
            }
            else
            {
                Ir = SalBruto * 0.275m;
            }
        }

        private void CalcularInss()
        {
            if (SalBruto <= 868.29m)
            {
                Inss = SalBruto * 0.08m;
            }
            else if (SalBruto <= 1447.14m)
            {
                Inss = SalBruto * 0.09m;
            }
            else if (SalBruto <= 2894.27m)
            {
                Inss = SalBruto * 0.11m;
            }
            else
            {
                Inss = 318.37m;
            }
        }

        private void calcularFgts()
        {
            Fgst = SalBruto * 0.08m;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Id: {Id}, Salário Bruto: R${SalBruto}, Salário Líquido: R${SalarioLiq}";
        }
    }
