using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contact : ObservableObject, IContact
    {
        private string _id;
        private string _firstName;
        private string _lastName;
        private string _company;
        private string _jobTitle;
        private string _mobilePhone;
        private string _birthday;
        private string _email;
        private string _address;
        private string _notes;


        public string Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        /// <summary>
        /// Get or set FirstName value
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { Set(ref _firstName, value); }
        }

        /// <summary>
        /// Get or set LastName value
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { Set(ref _lastName, value); }
        }

        /// <summary>
        /// Get full name value from FirstName and LastName 
        /// </summary>
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        /// <summary>
        /// Get or set Company value
        /// </summary>
        public string Company
        {
            get { return _company; }
            set { Set(ref _company, value); }
        }

        /// <summary>
        /// Get or set JobTitle value
        /// </summary>
        public string JobTitle
        {
            get { return _jobTitle; }
            set { Set(ref _jobTitle, value); }
        }

        /// <summary>
        /// Get or set MobilePhone value
        /// </summary>
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set { Set(ref _mobilePhone, value); }
        }

        /// <summary>
        /// Get or set Birthday value
        /// </summary>
        public string Birthday
        {
            get { return _birthday; }
            set { Set(ref _birthday, value); }
        }

        /// <summary>
        /// Get or set Email value
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        /// <summary>
        /// Get or set Address value
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { Set(ref _address, value); }
        }

        /// <summary>
        /// Get or set Notes value
        /// </summary>
        public string Notes
        {
            get { return _notes; }
            set { Set(ref _notes, value); }
        }
    }
}
