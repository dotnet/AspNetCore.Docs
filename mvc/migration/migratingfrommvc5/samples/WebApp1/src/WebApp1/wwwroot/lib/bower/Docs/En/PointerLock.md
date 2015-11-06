Pointer Lock
============

Provides interface for cross browser pointer locking


### atom.pointerLock.supports
Equals `true` if `PointerLock` supports:

```js
if (atom.pointerLock.supports) {
	console.log('PointerLock supports');
}
```

### atom.pointerLock.locked(DOMElement element)
Returns `true` if element is locked now:

```js
if (atom.pointerLock.locked(myCanvas)) {
	console.log('myCanvas locked');
}
```

### atom.pointerLock.request(DOMElement element, function callback)
Try to pointer lock `element` & then calls `callback` on mouse move:

```js
atom.pointerLock.request( myCanvas, function (e) {
	console.log( 'Locked mouse move: ', e.movementX, e.movementY );
});
```

### atom.pointerLock.exit()
Unlock pointer if locked

```js
atom.pointerLock.exit()
```