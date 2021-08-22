namespace BusinessRule.Services
{
    public class AgentCommission : IProcess
    {
        public string Process(UserContext context)
        {
            return "Commission payment to the agent generated";

        }
    }
}
