using So;
using UnityEngine;
using Util;

[RequireComponent(typeof(SpriteRenderer))]
public class SpaceshipBehaviour : MonoBehaviour
{
    [SerializeField] private int playerId;
    [SerializeField] private SpaceshipsListSo spaceshipsListSo;

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

        this.gameObject.SetActive(false);
    }
}