Type instance = Cache["key"] as Type;
if (instance == null)
{
    instance = BllMethodToGetInstance();
    Cache.Insert(key, instance, ...);
}
return instance;