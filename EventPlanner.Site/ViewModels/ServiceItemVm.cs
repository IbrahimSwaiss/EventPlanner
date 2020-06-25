namespace EventPlanner.Site.ViewModels {
    public class ServiceItemVm {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerHour { get; set; }
        public string ServiceType { get; set; }
        public bool IsSelected { get; set; }
    }
}
