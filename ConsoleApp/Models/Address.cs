using System;
using ConsoleApp1.Models;

namespace ConsoleApp.Models
{
    public class Address
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }

        private User? _user; 
        private string? _userId; 

        public User? User
        {
            get => _user;
            private set
            {
                _user = value; 
                _userId = _user?.Id.ToString(); 
            }
        }

        public Address(int id, string street, string number, string complement, string neighborhood, string city, string state, string zipCode, string country, User? user)
        {
            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
            _user = user;

            ValidateInputs(street, number, neighborhood, city, state, zipCode, country);
        }

        private void ValidateInputs(string street, string number, string neighborhood, string city, string state, string zipCode, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street cannot be null or empty.", nameof(street));

            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Number cannot be null or empty.", nameof(number));

            if (string.IsNullOrWhiteSpace(neighborhood))
                throw new ArgumentException("Neighborhood cannot be null or empty.", nameof(neighborhood));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City cannot be null or empty.", nameof(city));

            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("State cannot be null or empty.", nameof(state));

            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("ZipCode cannot be null or empty.", nameof(zipCode));

            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country cannot be null or empty.", nameof(country));
        }

        public void Update(string street, string number, string complement, string neighborhood, string city, string state, string zipCode, string country)
        {
            ValidateInputs(street, number, neighborhood, city, state, zipCode, country);

            Street = street;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Id} - {Street}, {Number} - {Neighborhood}, {City}/{State} - {ZipCode} - {Country}";
        }
    }
}