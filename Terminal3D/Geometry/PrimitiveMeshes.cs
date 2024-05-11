namespace Terminal_3D.Geometry
{
    public static class PrimitiveMeshes
    {
        public static Mesh CreatePlain(Vector3 position, Vector3 scale)
        {
            Vector3 bottomLeft = new Vector3(position.X, position.Y, position.Z);
            Vector3 bottomRight = new Vector3(position.X + scale.X, position.Y, position.Z);
            Vector3 topLeft = new Vector3(position.X, position.Y, position.Z + scale.Z);
            Vector3 topRight = new Vector3(position.X + scale.X, position.Y, position.Z + scale.Z);

            Mesh plainMesh = new Mesh();
            plainMesh.AddVertex(new Vertex(bottomLeft));
            plainMesh.AddVertex(new Vertex(bottomRight));
            plainMesh.AddVertex(new Vertex(topRight));
            plainMesh.AddVertex(new Vertex(topLeft));

            plainMesh.AddEdge(0, 1);
            plainMesh.AddEdge(1, 2);
            plainMesh.AddEdge(2, 3);
            plainMesh.AddEdge(3, 0);

            return plainMesh;
        }
        public static Mesh CreateCube(Vector3 position, Vector3 scale)
        {
            Mesh cubeMesh = new Mesh();

            // top
            Vector3 t_bottomLeft = new Vector3(position.X, position.Y, position.Z);
            Vector3 t_bottomRight = new Vector3(position.X + scale.X, position.Y, position.Z);
            Vector3 t_topLeft = new Vector3(position.X, position.Y, position.Z + scale.Z);
            Vector3 t_topRight = new Vector3(position.X + scale.X, position.Y, position.Z + scale.Z);

            cubeMesh.AddVertex(new Vertex(t_bottomLeft));
            cubeMesh.AddVertex(new Vertex(t_bottomRight));
            cubeMesh.AddVertex(new Vertex(t_topRight));
            cubeMesh.AddVertex(new Vertex(t_topLeft));

            cubeMesh.AddEdge(0, 1);
            cubeMesh.AddEdge(1, 2);
            cubeMesh.AddEdge(2, 3);
            cubeMesh.AddEdge(3, 0);
            
            // bottom
            Vector3 b_bottomLeft = new Vector3(position.X, position.Y + scale.Y, position.Z);
            Vector3 b_bottomRight = new Vector3(position.X + scale.X, position.Y + scale.Y, position.Z);
            Vector3 b_topLeft = new Vector3(position.X, position.Y + scale.Y, position.Z + scale.Z);
            Vector3 b_topRight = new Vector3(position.X + scale.X, position.Y + scale.Y, position.Z + scale.Z);

            cubeMesh.AddVertex(new Vertex(b_bottomLeft));
            cubeMesh.AddVertex(new Vertex(b_bottomRight));
            cubeMesh.AddVertex(new Vertex(b_topRight));
            cubeMesh.AddVertex(new Vertex(b_topLeft));

            cubeMesh.AddEdge(4, 5);
            cubeMesh.AddEdge(5, 6);
            cubeMesh.AddEdge(6, 7);
            cubeMesh.AddEdge(7, 4);

            // sides
            cubeMesh.AddEdge(0, 4);
            cubeMesh.AddEdge(1, 5);
            cubeMesh.AddEdge(2, 6);
            cubeMesh.AddEdge(3, 7);


            return cubeMesh;
        }
    }
}
