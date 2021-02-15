
namespace DZ5_5
{
    /// <summary>
    ////Список задач
    /// </summary>
    public class ToDo
    {
        /// <summary>
        //// Описание задачи
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        //// Статус задачи - выполнена
        /// </summary>
        public bool IsDone { get; set; }

        public ToDo()
        {
            Title = "Defoult";
            IsDone = true;
        }

        /// <summary>
        //// Конструктор - создает экземпляр класса.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isDone"></param>
        public ToDo(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }
    }
}
