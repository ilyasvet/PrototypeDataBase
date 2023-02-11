using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDbLibrary
{
    public enum Access
    {
        Creator,
        Admin,
        User,
    }
    public class Account
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _id = value;
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if(value.Length <= 3)
                {
                    throw new ArgumentException("value");
                }
                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length <= 3)
                {
                    throw new ArgumentException("value");
                }
                _lastName = value;
            }
        }
        public Access Access { get; private set; }

        public Account(int id, string firstName, string lastName, Access access)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Access = access;
        }
        public void MakeCreator()
        {
            Access = Access.Creator;
        }
        public void MakeAdmin()
        {
            if(Access != Access.Creator)
            {
                Access = Access.Admin;
            }
        }
        public override string ToString()
        {
            return $"ID: {Id} |" +
                $" Fist Name: {FirstName} |" +
                $" Last Name: {LastName} |" +
                $" Access: {Access}";
        }
    }
}
