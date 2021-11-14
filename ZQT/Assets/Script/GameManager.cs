using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Roles, Cells;
    public GameObject Selected;
    public GameObject Weapon;
    public List<GameObject> MoveCell, AttackCell;
    public int SumOfRole;
    public int[] OrderIds=new int[50], OrderTimes=new int[50];
    public bool IfMove, IfAction;
    // Start is called before the first frame update
    void Start()
    {
        Cells = GameObject.FindGameObjectsWithTag("cell");
        
        MoveCell = new List<GameObject>();
        AttackCell = new List<GameObject>();
        SumOfRole = 0;
        OrderFirst();
    }

    // Update is called once per frame
    void Update()
    {
        NextTurn();
    }
    void OrderFirst()
    {
        
        Roles = GameObject.FindGameObjectsWithTag("role");
        foreach (var Role in Roles)
        {
            SumOfRole++;
            Role.GetComponent<Role>().RoleId = SumOfRole;
            OrderIds[SumOfRole - 1] = SumOfRole;
            OrderTimes[SumOfRole - 1] = 100 - Role.GetComponent<Role>().Agility;
        }
        for(int i = 0;i<SumOfRole;i++)
        {
            for(int j = 0; j < SumOfRole - 1 - i; j++)
            {
                if (OrderTimes[j] > OrderTimes[j + 1])
                {
                    int t;
                    t = OrderTimes[j];OrderTimes[j] = OrderTimes[j + 1];OrderTimes[j + 1] = t;
                    t = OrderIds[j];OrderIds[j] = OrderIds[j + 1];OrderIds[j = 1] = t;
                }
            }
        }
        int Sum=OrderTimes[0];
        for(int i = 0; i < SumOfRole; i++)
        {
            OrderTimes[i] -= Sum;
        }
        foreach(var Role in Roles)
        {
            if (Role.GetComponent<Role>().RoleId == OrderIds[0])
            {
                Selected = Role;
                Selected.GetComponent<Role>().RoleMovePoint = Selected.GetComponent<Role>().Agility / 10;
                if (Selected.GetComponent<Role>().Agility < 10)
                    Selected.GetComponent<Role>().RoleMovePoint = 1;
                Selected.GetComponent<Role>().SetCellMovePoint();
            }
        }
    }
    
    public void ShowMove(int Range)
    {
        CloseAttack();
        CloseMove();
        for(int i = 0; i < Range; i++)
        {
            foreach (var Cell in Cells)
            {
                if (Cell.GetComponent<Cell>().CellMovePoint ==Range-i)
                {
                    if (i == 0)
                        MoveCell.Add(Cell);
                    RaycastHit2D[] Hitups = Physics2D.RaycastAll(Cell.transform.position, Vector2.up, (float)1.1);
                    foreach (var Hitup in Hitups)
                    {
                        
                        if (Hitup.collider.CompareTag("cell") && Hitup.collider.GetComponent<Cell>().CellMovePoint == 0 && Hitup.collider.GetComponent<Cell>().GroudState == 0)
                        {
                            Hitup.collider.GetComponent<Cell>().CellMovePoint = Range - 1 - i;
                            Hitup.collider.GetComponent<Cell>().Direction=Vector2.up;
                            Hitup.collider.GetComponent<Cell>().MoveAble = true;
                            Hitup.collider.GetComponent<Cell>().MoveCell.SetActive(true);
                            Hitup.collider.GetComponent<Cell>().MoveCell.transform.position=new Vector3(Hitup.collider.gameObject.GetComponent<Cell>().MoveCell.transform.position.x, Hitup.collider.gameObject.GetComponent<Cell>().MoveCell.transform.position.y,(float)-0.1);
                            MoveCell.Add(Hitup.collider.gameObject);
                        }
                    }
                    RaycastHit2D[] Hitlefts = Physics2D.RaycastAll(Cell.transform.position, Vector2.left, (float)1.1);
                    foreach (var Hitleft in Hitlefts)
                    {
                        if (Hitleft.collider.gameObject.CompareTag("cell") && Hitleft.collider.gameObject.GetComponent<Cell>().CellMovePoint == 0&&Hitleft.collider.gameObject.GetComponent<Cell>().GroudState == 0)
                        {
                            Hitleft.collider.gameObject.GetComponent<Cell>().CellMovePoint = Range - 1 - i;
                            Hitleft.collider.gameObject.GetComponent<Cell>().Direction=Vector2.left;
                            Hitleft.collider.gameObject.GetComponent<Cell>().MoveAble = true;
                            Hitleft.collider.gameObject.GetComponent<Cell>().MoveCell.SetActive(true);
                            Hitleft.collider.gameObject.GetComponent<Cell>().MoveCell.transform.position = new Vector3(Hitleft.collider.GetComponent<Cell>().MoveCell.transform.position.x, Hitleft.collider.GetComponent<Cell>().MoveCell.transform.position.y, (float)-0.1);
                            MoveCell.Add(Hitleft.collider.gameObject);
                        }
                    }
                    RaycastHit2D[] Hitdowns = Physics2D.RaycastAll(Cell.transform.position, Vector2.down, (float)1.1);
                    foreach (var Hitdown in Hitdowns)
                    {
                        if (Hitdown.collider.CompareTag("cell") && Hitdown.collider.GetComponent<Cell>().CellMovePoint == 0&&Hitdown.collider.GetComponent<Cell>().GroudState == 0)
                        {
                            Hitdown.collider.gameObject.GetComponent<Cell>().CellMovePoint = Range - 1 - i;
                            Hitdown.collider.gameObject.GetComponent<Cell>().Direction=Vector2.down;
                            Hitdown.collider.gameObject.GetComponent<Cell>().MoveAble = true;
                            Hitdown.collider.gameObject.GetComponent<Cell>().MoveCell.SetActive(true);
                            Hitdown.collider.gameObject.GetComponent<Cell>().MoveCell.transform.position = new Vector3(Hitdown.collider.GetComponent<Cell>().MoveCell.transform.position.x, Hitdown.collider.GetComponent<Cell>().MoveCell.transform.position.y, (float)-0.1);
                            MoveCell.Add(Hitdown.collider.gameObject);
                        }
                    }
                    RaycastHit2D[] Hitrights = Physics2D.RaycastAll(Cell.transform.position, Vector2.right, (float)1.1);
                    foreach (var Hitright in Hitrights)
                    {
                        if (Hitright.collider.gameObject.CompareTag("cell") && Hitright.collider.gameObject.GetComponent<Cell>().CellMovePoint == 0&&Hitright.collider.gameObject.GetComponent<Cell>().GroudState == 0)
                        {
                            Hitright.collider.gameObject.GetComponent<Cell>().CellMovePoint = Range - 1 - i;
                            Hitright.collider.gameObject.GetComponent<Cell>().Direction=Vector2.right;
                            Hitright.collider.gameObject.GetComponent<Cell>().MoveAble = true;
                            Hitright.collider.gameObject.GetComponent<Cell>().MoveCell.SetActive(true);
                            Hitright.collider.gameObject.GetComponent<Cell>().MoveCell.transform.position = new Vector3(Hitright.collider.GetComponent<Cell>().MoveCell.transform.position.x, Hitright.collider.GetComponent<Cell>().MoveCell.transform.position.y, (float)-0.1);
                            MoveCell.Add(Hitright.collider.gameObject);
                        }
                    }
                }
            }
        }

    }
    public void ShowAttack(int Range,int ID)
    {
        ResetCellMovePoint();
        CloseMove();
        CloseAttack();
        for (int i = 0; i < Range; i++)
        {
            foreach (var Cell in Cells)
            {
                if (Cell.GetComponent<Cell>().CellAttackPoint == Range - i)
                {
                    if (i == 0)
                        AttackCell.Add(Cell);
                    RaycastHit2D[] Hitups = Physics2D.RaycastAll(Cell.transform.position, Vector2.up, (float)1.1);
                    foreach (var Hitup in Hitups)
                    {
                        if (Hitup.collider.CompareTag("role") && Hitup.collider.GetComponent<Role>().TeamNumber != Selected.GetComponent<Role>().TeamNumber)
                            Hitup.collider.GetComponent<Role>().CanBeAttack = true;

                        if (Hitup.collider.CompareTag("cell") && Hitup.collider.GetComponent<Cell>().CellAttackPoint == 0 && Hitup.collider.GetComponent<Cell>().GroudState != ID)
                        {
                            Hitup.collider.GetComponent<Cell>().CellAttackPoint = Range - 1 - i;
                            Hitup.collider.GetComponent<Cell>().AttackAble = true;
                            Hitup.collider.GetComponent<Cell>().AttackCell.SetActive(true);
                            Hitup.collider.GetComponent<Cell>().AttackCell.transform.position = new Vector3(Hitup.collider.gameObject.GetComponent<Cell>().AttackCell.transform.position.x, Hitup.collider.GetComponent<Cell>().AttackCell.transform.position.y, (float)-0.1);
                            AttackCell.Add(Hitup.collider.gameObject);
                        }
                    }
                    RaycastHit2D[] Hitlefts = Physics2D.RaycastAll(Cell.transform.position, Vector2.left, (float)1.1);
                    foreach (var Hitleft in Hitlefts)
                    {
                        if (Hitleft.collider.CompareTag("role") && Hitleft.collider.GetComponent<Role>().TeamNumber != Selected.GetComponent<Role>().TeamNumber)
                            Hitleft.collider.GetComponent<Role>().CanBeAttack = true;
                        if (Hitleft.collider.CompareTag("cell") && Hitleft.collider.GetComponent<Cell>().CellAttackPoint == 0 && Hitleft.collider.GetComponent<Cell>().GroudState !=ID)
                        {
                            Hitleft.collider.GetComponent<Cell>().CellAttackPoint = Range - 1 - i;
                            Hitleft.collider.GetComponent<Cell>().AttackAble = true;
                            Hitleft.collider.GetComponent<Cell>().AttackCell.SetActive(true);
                            Hitleft.collider.GetComponent<Cell>().AttackCell.transform.position = new Vector3(Hitleft.collider.GetComponent<Cell>().AttackCell.transform.position.x, Hitleft.collider.GetComponent<Cell>().AttackCell.transform.position.y, (float)-0.1);
                            AttackCell.Add(Hitleft.collider.gameObject);
                        }
                    }
                    RaycastHit2D[] Hitdowns = Physics2D.RaycastAll(Cell.transform.position, Vector2.down, (float)1.1);
                    foreach (var Hitdown in Hitdowns)
                    {
                        if (Hitdown.collider.CompareTag("role") && Hitdown.collider.GetComponent<Role>().TeamNumber != Selected.GetComponent<Role>().TeamNumber)
                            Hitdown.collider.GetComponent<Role>().CanBeAttack = true;
                        if (Hitdown.collider.CompareTag("cell") && Hitdown.collider.GetComponent<Cell>().CellAttackPoint == 0 && Hitdown.collider.GetComponent<Cell>().GroudState !=ID)
                        {
                            Hitdown.collider.GetComponent<Cell>().CellAttackPoint = Range - 1 - i;
                            Hitdown.collider.GetComponent<Cell>().AttackAble = true;
                            Hitdown.collider.GetComponent<Cell>().AttackCell.SetActive(true);
                            Hitdown.collider.GetComponent<Cell>().AttackCell.transform.position = new Vector3(Hitdown.collider.GetComponent<Cell>().AttackCell.transform.position.x, Hitdown.collider.GetComponent<Cell>().AttackCell.transform.position.y, (float)-0.1);
                            AttackCell.Add(Hitdown.collider.gameObject);
                        }
                    }
                    RaycastHit2D[] Hitrights = Physics2D.RaycastAll(Cell.transform.position, Vector2.right, (float)1.1);
                    foreach (var Hitright in Hitrights)
                    {
                        if (Hitright.collider.CompareTag("role") && Hitright.collider.GetComponent<Role>().TeamNumber != Selected.GetComponent<Role>().TeamNumber)
                            Hitright.collider.GetComponent<Role>().CanBeAttack = true;
                        if (Hitright.collider.CompareTag("cell") && Hitright.collider.GetComponent<Cell>().CellAttackPoint == 0 && Hitright.collider.GetComponent<Cell>().GroudState !=ID)
                        {
                            Hitright.collider.GetComponent<Cell>().CellAttackPoint = Range - 1 - i;
                            Hitright.collider.GetComponent<Cell>().AttackAble = true;
                            Hitright.collider.GetComponent<Cell>().AttackCell.SetActive(true);
                            Hitright.collider.GetComponent<Cell>().AttackCell.transform.position = new Vector3(Hitright.collider.GetComponent<Cell>().AttackCell.transform.position.x, Hitright.collider.GetComponent<Cell>().AttackCell.transform.position.y, (float)-0.1);
                            AttackCell.Add(Hitright.collider.gameObject);
                        }
                    }
                }
            }
        }
    }
    public void CloseMove()
    {
        foreach(var Cell in MoveCell)
        {
            Cell.GetComponent<Cell>().MoveAble = false;
            Cell.GetComponent<Cell>().MoveCell.SetActive(false);
        }
        MoveCell.Clear();
    }
    public void CloseAttack()
    {
        foreach(var Role in Roles)
        {
            Role.GetComponent<Role>().CanBeAttack = false;
        }
        foreach (var Cell in AttackCell)
        {
            Cell.GetComponent<Cell>().AttackAble = false;
            Cell.GetComponent<Cell>().AttackCell.SetActive(false);
        }
        AttackCell.Clear();
    }
    public void ResetCellMovePoint()
    {
        foreach(var Cell in MoveCell)
        {
            Cell.GetComponent<Cell>().CellMovePoint = 0;
        }
    }
    public void ResetCellAttackPoint()
    {
        foreach(var Cell in AttackCell)
        {
            Cell.GetComponent<Cell>().CellAttackPoint = 0;
        }
    }
    public void Action(int MainType,int ViceType)
    {
        if (MainType == 0)
        {

        }
        if (MainType == 1)
        {
            Weapon.GetComponent<Weapon>().ActionOfWeapon(ViceType);
        }
    }
    public void NextTurn()
    {
        if (IfAction && IfMove)
        {
            IfAction = false;
            IfMove = false;
            ResetCellAttackPoint();
            ResetCellMovePoint();
            for(int i = 1; i < SumOfRole; i++)
            {
                if (OrderTimes[i-1] > OrderTimes[i])
                {
                    int t1,t2;
                    t1 = OrderTimes[i-1];
                    t2 = OrderIds[i-1];
                    OrderTimes[i - 1] = OrderTimes[i];
                    OrderIds[i - 1] = OrderIds[i];
                    OrderTimes[i] = t1;
                    OrderIds[i] = t2;
                }

            }
            int Sum = OrderTimes[0];
            for (int i = 0; i < SumOfRole; i++)
            {
                OrderTimes[i] -= Sum;
            }
            foreach (var Role in Roles)
            {
                if (Role.GetComponent<Role>().RoleId == OrderIds[0])
                {
                    Selected = Role;
                    Selected.GetComponent<Role>().RoleMovePoint = Selected.GetComponent<Role>().Agility / 10;
                    if (Selected.GetComponent<Role>().Agility < 10)
                        Selected.GetComponent<Role>().RoleMovePoint = 1;
                    Selected.GetComponent<Role>().SetCellMovePoint();
                }
            }
        }
    }
}
