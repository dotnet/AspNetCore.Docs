[OutputCache(Duration = 100,
VaryByParam = "none")]
public string GetDate() {
    return DateTime.Now.ToString();
}