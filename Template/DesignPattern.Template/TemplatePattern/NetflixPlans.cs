namespace DesignPattern.Template.TemplatePattern
{
    public abstract class NetflixPlans
    {
        public string PlanTypeValue { get; set; } = null!;
        public int CountPersonValue { get; set; }
        public double PriceValue { get; set; }
        public string ResolutionValue { get; set; } = null!;
        public string ContentsValue { get; set; } = null!;

        public void CreatePlan()
        {
            PlanTypeValue = PlanType();
            CountPersonValue = CountPerson();
            PriceValue = Price();
            ResolutionValue = Resolution();
            ContentsValue = Contents();
        }
        public abstract string PlanType();
        public abstract int CountPerson();
        public abstract double Price();
        public abstract string Resolution();
        public abstract string Contents();
    }

}
