using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Machine;

public class MainMenuView : State
{
    private void Awake()
    {
        state = MachineState.MainMenu;
        StateMachineManager.Instance.currentState = this;
        base.Awake();
    }

    protected override void ConfigureMachineTransitions()
    {
        base.ConfigureMachineTransitions();
        StateMachineManager.Instance.machine.Configure(state)
                .Permit(MachineTrigger.GoToOptions, MachineState.Options)
                .Permit(MachineTrigger.GoToGame, MachineState.Game);
    }
}
