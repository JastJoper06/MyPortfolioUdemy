namespace MyPortfolioUdemy.DAL.Entities
{
    public class ToDoList
    {
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
