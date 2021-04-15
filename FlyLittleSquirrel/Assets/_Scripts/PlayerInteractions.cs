using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    public bool start;

    public bool startAnimation;

    public bool restart;

    [SerializeField] private AudioSource weee;

    [SerializeField] private Animator anim;

    private bool done = false;

    private int layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("UI");
    }

    private void Start()
    {
        start = false;
        startAnimation = false;
    }

    private void Update()
    {

        DoPlayerAnimations();

        restart = Input.GetKeyDown(KeyCode.R);
        startAnimation = Input.GetKeyDown(KeyCode.Space);

        if(restart)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50, layerMask))
        {

            Debug.Log("AM DAT START!");

            startAnimation = true;

            weee.Play();

            Destroy(hit.transform.gameObject);
        }


    }

    private void DoPlayerAnimations()
    {
        // greu de explicat ce am facut aici
        // cod scris la 9 dimineata :))
        // pe scurt aicia se face play la animatia de start si dupa se incepe jocul

        if (startAnimation && !done)
        {
            anim.SetTrigger("start");
            done = true;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAnimation") && anim.IsInTransition(0))
        {
            start = true;
        }
    }

}
