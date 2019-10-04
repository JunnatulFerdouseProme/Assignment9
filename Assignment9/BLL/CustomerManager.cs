using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Assignment9.Repository;
using Assignment9.Model;

namespace Assignment9.BLL
{
   public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool IsCodeExist(Customer customer)
        {
            return _customerRepository.IsCodeExist(customer);
        }

        public bool IsContactExist(Customer customer)
        {
            return _customerRepository.IsContactExist(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public DataTable DistrictCombo()
        {
            return _customerRepository.DistrictCombo();
        }
            public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }
    }
}
