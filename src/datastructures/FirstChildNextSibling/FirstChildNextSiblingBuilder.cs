namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_Empty ()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string> ();
            return tree;
        }

        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_Small ()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string> ();

            FirstChildNextSiblingNode<string> e = new FirstChildNextSiblingNode<string>("e");
            FirstChildNextSiblingNode<string> d = new FirstChildNextSiblingNode<string>("d");
            FirstChildNextSiblingNode<string> c = new FirstChildNextSiblingNode<string>("c", null, d);
            FirstChildNextSiblingNode<string> b = new FirstChildNextSiblingNode<string>("b", e, c);
            FirstChildNextSiblingNode<string> a = new FirstChildNextSiblingNode<string>("a", b, null);

            tree.root = a;

            return tree;
        }

        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_18_3 ()
        {
            var tree = new FirstChildNextSibling<string> ();

            var k = new FirstChildNextSiblingNode<string>("k");
            var j = new FirstChildNextSiblingNode<string>("j", k, null);
            var i = new FirstChildNextSiblingNode<string>("i", null, j);
            var h = new FirstChildNextSiblingNode<string>("h");
            var g = new FirstChildNextSiblingNode<string>("g");
            var f = new FirstChildNextSiblingNode<string>("f", null, g);
            var e = new FirstChildNextSiblingNode<string>("e", i, null);
            var d = new FirstChildNextSiblingNode<string>("d", h, e);
            var c = new FirstChildNextSiblingNode<string>("c", null, d);
            var b = new FirstChildNextSiblingNode<string>("b",f ,c );
            var a = new FirstChildNextSiblingNode<string>("a", b, null);

            tree.root = a;
            return tree;
        }
    }
}