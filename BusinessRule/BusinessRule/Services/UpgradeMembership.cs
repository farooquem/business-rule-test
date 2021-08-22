namespace BusinessRule.Services
{
    public class UpgradeMembership : IProcess
    {
        public string Process(UserContext context)
        {
            return "Membership upgraded";
        }
    }
}
