using AutoMapper;
using System.Reflection;

namespace ConcertTicket.Application.TicketGeneral.Mappings
{
    public class AssemblyMapping : Profile
    {
        public AssemblyMapping(Assembly assembly) => ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().Where(type => type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IMapWith<>))).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var method = type.GetMethod("Mapping");
                method?.Invoke(instance, new[] { this });
            }
        }
    }
}
