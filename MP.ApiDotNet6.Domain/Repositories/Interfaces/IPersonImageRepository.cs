﻿namespace MP.ApiDotNet6.Domain;

public interface IPersonImageRepository
{
  Task<PersonImage?> GetByIdAsync(int id);
  Task<PersonImage> CreateAsync(PersonImage personImage);
  Task<ICollection<PersonImage>> GetByPersonIdAsync(int personId);
  Task EditAsync(PersonImage personImage);

}
