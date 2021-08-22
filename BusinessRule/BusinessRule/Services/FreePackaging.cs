namespace BusinessRule.Services
{
    public class FreePackaging : IProcess
    {
        public string Process(UserContext context)
        {
            return "Add a free “First Aid” video to the packing slip.";
        }
    }
}
