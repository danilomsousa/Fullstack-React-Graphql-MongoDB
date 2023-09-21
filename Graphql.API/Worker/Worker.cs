using GraphQL.Infra.Data;

/// <summary>
/// Class <c>Worker</c> provides the schedule task for reload the database.
/// </summary>
public class Worker : BackgroundService
{    
    private readonly ICatalogContext _catalog;

    public Worker(ICatalogContext catalog){
           
        _catalog = catalog;
    }

    /// <summary>
    /// Method <c>ExecuteAsync</c> schedule the task for reload the database.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
            while (!stoppingToken.IsCancellationRequested)
            {
                System.Console.WriteLine("Worker running at: {0}", DateTimeOffset.Now);
                _catalog.ReloadDatabase();
                await Task.Delay(300000, stoppingToken); //5 minutes delay
            }
        }
    }