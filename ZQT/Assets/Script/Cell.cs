using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool MoveAble, AttackAble;
    public int GroudState, CellMovePoint,CellAttackPoint;
    public Vector2 Direction;
    public GameObject MoveCell, AttackCell;
    GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (MoveAble)
        {
            gameManager.Selected.GetComponent<Role>().Move(transform.position.x, transform.position.y);
            gameManager.Selected.GetComponent<Role>().RoleMovePoint = CellMovePoint;
            gameManager.ResetCellMovePoint();
            gameManager.ResetCellAttackPoint();
            if (gameManager.Selected.GetComponent<Role>().RoleMovePoint > 0)
            {
                gameManager.OrderTimes[0] += (gameManager.Selected.GetComponent<Role>().PreRoleMovePoint-gameManager.Selected.GetComponent<Role>().RoleMovePoint) * 10 / (gameManager.Selected.GetComponent<Role>().Agility / 10);
                gameManager.Selected.GetComponent<Role>().SetCellMovePoint();
                gameManager.ShowMove(gameManager.Selected.GetComponent<Role>().RoleMovePoint);
            }
            else
            {
                gameManager.OrderTimes[0] += (gameManager.Selected.GetComponent<Role>().PreRoleMovePoint - gameManager.Selected.GetComponent<Role>().RoleMovePoint) * 10 / (gameManager.Selected.GetComponent<Role>().Agility / 10);
                gameManager.CloseMove();
                gameManager.IfMove = true;
            }
        }
    }

    
}
