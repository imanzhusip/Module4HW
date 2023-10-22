using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_ticket_office
{
    public class Train
    {
        public string TrainNumber { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public double Price { get; set; }
    }

    public class Ticket
    {
        public Train SelectedTrain { get; set; }
        public string PassengerName { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public double TotalPrice { get; set; }
    }

    public class RailwayTicketSystem
    {
        private List<Train> availableTrains = new List<Train>();
        private List<Ticket> bookedTickets = new List<Ticket>();

        public void AddTrain(Train train)
        {
            availableTrains.Add(train);
        }

        public List<Train> SearchTrains(string departureStation, string arrivalStation)
        {
            return availableTrains.FindAll(train =>
                train.DepartureStation.Equals(departureStation, StringComparison.OrdinalIgnoreCase) &&
                train.ArrivalStation.Equals(arrivalStation, StringComparison.OrdinalIgnoreCase));
        }

        public Ticket BookTicket(Train train, string passengerName, DateTime departureDateTime)
        {
            if (!availableTrains.Contains(train))
            {
                throw new ArgumentException("Указанный поезд не доступен для бронирования.");
            }

            double totalPrice = train.Price;
            Ticket ticket = new Ticket
            {
                SelectedTrain = train,
                PassengerName = passengerName,
                DepartureDateTime = departureDateTime,
                TotalPrice = totalPrice
            };

            bookedTickets.Add(ticket);
            return ticket;
        }
    }

}
