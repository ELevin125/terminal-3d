# Terminal 3D
<p align="middle">

  <img src="https://github.com/ELevin125/terminal-3d/assets/123626350/462bd8a9-1776-41c5-96b4-7b2b3f6039ae" style="width:600px;">
</p>
This project is a simple wireframe engine that will run in the terminal. The code utilizes a simple wireframe engine to render the environment in a 3D space, before converting and drawing the output into the terminal with ASCII characters.

## Controls

- **W**: Move forward
- **A**: Rotate camera left
- **S**: Move backward
- **D**: Rotate camera right

## The Engine
- `Engine`: Specifies the **Scene** to render, and which **Renderer** to use.
- `Renderer`: Contains the mothods to render **Mesh** objects and output it to the Terminal window.
- `Scenes`: Can be inherited from to describe the **Camera** and the **Meshes** contained in the scene.
- `Mesh`: A list of **Vertices** and joining **Edges** describing a model.
- `Camera`: An **Entity** that contains the **Screen Distance** used by the renderer.
- `Entity`: A movable entity in the 3D world.
