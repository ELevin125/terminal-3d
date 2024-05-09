using Terminal_3D.Geometry;
using Terminal_3D.Rendering;

namespace Terminal_3D.SceneManagement
{
    public class Scene
    {
        public Camera MainCamera;
        public List<Mesh> AllMeshes = new List<Mesh>();
        public Scene()
        {
            MainCamera = new Camera(Vector3.Zero, Vector3.Zero);

            AllMeshes.Add(PrimitiveMeshes.CreateCube(new Vector3(-50, 0, 2500), new Vector3(200, 100, 1000)));
            AllMeshes.Add(PrimitiveMeshes.CreateCube(new Vector3(-500, -100, 4000), new Vector3(200, 200, 1000)));
        }

    }
}
