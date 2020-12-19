using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionApplicationExtensions
    {
        /// <summary>
        /// 启动的地方
        /// </summary>
        /// <typeparam name="TStartupModule"></typeparam>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IAbpApplicationWithExternalServiceProvider AddApplication<TStartupModule>(
            [NotNull] this IServiceCollection services, 
            [CanBeNull] Action<AbpApplicationCreationOptions> optionsAction = null)
            where TStartupModule : IAbpModule
        {
            return AbpApplicationFactory.Create<TStartupModule>(services, optionsAction);
        }

        public static IAbpApplicationWithExternalServiceProvider AddApplication(
            [NotNull] this IServiceCollection services,
            [NotNull] Type startupModuleType,
            [CanBeNull] Action<AbpApplicationCreationOptions> optionsAction = null)
        {
            return AbpApplicationFactory.Create(startupModuleType, services, optionsAction);
        }
    }
}