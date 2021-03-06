using System;
using Caliburn.Micro;
using Documently.Commands;
using Documently.Infrastructure;

namespace Documently.WpfClient.Modules.CustomerDetails.CreateCustomer
{
	public class CreateCustomerViewModel : Screen
	{
		private readonly IBus _Bus;
		private readonly IEventAggregator _EventAggregator;

		public CreateCustomerViewModel(IBus bus, IEventAggregator eventAggregator)
		{
			_Bus = bus;
			_EventAggregator = eventAggregator;
			Command = new CreateCustomerCommand(Guid.NewGuid());
		}

		public CreateCustomerCommand Command { get; private set; }

		public void Save()
		{
			//important: send command over bus
			_Bus.Send(Command);

			//signal for UI - change view
			_EventAggregator.Publish(new CreateCustomerSavedEvent());
		}
	}

	public class CreateCustomerSavedEvent
	{
	}
}