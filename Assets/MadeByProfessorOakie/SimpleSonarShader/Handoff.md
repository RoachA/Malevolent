# Simple Sonar Shader Handoff 

## Background

### Development History
- Don't Make A Sound
- Built-in free version
- Released with many asks for URP
- Port to URP
- Add improvements on URP

### Why It Was Made
- Don't Make A Sound needed a visual effect to show the audio sources
- Was a good project to practice shipping
- Turned into a way to become familiar with URP

## Tech Decisions

### URP vs HDRP vs Built-in Pipeline
- Originally made before the new pipelines were really released
- URP was seeming to be popular in the community of people building games with smaller teams
- These smaller teams were the market I wanted to serve

## Code Structure

### Core implementation files
- SimpleSonarCore.hlsl: Contains the vertex and fragment shader functions which process the inputs and generate the rings.
- SimpleSonarShader.shader: Holds the properties for the shader and calls the Core functions. This is selectable on materials.
- SimpleSonarShader_SonarSender.cs: Base monobehavior singleton class for storing and sending data for sonar rings.


### Example files
- SimpleSonar.asset: Universal Render Pipeline asset containing the Renderer asset 
- SimpleSonar_Renderer.asset: Forward renderer data object that contains a custom Renderer Feature for the sonar effect.
- SimpleSonarShader_RenderFeature.mat: An example material for the example render feature.
- ColorMinis folder: This is a set of several fully set up simple example scenes that can be picked apart.

## Problems
- Feature parity between URP and Built-in is not there (features need to be brought back to built-in)
- Worst case memory transfer in a single frame is pretty high. 


## Future Direction
- Performance improvements: grouping sonar ring spawn data and not sending pre-existing data 
- URP and Built-in feature parity
- Can choose to work on different channels (normals, emmissive, etc)
- Texture based wave shapes
- Non-linear wave speed changes

## Links to Resources
- Unity Asset Store (Built-in): https://assetstore.unity.com/packages/vfx/shaders/simple-sonar-shader-lite-built-in-102734
- Unity Asset Store (URP): https://assetstore.unity.com/packages/vfx/shaders/simple-sonar-shader-urp-205656
