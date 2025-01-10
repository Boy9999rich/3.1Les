namespace MusicCrudService.Dto;

public class MusicDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Double MB { get; set; }
    public string AuthorName { get; set; }
    public string Description { get; set; }
    public int QuantityLikes { get; set; }
}
