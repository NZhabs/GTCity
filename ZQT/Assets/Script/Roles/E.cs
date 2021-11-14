using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E : MonoBehaviour
{

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Role>().HealthMax = 40;
        GetComponent<Role>().Health = GetComponent<Role>().HealthMax;
        GetComponent<Role>().Magic = 10;
        GetComponent<Role>().Strength = 10;
        GetComponent<Role>().Agility = 10;
        GetComponent<Role>().TeamNumber = 2;
        GetComponent<Role>().MainWeapon = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
