using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text pointText;
    //public Animator animator;
   //public AudioSource deaths, losts, collects;

    public int point;

    //public GameObject panel;
    public Collider2D playerHitBox;

    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        UpdateStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Point"))
        {
            //collects.Play();
            //hit.GetComponent<Animator>().Play("Meat_Collected");
            //yield return new WaitForSeconds(0.1f);
            point++;
            UpdateStatus();
            Destroy(hit.gameObject);
        }
       if (hit.CompareTag("Enemy"))
        {
            if (playerHitBox.IsTouching(hit))
            {
                //deaths.Play();
                //animator.SetBool("IsHurting", true);
                SoundManagerScript.PlaySound("death");
                yield return new WaitForSeconds(0.5f);
                UpdateStatus();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }       
        if (hit.CompareTag("TileWater"))
        {
            

                //deaths.Play();
                //animator.SetBool("IsHurting", true);
                SoundManagerScript.PlaySound("death");
                yield return new WaitForSeconds(0.5f);
                UpdateStatus();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           
        }
    }

    private void UpdateStatus()
    {
        string message = point.ToString();
        pointText.text = message;
    }

    public void Saveplayer() 
    {
        SaveSystem.SavePlayer(this);
        

    }

    public void LoadPlayer() 
    {
        PlayerData data = SaveSystem.LoadPlayer();
        point = data.point;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        point = data.point;
        UpdateStatus();
    }


}
