# Live2DLighting
Experiments with Live2D models and lighting/post-processing. :sparkles:

## Example
See [this video](https://www.youtube.com/watch?v=Yj6OkmbFB2A) (https://www.youtube.com/watch?v=Yj6OkmbFB2A) for a few example scenes created with the effects contained in this repository.

![Screenshot](https://raw.githubusercontent.com/DenchiSoft/Live2DLighting/master/img/preview.png "Screenshot")
![Screenshot](https://raw.githubusercontent.com/DenchiSoft/Live2DLighting/master/img/lighting_simple.gif "Screenshot")



## Scenes
* __`SampleScene:`__ Live2D model with some post processing applied.
* __`SenkoNormalMapped:`__ Live2D model with lighting using a hand-painted normal map.

## A note on the models
There are two models in the scene, both being rendered to separate RenderTextures. The first one is just the model with the regular model texture. The second model is used for rendering to a RenderTexture that will be used as a normal map. 

For this second model, the regular texture has been replaced with a texture containing the normals. Such a texture can be manually created with a program such as [SpriteIlluminator](https://www.codeandweb.com/spriteilluminator) or any graphics software like Photoshop or Sai.

## License
[MIT License](https://github.com/DenchiSoft/Live2DLighting/blob/master/LICENSE)

Contains components from [Kino](https://github.com/keijiro/Kino) by Keijiro Takahashi, also released under MIT license.
