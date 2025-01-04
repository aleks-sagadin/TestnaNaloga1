using System.ComponentModel.DataAnnotations;


namespace TestnaNaloga.Domain
{
    public class Zahtevek
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }

        // [JsonConverter(typeof(StringEnumConverter))]
        public PriorityEnum Priority { get; set; }

        public DateTime CretedDate { get; set; }
        //    [JsonIgnore]
        public DateTime UpdatedDate { get; set; }

        public Zahtevek()
        {

        }

        public Zahtevek(int id, string title, string description, bool isCompleted, DateTime dueDate, PriorityEnum priority, DateTime cretedDate, DateTime updatedDate)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            DueDate = dueDate;
            Priority = priority;
            CretedDate = cretedDate;
            UpdatedDate = updatedDate;
        }
    }
}
