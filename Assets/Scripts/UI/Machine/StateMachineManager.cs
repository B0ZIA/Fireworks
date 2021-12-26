using Pattern;
using Stateless;
using Stateless.Graph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Machine;

namespace UI.Machine
{
    public class StateMachineManager : Singleton<StateMachineManager>
    {
        public readonly StateMachine<MachineState, MachineTrigger> machine = new StateMachine<MachineState, MachineTrigger>(MachineState.Intro);
        public State currentState;
        public State previousState;
        public bool IsUiHidden { get; set; }
        public Action<MachineState> OnChangeState { get; set; }
        public string Graph => UmlDotGraph.Format(machine.GetInfo());




        private void Awake()
        {
            machine.Configure(MachineState.Intro)
                .Permit(MachineTrigger.GoToMainMenu, MachineState.MainMenu);
        }

        void Update()
        {
            if (currentState != null)
            {
                currentState.DoActionInState();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                currentState.OnExecuteEscapeInput();
            }
        }

        public void SetUiVisibility(bool _immediately = false)
        {
            if (!IsUiHidden)
            {
                currentState.HideOnScreen(_immediately);
            }
            else
            {
                currentState.AppearOnScreen(_immediately);
            }
            IsUiHidden = !IsUiHidden;
        }
    }
}
