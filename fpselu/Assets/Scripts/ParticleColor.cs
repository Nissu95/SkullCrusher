using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour
{

    [SerializeField]
    ParticleSystem fireParticles;
    [SerializeField]
    ParticleSystem waterParticles;
    [SerializeField]
    ParticleSystem plantParticles;

    string lastParticle;

    void Update()
    {
        if (lastParticle != PlayerManager.singleton.GetElementParticles())
        {
            disableAll();
            switch (PlayerManager.singleton.GetElementParticles())
            {
                case "Fire":
                    fireParticles.gameObject.SetActive(true);
                    break;
                case "Water":
                    waterParticles.gameObject.SetActive(true);
                    break;
                case "Plant":
                    plantParticles.gameObject.SetActive(true);
                    break;
            }
        }

        lastParticle = PlayerManager.singleton.GetElementParticles();
    }

    void disableAll()
    {
        fireParticles.gameObject.SetActive(false);
        waterParticles.gameObject.SetActive(false);
        plantParticles.gameObject.SetActive(false);
    }

}
