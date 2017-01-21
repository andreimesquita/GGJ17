using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorManager : MonoBehaviour
{
    [SerializeField]
    private Image[] spaceshipImages;

    [SerializeField]
    private Sprite[] spaceshipsSprites;

    private readonly int[] spaceshipsSelected = new []{0, 0};

    public void Previous(int id)
    {
        spaceshipsSelected[id]--;

        Debug.Log(spaceshipsSelected[id]);

        spaceshipsSelected[id] = Validate(id);

        UpdateSpaceshipSprite(id);
    }

    public void Next(int id)
    {
        spaceshipsSelected[id]++;

        Debug.Log(spaceshipsSelected[id]);

        spaceshipsSelected[id] = Validate(id);

        UpdateSpaceshipSprite(id);
    }

    private int Validate(int id)
    {
        if (spaceshipsSelected[id] < 0)
        {
            return spaceshipsSprites.Length - 1;
        }
        else if (spaceshipsSelected[id] >= spaceshipsSprites.Length)
        {
            return 0;
        }

        return spaceshipsSelected[id];
    }

    private void UpdateSpaceshipSprite(int id)
    {
        spaceshipImages[id].sprite = spaceshipsSprites[spaceshipsSelected[id]];
    }

}