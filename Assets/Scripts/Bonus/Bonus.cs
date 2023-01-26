using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject coin;

    private enum BonusType
    {
        Coin, Emerald, Ruby, Diamond, BlackDiamond
    }

    private Dictionary<BonusType, Color> colors;

    private Dictionary<BonusType, int> points;

    private BonusType bonus;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {

        bonus = RandomBonusType();
        speed = Utils.SpeedByDifficulty(Constantes.baseSpeed);

        InitPoints();
        InitColor();

        GetComponent<Renderer>().material.color = colors[bonus];

    }

    private void Update()
    {
        MooveBonus();
    }

    //When player get bonus object
    void OnTriggerEnter(Collider other)
    {
        Shared.scoreTotal += points[bonus];
        Destroy(coin);
    }

    //Spawn bonus depend on percentage
    private BonusType RandomBonusType()
    {
        var random = Random.Range(0, 100);

        //80%
        if (random <= 80)
            return BonusType.Coin;
        //14%
        if (random > 80 && random <= 94)
            return BonusType.Emerald;
        //5%
        if (random > 94 && random <= 99)
            return BonusType.Ruby;
        //0.5%
        return Random.Range(0, 1) == 0 ? BonusType.Diamond : BonusType.BlackDiamond;
    }

    private void InitColor()
    {
        colors = new Dictionary<BonusType, Color>(){
            {BonusType.Coin, Color.yellow},
            {BonusType.Emerald, Color.green},
            {BonusType.Ruby, Color.red},
            {BonusType.Diamond, Color.blue},
            {BonusType.BlackDiamond, Color.black},
        };
    }

    private void InitPoints()
    {
        points = new Dictionary<BonusType, int>(){
            {BonusType.Coin, 50},
            {BonusType.Emerald, 100},
            {BonusType.Ruby, 200},
            {BonusType.Diamond, 500},
            {BonusType.BlackDiamond, 500},
        };
    }

    private void MooveBonus()
    {
        transform.Translate(Vector3.back * speed);
    }
}
