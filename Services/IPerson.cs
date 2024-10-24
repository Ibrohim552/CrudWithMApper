

using DTO_Pagination_Filtering_Mapping.Responses;

public interface IPerson
{
    bool CreatePerson(PersonCreateInfo personCI);
    PersonReadInfo GetPersonById(int id);
    bool UpdatePerson(PersonUpdateInfo personUI);
    bool DeletePerson(int id);
    PaginationResponse<IEnumerable<PersonReadInfo>> GetAllPersons(PersonFilter filter);
}