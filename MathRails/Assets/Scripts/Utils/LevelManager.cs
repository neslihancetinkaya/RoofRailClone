using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.RefValue;

namespace Utils
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private IntRef CurrentLevel;
        [SerializeField] private List<GameObject> LevelPrefabs;
        [SerializeField] private String SceneName;

        private void Awake()
        {
            InstantiateCurrentLevel();
        }
        
        public void OnLevelCompleted()
        {
            CurrentLevel.Value++;
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(SceneName);
        }

        private void InstantiateCurrentLevel()
        {
            if (LevelPrefabs.Count <= 0)
                return;

            Instantiate(LevelPrefabs[(CurrentLevel.Value) % LevelPrefabs.Count]);
        }
        
    }
}