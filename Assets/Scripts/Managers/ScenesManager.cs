using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ScenesManager : MonoBehaviour, IScenesManagers
    {
        public delegate void LoadScene(Scene scene);
        public event LoadScene OnLoadScene;



        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Load(Scene _scene)
        {
            SceneManager.LoadSceneAsync((int)_scene);

            OnLoadScene?.Invoke(_scene);
        }
    }
    public enum Scene
    {
        Intro = 0,
        MainMenu = 1,
        Game = 2
    }
}