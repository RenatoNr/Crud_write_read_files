using read_write_files.models;
using System;

class Menu
{
	public Menu()
	{
	}

	public static void MainMenu()
    {
        

        Console.WriteLine("\nEscolha uma das opções abaixo:\n");
        Console.WriteLine("1 - Listar produtos");
        Console.WriteLine("2 - Cadastrar produto");
        Console.WriteLine("3 - Editar produto");
        Console.WriteLine("4 - Excluir produto");
        Console.WriteLine("0 - Sair da aplicação\n");
    }

    public static void ListMenu()
    {
        Console.Clear();
        Console.WriteLine("Listando todos os produtos");
        Product product = new Product();
        List<Product> allProducts = product.ReadAll();

        if (allProducts.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        else
        {
            foreach (Product oneProduct in allProducts)
            {
                Console.WriteLine($"[{oneProduct.IdProduct}] {oneProduct.Name} - {oneProduct.Description} - R$ {oneProduct.Price}");
            }
        }
    }

    public  static Product CreateMenu()
    {

        Console.Clear();
        Console.WriteLine("Cadastrar novo produto");
        //Console.WriteLine("\nDigite o código do produto:\n");
       // var id = Console.ReadLine();
        Console.WriteLine("\nDigite o nome do produto:\n");
        var name = Console.ReadLine();
        Console.WriteLine("\nDigite a descrição do produto:\n");
        var description = Console.ReadLine();
        Console.WriteLine("\nDigite o preço do produto:\n");
        var price = Console.ReadLine();

        Product newProduct = new Product()
        {
           // IdProduct = id,
            Name = name,
            Description = description,
            Price = Convert.ToDecimal(price),
        };

        return newProduct;
    }

    public static void UpdateMenu()
    {

        Product product = new Product();

        Console.Clear();
        Console.WriteLine("Editar produto");
        Console.WriteLine("\nDigite o código do produto:\n");
        var uId = Console.ReadLine();
        var found = product.findProduct(uId);

        if (found == null)
        {
            Console.WriteLine("Produto não encontrado!");
            return; 
        }

        string[] productFounded = found.Split(';');

        var uProduct = new Product();

        if (found != null)
        {
            Console.WriteLine($"Nome atual do produto: {productFounded[1]}");
            Console.Write("Insira o novo nome ou pressione Enter para manter o atual: ");
            var newName = Console.ReadLine();
            uProduct.Name = newName.Length != 0 ? newName : productFounded[1];

            Console.WriteLine($"Descrição atual do produto: {productFounded[2]} ");
            Console.Write("Insira a nova Descrição ou pressione Enter para manter a atual: ");
            var newDescription = Console.ReadLine();
            uProduct.Description = newDescription.Length != 0 ? newDescription : productFounded[2];

            Console.WriteLine($"Preço atual do produto: R$ {productFounded[3]} ");
            Console.Write("Insira o novo Preço ou pressione Enter para manter o atual: ");
            var newPrice = Console.ReadLine();

            uProduct.Price = newPrice.Length != 0 ? Convert.ToDecimal(newPrice)
                : Convert.ToDecimal(productFounded[3]);
            uProduct.IdProduct = uId;
        }


        Console.WriteLine($"[{uProduct.IdProduct}] {uProduct.Name} - {uProduct.Description} R$ {uProduct.Price}");

        product.Update(uProduct);
    }
}
