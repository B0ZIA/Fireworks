using Managers;
using UnityEngine;
using Zenject;

public class ScenesManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IScenesManagers>().To<ScenesManager>().AsSingle();
    }
}