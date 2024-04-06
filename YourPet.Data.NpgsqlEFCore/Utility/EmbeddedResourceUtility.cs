using System.Reflection;

namespace YourPet.Data.NpgsqlEFCore.Utility
{
    public static class EmbeddedResourceUtility
    {
        public static string LoadResourceString(string resourceName)
        {
            var assembly = Assembly.GetCallingAssembly();

            using var stream = assembly.GetManifestResourceStream(resourceName) 
                               ?? throw new FileNotFoundException($"Resource '{resourceName}' not found in assembly '{assembly.FullName}'.");
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static IEnumerable<string> LoadResourceStringsByPrefix(string prefix)
        {
            var assembly = Assembly.GetCallingAssembly();
            var namespaceName = assembly.GetName().Name;
            var fullPrefix = $"{namespaceName}.{prefix}";
            var allResourceNames = assembly.GetManifestResourceNames()
                .Where(name => name.StartsWith(fullPrefix, StringComparison.InvariantCultureIgnoreCase) 
                               && name.EndsWith(".sql", StringComparison.InvariantCultureIgnoreCase));

            foreach (var resourceName in allResourceNames)
            {
                yield return LoadResourceString(resourceName);
            }
        }
    }
}
