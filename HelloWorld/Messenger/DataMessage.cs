using System;
using MvvmCross.Plugins.Messenger;

namespace HelloWorld
{
	public class DataMessage : MvxMessage
	{
		public DataMessage(object sender, double value) : base(sender)
		{
			Value = value;
		}

		public double Value { get; private set; }
	}
}
