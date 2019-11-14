namespace ControleEmpresarial.UI.Models
{
    public class DataPointViewModel
    {
        public DataPointViewModel(string y, int a, int b)
        {
            this.y = y;
            this.a = a;
            this.b = b;
        }

        public string y { get; set; }

        public int a { get; set; }

        public int b { get; set; }
    }
}