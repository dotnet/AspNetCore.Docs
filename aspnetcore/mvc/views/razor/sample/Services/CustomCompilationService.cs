using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class CustomCompilationService : DefaultRoslynCompilationService, ICompilationService
{
    public CustomCompilationService(ApplicationPartManager partManager, 
        IOptions<RazorViewEngineOptions> optionsAccessor, 
        IRazorViewEngineFileProviderAccessor fileProviderAccessor, 
        ILoggerFactory loggerFactory) 
        : base(partManager, optionsAccessor, fileProviderAccessor, loggerFactory)
    {
    }

    CompilationResult ICompilationService.Compile(RelativeFileInfo fileInfo, 
        string compilationContent)
    {
        return base.Compile(fileInfo, compilationContent);
    }
}

