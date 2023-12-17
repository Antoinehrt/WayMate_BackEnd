namespace Infrastructure.Ef.Function;

public class EfFunctionRepository : IFunctionRepository
{
    private readonly WaymateContextProvider _waymateContextProvider;

    public EfFunctionRepository(WaymateContextProvider waymateContextProvider)
    {
        _waymateContextProvider = waymateContextProvider;
    }

    /// <summary>
    /// > This function fetches all the functions from the database and returns them as a list
    /// </summary>
    /// <returns>
    /// A list of all the functions in the database.
    /// </returns>
   /* public IEnumerable<Domain.Entities.Function> FetchAll()
    {
        using var context = _waymateContextProvider.NewContext();
        return context.Functions.ToList<Function>();
    }*/
}