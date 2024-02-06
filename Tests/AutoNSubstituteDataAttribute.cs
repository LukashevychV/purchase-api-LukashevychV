using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    internal class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(() => new Fixture()
            .Customize(
                 new CompositeCustomization(
                new AutoNSubstituteCustomization(), new AspNetCustomization())))
        {
        }
    }

    public class AspNetCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new ControllerBasePropertyOmitter());
        }
    }

    public class ControllerBasePropertyOmitter : Omitter
    {
        public ControllerBasePropertyOmitter()
            : base(new OrRequestSpecification(GetPropertySpecifications()))
        {
        }

        private static IEnumerable<IRequestSpecification> GetPropertySpecifications()
        {
            return typeof(ControllerBase).GetProperties().Where(x => x.CanWrite)
                .Select(x => new PropertySpecification(x.PropertyType, x.Name));
        }
    }

}
