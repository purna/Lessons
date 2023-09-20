using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator animator;
    public float transitionDelayTime = 3.0f;
    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //As an example, we'll be using GetKey() to test out the transition
        //between game scenes, so if you are implementing this with this code
        //make sure to modify the code according to your needs.
        if (Input.GetKey(KeyCode.Space))
        {
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        }
    }

    IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}