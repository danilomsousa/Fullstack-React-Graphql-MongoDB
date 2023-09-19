using GraphQL.Infra.Data;

public class Worker : BackgroundService
    {    
        private readonly ICatalogContext _catalog;

        public Worker(ICatalogContext catalog)        {
           
            _catalog = catalog;
        }

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