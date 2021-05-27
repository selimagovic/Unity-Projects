using UnityEngine;
using UnityEngine.UI;

public class CoinPickUp : MonoBehaviour
{
    public AudioClip aClip;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            ScoreScript.score+=1;
            AudioSource.PlayClipAtPoint(aClip, transform.position);           
            Destroy(gameObject);
        }            
    }
	
}
