namespace BusinessRule.Services
{
    public class ConfirmMembership : IProcess
    {
        public ConfirmMembership(bool upgraded)
        {
            Upgraded = upgraded;
        }

        public bool Upgraded { get; }

        public string Process(UserContext context)
        {
            return $"{(Upgraded == true ? "Upgrade" : "Activation")} email has been sent to owner";
        }
    }
}
