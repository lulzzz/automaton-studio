using Automaton.Studio.Activities;
using Automaton.Studio.Activities.Factories;
using Automaton.Studio.Activity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Automaton.Studio.Extensions
{
    public static class AutomatonServiceCollectionExtensions
    {        
        public static IServiceCollection AddAutomaton(
            this IServiceCollection services,
            Action<AutomatonOptionsBuilder>? configure = default)
        {
            // Options
            var optionsBuilder = new AutomatonOptionsBuilder(services);
            configure?.Invoke(optionsBuilder);

            services.AddTransient(sp => sp.GetRequiredService<AutomatonOptions>());
            services.AddSingleton(optionsBuilder.AutomatonOptions);

            // Factories
            services.AddTransient<ActivityFactory>();

            // Activity descriptors
            services.AddSingleton<IDescribesActivityType, ActivityTypeDescriber>();

            // Activities
            optionsBuilder.AddActivitiesFrom<WriteLineActivity>();      

            return services;
        }
    }
}