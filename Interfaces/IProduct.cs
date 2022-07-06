using read_write_files.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace read_write_files.Interfaces
{
    internal interface IProduct
    {
        List<Product> ReadAll();
        void Create(Product product);
        void Update(Product product);

        void Delete(string idProduct);
    }
}
