using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;

public class SpawnController : MonoBehaviour {

    public GameObject knife;
    public GameObject bow_string_1;
    public GameObject bow_string_2;
    public bool relese;
     Knife Knife_kom;
    public  AudioSource relese_arow;
    public AudioSource give_arow;
    public AudioSource ra;
    public AudioSource ga;
    public GameObject going_dark;
    public float time_of_replay = 15f;


    // Use this for initialization
    void Start () 
    {
        going_dark.SetActive(false);
        //    relese_arow = GetComponent<AudioSource>();
        // give_arow = GetComponent<AudioClip>();
       // ra = GetComponent<AudioSource>.();
        CreateKnife();
        //Knife Knife_kom = GetComponent<Knife>();
        if (Advertisement.isSupported) Advertisement.Initialize("3544792");
    }
	
	// Update is called once per frame
	void Update () 
    {if (Input.GetKeyDown(KeyCode.Escape)){ loadmenu();
        }

        if (PlayerPrefs.GetInt("relese") == 0) { relese = true; }
        if (PlayerPrefs.GetInt("relese") == 1) { relese =  false; }
        // if ((Input.GetMouseButtonDown(0)) && Knife_kom.moving == true)
        //if( GameObject.Find("Knife").GetComponent<Knife>.)
        // { relese = true; }
        if (relese)
        {
           // relese_arow.Play();
            bow_string_1.SetActive(false);
            bow_string_2.SetActive(true);
            //GetComponent<AudioSource>().PlayOneShot(relese_arow);
        }
        //if (Knife_kom.)
        //{
        //    relese = true;
        //}
        if (!relese)
        {
            bow_string_1.SetActive(true);
            bow_string_2.SetActive(false);
        }


    }
    public void goingdark() { going_dark.SetActive(true); }

    public void loadmenu() { SceneManager.LoadScene(0); going_dark.SetActive(true); StartCoroutine(Showsads()); }
   
    public void CreateKnife()
    {
        give_arow.Play();
       // give_arow.Play();
       // GetComponent<AudioSource>().PlayOneShot(give_arow);
        PlayerPrefs.SetInt("relese", 1);
       
        // Create knife if Trunk is alive!
        if(GameObject.Find("Trunk").GetComponent<TrunkHealth>().health > 1)
         
        Instantiate(knife, transform.position, Quaternion.identity);
    }
    IEnumerator Showsads()
    {
        yield return new WaitForSeconds(0.5f);
        while (!Advertisement.IsReady()) { yield return null; }
        Advertisement.Show();
        yield return new WaitForSeconds(time_of_replay);
        while (!Advertisement.IsReady()) yield return null;
        if (Advertisement.IsReady()) Advertisement.Show();
        yield break;
    }
}
