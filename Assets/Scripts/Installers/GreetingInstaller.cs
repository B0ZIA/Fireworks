using UnityEngine;
using Zenject;

public class GreetingInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGreeting>().To<Greeting>().AsSingle();
    }
}