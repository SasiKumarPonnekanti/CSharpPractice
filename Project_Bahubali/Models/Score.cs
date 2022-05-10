namespace Project_Bahubali.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string UserId { get; set; }

        public DateTime Date { get; set; }
        [ValidMarks]
        public int MathsScore { get; set; }
        [ValidMarks]
        public int ScienceScore { get; set; }
        [ValidMarks]
        public int GeographyScore { get; set; }
        [ValidMarks]
        public int HistoryScore { get; set; }   


       

    }
}
