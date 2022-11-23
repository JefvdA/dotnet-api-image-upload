namespace WebAPI.Models;

public class AddHouseDTO
{
    public string? Address { get; set; }
    public float Price { get; set; }
    public IFormFile? Image { get; set; }
}