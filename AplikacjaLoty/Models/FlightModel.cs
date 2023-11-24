namespace AplikacjaLoty.Models
{
    public class FlightModel
    {
        public string AirlineName { get; set; } // Przechowuje nazwę linii lotniczej
        public string FlightDate { get; set; }
        public string FlightIata { get; set; } // Przechowuje oznaczenie lotu (IATA)
        public string DepartureAirport { get; set; } // Przechowuje miejsce wylotu
        public string DepartureIata { get; set; } // Przechowuje oznaczenie lotniska odlotu (IATA)
        public string ArrivalAirport { get; set; } // Przechowuje nmiejsce przylotu
        public string ArrivalIata { get; set; } // Przechowuje oznaczenie lotniska przylotu (IATA)
        public bool IsInAir { get; set; } // Określa, czy lot jest w powietrzu
        
    }
}
