using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
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
    public void Move()
    {
        gameManager.ResetCellMovePoint();
        gameManager.Selected.GetComponent<Role>().SetCellMovePoint();
        gameManager.ShowMove(gameManager.Selected.GetComponent<Role>().RoleMovePoint);
    }
    public void EndMove()
    {
        gameManager.Selected.GetComponent<Role>().RoleMovePoint = 0;
        gameManager.ResetCellMovePoint();
        gameManager.CloseMove();
        gameManager.IfMove = true;
    }
    public void MoveAgain()
    {
        if (gameManager.IfAction == false)
        {
            gameManager.Selected.GetComponent<Role>().RoleMovePoint += gameManager.Selected.GetComponent<Role>().Agility / 10;
            if (gameManager.Selected.GetComponent<Role>().Agility < 10)
                gameManager.Selected.GetComponent<Role>().RoleMovePoint = 1;
            gameManager.ResetCellMovePoint();
            gameManager.CloseMove();
            Move();
            gameManager.IfMove = false;
            gameManager.IfAction = true;
        }
    }
    public void MainWeaponAttack()
    {
        if (gameManager.IfAction == false)
        {
            gameManager.Action(1, gameManager.Selected.GetComponent<Role>().MainWeapon);
        }
    }
}
