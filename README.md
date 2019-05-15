# Live2DLighting
Experiments with Live2D models and lighting/post-processing.

## Example
See [this video](https://www.youtube.com/watch?v=Yj6OkmbFB2A) (https://www.youtube.com/watch?v=Yj6OkmbFB2A) for a few example scenes created with the effects contained in this repository.
![Screenshot](https://raw.githubusercontent.com/DenchiSoft/Live2DLighting/master/img/preview.png "Screenshot")

## A note on the models
There are two models in the scene, both being rendered to separate RenderTextures. The first one is just the model with the regular model texture. The second model is used for rendering to a RenderTexture that will be used as a normal map. For this second model, the idea would be to replace the regular model texture with a texture containing normals. Such a texture could be manually created with a program such as [SpriteIlluminator](https://www.codeandweb.com/spriteilluminator). 

In this scene, I just use the regular model texture as normal map since that _randomly_ gave sufficiently decent-looking results. Hence I could theoretically get away with just having one model. This may not be the case for other models. 

## License
[MIT License](https://github.com/DenchiSoft/Live2DLighting/blob/master/LICENSE)

Contains components from [Kino](https://github.com/keijiro/Kino) by Keijiro Takahashi, also released under MIT license.
