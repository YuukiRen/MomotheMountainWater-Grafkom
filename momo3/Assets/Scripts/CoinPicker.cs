using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour {
    public int point;

	public AudioSource coinSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            return;
        }
        ScoreManager.AddPoints(point);

		coinSoundEffect.Play ();
        Destroy(gameObject);
    }
}
