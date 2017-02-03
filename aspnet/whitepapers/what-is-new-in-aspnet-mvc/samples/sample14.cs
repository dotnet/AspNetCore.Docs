Controller c = new MyController();
c.ValueProvider = new ValueProviderDictionary(null) {
	{ "example1", "example1Value" },
	{ "example2", "example2Value" },
	{ "example3", new int[] { 1, 2, 3 } }
};