using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement_transform : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float rot_speed;

    [SerializeField] private Vector3 v;

    [SerializeField] private PlayerBehavior p;
    [SerializeField] private PlayerInteractions i;

    [SerializeField] private Image respawnScreen;

    [SerializeField] private AudioSource of;


    private Quaternion rot = new Quaternion();


    private void Start()
    {
        speed = initialSpeed;
    }

    private void Update()
    {

        if (i.start == true)
        {
            if (p.running)
            {
                PlayerMove();
            }
            else
            {
                of.Play();
                respawnScreen.gameObject.SetActive(true);
                StartCoroutine(Respawn());
               
            }
        }
        
        

        
    }

    private bool VerificareDacaSeUitaInSpate(Quaternion rot)
    {
        float x = rot.eulerAngles.x;
        float y = rot.eulerAngles.y;

        if (x < 180) // ne uitam in jos
        {
            if(x > 60)
            {
                return true;
            }
        }
        if(x > 180) // ne uitam in sus
        {
            if(x < 280)
            {
                return true;
            }
        }

        if(y < 180) // ne uitam in dreapta
        {
            if(y > 90)
            {
                return true;
            }
        }
        if(y > 180) // stanga
        {
            if(y < 270)
            {
                return true;
            }
        }

        return false;
    }

    private void PlayerMove()
    {
        transform.localPosition += new Vector3(0.0f, 0.0f, speed) * Time.deltaTime; // for forward movement

        rot = transform.localRotation; // get the rotation
        float Xaxis = rot.eulerAngles.x;
        float Yaxis = rot.eulerAngles.y;
        float Zaxis = rot.eulerAngles.z;

        
        if(VerificareDacaSeUitaInSpate(rot))
        {
            p.running = false;
        }
        

        // luam axele de miscare
        if (rot.eulerAngles.x < 180)
        {
            Xaxis = -rot.eulerAngles.x;
        }
        else
        {
            Xaxis = 360 - rot.eulerAngles.x;
        }
        
        if (rot.eulerAngles.y < 180)
        {
            Yaxis = rot.eulerAngles.y;
        }
        else
        {
            Yaxis = -360 + rot.eulerAngles.y;
        }

        Xaxis /= 100;
        Yaxis /= 100;
        

        v.x = rot.eulerAngles.x;
        v.y = rot.eulerAngles.y;
        v.z = Zaxis;



        if (InGoodPositionX(Yaxis))
        {
            transform.localPosition += new Vector3(rot_speed * Yaxis * (speed/10), 0.0f, 0.0f) * Time.deltaTime;
        }
        
        if (InGoodPositionY(Xaxis))
        {
            transform.localPosition += new Vector3(0.0f, rot_speed * Xaxis * (speed/10), 0.0f) * Time.deltaTime;
        }

        SpeedIncreaseOnAngle(Xaxis);
    }

    

    private bool InGoodPositionX(float axis)
    {
        if (transform.localPosition.x > 7.5)
        {
            if(axis > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (transform.localPosition.x < -7.5)
        {
            if(axis < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }

    private bool InGoodPositionY(float axis)
    {
        if (transform.localPosition.y > 15)
        {
            if(axis > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (transform.localPosition.y < 0)
        {
            if(axis < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }


    private void SpeedIncreaseOnAngle(float x)
    {
        if ((x > 0.07f || x < -0.07f) && (x < 0.3f || x > -0.3f))
        {
            speed = initialSpeed * (1 - x);
        }
        else
        {
            speed = initialSpeed;
        }
    }

    public float GetSpeed()
    {
        return speed;
    }


    private IEnumerator Respawn()
    {


        yield return new WaitForSeconds(5);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }



}
