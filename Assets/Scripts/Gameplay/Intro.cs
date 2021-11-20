using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Intro : MonoBehaviour
{
    [Inject]
    IScenesManagers scenesManager;

    private void Start()
    {
        scenesManager.Load(Scene.MainMenu);
    }
}
