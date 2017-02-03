if (Cache["key"] == null)
{
    Cache.Insert(key, BllMethodToGetInstance(), ...);
}
return Cache["key"];