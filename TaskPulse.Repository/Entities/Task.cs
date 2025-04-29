namespace TaskPulse.Repository.Entities
{
    public class Task : Base
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
