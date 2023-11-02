using UnityEngine;
using System.Collections;

public class FruitSalad2 : MonoBehaviour
{
    void Start()
    {
        Apple2 myApple = new Apple2();

        //Notice that the Apple version of the methods
        //override the fruit versions. Also notice that
        //since the Apple versions call the Fruit version with
        //the "base" keyword, both are called.
        myApple.SayHello();
        myApple.Chop();

        //Overriding is also useful in a polymorphic situation.
        //Since the methods of the Fruit class are "virtual" and
        //the methods of the Apple class are "override", when we 
        //upcast an Apple into a Fruit, the Apple version of the 
        //Methods are used.
        Fruit2 myFruit = new Apple2();
        myFruit.SayHello();
        myFruit.Chop();
    }
}
