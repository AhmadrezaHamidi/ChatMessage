using System;
namespace Domain.UserDomain
{
    public class User
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Thread> Threads { get; set; }
    }

}

