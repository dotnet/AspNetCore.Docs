
module('[MooTools]');

test('Prototypes.Array', function () {
	ok([1,2,3,0,0,0].contains(0), 'contains: element found');
	ok(![0,1,2].contains('not found'), 'contains: element not found');
	deepEqual([1,2,3,4].include(1).include(5), [1,2,3,4,5], 'include');

	new function () {
		var a = [1,2,4];
		var b = [2,3,4,5];
		a.append(b);
		deepEqual(a, [1,2,4,2,3,4,5], 'append');
		deepEqual(b, [2,3,4,5], 'append (original element left the same)');
	};

	deepEqual([1,2,3,0,0,0].erase(0), [1,2,3], 'erase');
	deepEqual([1,2,3,4].combine([3,1,4,5,6,7]), [1,2,3,4,5,6,7], 'combine');

	strictEqual([null, undefined, true, 1].pick(), true, 'pick: true');
	strictEqual([].pick(), null, 'pick: null');

	deepEqual([1,2,3,0,0,0].associate(['a', 'b', 'c', 'd']), {a:1, b:2, c:3, d:0}, 'associate');
	deepEqual([null, 1, 0, true, false, "foo", undefined].clean(), [1, 0, true, false, "foo"], 'clean');
	deepEqual([1,2,3,4].empty(), [], 'empty');

	new function () { // Array.hexToRgb
		strictEqual([].hexToRgb(), null, 'hexToRgb: null');
		strictEqual(['0','0','0'].hexToRgb(), 'rgb(0,0,0)', 'hexToRgb: string, digits');
		strictEqual(['c','c','c'].hexToRgb(), 'rgb(204,204,204)', 'hexToRgb: string, alpha');
		deepEqual(['ff','ff','ff'].hexToRgb(true), [255,255,255], 'hexToRgb: array');
	};

	new function () {
		strictEqual([0,1].rgbToHex(), null, 'rgbToHex: null');
		strictEqual(['255', '0', '0'].rgbToHex(), '#ff0000', 'rgbToHex: strings');
		strictEqual([0,0,255].rgbToHex(), '#0000ff', 'rgbToHex: numbers');
		deepEqual([0,255,0].rgbToHex(true), ['00', 'ff', '00'], 'rgbToHex: array');
	};
});