using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UI.Machine;

namespace UI.Machine
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class State : MonoBehaviour
    {
        public MachineState StateType => state;

        private CanvasGroup canvasGroup;
        private Tweener canvasGroupTweener;
        protected MachineState state;



        protected void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            StateMachineManager.Instance.OnChangeState += SetStateInstance;
            ConfigureMachineTransitions();
        }

        protected virtual void OnDestroy()
        {
            if (StateMachineManager.Instance != null)
                StateMachineManager.Instance.OnChangeState -= SetStateInstance;
        }

        protected virtual void ConfigureMachineTransitions()
        {

        }

        public virtual void AppearOnScreen(bool _immediately = false)
        {
            canvasGroupTweener?.Kill();
            canvasGroupTweener = DOVirtual.Float(canvasGroup.alpha, 1f, _immediately ? 0f : Config.TIME_FOR_SHOW_GAME_PANEL, (value) => canvasGroup.alpha = value);
            canvasGroup.blocksRaycasts = true;
        }

        public virtual void HideOnScreen(bool _immediately = false)
        {
            canvasGroupTweener?.Kill();
            canvasGroupTweener = DOVirtual.Float(canvasGroup.alpha, 0f, _immediately ? 0f : Config.TIME_FOR_HIDE_GAME_PANEL, (value) =>
            {
                canvasGroup.alpha = value;
            });
            canvasGroup.blocksRaycasts = false;
        }

        private void SetStateInstance(MachineState _machineState)
        {
            if (_machineState == state)
            {
                StateMachineManager.Instance.previousState = StateMachineManager.Instance.currentState;
                StateMachineManager.Instance.currentState = this;
            }
        }

        public void InteractPanel()
        {

        }

        public void DisInteractPanel()
        {

        }

        public virtual void DoActionInState()
        {

        }

        public virtual void OnExecuteEscapeInput()
        {

        }
    }
}