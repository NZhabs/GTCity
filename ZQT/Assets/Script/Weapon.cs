using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActionOfWeapon(int Type)
    {
        if (Type == 0)
            Fist();
        if (Type == 1)
            Sword();
        if (Type == 2)
            Rapier();
        if (Type == 3)
            Lance();
    }

    void Fist()//0
    {
        gameManager.Selected.GetComponent<Role>().AttackTime = 10;
        gameManager.Selected.GetComponent<Role>().ATK = (int)(5 *((100+gameManager.Selected.GetComponent<Role>().Strength)/(float)100));
        gameManager.Selected.GetComponent<Role>().SetCellAttackPoint(1);
        gameManager.ShowAttack(1,gameManager.Selected.GetComponent<Role>().TeamNumber);
    }
    void Sword()//1
    {
        gameManager.Selected.GetComponent<Role>().AttackTime = 20;
        gameManager.Selected.GetComponent<Role>().ATK = (int)(15 * ((100 + gameManager.Selected.GetComponent<Role>().Strength) / (float)100));
        gameManager.Selected.GetComponent<Role>().SetCellAttackPoint(1);
        gameManager.ShowAttack(1, gameManager.Selected.GetComponent<Role>().TeamNumber);
    }
    void Rapier()//2
    {
        gameManager.Selected.GetComponent<Role>().AttackTime = 15;
        gameManager.Selected.GetComponent<Role>().ATK = (int)(10 * ((100 + gameManager.Selected.GetComponent<Role>().Strength) / (float)100));
        gameManager.Selected.GetComponent<Role>().SetCellAttackPoint(1);
        gameManager.ShowAttack(1, gameManager.Selected.GetComponent<Role>().TeamNumber);
    }
    void Lance()//3
    {
        gameManager.Selected.GetComponent<Role>().AttackTime = 20;
        gameManager.Selected.GetComponent<Role>().ATK = (int)(10 * ((100 + gameManager.Selected.GetComponent<Role>().Strength) / (float)100));
        gameManager.Selected.GetComponent<Role>().SetCellAttackPoint(2);
        gameManager.ShowAttack(1, gameManager.Selected.GetComponent<Role>().TeamNumber);
    }
}
