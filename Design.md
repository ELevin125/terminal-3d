## Systems:

### `Vector3`
- **Purpose**: Represents a 3D point or vector in space.
- **Properties**: `float X`, `float Y`, `float Z`.

### `Camera`
- **Purpose**: Represents the camera's position and orientation in the world.
- **Properties**: `Vector3 Position`, `Vector3 Rotation`.
- **Methods**: `Move`, `Rotate`.

### `Mesh`
- **Purpose**: Represents a collection of vertices that form an object.
- **Properties**: `List<Vector3> Vertices`, `List<Tuple<int, int>> Edges` (pairs of vertex indices forming edges).

### `Scene`
- **Purpose**: Contains all the objects in the world and the camera.
- **Properties**: `List<Mesh> Meshes`, `Camera ActiveCamera`.

### `Renderer`
- **Purpose**: Handles rendering of the scene using ASCII characters.
- **Properties**: `int Width`, `int Height` (size of the render target).
- **Methods**: `Render(Scene scene)`.

### `InputManager`
- **Purpose**: Handles user input to control the camera or other aspects of the scene.
- **Methods**: `UpdateCamera(Camera camera)`.

### `Engine`
- **Purpose**: The main class to set up and run the application.
- **Properties**: `Scene CurrentScene`, `Renderer Renderer`, `InputManager InputManager`.
- **Methods**: `Initialize`, `Update`, `Draw`.


## Interaction:
- **Interaction**:
  - `Engine` initializes and holds references to `Scene`, `Renderer`, and `InputManager`.
  - `Renderer` takes `Scene` as a parameter and uses `Camera` from `Scene` to render `Meshes`.
  - `InputManager` updates the `Camera` based on user inputs, affecting how the scene is rendered.


