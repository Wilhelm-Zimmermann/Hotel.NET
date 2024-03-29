﻿using Hotel.Domain.Commands.Contracts;

namespace Hotel.Domain.Commands
{
    public class UpdateHotelGuestCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Om { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public UpdateHotelGuestCommand()
        {

        }

        public UpdateHotelGuestCommand(string name, string om, DateTime birthDate, string phoneNumber, string email, Guid id)
        {
            Name = name;
            Om = om;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Id = id;
        }
    }
}
