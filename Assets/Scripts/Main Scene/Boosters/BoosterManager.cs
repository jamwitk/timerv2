using System.Collections;
using System.Collections.Generic;
using Game;
using Main_Scene.Character;
using Scriptable_Objects;
using UnityEngine;

namespace Main_Scene.Boosters
{
    public class BoosterManager : Singleton<BoosterManager>
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] public List<PlayerProperties> boosters;
        [SerializeField] private List<GameObject> boosterPrefabs;
        [SerializeField] private float boosterGenerateTimer;
        private void Start()
        {
            SetDefaultPlayerProperties();
            StartCoroutine(Generate());
            GameManager.Instance.OnFinishGame += SetDefaultPlayerProperties;
        }
        private IEnumerator Generate()
        {
            if (!GameManager.Instance.isGame) yield break;
            yield return new WaitForSeconds(boosterGenerateTimer);
            Instantiate(boosterPrefabs[Random.Range(0, boosterPrefabs.Count - 1)],
                MaterialManager.Instance.planes[Random.Range(0,MaterialManager.Instance.planes.Count-1)].transform.position,Quaternion.identity);
        }

        private void SetDefaultPlayerProperties()
        {
            playerMovement.SetPlayerProperties(boosters[0]);
        }

        public void SetProperty(PlayerProperties property)
        {
            playerMovement.SetPlayerProperties(property);
            StartCoroutine(Generate());
        }
    }
}

