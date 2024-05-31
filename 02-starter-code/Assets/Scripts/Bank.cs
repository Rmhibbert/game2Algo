using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{

    private int money = 50;
    private AudioSource chaChingSFX;


    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            chaChingSFX.Play();
        }
    }

    public void SomeFunction()
    {
        Money = 50; // money will now be 50, cha-ching SFX plays.
        Money += 50; // money is now 100, cha-ching SFX plays again.
        Money = Money - 75; // money is now 25, cha-ching SFX plays a 3rd time.
    }
}
