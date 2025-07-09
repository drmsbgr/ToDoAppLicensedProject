
namespace ToDoApp.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public bool IsDone { get; set; }

        public string GetDoneState() => IsDone ? "Tamamlandı" : "Tamamlanmadı";
    }
}
