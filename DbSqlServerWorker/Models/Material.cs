namespace DbSqlServerWorker.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string Title { get; set; }
        public double Density { get; set; }
        public int MaterialGroupId { get; set; }
        public string Support { get; set; }
    }
}
