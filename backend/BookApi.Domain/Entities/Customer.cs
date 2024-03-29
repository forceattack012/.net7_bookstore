﻿using BookApi.Domain.Entities.Base;


namespace BookApi.Domain.Entities
{
    public class Customer : BaseEntity<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
