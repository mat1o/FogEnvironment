// See https://aka.ms/new-console-template for more information


using FogEnvironment.Domain.Model;
using FogEnvironment.Service.BaseServices;
using FogEnvironment.Utilities;

var startUp = new AppSettings();
var nodes = new List<BaseNode>();
nodes.AddRange(startUp.FogEnvironmentModel.Edges);

var environment = new EnvironmentDecorator(startUp.FogEnvironmentModel.Edges,startUp.FogEnvironmentModel.Clouds);



Console.ReadLine();
var t = environment;

