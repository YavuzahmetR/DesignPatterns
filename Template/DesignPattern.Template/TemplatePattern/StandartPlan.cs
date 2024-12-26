namespace DesignPattern.Template.TemplatePattern
{
    public class StandartPlan : NetflixPlans
    {
        public override string PlanType()
        {
            return "Standart";
        }

        public override int CountPerson()
        {
            return 2;
        }

        public override double Price()
        {
            return 13.99;
        }

        public override string Resolution()
        {
            return "1080p";
        }

        public override string Contents()
        {
            return "Standard movies and TV shows";
        }
    }
}
