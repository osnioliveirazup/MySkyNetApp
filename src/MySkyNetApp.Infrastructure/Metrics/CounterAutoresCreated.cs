using MySkyNetApp.Application.Interfaces.Metrics;
using StackSpot.Metrics;

namespace MySkyNetApp.Infrastructure.Metrics
{
    public class CounterAutoresCreated : ICounterAutoresCreated
    {
        private readonly ICounter _counterAutoresCreated;

        public CounterAutoresCreated(IMetricsFactory metricsFactory)
        {
            _counterAutoresCreated = metricsFactory.CreateCounterBuilder("autores_created_total")
                .WithTag("uri", "Autores")
                .WithTag("method", "POST")
                .WithNamespace("myskynetapp")
                .WithDescription("Quantidade de autores criados")
                .Build();
        }

        public void Increment()
            => _counterAutoresCreated.Increment();
    }
}
