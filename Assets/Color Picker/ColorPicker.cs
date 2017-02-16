//CREATED BY HARDLYBRIEFDAN

using UnityEngine;
using System.Collections;

public class ColorPicker : MonoBehaviour {

	//texture or image of colors
    public Texture2D colorsPalette;
    //number of rows
    public int numRows;
    //number of cols
    public int numCols;
    //texture size
    public int textureSize;

    //color array, just to load all colors instead of sampling multiple times
    private Color32[] allColors;
    //total color number
    private int totalNumColors;
    //selected color
    private Color32 selectedColor;

    //show selected color
    public UnityEngine.UI.Image selectedColorImage;
    //keep count for color array
    private int count;
    //color offsets for meshes
    private Vector2[] colorOffsets;

    //when we enable the selection gui check to see if we have already loaded the palette
    void OnEnable()
    {
        if(allColors == null)
            CreateColorsArray();
        
        selectedColorImage.color = allColors[0];
    
    }

    //sample the texture
    //Takes in two values, x and y offsets as floats, multiplies them by the texture size and then casts them as an int for the the  get pixel call.
    //this ONLY should be used if you are going to have solid colors!!!!
    private Color32 SamplePaletteTexture(float xOffset, float yOffset)
    {
        Color32 color = colorsPalette.GetPixel((int)(xOffset * textureSize) - 5, (int)(yOffset * textureSize) - 5);
        return color;
    }

    //Creates two arrays. One array is of the colors values within the texture. The other array stores the offsets in a vector2 for the mesh render
    //If you are NOT using solid colors then DO NOT sample the texture with get pixel. You DO NOT need the allColors array if you are NOT using solid colors.
    private void CreateColorsArray()
    {
        totalNumColors = numRows * numCols; //total number of little boxes in the texture
        allColors = new Color32[totalNumColors];    //all colors array, for solid colors
        colorOffsets = new Vector2[totalNumColors]; //for game object meshes, for things likes faces
        int totalCount = 0; //used to keep track of the index value
        for (int x = 0; x < numRows; x++)
        {
            for (int y = 0; y < numCols; y++)
            {
                allColors[totalCount] = SamplePaletteTexture(((x + 1f) / numRows), ((y + 1f) / numCols));   //calls the above method to get the correct pixel value, used for SOLID COLORS ONLY
                colorOffsets[totalCount] = new Vector2(((float)(x) / numRows), ((float)(y) / numCols)); //grabs the offset as a vector2 and stores it in the array, used for multiple textures like faces
                totalCount++;   //increments the index count
            }
        }
    }


    //USED FOR THE UI!!!
    //apply to the increment and decrement buttons to move through the array of colors
    public void ChangeColor(int num)
    {
        count += num;
        if (count < 0)  //checks to make sure we never go below index value of 0
            count = 0;
        if (count > totalNumColors - 1) //checks to make sure we never go about the index value of the total number of colors - 1
            count = totalNumColors - 1;

        selectedColorImage.color = allColors[count];    //applies the color to the preview texture
    }

    //Gets called when you press the aplply image button in the UI
    public void ApplyColorToSprite(UnityEngine.UI.Image image)
    {
        image.color = allColors[count];
    }

    //Gets called when you press apply GO button in the UI
    //Pass in a gameobject, get its meshrenderer component, then its FIRST material in the materials list, and then we apply the correct offset of the preview color!
    public void ApplyColorToGameObject(GameObject gO)
    {
        gO.GetComponent<MeshRenderer>().material.mainTextureOffset = colorOffsets[count];
    }

}
