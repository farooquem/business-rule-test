namespace BusinessRule.Services
{
    public class ConfirmMembership : IProcess
    {
        public string Process(Context context)
        {
            return "Email has been sent to owner";
        }
    }
}
