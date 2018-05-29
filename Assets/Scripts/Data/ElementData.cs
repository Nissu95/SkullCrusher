using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Game/Data/Elements"))]
public class ElementData : ScriptableObject{

    public new string name;
    public float damage;
    public GameObject bulletPref;

}
