using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;


public class TrunkHealth : MonoBehaviour {
    private InterstitialAd ad;
    public int health = 5;
    public AudioClip breakClip;
    public AudioClip startClip;
    public GameObject going_dark;
    private const string gameover = "";
    private const string banner =   "";
    public int i;
    public int a;
    public float time_of_replay = 15f;
    void Start()
    {
        //if (Advertisement.isSupported) Advertisement.Initialize("");
        //GetComponent<Renderer>().material.shader = Shader.Find("Models/Materials/FrontTex1");
        GameObject.Find("TextLevel").GetComponent<Text>().text = "Level " + SceneManager.GetActiveScene().buildIndex;
        GetComponent<AudioSource>().PlayOneShot(startClip);
        i = SceneManager.sceneCountInBuildSettings;
        a = SceneManager.GetActiveScene().buildIndex;
 



    }

    void Update()
    {

    }

    // Decrease health
	public void Damage(int value)
    {
        health -= value;

        if (health == 0) // If there is no health
        {

            PlayerPrefs.SetInt("relese", 0);
            // Deactive Trunk collider
            GetComponent<CircleCollider2D>().enabled = false;

            // Trunk fragmentation
            // Fragmention 1
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(400, 800, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(100, 100, 100);
            transform.GetChild(0).parent = null;
            // Fragmention 2
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-400, 800, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-100, 100, 100);
            transform.GetChild(0).parent = null;
            // Fragmention 3
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(0, 800, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-200, 100, -100);
            transform.GetChild(0).parent = null;

            while (transform.childCount > 0)
            {
                // Knives apart from Trunk
                transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400f, 400f), Random.Range(400f, 800f)));
                transform.GetChild(0).GetComponent<Rigidbody2D>().AddTorque(Random.Range(-400, 400));
                transform.GetChild(0).parent = null;
            }

            GetComponent<AudioSource>().PlayOneShot(breakClip);
     //       if (a == 10 ||  a == 20  ) { StartCoroutine(Showsads()); }
            // Show "YOU WIN!" and go to next level
            GameObject.Find("TextMessage").GetComponent<Text>().text = "YOU WIN!";
          //  if (i == 5 || i == 12 || i == 20 || i == 27 || i == 25) { reklama(); }
            StartCoroutine(NextLevel());
        }
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

    IEnumerator NextLevel()
    {
        // Go to next level after 2 seconds
        yield return new WaitForSeconds(2f);
        if (i > (SceneManager.GetActiveScene().buildIndex) + 1)
        {
          //  if (i == 5 || i ==12 || i == 20 || i == 25) { reklama(); }

            PlayerPrefs.SetInt("relese", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            going_dark.SetActive(true);
        }
        else
        {
            StartCoroutine(Showsads());
          //  reklama();
            SceneManager.LoadScene(0);
            going_dark.SetActive(true);
            PlayerPrefs.SetInt("relese", 0);
            PlayerPrefs.SetInt("end", 0);

        }
    }
    public void onAdLoad(object sender, System.EventArgs args)
    {
        ad.Show();

    }
    public void reklama()
        {
            ad = new InterstitialAd(gameover);
            AdRequest request = new AdRequest.Builder().Build();
            ad.LoadAd(request);
            ad.OnAdLoaded += onAdLoad;
        }

    
}
