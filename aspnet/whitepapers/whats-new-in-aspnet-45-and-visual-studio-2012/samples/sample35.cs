function GetOrSet(key, value) {
/// <signature>
///	 <summary>Gets the value</summary>
///	 <param name="key" type="String">The key to get the value for</param>
///	 <returns type="String" />
/// </signature>
/// <signature>
///	 <summary>Sets the value</summary>
///	 <param name="key" type="String">The key to set the value for</param>
///	 <param name="value" type="String">The value to set</param>
///	 <returns type="MyLib" />
/// </signature>
	if (value) {
		values[key] = value;
		return this;
	} else {
		return values[key];
	}
}