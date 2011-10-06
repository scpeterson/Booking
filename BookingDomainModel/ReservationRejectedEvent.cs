﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ploeh.Samples.Booking.DomainModel
{
    public class ReservationRejectedEvent : IMessage
    {
        private readonly Guid id;
        private readonly DateTime date;
        private readonly string name;
        private readonly string email;
        private readonly int quantity;

        public ReservationRejectedEvent(Guid id, DateTime date, string name, string email, int quantity)
        {
            this.id = id;
            this.date = date;
            this.name = name;
            this.email = email;
            this.quantity = quantity;
        }

        public Envelope Envelop()
        {
            return new Envelope(this, "1");
        }

        public Guid Id
        {
            get { return this.id; }
        }

        public DateTime Date
        {
            get { return this.date; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Email
        {
            get { return this.email; }
        }

        public int Quantity
        {
            get { return this.quantity; }
        }
    }
}