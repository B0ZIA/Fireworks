using Pattern;
using Stateless;
using Stateless.Graph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateMachineManager : Singleton<UIStateMachineManager>, IUIStateMachine
{
    public static ChangeState OnChangeState { get; set; }

    public delegate void ChangeState(UITrigger trigger);
    public string Graph => UmlDotGraph.Format(machine.GetInfo());

    private StateMachine<UIState, UITrigger> machine;



    private void Awake()
    {
        machine = new StateMachine<UIState, UITrigger>(UIState.Intro);

        machine.Configure(UIState.Intro)
            .Permit(UITrigger.GoToMainMenu, UIState.MainMenu);

        machine.Configure(UIState.MainMenu)
            .Permit(UITrigger.GoToOptions, UIState.Options)
            .Permit(UITrigger.GoToGame, UIState.Game);
    }

    public void ChangeUIState(UITrigger trigger)
    {
        if(machine.CanFire(trigger))
        {
            machine.Fire(trigger);
            OnChangeState?.Invoke(trigger);
        }
        else
        {
            Debug.LogError("State machine can't fire " + trigger.ToString());
        }
    }

    public enum UIState
    {
        Intro,
        MainMenu,
        Options,
        Game,
        //LoadingScreen,
    }

    public enum UITrigger
    {
        GoToMainMenu,
        GoToOptions,
        GoToGame,
        //GoToLoadingScreen,
    }
}
