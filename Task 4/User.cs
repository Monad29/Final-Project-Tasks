namespace Task_4
{
    public class User
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        private string idnumber;
        public string Idnumber
        {
            get { return idnumber; }

            set
            {
                if (value.Length == 11)
                {
                    idnumber = value;
                }
                else
                {
                    throw new Exception("Must be 11 digits");
                }
            }
        }
        private int id;
        public int Id
        {
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    throw new Exception("Can't be negative number");
                }
            }
            get { return id; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length == 4)
                {
                    password = value;
                }
                else
                {
                    throw new Exception("Must be 4 digits");
                }
            }
        }
        private float balance;
        public float Balance
        {
            get { return balance; }

            set
            {
                if (value >= 0)
                {
                    balance = value;
                }
                else
                {
                    throw new Exception("You are broke");
                }
            }
        }
        public override string ToString()
        {
            return $"{Firstname} {Surname} {Idnumber} {Id} {Password} {Balance}";
        }
    }
}
