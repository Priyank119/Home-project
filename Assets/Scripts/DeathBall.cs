using UnityEngine;
public class DeathBall : MonoBehaviour
{
    public ScoreUI _scoreUI;
    public float getScore;
    public AudioClip _hit;
    public GameObject arrowSpawner;
    private bool isDesolve;

    private float timeElapsed = 0;
    public float desolveDuration = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "arrow")
        {
            this.GetComponent<AudioSource>().PlayOneShot(_hit);
            getScore += 10;
            _scoreUI.getTotalScore();
            isDesolve = true;
            Destroy(arrowSpawner.transform.GetChild(0).gameObject, 1);
        }
    }
    private void Update()
    {
        if (timeElapsed < desolveDuration && isDesolve == true)
        {
            float t = timeElapsed / desolveDuration;
            float desolve = Mathf.Lerp(-1f, 1f, t);
            timeElapsed += Time.deltaTime;

            this.GetComponent<MeshRenderer>().material.SetFloat("_Desolve", desolve);
            if (timeElapsed > desolveDuration)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
