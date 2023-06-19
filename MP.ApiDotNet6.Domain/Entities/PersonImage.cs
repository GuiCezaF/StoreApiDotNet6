using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain;

public class PersonImage
{
  public PersonImage(int personId, string? imageUri, string? imageBase)
  {
    Validation(personId);
    ImageUri = imageUri;
    ImageBase = imageBase;
  }

  public int Id { get; set; }
  public int PersonId { get; set; }
  public string? ImageUri { get; set; }
  public string? ImageBase { get; set; }
  public Person Person { get; set; }

  private void Validation(int personId)
  {
    DomainValidationException.When(personId == 0, "Id deve ser informado");
    PersonId = personId;
  }
}
