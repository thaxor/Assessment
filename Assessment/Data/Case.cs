namespace Assessment.Data
{
    public class Case
    {
        public int CaseId { get; set; }
        public string Message { get; set; }
        public string WorkerId { get; set; }
        public string ReviewerId { get; set; }
        public string ApproverId { get; set; }
    }
}
