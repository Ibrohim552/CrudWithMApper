



using AutoMapper;
using AutoMapper.QueryableExtensions;
using DTO_Pagination_Filtering_Mapping.Responses;

public class PersonService(DataContex dataContex,IMapper mapper) : IPerson
{
    public bool CreatePerson(PersonCreateInfo personCI)
    {
      bool existPerson = dataContex.Person.Any(x=>x.Name.ToLower()==personCI.Name.ToLower());
      if(existPerson) return false;
      dataContex.Person.Add(mapper.Map<Person>(personCI));
      dataContex.SaveChanges();
      return true;

    }

    public bool DeletePerson(int id)
    {
       Person existPerson=dataContex.Person.FirstOrDefault(x=>x.Id==id);
       if(existPerson is null) return false;
       dataContex.Person.Remove(existPerson);
       dataContex.SaveChanges();
       return true;
       
    }

    public PaginationResponse<IEnumerable<PersonReadInfo>> GetAllPersons(PersonFilter filter)
    {
        IQueryable<Person> person=dataContex.Person;
        if(filter.Name!=null) 
        person=person.Where(x=>x.Name.ToLower().Contains(filter.Name.ToLower()));
        if(filter.Salary!=null)
        person=person.Where(x=>x.Salary==filter.Salary);
        IQueryable<PersonReadInfo> result=person.Skip((filter.PageNumber-1)*filter.PageSize)
        .Take(filter.PageSize).ProjectTo<PersonReadInfo>(mapper.ConfigurationProvider);
        int totalrecords=dataContex.Person.Count();
        return PaginationResponse<IEnumerable<PersonReadInfo>>.Create(filter.PageNumber ,filter.PageSize , totalrecords,
        result);
    }

    public PersonReadInfo GetPersonById(int id)
    {
       PersonReadInfo? existPerson=dataContex.Person.Where(x=>x.Id==id).ProjectTo<PersonReadInfo>(mapper.ConfigurationProvider).FirstOrDefault();
      return (PersonReadInfo)(existPerson ?? null);
    }

    public bool UpdatePerson(PersonUpdateInfo person)
    {
       Person? existPerson=dataContex.Person.FirstOrDefault(x=>x.Id==person.Id);
       if(existPerson is null) return false;
       dataContex.Person.Update(mapper.Map<Person>(person));
       dataContex.SaveChanges();
       return true;
    }
}