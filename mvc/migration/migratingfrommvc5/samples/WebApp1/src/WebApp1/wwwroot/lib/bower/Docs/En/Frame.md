Atom Frame
==========

Provides interface to perform animation. It calls you function up to 60 times per second. 
Alternative (and wrapper in future) for `requestAnimationFrame`


### atom.frame.add(function callback)
Adds callback for animation

### atom.frame.remove(function callback)
Remove callback from animation

#### Example
	atom.frame.add(function animate() {
		element.left += 5;
		if (element.left > 100) {
			atom.frame.remove(animate);
		}
	});