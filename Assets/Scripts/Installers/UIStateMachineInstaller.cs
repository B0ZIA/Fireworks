using UnityEngine;
using Zenject;

public class UIStateMachineInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<IUIStateMachine>().To<StateMachineManager>().AsSingle();
    }
}