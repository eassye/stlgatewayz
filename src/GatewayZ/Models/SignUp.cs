namespace GatewayZ.Models
{
    public class SignUp
    {
        public SignUp()
        {
            Enrollment = new EnrollmentType();
            Personal = new PersonalInformation();
            Vehicals = new VehicalsOwned();
            ZInterests = new ZInterests();
            Signature = new Signature();
            Waiver = new Waiver();
        }

        public EnrollmentType Enrollment { get; set; }
        public PersonalInformation Personal { get; set; }
        public VehicalsOwned Vehicals { get; set; }
        public ZInterests ZInterests { get; set; }
        public Signature Signature { get; set; }
        public Waiver Waiver { get; set; }   
    }

    public class EnrollmentType
    {
        public bool Renewal { get; set; }
        public bool NewMembership { get; set; }
        public string ReferredBy { get; set; }
    }

    public class PersonalInformation
    {
        public string Name { get; set; }
        public string BirthDay { get; set; }
        public string SignificantOthersName { get; set; }
        public string Anniversary { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PrimaryPhone { get; set; }
        public string Email { get; set; }
    }

    public class VehicalsOwned
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string BodyStyle { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public bool Modified { get; set; }
        public string MakeTwo { get; set; }
        public string ModelTwo { get; set; }
        public string BodyStyleTwo { get; set; }
        public string YearTwo { get; set; }
        public string ColorTwo { get; set; }
        public bool ModifiedTwo { get; set; }
    }

    public class ZInterests
    {
        public bool Autocross { get; set; }
        public bool Restoration { get; set; }
        public bool SocialEvent { get; set; }
        public bool Rallies { get; set; }
        public bool DragRacing { get; set; }
        public bool CarShows { get; set; }
        public bool SportsCarRacing { get; set; }
        public bool Customizing { get; set; }
        public string SCCARegion { get; set; }
    }

    public class Signature
    {
        public string Name { get; set; }
        public string Date { get; set; }
    }

    public class Waiver
    {
        public string DateReceived { get; set; }
        public string PaymentMethod { get; set; }
        public string CheckNumber { get; set; }
        public string AmountRecieved { get; set; }
        public string DateEntered { get; set; }
        public string PackageSent { get; set; }
        public string MembershipNumber { get; set; }
    }
}