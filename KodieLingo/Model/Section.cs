namespace KodieLingo.Model
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Topic>? Topics { get; set; }
    }
}
