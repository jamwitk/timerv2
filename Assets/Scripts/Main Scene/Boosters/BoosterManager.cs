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
        [SerializeField] private List<PlayerProperties> boosters;
        [SerializeField] private List<GameObject> boosterPrefabs;
        private void Start()
        {
            SetDefaultPlayerProperties();
            StartCoroutine(Generate());
        }
        private IEnumerator Generate()
        {
            if (!GameManager.Instance.isGame) yield break;
            yield return new WaitForSeconds(1f);
            Instantiate(boosterPrefabs[Random.Range(0, boosterPrefabs.Count - 1)],
                MaterialManager.Instance.planes[Random.Range(0,MaterialManager.Instance.planes.Count-1)].transform.position,Quaternion.identity);
        }
        public void SetDefaultPlayerProperties()
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

