using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    WAIT,
    PATROL,
    ATTACK
}

public class Enemy : MonoBehaviour
{
    public State state = State.PATROL;
    NavMeshAgent nav;
    GameObject[] waypoints;
    GameObject player;
    public float timeToWait = 3f;
    public float agroRange = 10f;
    float timer = 0f;
    Vector3 targetWaypoint;
	// Use this for initialization
	void Start ()
    {
        nav = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        player = GameObject.FindGameObjectWithTag("Player");
        targetWaypoint = PickNewWaypoint();
        //nav.SetDestination(targetWaypoint);
	}
	
    Vector3 PickNewWaypoint()
    {
        return waypoints[Random.Range(0, waypoints.Length)].transform.position;
    }

	// Update is called once per frame
	void Update ()
    {
		if(waypoints.Length == 0)
        {
            Debug.LogError("No waypoints found!");
            return;
        }
        if(state == State.PATROL)
        {
            nav.destination = targetWaypoint;
            if (Vector3.Distance(transform.position, targetWaypoint) <= 1f)
                state = State.WAIT;
        }
        if(state == State.WAIT)
        {
            timer += Time.deltaTime;
            if(timer >= timeToWait)
            {
                timer = 0f;
                state = State.PATROL;
                targetWaypoint = PickNewWaypoint();
            }
        }
        if (Vector3.Distance(player.transform.position, transform.position) < agroRange)
            state = State.ATTACK; //Distance check to player
        else if(state == State.ATTACK) //Did the player get away?
        {
            state = State.PATROL;
            targetWaypoint = PickNewWaypoint();
        }
        if (state == State.ATTACK) //Attack the player 
            nav.destination = player.transform.position;
	}
}
