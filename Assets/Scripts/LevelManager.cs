using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public GameObject currentCheckpoint;
    private PlayerController playerController;
    private float save;    
    
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    public int deathPenalty;

    private CameraController cameras;
    // Use this for initialization
    void Start () {
        playerController = FindObjectOfType<PlayerController>();
        cameras = FindObjectOfType<CameraController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }
    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, playerController.transform.position, playerController.transform.rotation);
        playerController.enabled = false;
        save = playerController.GetComponent<Rigidbody2D>().gravityScale;
        playerController.GetComponent<Rigidbody2D>().gravityScale = 0f;
        playerController.GetComponent<Renderer>().enabled = false;
        cameras.isFollowing = false;
        playerController.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        KillPlayer.Killable(false);
        ScoreManager.AddPoints(-deathPenalty);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        //ScoreManager.reset();
        playerController.GetComponent<Rigidbody2D>().gravityScale = save;
        playerController.transform.position = currentCheckpoint.transform.position;
        cameras.isFollowing = true;
        playerController.enabled = true;
        playerController.GetComponent<Renderer>().enabled = true;
        KillPlayer.Killable(true);
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
