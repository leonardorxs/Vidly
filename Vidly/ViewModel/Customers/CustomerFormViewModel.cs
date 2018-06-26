using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Editar Cliente";
                return "Cadastrar Cliente";
            }
        }

        public string Action
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Editar";
                return "Cadastrar";
            }
        }
    }
}