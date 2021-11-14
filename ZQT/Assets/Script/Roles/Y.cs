using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Role>().HealthMax = 100;
        GetComponent<Role>().Health = GetComponent<Role>().HealthMax;
        GetComponent<Role>().Magic = 50;
        GetComponent<Role>().Strength = 50;
        GetComponent<Role>().Agility = 50;
        GetComponent<Role>().TeamNumber = 1;
        GetComponent<Role>().MainWeapon = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
