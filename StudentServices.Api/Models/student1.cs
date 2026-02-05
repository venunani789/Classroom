using System.ComponentModel.DataAnnotations;
namespace StudentServices.Api.Models
{
    public class student1
    {

            public int Id { get; set; }
            [Required,StringLength(100)]   
            public string Name { get; set; } = "";
            [Range(1, 120)]
            public int Age { get; set; }
        
    }

}
