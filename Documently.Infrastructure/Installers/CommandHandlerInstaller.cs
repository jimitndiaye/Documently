using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Documently.Commands;
using Documently.Domain.CommandHandlers;
using MassTransit;

namespace Documently.Infrastructure.Installers
{
	public class CommandHandlerInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				AllTypes.FromAssemblyContaining(typeof (CreateCustomerCommandHandler)).Where(
					x => x.GetInterface(typeof (Handles).Name) != null).WithService.AllInterfaces());

			//container.Register(
			//    Component.For<Consumes<SaveDocumentMetaData>.All>()
			//        .ImplementedBy<DocumentMetaDataHandler>(),

			//    Component.For(typeof(Consumes<>.All))
			//        .ImplementedBy(typeof(TxHandler<>)));
		}
	}
}