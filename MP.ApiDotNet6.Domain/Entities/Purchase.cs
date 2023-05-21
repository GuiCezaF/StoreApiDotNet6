using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Products Products { get; set; }

        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(id < 0, "Id deve ser informado");
            Id = id;
            Validation(productId, personId);
        }

        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId < 0, "Id do Produto deve ser informado");
            DomainValidationException.When(personId < 0, "Id da pessoa deve ser informado");

            PersonId = personId;
            ProductId = productId;
        }
    }
}