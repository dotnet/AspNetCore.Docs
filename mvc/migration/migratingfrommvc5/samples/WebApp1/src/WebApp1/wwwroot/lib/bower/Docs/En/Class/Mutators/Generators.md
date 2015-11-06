# atom.Class.Mutators.Generators

Used to DRY such pattern:

	MyClass = atom.Class({
		_property: null,
		get property () {
			if (this._property == null) {
				this._property = countValue();
			}
			return this._property;
		}
	});

You can use Generators mutators instead (it will be counted only once):

	MyClass = atom.Class({
		Generators: {
			property: function () {
				return countValue();
			}
		}
	});