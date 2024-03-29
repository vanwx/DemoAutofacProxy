﻿using Castle.DynamicProxy;

namespace DemoConsole
{
	public class CallLogger : IInterceptor
	{
		readonly TextWriter _output;

		public CallLogger(TextWriter output)
		{
			_output = output;
		}

		public void Intercept(IInvocation invocation)
		{
			_output.WriteLine("Calling method {0} with parameters {1}... ",
				invocation.Method.Name,
				string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

			invocation.Proceed();

			_output.WriteLine("Done: result was {0}.", invocation.ReturnValue);
		}
	}
}
