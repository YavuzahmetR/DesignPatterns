namespace DesignPattern.Template.TemplatePattern
{
    public class BasicPlan : NetflixPlans
    {
        public override string PlanType()
        {
            return "Basic";
        }

        public override int CountPerson()
        {
            return 1;
        }

        public override double Price()
        {
            return 8.99;
        }

        public override string Resolution()
        {
            return "720p";
        }

        public override string Contents()
        {
            return "Basic movies and TV shows";
        }
    }
}
