using AutoMapper;

namespace BankWebApplication.Infrastructure
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
