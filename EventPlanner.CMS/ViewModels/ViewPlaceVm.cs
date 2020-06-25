namespace EventPlanner.CMS.ViewModels
{
    public class ViewPlaceVm {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal CostPerHour { get; set; }
        public string PlaceType { get; set; }
    }
}