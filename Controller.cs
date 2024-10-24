

using DTO_Pagination_Filtering_Mapping.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/persons")]

public class PersonController(IPerson personser):ControllerBase
{
 [HttpPost]

 public IActionResult CreatePerson([FromBody] string name,string surName, int age,decimal salary)
 {
    PersonCreateInfo info =new PersonCreateInfo(name,surName,age,salary);
    bool res = personser.CreatePerson(info);
         return res
            ? Ok(ApiResponse<bool>.Success(null, res))
            : BadRequest(ApiResponse<bool>.Fail(null, res));
 }

 [HttpGet]
 public IActionResult GetPersons([FromQuery] PersonFilter filter)
   =>Ok(ApiResponse<PaginationResponse<IEnumerable<PersonReadInfo>>>.Success(null,
        personser.GetAllPersons(filter)));

 [HttpGet("{id:int}")]

 public IActionResult GetPersonById(int id)
 {
     PersonReadInfo? res = personser.GetPersonById(id);
     return res!= null
        ? Ok(ApiResponse<PersonReadInfo?>.Success(null, res))
         : NotFound(ApiResponse<PersonReadInfo?>.Fail(null, null));
 }

 [HttpPut]
 public IActionResult UpdatePerson(PersonUpdateInfo info)
 {
     bool res = personser.UpdatePerson(info);
     return res
        ? Ok(ApiResponse<bool>.Success(null, res))
         : NotFound(ApiResponse<bool>.Fail(null, res));
 }

 [HttpDelete("{id:int}")]
 public IActionResult DeletePerson(int id)
 {
     bool res = personser.DeletePerson(id);
     return res
        ? Ok(ApiResponse<bool>.Success(null, res))
         : NotFound(ApiResponse<bool>.Fail(null, res));
 }

}