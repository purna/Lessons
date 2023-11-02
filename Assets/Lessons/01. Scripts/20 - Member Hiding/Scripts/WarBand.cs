using UnityEngine;
using System.Collections;
public class WarBand : MonoBehaviour
{
    void Start()
    {
        Humanoid human = new Humanoid();
        Humanoid enemies = new Enemies();
        Humanoid orc = new Orc();
        //Notice how each Humanoid variable contains a reference to a different class
        //in the inheritance hierarchy, yet each of them calls the Humanoid Yell() method.

        Debug.Log("-----------------");
        human.Yell();
        enemies.Yell();
        orc.Yell();
        Debug.Log("-----------------");

        Humanoid human2 = new Humanoid();
        Enemies enemies2 = new Enemies();
        Orc orc2 = new Orc();

        Debug.Log("-----------------");
        human2.Yell();
        enemies2.Yell();
        orc2.Yell();
        Debug.Log("-----------------");

    }
}
