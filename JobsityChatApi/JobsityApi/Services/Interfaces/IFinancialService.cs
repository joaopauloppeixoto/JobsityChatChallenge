using JobsityApi.ViewModels;

namespace JobsityApi.Services.Interfaces;

public interface IFinancialService
{
    public Task SendCommandAsync(string command, string source);
}
