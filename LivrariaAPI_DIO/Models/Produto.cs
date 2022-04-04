namespace LivrariaAPI_DIO.Models
{
    public class Produto : Entity
    {
        public Produto(
            string nome, 
            decimal preco, 
            int quantidade, 
            string categoria, 
            string img)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            Categoria = categoria;
            Img = img;
        }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }
        public string Categoria { get; private set; }
        public string Img { get; private set; }
    }
}
