using BusinessRule.Services;

namespace BusinessRule
{
    public interface IProcess
    {
        string Process(Context context);
    }
}
