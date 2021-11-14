using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Role : MonoBehaviour
{
    public Slider Healthy;
    public int Health, HealthMax, Magic, Strength, Agility, TeamNumber, State, RoleId, OrderTime, RoleMovePoint,PreRoleMovePoint;
    public bool CanBeAttack;
    public int ATK;
    public int MainWeapon,ViceWeapon,AttackTime;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SetGroudState(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(float nx,float ny)
    {
        PreRoleMovePoint = RoleMovePoint;
        SetGroudState(false);
        transform.position = new Vector3(nx, ny, (float)-1);
        SetGroudState(true);
    }
    public void SetGroudState(bool HowSet)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("cell"))
            {
                if (HowSet == true)
                {
                    hit.collider.GetComponent<Cell>().GroudState = TeamNumber;
                }
                else
                    hit.collider.GetComponent<Cell>().GroudState = 0;

            }
        }
    }
    public void SetCellMovePoint()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("cell"))
                hit.collider.GetComponent<Cell>().CellMovePoint = RoleMovePoint;
        }
    }
    public void SetCellAttackPoint(int Range)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.zero);
        foreach (var hit in hits)
        {
            if (hit.collider.CompareTag("cell"))
                hit.collider.GetComponent<Cell>().CellAttackPoint = Range;
        }
    }
    void BeAttack()
    {
        gameManager.OrderTimes[0] += gameManager.Selected.GetComponent<Role>().AttackTime;
        Health -= gameManager.Selected.GetComponent<Role>().ATK;
        Healthy.GetComponent<Slider>().value = Health / (float)HealthMax;
        gameManager.ResetCellAttackPoint();
        gameManager.CloseAttack();
        if (Health <= 0)
        {
            gameManager.OrderIds[RoleId] = gameManager.OrderIds[gameManager.SumOfRole];
            gameManager.OrderTimes[RoleId] = gameManager.OrderTimes[gameManager.SumOfRole];
            gameManager.OrderIds[gameManager.SumOfRole] = 0;
            gameManager.OrderTimes[gameManager.SumOfRole] = 0;
            gameManager.SumOfRole--;
            Destroy(this.gameObject);
        }
        gameManager.IfAction = true;
        if (gameManager.IfMove == false && gameManager.IfAction)
            gameManager.ShowMove(gameManager.Selected.GetComponent<Role>().RoleMovePoint);
    }
    public void OnMouseDown()
    {
        if (CanBeAttack)
            BeAttack();
    }
}
