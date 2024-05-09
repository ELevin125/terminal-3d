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

            AllMeshes.Add(PrimitiveMeshes.CreateCube(new Vector3(-50, 0, 2000), new Vector3(200, 100, 1000)));
        }

    }
}
