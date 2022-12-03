using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace VisualAssetGenerator.Extensions
{
    static class DteExtensions
    {
        public static string GetSolutionPath()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            try
            {
                var solution = (ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE)?.Solution;
                if (!string.IsNullOrEmpty(solution?.FullName))
                {
                    return Path.GetDirectoryName(solution.FullName);
                }
            }
            catch (Exception) { }

            return null;
        }
    }
}
