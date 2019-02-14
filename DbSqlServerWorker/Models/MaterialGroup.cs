namespace DbSqlServerWorker.Models
{
    public class MaterialGroup
    {
        public int MaterialGroupId { get; set; }
        public string GroupTitle { get; set; }
        public string Parent { get; set; }
        public string Support { get; set; }
        public string Gost { get; set; }
    }
}
