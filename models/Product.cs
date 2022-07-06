using read_write_files.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace read_write_files.models
{
    internal class Product : Base, IProduct
    {
        public string IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        private const string path = "database/product.csv";

        public Product()
        {
            CreateFolderAndFile(path);
        }

        private static string Prepareline(Product product)
        {
            return $"{product.IdProduct};{product.Name};{product.Description};{product.Price}";
        }

        public List<Product> ReadAll()
        {
            List<Product> products = new List<Product>();
           string[] lines = File.ReadAllLines(path);

            foreach (var item in lines)
            {
                string[] line = item.Split(";");

                Product product = new Product()
                {
                    IdProduct = line[0],
                    Name = line[1],
                    Description = line[2],
                    Price = Convert.ToDecimal( line[3])
                };

                products.Add(product);
            }

            return products;
        }

        public void Create(Product product)
        {
            string[] line = {Prepareline(product)};
            File.AppendAllLines(path, line);
        }

        public string findProduct(string IdProduct)
        {
            List<string> lines = ReadAllLinesCSV(path);
                        
            string found = lines.Find(a=>a.Split(";")[0] == IdProduct);

            Console.WriteLine("Produto encontrado: "+found);
               
            return found;
        }
               

        public void Update(Product product)
        {
            string line =  Prepareline(product) ;
            List<string> lines = ReadAllLinesCSV(path);

            int index = lines.FindIndex(a => a.Contains(product.IdProduct));

            if(index != -1)
            {
                lines[index] = line;
            }

           
            RewriteCSV(path, lines);
            
        }

        public void Delete(string idProduct)
        {
            List<string> lines = ReadAllLinesCSV(path);
            lines.RemoveAll(x => x.Split(";")[0] == Convert.ToString(idProduct));

            RewriteCSV(path, lines);

        }
    }
}
