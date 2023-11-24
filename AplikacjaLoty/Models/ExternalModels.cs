namespace AplikacjaLoty.Models
{
    public class FlightResponse
    {
        public FlightResult[] Results { get; set; }
    }

    public class FlightResult
    {
       public Airline Airline { get; set; }
       public FlightInfo Flight { get; set; }
       public Departure Departure { get; set; }
       public Arrival Arrival { get; set; }
       public LiveInfo Live { get; set; }
    }

    public class Airline
    {
        public string Name { get; set; }
    }
    public class FlightInfo
    {
        public string Date { get; set; }
        public string Iata { get; set; }
    }
    public class Departure
    {
        public string Airport { get; set; }
        public string Iata { get; set; }
    }
    public class Arrival
    {
        public string Airport { get; set; }
        public string Iata { get; set; }
    }
    public class LiveInfo
    {
        public bool IsGround { get; set; }
    }
}
