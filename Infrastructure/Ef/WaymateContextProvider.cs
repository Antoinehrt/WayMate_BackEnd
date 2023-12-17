namespace Infrastructure.Ef;

public class WaymateContextProvider
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public WaymateContextProvider(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public WaymateContext NewContext()
    {
        return new WaymateContext(_connectionStringProvider);
    }
}