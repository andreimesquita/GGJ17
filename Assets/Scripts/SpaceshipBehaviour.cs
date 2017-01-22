using So;
using UnityEngine;
using Util;

[RequireComponent(typeof(SpriteRenderer))]
public class SpaceshipBehaviour : MonoBehaviour
{
    [SerializeField] private int playerId;
    [SerializeField] private SpaceshipsListSo spaceshipsListSo;
    [SerializeField] private ParticleSystem explosionEffect;

    public SpaceshipMove spaceshipMove;

    private void Awake()
    {
        spaceshipMove = GetComponent<SpaceshipMove>();

        int selectedSpaceshipId;

        if (playerId == 0)
            selectedSpaceshipId = PlayerPrefs.GetInt(Constants.KEY_PLAYER_ONE_ID);
        else
            selectedSpaceshipId = PlayerPrefs.GetInt(Constants.KEY_PLAYER_TWO_ID);

        GetComponent<SpriteRenderer>().sprite = spaceshipsListSo.spaceshipsSprites[selectedSpaceshipId];
    }

    private void OnCollisionEnter(Collision other)
    {
        GameManager.Instance.NotifyPlayerDead();

        ParticleSystem explosion = Instantiate(this.explosionEffect) as ParticleSystem;

        explosion.transform.position = this.transform.position;
        explosion.Play();

        Destroy(explosion.gameObject, explosion.main.duration);

        this.gameObject.SetActive(false);
    }
}