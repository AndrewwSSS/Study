
namespace Contact_Info
{
    public static class ContactInfo
    {
        public static bool isRightFullName(string FirstName, string SecondName, string Patronymic)
        {
            if (FirstName == null || SecondName == null || Patronymic == null)
            {
                return false;
            }


            foreach (char item in FirstName)
            {
                if(!char.IsLetter(item))
                    return false;
            }

            foreach (char item in SecondName)
            {
                if (!char.IsLetter(item))
                    return false;
            }

            foreach (char item in Patronymic)
            {
                if (!char.IsLetter(item))
                    return false;
            }



            return true;


        }

        public static bool isRightAge(string Age)
        {
            int i;

            if (int.TryParse(Age, out i)) { return true; }
            else { return false; }
        }

        public static bool isRightTelephoneByFormat(string telephoneNumber, string StartsWith)
        {
            return telephoneNumber.StartsWith(StartsWith);
        }

        public static bool isRightEmailByFormat(string Email, string EndWith)
        {
            return Email.EndsWith(EndWith);
        }
    }
}
