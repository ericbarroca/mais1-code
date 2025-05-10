public interface IRepository<T> {

    public T Get(int id);

    public bool Upsert(T entidade);

    public bool Remove(int id);

    public List<T> List();
}

public abstract class Repository<T> {

    protected List<T> items;

    public Repository() {
        items = new List<T>();
    }
}
