namespace Planets
{
    public class Planet
    {
        public string Name { get; set; }

        public string Image { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}