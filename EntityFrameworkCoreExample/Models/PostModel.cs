using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreExample.Models
{
    public class PostModel
    {
	    public int Id { get; set; }

		[Required]
	    public string Title { get; set; }

	    public string Content { get; set; }
    }
}
