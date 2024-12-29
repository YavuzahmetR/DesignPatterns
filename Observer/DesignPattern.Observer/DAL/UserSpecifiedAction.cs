namespace DesignPattern.Observer.DAL
{
    public class UserSpecifiedAction
    {
        public int Id { get; set; }
        public string NameSurname { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Magazine { get; set; } = null!;
    }
}
