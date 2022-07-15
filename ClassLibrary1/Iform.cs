using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Iform
    {
        private string title;
        private string firstName;
        private string lastName;
        private string mailAdress;
        private int identityCard;
        private string telephonePrefix;
        private string phon;

        public string Title
        {
            get { return title; }
            set
            {
                if (value == null)
                    return;
                title = value.Trim();
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null || !Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                    return;
                firstName = value.Trim();
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null || !Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                    return;
                lastName = value.Trim();
            }
        }
        public string MailAdress
        {
            get { return mailAdress; }
            set
            {
                var trimmedEmail = value.Trim();
                try
                {
                    if (!new EmailAddressAttribute().IsValid(value))
                    {
                        return;
                    }
                    mailAdress = trimmedEmail;
                }
                catch (Exception)
                {
                    mailAdress = trimmedEmail;
                }
            }
        }
        public int IdentityCard
        {
            get { return identityCard; }
            set
            {
                if (!Regex.IsMatch(value.ToString(), "[0-9]{9}")
                    || value.ToString().Count(char.IsDigit) != 9
                    || value.ToString().EndsWith("X", StringComparison.OrdinalIgnoreCase)
                    || value.ToString().EndsWith("V", StringComparison.OrdinalIgnoreCase)
                    || value.ToString()[2] == '4' || value.ToString()[2] == '9'
                    )
                {
                    return;
                }
                identityCard = value;
            }
        }
        public string TelephonePrefix
        {
            get { return telephonePrefix; }
            set
            {
                if (value == null
                    || value.Length != 3)
                    return;
                telephonePrefix = value.Trim();
            }
        }
        public string Phon
        {
            get { return phon; }
            set
            {
                if (value == null
                    || !Regex.IsMatch(value, "[0-9]{7,}"))
                    return;
                phon = value.Trim();
            }
        }
    }
}
