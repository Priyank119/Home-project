using UnityEngine;

public class DeathBall : MonoBehaviour
{
    private ScoreUI _scoreUI;
    public float _getScore;
    public AudioClip _hit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "arrow")
        {
            _scoreUI.getTotalScore();
            this.GetComponent<AudioSource>().PlayOneShot(_hit);
            float desolve = Mathf.Lerp(-1f, 1f, 0.5f);
            this.GetComponent<MeshRenderer>().material.SetFloat("_Desolve", desolve);
        }
    }
}
