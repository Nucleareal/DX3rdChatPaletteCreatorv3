namespace DX3rdChatPaletteCreatorv3
{
    public class TupleItem<T1, T2>
    {
        public TupleItem(T1 t1, T2 t2)
        {
            Item1 = t1;
            Item2 = t2;
        }

        public T1 Item1 { private set; get; }
        public T2 Item2 { private set; get; }
    }
}