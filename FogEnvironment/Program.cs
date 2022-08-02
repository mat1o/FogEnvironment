// See https://aka.ms/new-console-template for more information


using FogEnvironment.Service.BaseServices;
using FogEnvironment.Utilities;

var startUp = new AppSettings();
var environment = new EnvironmentDecorator(startUp.FogEnvironmentModel.Edges,startUp.FogEnvironmentModel.Clouds);


Console.ReadLine();
var t = environment;

