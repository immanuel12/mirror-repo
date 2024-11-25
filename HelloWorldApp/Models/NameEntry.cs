using System.ComponentModel.DataAnnotations;

namespace HelloWorldApp.Models
{
public class NameEntry
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nama tidak boleh kosong.")]
    public string Name { get; set; }
}

}
