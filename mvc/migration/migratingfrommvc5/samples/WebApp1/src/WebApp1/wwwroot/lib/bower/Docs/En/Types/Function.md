atom.fn
=======

Provides method to operate with functions:

### atom.fn.lambda(value)

Returns function, which returns value.

	window.onclick = atom.fn.lambda(false);

### atom.fn.after(onReady, fnName)

Returns hash of functions, which should be invoked before onReady will be invoked. Can be used for parallel invoking of several async callbacks.

	var callbacks = atom.fn.after(function (args) {
		console.log(
			args.fileReaded, // data from file
			args.dbQuery,    // data from database
			args.userInput   // data from user
		);
	}, 'fileReaded', 'dbQuery', 'userInput' );
	
	// here we subscribe to async events:
	
	new My.File.Read.Async( 'filename.txt', callbacks.fileReaded );
	new My.Db.Query.Async( 'SELECT * from `db`', callbacks.dbQuery );
	document.onclick = callbacks.userInput;