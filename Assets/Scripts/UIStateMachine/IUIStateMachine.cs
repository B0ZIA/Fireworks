using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIStateMachineManager;

public interface IUIStateMachine
{
    string Graph { get; }
    void ChangeUIState(UITrigger trigger);
}
