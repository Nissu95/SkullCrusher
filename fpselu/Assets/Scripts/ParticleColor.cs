using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour {

    ParticleSystem pS;

    void Start() {
        pS = GetComponentInChildren<ParticleSystem>();
    }

    void Update() {
        pS.startColor = PlayerManager.singleton.GetColorParticles();
    }

}
