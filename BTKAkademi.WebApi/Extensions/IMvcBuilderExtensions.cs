using BTKAkademi.WebApi.Utilities.Formatters;

namespace BTKAkademi.WebApi.Extensions
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) => builder.AddMvcOptions(config=>config.OutputFormatters
        .Add(new CsvOutputFormatter()));
    }
}
