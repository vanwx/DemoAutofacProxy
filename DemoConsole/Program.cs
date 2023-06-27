using Autofac;
using Autofac.Extras.DynamicProxy;
using DemoConsole;

var builder = new ContainerBuilder();

// Named registration
builder.RegisterType<RealApiClient>()
	.AsImplementedInterfaces()
	.EnableInterfaceInterceptors()
	.InterceptedBy(typeof(CallLogger));

builder.Register(c => new CallLogger(Console.Out));
var container = builder.Build();

var willBeIntercepted = container.Resolve<IApiClient>();

willBeIntercepted.CallApi();

Console.ReadKey();