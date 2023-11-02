using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polymorphism : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal myAnimal = new Animal();  // Create a Animal object
        Animal myPig = new Pig();  // Create a Pig object
        Animal myDog = new Dog();  // Create a Dog object

        myAnimal.animalSound();
        myPig.animalSound();
        myDog.animalSound();
    }


}


class Animal  // Base class (parent) uses virtual
{
    public virtual void animalSound()
    {
        Debug.Log("The animal makes a sound");
    }
}

class Pig : Animal  // Derived class (child) uses override
{
    public override void animalSound()
    {
        Debug.Log("The pig says: wee wee");
    }
}

class Dog : Animal  // Derived class (child) uses override
{
    public override void animalSound()
    {
        Debug.Log("The dog says: bow wow");
    }
}