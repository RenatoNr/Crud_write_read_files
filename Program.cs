using read_write_files.models;

namespace read_write_files
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Product product = new();
            Console.WriteLine("*** CRUD C# - Leitura e escrita em arquivo *** /n/n");
            string option;
            do
            {

                Menu.MainMenu();

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        Menu.ListMenu();
                        break;

                    case "2":

                        var menu = Menu.CreateMenu();
                        product.Create(menu);

                        break;
                    case "3":

                        Menu.UpdateMenu();                        
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Deletar um produto\n\n");
                        Console.WriteLine("Insira o ID");

                        var idToDelete = Console.ReadLine();

                        product.Delete(idToDelete);

                        break;
                    default:
                        break;
                }
            } while (option != "0");
        }
    }
}