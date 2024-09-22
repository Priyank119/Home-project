using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : MonoBehaviour
{
    public ScoreUI _scoreUI;
    public float getScore;
    public AudioClip _hit;
    public GameObject arrowSpawner;
    private bool isDesolve;

    private float timeElapsed = 0;
    public float desolveDuration = 1;

    public List<Transform> waypoints;
    NavMeshAgent agent;
    public int currentWayPointIndex = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void hiding()
    {
        float distenceToWayPoint = Vector3.Distance(waypoints[currentWayPointIndex].position, transform.position);
        if (distenceToWayPoint <= 3)
        {
            currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Count;
        }
        agent.SetDestination(waypoints[currentWayPointIndex].position);
    }

    private void deathEffect()
    {
        if (timeElapsed < desolveDuration && isDesolve == true)
        {
            float t = timeElapsed / desolveDuration;
            float desolve = Mathf.Lerp(-1f, 1f, t);
            timeElapsed += Time.deltaTime;

            this.transform.GetComponentInChildren<SkinnedMeshRenderer>().material.SetFloat("_Desolve", desolve);
            if (timeElapsed > desolveDuration)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "arrow")
        {
            this.GetComponent<AudioSource>().PlayOneShot(_hit);
            getScore += 15;
            _scoreUI.getTotalScore();
            isDesolve = true;
            Destroy(arrowSpawner.transform.GetChild(0).gameObject, 1);
        }
    }
    private void Update()
    {
        this.GetComponent<Animator>().SetFloat("Speed", agent.velocity.magnitude / 2);
        hiding();
        deathEffect();
    }
}
