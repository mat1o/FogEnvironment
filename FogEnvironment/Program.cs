// See https://aka.ms/new-console-template for more information


using FogEnvironment.Service.BaseServices;
using FogEnvironment.Utilities;

var environment = new EnvironmentDecorator();

var startUp = new AppSettings();

Console.WriteLine($"{startUp.ApiSettings.BearerToken}");

Console.ReadLine();
//var t = environment;

