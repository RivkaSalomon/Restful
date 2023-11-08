namespace RestfulAPI.Entities
{
    public class Appointment
    {
        public DateOnly Date { get; set; }
        public string Subject { get; set; }
        public int Id { get; set; }
        //Appointment(DateOnly d,string s,int id)
        //{
        //    Date = d;
        //    Subject = s;
        //    Id = id;
        //}
        //Appointment()
        //{ }

    }
}
