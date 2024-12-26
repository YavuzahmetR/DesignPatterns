namespace DesignPattern.Template.TemplatePattern
{
    public class UltraPlan : NetflixPlans
    {
        public override string PlanType()
        {
            return "Premium";
        }

        public override int CountPerson()
        {
            return 4;
        }

        public override double Price()
        {
            return 17.99;
        }

        public override string Resolution()
        {
            return "4K HDR";
        }

        public override string Contents()
        {
            return "Premium movies, TV shows, and exclusive content";
        }
    }
}
