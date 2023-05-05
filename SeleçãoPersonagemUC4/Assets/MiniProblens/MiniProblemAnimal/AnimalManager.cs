using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalManager : MonoBehaviour
{
    public List<Sprite> imgAnimal;
    public List<Image> animalList;
    public List<Image> blackAnimalList;
    public Image animal;
    public Image blackAnimal;
    public Transform folder;
    public float space;
    Dictionary<Sprite, int> spritesAddList = new Dictionary<Sprite, int>();

    void Start()
    {
        Image[,] grid = new Image[2, 6];

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Vector3 pos = new Vector3(j - 2.5f, i +0.5f, 0) * space;
                Image newAnimal = Instantiate(animal, folder);

                if (i == 0)
                {
                    pos = new Vector3(j - 2.5f, i - 1.6f, 0) * space;
                    newAnimal.color = new Color(0,0,0,1);
                }
                newAnimal.transform.localPosition = pos;
                animalList.Add(newAnimal);
            }
        }

        /*List<int> availableImageIndices = new List<int>();
        for (int i = 0; i < imgAnimal.Count; i++)
        {
            if (imgAnimal[i] != null)
            {
                availableImageIndices.Add(i);
            }
        }

        for (int i = 0; i < animalList.Count; i++)
        {
            int spriteIndex = UnityEngine.Random.Range(0, imgAnimal.Count);
            Sprite randomSprite = imgAnimal[spriteIndex];
            imgAnimal.RemoveAt(spriteIndex);
            animal.sprite = randomSprite;

            if (spritesAddList.ContainsKey(animal.sprite) && spritesAddList[animal.sprite] >= 1)
            {
                availableImageIndices.RemoveAt(spriteIndex);
            }
            else
            {
                if (spritesAddList.ContainsKey(animal.sprite))
                {
                    spritesAddList[animal.sprite]++;
                }
                else
                {
                    spritesAddList.Add(animal.sprite, 1);
                }
            }
        }*/
    }
}
